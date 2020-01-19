using System;
using System.IO;
using System.Net;
using EPICCentralServiceAPI.REST.Core;
using EPICCentralServiceAPI.REST.Objects;
using log4net;

namespace EPICCentralServiceAPI.REST.Services
{
	/// <summary>
	/// REST service interface for sending image sets to the server to be added
	/// to the central database.
	/// This class presents simple methods for getting the server's database ID
	/// for an image set (really used to check if the image set has already been
	/// uploaded) and for adding an image set defined by an <see cref="ImageSetBlob"/>
	/// instance.
	/// Internally, it will apply all the plumbing necessary to invoke the service
	/// on the server and return its response.
	/// </summary>
	public class ImageService : Service
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(Service));

		/// <summary>
		/// The URI for the image service.
		/// Service methods extend this URI with method-specific parameters.
		/// </summary>
		/// <value>the root URI for the REST services</value>
		internal override Uri BaseUri
		{
			set
			{
				SetBaseUri(value, "images/");
			}
		}

		/// <summary>
		/// Get the server's ID for an image set stored in the central database using the
		/// image set's GUID as the search criteria
		/// </summary>
		/// <param name="guid">the GUID that uniquely identifies the image set</param>
		/// <returns>a long containing the ID of the image set on the server</returns>
		/// <exception cref="HttpInvocationException">thrown when any HTTP status code other than
		///		200 is returned by the server; fields in the exception hold the status code and
		///		error message returned</exception>
		/// <exception cref="InvocationException">thrown when an error occurs invoking the service
		///		on the server, prior to the service running</exception>
		/// <exception cref="MalformedUriException">thrown when a valid URI cannot be constructed
		///		from the base URI and additional relative path</exception>
		public long GetId(string guid)
		{
			return Invoke<long>("GET", string.Format("/id/guid={0}", guid));
		}

		/// <summary>
		/// <para>
		/// Add an image set to the server's central database.
		/// The image set is specified as a <see cref="ImageSetBlob"/> instance which provides a
		/// way to retrieve the binary data for the images and the GUID that uniquely identifies
		/// the image set.
		/// </para><para>
		/// This method will first invoke the <see cref="GetId"/> method to determine if an image
		/// set with the GUID in the <code>ImageSetBlob</code> already exists in the central
		/// database.
		/// If it exists, the database's ID for the image set will be returned and the upload of
		/// the binary data will not be done.
		/// If it doesn't exist, the upload will proceed.
		/// The binary data for the images is large, so there is no need to upload it if the image
		/// set is already present in the database.
		/// </para>
		/// </summary>
		/// <param name="imageSet">an <see cref="ImageSetBlob"/> instance that contains the image
		///		set to add</param>
		/// <returns>a long containing the ID of the image set on the server</returns>
		/// <exception cref="HttpInvocationException">thrown when any HTTP status code other than
		///		200 is returned by the server; fields in the exception hold the status code and
		///		error message returned</exception>
		/// <exception cref="InvocationException">thrown when an error occurs invoking the service
		///		on the server, prior to the service running</exception>
		/// <exception cref="MalformedUriException">thrown when a valid URI cannot be constructed
		///		from the base URI and additional relative path</exception>
		public long Add(ImageSetBlob imageSet)
		{
			// See if the image set is already on the server. Exception will result if it isn't.
			try
			{
				return GetId(imageSet.Guid);
			}
			catch (HttpInvocationException e)
			{
				// If any exception except "not found" occurred, re-throw it. Otherwise, continue below.
				if (e.StatusCode != HttpStatusCode.NotFound)
					throw;
			}

			// Get here if the image set isn't on the server. Get the stream for reading the image set
			// and build the request. A checksum is computed over the image set data and provided as a
			// parameter along with the GUID.
			Stream imageStream = imageSet.GetReadStream();
			HttpWebRequest request = GetRequest("POST", string.Format("/guid={0}/checksum={1}", imageSet.Guid, Checksum.Compute(imageStream)));

			// Checksum calculation read the stream. Seek back to the beginning to send it.
			imageStream.Seek(0, SeekOrigin.Begin);

			try
			{
				// Configure request with data size and type.
				request.ContentLength = imageStream.Length;
				request.ContentType = "application/octet-stream";

				// Send the image set data by copying it to the request's stream.
				using (Stream requestStream = request.GetRequestStream())
					imageStream.CopyTo(requestStream);

				// Get the server's response and return it.
				return GetResponse(request, GetResponse<long>);
			}
			catch (InvocationException)
			{
				// Any InvocationException exception is just re-thrown.
				throw;
			}
			catch (Exception e)
			{
				// Most likely I/O error. All others are programming issues.
				if (Log.IsDebugEnabled)
					Log.Debug(string.Format("Error writing request Content: {0}, POST method, likely I/O error", request.RequestUri), e);

				throw new InvocationException("Request transmission error", e);
			}
		}
	}
}
