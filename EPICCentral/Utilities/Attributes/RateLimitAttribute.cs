using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Routing;
using SharedRes;

namespace EPICCentral.Utilities.Attributes
{
    /// <summary>
    /// Use this on the POST and GET methods to display error
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RateLimitAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Default rate limiting is logarithmic.
        /// </summary>
        private bool _secondsSet;
        private int _seconds;
        public int Seconds
        {
            get
            {
                if (!_secondsSet)
                    _seconds = 2;
                return _seconds;
            }
            set
            {
                _secondsSet = true;
                _seconds = value;
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.HttpMethod == "GET")
            {
                // check for model state error and add to current context
                if(filterContext.Controller.TempData.ContainsKey("409"))
                    filterContext.Controller.ViewData.ModelState.AddModelError("", filterContext.Controller.TempData["409"].ToString());
            }
            else
            {
                // Using the IP Address here as part of the key but you could modify
                // and use the username if you are going to limit only authenticated users
                // filterContext.HttpContext.User.Identity.Name
                var key = string.Format("{0}-{1}-{2}",
                                        filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                                        filterContext.ActionDescriptor.ActionName,
                                        filterContext.HttpContext.Request.UserHostAddress
                    );

                var allowExecute = false;

                var seconds = (int) (HttpRuntime.Cache[key + "Seconds"] ?? Seconds);
                // re-add key to cache reset the wait between requests
                if (HttpRuntime.Cache[key] != null)
                {
                    // increase seconds
                    try
                    {
                        HttpRuntime.Cache.Remove(key);
                        HttpRuntime.Cache.Remove(key + "Seconds");
                    }
                    catch
                    {
                    }

                    // multiple seconds to increase logarithmically
                    if (!_secondsSet)
                        seconds *= 2;
                }
                else
                    allowExecute = true;

                HttpRuntime.Cache.Add(key,
                                      true,
                                      null,
                                      DateTime.Now.AddSeconds(seconds),
                                      Cache.NoSlidingExpiration,
                                      CacheItemPriority.Low,
                                      null);
                HttpRuntime.Cache.Add(key + "Seconds",
                                      seconds,
                                      null,
                                      DateTime.Now.AddSeconds(seconds),
                                      Cache.NoSlidingExpiration,
                                      CacheItemPriority.Low,
                                      null);
                if (!allowExecute)
                {
                    // redirect to the action instead, this may clear the post data, which is ok
                    object action;
                    // get the action and check for get value
                    if (filterContext.RouteData.Values.TryGetValue("action", out action))
                    {
                        var matchingActions =
                            filterContext.ActionDescriptor.ControllerDescriptor.GetCanonicalActions().Where(
                                x => x.ActionName == action.ToString());
                        // we have a GET action to redirect to, AND it will display the message once we get there
                        if (matchingActions.Any(x =>
                                                    {
                                                        var attrs = x.GetCustomAttributes(true);
                                                        // check for GET attribute
                                                        return (
                                                            // no ActionMethodSelectorAttributes also will be matched for a GET request
                                                            !attrs.OfType<ActionMethodSelectorAttribute>().Any() ||
                                                            // get for GET attribute
                                                            attrs.OfType<HttpGetAttribute>().Any() ||
                                                            // check for GET in verbs attribute
                                                                attrs.OfType<AcceptVerbsAttribute>().Any(
                                                                    y => y.Verbs.Contains("GET"))) &&
                                                            // make sure the message will be displayed when we get there
                                                               attrs.OfType<RateLimitAttribute>().Any();
                                                    }))
                        {
                            filterContext.Controller.TempData["409"] = string.Format(Error.RateLimit, seconds);
                            filterContext.Result =
                                new RedirectToRouteResult(new RouteValueDictionary(filterContext.RouteData.Values));
                            return;
                        }

                    }
                    // if we can't redirect to a get action above, throw an error page
                    throw new HttpException(409, string.Format(Error.RateLimit, seconds));
                }
            }
        }
    }
}