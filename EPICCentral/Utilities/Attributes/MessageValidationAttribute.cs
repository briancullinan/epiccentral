using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using EPICCentral.Models;
using EPICCentralDL.EntityClasses;

namespace EPICCentral.Utilities.Attributes
{
    public class MessageValidationAttribute : ValidationAttribute
    {
        internal static CommonEntityBase FindEntity(string address, IEnumerable<CommonEntityBase> entites)
        {
            var addressSplit = address.Split(':');
            if (addressSplit.Length > 1)
            {
                var match = Regex.Match(addressSplit[1], "[0-9]*");
                if (match.Success)
                {
                    if (addressSplit[0].StartsWith("o", StringComparison.OrdinalIgnoreCase))
                    {
                        var organization = new OrganizationEntity(int.Parse(match.Value));
                        if (!organization.IsNew)
                            return organization;
                    }
                    if (addressSplit[0].StartsWith("l", StringComparison.OrdinalIgnoreCase))
                    {
                        var location = new LocationEntity(int.Parse(match.Value));
                        if (!location.IsNew)
                            return location;
                    }
                    if (addressSplit[0].StartsWith("d", StringComparison.OrdinalIgnoreCase))
                    {
                        var device = new DeviceEntity(int.Parse(match.Value));
                        if (!device.IsNew)
                            return device;
                    }
                }
            }
            return null;
        }

        internal static string GetId(CommonEntityBase entity)
        {
            var device = entity as DeviceEntity;
            if (device != null)
                return String.Format("d:{0} ({1})", device.DeviceId, SharedRes.Formats.Device.FormatWith(device)).Replace(",", "").Replace(";", "");
            var location = entity as LocationEntity;
            if (location != null)
                return String.Format("l:{0} ({1})", location.LocationId, location.Name).Replace(",", "").Replace(";", "");
            var organization = entity as OrganizationEntity;
            if (organization != null)
                return String.Format("o:{0} ({1})", organization.OrganizationId, organization.Name).Replace(",", "").Replace(";", "");
            return null;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var property = validationContext.ObjectType.GetProperty("To");


            // save the message
            if (value == null)
                value = "";
            var tos = ((string)value).Split(new[] { "\n", ";", "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim());
            var result = "";
            var invalid = "";


            // check for internal e-mail address for each user
            foreach (var address in tos)
            {
                if (string.IsNullOrEmpty(address.Trim()))
                    continue;

                var selectedEntity = FindEntity(address, ComposeMessage.Entities);

                if (selectedEntity != null)
                {
                    result += (result != "" ? ", " : "") + GetId(selectedEntity);
                }
                else
                {
                    result += (result != "" ? ", " : "") + address;
                    invalid += (invalid != "" ? ", " : "") + address.Trim();
                }
            }

            property.SetValue(validationContext.ObjectInstance, result, null);

            return string.IsNullOrEmpty(invalid)
                       ? null
                       : new ValidationResult(String.Format(CultureInfo.CurrentCulture, ErrorMessageString,
                                                            validationContext.DisplayName, invalid));
        }
    }
}