using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;

namespace EPICCentral.Utilities.Attributes
{
    public class TransferQuantityAttribute : RangeAttribute, IClientValidatable
    {

        public TransferQuantityAttribute(string otherProperty)
            : base(1, new LinqMetaData().ScanRate.Max(x => x.MaxCountForRate))
        {
            if (otherProperty == null) { 
                throw new ArgumentNullException("otherProperty"); 
            }
            OtherProperty = otherProperty; 
        }

        public string OtherProperty { get; private set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
            var otherPropertyValue = new DeviceEntity((int)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null));
            if (otherPropertyValue.IsNew)
                return null;

            if ((int)value <= 0 ||
                (int)value > otherPropertyValue.ScansAvailable)
                return new ValidationResult(string.Format(CultureInfo.CurrentCulture, ErrorMessageString, validationContext.DisplayName,
                                                          1, otherPropertyValue.ScansAvailable));
            return null;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
                           {
                               ValidationType = "transferquantity",
                               ErrorMessage = ErrorMessageString
                           };
            rule.ValidationParameters["min"] = Minimum;
            rule.ValidationParameters["otherproperty"] = (context as ViewContext).ViewData.TemplateInfo.GetFullHtmlFieldId(OtherProperty);
            yield return rule;
        }
    }
}