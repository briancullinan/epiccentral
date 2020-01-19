using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using log4net;

namespace EPICCentralServiceAPI.REST.Core
{
	public abstract class Service
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(Service));

		internal Service()
		{
		}

		private Uri baseUri;
		internal virtual Uri BaseUri
		{
			get { return baseUri; }
			set
			{
				throw new NotImplementedException("Setter must be overridden by subclass.");
			}
		}

		internal Gateway Gateway { get; set; }

		internal virtual RequestBuilder RequestBuilder { get; set; }

		protected void SetBaseUri(Uri rootUri, string relativeUri)
		{
			Uri uri;
			if (!Uri.TryCreate(rootUri, relativeUri, out uri))
				throw new MalformedUriException("Cannot construct valid URI", rootUri + relativeUri);

			baseUri = uri;
		}

		public WebResponse Invoke(string method)
		{
			return Invoke(GetRequest(method));
		}

		public WebResponse Invoke(string method, string relativeUri)
		{
			return Invoke(GetRequest(method, relativeUri));
		}

		public TResponse Invoke<TResponse>(string method)
		{
			return Invoke<TResponse>(GetRequest(method));
		}

		public TResponse Invoke<TResponse>(string method, string relativeUri)
		{
			return Invoke<TResponse>(GetRequest(method, relativeUri));
		}

		public WebResponse Invoke<TContent>(string method, TContent content)
		{
			return Invoke(GetRequest(method), content);
		}

		public WebResponse Invoke<TContent>(string method, string relativeUri, TContent content)
		{
			return Invoke(GetRequest(method, relativeUri), content);
		}

		public TResponse Invoke<TContent, TResponse>(string method, TContent content)
		{
			return Invoke<TContent, TResponse>(GetRequest(method), content);
		}

		public TResponse Invoke<TContent, TResponse>(string method, string relativeUri, TContent content)
		{
			return Invoke<TContent, TResponse>(GetRequest(method, relativeUri), content);
		}

		protected WebResponse Invoke(HttpWebRequest request)
		{
			return GetResponse(request, GetResponse);
		}

		protected TResponse Invoke<TResponse>(HttpWebRequest request)
		{
			return GetResponse(request, GetResponse<TResponse>);
		}

		protected WebResponse Invoke<TContent>(HttpWebRequest request, TContent content)
		{
			Send(request, content);
			return GetResponse(request, GetResponse);
		}

		protected TResponse Invoke<TContent, TResponse>(HttpWebRequest request, TContent content)
		{
			Send(request, content);
			return GetResponse(request, GetResponse<TResponse>);
		}

		public void Send<TContent>(HttpWebRequest request, TContent content)
		{
			string method = request.Method.ToUpper();
			try
			{
				if (method == "POST" || method == "PUT")
				{
					byte[] buffer;

					DataContractSerializer dcSerializer = new DataContractSerializer(typeof(TContent));
					using (StringWriter stringWriter = new StringWriter())
					{
						using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Encoding = new ASCIIEncoding(), Indent = false, OmitXmlDeclaration = true }))
							dcSerializer.WriteObject(xmlWriter, content);

						buffer = Encoding.ASCII.GetBytes(stringWriter.ToString());
					}

					request.ContentLength = buffer.Length;
					request.ContentType = "application/xml; charset=utf-8";

					if (Log.IsDebugEnabled)
						Log.Debug(string.Format("Writing request Content: {0}, {1} method, {2} bytes, first 80 bytes '{3}...'", request.RequestUri, method, buffer.Length, Encoding.ASCII.GetString(buffer, 0, 80)));
					
					using (Stream requestStream = request.GetRequestStream())
						requestStream.Write(buffer, 0, buffer.Length);
				}
			}
			catch (WebException e)
			{
				if (Log.IsDebugEnabled)
					Log.Debug(string.Format("Error writing request Content: {0}, {1} method", request.RequestUri, method), e);

				throw new InvocationException("Error sending request", e);
			}
			catch (Exception e)
			{
				// Most likely serialization or I/O error. All others are programming issues.
				if (Log.IsDebugEnabled)
					Log.Debug(string.Format("Error writing request Content: {0}, {1} method, likely serialization or I/O error", request.RequestUri, method), e);

				throw new InvocationException("Request transmission error", e);
			}
		}

		public HttpWebRequest GetRequest(string method)
		{
			return GetRequest(method, string.Empty);
		}

		public HttpWebRequest GetRequest(string method, string relativeUri)
		{
			Uri uri;
			if (string.IsNullOrWhiteSpace(relativeUri))
				uri = BaseUri;
			else
			{
				if (!Uri.TryCreate(BaseUri, relativeUri.TrimStart(new[] { ' ', '/' }).TrimEnd(new[] { ' ' }), out uri))
				{
					if (Log.IsDebugEnabled)
						Log.Debug(string.Format("Cannot construct valid URI: {0}{1}", BaseUri, relativeUri));

					throw new MalformedUriException("Cannot construct valid URI", BaseUri + relativeUri);
				}
			}

			return GetRequest(uri, method);
		}

		protected HttpWebRequest GetRequest(Uri uri, string method)
		{
			return RequestBuilder(uri, method);
		}

		public TResponse GetResponse<TResponse>(HttpWebRequest request, GetResponseDelegate<TResponse> getResponse)
		{
			if (Log.IsDebugEnabled)
				Log.Debug(string.Format("Reading Response of {0} type, {1}, {2} method", typeof(TResponse), request.RequestUri, request.Method));

			try
			{
				// Invoke delegate to get the response.
				return getResponse(request.GetResponse());
			}
			catch (WebException e)
			{
				InvocationException exception;

				string errorDescription = GetResponse<string>(e.Response) ?? e.Status.ToString();

				if (e.Response is HttpWebResponse)
					exception = new HttpInvocationException(((HttpWebResponse)(e.Response)).StatusCode, errorDescription);
				else
					exception = new InvocationException(errorDescription, e);

				if (Log.IsDebugEnabled)
					Log.Debug(string.Format("WebException Response: {0}, {1} method. Error is '{2}'", request.RequestUri, request.Method, exception.Message));

				throw exception;
			}
			catch (Exception e)
			{
				if (Log.IsDebugEnabled)
					Log.Debug(string.Format("Error reading Response: {0}, {1} method", request.RequestUri, request.Method), e);

				throw new InvocationException("Service invocation exception", e);
			}
		}

		public delegate TResponse GetResponseDelegate<out TResponse>(WebResponse response);

		public WebResponse GetResponse(WebResponse response)
		{
			return response;
		}

		public TResponse GetResponse<TResponse>(WebResponse response)
		{
			if (response == null)
				return default(TResponse);

			string contentType = response.ContentType;
			if (string.IsNullOrEmpty(contentType) || !contentType.StartsWith("application/xml"))
				return default(TResponse);

			Stream responseStream = response.GetResponseStream();
			if (responseStream == null)
				return default(TResponse);

			using (StreamReader streamReader = new StreamReader(responseStream, Encoding.GetEncoding(1252)))
			{
				string s = streamReader.ReadToEnd();
				if (string.IsNullOrWhiteSpace(s))
					return default(TResponse);

				DataContractSerializer dcSerializer = new DataContractSerializer(typeof(TResponse));
				using (StringReader stringReader = new StringReader(s))
				{
					using (XmlReader xmlReader = new XmlTextReader(stringReader))
						return (TResponse)dcSerializer.ReadObject(xmlReader, true);
				}
			}
		}
	}
}
