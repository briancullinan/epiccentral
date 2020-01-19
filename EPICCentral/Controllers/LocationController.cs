using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using EPICCentral.Models;
using EPICCentral.Utilities.Attributes;
using EPICCentral.Utilities.DataLayer;
using EPICCentral.Utilities.Filters;
using EPICCentral.Utilities.Google;
using EPICCentral.Utilities.Membership;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;

namespace EPICCentral.Controllers
{
    /// <summary>
    /// Controls all location configuration.  An organization has locations associated with it.  A location contains 1 or many devices.
    /// </summary>
    public class LocationController : DataTablesController
	{
        [Allow(Roles = "Service Administrator,Organization Administrator")]
        public ActionResult Edit(int? locationId, int? organizationId)
		{
			return PartialView(new NewLocationModel(GetLocation(locationId, organizationId)));
		}

		[HttpPost]
        [Allow(Roles = "Service Administrator,Organization Administrator")]
        public ActionResult Edit(int? locationId, int? organizationId, NewLocationModel locationModel)
		{
			var location = GetLocation(locationId, organizationId);

			if (ModelState.IsValid)
			{
				// Google limits number of lookups per day. No reason to waste them.
				bool needGeocode = location.IsNew ||
				                   locationModel.AddressLine1 != location.AddressLine1 ||
				                   (locationModel.AddressLine2 ?? "") != location.AddressLine2 ||
				                   locationModel.City != location.City ||
				                   locationModel.State != location.State ||
				                   locationModel.Country != location.Country;

				// Admin can edit geocode if the lookup fails.
				if (!needGeocode && RoleUtils.IsUserServiceAdmin())
				{
					// If they aren't set by admin, then lookup, ... or retry.
					if ((!locationModel.Latitude.HasValue || locationModel.Latitude == 0) &&
								(!locationModel.Longitude.HasValue || locationModel.Longitude == 0))
						needGeocode = true;
					else
					{
						// Admin set them manually. So use the edited values, ... or
						// the same unedited values as before.
						location.Latitude = locationModel.Latitude;
						location.Longitude = locationModel.Longitude;
					}
				}

				// this is already set at this point by GetLocation() location.OrganizationId = locationModel.OrganizationId;
				location.Name = locationModel.Name;
				location.AddressLine1 = locationModel.AddressLine1;
				location.AddressLine2 = locationModel.AddressLine2;
				location.City = locationModel.City;
				location.State = locationModel.State;
				location.Country = locationModel.Country;
				location.PostalCode = locationModel.PostalCode;
				location.PhoneNumber = locationModel.PhoneNumber;

				if (needGeocode)
				{
					if (GoogleMaps.GetGeocode(location) == null && RoleUtils.IsUserServiceAdmin())
					{
						location.Latitude = locationModel.Latitude;
						location.Longitude = locationModel.Longitude;
					}
				}

				if (RoleUtils.IsUserServiceAdmin())
					location.IsActive = locationModel.IsActive;

				if (location.IsNew)
					location.UniqueIdentifier = LocationUtils.CreateUid();

				location.Save();
                return new EmptyResult();
            }
			else
			{
                Response.StatusCode = 417;
                Response.TrySkipIisCustomErrors = true;
            }

		    return PartialView(locationModel);
		}

		public ActionResult View(int locationId)
		{
			var location = new LocationEntity(locationId);
			if (location.IsNew)
				throw new HttpException(404, SharedRes.Error.NotFound_Location);

			if (!Permissions.UserHasPermission("View", location))
				throw new HttpException(401, SharedRes.Error.Unauthorized_Location);

			return PartialView(location);
		}

        [ActionMenu(Rank = 400, ResourceName = "LocationList_Locations")]
        public ActionResult List(int? organizationId, [ModelBinder(typeof(DataTablesRequestModelBinder))] DataTablesRequestModel dtRequestModel)
		{
			ViewResult result = View(GetModel(organizationId));
			if (dtRequestModel == null)
				return result;

			return Query(result, dtRequestModel);
		}

        /// <summary>
        /// Retrieves the Geocode for an address to fill in the Latitude and Longitude fields.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
		public JsonResult Geocode(string address)
		{
			Dictionary<string, string> response = new Dictionary<string, string>();
			decimal[] geocode = GoogleMaps.GetGeocode(address);
			if (geocode != null)
			{
				response.Add("status", "success");
				response.Add("lat", geocode[0].ToString(CultureInfo.InvariantCulture));
				response.Add("lng", geocode[1].ToString(CultureInfo.InvariantCulture));
			}
			else
				response.Add("status", "failed");

			return Json(response, JsonRequestBehavior.AllowGet);
		}

        /// <summary>
        /// Primary location listing function, WithPermissions is used and the code for the filtering is left in to make sure WithPermissions is showing the correct locations.
        /// </summary>
        /// <param name="organizationId"></param>
        /// <returns></returns>
		private IQueryable<LocationEntity> GetModel(int? organizationId)
		{
			var locations = (IQueryable<LocationEntity>)new LinqMetaData().Location;

            /*
			if (!organizationId.HasValue)
                // For other users, use the user's organization ID.
                organizationId = Membership.GetUser().GetUserEntity().OrganizationId;

		    var organization = new OrganizationEntity(organizationId.Value);
            if(organization.IsNew)
                throw new HttpException(404, SharedRes.Error.NotFound_Organization);
            ViewData.Add("organization", organization);

            if(!Permissions.UserHasPermission("View", organization))
                throw new HttpException(401, SharedRes.Error.Unauthorized_Organization);

            if (RoleUtils.IsUserServiceAdmin())
            {
                return new LinqMetaData().Location.Where(l => l.OrganizationId == organizationId.Value);
            }
            */

		    return locations.WithPermissions();
		}

        /// <summary>
        /// Called by the Edit function this performs all of the proper permissions checks.
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="organizationId"></param>
        /// <returns>The LocationEntity for the specified locationId or a new entity if locationId is not specified and the current user has permission to add locations.</returns>
		private static LocationEntity GetLocation(int? locationId, int? organizationId)
		{
			LocationEntity location;

			if (locationId.HasValue)
			{
				location = new LocationEntity(locationId.Value);
				if (location.IsNew)
					throw new HttpException(404, SharedRes.Error.NotFound_Location);

				if (!Permissions.UserHasPermission("Edit", location))
					throw new HttpException(401, SharedRes.Error.Unauthorized_Location);
			}
			else
			{
			    location = new LocationEntity
			                   {
			                       IsActive = true, 
                                   OrganizationId = Membership.GetUser().GetUserId().OrganizationId
			                   };
			    if (RoleUtils.IsUserServiceAdmin())
                {
                    if (organizationId.HasValue)
                        location.OrganizationId = organizationId.Value;
                }
                else if (!RoleUtils.IsUserOrgAdmin())
                    throw new HttpException(401, SharedRes.Error.Unauthorized_Location);
			}

			return location;
		}
	}
}