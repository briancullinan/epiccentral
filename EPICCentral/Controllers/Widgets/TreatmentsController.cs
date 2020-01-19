using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using EPICCentralDL.Linq;

namespace EPICCentral.Controllers.Widgets
{
    public class TreatmentsController : WidgetController
	{
        public class TreatmentsModel
        {
            public int Year { get; set; }
        }

        public override string Title
        {
            get { return ControllerRes.Widgets.Treatments_Title; }
        }

        public override ActionResult Load()
        {
            return PartialView(new TreatmentsModel{Year = DateTime.Now.Year});
        }

        public ActionResult Data(int year)
        {
            int validYear = DateTime.Now.Year;
            try
            {
                validYear = new DateTime(year, 1, 1).Year;
            }
            catch
            {
                
            }
            var months = new[]
                             {
                                 SharedRes.General.Month_Jan,
                                 SharedRes.General.Month_Feb,
                                 SharedRes.General.Month_Mar,
                                 SharedRes.General.Month_Apr,
                                 SharedRes.General.Month_May,
                                 SharedRes.General.Month_Jun,
                                 SharedRes.General.Month_Jul,
                                 SharedRes.General.Month_Aug,
                                 SharedRes.General.Month_Sep,
                                 SharedRes.General.Month_Oct,
                                 SharedRes.General.Month_Nov,
                                 SharedRes.General.Month_Dec
                             };

            var treatments = new List<object>();
            for (var i = 1; i <= 12; i++)
            {
                var before = new DateTime(validYear, i, 1);
                DateTime after;
                if(i == 12)
                    after = new DateTime(validYear + 1, 1, 1);
                else
                    after = new DateTime(validYear, i + 1, 1);
                var count = new LinqMetaData().Treatment.Count(x => x.TreatmentTime >= before && x.TreatmentTime < after);
                treatments.Add(new object[] {months[i - 1], count});
            }
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return Json(new
                            {
                                label = validYear == DateTime.Now.Year
                                    ? ControllerRes.Widgets.Treatments_TreatmentsThisYear 
                                    : (validYear == DateTime.Now.Year - 1
                                        ? ControllerRes.Widgets.Treatments_TreatmentsLastYear
                                        : String.Format(ControllerRes.Widgets.Treatments_TreatmentsInYear, validYear)),
                                data = treatments
                            }, JsonRequestBehavior.AllowGet);
        }

	}
}