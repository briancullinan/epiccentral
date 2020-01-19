using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using ControllerRes;
using EPICCentral.Utilities.Attributes;
using EPICCentral.Utilities.Filters;
using EPICCentral.Utilities.Google;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;

namespace EPICCentral.Controllers
{
    /// <summary>
    /// Displays a Google map of events that occur within the ClearView system.
    /// </summary>
    public class OperationController : Controller
    {
        //
        // GET: /Operations/
        [Allow(Roles = "Service Administrator")]
        [ActionMenu(Rank = 1100, ResourceName = "OperationsIndex_Operations")]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Primary callback and logic for what to display on the Google map.
        /// </summary>
        /// <returns></returns>
        [Allow(Roles = "Service Administrator")]
        public ActionResult GetData()
        {
            // create list of markers
            var markers = new LinqMetaData().Location
                .Where(x => x.Latitude != null && x.Longitude != null)
                .ToList().Select(x =>
                                     {
                                         var icon = GetLocationIcon(x);
                                         return new Marker
                                                    {
                                                        Latitude = x.Latitude.Value,
                                                        Longitude = x.Longitude.Value,
                                                        Icon = icon,
                                                        Content =
                                                            String.Format(Operation.LocationLabel, x.Name) + "<br /><table>" +
                                                            string.Join("</tr><tr>",
                                                                        x.Devices.Select(
                                                                            y =>
                                                                            "<td>" + y.SerialNumber +
                                                                            "</td><td>" + y.DeviceState +
                                                                            "</td><td>" + y.CurrentStatus +
                                                                            "</td>")) + "<table>",
                                                        ZIndex = icon.Contains("CCCC00") ? 1 : 3,
                                                        Title = x.Name,
                                                        MinZoom = 3,
                                                        MaxZoom = 17
                                                    };
                                     })
                .Concat(new LinqMetaData().Organization
                .Where(o => o.Locations.Any())
                .ToList().Select(x =>
                                     {
                                         var locations = x.Locations
                                             .Where(l => l.Latitude != null && l.Longitude != null)
                                             .Select(l => new LatLng(l.Latitude.Value, l.Longitude.Value));
                                         var point = GoogleMaps.GetAverage(locations);
                                         var icon = GetOrganizationIcon(x);
                                            return new Marker
                                                    {
                                                        Latitude = point.Latitude,
                                                        Longitude = point.Longitude,
                                                        Icon = icon,
                                                        Content =
                                                            String.Format(Operation.OrganizationLabel, x.Name) + "<br /><table>" +
                                                            string.Join("</tr><tr>",
                                                                        x.Locations.SelectMany(l => l.Devices.Select(
                                                                            y =>
                                                                            (locations.Count() > 1 ? ("<td>" + l.Name + "</td>") : "") +
                                                                            "<td>" + y.SerialNumber +
                                                                            "</td><td>" + y.DeviceState +
                                                                            "</td><td>" + y.CurrentStatus +
                                                                            "</td>"))) + "<table>",
                                                        ZIndex = icon.Contains("996633") ? 0 : 2,
                                                        Title = x.Name,
                                                        MinZoom = 0,
                                                        MaxZoom = 17,
                                                        Locations = locations
                                                    };
                                     }));


            UserSettingEntity todaySetting = null;
            try
            {
                // get the time the daily count was updated
                var timeSetting = Membership.GetUser().GetUserEntity().Settings.FirstOrDefault(x => x.Name == "SupportInboxUpdated");
                DateTime result;
                if(timeSetting != null && 
                    // try to parse the time caches in the user settings
                    DateTime.TryParse(timeSetting.Value, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out result) &&
                    // make sure the count was updated today
                    result.Date == DateTime.UtcNow.Date)
                    // get the daily count for today caches in user settings
                    todaySetting = Membership.GetUser().GetUserEntity().Settings.FirstOrDefault(x => x.Name == "SupportInboxToday");
            }
            catch { }
            var daily = new[]
                            {
                                new
                                    {
                                        Icon = "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|6666CC|000000",
                                        Text = Operation.ScansPerformed,
                                        Count = new LinqMetaData().DeviceEvent.Count(x => x.ReceivedTime > DateTime.UtcNow.Date && x.EventType == EventType.ScanBegin).ToString()
                                    },
                                new
                                    {
                                        Icon = "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|00CC00|000000",
                                        Text = Operation.PurchasesMade,
                                        Count = String.Format("{0:C}", new LinqMetaData().PurchaseHistory.Where(x => x.PurchaseTime > DateTime.UtcNow.Date).Sum(x => x.AmountPaid))
                                    },
                                new
                                    {
                                        Icon = "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|CCCC00|000000",
                                        Text = Operation.DevicesActive,
                                        Count = new LinqMetaData().DeviceEvent.Where(x => x.ReceivedTime > DateTime.UtcNow.Date && x.EventType == EventType.Ping).DistinctBy(x => x.DeviceId).Count().ToString()
                                    },
                                new
                                    {
                                        Icon = "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|CC0000|000000",
                                        Text = Operation.ExceptionsReceived,
                                        Count = new LinqMetaData().ExceptionLog.Count(x => x.ReceivedTime > DateTime.UtcNow.Date).ToString()
                                    },
                                new
                                    {
                                        Icon = "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|CC00CC|000000",
                                        Text = Operation.UsersOnline,
                                        Count = Membership.GetNumberOfUsersOnline().ToString()
                                    },
                                new
                                    {
                                        Icon = "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|CC9900|000000",
                                        Text = Operation.SupportRequests,
                                        Count = todaySetting != null ? todaySetting.Value : "0"
                                    }
                            };
            var system = new[]
                            {
                                new
                                    {
                                        Icon = "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|6666CC|000000",
                                        Text = Operation.TotalScans,
                                        Arrow = new LinqMetaData().DeviceEvent.Any(x => x.EventType == EventType.ScanBegin && 
                                            x.EventTime > DateTime.UtcNow.AddMilliseconds(-UpdateController.UPDATE_INTERVAL * 2))
                                            ? Url.Content("~/Content/GreenUp.gif")
                                            : Url.Content("~/Content/spacer.gif"),
                                        Count = new LinqMetaData().DeviceEvent.Count(x => x.EventType == EventType.ScanBegin).ToString(CultureInfo.InvariantCulture)
                                    },
                                new
                                    {
                                        Icon = "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|00CC00|000000",
                                        Text = Operation.TotalPurchases,
                                        Arrow = new LinqMetaData().PurchaseHistory.Any(x => x.PurchaseTime > DateTime.UtcNow.AddMilliseconds(-UpdateController.UPDATE_INTERVAL * 2))
                                            ? Url.Content("~/Content/GreenUp.gif")
                                            : Url.Content("~/Content/spacer.gif"),
                                        Count = String.Format("{0:C}", new LinqMetaData().PurchaseHistory.Sum(x => x.AmountPaid))
                                    },
                                new
                                    {
                                        Icon = "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|CCCC00|000000",
                                        Text = Operation.TotalDevices,
                                        Arrow = new LinqMetaData().Device.Any(x => x.DateIssued > DateTime.UtcNow.AddMilliseconds(-UpdateController.UPDATE_INTERVAL * 2)) 
                                            ? Url.Content("~/Content/GreenUp.gif")
                                            : Url.Content("~/Content/spacer.gif"),
                                        Count = new LinqMetaData().Device.Count().ToString(CultureInfo.InvariantCulture)
                                    },
                                new
                                    {
                                        Icon = "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|CC0000|000000",
                                        Text = Operation.TotalExceptions,
                                        Arrow = new LinqMetaData().ExceptionLog.Any(x => x.ReceivedTime > DateTime.UtcNow.AddMilliseconds(-UpdateController.UPDATE_INTERVAL * 2))
                                            ? Url.Content("~/Content/GreenUp.gif")
                                            : Url.Content("~/Content/spacer.gif"),
                                        Count = new LinqMetaData().ExceptionLog.Count().ToString(CultureInfo.InvariantCulture)
                                    },
                                new
                                    {
                                        Icon = "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|CC00CC|000000",
                                        Text = Operation.TotalUsers,
                                        Arrow = new LinqMetaData().User.Any(x => x.CreateTime > DateTime.UtcNow.AddMilliseconds(-UpdateController.UPDATE_INTERVAL * 2))
                                            ? Url.Content("~/Content/GreenUp.gif")
                                            : Url.Content("~/Content/spacer.gif"),
                                        Count = new LinqMetaData().User.Count().ToString(CultureInfo.InvariantCulture)
                                    },
                                new
                                    {
                                        Icon = "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|996633|000000",
                                        Text = Operation.TotalOrganizations,
                                        Arrow = Url.Content("~/Content/spacer.gif"), // TODO: something interesting here
                                        Count = new LinqMetaData().Organization.Count().ToString(CultureInfo.InvariantCulture)
                                    }
                            };

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return Json(new { markers, daily, system }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Returns the icon for an organization based on a few conditions.
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
        private string GetOrganizationIcon(OrganizationEntity organization)
        {
            if(organization.Users.Any(x => x.LastLoginTime > DateTime.UtcNow.AddMilliseconds(-UpdateController.UPDATE_INTERVAL * 2)))
                // purple user activity
                return "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|CC00CC|000000";

            // brown
            return "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|996633|000000";
        }

        /// <summary>
        /// Returns icon for locations based on conditions such as what event occurred in the last few seconds that should be reflected on the map.
        /// Conditions are in order of precedence as only 1 icon can be displayed for each location and a location may have multiple devices.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        private string GetLocationIcon(LocationEntity location)
        {

            if (
                location.PurchaseHistories.Any(
                    x => x.PurchaseTime > DateTime.UtcNow.AddMilliseconds(-UpdateController.UPDATE_INTERVAL * 2)))
                // green
                return "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|00CC00|000000";

            if (
                location.Devices.Any(
                    x =>
                    x.ExceptionLogs.Any(
                        y => y.ReceivedTime > DateTime.UtcNow.AddMilliseconds(-UpdateController.UPDATE_INTERVAL * 2))))
                // red
                return "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|CC0000|000000";

            // check for recent events
            if (location.Devices.Any(y => y.LastReportTime > DateTime.UtcNow.AddMilliseconds(-UpdateController.UPDATE_INTERVAL * 2) && 
                (y.CurrentStatus == EventType.ScanBegin.ToString() || y.CurrentStatus == EventType.ScanEnd.ToString())))
                // blue
                return "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|6666CC|000000";

            if (location.Devices.Any(y => y.LastReportTime > DateTime.UtcNow.AddMilliseconds(-UpdateController.UPDATE_INTERVAL * 2) &&
                (y.CurrentStatus == EventType.ApplicationBegin.ToString() || y.CurrentStatus == EventType.ApplicationEnd.ToString())))
                // light blue
                return "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|9999EE|000000";

            if (location.Devices.Any(y => y.LastReportTime > DateTime.UtcNow.AddMilliseconds(-UpdateController.UPDATE_INTERVAL * 2) && 
                (y.CurrentStatus == EventType.CalibrationBegin.ToString() || y.CurrentStatus == EventType.CalibrationEnd.ToString())))
                // lighter blue
                return "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|BBBBFF|000000";

            // yellow, ping
            return "http://chart.apis.google.com/chart?chst=d_map_pin_letter&chld=%E2%80%A2|CCCC00|000000";
        }

        /// <summary>
        /// Forces the operations page to refresh its data.  This function is called in various places by REST services and other controllers.
        /// </summary>
        public static void Update()
        {
            new UpdateStatusEntity("Operation", "Change") { Controller = "Operation", Action = "Change", Method = "POST", UpdateTime = DateTime.UtcNow }.Save();
        }

        /// <summary>
        /// The container function for the call above, this triggers the Updates tables to be changed by the ActionLog filter.
        /// </summary>
        /// <returns></returns>
        public ActionResult Change()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            // force clients to update the operations view
            return new EmptyResult();
        }
    }
}
