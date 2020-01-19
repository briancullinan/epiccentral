using System;
using EPICCentralServiceAPI.REST.Core;
using EPICCentralServiceAPI.REST.Objects;

namespace EPICCentralServiceAPI.REST.Services
{
	/// <summary>
	/// REST service interface for getting messages from the server.
	/// Messages can be created on the server to be displayed on the client for user's
	/// to be informed of events, issues, marketing programs, etc.
	/// This class presents a simple method for getting all the message from the server.
	/// Internally, it will apply all the plumbing necessary to invoke the service
	/// on the server and return its response.
	/// </summary>
	public class MessageService : Service
	{
		/// <summary>
		/// The URI for the event service.
		/// Service methods extend this URI with method-specific parameters.
		/// </summary>
		/// <value>the root URI for the REST services</value>
		internal override Uri BaseUri
		{
			set
			{
				SetBaseUri(value, "messages/");
			}
		}

		/// <summary>
		/// Get the list of current messages for the device.
		/// </summary>
		/// <returns>the messages which are current</returns>
		/// <exception cref="HttpInvocationException">thrown when any HTTP status code other than
		///		200 is returned by the server; fields in the exception hold the status code and
		///		error message returned</exception>
		/// <exception cref="InvocationException">thrown when an error occurs invoking the service
		///		on the server, prior to the service running</exception>
		public Messages GetAll()
		{
			return Invoke<Messages>("GET");
		}
	}
}
