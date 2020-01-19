using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using EPICCentral.Models;
using EPICCentral.Utilities.Attributes;

public static class MenuExtensions
{
    /// <summary>
    /// Generates a menu link for the current menu item.
    /// </summary>
    /// <param name="htmlHelper"></param>
    /// <param name="menuItem"></param>
    /// <returns></returns>
    public static MvcHtmlString MenuLink(this HtmlHelper<IEnumerable<ActionMenuAttribute>> htmlHelper, MenuItemModel menuItem)
    {
        var viewKeys = menuItem.Route != null ?
            htmlHelper.ViewContext.ParentActionViewContext.ViewData.ModelState
                // select the values from the view that are relevant to this particular menu item
                .Where(x => x.Value.Errors.Count == 0 && menuItem.Route.ContainsKey(x.Key))
                .ToDictionary(x => x.Key.ToLower(), y => (object)y.Value.Value.AttemptedValue) : new Dictionary<string, object>();
        if (menuItem.Route != null)
        {
            // copy route values to link
            viewKeys = viewKeys
                // keep the keys from the view that are regex
                .Where(x => menuItem.Route[x.Key] is Regex)
                // copy values from the route table where the values are not regular expression
                .Concat(menuItem.Route.Where(x => !(x.Value is Regex))
                                      .Select(x => new KeyValuePair<string, object>(x.Key, x.Value)))
                .ToDictionary(x => x.Key, x => x.Value);

        }

        // create a query string just out of the relevant view keys
        var queryString = (viewKeys.Count > 0 ? "?" : "") +
                          String.Join("&", viewKeys.Select(x => x.Key + "=" + HttpUtility.UrlEncode(x.Value.ToString())));

        // create a link out of the path
        if (!String.IsNullOrEmpty(menuItem.Path))
        {
            return MvcHtmlString.Create("<a href=\"" + new UrlHelper(htmlHelper.ViewContext.RequestContext).Content(menuItem.Path + queryString) +
                           "\">" + menuItem.Text + "</a>");
        }
        else
        {
            // create a link out of the action and controller values
            return htmlHelper.ActionLink(menuItem.Text, menuItem.Action, menuItem.Controller, new RouteValueDictionary(viewKeys), null);
        }

    }
}
