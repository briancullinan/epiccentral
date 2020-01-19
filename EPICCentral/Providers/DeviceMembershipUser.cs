using System;
using System.Web.Security;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;

namespace EPICCentral.Providers
{
	public class DeviceMembershipUser : MembershipUser
	{
        public DeviceMembershipUser(string providerName, DeviceEntity device)
            : base(
            providerName, /* providerName */
            device.UniqueIdentifier,  /* name */
            new BaseMembershipProvider.ProviderUserKey
            {
                Id = device.DeviceId,
                LocationIds = new[] {device.LocationId},
                OrganizationId = device.Location.OrganizationId
            },  /* providerUserKey */
            string.Empty,  /* emain */
            string.Empty,  /* passwordQuestion */
            string.Empty,  /* comment */
            device.DeviceState != DeviceState.Retired && device.DeviceState != DeviceState.New,  /* isApproved */
            device.DeviceState == DeviceState.Retired || !device.Location.IsActive || !device.Location.Organization.IsActive,  /* isLockedOut */
            device.DateIssued, default(DateTime),  /* creationDate */
            device.LastReportTime ?? default(DateTime),  /* lastLoginDate */
            default(DateTime), /* lastPasswordChangedDate */
            default(DateTime)) /* lastLockoutDate */
        {
        }

	    public int DeviceId
		{
            get { return ProviderUserKey == null ? -1 : ((BaseMembershipProvider.ProviderUserKey)ProviderUserKey).Id; }
		}
	}
}