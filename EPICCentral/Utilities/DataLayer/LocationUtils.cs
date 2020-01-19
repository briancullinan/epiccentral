using System;
using System.Linq;
using EPICCentral.Utilities.Membership;
using EPICCentralDL.CollectionClasses;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentral.Utilities.DataLayer
{
	public static class LocationUtils
	{
		public static string CreateUid()
		{
			string uid;

			do
			{
				uid = string.Format("000020-{0}", Guid.NewGuid());
			} while (GetByUid(uid) != null);

			return uid;
		}

		public static LocationEntity GetByUid(string locationUid)
		{
			LocationCollection locations = new LocationCollection();
			locations.GetMulti(new PredicateExpression(LocationFields.UniqueIdentifier == locationUid));
			return locations.Count > 0 ? locations[0] : null;
		}

		public static int GetUserCount(LocationEntity location)
		{
			return RoleUtils.IsUserAdmin() ? location.UserAssignedLocations.Count : location.UserAssignedLocations.Count(l => !l.User.UserAccountRestrictions.Any());
		}
	}
}