extern alias CurrentAPI;

using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using EPICCentral.Utilities.DataLayer;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using V0100 = CurrentAPI::EPICCentralServiceAPI.REST;	// Map alias in DLL reference to an import alias.

namespace EPICCentral.REST.v0100.Registration
{
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class RegistrationService : VersionService
	{
		public override ServiceProperties GetProperties()
		{
			return new ServiceProperties { Version = "v0100", Url = "registration" };
		}

		[WebGet(UriTemplate = "locations")]
		public V0100.Objects.Locations GetLocations()
		{
			UserEntity user = GetUser();
			if (user == null)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.USER_AUTH_REQUIRED, HttpStatusCode.Forbidden);

			V0100.Objects.Locations locations = new V0100.Objects.Locations();
			locations.AddRange(user.Organization.Locations.Select(location => new V0100.Objects.Location {UniqueIdentifier = location.UniqueIdentifier, Name = location.Name}));

			if (locations.Count <= 0)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.LOCATION_NOT_FOUND, HttpStatusCode.NotFound);

			return locations;
		}

		[WebGet(UriTemplate = "credentials/location={locationUid}/device={serialNumber}")]
		public V0100.Objects.Credentials RegisterDevice(string locationUid, string serialNumber)
		{
			UserEntity user = GetUser();
			if (user == null)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.USER_AUTH_REQUIRED, HttpStatusCode.Forbidden);

			LocationEntity location = LocationUtils.GetByUid(locationUid);
			if (location == null)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.LOCATION_NOT_FOUND, HttpStatusCode.PreconditionFailed);
			if (location.OrganizationId != user.OrganizationId)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.LOCATION_INVALID, HttpStatusCode.PreconditionFailed);

			DeviceEntity device = location.Devices.FirstOrDefault(d => d.SerialNumber == serialNumber);
			if (device == null)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.DEVICE_NOT_FOUND, HttpStatusCode.NotFound);

			if (device.DeviceState != DeviceState.New && device.DeviceState != DeviceState.Transitioning)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.DEVICE_STATE_INVALID, HttpStatusCode.NotAcceptable);

			V0100.Objects.Credentials credentials = new V0100.Objects.Credentials
			                                			{
			                                					OrganizationUid = location.Organization.UniqueIdentifier,
			                                					LocationUid = location.UniqueIdentifier,
			                                					DeviceUid = device.UniqueIdentifier,
			                                					UidQualifier = DeviceUtils.GetUidQualifier(device),
			                                					AuthenticationToken = DeviceUtils.GetAuthenticationToken(device, false)
			                                			};

			// Set new state and create tracking record. This will update the database.
			DeviceUtils.SetState(device, DeviceState.Active, "Device registered at location " + location.Name);

			return credentials;
		}

		[WebGet(UriTemplate = "token/device={deviceUid}/location={locationUid}/organization={organizationUid}")]
		public string ResetAuthenticationKey(string deviceUid, string locationUid, string organizationUid)
		{
			DeviceEntity device;
			UserEntity user = GetUser();
			if (user != null)
			{
				device = DeviceUtils.GetByUid(deviceUid);
				if (device == null)
					throw new WebFaultException<string>(V0100.Constants.StatusSubcode.DEVICE_NOT_FOUND, HttpStatusCode.NotFound);

				if (device.Location.OrganizationId != user.OrganizationId)
					throw new WebFaultException<string>(V0100.Constants.StatusSubcode.DEVICE_NOT_FOUND, HttpStatusCode.PreconditionFailed);
			}
			else
			{
				device = GetDevice();			// throws "unauthorized" exception if token auth fails

				if (device.UniqueIdentifier != deviceUid)
					throw new WebFaultException<string>(V0100.Constants.StatusSubcode.DEVICE_INVALID, HttpStatusCode.PreconditionFailed);
			}

			if (device.Location.UniqueIdentifier != locationUid)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.LOCATION_INVALID, HttpStatusCode.PreconditionFailed);
			if (device.Location.Organization.UniqueIdentifier != organizationUid)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.ORGANIZATION_INVALID, HttpStatusCode.PreconditionFailed);

			if (device.DeviceState != DeviceState.Active)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.DEVICE_STATE_INVALID, HttpStatusCode.NotAcceptable);

			return DeviceUtils.GetAuthenticationToken(device);
		}
	}
}