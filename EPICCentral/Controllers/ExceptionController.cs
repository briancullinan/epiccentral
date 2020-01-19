using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using EPICCentral.Models;
using EPICCentral.Utilities.Attributes;
using EPICCentral.Utilities.Filters;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;

namespace EPICCentral.Controllers
{
    /// <summary>
    /// Controls displaying exceptions uploaded from ClearView clients, or exceptions that occur on EPIC Central.
    /// TODO: Create a new controller for EPIC Central diagnostics and logging?
    /// </summary>
    public class ExceptionController : DataTablesController
    {
        [Allow(Roles = "Service Administrator")]
        [ActionMenu(Rank = 1300, ResourceName = "ExceptionList_Exceptions")]
        public ActionResult List([ModelBinder(typeof(DataTablesRequestModelBinder))] DataTablesRequestModel dtRequestModel)
        {
            ViewResult result = View(new LinqMetaData().ExceptionLog);
			if (dtRequestModel == null)
				return result;

			return Query(result, dtRequestModel);
        }

        [Allow(Roles = "Service Administrator")]
        public ActionResult View(long exceptionLogId)
        {
            var exception = new ExceptionLogEntity(exceptionLogId);
            if(exception.IsNew)
                throw new HttpException(404, SharedRes.Error.NotFound_Exception);

            return PartialView(exception);
        }
    }
}