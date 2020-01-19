using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;

namespace EPICCentral.Utilities.Attributes
{
    public class QuantityAttribute : RangeAttribute
    {
        public QuantityAttribute(string otherProperty)
            : base(
                new LinqMetaData().ScanRate.Min(x => x.MinCountForRate),
                new LinqMetaData().ScanRate.Max(x => x.MaxCountForRate))
        {
            if (otherProperty == null)
            {
                throw new ArgumentNullException("otherProperty");
            }
            OtherProperty = otherProperty;
        }

        public string OtherProperty { get; private set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
            var otherPropertyValue = new ScanRateEntity((int)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null));
            if (otherPropertyValue.IsNew)
                return null;
            if ((int)value < otherPropertyValue.MinCountForRate ||
                (int)value > otherPropertyValue.MaxCountForRate)
                return new ValidationResult(string.Format(CultureInfo.CurrentCulture, ErrorMessageString, validationContext.DisplayName,
                                                          otherPropertyValue.MinCountForRate, otherPropertyValue.MaxCountForRate));
            return null;
        }
    }
}