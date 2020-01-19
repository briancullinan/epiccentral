using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using EPICCentral.Models;
using EPICCentral.Utilities.Attributes;
using EPICCentral.Utilities.Filters;
using EPICCentral.Utilities.Membership;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;

namespace EPICCentral.Controllers
{
    public class ConfigurationController : DataTablesController
    {
        /// <summary>
        /// Displays a few tables for direct editing of System settings and Rates.  Only available to Service Administrators
        /// </summary>
        /// <param name="dtRequestModel"></param>
        /// <returns></returns>
        [Allow(Roles = RoleUtils.SERVICE_ADMIN_NAME)]
        [ActionMenu(Rank = 1200, ResourceName = "ConfigurationIndex_Configuration")]
        public ActionResult Index([ModelBinder(typeof(DataTablesRequestModelBinder))] DataTablesRequestModel dtRequestModel)
        {
            var result = View();
            if (dtRequestModel != null)
                return Query(result, dtRequestModel);

            return View();
        }

        /// <summary>
        /// Editing of scan rates.
        /// </summary>
        /// <param name="scanRateId"></param>
        /// <returns></returns>
        [Allow(Roles = "Service Administrator")]
        public ActionResult EditRate(int? scanRateId)
        {
            var scanRate = new ScanRate(scanRateId);

			return (Request.IsAjaxRequest() || ControllerContext.IsChildAction)
                           ? (ActionResult)PartialView(scanRate)
                           : View(scanRate);
        }

        [HttpPost]
        [Allow(Roles = "Service Administrator")]
        public ActionResult EditRate(int? scanRateId, ScanRate model)
        {
            if(ModelState.IsValid)
            {
                ScanRateEntity scanRate = scanRateId.HasValue
                                              ? new ScanRateEntity(scanRateId.Value)
                                              : new ScanRateEntity();

                scanRate.ScanType = model.ScanType;
                scanRate.RatePerScan = model.RatePerScan;
                scanRate.MinCountForRate = model.MinCountForRate;
                scanRate.MaxCountForRate = model.MaxCountForRate;
                scanRate.EffectiveDate = model.EffectiveDate;
                scanRate.IsActive = model.IsActive;

                // save the scan rate
                scanRate.Save();
            }
            else
            {
                Response.StatusCode = 417;
                Response.TrySkipIisCustomErrors = true;
            }

            return (Request.IsAjaxRequest() || ControllerContext.IsChildAction)
                           ? (ActionResult)PartialView(model)
                           : View(model);
        }

        /// <summary>
        /// Editing of global epic central settings.
        /// TODO: Might want to put some settings from web.config in here.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Allow(Roles = "Service Administrator")]
        public ActionResult EditSetting(string name)
        {
            var setting = new EditSetting(name);

            return (Request.IsAjaxRequest() || ControllerContext.IsChildAction)
                           ? (ActionResult)PartialView(setting)
                           : View(setting);
        }

        [HttpPost]
        [Allow(Roles = "Service Administrator")]
        public ActionResult EditSetting(string name, EditSetting model)
        {
            if(ModelState.IsValid)
            {
                SystemSettingEntity setting = !string.IsNullOrEmpty(name)
                                                  ? new SystemSettingEntity(name)
                                                  : new SystemSettingEntity();

                setting.Name = model.Name;
                setting.Value = model.Value;

                setting.Save();
            }
            else
            {
                Response.StatusCode = 417;
                Response.TrySkipIisCustomErrors = true;
            }

            return (Request.IsAjaxRequest() || ControllerContext.IsChildAction)
                           ? (ActionResult)PartialView(model)
                           : View(model);
        }
    }
}