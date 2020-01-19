using System;
using System.ComponentModel.DataAnnotations;
using EPICCentral.Models;

namespace EPICCentral.Utilities.Attributes
{
    public class FullYearAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // is valid if called from edit card and the card number is empty
            var edit = validationContext.ObjectInstance as EditCard;
            if (edit != null && edit.CardNumber == "")
                return null;

            if (value == null)
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));

            int year;
            if (int.TryParse(value.ToString(), out year) && year >= DateTime.Now.Year)
                return null;
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
}