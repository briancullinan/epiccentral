using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using EPICCentral.Controllers;
using EPICCentral.Models;
using EPICCentralDL.EntityClasses;

namespace EPICCentral.Utilities.Attributes
{
    public class EmailValidationAttribute : ValidationAttribute
    {
        internal static MailAddress FindUser(string address, IEnumerable<UserEntity> users)
        {
            UserSettingEntity profile = null;
            var selectedUser = users.FirstOrDefault(
                x =>
                    {
                        profile = x.Settings.FirstOrDefault(y => y.Name == "SupportUser");
                        // check if email of user is in To
                        if (address.IndexOf(x.EmailAddress, StringComparison.InvariantCultureIgnoreCase) > -1)
                            return true;

                        // check if profile of user is in To
                        if (profile != null && address.IndexOf(profile.Value, StringComparison.InvariantCultureIgnoreCase) > -1)
                            return true;

                        return false;
                    });
            if (selectedUser != null)
            {
                return new MailAddress(
                    profile != null
                        ? profile.Value + "@" + SupportController.DOMAIN
                        : selectedUser.EmailAddress,
                    SharedRes.Formats.User.FormatWith(selectedUser));
            }

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
            foreach (var recipient in tos)
            {
                if (string.IsNullOrEmpty(recipient.Trim()))
                    continue;

                var selectedUser = FindUser(recipient, ComposeMail.Users);

                if (selectedUser != null)
                {
                    result += (result != "" ? ", " : "") + SharedRes.Formats.MailAddress.FormatWith(selectedUser);
                }
                else
                {
                    result += (result != "" ? ", " : "") + recipient;
                    invalid += (invalid != "" ? ", " : "") + recipient.Trim();
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