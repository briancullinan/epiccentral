using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

public static class RequestContextExtensions
{
    /// <summary>
    /// Get's the method info for a particular request context, used in virtual requests for permission checking.
    /// </summary>
    /// <param name="requestContext"></param>
    /// <returns></returns>
    public static MethodInfo GetActionMethod(this RequestContext requestContext)
    {
        Type controllerType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == requestContext.RouteData.Values["controller"].ToString());
        var controllerContext = new ControllerContext(requestContext, Activator.CreateInstance(controllerType) as ControllerBase);
        var controllerDescriptor = new ReflectedControllerDescriptor(controllerType);
        var actionDescriptor = controllerDescriptor.FindAction(controllerContext, controllerContext.RouteData.Values["action"].ToString());
        return (actionDescriptor as ReflectedActionDescriptor).MethodInfo;
    }
}
