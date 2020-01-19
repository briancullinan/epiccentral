using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using ControllerRes;
using EPICCentral.Models;
using EPICCentral.Utilities.Attributes;
using EPICCentral.Utilities.DataLayer;
using EPICCentral.Utilities.Filters;
using EPICCentral.Utilities.Membership;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using EPICCentralDL.Linq;
using log4net;

namespace EPICCentral.Controllers
{
	/// <summary>
	/// Manages device states and organization of devices.
	/// </summary>
	public class DeviceController : DataTablesController
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(DeviceController));

		/// <summary>
		/// Primary functionality is to list the available devices for a user.
		/// </summary>
		/// <param name="dtRequestModel"></param>
		/// <returns></returns>
		[Allow(Users = "*")]
		[ActionMenu(Rank = 900, ResourceName = "DeviceList_Devices")]
		public ActionResult List([ModelBinder(typeof(DataTablesRequestModelBinder))] DataTablesRequestModel dtRequestModel)
		{
			ViewResult result = View(new LinqMetaData().Device.WithPermissions());
			if (dtRequestModel == null)
				return result;

			return Query(result, dtRequestModel);
		}

		[Allow(Roles = "Service Administrator")]
		public ActionResult Edit(int? deviceId)
		{
			return PartialView(new DeviceModel(deviceId));
		}

		[HttpPost]
		[Allow(Roles = "Service Administrator")]
		public ActionResult Edit(int? deviceId, DeviceModel model)
		{
			if (ModelState.IsValid)
			{
				DeviceEntity device = deviceId.HasValue ? new DeviceEntity(deviceId.Value) : new DeviceEntity();
				device.LocationId = model.LocationId;
				device.SerialNumber = model.SerialNumber;
				device.RevisionLevel = model.RevisionLevel;
				device.DeviceState = model.DeviceState;

				if (!deviceId.HasValue)
				{
					device.UniqueIdentifier = DeviceUtils.CreateUid();
					device.DateIssued = DateTime.UtcNow;
					device.DeviceState = DeviceState.New;
				}

				// if the scans available has changed, create a record of it with the notes.
				//   Notes are required if changing the scans available.
				if (device.IsNew || device.ScansAvailable != model.ScansAvailable)
				{
					device.ScansAvailable = model.ScansAvailable;

					var history = device.PurchaseHistories.AddNew();
					history.LocationId = model.LocationId;
					history.UserId = Membership.GetUser().GetUserEntity().UserId;
					history.PurchaseTime = DateTime.UtcNow;
					history.ScansPurchased = model.ScansAvailable - device.ScansAvailable;
					history.AmountPaid = 0;
					history.TransactionId = string.Empty;
					history.PurchaseNotes = model.PurchaseNotes;
				}

				device.Save(true);

				return new EmptyResult();
			}

			Response.StatusCode = 417;
			Response.TrySkipIisCustomErrors = true;

			return PartialView(new DeviceModel(deviceId));
		}

		[Allow(Users = "*")]
		public ActionResult View(int deviceId)
		{
			var device = new DeviceEntity(deviceId);
			if (device.IsNew)
				throw new HttpException(404, SharedRes.Error.NotFound_Device);

			if (!Permissions.UserHasPermission("View", device))
				throw new HttpException(401, SharedRes.Error.Unauthorized_Device);

			return PartialView(new DeviceModel(deviceId));
		}

		/// <summary>
		/// Returns a list of available locations the device can be assigned to.
		/// </summary>
		/// <param name="organizationId"></param>
		/// <returns></returns>
		[Allow(Roles = "Service Administrator")]
		public JsonResult GetLocations(int organizationId)
		{
			OrganizationEntity organization = new OrganizationEntity(organizationId);
			List<Location> locations = organization.Locations.Select(location => new Location { Id = location.LocationId, Name = location.Name }).ToList();
			return Json(locations, JsonRequestBehavior.AllowGet);
		}

		/// <summary>
		/// Used above to send the available locations to the client.
		/// </summary>
		private class Location
		{
			public int Id { get; set; }
			public string Name { get; set; }
		}
	}
}
