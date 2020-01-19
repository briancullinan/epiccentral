using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using EPICCentral.Models;
using EPICCentral.Utilities.Attributes;
using EPICCentral.Utilities.DataLayer;
using EPICCentral.Utilities.Filters;
using EPICCentral.Utilities.Membership;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;
using SharedRes;

namespace EPICCentral.Controllers
{
    /// <summary>
    /// Controls all Organization functionality.  An organization has multiple locations.  This is the top level entity in the system.
    /// </summary>
    [OrganizationMenu]
    public class OrganizationController : DataTablesController
	{
        /// <summary>
        /// Displays My Organization in the menu for users that are not the Service Administrator.
        /// Since multiple menu attributes are used in this controller, the My Organization item is merged with the rest of the menu items using base.GetSubMenu()
        /// </summary>
        private class OrganizationMenuAttribute : ControllerMenuAttribute
        {
            [ActionMenu(Path = "~/Organization/View", ResourceName = "MyOrganization", Rank = 199)]
            public override System.Collections.Generic.IEnumerable<ActionMenuAttribute> GetSubMenu()
            {
                if (!RoleUtils.IsUserServiceAdmin())
                    return
                        base.GetSubMenu().Concat(
                            MethodBase.GetCurrentMethod().GetCustomAttributes(typeof (ActionMenuAttribute), false).Cast
                                <ActionMenuAttribute>());
                return base.GetSubMenu();
            }
        }

        public ActionResult View(int? organizationId)
		{
			var user = Membership.GetUser().GetUserEntity();

			if (!organizationId.HasValue)
				return View(user.Organization);

            var organization = new OrganizationEntity(organizationId.Value);
            if (organization.IsNew)
                throw new HttpException(404, Error.NotFound_Organization);

            if(!Permissions.UserHasPermission("View", organization))
                throw new HttpException(401, Error.Unauthorized_Organization);

            return View(organization);
		}

		public ActionResult Edit(int? organizationId)
		{
			OrganizationEntity organization;

			var user = Membership.GetUser().GetUserEntity();

			if (!organizationId.HasValue)
				// When adding new organization, default to "active".
				organization = RoleUtils.IsUserServiceAdmin() ? new OrganizationEntity { IsActive = true } : user.Organization;
			else
			{
                organization = new OrganizationEntity(organizationId.Value);
                if (organization.IsNew)
                    throw new HttpException(404, Error.NotFound_Organization);

                if (!Permissions.UserHasPermission("Edit", organization))
                    throw new HttpException(401, Error.Unauthorized_Organization);
			}

			return (Request.IsAjaxRequest() || ControllerContext.IsChildAction)
						   ? (ActionResult)PartialView(organization)
						   : View(organization);
		}

		[HttpPost]
		public ActionResult Edit(int? organizationId, OrganizationEntity organizationModel)
		{
			OrganizationEntity organization;

			var user = Membership.GetUser().GetUserEntity();

			if (!organizationId.HasValue)
			{
				if (!RoleUtils.IsUserServiceAdmin())
                    throw new HttpException(401, Error.Unauthorized_OrganizationAdd);

				organization = new OrganizationEntity();
			}
			else
			{
				if (RoleUtils.IsUserServiceAdmin() ||
					(RoleUtils.IsUserOrgAdmin() && organizationId.Value == user.OrganizationId))
				{
					organization = new OrganizationEntity(organizationId.Value);
					if (organization.IsNew)
						throw new HttpException(404, Error.NotFound_Organization);
				}
				else
					throw new HttpException(401, Error.Unauthorized_OrganizationEdit);
			}

			if (ModelState.IsValid)
			{
				// Organization admin can edit name.
				organization.Name = organizationModel.Name;

				if (RoleUtils.IsUserServiceAdmin())
				{
					// Only service admin can change other properties.

					// NOTE! For now disallowing setting type to "Host". There can be only
					// one "Host".
					if (organizationModel.OrganizationType == OrganizationType.Host)
						throw new HttpException(401, Error.Unauthorized_OrganizationHost);

					organization.OrganizationType = organizationModel.OrganizationType;
					organization.IsActive = organizationModel.IsActive;

					if (!organizationId.HasValue)
						organization.UniqueIdentifier = OrganizationUtils.CreateUid();
				}

				organization.Save();
			}

			return (Request.IsAjaxRequest() || ControllerContext.IsChildAction)
					   ? (ActionResult)new EmptyResult()
					   : RedirectToAction("View");
		}

        /// <summary>
        /// Primary function of this controller is to list Organizations for the Service Administrator.
        /// </summary>
        /// <param name="dtRequestModel"></param>
        /// <returns></returns>
        [Allow(Roles = "Service Administrator")]
        [ActionMenu(Rank = 300, ResourceName = "OrganizationList_Organizations")]
        public ActionResult List([ModelBinder(typeof(DataTablesRequestModelBinder))] DataTablesRequestModel dtRequestModel)
		{
			ViewResult result = View(GetModel());
			if (dtRequestModel == null)
				return result;

			return Query(result, dtRequestModel);
		}

		private static IQueryable<OrganizationEntity> GetModel()
		{
			return new LinqMetaData().Organization.WithPermissions();
		}

        /// <summary>
        /// TODO: something interesting here.
        /// </summary>
        /// <returns></returns>
        public ActionResult Summary()
        {
            return View();
        }

        /// <summary>
        /// Returns a list of locations for an Organization for assigning users of an organization to locations.
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
		public JsonResult GetLocations(int? organizationId)
		{
			var locations = new LinqMetaData().Location.Where(l => l.OrganizationId == organizationId).ToDictionary(k => k.LocationId.ToString(CultureInfo.InvariantCulture), v => v.Name);
			return Json(locations, JsonRequestBehavior.AllowGet);
		}

        /// <summary>
        /// Gets a list of roles that are available to users within the specified organization, 
        ///   mostly just filters out making an organization the ServiceHost, which only one is allowed and that is EPIC Central
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
		public JsonResult GetRoles(int? organizationId)
		{
			return Json(OrganizationUtils.GetAllowedRoles(organizationId).ToDictionary(r => r.RoleId.ToString(CultureInfo.InvariantCulture), x => x.Name), JsonRequestBehavior.AllowGet);
		}
	}
}
