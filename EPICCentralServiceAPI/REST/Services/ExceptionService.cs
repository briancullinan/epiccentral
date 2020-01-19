using System;
using EPICCentralServiceAPI.REST.Core;
using EPICCentralServiceAPI.REST.Objects;

namespace EPICCentralServiceAPI.REST.Services
{
	/// <summary>
	/// REST service interface for adding exceptions to the server's exception log.
	/// This class presents a simple method for adding an exception defined by an
	/// <see cref="Exception"/> instance.
	/// Internally, it will apply all the plumbing necessary to invoke the service
	/// on the server and return its response.
	/// </summary>
	public class ExceptionService : Service
	{
		/// <summary>
		/// The URI for the exception service.
		/// Service methods extend this URI with method-specific parameters.
		/// </summary>
		/// <value>the root URI for the REST services</value>
		internal override Uri BaseUri
		{
			set
			{
				SetBaseUri(value, "exceptions/");
			}
		}

		/// <summary>
		/// Add an exception log to the central tracking database.
		/// </summary>
		/// <param name="logItem">an <see cref="ExceptionLog"/> instance that specifies the exception</param>
		/// <returns>the ID of the exception on the server</returns>
		/// <exception cref="HttpInvocationException">thrown when any HTTP status code other than
		///		200 is returned by the server; fields in the exception hold the status code and
		///		error message returned</exception>
		/// <exception cref="InvocationException">thrown when an error occurs invoking the service
		///		on the server, prior to the service running</exception>
		/// <exception cref="MalformedUriException">thrown when a valid URI cannot be constructed
		///		from the base URI and additional relative path</exception>
		public long Add(ExceptionLog logItem)
		{
			logItem = Invoke<ExceptionLog, ExceptionLog>("POST", "/", logItem);
			return logItem.ExceptionLogId;
		}
	}
}
