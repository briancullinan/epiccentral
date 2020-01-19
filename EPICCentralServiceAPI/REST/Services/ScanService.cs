using System;
using EPICCentralServiceAPI.REST.Core;
using EPICCentralServiceAPI.REST.Objects;

namespace EPICCentralServiceAPI.REST.Services
{
	/// <summary>
	/// REST interface for coordinating the scanning process with the central server.
	/// The server is an integral part of managing the ability to perform scans.
	/// This allows the scanning process to be managed by a server administrator.
	/// When a client is ready to perform a scan, it will check with the server to be
	/// sure it is allowed to continue.
	/// When a scan is complete, the client must inform the server that it has completed
	/// a scan.
	/// The server maintains a count of the number of scans available to the client.
	/// If there are no scans available, the client cannot perform a scan.
	/// </summary>
	public class ScanService : Service
	{
		/// <summary>
		/// The URI for the scan service.
		/// Service methods extend this URI with method-specific parameters.
		/// </summary>
		/// <value>the root URI for the REST services</value>
		internal override Uri BaseUri
		{
			set
			{
				SetBaseUri(value, "scans/");
			}
		}

		/// <summary>
		/// Validate the ability of the device to do a scan.
		/// </summary>
		/// <param name="keys">a <see cref="ValidationKeys"/> instance containing the keys to be validated</param>
		/// <returns><c>true</c> if the device is valid and authorized to scan, <c>false</c> if not</returns>
		/// <exception cref="HttpInvocationException">thrown when any HTTP status code other than
		///		200 is returned by the server; fields in the exception hold the status code and
		///		error message returned</exception>
		/// <exception cref="InvocationException">thrown when an error occurs invoking the service
		///		on the server, prior to the service running</exception>
		/// <exception cref="MalformedUriException">thrown when a valid URI cannot be constructed
		///		from the base URI and additional relative path</exception>
		public void ValidateScanAbility(ValidationKeys keys)
		{
			Invoke("POST", "/validate", keys);
		}

		/// <summary>
		/// Get scan counts for a device.
		/// The <see cref="ScanCount" /> returned contains the current counts.
		/// </summary>
		/// <returns><c>ScanCount</c> containing counts for the device; <c>null</c> if failure occurs</returns>
		/// <exception cref="HttpInvocationException">thrown when any HTTP status code other than
		///		200 is returned by the server; fields in the exception hold the status code and
		///		error message returned</exception>
		/// <exception cref="InvocationException">thrown when an error occurs invoking the service
		///		on the server, prior to the service running</exception>
		/// <exception cref="MalformedUriException">thrown when a valid URI cannot be constructed
		///		from the base URI and additional relative path</exception>
		public ScanCount GetScanCount()
		{
			return Invoke<ScanCount>("GET", "/count");
		}

		/// <summary>
		/// Note the completion of a scan.
		/// This will result in a decrement of the number of available scans and an increment of the number
		/// of completed scans.
		/// </summary>
		/// <param name="scanRecord">a <see cref="ScanRecord"/> containing information about the scan</param>
		/// <returns><c>ScanCount</c> containing counts for the device; <c>null</c> if failure occurs</returns>
		/// <exception cref="HttpInvocationException">thrown when any HTTP status code other than
		///		200 is returned by the server; fields in the exception hold the status code and
		///		error message returned</exception>
		/// <exception cref="InvocationException">thrown when an error occurs invoking the service
		///		on the server, prior to the service running</exception>
		/// <exception cref="MalformedUriException">thrown when a valid URI cannot be constructed
		///		from the base URI and additional relative path</exception>
		public ScanCount NoteScanCompletion(ScanRecord scanRecord)
		{
			return Invoke<ScanRecord, ScanCount>("POST", "/complete", scanRecord);
		}
	}
}
