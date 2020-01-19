using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using EPICCentral.Utilities.Membership;
using EPICCentralDL.EntityClasses;

namespace EPICCentral.Providers
{
    public class EpicPermissionProvider : PermissionProvider<CommonEntityBase>
    {
        public override bool UserHasPermission(string username, string permissionName, CommonEntityBase entity)
        {
            var user = Membership.GetUser(username).GetUserEntity();

            var location = entity as LocationEntity;
            if (location != null)
            {
				if (RoleUtils.IsUserServiceAdmin())
					return true;

				if (RoleUtils.IsUserOrgAdmin() && location.OrganizationId == user.OrganizationId)
                    return true;

                if (location.UserAssignedLocations.Any(x => x.UserId == user.UserId) && permissionName == "View")
                    return true;
            }

            var organization = entity as OrganizationEntity;
            if (organization != null)
            {
				if (RoleUtils.IsUserServiceAdmin())
					return true;

				if (RoleUtils.IsUserOrgAdmin() && organization.OrganizationId == user.OrganizationId)
                    return true;

                if (organization.OrganizationId == user.OrganizationId && permissionName == "View")
                    return true;
            }

            var patient = entity as PatientEntity;
            if (patient != null)
            {
				if (RoleUtils.IsUserServiceAdmin())
					return true;

				if (RoleUtils.IsUserOrgAdmin() && patient.Location.OrganizationId == user.OrganizationId)
                    return true;

                if (patient.Location.UserAssignedLocations.Any(x => x.UserId == user.UserId))
                    return true;
            }

            var treatment = entity as TreatmentEntity;
            if (treatment != null)
            {
				if (RoleUtils.IsUserServiceAdmin())
					return true;

				if (RoleUtils.IsUserOrgAdmin() && treatment.Patient.Location.OrganizationId == user.OrganizationId)
                    return true;

                if (treatment.Patient.Location.UserAssignedLocations.Any(x => x.UserId == user.UserId))
                    return true;
            }

            var device = entity as DeviceEntity;
            if (device != null)
            {
                if (RoleUtils.IsUserServiceAdmin())
                    return true;

				if (RoleUtils.IsUserOrgAdmin() && device.Location.OrganizationId == user.OrganizationId)
                    return true;

                if (device.Location.UserAssignedLocations.Any(x => x.UserId == user.UserId))
                    return true;
            }

        	var usr = entity as UserEntity;
			if (usr != null)
			{
				if (RoleUtils.IsUserServiceAdmin())
					return true;

				if (RoleUtils.IsUserOrgAdmin() && usr.OrganizationId == user.OrganizationId)
					return true;

				if (usr.UserAssignedLocations.Select(x => x.LocationId).Intersect(user.UserAssignedLocations.Select(y => y.LocationId)).Any())
					return true;
			}

            var card = entity as CreditCardEntity;
            if (card != null)
            {
                if (RoleUtils.IsUserServiceAdmin())
                    return true;

                if (card.UserCreditCards.Any(x => x.UserId == user.UserId))
                    return true;
            }

            return false;
        }

        public override bool UserHasPermission(string username, CommonEntityBase entity)
        {
            // assume roles permission is already set up on method, just check entity permissions based on roles
            throw new NotImplementedException();
        }
    }
}

public static class PermissionExtensions
{
    public static IQueryable<DeviceEntity> WithPermissions(this IQueryable<DeviceEntity> devices)
    {
        var user = Membership.GetUser().GetUserEntity();

        if(RoleUtils.IsUserServiceAdmin())
            return devices;

        if (RoleUtils.IsUserOrgAdmin())
            return devices.Where(x => x.Location.OrganizationId == user.OrganizationId);

        return devices.Where(x => x.Location.UserAssignedLocations.Any(y => y.UserId == user.UserId));
    }

    public static IQueryable<OrganizationEntity> WithPermissions(this IQueryable<OrganizationEntity> organizations)
    {
        var user = Membership.GetUser().GetUserEntity();

        if (RoleUtils.IsUserServiceAdmin())
            return organizations;

        return organizations.Where(
            x =>
            x.Locations.Any(
                y => y.UserAssignedLocations.Any(u => u.UserId == user.UserId)));
    }

    public static IQueryable<LocationEntity> WithPermissions(this IQueryable<LocationEntity> locations, int? organizationId = null)
    {
        var user = Membership.GetUser().GetUserEntity();

		if (RoleUtils.IsUserServiceAdmin())
			return organizationId.HasValue ? locations.Where(x => x.OrganizationId == organizationId.Value) : locations;

    	if (RoleUtils.IsUserOrgAdmin())
            return locations.Where(x => x.OrganizationId == user.OrganizationId);

        return locations.Where(x => x.UserAssignedLocations.Any(y => y.UserId == user.UserId));
    }

    public static IQueryable<PatientEntity> WithPermissions(this IQueryable<PatientEntity> patients)
    {
        var user = Membership.GetUser().GetUserEntity();

        if (RoleUtils.IsUserServiceAdmin())
            return patients;

        if (RoleUtils.IsUserOrgAdmin())
            return patients.Where(x => x.Location.OrganizationId == user.OrganizationId);

        return patients.Where(x => x.Location.UserAssignedLocations.Any(y => y.UserId == user.UserId));
    }

    public static IQueryable<TreatmentEntity> WithPermissions(this IQueryable<TreatmentEntity> treatments)
    {
        var user = Membership.GetUser().GetUserEntity();

        if (RoleUtils.IsUserServiceAdmin())
            return treatments;

        if (RoleUtils.IsUserOrgAdmin())
            return treatments.Where(x => x.Patient.Location.OrganizationId == user.OrganizationId);

        return treatments.Where(x => x.Patient.Location.UserAssignedLocations.Any(y => y.UserId == user.UserId));
    }

    public static IQueryable<UserEntity> WithPermissions(this IQueryable<UserEntity> users)
    {
        var user = Membership.GetUser().GetUserEntity();

        if (RoleUtils.IsUserServiceAdmin())
            return users;

        if (RoleUtils.IsUserOrgAdmin())
            return users.Where(x => x.OrganizationId == user.OrganizationId);

        return users.Where(x => x.UserAssignedLocations.Any(y => y.Location.UserAssignedLocations.Any(z => z.UserId == user.UserId)));
    }

    public static IQueryable<PurchaseHistoryEntity> WithPermissions(this IQueryable<PurchaseHistoryEntity> purchases)
    {
        var user = Membership.GetUser().GetUserEntity();

        if (RoleUtils.IsUserServiceAdmin())
            return purchases;

        if (RoleUtils.IsUserOrgAdmin())
            return purchases.Where(x => x.Location.OrganizationId == user.OrganizationId);

        return purchases.Where(x => x.Location.UserAssignedLocations.Any(y => y.UserId == user.UserId));
    }

    public static IQueryable<ScanRateEntity> WithPermissions(this IQueryable<ScanRateEntity> rates)
    {
        return rates.Where(x => x.EffectiveDate < DateTime.UtcNow);
    }
}
