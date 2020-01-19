using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using EPICCentral.Utilities.Attributes;
using EPICCentral.Utilities.DataLayer;
using MvcApi;
using ControllerRes;
using EPICCentral.Models;
using EPICCentral.Providers;
using EPICCentral.Utilities.Filters;
using EPICCentral.Utilities.Membership;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;

[assembly: InternalsVisibleTo("EPICCentralUnitTest", AllInternalsVisible = true)]

namespace EPICCentral.Controllers
{
    /// <summary>
    /// Controls all interfaces for logging in to EPIC Central and account management, such as Password Reset, Registration, Logging on and off.
    /// This does not control modifying a user account.
    /// </summary>
    // To combine default menu functionality with the custom menu, 
    //    one would simply add the attribute [ControllerMenu] and both class menus and LoggedOffMenu would be shown.
    [LoggedOffMenu]
    public class AccountController : Controller
	{

        /// <summary>
        /// Used above, overrides the default ControllerMenuAttribute generated automatically for every controller
        /// Displays the logged off menu when a user is logged out.
        /// No other Menu attributes are used in this controller, if that changes merge the condition below with base.GetSubMenu()
        /// </summary>
        private class LoggedOffMenuAttribute : ControllerMenuAttribute
        {
            [ActionMenu(Path = "~/Account/LogOn", ResourceName = "AccountLogOn_LogOn", Rank = 1)]
            [ActionMenu(Path = "http://www.epicdiagnostics.com/", ResourceName = "CorporateWebsite", Rank = 2)]
            [ActionMenu(Path = "http://www.epicdiagnostics.com/contact", ResourceName = "ContactUs", Rank = 3)]
            public override IEnumerable<ActionMenuAttribute> GetSubMenu()
            {
                if(!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)

                {
                    return
                        MethodBase.GetCurrentMethod().GetCustomAttributes(typeof (ActionMenuAttribute), false).Cast
                            <ActionMenuAttribute>();
                }
                return base.GetSubMenu();
            }
        }

        /// <summary>
        /// The basic LogOn functionality accepts a Username and Password
        /// </summary>
        /// <returns></returns>
        [RateLimit]
        public ActionResult LogOn()
        {
			return View();
		}

		// POST: /Account/LogOn
		[HttpPost]
        [RateLimit]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
		{
			if (ModelState.IsValid)
			{
				if (Membership.ValidateUser(model.UserName, model.Password))
				{
				    Session["lang"] = null;
				    Session["timezone"] = null;

                    Global.FormsAuthentication.SetAuthCookie(model.UserName, false);
					if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
						&& !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
					{
						return Redirect(returnUrl);
					}

					return RedirectToAction("Index", "Home");
				}

				string message = Account.Invalid_UsernamePassword;

				var user = Membership.GetUser(model.UserName, false);
				if (user != null)
				{
					if (!user.IsApproved)
						message = user.GetUserEntity().UserAccountRestrictions[0].AccountRestriction.AccountRestrictionType == AccountRestrictionType.NewUser
							? Account.Invalid_IncompleteRegistration
							: Account.Invalid_AccountReset;
					else if (user.IsLockedOut)
						message = Account.Invalid_AccountLocked;
				}

				ModelState.AddModelError("", message);
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		/// <summary>
		/// The basic LogOff function.  Must force the session to be cleared.
		/// </summary>
		/// <returns></returns>
		public ActionResult LogOff()
		{
            Global.FormsAuthentication.SignOut();
            Session.Abandon();

			return RedirectToAction("LogOn", "Account");
		}

		/// <summary>
		/// Registration occurs after the user account is created by an administrator and the e-mail is sent.
		/// </summary>
		/// <param name="registrationKey"></param>
		/// <param name="email"></param>
		/// <returns></returns>
		public ActionResult Register(string registrationKey, string email)
		{
			// Get the restriction object with matching key and email address.
			var accountRestriction = new LinqMetaData().AccountRestriction.First(u => u.RestrictionKey == registrationKey && u.EmailAddress == email);
			if (accountRestriction == null)
				throw new HttpException(404, SharedRes.Error.NotFound_User);

			// It must be active and it must reference only ONE user object.
			if (!accountRestriction.IsActive || accountRestriction.UserAccountRestrictions.Count != 1)
				throw new HttpException(404, SharedRes.Error.NotFound_User);

			// The user account must also be active.
			if (!accountRestriction.UserAccountRestrictions[0].User.IsActive)
				throw new HttpException(412, Account.Invalid_InactiveAccount);

			// Show account setup completion form.
			var model = new RegisterModel { Email = email, OriginalEmail = email, RegistrationKey = registrationKey };

			return View(model);
		}

		// POST: /Account/Register
		[HttpPost]
		public ActionResult Register(RegisterModel model)
		{
			if (ModelState.IsValid)
			{
				// Get the restriction object with matching key and email address.
				var accountRestriction = new LinqMetaData().AccountRestriction.First(u => u.RestrictionKey == model.RegistrationKey && u.EmailAddress == model.OriginalEmail);
				if (accountRestriction == null)
					throw new HttpException(404, SharedRes.Error.NotFound_User);

				// It must be active and it must reference only ONE user object.
				if (!accountRestriction.IsActive || accountRestriction.UserAccountRestrictions.Count != 1)
					throw new HttpException(404, SharedRes.Error.NotFound_User);

				// The user account must also be active.
				if (!accountRestriction.UserAccountRestrictions[0].User.IsActive)
					throw new HttpException(412, Account.Invalid_InactiveAccount);

				// If there's a PIN required, the one in the form must match.
				if (string.IsNullOrEmpty(accountRestriction.Parameters) || accountRestriction.Parameters == model.Pin.Trim())
				{
					var user = accountRestriction.UserAccountRestrictions[0].User;

					// Attempt to register the user
					MembershipCreateStatus createStatus;
					Membership.CreateUser(model.UserName, model.Password, model.Email, null, null, true, user.UserId, out createStatus);

					if (createStatus == MembershipCreateStatus.Success)
					{
						// Successfully created. Remove the join between the restriction and the user.
						// Make the restriction inactive; it's kept around for auditing.
						accountRestriction.UserAccountRestrictions[0].Delete();
						accountRestriction.RemovalTime = DateTime.UtcNow;
						accountRestriction.IsActive = false;
						accountRestriction.Save();

						// Set user to be authenticated and redirect to Home.
						Global.FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
						return RedirectToAction("Index", "Home");
					}

					// Account creation error. Convert error code to message to display.
					ModelState.AddModelError("", ErrorCodeToString(createStatus));
				}
				else
					ModelState.AddModelError("", Account.Invalid_RegistrationPIN);
			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}

		// GET: /Account/ChangePassword
		/// <summary>
		/// Change the users password.
		/// </summary>
		/// <returns></returns>
		[Authorize]
		public ActionResult ChangePassword()
		{
			var user = new UserEntity(Membership.GetUser().GetUserId().Id);
			ViewData["FirstName"] = user.FirstName;
			ViewData["LastName"] = user.LastName;
			return View(new ChangePasswordModel());
		}

		// POST: /Account/ChangePassword
		/// <summary>
		/// Post callback for changing the users password.
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[Authorize]
		[HttpPost]
		public ActionResult ChangePassword(ChangePasswordModel model)
		{
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    changePasswordSucceeded = Membership.GetUser().ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                    return RedirectToAction("ChangePasswordSuccess");

                ModelState.AddModelError("", Account.Error_ChangePassword);
            }

		    // If we got this far, something failed, redisplay form
			return View(model);
		}

		// GET: /Account/ChangePasswordSuccess
		public ActionResult ChangePasswordSuccess()
		{
			return View();
		}

		// GET: /Account/PasswordPolicy
        /// <summary>
        /// This specifies characters are required for a password.
        /// Current must contain at least 1 number 1 uppercase 1 lowercase 1 special character.
        /// Specified all of the messages for each requirement.
        /// </summary>
        /// <returns></returns>
		[Api]
		public ActionResult PasswordPolicy()
		{
			PasswordStrengthMeterSettings meterSettings = new PasswordStrengthMeterSettings {Specials = "-_`~!@#$%^&*:;'\"?/\\,.|=+(){}<>[]", ShowScore = false, ShowHint = true};

			meterSettings.AddPolicy(new PasswordStrengthMeterSettings.Policy { Type = "required", MinLength = 8, MaxLength = 24, NumLowers = 1, NumUppers = 1, NumDigits = 1, NumSpecials = 1});
			meterSettings.AddPolicy(new PasswordStrengthMeterSettings.Policy { Type = "recommended", MinLength = 8, MaxLength = 24, NumLowers = 2, NumUppers = 2, NumDigits = 2, NumSpecials = 2 });

			PasswordStrengthMeterSettings.HintMessages messages = new PasswordStrengthMeterSettings.HintMessages
			                    	{
			                    			NoSpace = Account.PasswordStrength_NoSpace,
			                    			TooLong = Account.PasswordStrength_TooLong,
			                    			InvalidCharacter = Account.PasswordStrength_InvalidCharacter,
			                    			AtLeast = Account.PasswordStrength_AtLeast,
			                    			MakeStronger = Account.PasswordStrength_MakeStronger,
			                    			StrongPassword = Account.PasswordStrength_StrongPassword,
			                    			Valid = Account.PasswordStrength_Valid,
			                    			Invalid = Account.PasswordStrength_Invalid
			                    	};

			messages.AddNeed(new PasswordStrengthMeterSettings.HintMessages.Need { Type = "characters", Singular = Account.PasswordStrength_MoreCharsSingular, Plural = Account.PasswordStrength_MoreCharsPlural });
			messages.AddNeed(new PasswordStrengthMeterSettings.HintMessages.Need { Type = "lowers", Singular = Account.PasswordStrength_MoreLowersSingular, Plural = Account.PasswordStrength_MoreLowersPlural });
			messages.AddNeed(new PasswordStrengthMeterSettings.HintMessages.Need { Type = "uppers", Singular = Account.PasswordStrength_MoreUppersSingular, Plural = Account.PasswordStrength_MoreUppersPlural });
			messages.AddNeed(new PasswordStrengthMeterSettings.HintMessages.Need { Type = "digits", Singular = Account.PasswordStrength_MoreDigitsSingular, Plural = Account.PasswordStrength_MoreDigitsPlural });
			messages.AddNeed(new PasswordStrengthMeterSettings.HintMessages.Need { Type = "specials", Singular = Account.PasswordStrength_MoreSpecialsSingular, Plural = Account.PasswordStrength_MoreSpecialsPlural });

			meterSettings.Messages = messages;

			return new ApiResult(meterSettings);
		}

		// GET: /Account/ValidateUsername
    	/// <summary>
    	/// Determines if a username is valid and in use.
    	/// It is normally bad practice to tell the client if a username is in use because it narrows down bruteforcing to a single target account.
    	/// However, only administrators can create accounts and you must be logged in to use this function so we know everyone who is aware of this function.
    	/// </summary>
    	/// <param name="username"></param>
    	/// <param name="key"> </param>
    	/// <returns></returns>
    	[Api]
		public ActionResult ValidateUsername(string username, string key = null)
        {
        	string currentUsername = string.Empty;

			// Get current authenticated user, if there is one.
            var user = Membership.GetUser();
			if (user == null)
			{
				// No user authenticated. Check if there is an account restriction.
				if (new LinqMetaData().AccountRestriction.All(u => u.RestrictionKey != key))
					// None. Disallow access.
					throw new HttpException(401, SharedRes.Error.Unauthorized);
			}
			else
				// User authenticated. Get username.
				currentUsername = user.UserName;

			int minLength = EpicMembershipProvider.MinUsernameLength;
			bool isValid = false;
			string feedback;
			if (username != currentUsername)
			{
				if (!username.Contains(" "))
				{
					if (username.Length >= minLength)
					{
						if (!UserUtils.IsUsernameUsed(username))
						{
							isValid = true;
							feedback = Account.Username_Valid;
						}
						else
							feedback = Account.Username_InUse;
					}
					else
					{
						var need = minLength - username.Length;
						feedback = string.Format(need > 1 ? Account.Username_HelpPlural : Account.Username_HelpSingular, need);
					}
				}
				else
					feedback = Account.Username_NoSpace;
			}
			else
			{
				// This grandfathers in existing usernames that don't meet the standard.
				isValid = true;
				feedback = Account.Username_Valid;
			}

			return new ApiResult(new Dictionary<string, object> { { "isValid" , isValid }, { "feedback", feedback }});
		}

		// GET: /Account/Reset
		[Allow(Users = "?")]
		public ActionResult Reset(string username = null)
		{
			var model = new ResetModel();
			if (!string.IsNullOrWhiteSpace(username))
				model.UserName = username;

			return View();
		}

		// POST: /Account/Reset
        /// <summary>
        /// Basic reset password function.  Adds account restriction to all user accounts associated with an email address 
        /// until the user completes the password reset on at least one of their accounts.
        /// TODO: A user should be able to cancel the password reset if it was received or started in error.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		[Allow(Users = "?")]
		[HttpPost]
        [RateLimit]
		public ActionResult Reset(ResetModel model)
		{
			string message;

			// Email address must be specified.
			if (!string.IsNullOrWhiteSpace(model.Email))
			{
				// Get all accounts with that email address; check if there are any.
				var accounts = new LinqMetaData().User.Where(u => u.EmailAddress == model.Email);
				if (accounts.Any())
				{
					// Have some accounts. Filter out all but the unrestricted ones.
					accounts = GetUnrestictedOnly(accounts, model.UserName, out message);
					if (accounts.Any())
					{
						// Have unrestricted accounts. They will be reset. Assume there's
						// more than one. If more than one, we don't necessarily know the
						// person's name.
						string firstName = null;
						string lastName = null;
						if (accounts.Count() == 1)
						{
							// Only one. So get person's name.
							var account = accounts.First();
							firstName = account.FirstName;
							lastName = account.LastName;
						}

						// Create restriction on each account, send email and tell user it's done.
						var key = CreateRestriction(accounts, model.Email, firstName != null);
						SendResetEmail(model.Email, key, firstName, lastName);
						return RedirectToAction("ResetSuccess");
					}
				}
				else
					// No accounts with the specified email address. Tell user.
					message = Account.Invalid_EmailNotMatched;
			}
			else
				// No email address. Tell user to enter one.
				message = Account.Invalid_EmailNotSpecified;

			ModelState.AddModelError("", message);

			// If we got this far, something failed, redisplay form.
			return View();
		}

		// GET: /Account/ResetSuccess
		[Allow(Users = "?")]
		public ActionResult ResetSuccess()
		{
			return View();
		}

		// GET: /Account/ResetCompletion
        /// <summary>
        /// Resets the password and removes account restrictions for an email address.
        /// </summary>
        /// <param name="resetKey"></param>
        /// <param name="email"></param>
        /// <returns></returns>
		[Allow(Users = "?")]
		public ActionResult ResetCompletion(string resetKey, string email)
		{
			// Get the restriction object with matching key and email address.
			var accountRestriction = new LinqMetaData().AccountRestriction.First(u => u.RestrictionKey == resetKey && u.EmailAddress == email);
			if (accountRestriction == null)
				throw new HttpException(404, SharedRes.Error.NotFound_User);

			// It must be active.
			if (!accountRestriction.IsActive)
				throw new HttpException(404, SharedRes.Error.NotFound_User);

			ResetCompletionModel model = new ResetCompletionModel();
			if (accountRestriction.UserAccountRestrictions.Count > 1)
			{
				model.UserNames = accountRestriction.UserAccountRestrictions.Where(r => r.User.IsActive).Select(u => u.User.Username).ToList();

				// Must be at least one.
				if (model.UserNames.Count == 0)
					throw new HttpException(412, Account.Invalid_InactiveAccount);

				model.Step = 1;
			}
			else
			{
				// The user account must also be active.
				if (!accountRestriction.UserAccountRestrictions[0].User.IsActive)
					throw new HttpException(412, Account.Invalid_InactiveAccount);

				model.UserName = accountRestriction.UserAccountRestrictions[0].User.Username;
				model.Step = 2;
			}

			model.ResetKey = resetKey;
			model.OriginalEmail = email;

			return View(model);
		}

		// POST: /Account/ResetCompletion
		[Allow(Users = "?")]
		[HttpPost]
		public ActionResult ResetCompletion(ResetCompletionModel model)
		{
			if (ModelState.IsValid)
			{
				// Get the restriction object with matching key and email address.
				var accountRestriction = new LinqMetaData().AccountRestriction.First(u => u.RestrictionKey == model.ResetKey && u.EmailAddress == model.OriginalEmail);
				if (accountRestriction == null)
					throw new HttpException(404, SharedRes.Error.NotFound_User);

				// It must be active.
				if (!accountRestriction.IsActive)
					throw new HttpException(404, SharedRes.Error.NotFound_User);

				if (model.Step == 1)
				{
					var user = accountRestriction.UserAccountRestrictions.Where(r => r.User.Username == model.UserName).Select(u => u.User).ToArray()[0];
					if (!user.IsActive)
						throw new HttpException(404, SharedRes.Error.NotFound_User);

					model.Step = 2;
				}
				else
				{
					// NOTE: Presently validating presence of password here because it can't be required for
					// step 1. Need to fix this so the standard validation can be used.
					if (!string.IsNullOrWhiteSpace(model.Password))
					{
						if (accountRestriction.UserAccountRestrictions.Any(r => r.User.Username == model.UserName))
						{
							var user = Membership.GetUser(model.UserName);
							if (user != null && !user.IsLockedOut)
							{
								if (user.SetPassword(model.Password))
								{
									// Successfully rest. Remove the joins between the restriction and the users.
									// Make the restriction inactive; it's kept around for auditing.
									foreach (var restriction in accountRestriction.UserAccountRestrictions)
										restriction.Delete();

									accountRestriction.RemovalTime = DateTime.UtcNow;
									accountRestriction.IsActive = false;
									accountRestriction.Save();

									return RedirectToAction("ResetCompletionSuccess");
								}

								ModelState.AddModelError("", Account.Error_PasswordResetFailed);
							}
							else
								ModelState.AddModelError("", Account.Invalid_AccountLocked);
						}
						else
							throw new HttpException(404, SharedRes.Error.NotFound_User);
					}
					else
						ModelState.AddModelError("", Account.Invalid_PasswordNotSpecified);
				}
			}

			ModelState.SetModelValue("Step", new ValueProviderResult(null, null, null));

			return View(model);
		}

		// GET: /Account/ResetCompletionSuccess
		[Allow(Users = "?")]
		public ActionResult ResetCompletionSuccess()
		{
			return View();
		}

		/// <summary>
		/// Get the set of accounts in the specified set of accounts that are not
		/// restricted and can be reset.
		/// </summary>
		/// <param name="accounts">set of accounts for a particular email address</param>
		/// <param name="username">username entered by user, if any</param>
		/// <param name="message">message to display for user when there's an issue</param>
		/// <returns>queryable set of accounts with no restrictions</returns>
		private IQueryable<UserEntity> GetUnrestictedOnly(IQueryable<UserEntity> accounts, string username, out string message)
		{
			message = null;

			// Was a username specfied?
			if (!string.IsNullOrWhiteSpace(username))
			{
				// Yes. Usernames are unique. Get the one account that matches.
				// Check if found.
				var oneAccount = accounts.Where(a => a.Username == username);
				if (oneAccount.Any())
				{
					// Found it. Does it have any restrictions?
					var restrictions = oneAccount.First().UserAccountRestrictions;
					if (restrictions.Count == 0)
						// No restrictions. It will be reset.
						return oneAccount;

					// Has a restriction. Check the type.
					if (restrictions[0].AccountRestriction.AccountRestrictionType != AccountRestrictionType.NewUser)
					{
						// It's a password reset. Resend the email and set message
						// for user.
						var user = oneAccount.First();
						SendResetEmail(user.EmailAddress, restrictions[0].AccountRestriction.RestrictionKey, user.FirstName, user.LastName);
						message = Account.Invalid_AccountAlreadyReset;
					}
					else
						// It's a new account. Set message to tell user.
						message = Account.Invalid_AccountRegistrationIncomplete;
				}
				else
					// No account with that user name. Tell user.
					message = Account.Invalid_EmailUsernameMismatch;

				// Return an empty account set.
				return new List<UserEntity>().AsQueryable();
			}

			// No username specified. Get both the set of new accounts and the set
			// of restricted accounts with the specified email address.
			var newAccounts = accounts.Where(a => a.UserAccountRestrictions.Any(r => r.AccountRestriction.AccountRestrictionType == AccountRestrictionType.NewUser));
			var resetAccounts = accounts.Where(a => a.UserAccountRestrictions.Any(r => r.AccountRestriction.AccountRestrictionType != AccountRestrictionType.NewUser));

			// Do the two sets contain all accounts?
			if (resetAccounts.Count() + newAccounts.Count() == accounts.Count())
			{
				// Yes. So none will be reset. Have any been previously reset?
				if (resetAccounts.Any())
				{
					// Yes. Resend all reset emails again and set message for user.
					ResendResetEmail(resetAccounts.First().EmailAddress);
					message = Account.Invalid_AccountsAlreadyReset;
				}
				else
					// No. Then they are all new accounts and can't be reset.
					message = newAccounts.Count() > 1 ? Account.Invalid_AccountsRegistrationIncomplete
													  : Account.Invalid_AccountRegistrationIncomplete;

				// Return an empty account set.
				return new List<UserEntity>().AsQueryable();
			}

			// There are some accounts to reset. Return the ones not in the new
			// and already reset sets.
			return accounts.Except(newAccounts).Except(resetAccounts);
		}

        /// <summary>
        /// Creates a restriction on accounts with the specified e-mail address indication that the user is not allowed to log in while their account is being reset.
        /// </summary>
        /// <param name="accounts">A list of user accounts associated with the e-mail address</param>
        /// <param name="emailAddress">The e-mail address entered from the Reset page</param>
        /// <param name="haveUsername">If the username has also been forgotten or a normal reset where the user knows their username</param>
        /// <returns></returns>
		private string CreateRestriction(IEnumerable<UserEntity> accounts, string emailAddress, bool haveUsername)
		{
			var restrictionKey = EpicMembershipProvider.CreateSalt(16);

			var accountRestriction = new AccountRestrictionEntity
				                        {
				                         		AccountRestrictionType = haveUsername ? AccountRestrictionType.PasswordReset : AccountRestrictionType.LostUsername,
				                         		RestrictionKey = restrictionKey,
				                         		EmailAddress = emailAddress,
				                         		IPAddress = Request.ServerVariables["REMOTE_ADDR"]
				                        };

			foreach (var account in accounts)
			{
				// If account is already restricted, don't create a new restriction.
				// It could be restricted because it's a new account or due to a prior
				// password reset.
				if (account.UserAccountRestrictions.Count == 0)
				{
					var restriction = accountRestriction.UserAccountRestrictions.AddNew();
					restriction.UserId = account.UserId;
				}
			}

			accountRestriction.Save(true);

			return restrictionKey;
		}

		private void ResendResetEmail(string emailAddress)
		{
			var restrictions = new LinqMetaData().AccountRestriction.Where(r => r.IsActive && r.EmailAddress == emailAddress);
			foreach (var restriction in restrictions.Where(restriction => restriction.AccountRestrictionType != AccountRestrictionType.NewUser))
			{
				if (restriction.UserAccountRestrictions.Count > 1)
					SendResetEmail(restriction.EmailAddress, restriction.RestrictionKey);
				else
					SendResetEmail(restriction.EmailAddress, restriction.RestrictionKey, restriction.UserAccountRestrictions[0].User.FirstName, restriction.UserAccountRestrictions[0].User.LastName);
			}
		}

        /// <summary>
        /// Generates the e-mail using the extension method ControllerContext.Render()
        /// </summary>
        /// <param name="emailAddress">The e-mail address to send the reset email to.</param>
        /// <param name="key">The unique secret key sent only to that e-mail address that verifies it reached the right person and they can reset their account.</param>
        /// <param name="firstName">First name of the user.</param>
        /// <param name="lastName">Last name of the user.</param>
		private void SendResetEmail(string emailAddress, string key, string firstName = null, string lastName = null)
		{
			// Send email for password reset completion.
			var emailModel = new KeyedEmailModel
								{
									EmailAddress = emailAddress,
									FirstName = firstName,
									LastName = lastName,
									Key = key
								};

			var message = ControllerContext.Render("_ResetEmailPartial", new ViewDataDictionary(emailModel)).ToString();
			EmailUtils.Send(message, emailAddress, firstName, lastName, subject: Account.Email_SubjectPasswordReset);
		}

        /// <summary>
        /// Converts a .Net Membership.Create() status code to a translated error message to display to the client.
        /// Typically it is a good idea to send as little information about other user accounts as possibly, such as only
        ///  displaying "Invalid username or password" for every error.
        /// However, in our scenario, administrators are the only ones who create accounts and we know everyone who accesses the registration page.
        /// </summary>
        /// <param name="createStatus"></param>
        /// <returns></returns>
		private static string ErrorCodeToString(MembershipCreateStatus createStatus)
		{
			// See http://go.microsoft.com/fwlink/?LinkID=177550 for
			// a full list of status codes.
			switch (createStatus)
			{
			case MembershipCreateStatus.DuplicateUserName:
				return Account.Invalid_DuplicateUsername;

			// NOT USED
			case MembershipCreateStatus.DuplicateEmail:
				return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

			case MembershipCreateStatus.InvalidPassword:
				return Account.Invalid_PasswordBad;

			case MembershipCreateStatus.InvalidEmail:
				return Account.Invalid_EmailBad;

			// NOT USED
			case MembershipCreateStatus.InvalidAnswer:
				return "The password retrieval answer provided is invalid. Please check the value and try again.";

			// NOT USED
			case MembershipCreateStatus.InvalidQuestion:
				return "The password retrieval question provided is invalid. Please check the value and try again.";

			case MembershipCreateStatus.InvalidUserName:
				return Account.Invalid_UsernameBad;

			case MembershipCreateStatus.ProviderError:
				return Account.Error_AuthProvider;

			// NOT USED
			case MembershipCreateStatus.UserRejected:
				return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

			default:
				return Account.Error_UserCreateUnknown;
			}
		}
	}
}
