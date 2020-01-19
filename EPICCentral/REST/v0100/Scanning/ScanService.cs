extern alias CurrentAPI;

using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using EPICCentral.Utilities.DataLayer;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using V0100 = CurrentAPI::EPICCentralServiceAPI.REST;	// Map alias in DLL reference to an import alias.

namespace EPICCentral.REST.v0100.Scanning
{
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class ScanService : VersionService
	{
		public override ServiceProperties GetProperties()
		{
			return new ServiceProperties { Version = "v0100", Url = "scans" };
		}

		[WebInvoke(UriTemplate = "validate", Method = "POST")]
		public void Validate(V0100.Objects.ValidationKeys keys)
		{
			DeviceEntity device = GetDevice();

			LocationEntity location = device.Location;
			if (location.UniqueIdentifier != keys.LocationGuid)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.LOCATION_INVALID, HttpStatusCode.NotAcceptable);

			if (location.Organization.UniqueIdentifier != keys.OrganizationGuid)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.ORGANIZATION_INVALID, HttpStatusCode.NotAcceptable);

			if (device.DeviceState != DeviceState.Active)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.DEVICE_STATE_INVALID, HttpStatusCode.NotAcceptable);

			if (device.ScansAvailable <= 0)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.DEVICE_HAS_NO_SCANS, HttpStatusCode.NotAcceptable);
		}

		[WebGet(UriTemplate = "count")]
		public V0100.Objects.ScanCount GetCount()
		{
			DeviceEntity device = GetDevice();

			return new V0100.Objects.ScanCount { ScansAvailable = device.ScansAvailable, ScansCompleted = device.ScansUsed };
		}

		[WebInvoke(UriTemplate = "complete", Method = "POST")]
		public V0100.Objects.ScanCount ScanComplete(V0100.Objects.ScanRecord scanRecord)
		{
			DeviceEntity device = GetDevice();

			if (device.DeviceState != DeviceState.Active)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.DEVICE_STATE_INVALID, HttpStatusCode.NotAcceptable);

			// Assume new counts to return.
			V0100.Objects.ScanCount scanCount = new V0100.Objects.ScanCount { ScansAvailable = device.ScansAvailable - 1, ScansCompleted = device.ScansUsed + 1 };

			if (!DeviceUtils.RecordScan(device.DeviceId, ConvertScanType(scanRecord.ScanType), scanRecord.ScanStartTime))
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.INTERNAL_TRANSACTION_ERROR, HttpStatusCode.InternalServerError);

			return scanCount;
		}

		private static ScanType ConvertScanType(V0100.Objects.ScanType scanType)
		{
			switch (scanType)
			{
			default:
				return ScanType.ClearViewScan;
			}
		}
	}
}