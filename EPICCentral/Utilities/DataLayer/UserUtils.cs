using System.Linq;
using EPICCentralDL.CollectionClasses;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using EPICCentralDL.Linq;

namespace EPICCentral.Utilities.DataLayer
{
	public static class UserUtils
	{
		public static UserEntity GetByUsername(string username)
		{
			// New users have an empty username until the user sets it during registration.
			// Reject any empty username.
			if (string.IsNullOrEmpty(username))
				return null;

			var users = new UserCollection();
			users.GetMulti(UserFields.Username == username);
			return users.Count > 0 ? users[0] : null;
		}

		public static bool IsUsernameUsed(string username)
		{
			return new LinqMetaData().User.Any(u => u.Username == username);
		}
	}
}