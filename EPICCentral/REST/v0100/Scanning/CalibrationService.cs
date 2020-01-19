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
	public class CalibrationService : VersionService
	{
		public override ServiceProperties GetProperties()
		{
			return new ServiceProperties { Version = "v0100", Url = "calibrations" };
		}

		[WebInvoke(UriTemplate = "", Method = "POST")]
		public V0100.Objects.Calibration Add(V0100.Objects.Calibration calibration)
		{
			// Get the device that authenticated.
			DeviceEntity device = GetDevice();

			// Device must be active.
			if (device.DeviceState != DeviceState.Active)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.DEVICE_STATE_INVALID, HttpStatusCode.NotAcceptable);

			// If the calibration specifies a different device, switch to that one.
			// This allows uploading a calibration for a previously-attached scanner.
			if (!string.IsNullOrEmpty(calibration.DeviceGuid) && calibration.DeviceGuid != device.UniqueIdentifier)
			{
				// Get device. It must exist.
				device = DeviceUtils.GetByUid(calibration.DeviceGuid);
				if (device == null)
					throw new WebFaultException<string>(V0100.Constants.StatusSubcode.DEVICE_NOT_FOUND, HttpStatusCode.PreconditionFailed);
			}

			// Get the calibration if it exists.
			CalibrationEntity calibrationEntity = CalibrationUtils.GetByUid(calibration.Guid);
			if (calibrationEntity == null)
			{
				// Not found. Creating a new one. Be sure the image set exists.
				ImageSetEntity imageSet = ImageSetUtils.GetByUid(calibration.ImageSetGuid);
				if (imageSet == null)
					throw new WebFaultException<string>(V0100.Constants.StatusSubcode.IMAGE_SET_NOT_FOUND, HttpStatusCode.PreconditionFailed);

				// Create new calibration.
				calibration.CalibrationId = CalibrationUtils.Create(device.DeviceId, calibration.Guid, calibration.Timestamp, calibration.PerformedBy, imageSet.ImageSetId);
			}
			else
			{
				// Calibration already exists. Device IDs must match.
				if (calibrationEntity.DeviceId != device.DeviceId)
					throw new WebFaultException<string>(V0100.Constants.StatusSubcode.CALIBRATION_INVALID, HttpStatusCode.Conflict);

				// Get existing ID.
				calibration.CalibrationId = calibrationEntity.CalibrationId;
			}

			// Return it with the ID provided.
			return calibration;
		}
	}
}