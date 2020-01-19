using System.Linq;
using EPICCentralDL.CollectionClasses;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;

namespace EPICCentral.Providers
{
	public class EpicRoleProvider : BaseRoleProvider
	{
		public override bool IsUserInRole(string username, string roleName)
		{
			var users = new UserCollection();
			users.GetMulti(UserFields.Username == username);
			return users.Count > 0 &&
				   users[0].Roles.Select(userRole => userRole.Role).Any(
					   role => role.Name.ToLower() == roleName.ToLower());
		}

		public override string[] GetRolesForUser(string username)
		{
			var users = new UserCollection();
			users.GetMulti(UserFields.Username == username);
			return users.Count > 0 ? users[0].Roles.Select(x => new RoleEntity(x.RoleId).Name).ToArray() : new string[] { };
		}
	}
}