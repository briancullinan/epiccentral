using System;
using EPICCentralServiceAPI.REST.Core;
using EPICCentralServiceAPI.REST.Objects;

namespace EPICCentralServiceAPI.REST.Services
{
	/// <summary>
	/// REST service interface for sending calibrations to the server to be added
	/// to the central database.
	/// This class presents a simple method for adding a calibration defined by a
	/// <see cref="Calibration"/> instance.
	/// Internally, it will apply all the plumbing necessary to invoke the service
	/// on the server and return its response.
	/// </summary>
	public class CalibrationService : Service
	{
		/// <summary>
		/// The URI for the calibration service.
		/// Service methods extend this URI with method-specific parameters.
		/// </summary>
		/// <value>the root URI for the REST services</value>
		internal override Uri BaseUri
		{
			set
			{
				SetBaseUri(value, "calibrations/");
			}
		}

		/// <summary>
		/// <para>
		/// Add a calibration record to the central database.
		/// The calibration is defined by a <see cref="Calibration"/> instance which contains a
		/// GUID reference to an image set containing the set of images for the calibration.
		/// That set of images must be provided as an <see cref="ImageSetBlob"/> to this method.
		/// The GUIDs in the <code>ImageSetBlob</code> and the <code>Calibration</code> must match.
		/// </para><para>
		/// The image set will be uploaded to the server first.
		/// If that operation is successful, the <code>Calibration</code> will then be sent to the
		/// server.
		/// All failures result in an exception being thrown.
		/// </para>
		/// </summary>
		/// <param name="calibration">a <see cref="Calibration"/> instance that specifies the
		///		calibration</param>
		/// <param name="calibrationImageSet">an <see cref="ImageSetBlob"/> that contains the set
		///		of images for the calibration</param>
		/// <returns>a long containing the ID of the calibration on the server</returns>
		/// <exception cref="HttpInvocationException">thrown when any HTTP status code other than
		///		200 is returned by the server; fields in the exception hold the status code and
		///		error message returned</exception>
		/// <exception cref="InvocationException">thrown when an error occurs invoking the service
		///		on the server, prior to the service running</exception>
		/// <exception cref="MalformedUriException">thrown when a valid URI cannot be constructed
		///		from the base URI and additional relative path</exception>
		/// <exception cref="InvalidArgumentException">thrown when the GUID of the image set in the
		///		<code>ImageSetBlob</code> does not match the GUID reference to the image set in the
		///		<code>Calibration</code></exception>
		public long Add(Calibration calibration, ImageSetBlob calibrationImageSet)
		{
			// Be sure the GUID in the calibration references the image set provided.
			if (calibration.ImageSetGuid != calibrationImageSet.Guid)
				throw new InvalidArgumentException("Two GUIDs for the image set do not match");

			// First, upload the image set using the image service.
			ImageService imageService = Gateway.GetService<ImageService>();
			imageService.Add(calibrationImageSet);

			// Second, send the calibration. The service will return a Calibration; just return the
			// ID of the record on the server.
			calibration = Invoke<Calibration, Calibration>("POST", "/", calibration);
			return calibration.CalibrationId;
		}
	}
}
