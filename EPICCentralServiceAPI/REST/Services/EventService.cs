using System;
using EPICCentralServiceAPI.REST.Core;
using EPICCentralServiceAPI.REST.Objects;

namespace EPICCentralServiceAPI.REST.Services
{
	/// <summary>
	/// REST service interface for sending defined events to the server.
	/// This class presents a simple method for dispatching an event defined by an
	/// <see cref="Event"/> instance.
	/// Internally, it will apply all the plumbing necessary to invoke the service
	/// on the server and return its response.
	/// </summary>
	public class EventService : Service
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
				SetBaseUri(value, "events/");
			}
		}

		/// <summary>
		/// Dispatch an event to the central server.
		/// </summary>
		/// <param name="eventt">an <see cref="Event"/> instance that specifies the event</param>
		/// <returns>a long containing the ID of the event on the server</returns>
		/// <exception cref="HttpInvocationException">thrown when any HTTP status code other than
		///		200 is returned by the server; fields in the exception hold the status code and
		///		error message returned</exception>
		/// <exception cref="InvocationException">thrown when an error occurs invoking the service
		///		on the server, prior to the service running</exception>
		/// <exception cref="MalformedUriException">thrown when a valid URI cannot be constructed
		///		from the base URI and additional relative path</exception>
		public long Dispatch(Event eventt)
		{
			eventt = Invoke<Event, Event>("POST", "/", eventt);
			return eventt.EventId;
		}
	}
}
