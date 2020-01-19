using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.ServiceModel.Activation;
using System.Web;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml;
using System.Xml.Linq;
using EPICCentral.Controllers;
using EPICCentral.Providers;
using EPICCentral.REST.Core;
using EPICCentral.Utilities.Filters;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;
using log4net;
using ServiceHostFactory = EPICCentral.REST.Core.ServiceHostFactory;

[assembly: InternalsVisibleTo("EPICCentralUnitTest", AllInternalsVisible = true)]

namespace EPICCentral
{
	public class Global : HttpApplication
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(Global));

	    private static VirtualPathProvider _virtualPath;
	    private static bool _virtualPathSet;
        internal static VirtualPathProvider VirtualPathProvider
	    {
	        get
	        {
	            if (!_virtualPathSet)
	                VirtualPathProvider = HostingEnvironment.VirtualPathProvider;
	            return _virtualPath;
	        }
	        set
	        {
	            _virtualPathSet = true;
	            _virtualPath = value;
	        }
	    }

        private static FormsAuthenticationService _formsAuthentication;
        private static bool _formsAuthenticationSet;
        internal static FormsAuthenticationService FormsAuthentication
	    {
	        get
	        {
                if (!_formsAuthenticationSet)
                    FormsAuthentication = FormsAuthenticationService.Service;
	            return _formsAuthentication;
	        }
	        set
	        {
	            _formsAuthenticationSet = true;
	            _formsAuthentication = value;
	        }
	    }

        public class FormsAuthenticationService
        {
            private static FormsAuthenticationService _theService;
            static FormsAuthenticationService()
            {
                _theService = new FormsAuthenticationService();
            }

            public FormsAuthenticationService()
            {
                
            }

            public static FormsAuthenticationService Service
            {
                get { return _theService; }
            }

            public virtual void SetAuthCookie(string userName, bool createPersistentCookie)
            {
                System.Web.Security.FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
            }

            public virtual void SignOut()
            {
                System.Web.Security.FormsAuthentication.SignOut();
            }
        }

	    protected void Application_PostAuthorizeRequest()
        {
        }

        internal static void SetupRequestState()
        {
            new Global().Application_AcquireRequestState(null, null);
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            try
            {
                // only set the language for requests with a session
                if (HttpContext.Current.Session != null)
                {
                    var ci = DetectCultureInfo();
                    var tz = DetectTimeZoneInfo();

                    // set the language for the thread
                    System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
                    System.Threading.Thread.CurrentThread.CurrentCulture = ci;

                    // store the timezone for the thread
                    HttpContext.Current.Items["TimeZoneInfo"] = tz;
                }
            }
            catch(Exception ex)
            {
                Log.Error("Exception while initializing.", ex);
            }
        }

	    private TimeZoneInfo DetectTimeZoneInfo()
	    {
            // create TimeZoneInfo to use below
	        TimeZoneInfo tz = null;

            // get the timezone from the users profile
            UserSettingEntity regionAutoSetting = null;
            UserSettingEntity regionSetting = null;
	        Utilities.Information.TimeZones.TimeZone zone = null;

            if (HttpContext.Current.Session["timezone"] != null)
            {
                tz = TimeZoneInfo.FindSystemTimeZoneById(HttpContext.Current.Session["timezone"].ToString());
            }
            else if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var user = Membership.GetUser(HttpContext.Current.User.Identity.Name);
                if (user != null && Membership.Providers[user.ProviderName] is EpicMembershipProvider)
                {
                    var userEntity = user.GetUserEntity();
                    // check if the region setting is set to auto configure when the timezone changed
                    regionAutoSetting = userEntity.Settings.FirstOrDefault(x => x.Name == "RegionAuto");
                    regionSetting = userEntity.Settings.FirstOrDefault(x => x.Name == "Region");
                    // force the timezone in the users profile to be used
                    if ((regionAutoSetting == null || regionAutoSetting.Value != "True") &&
                        regionSetting != null)
                    {
                        // convert regional info to window time zone eg Arizona/Phoenix = US Mountain Standard Time
                        zone = Utilities.Information.TimeZones.Zones.FirstOrDefault(x => x.Type == regionSetting.Value);
                        if (zone != null)
                            tz = TimeZoneInfo.FindSystemTimeZoneById(zone.Zone);
                    }
                }
            }

	        // try to get timezone from client
            if (tz == null && HttpContext.Current.Request["tz"] != null)
            {
                zone = Utilities.Information.TimeZones.Zones.FirstOrDefault(x => x.Type == HttpContext.Current.Request["tz"]);
                if (zone != null)
                    tz = TimeZoneInfo.FindSystemTimeZoneById(zone.Zone);
            }

            // save the timezone in the session
            if (tz != null && HttpContext.Current.Session["timezone"] == null)
                HttpContext.Current.Session["timezone"] = tz.Id;
            tz = tz ?? TimeZoneInfo.FindSystemTimeZoneById("UTC");

            // save the timezone in the user profile
            if (HttpContext.Current.User.Identity.IsAuthenticated && zone != null &&
                // if the region is set to auto, do not save the timezone
                (regionAutoSetting == null || regionAutoSetting.Value != "True" || regionSetting == null))
            {
                var user = Membership.GetUser(HttpContext.Current.User.Identity.Name);
                if (user != null && Membership.Providers[user.ProviderName] is EpicMembershipProvider)
                {
                    var userEntity = user.GetUserEntity();
                    // default to true
                    if (regionAutoSetting == null)
                        new UserSettingEntity(userEntity.UserId, "RegionAuto")
                            {
                                UserId = userEntity.UserId,
                                Name = "RegionAuto",
                                Value = "True"
                            }.Save();
                    new UserSettingEntity(userEntity.UserId, "Region")
                    {
                        UserId = userEntity.UserId,
                        Name = "Region",
                        Value = zone.Type
                    }.Save();
                }
            }

	        return tz;
	    }

	    private CultureInfo DetectCultureInfo()
	    {
            // Create culture info object 
            CultureInfo ci = null;

            // try to get saved language from user session
            UserSettingEntity langSetting = null;

            if (HttpContext.Current.Session["lang"] != null)
            {
                ci = new CultureInfo(HttpContext.Current.Session["lang"].ToString());
            }
            else if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var user = Membership.GetUser(HttpContext.Current.User.Identity.Name);
                if (user != null && Membership.Providers[user.ProviderName] is EpicMembershipProvider)
                {
                    var userEntity = user.GetUserEntity();
                    langSetting = userEntity.Settings.FirstOrDefault(x => x.Name == "Language");
                    if (langSetting != null)
                    {
                        ci = new CultureInfo(langSetting.Value);
                    }
                }
            }

            // try to get culture from client
            if (ci == null && Request.UserLanguages != null)
            {
                var lang = Request.UserLanguages.First();
                ci = new CultureInfo(lang);
            }

            ci = ci ?? new CultureInfo("en-US");
            // save language in session
            if (HttpContext.Current.Session["lang"] == null)
            HttpContext.Current.Session["lang"] = ci.Name;

            // save the language as a user setting for future use
            if (langSetting == null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var user = Membership.GetUser(HttpContext.Current.User.Identity.Name);
                if (user != null && Membership.Providers[user.ProviderName] is EpicMembershipProvider)
                {
                    var userEntity = user.GetUserEntity();
                    new UserSettingEntity(userEntity.UserId, "Language") { UserId = userEntity.UserId, Name = "Language", Value = ci.Name }.Save();
                }
            }

	        return ci;
	    }

	    protected void Application_Start(object sender, EventArgs e)
		{
			Log.Info("Application instance starting up ...");

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            RegisterServiceRoutes(RouteTable.Routes, (s, @base, arg3) => new ServiceRoute(s, @base, arg3));
        }

		protected void Session_Start(object sender, EventArgs e)
		{

		}

		protected void Application_PostRequestHandlerExecute(object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
        }

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

        private static string GetRequestInfo()
        {
            var current = HttpContext.Current;
            var request = "";
            if (current != null)
                request = String.Join("\n", current
                                                .Request.GetType().GetProperties()
                                                .Select(x =>
                                                {
                                                    try
                                                    {
                                                        var obj = x.GetValue(current.Request, null);
                                                        if (obj != null)
                                                            return x.Name + " = " + obj.ToString();
                                                    }
                                                    catch { }
                                                    return x.Name + " = null";
                                                }))
                          + Environment.NewLine
                          + String.Join("\n", current.Request.ServerVariables.AllKeys
                                                  .Select(x => x + " = " + current.Request
                                                                   .ServerVariables[x].ToString(
                                                                       CultureInfo.InvariantCulture)));
            return request;
        }

        internal static void ErrorOut(Exception exception = null)
        {
            if(exception == null)
                exception = HttpContext.Current.Server.GetLastError();

            HttpContext.Current.Response.TrySkipIisCustomErrors = true;
            Log.Debug(GetRequestInfo(), exception);
            Log.Error(exception.Message, exception);

            HttpContext.Current.Response.Clear();

            var httpException = exception as HttpException;
            var routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("action", "Index");
            if (HttpContext.Current.Handler is MvcHandler)
            {
                var oldRouteData = ((MvcHandler)HttpContext.Current.Handler).RequestContext.RouteData;
                routeData.Values.Add("error", new HandleErrorInfo(exception, oldRouteData.Values["controller"].ToString(), oldRouteData.Values["action"].ToString()));
                var httpContext = new HttpContextWrapper(HttpContext.Current);
                var requestContext = new RequestContext(httpContext, routeData);
                var handler = new MvcHandler(requestContext);
                ((MvcHandler)HttpContext.Current.Handler).RequestContext.HttpContext.Server.Execute(handler, HttpContext.Current.Response.Output, true);
            }
            else
            {
                routeData.Values.Add("error", new HandleErrorInfo(exception, "Error", "Index"));
                var httpContext = new HttpContextWrapper(HttpContext.Current);
                var requestContext = new RequestContext(httpContext, routeData);
                var handler = new MvcHandler(requestContext);
                HttpContext.Current.Server.Execute(handler, HttpContext.Current.Response.Output, true);
            }


            if (httpException != null)
            {
                /*
                switch (httpException.GetHttpCode())
                {
                    case 404:
                        // page not found
                        routeData.Values["action"] = "NotFound";
                        break;
                    //case 500:
                        // server error
                    //    routeData.Values.Add("action", "HttpError500");
                    //    break;
                    default:
                        routeData.Values["action"] = "Index";
                        break;
                }
                 * */
            }


            // clear error on server
            HttpContext.Current.Server.ClearError();
        }

		protected void Application_Error(object sender, EventArgs e) 
		{
            ErrorOut();
        }

		protected void Session_End(object sender, EventArgs e)
		{

		}

		protected void Application_End(object sender, EventArgs e)
		{

		}

        internal static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            var provider = new ActionLogFilterProvider();
            //provider.Add("Account", "LogOn");
            //provider.Add("Store", "*");
            //provider.Add("*", "Index");
            FilterProviders.Providers.Add(provider);
        }

        internal static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{myWebForms}.aspx/{*pathInfo}");
            routes.IgnoreRoute("{myWebServices}.asmx/{*pathInfo}");
            //routes.IgnoreRoute("");

            routes.CreateArea("Widgets", "EPICCentral.Controllers.Widgets",
                              routes.MapRoute(null, "Widgets/{controller}/{action}", new {controller = "Home", action = "Index"}));

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
				new { controller = "^(?!api).*" }
            );
        }

        public static void RegisterServiceRoutes(RouteCollection routes, Func<string, ServiceHostFactoryBase, Type, Route> routeGenerator)
        {
            foreach (ServiceRecord service in ServiceRegistrar.GetServiceRecords())
                routes.Add(routeGenerator(service.GetServiceUrl(ServiceRegistrar.ServiceUrlRoot).TrimStart(new[] { '/', '~' }), new ServiceHostFactory(service.MaxReceivedMessageSize), service.ServiceType));
        }
	}
}