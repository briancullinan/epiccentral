using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EPICCentral.Utilities.Attributes
{
    public class RequiredIfAttribute : RequiredAttribute, IClientValidatable
    {
        public Condition Condition { get; set; }
        public string OtherProperty { get; private set; }
        public object Value { get; set; }

        public RequiredIfAttribute(string other, object value, Condition condition = Condition.EqualTo)
        {
            Condition = condition;
            OtherProperty = other;
            Value = value;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
            var otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

            var passes = false;
            switch(Condition)
            {
                case Condition.EqualTo:
                    passes = otherPropertyValue.Equals(Value);
                    break;
                case Condition.NotEqualTo:
                    passes = !otherPropertyValue.Equals(Value);
                    break;
                default:
                    throw new NotImplementedException();
            }

            if (passes)
                return base.IsValid(value, validationContext);

            return null;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var required = new ModelClientValidationRequiredRule(String.Format(ErrorMessageString, metadata.DisplayName)) {ValidationType = "requiredif"};
            required.ValidationParameters["other"] = (context as ViewContext).ViewData.TemplateInfo.GetFullHtmlFieldId(OtherProperty);
            required.ValidationParameters["condition"] = Condition.ToString();
            required.ValidationParameters["value"] = Value;
            yield return required;
        }
    }

    public enum Condition
    {
        GreaterThan,
        LessThan,
        GreaterThanOrEqualTo,
        LessThanOrEqualTo,
        EqualTo,
        NotEqualTo
    }

}