using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPICCentral.Controllers.Widgets;

public static class WidgetExtensions
{
    /// <summary>
    /// Renders a widget.
    /// </summary>
    /// <param name="htmlHelper"></param>
    /// <param name="widget"></param>
    /// <param name="htmlAttributes"></param>
    /// <returns></returns>
    public static MvcHtmlString Widget(this HtmlHelper htmlHelper, IWidgetController widget, object htmlAttributes = null)
    {
        if(widget is WidgetController)
            return ((WidgetController)widget).Render(htmlHelper, htmlAttributes);
        else
        {
            var widgetController = new WidgetController(widget);
            return widgetController.Render(htmlHelper, htmlAttributes);
        }
    }
}
