using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Security;
using System.Web.SessionState;
using EPICCentral.Models;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;

namespace EPICCentral.Controllers.Widgets
{
    public class RecentActivityController : DataTablesController, IWidgetController
    {
        public class RecentActivityModel
        {
            public string Type { get; set; }
            public DateTime EventTime { get; set; }
            public string Description { get; set; }
            public string Link { get; set; }
        }
        //
        // GET: /Synchronization/
        public ActionResult Load()
        {
            return View(this, GetEntities());
        }

        private IQueryable<RecentActivityModel> GetEntities()
        {
            var result = new List<RecentActivityModel>();

            // load the newest entities
            result.AddRange(GetServiceEntities());

            result.AddRange(GetOrganizationEntities());

            result.AddRange(GetUserEntities());

            return result.AsQueryable();
        }

        public string Title
        {
            get { return ControllerRes.Widgets.RecentActivity_Title; }
        }

        public void Render(ViewContext viewContext, System.IO.TextWriter writer)
        {
            var htmlHelper = new HtmlHelper<IQueryable<RecentActivityModel>>(viewContext, this);
            var table = htmlHelper.DataTableFor(
                (IQueryable<RecentActivityModel>) viewContext.ViewData.Model,
                new ColumnCollection<RecentActivityModel>
                    {
                        {x => x.Type, ControllerRes.Widgets.RecentActivity_Type},
                        {
                            x => x.EventTime, ControllerRes.Widgets.RecentActivity_EventTime,
                            x => TimeZoneInfo.ConvertTime(x.EventTime, TimeZoneInfo.Utc,
                                                          (TimeZoneInfo) HttpContext.Items["TimeZoneInfo"]).ToString(
                                                              CultureInfo.CurrentCulture)
                            },
                        {x => x.Description, ControllerRes.Widgets.RecentActivity_Description},
                        {"Link", "", null, false}
                    },
                defaultCount: 10,
                defaultSort: new List<DataTablesRequestModel.Sort>
                                 {
                                     new DataTablesRequestModel.Sort
                                         {
                                             iSortCol = 1,
                                             sSortDir = "desc"
                                         }
                                 },
                ajaxUrl: new UrlHelper(viewContext.RequestContext).Action("Query",
                                                                          "RecentActivity"));

            writer.Write(table);
        }

        private IEnumerable<RecentActivityModel> GetServiceEntities()
        {
            if (Roles.IsUserInRole("Service Administrator"))
            {
                IQueryable<ExceptionLogEntity> exceptions = new LinqMetaData().ExceptionLog;
                return exceptions.OrderByDescending(x => x.ReceivedTime).Take(5).ToList().Select(
                        x => new RecentActivityModel
                                 {
                                     Type = ControllerRes.Widgets.RecentActivity_Exception,
                                     EventTime = x.ReceivedTime,
                                     Description = x.Title.Substring(0, Math.Min(x.Title.Length, 100)),
                                     Link = String.Format("<a href='{0}#%2523Exceptions_filter=ExceptionLogId%253A{2}&%2523Exceptions_dialog7=/Exception/View%253FExceptionLogId%253D{2}'>{1}</a>",
                                                       Url.Action("List", "Exception"),
                                                       ControllerRes.Widgets.RecentActivity_ViewException,
                                                       x.ExceptionLogId)
                                 });
            }
            return new List<RecentActivityModel>();
        }

        private IEnumerable<RecentActivityModel> GetOrganizationEntities()
        {
            if(Roles.IsUserInRole("Service Administrator") || Roles.IsUserInRole("Organization Administrator"))
            {
                var result = new LinqMetaData().User.WithPermissions().OrderByDescending(x => x.CreateTime).Take(5).
                    ToList().Select(
                        x => new RecentActivityModel
                                 {
                                     Type = ControllerRes.Widgets.RecentActivity_UserCreated,
                                     EventTime = x.CreateTime,
                                     Description = SharedRes.Formats.User.FormatWith(x) + " (" + x.EmailAddress + ")",
                                     Link =
                                         String.Format("<a href='{0}'>{1}</a>",
                                                       Url.Action("List", "User",
                                                                  new
                                                                      {
                                                                          search = String.Format(
                                                                              "FirstName:{0} LastName:{1} EmailAddress:{2}", x.FirstName, x.LastName, x.EmailAddress)
                                                                      }, null),
                                                       ControllerRes.Widgets.RecentActivity_ViewUser)
                                 });
                return result;
            }
            return new List<RecentActivityModel>();
        }

        private IEnumerable<RecentActivityModel> GetUserEntities()
        {
            var result = new LinqMetaData().Patient.WithPermissions().OrderByDescending(x => x.ReceivedTime).Take(5).ToList().Select(
                    x => new RecentActivityModel
                             {
                                 Type = ControllerRes.Widgets.RecentActivity_PatientCreated,
                                 EventTime = x.ReceivedTime,
                                 Description = x.FirstName + " " + x.LastName,
                                 Link = String.Format("<a href='{0}#%2523Patients_filter=PatientId%253A{2}&%2523Patients_dialog5=/Patient/View%253FpatientId%253D{2}'>{1}</a>",
                                                   Url.Action("Index", "Patient"),
                                                   ControllerRes.Widgets.RecentActivityController_ViewPatient,
                                                   x.PatientId)
                             });
            result = result.Concat(new LinqMetaData().Treatment.WithPermissions().OrderByDescending(x => x.ReceivedTime).Take(5).ToList().Select(
                    x => new RecentActivityModel
                             {
                                 Type = ControllerRes.Widgets.RecentActivity_Treatment,
                                 EventTime = x.ReceivedTime,
                                 Description = x.Patient.FirstName + " " + x.Patient.LastName,
                                 Link = String.Format("<a href='{0}'>{1}</a>",
                                                      Url.Action("View", "Treatment", new {x.TreatmentId, page = "Summary"}),
                                                      ControllerRes.Widgets.RecentActivity_ViewTreatment)
                             })
                );

            return result;
        }

        public ActionResult Query([ModelBinder(typeof(DataTablesRequestModelBinder))] DataTablesRequestModel dtRequestModel)
        {
            var result = View(this, GetEntities());
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return Query(result, dtRequestModel);
        }
    }
}
