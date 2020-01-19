using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPICCentralDL.EntityClasses;
using log4net;

namespace EPICCentral.Utilities.Filters
{
    public class ActionLogFilterProvider : IFilterProvider
    {
        //private IList<ControllerAction> actions = new List<ControllerAction>();

        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            yield return new Filter(new ActionLogAttribute(), FilterScope.First, null);

            /*foreach (ControllerAction action in actions)
                if ((action.ControllerName == actionDescriptor.ControllerDescriptor.ControllerName ||
                     action.ControllerName == "*")
                    && (action.ActionName == actionDescriptor.ActionName || action.ActionName == "*"))
                {
                    yield return new Filter(new ActionLogAttribute(), FilterScope.First, null);
                    break;
                }
            yield break;*/
        }
        /*
        public void Add(string controllername, string actionname)
        {
            actions.Add(new ControllerAction {ControllerName = controllername, ActionName = actionname});
        }
         * */
    }

    /// <summary>
    /// Records all actions invoked by a browser request or within the system.
    /// </summary>
    public class ActionLogAttribute : FilterAttribute, IActionFilter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ActionLogAttribute));

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var action = filterContext.ActionDescriptor.ActionName;
            var ip = filterContext.HttpContext.Request.UserHostAddress;
            var date = filterContext.HttpContext.Timestamp;
            var method = filterContext.HttpContext.Request.HttpMethod;

            Log.Debug(String.Format("Executing: {0} - {1} - {2} - {3} - {4}", method, controller, action, ip, date));
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var action = filterContext.ActionDescriptor.ActionName;
            var ip = filterContext.HttpContext.Request.UserHostAddress;
            var date = filterContext.HttpContext.Timestamp;
            var method = filterContext.HttpContext.Request.HttpMethod;

            new UpdateStatusEntity(controller, action) { Controller = controller, Action = action, Method = method, UpdateTime = DateTime.UtcNow }.Save();

            Log.Debug(String.Format("Executed: {0} - {1} - {2} - {3} - {4}", method, controller, action, ip, date));
        }
    }

    /*
    internal class ControllerAction
    {

        internal string ControllerName { get; set; }

        internal string ActionName { get; set; }

    }
    */
}