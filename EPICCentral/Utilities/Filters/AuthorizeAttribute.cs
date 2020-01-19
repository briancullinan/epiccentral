using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Resources;
using SharedRes;
using log4net;

namespace EPICCentral.Utilities.Filters
{
    /// <summary>
    /// Allows simple syntax to be used to allow or deny access to an action.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Parameter, Inherited = true, AllowMultiple = true)]
    public class AllowAttribute : FilterAttribute, IAuthorizationFilter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(AllowAttribute));

        public string Roles { get; set; }

        public string Users { get; set; }

        public string Message { get; set; }

        protected virtual bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            IPrincipal user = httpContext.User;

            var usersSplit = Users != null ? Users.Split(',').Select(x => x.Trim()) : new string[] {};
            var rolesSplit = Roles != null ? Roles.Split(',').Select(x => x.Trim()) : new string[] {};

            if (usersSplit.Any(x => (x == "*" && user.Identity.IsAuthenticated) ||
                (x == "?" && !user.Identity.IsAuthenticated) ||
                (user.Identity.IsAuthenticated && x == user.Identity.Name)))
                return true;

            if (rolesSplit.Any(x => (x == "*" && user.Identity.IsAuthenticated) ||
                (x == "?" && !user.Identity.IsAuthenticated) ||
                (user.Identity.IsAuthenticated && user.IsInRole(x))))
                return true;

            return false;
        }

        public virtual void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            if (OutputCacheAttribute.IsChildActionCacheActive(filterContext))
            {
                // If a child action cache block is active, we need to fail immediately, even if authorization
                // would have succeeded. The reason is that there's no way to hook a callback to rerun 
                // authorization before the fragment is served from the cache, so we can't guarantee that this 
                // filter will be re-run on subsequent requests.
                throw new InvalidOperationException("Cannot use within child action cache.");
            }

            if (AuthorizeCore(filterContext.HttpContext))
            {
                // ** IMPORTANT ** 
                // Since we're performing authorization at the action level, the authorization code runs
                // after the output caching module. In the worst case this could allow an authorized user 
                // to cause the page to be cached, then an unauthorized user would later be served the 
                // cached page. We work around this by telling proxies not to cache the sensitive page,
                // then we hook our custom authorization code into the caching mechanism so that we have 
                // the final say on whether a page should be served from the cache.
                if(filterContext.HttpContext.Response != null)
                {
                    HttpCachePolicyBase cachePolicy = filterContext.HttpContext.Response.Cache;
                    cachePolicy.SetProxyMaxAge(new TimeSpan(0));
                    cachePolicy.AddValidationCallback(CacheValidateHandler, null /* data */);
                }
            }
            else
            {
                HandleUnauthorizedRequest(filterContext);
            }
        }

        protected virtual void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            // Returns HTTP 401 - see comment in HttpUnauthorizedResult.cs.
            var controller = filterContext.Controller as Controller;
            if(controller != null)
                filterContext.Controller.TempData.Add("error", !String.IsNullOrEmpty(Message) ? Message : SharedRes.Error.Unauthorized);
            Log.Debug(String.Format(Error.UnauthorizedActionController, filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, filterContext.ActionDescriptor.ActionName));
            filterContext.Result = new HttpUnauthorizedResult();
        }

        private void CacheValidateHandler(HttpContext context, object data, ref HttpValidationStatus validationStatus)
        {
            validationStatus = OnCacheAuthorization(new HttpContextWrapper(context));
        } 

        // This method must be thread-safe since it is called by the caching module.
        protected virtual HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            bool isAuthorized = AuthorizeCore(httpContext);
            return (isAuthorized) ? HttpValidationStatus.Valid : HttpValidationStatus.IgnoreThisRequest;
        }

    }
    public class DenyAttribute : AllowAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return !base.AuthorizeCore(httpContext);
        }
    }
}