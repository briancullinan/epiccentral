using System;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using EPICCentral.Models;
using EPICCentral.Providers;
using EPICCentral.Utilities.Attributes;
using EPICCentral.Utilities.DataLayer;
using EPICCentral.Utilities.Filters;
using EPICCentral.Utilities.Membership;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using EPICCentralDL.Linq;

namespace EPICCentral.Controllers
{
    /// <summary>
    /// Controls all user editing, from listing, adding, and sending account created e-mails.
    /// </summary>
    public class UserController : DataTablesController
	{
		[Allow(Roles = "Service Administrator,Organization Administrator")]
		public ActionResult Add(int? organizationId, int? locationId)
		{
			var model = new AddUserModel { OrganizationId = organizationId, IsPresetOrganization = organizationId.HasValue };
			if (locationId.HasValue)
				model.Locations = new[] { locationId.Value };

			return PartialView(model);
		}

		[HttpPost]
		[Allow(Roles = "Service Administrator,Organization Administrator")]
		public ActionResult Add(int organizationId, AddUserModel model)
		{
			var organization = new OrganizationEntity(organizationId);
			if (organization.IsNew)
				throw new HttpException(404, SharedRes.Error.NotFound_Organization);

			var restrictionKey = EpicMembershipProvider.CreateSalt(16);

			if (ModelState.IsValid)
			{
				if (!Permissions.UserHasPermission("Edit", organization))
					throw new HttpException(401, SharedRes.Error.Unauthorized_OrganizationEdit);

				// Validate submitted role.
				if (!model.Role.HasValue || !(OrganizationUtils.GetAllowedRoles(organizationId).Any(r => r.RoleId == model.Role)))
					throw new HttpException(417, ControllerRes.Account.Invalid_RoleSpecified);

				// Locations are only valid for non-admin users.
				bool isAdmin = RoleUtils.IsRoleForAdmin(model.Role.Value);
				if (!isAdmin)
				{
					// Validate submitted locations are locations of the organization.
					if (model.Locations.Except(new LinqMetaData().Location.Where(l => l.OrganizationId == organizationId).Select(l => l.LocationId).ToList()).Any())
						throw new HttpException(404, SharedRes.Error.NotFound_Location);
				}

				Transaction transaction = new Transaction(IsolationLevel.ReadCommitted, "user add");

				try
				{
				    UserEntity user = new UserEntity
				                          {
				                              OrganizationId = organizationId,
				                              FirstName = model.FirstName,
				                              LastName = model.LastName,
				                              EmailAddress = model.EmailAddress,
				                              Username = string.Empty,
				                              Password = string.Empty
				                          };
					transaction.Add(user);

					// If role is non-admin, set up locations.
					if (!isAdmin)
					{
						foreach (var loc in model.Locations)
						{
							var assignedLocation = user.UserAssignedLocations.AddNew();
							assignedLocation.LocationId = loc;
						}
					}

					var userRole = user.Roles.AddNew();
					userRole.RoleId = model.Role.Value;

					var accountRestriction = new AccountRestrictionEntity
					                      		{
					                      				AccountRestrictionType = AccountRestrictionType.NewUser,
														RestrictionKey = restrictionKey,
					                      				EmailAddress = model.EmailAddress,
					                      				Parameters = string.IsNullOrWhiteSpace(model.Pin) ? string.Empty : model.Pin,
					                      				CreatedBy = Membership.GetUser().GetUserId().Id,
					                      				IPAddress = Request.ServerVariables["REMOTE_ADDR"]
					                      		};
					transaction.Add(accountRestriction);
					accountRestriction.Save();

					var userRestriction = user.UserAccountRestrictions.AddNew();
					userRestriction.AccountRestrictionId = accountRestriction.AccountRestrictionId;

					// Save recursively ... so assigned locations, role and restriction are saved, too.
					user.Save(true);

					transaction.Commit();
				}
				catch (Exception)
				{
					transaction.Rollback();
					throw new HttpException(500, SharedRes.Error.Error_DatabaseUnknown);
				}
				finally
				{
					transaction.Dispose();
				}

                // Send email for registration validation.
				SendRegistrationEmail(model, restrictionKey);

				// Add user complete. Modal dialog will close, so no response except "success".
				return new EmptyResult();
			}

			Response.StatusCode = 417;
			Response.TrySkipIisCustomErrors = true;

			return PartialView(model);
		}

        /// <summary>
        /// Allows a user to edit their own user account.
        /// </summary>
        /// <returns></returns>
        [ActionMenu(SelectAction = "View", Visible = false)]
		public ActionResult EditMe()
		{
			return View(new EditMeModel(Membership.GetUser().GetUserEntity()));
		}

		[HttpPost]
        public ActionResult EditMe(EditMeModel model)
		{
			if (ModelState.IsValid)
			{
			    var user = Membership.GetUser().GetUserEntity();
				if (user.IsNew)
					throw new HttpException(404, SharedRes.Error.NotFound_User);

				if (user.FirstName != model.FirstName || user.LastName != model.LastName | user.EmailAddress != model.EmailAddress)
				{
					user.FirstName = model.FirstName;
					user.LastName = model.LastName;
					user.EmailAddress = model.EmailAddress;

					user.Save();
				}

                if(CultureInfo.CurrentCulture.Name != model.Language)
                {
                    CultureInfo ci;
                    try
                    {
                        ci = new CultureInfo(model.Language);
                    }
                    catch
                    {
                        ci = new CultureInfo("en-US");
                    }
                    new UserSettingEntity(user.UserId, "Language") { UserId = user.UserId, Name = "Language", Value = ci.Name }.Save();
                    Session["lang"] = ci.Name;
                }

			    var regionSetting = user.Settings.FirstOrDefault(x => x.Name == "Region");
			    new UserSettingEntity(user.UserId, "RegionAuto")
			        {UserId = user.UserId, Name = "RegionAuto", Value = model.RegionAutoDetect.ToString()}.Save();
                if (regionSetting == null || regionSetting.Value != model.Region)
                {
                    new UserSettingEntity(user.UserId, "Region")
                        {UserId = user.UserId, Name = "Region", Value = model.Region}.Save();
                    Session["timezone"] = Utilities.Information.TimeZones.Zones.First(x => x.Type == model.Region).Zone;
                }

			    if (user.Username == model.UserName)
					return RedirectToAction("View");

				if (Membership.GetUser().ChangeUsername(model.UserName))
					return RedirectToAction("View");

				ModelState.AddModelError("", ControllerRes.Account.Invalid_DuplicateUsername);
			}

			return View(model);
		}

        /// <summary>
        /// Allows an administrator to edit any user account with the proper permissions.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="dtRequestModel"></param>
        /// <returns></returns>
		[Allow(Roles = "Service Administrator,Organization Administrator")]
		public ActionResult Edit(int? userId, [ModelBinder(typeof(DataTablesRequestModelBinder))] DataTablesRequestModel dtRequestModel)
		{
			var result = (Request.IsAjaxRequest() || ControllerContext.IsChildAction)
					   ? (ViewResultBase)PartialView(GetEditModel(userId))
					   : View(GetEditModel(userId));

			if (dtRequestModel == null)
				return result;

			return Query(result, dtRequestModel);
		}

		[HttpPost]
		[Allow(Roles = "Service Administrator,Organization Administrator")]
		public ActionResult Edit(int userId, EditUserModel model)
		{
			var user = new UserEntity(userId);
			if (user.IsNew)
				throw new HttpException(404, SharedRes.Error.NotFound_User);

			if (!RoleUtils.IsUserServiceAdmin() && !RoleUtils.IsUserOrgAdmin())
				throw new HttpException(401, SharedRes.Error.Unauthorized_UserEdit);

			if (RoleUtils.IsUserOrgAdmin() && user.OrganizationId != Membership.GetUser().GetUserId().OrganizationId)
				throw new HttpException(401, SharedRes.Error.Unauthorized_OrganizationEdit);

			if (ModelState.IsValid)
			{
				// Validate submitted role.
				if (!model.Role.HasValue || !(OrganizationUtils.GetAllowedRoles(model.OrganizationId).Any(r => r.RoleId == model.Role)))
					throw new HttpException(417, ControllerRes.Account.Invalid_RoleSpecified);

				// Locations are only valid for non-admin users.
				bool isAdmin = RoleUtils.IsRoleForAdmin(model.Role.Value);
				if (!isAdmin)
				{
					// Validate submitted locations are locations of the organization.
					if (model.Locations.Except(new LinqMetaData().Location.Where(l => l.OrganizationId == model.OrganizationId).Select(l => l.LocationId).ToList()).Any())
						throw new HttpException(404, SharedRes.Error.NotFound_Location);
				}

				// Set flag to indicate whether or not it's a pending registration.
				// Not using the posted back value in the model for security reasons.
				bool isPendingRegistration = user.UserAccountRestrictions.Count > 0 && user.UserAccountRestrictions[0].AccountRestriction.AccountRestrictionType == AccountRestrictionType.NewUser;

				// If not pending registration and username changed, validate username is unique.
				// Also, set flag to indicate if it's the current user changing own username.
				bool isCurrentUsernameChange = false;
				if (!isPendingRegistration && user.Username != model.UserName)
				{
					if (UserUtils.IsUsernameUsed(model.UserName))
						throw new HttpException(417, ControllerRes.Account.Invalid_DuplicateUsername);

					isCurrentUsernameChange = Membership.GetUser().GetUserId().Id == userId;
				}

				// Set flag to indicate whether or not the email address in a registration
				// has changed.
				bool isRegistrationChange = isPendingRegistration && user.EmailAddress != model.EmailAddress;

				Transaction transaction = new Transaction(IsolationLevel.ReadCommitted, "user add");

				try
				{
					transaction.Add(user);

					// Username is empty in pending registrations and can't be changed.
					// And current user username change isn't a simple change; don't do here.
					if (!isPendingRegistration && !isCurrentUsernameChange)
						user.Username = model.UserName;

					user.EmailAddress = model.EmailAddress;
					user.FirstName = model.FirstName;
					user.LastName = model.LastName;

					if (RoleUtils.IsUserServiceAdmin())
						user.IsActive = model.IsActive;

					// Did role change?
					if (user.Roles.Count == 0 || user.Roles[0].RoleId != model.Role.Value)
					{
						user.Roles.DeleteMulti();
						var userRole = user.Roles.AddNew();
						userRole.RoleId = model.Role.Value;
					}

					int[] newLocations = new int[0];
					int[] oldLocations;

					if (!isAdmin)
					{
						// User is not an admin. So find the set of locations user has been added to,
						// and the set of location user has been removed from.
						newLocations = model.Locations.Except(user.UserAssignedLocations.Select(l => l.LocationId)).ToArray();
						oldLocations = user.UserAssignedLocations.Select(l => l.LocationId).Except(model.Locations).ToArray();
					}
					else
						// User is admin. So user will be removed from all locations (admins aren't
						// assigned to locations).
						oldLocations = user.UserAssignedLocations.Select(l => l.LocationId).ToArray();

					if (oldLocations.Length > 0)
						user.UserAssignedLocations.DeleteMulti(UserAssignedLocationFields.UserId == user.UserId & UserAssignedLocationFields.LocationId == oldLocations);

					if (newLocations.Length > 0)
					{
						foreach (var loc in newLocations)
						{
							var assignedLocation = user.UserAssignedLocations.AddNew();
							assignedLocation.LocationId = loc;
						}
					}

					// If the registration email has changed, update the email address in the account
					// restriction.
					if (isRegistrationChange)
						user.UserAccountRestrictions[0].AccountRestriction.EmailAddress = model.EmailAddress;

					// Is current user changing own username?
					if (isCurrentUsernameChange)
					{
						// Changing the current user's username requres special handling because the
						// forms-auth cookies must be updated with the new username. The delegate will
						// be invoked to save the new username updating the datbase. In this case, it
						// needs to be done within the transaction created here.
						//
						// Have already validated the username as unique. So the only reason for this
						// to fail is with some exception thrown, which will be handled in the "catch".
						Membership.GetUser().ChangeUsername(model.UserName,
						                                    delegate(string username)
						                                    	{
						                                    		user.Username = username;
						                                    		user.Save(true);
						                                    		// ReSharper disable AccessToDisposedClosure
						                                    		transaction.Commit();
						                                    		// ReSharper restore AccessToDisposedClosure
						                                    	});
					}
					else
					{
						user.Save(true);
						transaction.Commit();
					}
				}
				catch (Exception)
				{
					transaction.Rollback();
					throw new HttpException(500, SharedRes.Error.Error_DatabaseUnknown);
				}
				finally
				{
					transaction.Dispose();
				}

				// If registration email has changed, need to re-send the registration email.
				if (isRegistrationChange)
					SendRegistrationEmail(model, user.UserAccountRestrictions[0].AccountRestriction.RestrictionKey);
			}

			return (Request.IsAjaxRequest() || ControllerContext.IsChildAction)
					   ? (ActionResult)new EmptyResult()
					   : View(GetEditModel(userId));
		}

        /// <summary>
        /// A simple view of the user account and selected options such as regional and language settings.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [ActionMenu(Rank = 200)]
		public ActionResult View(int? userId)
		{
			UserEntity user;
			if (userId.HasValue)
			{
				user = new UserEntity(userId.Value);
				if (user.IsNew)
					throw new HttpException(404, SharedRes.Error.NotFound_User);
			}
			else
				user = Membership.GetUser().GetUserEntity();

			if (!Permissions.UserHasPermission("View", user))
				throw  new HttpException(401, SharedRes.Error.Unauthorized_User);

			return (Request.IsAjaxRequest() || ControllerContext.IsChildAction)
						   ? (ActionResult)PartialView(user)
						   : View(user);
		}

        /// <summary>
        /// Primary function of the page to list the users in the system.
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="organizationId"></param>
        /// <param name="dtRequestModel"></param>
        /// <returns></returns>
        [ActionMenu(Rank = 500, ResourceName = "UserList_Users")]
        public ActionResult List(int? locationId, int? organizationId, [ModelBinder(typeof(DataTablesRequestModelBinder))] DataTablesRequestModel dtRequestModel)
		{
			var result = (Request.IsAjaxRequest() || ControllerContext.IsChildAction)
					   ? (ViewResultBase)PartialView(GetListModel(locationId, organizationId))
					   : View(GetListModel(locationId, organizationId));

			if (dtRequestModel == null)
				return result;

			return Query(result, dtRequestModel);
		}

        /// <summary>
        /// Sends the registration e-mail again.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
		[Allow(Roles = "Service Administrator,Organization Administrator")]
		public ActionResult ResendEmail(int userId)
		{
			var user = new UserEntity(userId);
			if (user.IsNew)
				throw new HttpException(404, SharedRes.Error.NotFound_User);

			if (user.UserAccountRestrictions.Count == 0 || user.UserAccountRestrictions[0].AccountRestriction.AccountRestrictionType != AccountRestrictionType.NewUser)
				throw new HttpException(417, ControllerRes.Account.NotFound_PendingRegistration);

			SendRegistrationEmail(user);

			return new EmptyResult();
		}

		private IQueryable<UserEntity> GetListModel(int? locationId, int? organizationId)
		{
			LinqMetaData m = new LinqMetaData();

			var user = Membership.GetUser().GetUserEntity();

			if (!organizationId.HasValue)
			{
				if (RoleUtils.IsUserServiceAdmin())
				{
					if (!locationId.HasValue)
						// Service admin gets all users.
						return m.User;

					// Location specified, so just users assigned to that location.
					return m.User
								.Where(
									x =>
									x.UserAssignedLocations.Any(
										y => y.LocationId == locationId.Value));
				}

				// Other users assume their organization ID.
				organizationId = user.OrganizationId;
			}

			// View needs this for building URLs.
			ViewData.Add("organizationId", organizationId.Value);
            var organization = new OrganizationEntity(organizationId.Value);
            if (organization.IsNew)
                throw new HttpException(404, SharedRes.Error.NotFound_Organization);
            ViewData.Add("organization", organization);

			if (!locationId.HasValue)
			{
				if (RoleUtils.IsUserServiceAdmin() || RoleUtils.IsUserOrgAdmin())
					// All users for the specified organization.
					return new LinqMetaData().User.Where(u => u.OrganizationId == organizationId.Value);

				// Other users only see unrestricted users at their assigned locations.
				// TODO: Decide if we even want to allow this.
				var query = from ual1 in m.UserAssignedLocation
							join ual2 in m.UserAssignedLocation on ual1.LocationId equals ual2.LocationId
							join usr in m.User on ual2.UserId equals usr.UserId
							where ual1.UserId == user.UserId && !usr.UserAccountRestrictions.Any()
							select usr;
				return query;
			}

			var location = new LocationEntity(locationId.Value);
			if (location.IsNew || location.OrganizationId != organizationId.Value)
				throw new HttpException(404, SharedRes.Error.NotFound_Location);
            ViewData.Add("location", location);

			// View needs this for building URLs.
			ViewData.Add("locationId", locationId.Value);

			var users = m.User
							.Where(
								x =>
								x.UserAssignedLocations.Any(
									y => y.LocationId == locationId.Value));

			// Service admin can see all users for any organization.
			if (RoleUtils.IsUserServiceAdmin())
				return users;

			// Other users must be from the organization.
			if (organizationId.Value != user.OrganizationId)
				throw new HttpException(401, SharedRes.Error.Unauthorized_User);

			// Organization admin can see all the users of the organization.
			if (RoleUtils.IsUserOrgAdmin())
				return users;

			// Other users can only see unrestricted users in their location.
			if (user.UserAssignedLocations.Count(l => l.LocationId == locationId.Value) > 0)
				return users.Where(u => !u.UserAccountRestrictions.Any());

			throw new HttpException(401, SharedRes.Error.Unauthorized_User);
		}

		private static EditUserModel GetEditModel(int? userId)
		{
			// If no user ID provided, return logged in user.
			if (!userId.HasValue)
				return new EditUserModel(Membership.GetUser().GetUserEntity());

			var user = new UserEntity(userId.Value);
			if (user.IsNew)
				throw new HttpException(404, SharedRes.Error.NotFound_User);

			// Service admin can edit all users.
			if (RoleUtils.IsUserServiceAdmin())
				return new EditUserModel(user);

			// Org admin can edit all user in his/her organization.
			if (RoleUtils.IsUserOrgAdmin() && user.OrganizationId == Membership.GetUser().GetUserId().OrganizationId)
				return new EditUserModel(user);

			throw new HttpException(401, SharedRes.Error.Unauthorized_User);
		}

        /// <summary>
        /// Sends a registration email for the newly created user.
        /// </summary>
        /// <param name="user"></param>
		private void SendRegistrationEmail(UserEntity user)
		{
			var restriction = user.UserAccountRestrictions[0].AccountRestriction;
			SendRegistrationEmail(restriction.EmailAddress, user.FirstName, user.LastName, restriction.RestrictionKey);
		}

		private void SendRegistrationEmail(BaseUserModel model, string restrictionKey)
		{
			SendRegistrationEmail(model.EmailAddress, model.FirstName, model.LastName, restrictionKey);
		}

		private void SendRegistrationEmail(string emailAddress, string firstName, string lastName, string key)
		{
			var emailModel = new KeyedEmailModel
			                 	{
			                 			EmailAddress = emailAddress,
			                 			FirstName = firstName,
			                 			LastName = lastName,
			                 			Key = key
			                 	};

			var message = ControllerContext.Render("_AddEmailPartial", new ViewDataDictionary(emailModel)).ToString();
			EmailUtils.Send(message, emailAddress, firstName, lastName, subject: ControllerRes.Account.Email_SubjectUserRegistration);
		}
	}
}
