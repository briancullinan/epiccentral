using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using EPICCentral.Controllers.Widgets;
using EPICCentral.Models;
using EPICCentral.Utilities.Attributes;
using EPICCentral.Utilities.Filters;
using EPICCentralDL.EntityClasses;

namespace EPICCentral.Controllers
{
    /// <summary>
    /// Home controller displays widgets, that's about it.
    /// </summary>
    public class HomeController : Controller
    {
        public const string WIDGET_NAMESPACE = "EPICCentral.Controllers.Widgets";

        [Allow(Users = "*")]
        [ActionMenu(ResourceName = "HomeIndex_Home", Rank = 100)]
        public ActionResult Index(HomeModel model)
        {
            var user = Membership.GetUser().GetUserEntity();
            model.Widgets = new Dictionary<Type, IWidgetController>();

            // get saved options
            model.LeftTypes = new UserSettingEntity(user.UserId, "PortletLocationLeft").Value.Split(',').Where(
                x => Type.GetType(WIDGET_NAMESPACE + '.' + x) != null).Select(x => Type.GetType(WIDGET_NAMESPACE + '.' + x)).ToArray();
            model.CenterTypes = new UserSettingEntity(user.UserId, "PortletLocationCenter").Value.Split(',').Where(
                x => Type.GetType(WIDGET_NAMESPACE + '.' + x) != null).Select(x => Type.GetType(WIDGET_NAMESPACE + '.' + x)).ToArray();
            model.RightTypes = new UserSettingEntity(user.UserId, "PortletLocationRight").Value.Split(',').Where(
                x => Type.GetType(WIDGET_NAMESPACE + '.' + x) != null).Select(x => Type.GetType(WIDGET_NAMESPACE + '.' + x)).ToArray();

            if(!user.Settings.Any(x => x.Name == "PortletLocationLeft" || x.Name == "PortletLocationCenter" || x.Name == "PortletLocationRight"))
            {
                model.LeftTypes = new[] {typeof (WeatherController), typeof (TreatmentsController)};
                model.CenterTypes = new[] {typeof (DeviceStateController)};
                model.RightTypes = new[] {typeof (RecentActivityController), typeof(AlertController)};
            }

            // load list of widgets from namespace
            var widgets =
                Assembly.GetExecutingAssembly().GetTypes().Where(
                    t => String.Equals(t.Namespace, WIDGET_NAMESPACE, StringComparison.InvariantCultureIgnoreCase)).ToArray();
            foreach (Type widget in widgets)
            {
                // skip the base widget
                if (widget == typeof(WidgetController))
                    continue;

                if (widget.IsSubclassOf(typeof(WidgetController)) || widget.GetInterfaces().Any(x => x == typeof(IWidgetController)))
                {
                    var newWidget = (IWidgetController)Activator.CreateInstance(widget);
                    model.Widgets.Add(widget, newWidget);
                }
            }

            return View(model);
        }

        [Allow(Users = "*")]
        public ActionResult SaveWidgets(string left_column, string center_column, string right_column)
        {
            var providerUserKey = Membership.GetUser().GetUserId().Id;

            // validate locations and controls
            new UserSettingEntity(providerUserKey, "PortletLocationLeft")
            {
                UserId = providerUserKey,
                Name = "PortletLocationLeft",
                Value = String.Join(",", left_column.Split(',').Where(x => Type.GetType(WIDGET_NAMESPACE + '.' + x, false, true) != null).ToArray())
            }.Save();

            new UserSettingEntity(providerUserKey, "PortletLocationCenter")
            {
                UserId = providerUserKey,
                Name = "PortletLocationCenter",
                Value = String.Join(",", center_column.Split(',').Where(x => Type.GetType(WIDGET_NAMESPACE + '.' + x, false, true) != null).ToArray())
            }.Save();

            new UserSettingEntity(providerUserKey, "PortletLocationRight")
            {
                UserId = providerUserKey,
                Name = "PortletLocationRight",
                Value = String.Join(",", right_column.Split(',').Where(x => Type.GetType(WIDGET_NAMESPACE + '.' + x, false, true) != null).ToArray())
            }.Save();

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            return new EmptyResult();
        }

        [Allow(Users = "*")]
        public ActionResult LoadWidget(string type)
        {
            var widget = Type.GetType(WIDGET_NAMESPACE + '.' + type, false, true);
            if (widget != null)
            {
                var newWidget = (IWidgetController)Activator.CreateInstance(widget);
                return View(new WidgetLoader(newWidget));
            }

            return new EmptyResult();
        }

        /// <summary>
        /// Basic structure containing all the information needed to render a widget through AJAX, rather than calling their Render function directly when the page is first generated.
        /// </summary>
        public class WidgetLoader : IView, IViewDataContainer
        {
            private IWidgetController _widget;
            public WidgetLoader(IWidgetController widget)
            {
                _widget = widget;
            }

            public void Render(ViewContext viewContext, TextWriter writer)
            {
                ViewData = viewContext.ViewData;
                var htmlHelper = new HtmlHelper(viewContext, this);
                var body = htmlHelper.Widget(_widget);
                writer.Write(htmlHelper.RenderScripts());
                writer.Write(body);
            }

            public ViewDataDictionary ViewData { get; set; }
        }

#if DEBUG || LOGTEST
        public ActionResult GenerateException(int next)
        {
            throw new NotImplementedException(next.ToString(CultureInfo.InvariantCulture));
        }
#endif
    }
}
