using System;
using System.Net;
using System.Security;
using System.Text;
using log4net;

namespace EPICCentralServiceAPI.REST.Core
{
	internal delegate HttpWebRequest RequestBuilder(Uri uri, string method);

	public class Gateway
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(Gateway));

		private const int PORT = 80;
		private const int SSLPORT = 443;

		private readonly string username;
		private readonly string password;

		public Gateway(string username, string password, string host, bool? secure = null, int? port = null, string language = "en")
		{
			Uri uri;

			if (!secure.HasValue)
                secure = port.HasValue && port.Value == 443 ? true : false;
			if (!port.HasValue)
				port = secure.Value ? SSLPORT : PORT;

			string uriString = string.Format("{0}://{1}:{2:D}/api/v0100/", secure.Value ? Uri.UriSchemeHttps : Uri.UriSchemeHttp, host, port);
			if (Uri.TryCreate(uriString, UriKind.Absolute, out uri))
			{
				Uri = uri;
				Host = host;
				Port = port.Value;
				Secure = secure.Value;
			}
			else
				throw new MalformedUriException("URI contains invalid components", uriString);

			this.username = username;
			this.password = password;
		    Language = language;

			if (Log.IsDebugEnabled)
				Log.Debug(string.Format("Gateway created: {0} using principal {1}", uri, username));
		}

		public Gateway(string username, string password, Uri uri)
		{
			Uri = uri;
			Host = uri.Host;
			Port = uri.Port;
			Secure = uri.Scheme.StartsWith("https");

			this.username = username;
			this.password = password;

			if (Log.IsDebugEnabled)
				Log.Debug(string.Format("Gateway created: {0} using principal {1}", uri, username));
		}

		public string Host { get; protected set; }
		public int Port { get; protected set; }
		public bool Secure { get; protected set; }
		public Uri Uri { get; protected set; }
        public string Language { get; set; }

		public TService GetService<TService>() where TService : Service, new()
		{
			TService service = new TService { BaseUri = Uri, Gateway = this, RequestBuilder = GetRequest };

			if (Log.IsDebugEnabled)
				Log.Debug(string.Format("Service created: {0} type", service.GetType()));

			return service;
		}

		internal HttpWebRequest GetRequest(Uri uri, string method)
		{
			try
			{
				HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
				if (request == null)
					throw new ServiceApiException("Unable to create HTTP request");

				request.Method = method.ToUpper();
                request.Headers.Add(HttpRequestHeader.AcceptLanguage, Language);
				request.KeepAlive = false;

				request.Headers["Authorization"] = string.Format("Basic {0}", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));

				if (Log.IsDebugEnabled)
					Log.Debug(string.Format("Created HTTP Request: {0}, {1} method, using principal {2}", uri, method, username));

				return request;
			}
			catch (SecurityException e)
			{
				if (Log.IsDebugEnabled)
					Log.Debug(string.Format("Error creating HTTP request: {0}. {1} method, using principal {2}", uri, method, username), e);

				throw;
			}
			catch (Exception e)
			{
				if (Log.IsDebugEnabled)
					Log.Debug(string.Format("Error creating HTTP request: {0}. {1} method, using principal {2}", uri, method, username), e);

				throw new ServiceApiException("Unable to create HTTP request", e);
			}
		}
	}
}
