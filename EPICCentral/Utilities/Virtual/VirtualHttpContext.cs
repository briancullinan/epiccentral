using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPICCentral.Utilities.Virtual
{
    internal class VirtualHttpContext : HttpContextBase
    {
        private readonly MockRequest _request;
        public VirtualHttpContext(string url)
        {
            _request = new MockRequest(url);
        }

        public override HttpRequestBase Request
        {
            get
            {
                return _request;
            }
        }

        public override System.Collections.IDictionary Items
        {
            get { return System.Web.HttpContext.Current.Items; }
        }

        public override System.Security.Principal.IPrincipal User
        {
            get { return System.Web.HttpContext.Current.User; }
            set { System.Web.HttpContext.Current.User = value; }
        }

        public override HttpResponseBase Response
        {
            get { return null; }
        }

        public static bool ActionIsAuthorized(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            if (actionDescriptor == null)
                return false; // action does not exist so say yes - should we authorise this?!

            var authContext = new AuthorizationContext(controllerContext, actionDescriptor);

            // run each auth filter until on fails
            var authFilters =
                FilterProviders.Providers.GetFilters(controllerContext, actionDescriptor).Where(x => x.Instance is IAuthorizationFilter);

            // performance could be improved by some caching
            foreach (var authFilter in authFilters)
            {
                ((IAuthorizationFilter)authFilter.Instance).OnAuthorization(authContext);

                if (authContext.Result != null)
                    return false;
            }

            return true;
        }

    }
}