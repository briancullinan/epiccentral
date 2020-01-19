using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using EPICCentral.Utilities.Crypto;
using EPICCentral.Utilities.DataLayer;
using EPICCentralDL.Linq;

namespace EPICCentral.Providers
{
    public class DeviceMembershipProvider : BaseMembershipProvider
    {
        public override bool ValidateUser(string deviceUniqueId, string authToken)
        {
        	var device = DeviceUtils.GetByUid(deviceUniqueId);
        	return device != null && device.AuthenticationToken.SequenceEqual(Hash.GetHash(authToken));
        }

        public override MembershipUser GetUser(string deviceUniqueId, bool userIsOnline)
        {
			var device = DeviceUtils.GetByUid(deviceUniqueId);
        	return device != null ? new DeviceMembershipUser(Name, device) : null;
        }

        public override int GetNumberOfUsersOnline()
        {
            return
                new LinqMetaData().Device.Count(
                    x => x.LastReportTime > DateTime.UtcNow.AddMinutes(-HttpContext.Current.Session.Timeout));
        }
    }
}