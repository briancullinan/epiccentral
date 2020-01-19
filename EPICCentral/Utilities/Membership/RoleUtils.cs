using System.Web.Security;
using EPICCentralDL.EntityClasses;

namespace EPICCentral.Utilities.Membership
{
	public static class RoleUtils
	{
		public const string SERVICE_ADMIN_NAME = "Service Administrator";
		public const string ORGANIZATION_ADMIN_NAME = "Organization Administrator";

		public static bool IsUserServiceAdmin()
		{
			return Roles.IsUserInRole(SERVICE_ADMIN_NAME);
		}

		public static bool IsUserOrgAdmin()
		{
			return Roles.IsUserInRole(ORGANIZATION_ADMIN_NAME);
		}

		public static bool IsUserAdmin()
		{
			return IsUserServiceAdmin() || IsUserOrgAdmin();
		}

		public static bool IsRoleForAdmin(short roleId)
		{
			var role = new RoleEntity(roleId);
			return !role.IsNew && (role.Name == SERVICE_ADMIN_NAME || role.Name == ORGANIZATION_ADMIN_NAME);
		}
	}
}