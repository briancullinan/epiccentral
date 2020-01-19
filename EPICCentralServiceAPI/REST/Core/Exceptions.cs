using System;
using System.Net;

namespace EPICCentralServiceAPI.REST.Core
{
	/// <summary>
	/// Root exception for all specialized API exceptions.
	/// Most exceptions thrown are subclasses of this root.
	/// Instances of this exception are thrown for general errors.
	/// </summary>
	public class ServiceApiException : Exception
	{
		/// <summary>
		/// Construct a default instance.
		/// </summary>
		public ServiceApiException()
			: base()
		{}

		/// <summary>
		/// Construct an instance with the specified description.
		/// </summary>
		/// <param name="description">concise description of the error</param>
		public ServiceApiException(string description)
			: base(description)
		{}

		/// <summary>
		/// Construct an instance with the specified description and wrapping the specified
		/// exception.
		/// </summary>
		/// <param name="description">concise description of the error</param>
		/// <param name="e">the underlying exception that provides more detail</param>
		public ServiceApiException(string description, Exception e)
			: base(description, e)
		{}
	}

	/// <summary>
	/// Exception thrown by the API when a valid URI cannot be created from a set of
	/// constituent parts, usually a base and a relative additional path.
	/// </summary>
	public class MalformedUriException : ServiceApiException
	{
		/// <summary>
		/// Construct a default instance.
		/// </summary>
		public MalformedUriException()
		{}

		/// <summary>
		/// Construct an instance with the specified description.
		/// </summary>
		/// <param name="description">concise description of the error</param>
		public MalformedUriException(string description)
			: base(description)
		{}

		/// <summary>
		/// Construct an instance with the specified description and wrapping the specified
		/// exception.
		/// </summary>
		/// <param name="description">concise description of the error</param>
		/// <param name="e">the underlying exception that provides more detail</param>
		public MalformedUriException(string description, Exception e)
			: base(description, e)
		{}

		/// <summary>
		/// Construct an instance with the specified faulty URI and description.
		/// </summary>
		/// <param name="uri">the string form of the URI that cannot be constructed</param>
		/// <param name="description">concise description of the error</param>
		public MalformedUriException(string uri, string description)
			: base(description)
		{
			Uri = uri;
		}

		/// <summary>
		/// Construct an instance with the specified faulty URI and description and wrapping
		/// the specified exception.
		/// </summary>
		/// <param name="uri">the string form of the URI that cannot be constructed</param>
		/// <param name="description">concise description of the error</param>
		/// <param name="e">the underlying exception that provides more detail</param>
		public MalformedUriException(string uri, string description, Exception e)
			: base(description, e)
		{
			Uri = uri;
		}

		/// <summary>
		/// The faulty URI string.
		/// </summary>
		public string Uri { get; private set; }
	}

	/// <summary>
	/// Exception thrown by the API when a method or constructor argument is not valid.
	/// </summary>
	public class InvalidArgumentException : ServiceApiException
	{
		/// <summary>
		/// Construct a default instance.
		/// </summary>
		public InvalidArgumentException()
		{ }

		/// <summary>
		/// Construct an instance with the specified description.
		/// </summary>
		/// <param name="description">concise description of the error</param>
		public InvalidArgumentException(string description)
			: base(description)
		{ }

		/// <summary>
		/// Construct an instance with the specified description and wrapping the specified
		/// exception.
		/// </summary>
		/// <param name="description">concise description of the error</param>
		/// <param name="e">the underlying exception that provides more detail</param>
		public InvalidArgumentException(string description, Exception e)
			: base(description, e)
		{ }
	}

	/// <summary>
	/// Exception thrown by the API when an error occurs while invoking the server-side
	/// service.
	/// An instance of this exception indicates that the server-side service was not
	/// actually invoked; the error might be a serialization error, or timeout, for example.
	/// When the server-side service is actually invoked and it returns an error via an
	/// HTTP status code, an <see cref="HttpInvocationException"/> is thrown instead.
	/// </summary>
	public class InvocationException : ServiceApiException
	{
		/// <summary>
		/// Construct a default instance.
		/// </summary>
		public InvocationException()
		{ }

		/// <summary>
		/// Construct an instance with the specified description.
		/// </summary>
		/// <param name="description">concise description of the error</param>
		public InvocationException(string description)
			: base(description)
		{ }

		/// <summary>
		/// Construct an instance with the specified description and wrapping the specified
		/// exception.
		/// </summary>
		/// <param name="description">concise description of the error</param>
		/// <param name="e">the underlying exception that provides more detail</param>
		public InvocationException(string description, Exception e)
			: base(description, e)
		{
		}
	}

	/// <summary>
	/// Exception thrown by the API when an exception is returned by the server-side service.
	/// An instance of this exception is created only when there is a valid response to the
	/// web request containing an HTTP status code.
	/// The status code is saved in the <see cref="StatusCode"/> property.
	/// Any description returned by the service is saved in the <see cref="Description"/>
	/// property.
	/// If an error occurs and there is no valid response, an <see cref="InvocationException"/>
	/// is thrown instead.
	/// </summary>
	public class HttpInvocationException : InvocationException
	{
		/// <summary>
		/// Construct an instance with the specified HTTP status code and error description.
		/// </summary>
		/// <param name="statusCode">HTTP status code returned by server-side service</param>
		/// <param name="description">error description returned by server-side service</param>
		public HttpInvocationException(HttpStatusCode statusCode, string description)
			: this(statusCode, description, null)
		{ }

		/// <summary>
		/// Construct an instance with the specified HTTP status code and error description,
		/// and wrapping the specified exception.
		/// </summary>
		/// <param name="statusCode">HTTP status code returned by server-side service</param>
		/// <param name="description">error description returned by server-side service</param>
		/// <param name="e">the underlying exception that provides more detail</param>
		public HttpInvocationException(HttpStatusCode statusCode, string description, Exception e)
			: base(string.Format("{0} : {1}", (int)statusCode, description), e)
		{
			StatusCode = statusCode;
			Description = description;
		}

		/// <summary>
		/// The HTTP status code returned by the service on the server.
		/// </summary>
		public HttpStatusCode StatusCode { get; set; }

		/// <summary>
		/// Description of the error that caused the malfunction; returned by the service.
		/// </summary>
		public string Description { get; set; }
	}
}
