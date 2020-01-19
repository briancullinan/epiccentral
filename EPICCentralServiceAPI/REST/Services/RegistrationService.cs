using System;
using EPICCentralServiceAPI.REST.Core;
using EPICCentralServiceAPI.REST.Objects;

namespace EPICCentralServiceAPI.REST.Services
{
	public class RegistrationService : Service
	{
		/// <summary>
		/// The URI for the registration service.
		/// Service methods extend this URI with method-specific parameters.
		/// </summary>
		/// <value>the root URI for the REST services</value>
		internal override Uri BaseUri
		{
			set
			{
				SetBaseUri(value, "registration/");
			}
		}

		public Locations GetLocations()
		{
			return Invoke<Locations>("GET", "/locations");
		}

		public Credentials RegisterDevice(string locationUid, string deviceSerialNumber)
		{
			return Invoke<Credentials>("GET", string.Format("/credentials/location={0}/device={1}", locationUid, deviceSerialNumber));
		}

		public string ResetAuthenticationToken(string deviceUid, string locationUid, string organizationUid)
		{
			return Invoke<string>("GET", string.Format("/token/device={0}/location={1}/organization={2}", deviceUid, locationUid, organizationUid));
		}
	}
}
