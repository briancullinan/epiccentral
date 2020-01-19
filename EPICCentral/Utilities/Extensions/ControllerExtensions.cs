using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/// <summary>
/// Extend the controller object.
/// </summary>
public static class ControllerExtensions
{
    /// <summary>
    /// Renders any view for the specified controller context, used to generate e-mails and send them using the same MVC paradigm.
    /// </summary>
    /// <param name="controllerContext"></param>
    /// <param name="partialViewName"></param>
    /// <param name="viewData"></param>
    /// <returns></returns>
    public static MvcHtmlString Render(this ControllerContext controllerContext, string partialViewName, ViewDataDictionary viewData = null)
    {
        using (var sw = new StringWriter())
        {
            var view = ViewEngines.Engines.FindPartialView(controllerContext, partialViewName);
            var newViewContext = new ViewContext(controllerContext, view.View, viewData ?? controllerContext.Controller.ViewData, controllerContext.Controller.TempData, sw);
            view.View.Render(newViewContext, sw);
            return MvcHtmlString.Create(sw.GetStringBuilder().ToString());
        }
    }
}
