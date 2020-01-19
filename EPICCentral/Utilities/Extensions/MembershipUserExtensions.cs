using System;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using EPICCentral.Providers;
using EPICCentral.Utilities.DataLayer;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;

public static class MembershipUserExtensions
{
    /// <summary>
    /// Returns the UserId for the current UserEntity
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public static BaseMembershipProvider.ProviderUserKey GetUserId(this MembershipUser user)
    {
        if (user == null || user.ProviderUserKey == null)
            throw new NullReferenceException("User has not been initialized.");

        if (!(Membership.Providers[user.ProviderName] is EpicMembershipProvider))
            throw new ArgumentException(String.Format("User '{0}' is not provided by EPIC Membership.", user.UserName));

        return (BaseMembershipProvider.ProviderUserKey)user.ProviderUserKey;
    }

    /// <summary>
    /// Gets the UserEntity for the currently logged in user.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public static UserEntity GetUserEntity(this MembershipUser user)
    {
        if (user == null || user.ProviderUserKey == null)
            throw new NullReferenceException("User has not been initialized.");

        if(!(Membership.Providers[user.ProviderName] is EpicMembershipProvider))
            throw new ArgumentException(String.Format("User '{0}' is not provided by EPIC Membership.", user.UserName));

        return new UserEntity(((BaseMembershipProvider.ProviderUserKey)user.ProviderUserKey).Id);
    }

    /// <summary>
    /// Sets the password for a user, not typically allowed by MembershipProvider.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public static bool SetPassword(this MembershipUser user, string password)
    {
        Transaction transaction = new Transaction(System.Data.IsolationLevel.ReadCommitted, "password change");

        try
        {
        	int userId = user.GetUserId().Id;
			UserEntity userEntity = new UserEntity(userId);
            if (!userEntity.IsNew)
            {
                transaction.Add(userEntity);
				EpicMembershipProvider.SetPassword(userEntity, password, transaction);
                userEntity.Save();

                transaction.Commit();

                return true;
            }
            else
                return false;
        }
        catch
        {
            transaction.Rollback();

            return false;
        }
        finally
        {
            transaction.Dispose();
        }
    }

	/// <summary>
	/// Delegate for saving an updated username to the database.
	/// Invoked after validation is complete, but before the current user is
	/// signed out and then reauthenticated.
	/// </summary>
	/// <param name="username">current user's new username</param>
	public delegate void SaveUsername(string username);

	/// <summary>
	/// Change the current user's username and update the current authentication cookie
	/// to include the new username.
	/// This process isn't as simple as just updating the user's entity record in the
	/// database.
	/// Since it's the current user, the authentication cookie must be updated with the
	/// new username.
	/// This is done by signing out the user and then reauthenticating the session with
	/// the new username.
	/// </summary>
	/// <param name="user">current logged in user's membership</param>
	/// <param name="newUsername">user's new username</param>
	/// <param name="saver">a delegate that will be invoked to actually save the new
	///		username to the database; if not provided, the username will simply be
	///		updated in the current logged-in user's record; this allows the update to
	///		be performed within a transaction</param>
	/// <returns><code>true</code> if successful, <code>false</code> if the new username
	///		is not unique</returns>
	public static bool ChangeUsername(this MembershipUser user, string newUsername, SaveUsername saver = null)
	{
		if (saver == null)
			saver = delegate(string username)
			        	{
                            var userEntity = new UserEntity(user.GetUserId().Id) { Username = username };
			        		userEntity.Save();
			        	};

		if (UserUtils.GetByUsername(newUsername) == null)
		{
			HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
			if (authCookie != null)
			{
				var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
				var identity = new FormsIdentity(
									new FormsAuthenticationTicket(
											authTicket.Version,
											newUsername,
											authTicket.IssueDate,
											authTicket.Expiration,
											authTicket.IsPersistent,
											authTicket.UserData));
				string[] roles = authTicket.UserData.Split(new[] {'|'});

				saver(newUsername);

				HttpContext.Current.User = new GenericPrincipal(identity, roles);

				FormsAuthentication.SignOut();
				HttpContext.Current.Session.Abandon();
				FormsAuthentication.SetAuthCookie(newUsername, authTicket.IsPersistent);

				return true;
			}
		}

		return false;
	}
}
