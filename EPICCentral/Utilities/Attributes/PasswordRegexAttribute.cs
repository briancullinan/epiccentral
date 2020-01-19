using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace EPICCentral.Utilities.Attributes
{
    /// <summary>
    /// Validate user-entered password with regular expression.
    /// The standard <code>RegexExpressionAttribute</code> is not used for two reasons:
    /// 1) it requires the specified regex to be a constant; this ones uses the regex
    /// defined by the membership provider, and 2) the error message provided includes
    /// the actual regex definition which isn't something an average user will know in
    /// the slighest manner.
    /// Subclassing <code>RegexExpressionAttribute</code> would seem to be the best
    /// approach, but that didn't work; we could not get the client-side validation
    /// attributes to be placed in the HTML.
    /// So this is a separate implementation, although a rather trivial one.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class PasswordRegexAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly string regexDef;
        private readonly Regex regex;

        public PasswordRegexAttribute()
        {
            regexDef = System.Web.Security.Membership.PasswordStrengthRegularExpression;
            regex = new Regex(regexDef);
        }

        public override bool IsValid(object value)
        {
			if (value == null)
				return false;

            string val = value as string;
            if (val == null)
                throw new ArgumentException("Argument is not a string", "value");

            return regex.IsMatch(val);
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            // Using the existing rule class. This makes it trivial to create the HTML
            // attributes required for the standard "unobtrusive" jQuery validation.
            var rule = new ModelClientValidationRegexRule(FormatErrorMessage(metadata.GetDisplayName()), regexDef);
            return new[] { rule };
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, System.Web.Security.Membership.MinRequiredPasswordLength);
        }
    }
}