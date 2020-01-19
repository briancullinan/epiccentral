using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;

namespace EPICCentral.Controllers
{
    /// <summary>
    /// Controls event based updating from AJAX clients.  Checks the updates tables at the interval.
    /// </summary>
    public class UpdateController : Controller
    {
        /// <summary>
        /// TODO: Could be stored in Web.config?
        /// </summary>
        public const int UPDATE_INTERVAL = 5000;

        private static IEnumerable<UpdateStatusEntity> _updates;
        private static DateTime _lastRefresh;

        /// <summary>
        /// Updates the list cache for the process.
        /// </summary>
        private static void Update()
        {
            // refresh _updates from database
            _updates = new LinqMetaData().UpdateStatus.ToList();

            _lastRefresh = DateTime.UtcNow;
        }

        /// <summary>
        /// Primary function called by AJAX to check if an event has occurred since it's last check.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ActionResult CheckForUpdate(string request)
        {
            // parse out the request just like HttpContext.Request
            if (request == null)
                return new EmptyResult();

            // TODO: Move this functionality to be stored in session, rather than on the client,
            //   just use action/controller/last refresh time as the key to what has changed and what actions are bound
            var requestParams = GetRequestParams(Utilities.Crypto.Rijndael.Decrypt(request));

            // get the ticks and convert it to a date, this is stored on the client
            var date = requestParams.ContainsKey("ticks") ? long.Parse(requestParams["ticks"][0]) : _lastRefresh.Ticks;

            // if the current time is greater than the lastRefresh + UPDATE_INTERVAL 
            //   then refresh the global static dictionary of events for the entire process
            if (_lastRefresh.AddMilliseconds(UPDATE_INTERVAL) < DateTime.UtcNow)
                Update();

            // BIG IF: loop through the request and select the updates that have occurred
            var updates = requestParams.Where(x =>
                // make sure the controller is a valid type
                Type.GetType("EPICCentral.Controllers." + x.Key + "Controller", false, true) != null &&
                // select the updates that intersect with the global list
                _updates.Any(y => x.Key == y.Controller && x.Value.Contains(y.Action) && 
                // only select updates that happened after the client loaded
                y.UpdateTime.Ticks > date));

            requestParams["ticks"] = new List<string>{_lastRefresh.Ticks.ToString()};

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            return Json(
                new
                {
                    request = Utilities.Crypto.Rijndael.Encrypt(String
                        .Join("&", requestParams
                        .Select(x => x.Key + '=' + HttpUtility.UrlEncode(String.Join(",", x.Value))))),
                    updates = updates.Select(x => new { Controller = x.Key, Actions = String.Join(",", x.Value) })
                },
                JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Parses the list of actions the AJAX client is listening for.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Dictionary<string, List<string>> GetRequestParams(string request)
        {
            return request.Split('&')
                .ToDictionary(x => x.Split('=')[0], x =>
                {
                    var split = x.Split('=');
                    if (split.Length > 1)
                        return split[1].Split(',').Select(y => y.Trim()).ToList();
                    return new List<string>();
                });
        }
    }

    /// <summary>
    /// A structure for storing the list of controllers and actions.
    /// </summary>
    public class UpdatesModel : Dictionary<string, Dictionary<string, string>>
    {
        public UpdatesModel(Dictionary<string, Dictionary<string, string>> updates)
            : base(updates)
        {
            
        }

        public string Request
        {
            get
            {
                // create a string link ticks=DateTime.UtcNow.Ticks&User=Edit,Add&Operations=Change&Devices=Edit
                var requestParams = "ticks=" + DateTime.UtcNow.Ticks;
                foreach (var controller in this)
                {
                    requestParams += '&' + controller.Key + '=' +
                                     HttpUtility.UrlEncode(String.Join(",", controller.Value.Keys));
                }

                return Utilities.Crypto.Rijndael.Encrypt(requestParams);

            }
        }
    }
}