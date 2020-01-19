using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using ControllerRes;
using EPICCentral.Models;
using EPICCentral.Utilities.Attributes;
using EPICCentral.Utilities.Virtual;
using EPICCentralDL.EntityClasses;

namespace EPICCentral.Controllers
{
    /// <summary>
    /// Filters and selects the menu for the current user.
    /// </summary>
    public class MenuController : Controller
    {
        /// <summary>
        /// Most menu functionality is contained in the ActionMenuAttribute, this just selects and sorts the menu items.
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult ListMenu()
        {

            var menu = ActionMenuAttribute.Menus
                .Where(x => x.IsAuthorized && x.Visible)
                .Distinct(new ActionMenuAttribute())
                .OrderBy(x => x.Text)
                .OrderBy(x => x.Rank);

            return PartialView("_MainMenuPartial", menu);
        }
    }
}
