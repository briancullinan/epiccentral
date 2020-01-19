using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using EPICCentral.Providers;
using EPICCentralDL;
using EPICCentralDL.FactoryClasses;

namespace EPICCentral.Utilities.Attributes
{
    /// <summary>
    /// 
    /// </summary>
    public class UsernameLengthAttribute : StringLengthAttribute, IClientValidatable
    {
        /// <summary>
        /// 
        /// </summary>
        public UsernameLengthAttribute()
            : base(EntityFieldFactory.Create(UserFieldIndex.Username).MaxLength)
        {
            MinimumLength = EpicMembershipProvider.MinUsernameLength;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationStringLengthRule(FormatErrorMessage(metadata.GetDisplayName()), MinimumLength, MaximumLength);
            return new[] { rule };
        }
    }

	/// <summary>
	/// 
	/// </summary>
	public class PasswordLengthAttribute : StringLengthAttribute, IClientValidatable
	{
		/// <summary>
		/// 
		/// </summary>
		public PasswordLengthAttribute()
			: base(EpicMembershipProvider.MaxRequiredPasswordLength)
		{
			MinimumLength = System.Web.Security.Membership.MinRequiredPasswordLength;
		}

		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
		{
			var rule = new ModelClientValidationStringLengthRule(FormatErrorMessage(metadata.GetDisplayName()), MinimumLength, MaximumLength);
			return new[] { rule };
		}
	}
}