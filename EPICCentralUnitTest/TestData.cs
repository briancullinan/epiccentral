using System.Linq;
using EPICCentral.Controllers;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPICCentralUnitTest
{
	public static class TestData
	{
		private const string TEST_DATA_ROOT = "\\\\EPICCORPSERVER\\UserStorage\\EPICCentral\\TestData";
		private const string TEST_PASSWORD = "$Secret0";

		public static string TestDataRoot
		{
			get { return TEST_DATA_ROOT; }
		}

		private static short? serviceAdminRoleId;
		public static short ServiceAdminRoleId
		{
			get
			{
				if (!serviceAdminRoleId.HasValue)
				{
					serviceAdminRoleId = new LinqMetaData().Role.First(r => r.Name == "Service Administrator").RoleId;
				}
				return serviceAdminRoleId.Value;
			}
		}

		private static short? orgAdminRoleId;
		public static short OrgAdminRoleId
		{
			get
			{
				if (!orgAdminRoleId.HasValue)
				{
					orgAdminRoleId = new LinqMetaData().Role.First(r => r.Name == "Organization Administrator").RoleId;
				}
				return orgAdminRoleId.Value;
			}
		}

		private static short? simpleUserRoleId;
		public static short SimpleUserRoleId
		{
			get
			{
				if (!simpleUserRoleId.HasValue)
				{
					simpleUserRoleId = new LinqMetaData().Role.First(r => r.Name == "Simple User").RoleId;
				}
				return simpleUserRoleId.Value;
			}
		}

		private static OrganizationEntity serviceHostOrg;
		public static OrganizationEntity ServiceHostOrg
		{
			get { return serviceHostOrg ?? (serviceHostOrg = new LinqMetaData().Organization.First(o => o.Name == "EPIC Central")); }
		}

		public static int ServiceHostOrgId
		{
			get { return ServiceHostOrg.OrganizationId; }
		}

		private static OrganizationEntity endUserOrg;
		public static OrganizationEntity EndUserOrg
		{
			get { return endUserOrg ?? (endUserOrg = new LinqMetaData().Organization.First(o => o.Name == "EPIC")); }
		}

		public static int EndUserOrgId
		{
			get { return EndUserOrg.OrganizationId; }
		}

		private static LocationEntity endUserLoc;
		public static LocationEntity EndUserLoc
		{
			get { return endUserLoc ?? (endUserLoc = new LinqMetaData().Location.First(l => l.OrganizationId == EndUserOrgId)); }
		}

		private static UserEntity orgAdminUser;
		public static UserEntity OrgAdminUser
		{
			get { return orgAdminUser ?? (orgAdminUser = new LinqMetaData().User.First(u => u.Username == "epicadmin")); }
		}

		public static int OrgAdminUserId
		{
			get { return OrgAdminUser.UserId; }
		}

		public static string OrgAdminUsername
		{
			get { return OrgAdminUser.Username; }
		}

		public static string OrgAdminPassword
		{
			// Password not in database. Just using constant.
			get { return TEST_PASSWORD; }
		}

		private static UserEntity simpleUser;
		public static UserEntity SimpleUser
		{
			get { return simpleUser ?? (simpleUser = new LinqMetaData().User.First(u => u.Username == "simpleuser")); }
		}

		public static string SimpleUserUsername
		{
			get { return SimpleUser.Username; }
		}

		private static UserEntity serviceAdminUser;
		public static UserEntity ServiceAdminUser
		{
			get { return serviceAdminUser ?? (serviceAdminUser = new LinqMetaData().User.First(u => u.Username == "echost")); }
		}

		public static int ServiceAdminUserId
		{
			get { return ServiceAdminUser.UserId; }
		}

		public static string ServiceAdminUsername
		{
			get { return ServiceAdminUser.Username; }
		}

		private static string serviceAdminSupportEmail;
		public static string ServiceAdminSupportEmail
		{
			get
			{
				if (serviceAdminSupportEmail == null)
				{
					var profile = new UserSettingEntity(ServiceAdminUserId, "SupportUser") { UserId = ServiceAdminUserId, Name = "SupportUser" };
					Assert.IsFalse(profile.IsNew);
					serviceAdminSupportEmail = profile.Value + '@' + SupportController.DOMAIN;
				}
				return serviceAdminSupportEmail;
			}
		}
	}
}
