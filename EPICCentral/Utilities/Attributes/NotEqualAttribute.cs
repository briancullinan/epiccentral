using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace EPICCentral.Utilities.Attributes
{
    public class NotEqualAttribute : ValidationAttribute, IClientValidatable
    {
        public string OtherProperty { get; private set; }

        public NotEqualAttribute(string otherProperty)
        {
            if (otherProperty == null)
            {
                throw new ArgumentNullException("otherProperty");
            }
            OtherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
            var otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
            var otherDisplayAttribute =
                (DisplayAttribute) (otherPropertyInfo.GetCustomAttributes(typeof (DisplayAttribute), false).SingleOrDefault());

            if (value == otherPropertyValue)
                return
                    new ValidationResult(string.Format(CultureInfo.CurrentCulture, ErrorMessageString,
                                                       validationContext.DisplayName,
                                                       otherDisplayAttribute != null
                                                           ? otherDisplayAttribute.Name
                                                           : OtherProperty));
            return null;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
                           {
                               ValidationType = "notequalto",
                               ErrorMessage = ErrorMessageString
                           };
            rule.ValidationParameters["other"] = (context as ViewContext).ViewData.TemplateInfo.GetFullHtmlFieldId(OtherProperty);
            yield return rule;
        }
    }
}