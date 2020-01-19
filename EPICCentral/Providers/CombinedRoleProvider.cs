using System;
using System.Linq;
using System.Web.Security;

namespace EPICCentral.Providers
{
	public class CombinedRoleProvider : BaseRoleProvider
	{
		public override bool IsUserInRole(string username, string roleName)
		{
			return Roles.Providers.Cast<object>().Where(x => !(x is CombinedRoleProvider)).Any(provider => ((RoleProvider)provider).IsUserInRole(username, roleName));
		}

		public override string[] GetRolesForUser(string username)
		{
			var result = new string[] { };
			return Roles.Providers.Cast<object>().Where(x => !(x is CombinedRoleProvider)).Aggregate(result, (current, provider) => current.Union(((RoleProvider)provider).GetRolesForUser(username)).ToArray());
		}
	}
}