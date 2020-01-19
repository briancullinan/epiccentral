using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

public static class RouteCollectionExtensions
{
    /// <summary>
    /// Used to create a subset of controllers. Such as the Widgets.
    /// </summary>
    /// <param name="routes"></param>
    /// <param name="areaName"></param>
    /// <param name="controllersNamespace"></param>
    /// <param name="routeEntries"></param>
    public static void CreateArea(this RouteCollection routes, string areaName, string controllersNamespace, params Route[] routeEntries)
    {
        foreach (var route in routeEntries)
        {
            if (route.Constraints == null) route.Constraints = new RouteValueDictionary();
            if (route.Defaults == null) route.Defaults = new RouteValueDictionary();
            if (route.DataTokens == null) route.DataTokens = new RouteValueDictionary();

            route.Constraints.Add("area", areaName);
            route.Defaults.Add("area", areaName);
            route.DataTokens.Add("namespaces", new string[] { controllersNamespace });

            if (!routes.Contains(route)) // To support "new Route()" in addition to "routes.MapRoute()"
                routes.Add(route);
        }
    }
}
