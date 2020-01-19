using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Security;
using System.Web.SessionState;
using EPICCentral.Models;
using EPICCentral.Utilities.Filters;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;

namespace EPICCentral.Controllers.Widgets
{
    /// <summary>
    /// Lists the device states on the home page.
    /// </summary>
    public class DeviceStateController : DataTablesController, IWidgetController
    {
        /// <summary>
        /// Implements Title, this is a required property for every widget.
        /// </summary>
        public string Title
        {
            get { return ControllerRes.Widgets.DeviceState_Title; }
        }

        /// <summary>
        /// Implements Load, used as the default Action for loading widgets over ajax or initially on the Home page.
        /// </summary>
        /// <returns>Returns the view that is fitted in to a table that is draggable on the home page.</returns>
        public ActionResult Load()
        {
            return View((IView)this);
        }

        /// <summary>
        /// Returns the data for the table that contains all the device states.  This is only called by the datatable.
        /// </summary>
        /// <param name="dtRequestModel"></param>
        /// <returns></returns>
        [Allow(Users = "*")]
        public ActionResult Query([ModelBinder(typeof(DataTablesRequestModelBinder))] DataTablesRequestModel dtRequestModel)
        {
            var result = View(this);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return Query(result, dtRequestModel);
        }

        /// <summary>
        /// Implements the Render function for calling View(this) as the IView.
        /// </summary>
        /// <param name="viewContext"></param>
        /// <param name="writer"></param>
        public void Render(ViewContext viewContext, System.IO.TextWriter writer)
        {
            // render device display
            var htmlHelper = new HtmlHelper<IQueryable<DeviceEntity>>(viewContext, this);
            var table = htmlHelper.DataTableFor(new LinqMetaData().Device.WithPermissions(), new ColumnCollection<DeviceEntity>
                                                             {
                                                                 {x => x.SerialNumber, ControllerRes.Widgets.DeviceState_SerialNumber},
                                                                 {x => x.Location.Name, ControllerRes.Widgets.DeviceState_LocationName},
                                                                 {x => x.DeviceState, ControllerRes.Widgets.DeviceState_DeviceState}
                                                             },
                                                ajaxUrl:
                                                    new UrlHelper(viewContext.RequestContext).Action("Query",
                                                                                                     "DeviceState"));
            writer.Write(htmlHelper.RenderScripts());
            writer.Write(table);
            writer.Write("<br class='clear'/>" + htmlHelper.ActionLink(ControllerRes.Widgets.DeviceState_Devices, "List", "Device", null, new { @class = "button" }));
        }
    }
}
