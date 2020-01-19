extern alias CurrentAPI;

using System;
using System.Net;
using System.Security.Principal;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Web.Security;
using EPICCentral.Providers;

using V0100 = CurrentAPI::EPICCentralServiceAPI.REST;

namespace EPICCentral.REST.Core
{
	public class RESTAuthenticator : IHttpModule
	{
		public const string AUTHENTICATION_TYPE_REST = "Custom REST";

        private const string DENIAL_RESPONSE = "<string>" + V0100.Constants.StatusSubcode.UNAUTHORIZED + "</string>";
	    private const string SHOULDBE401 = "__THISREQUESTIS401__";

		public void Init(HttpApplication context)
		{
			context.AuthenticateRequest += OnAuthenticateRequest;
            context.EndRequest += (sender, args) =>
            {
                if (((HttpApplication)sender).Request.Path.StartsWith(ServiceRegistrar.ServiceUrlRoot) &&
                    ((HttpApplication)sender).Context.Items[SHOULDBE401] != null && 
                    (bool)((HttpApplication)sender).Context.Items[SHOULDBE401])
                {
                    ((HttpApplication)sender).Response.StatusCode = 401;
                }
            };
        }

		public void OnAuthenticateRequest(object source, EventArgs eventArgs)
		{
			HttpApplication application = (HttpApplication)source;
			if (application.Context.User == null)
			{
				string path = application.Request.Path;
				if (path.StartsWith(ServiceRegistrar.ServiceUrlRoot))
				{
					ServiceRecord service = ServiceRegistrar.GetServiceRecord(path);
					if (service != null)
					{
						if (!DoAuthentication(application))
						{
							HttpResponse response = application.Response;
                            application.Context.Items.Add(SHOULDBE401, true);
							response.StatusDescription = "Access Denied";
						    SetAuthHeader(response);
							application.CompleteRequest();
						}
					}
				}
			}
		}

		public void Dispose()
		{
		}

		private static bool DoAuthentication(HttpApplication application)
		{
			string authHeader = application.Request.Headers["Authorization"];
			if (!string.IsNullOrEmpty(authHeader))
			{
				authHeader = authHeader.Trim();
				if (authHeader.StartsWith("Basic"))
				{
					string[] usernamePassword = GetUsernamePassword(authHeader);

					MembershipUser user;
					CombinedMembershipProvider provider = new CombinedMembershipProvider();
					if (provider.ValidateUser(usernamePassword[0], usernamePassword[1]) && (user = provider.GetUser(usernamePassword[0], false)) != null)
					{
						// TODO: Add roles to the Principal.
						application.Context.User = new GenericPrincipal(new GenericIdentity(user.UserName, AUTHENTICATION_TYPE_REST), null);
						return true;
					}
				}
			}

			return false;
		}

		private static string[] GetUsernamePassword(string authHeader)
		{
			string encodedCredentials = authHeader.Substring("Basic".Length + 1).Trim();
			string credentials = Encoding.ASCII.GetString(Convert.FromBase64String(encodedCredentials));
			return credentials.Split(new[] { ':' });
		}

		private static void SetAuthHeader(HttpResponse response)
		{
			response.AddHeader("WWW-Authenticate", "Basic realm =\"Secure Service\"");
		}
	}
}