using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EPICCentral.Utilities.Attributes;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;

namespace EPICCentral.Models
{
    public class ComposeMessage
    {
        private DateTime _start = TimeZoneInfo.ConvertTime(DateTime.UtcNow, (TimeZoneInfo)HttpContext.Current.Items["TimeZoneInfo"]);

        public ComposeMessage()
        {
            
        }

        public ComposeMessage(MessageEntity message)
        {
            Type = message.MessageType;
            StartTime = message.StartTime;
            EndTime = message.EndTime;
            Title = message.Title;
            Body = message.Body;
            To = "";
            // get all the devices included that haven't received the message yet
            var devices = message.DeviceMessages.Where(x => x.DeliveryTime == null).Select(x => x.Device).ToList();

            // get all the locations where all of the devices are included
            var locations =
                devices.Select(x => x.Location).Distinct().ToList().Where(x => x.Devices.All(y => devices.Contains(y))).ToList();
            devices = devices.Except(locations.SelectMany(x => x.Devices)).ToList();

            // get all the organizations where all of the locations are included
            var organizations =
                locations.Select(x => x.Organization).Distinct().ToList().Where(x => x.Locations.All(y => locations.Contains(y))).ToList();
            locations = locations.Except(organizations.SelectMany(x => x.Locations)).ToList();

            // loop through each entity and add it to the to address
            foreach (var entity in ((IEnumerable<CommonEntityBase>)devices).Concat(locations).Concat(organizations))
            {
                To += (To != "" ? ", " : "") + MessageValidationAttribute.GetId(entity);
            }
        }

        [Display(ResourceType = typeof (ModelRes.Message), Name = "Edit_Type")]
        [Required(ErrorMessageResourceType = typeof (SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        public MessageType Type { get; set; }

        [Display(ResourceType = typeof(ModelRes.Message), Name = "Edit_StartTime")]
        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [StartTime]
        public DateTime StartTime { get { return _start; } set { _start = TimeZoneInfo.ConvertTimeToUtc(value, (TimeZoneInfo)HttpContext.Current.Items["TimeZoneInfo"]); } }

        [Display(ResourceType = typeof(ModelRes.Message), Name = "Edit_EndTime")]
        public DateTime? EndTime { get; set; }

        [Display(ResourceType = typeof (ModelRes.Message), Name = "Edit_To")]
        [Required(ErrorMessageResourceType = typeof (SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [MessageValidation(ErrorMessageResourceType = typeof (ModelRes.Message), ErrorMessageResourceName = "InvalidRecipients")]
        public string To { get; set; }

        [Display(ResourceType = typeof (ModelRes.Message), Name = "Edit_Title")]
        [Required(AllowEmptyStrings = true, ErrorMessageResourceType = typeof (SharedRes.Error),
            ErrorMessageResourceName = "Error_Required")]
        public string Title { get; set; }

        [Display(ResourceType = typeof (ModelRes.Message), Name = "Edit_Message")]
        [Required(AllowEmptyStrings = true, ErrorMessageResourceType = typeof (SharedRes.Error),
            ErrorMessageResourceName = "Error_Required")]
        public string Body { get; set; }

        public static IEnumerable<CommonEntityBase> Entities
        {
            get
            {
                var result = new List<CommonEntityBase>();
                result.AddRange(new LinqMetaData().Device.WithPermissions());
                result.AddRange(new LinqMetaData().Location.WithPermissions());
                result.AddRange(new LinqMetaData().Organization.WithPermissions());
                return result;
            }
        }

        public IEnumerable<DeviceEntity> Tos
        {
            get
            {
                var tos = To.Split(new[] { "\n", ";", "," }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim());

                foreach (var recipient in tos)
                {
                    if (string.IsNullOrEmpty(recipient.Trim()))
                        continue;

                    var selectedEntity = MessageValidationAttribute.FindEntity(recipient, Entities);
                    if (selectedEntity != null)
                    {
                        var device = selectedEntity as DeviceEntity;
                        if (device != null)
                            yield return device;
                        var location = selectedEntity as LocationEntity;
                        if (location != null)
                            foreach (var entity in location.Devices)
                                yield return entity;
                        var organization = selectedEntity as OrganizationEntity;
                        if (organization != null)
                            foreach (var loc in organization.Locations)
                                foreach (var entity in loc.Devices)
                                    yield return entity;

                    }
                }
            }
        } 
    }
}
