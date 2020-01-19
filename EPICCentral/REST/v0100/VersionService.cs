extern alias CurrentAPI;

using System.Net;
using System.ServiceModel.Web;
using EPICCentral.Providers;
using EPICCentral.REST.Core;
using EPICCentralDL.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using V0100 = CurrentAPI::EPICCentralServiceAPI.REST;

namespace EPICCentral.REST.v0100
{
	public abstract class VersionService : Service
	{
		protected DeviceEntity GetDevice()
		{
			return GetDevice(null);
		}

		protected DeviceEntity GetDevice(ITransaction transaction)
		{
			if (!(User is DeviceMembershipUser))
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.DEVICE_AUTH_REQUIRED, HttpStatusCode.Forbidden);

			DeviceEntity device = GetDeviceEntity(transaction);
			if (device == null)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.INTERNAL_DATABASE_ERROR, HttpStatusCode.InternalServerError);

			return device;
		}
	}
}