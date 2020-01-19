using System;
using System.Collections.Generic;
using System.Linq;
using EPICCentralDL.CollectionClasses;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using EPICCentralDL.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentral.Utilities.DataLayer
{
	public static class OrganizationUtils
	{
		public static string CreateUid()
		{
			string uid;

			do
			{
				uid = string.Format("000010-{0}", Guid.NewGuid());
			} while (GetByUid(uid) != null);

			return uid;
		}

		public static OrganizationEntity GetByUid(string organizationUid)
		{
			OrganizationCollection organizations = new OrganizationCollection();
			organizations.GetMulti(new PredicateExpression(OrganizationFields.UniqueIdentifier == organizationUid));
			return organizations.Count > 0 ? organizations[0] : null;
		}

		public static IEnumerable<RoleEntity> GetAllowedRoles(int? organizationId)
		{
			if (!organizationId.HasValue)
				return new List<RoleEntity>();

			OrganizationEntity organization = new OrganizationEntity(organizationId.Value);
			if (organization.IsNew)
				return new List<RoleEntity>();

            // TODO:  A user can never elevate themselves higher than what they started as

			return new LinqMetaData().Role.Where(r => r.Name != "Service Administrator" || (r.Name == "Service Administrator" && organization.OrganizationType == OrganizationType.Host));
		}

		public static int GetLocationCount(int? organizationId)
		{
			if (!organizationId.HasValue)
				return 0;

			OrganizationEntity organization = new OrganizationEntity(organizationId.Value);
			return organization.IsNew ? 0 : organization.Locations.Count;
		}
	}
}