using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using EPICCentral.Utilities.Attributes;
using EPICCentral.Utilities.DataLayer;
using EPICCentral.Utilities.Membership;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;

namespace EPICCentral.Models
{
	public class DeviceModel
	{
		public DeviceModel()
		{
		}

		public DeviceModel(int? deviceId)
		{
			if (deviceId.HasValue)
			{
				DeviceEntity device = new DeviceEntity(deviceId.Value);
				if (!device.IsNew)
				{
					DeviceId = deviceId.Value;
					OrganizationId = device.Location.OrganizationId;
					OrganizationName = device.Location.Organization.Name;
					LocationId = device.LocationId;
					LocationName = device.Location.Name;
					DeviceState = device.DeviceState;
					SerialNumber = device.SerialNumber;
					RevisionLevel = device.RevisionLevel;
					ScansAvailable = device.ScansAvailable;
					ScansCompleted = device.ScansUsed;
					IssuedTime = device.DateIssued;
					UniqueIdentifier = device.UniqueIdentifier;
					LastReportTime = device.LastReportTime;
					UidQualifier = DeviceUtils.GetUidQualifier(device, false);
				}
				else
				{
					DeviceState = DeviceState.New;
					OrganizationId = -1;
				}
			}
			else
			{
				DeviceState = DeviceState.New;
				OrganizationId = -1;
			}

		}

		public int? DeviceId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Device), Name = "Edit_OrganizationId")]
        public int OrganizationId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Device), Name = "Edit_LocationId")]
        public int LocationId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Device), Name = "Edit_DeviceState")]
        public DeviceState DeviceState { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Device), Name = "Edit_SerialNumber")]
        public string SerialNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Device), Name = "Edit_RevisionLevel")]
        public string RevisionLevel { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Device), Name = "Edit_ScansAvailable")]
        public int ScansAvailable { get; set; }

        [RequiredIfScansChanged("DeviceId", "ScansAvailable", ErrorMessageResourceType = typeof(ModelRes.Device), ErrorMessageResourceName = "Edit_NotesError")]
        [Display(ResourceType = typeof(ModelRes.Device), Name = "Edit_PurchaseNotes")]
        public string PurchaseNotes { get; set; }

		public int ScansCompleted { get; set; }

		public DateTime IssuedTime { get; set; }

		public string OrganizationName { get; set; }

		public string LocationName { get; set; }

		public string UniqueIdentifier { get; set; }

		public string UidQualifier { get; set; }

		public DateTime? LastReportTime { get; set; }

		public bool IsNew
		{
			get { return DeviceId == 0; }
		}

		public List<SelectListItem> ValidStates
		{
			get
			{
				List<SelectListItem> items = new List<SelectListItem>();

				switch (DeviceState)
				{
				case DeviceState.New:
					items.Add(new SelectListItem { Text = DeviceState.New.ToString(), Value = DeviceState.New.ToString() });
					items.Add(new SelectListItem { Text = DeviceState.Retired.ToString(), Value = DeviceState.Retired.ToString() });
					break;
				case DeviceState.Active:
					items.Add(new SelectListItem { Text = DeviceState.Active.ToString(), Value = DeviceState.Active.ToString() });
					items.Add(new SelectListItem { Text = DeviceState.Transitioning.ToString(), Value = DeviceState.Transitioning.ToString() });
					items.Add(new SelectListItem { Text = DeviceState.Locked.ToString(), Value = DeviceState.Locked.ToString() });
					items.Add(new SelectListItem { Text = DeviceState.Retired.ToString(), Value = DeviceState.Retired.ToString() });
					break;
				case DeviceState.Transitioning:
					items.Add(new SelectListItem { Text = DeviceState.Transitioning.ToString(), Value = DeviceState.Transitioning.ToString() });
					items.Add(new SelectListItem { Text = DeviceState.Locked.ToString(), Value = DeviceState.Locked.ToString() });
					items.Add(new SelectListItem { Text = DeviceState.Retired.ToString(), Value = DeviceState.Retired.ToString() });
					break;
				case DeviceState.Locked:
					items.Add(new SelectListItem { Text = DeviceState.Active.ToString(), Value = DeviceState.Active.ToString() });
					items.Add(new SelectListItem { Text = DeviceState.Transitioning.ToString(), Value = DeviceState.Transitioning.ToString() });
					items.Add(new SelectListItem { Text = DeviceState.Locked.ToString(), Value = DeviceState.Locked.ToString() });
					items.Add(new SelectListItem { Text = DeviceState.Retired.ToString(), Value = DeviceState.Retired.ToString() });
					break;
				case DeviceState.Retired:
					items.Add(new SelectListItem { Text = DeviceState.Retired.ToString(), Value = DeviceState.Retired.ToString() });
					break;
				}

				return items;
			}
		}
	}
}
