using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EPICCentralDL.EntityClasses;

namespace EPICCentral.Models
{
    public class NewLocationModel
    {
        public NewLocationModel()
        {
            
        }

        public NewLocationModel(LocationEntity location)
        {
            IsNew = location.IsNew;
            AddressLine1 = location.AddressLine1;
            AddressLine2 = location.AddressLine2;
            Name = location.Name;
            OrganizationId = location.OrganizationId;
            City = location.City;
            State = location.State;
            Country = location.Country;
            PostalCode = location.PostalCode;
            PhoneNumber = location.PhoneNumber;
            Latitude = location.Latitude;
            Longitude = location.Longitude;
            IsActive = location.IsActive;
        }

        public bool IsNew { get; private set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Location), Name = "Address")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Location), Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Location), Name = "Organization")]
        public int OrganizationId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Location), Name = "City")]
        public string City { get; set; }

        [Display(ResourceType = typeof(ModelRes.Location), Name = "State")]
        public string State { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Location), Name = "Country")]
        public string Country { get; set; }

        [Display(ResourceType = typeof(ModelRes.Location), Name = "PostalCode")]
        public string PostalCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Location), Name = "Telephone")]
        public string PhoneNumber { get; set; }

        [Display(ResourceType = typeof(ModelRes.Location), Name = "Latitude")]
        public decimal? Latitude { get; set; }

        [Display(ResourceType = typeof(ModelRes.Location), Name = "Longitude")]
        public decimal? Longitude { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Location), Name = "Active")]
        public bool IsActive { get; set; }
    }
}