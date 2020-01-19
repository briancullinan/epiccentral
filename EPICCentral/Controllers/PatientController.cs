using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using EPICCentral.Models;
using System.Linq;
using EPICCentral.Utilities.Attributes;
using EPICCentral.Utilities.Filters;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentral.Controllers
{
    /// <summary>
    /// Lists patients uploaded from ClearView.
    /// </summary>
    public class PatientController : DataTablesController
    {
        //
        // GET: /Subject/
        [HttpGet]
        [Allow(Users = "*")]
        [ActionMenu(Rank = 700, ResourceName = "PatientSearch_Patients")]
        public ActionResult Index([ModelBinder(typeof(DataTablesRequestModelBinder))] DataTablesRequestModel dtRequestModel)
        {
            ViewResult result = View(new LinqMetaData().Patient.WithPermissions());

            if (dtRequestModel == null)
                return result;

            return Query(result, dtRequestModel);
        }

        [HttpGet]
        public ActionResult View(int patientId)
        {
            var patient = new PatientEntity(patientId);
            if(patient.IsNew)
                throw new HttpException(404, SharedRes.Error.NotFound_Patient);

            if(!Permissions.UserHasPermission("View", patient))
                throw new HttpException(401, SharedRes.Error.Unauthorized_Patient);

            return PartialView(patient);
        }
    }
}
