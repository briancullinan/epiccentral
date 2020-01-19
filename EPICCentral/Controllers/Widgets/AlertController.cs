using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using EPICCentral.Models;
using EPICCentralDL.Linq;

namespace EPICCentral.Controllers.Widgets
{
    public class AlertController : DataTablesController, IWidgetController
    {
        public const int MIN_SCANS = 10;

        public string Title
        {
            get { return ControllerRes.Widgets.Alert_Title; }
        }

        public ActionResult Load()
        {
            return View(this, GetAlerts());
        }

        private IQueryable<Alert> GetAlerts()
        {
            var locationsScansEmpty =
                new LinqMetaData().Location.WithPermissions()
                    .Where(
                        x => x.Devices
                                 .Any(y => y.ScansAvailable  == 0))
                    .ToList()
                    .Select(x => new Alert
                                     {
                                         Message =
                                             String.Format(ControllerRes.Widgets.Alert_ZeroScansRemaining, x.Name),
                                         Type = AlertType.Error
                                     });

            var locationsScansLow =
                new LinqMetaData().Location.WithPermissions()
                    .Where(
                        x => x.Devices
                                 .Any(y => y.ScansAvailable < MIN_SCANS && y.ScansAvailable > 0))
                    .ToList()
                    .Select(x => new Alert
                                     {
                                         Message =
                                             String.Format(ControllerRes.Widgets.Alert_ScansRemaining, x.Name, MIN_SCANS),
                                         Type = AlertType.Warning
                                     });

            return locationsScansEmpty.Concat(locationsScansLow).AsQueryable();
        }

        public void Render(ViewContext viewContext, System.IO.TextWriter writer)
        {
            var htmlHelper = new HtmlHelper<IQueryable<Alert>>(viewContext, this);
            var table = htmlHelper.DataTableFor(
                (IQueryable<Alert>) viewContext.ViewData.Model,
                new ColumnCollection<Alert>
                    {
                        {x => x.Message, "", x => "<div class='" + x.Type + "'>" + x.Message + "</div>", false},
                        {x => x.Type, null, null, true, null, false, null, false}
                    },
                defaultSort: new List<DataTablesRequestModel.Sort>
                                 {
                                     new DataTablesRequestModel.Sort
                                         {
                                             iSortCol = 1,
                                             sSortDir = "asc"
                                         }
                                 },
                defaultCount: -1,
                ajaxUrl: new UrlHelper(viewContext.RequestContext).Action("Query",
                                                                          "Alert"));

            writer.Write(table);
        }

        public ActionResult Query([ModelBinder(typeof(DataTablesRequestModelBinder))] DataTablesRequestModel dtRequestModel)
        {
            var result = View(this, GetAlerts());
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return Query(result, dtRequestModel);
        }

        private class Alert
        {
            public AlertType Type { get; set; }
            public string Message { get; set; }
        }

        private enum AlertType
        {
            Error = 0,
            Warning = 1,
            Notice = 2,
            Default = 3
        }
    }
}