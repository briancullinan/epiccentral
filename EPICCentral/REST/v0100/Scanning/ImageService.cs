extern alias CurrentAPI;

using System;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using EPICCentral.REST.Core;
using EPICCentral.Utilities.DataLayer;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using log4net;
using V0100 = CurrentAPI::EPICCentralServiceAPI.REST;	// Map alias in DLL reference to an import alias.

namespace EPICCentral.REST.v0100.Scanning
{
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class ImageService : VersionService
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(Service));

		public override ServiceProperties GetProperties()
		{
			return new ServiceProperties { Version = "v0100", Url = "images", MaxReceivedMessageSize = 1024 * 1024 * 20 };
		}

		[WebGet(UriTemplate = "id/guid={guid}")]
		public long GetId(string guid)
		{
			DeviceEntity device = GetDevice();

			if (device.DeviceState != DeviceState.Active)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.DEVICE_STATE_INVALID, HttpStatusCode.NotAcceptable);

			ImageSetEntity imageSet = ImageSetUtils.GetByUid(guid);
			if (imageSet == null)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.IMAGE_SET_NOT_FOUND, HttpStatusCode.NotFound);

			return imageSet.ImageSetId;
		}

		[WebInvoke(UriTemplate = "guid={guid}/checksum={checksum}", Method = "POST")]
		public long Add(string guid, string checksum, Stream stream)
		{
			DeviceEntity device = GetDevice();

			if (device.DeviceState != DeviceState.Active)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.DEVICE_STATE_INVALID, HttpStatusCode.NotAcceptable);

			try
			{
				MemoryStream images = new MemoryStream();
				stream.CopyTo(images);

				// Seek to start so checksum validation can use the stream.
				images.Seek(0, SeekOrigin.Begin);

				if (string.IsNullOrWhiteSpace(guid))
					throw new WebFaultException<string>(V0100.Constants.StatusSubcode.GUID_INVALID, HttpStatusCode.PreconditionFailed);

				if (ImageSetUtils.GetByUid(guid) != null)
					throw new WebFaultException<string>(V0100.Constants.StatusSubcode.IMAGE_SET_INVALID, HttpStatusCode.Conflict);

				if (!CurrentAPI::EPICCentralServiceAPI.REST.Core.Checksum.Validate(images, checksum))
					throw new WebFaultException<string>(V0100.Constants.StatusSubcode.CHECKSUM_INVALID, HttpStatusCode.BadRequest);

				return ImageSetUtils.Create(guid, images.ToArray());
			}
			catch (WebFaultException<string>)
			{
				throw;
			}
			catch (Exception e)
			{
				Log.Error(string.Format("Error adding image set: {0}, device: {1}", guid, device.DeviceId), e);

				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.INTERNAL_IO_ERROR, HttpStatusCode.InternalServerError);
			}
		}
	}
}