using System;
using System.IO;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.SessionState;

namespace EPICCentral.Controllers.Widgets
{
    public interface IWidgetController: IController, IView, IViewDataContainer
    {
        ActionResult Load();
        string Title { get; }
    }

    public class WidgetController : Controller, IWidgetController
    {
        private bool _isLoaded;
        private IWidgetController _widget;

        protected HtmlHelper Html { get; set; }

        public WidgetController()
        {
            _isLoaded = false;
        }

        public WidgetController(IWidgetController widget)
        {
            _widget = widget;
        }

        public virtual string Title { get { return _widget != null ? _widget.Title : ""; } }

        public virtual ActionResult Load()
        {
            return View(this);
        }

        public MvcHtmlString Render(HtmlHelper htmlHelper, object htmlAttributes = null)
        {
            MvcHtmlString actionResults;
            var type = GetType();
            if (_widget != null)
                type = _widget.GetType();
            try
            {
                actionResults = htmlHelper.Action("Load", type.Name.Replace("Controller", ""));
            }
            catch
            {
                actionResults =
                    MvcHtmlString.Create(String.Format(ControllerRes.Widgets.Widget_RenderError, GetType()));
            }
            _isLoaded = true;
            var div = new TagBuilder("div");
            div.GenerateId(type.Name);
            div.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            div.InnerHtml += "<table><thead><tr><th class='title'>" + Title + "</th></tr></thead><tbody><tr><td>" + actionResults + "</td></tr></tbody></table>";

            return MvcHtmlString.Create(div.ToString());
        }

        public virtual void Render(ViewContext viewContext, TextWriter writer)
        {
            writer.Write(ControllerRes.Widgets.Widget_Content);
        }
    }
}

