using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using EPICCentral.Utilities.Crypto;
using EPICCentral.Utilities.DataLayer;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using EPICCentralDL.Linq;

namespace EPICCentral.Providers
{
	public class EpicMembershipProvider : BaseMembershipProvider
	{
		private const string PASSWORD_COMPLEXITY = @"(?=[-_`~!@#$%^&*:;'""?/\\,.|=+(){}<>[\]a-zA-Z0-9]*?[A-Z])(?=[-_`~!@#$%^&*:;'""?/\\,.|=+(){}<>[\]a-zA-Z0-9]*?[a-z])(?=[-_`~!@#$%^&*:;'""?/\\,.|=+(){}<>[\]a-zA-Z0-9]*?[0-9])(?=[-_`~!@#$%^&*:;'""?/\\,.|=+(){}<>[\]a-zA-Z0-9]*?[-_`~!@#$%^&*:;'""?/\\,.|=+(){}<>[\]])[-_`~!@#$%^&*:;'""?/\\,.|=+(){}<>[\]a-zA-Z0-9]{8,}";
		private const int MINIMUM_USERNAME_LENGTH = 8;

		public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
		{
			var userId = (int)providerUserKey;
			var user = new UserEntity(userId);
			if (!user.IsNew && !user.LastLoginTime.HasValue)
			{
				if (username.Length >= MinUsernameLength && !username.Contains(" "))
				{
					if (ValidateNewPassword(password))
					{
						var args = new ValidatePasswordEventArgs(username, password, true);
						OnValidatingPassword(args);
						if (!args.Cancel)
						{
							if (UserUtils.GetByUsername(username) == null)
							{
								Transaction transaction = new Transaction(IsolationLevel.ReadCommitted, "user initialization");

								try
								{
									transaction.Add(user);

									user.Username = username;
									user.EmailAddress = email;
									SetPassword(user, password, transaction);

									user.Save();

									transaction.Commit();

									status = MembershipCreateStatus.Success;

									return GetUser(username, true);
								}
								catch (Exception)
								{
									transaction.Rollback();
									status = MembershipCreateStatus.ProviderError;
								}
								finally
								{
									transaction.Dispose();
								}
							}
							else
								status = MembershipCreateStatus.DuplicateUserName;
						}
						else
							status = MembershipCreateStatus.InvalidPassword;
					}
					else
						status = MembershipCreateStatus.InvalidPassword;
				}
				else
					status = MembershipCreateStatus.InvalidUserName;
			}
			else
				status = MembershipCreateStatus.InvalidProviderUserKey;

			return null;
		}

		public override bool ValidateUser(string username, string password)
		{
			// Get user object from database.
			var user = UserUtils.GetByUsername(username);
			if (user != null)
			{
				// User object present. Create membership user; need to check status.
				var membershipUser = GetMembershipUser(user);

				// Can the user log in?
				if (membershipUser.IsApproved && !membershipUser.IsLockedOut)
				{
					// Yes, can log in. Check password.
					if (ValidatePassword(user, password))
					{
						user.LastLoginTime = DateTime.UtcNow;
						user.Save();

						return true;
					}
				}
			}

			// Validation has failed.
			return false;
		}

		public override MembershipUser GetUser(string username, bool userIsOnline)
		{
			// Get user object from database.
		    UserEntity user = UserUtils.GetByUsername(username);
			if (user != null)
			{
				// Create membership user.
				var membershipUser = GetMembershipUser(user);

				// Need to update last activity?
				if (userIsOnline)
				{
					user.LastActivityTime = DateTime.UtcNow;
					user.Save();
				}

				return membershipUser;
			}

			// Not found.
			return null;
		}

		public override bool ChangePassword(string username, string oldPassword, string newPassword)
		{
			// Get user entity object from database.
			var user = UserUtils.GetByUsername(username);
			if (user == null)
				// Not found; can't change password.
				return false;

			// Check that old password is correct.
			if (!ValidatePassword(user, oldPassword))
				// No. Disallow change.
				return false;

			// Validate new password.
			if (!ValidateNewPassword(newPassword))
				// No good. Disallow change.
				return false;

			// Ready to change. Need transaction.
			Transaction transaction = new Transaction(IsolationLevel.ReadCommitted, "change password");

			try
			{
				transaction.Add(user);

				// Set the new password
				SetPassword(user, newPassword, transaction);

				// Update password change time and save object.
				user.LastPasswordChangeTime = DateTime.UtcNow;
				user.Save();

				// Commit and indicate changed.
				transaction.Commit();

				return true;
			}
			finally
			{
				transaction.Dispose();
			}
		}

		private MembershipUser GetMembershipUser(UserEntity user)
		{
			var membershipUser = new MembershipUser(Name,
													user.Username,
													new ProviderUserKey
													{
														LocationIds = user.UserAssignedLocations.Select(x => x.LocationId).ToArray(),
														Id = user.UserId,
														OrganizationId = user.OrganizationId
													},
													user.EmailAddress,
													String.Empty,																					// passwordQuestion
													String.Empty,																					// comment
													user.UserAccountRestrictions.Count == 0,														// isApproved
													!user.IsActive,																					// isLockedOut
													user.CreateTime,																				// creationDate
													user.LastLoginTime.HasValue ? user.LastLoginTime.Value : default(DateTime),						// lastLoginDate
													user.LastActivityTime.HasValue ? user.LastActivityTime.Value : default(DateTime),				// lastActivityDate
													user.LastPasswordChangeTime.HasValue ? user.LastPasswordChangeTime.Value : default(DateTime),	// lastPasswordChangedDate
													user.LastLockoutTime.HasValue ? user.LastLockoutTime.Value : default(DateTime)					// lastLockoutDate
													);

			return membershipUser;
		}

		private bool ValidatePassword(UserEntity user, string password)
		{
			return user.Password == Hash.GetHashString(password + user.UserSalt.Salt);
		}

		public static void SetPassword(UserEntity user, string password, Transaction transaction)
		{
			UserSaltEntity userSalt = new UserSaltEntity(user.UserId);
			string salt = CreateSalt(2048);
			userSalt.Salt = salt;
			userSalt.UserId = user.UserId;
			transaction.Add(userSalt);
			userSalt.Save();

			user.Password = SHA512Hash(password + salt);
			user.LastPasswordChangeTime = DateTime.UtcNow;
		}

		public static string SHA512Hash(String data)
		{
			SHA512 sha = new SHA512Managed();
			byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(data));

			var stringBuilder = new StringBuilder();
			foreach (byte b in hash)
			{
				stringBuilder.AppendFormat("{0:x2}", b);
			}

			return stringBuilder.ToString();
		}

		public static string CreateSalt(int size)
		{
			// Generate a cryptographic random number using the cryptographic
			// service provider
			var rng = new RNGCryptoServiceProvider();
			var buff = new byte[size];
			rng.GetBytes(buff);
			// Return a Base64 string representation of the random number
			return BitConverter.ToString(buff).Replace("-", "");
		}

		private  bool ValidateNewPassword(string password)
		{
			if (password.Length < MinRequiredPasswordLength)
				return false;
			if (password.Length > MaxRequiredPasswordLength)
				return false;
			if (password.Contains(" "))
				return false;

			if (Regex.IsMatch(password, PasswordStrengthRegularExpression))
				return true;

			// check if complexity enforcement is turned on
			SystemSettingEntity isEnforced = new SystemSettingEntity("EnforcePasswordComplexity");
			return !isEnforced.IsNew && isEnforced.Value != "1";
		}

		public override string PasswordStrengthRegularExpression
		{
			get { return PASSWORD_COMPLEXITY; }
		}

		public override int MinRequiredPasswordLength
		{
			get { return 8; }
		}

		public static int MaxRequiredPasswordLength
		{
			get { return 24; }
		}

		public override int MaxInvalidPasswordAttempts
		{
			get { return 3; }
		}

		public override bool EnablePasswordRetrieval
		{
			get { return false; }
		}

		public override bool RequiresUniqueEmail
		{
			get { return true; }
		}

		public override MembershipPasswordFormat PasswordFormat
		{
			get { return MembershipPasswordFormat.Hashed; }
		}

		public static int MinUsernameLength
		{
			get { return MINIMUM_USERNAME_LENGTH; }
		}

        public override int GetNumberOfUsersOnline()
        {
            return
                new LinqMetaData().User.Count(
                    x => x.LastActivityTime > DateTime.UtcNow.AddMinutes(-HttpContext.Current.Session.Timeout));
        }
	}
}