using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Serialization;
using EPICCentral.Utilities.Attributes;
using Newtonsoft.Json;
using EPICCentral.Utilities.DataLayer;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;

namespace EPICCentral.Models
{
	public class BaseUserModel
	{
		private int[] locations;

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        public int? OrganizationId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?", ErrorMessageResourceType = typeof(ModelRes.Account), ErrorMessageResourceName = "EmailError")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        public short? Role { get; set; }

		public int[] Locations
		{
			get { return locations ?? new int[0]; }
			set { locations = value; }
		}

		public IEnumerable<SelectListItem> LocationList
		{
			get
			{
				List<SelectListItem> items = new LinqMetaData().Location
															.Where(l => l.OrganizationId == OrganizationId.Value)
															.Select(x => new SelectListItem
															{
																Text = x.Name,
																Value = x.LocationId.ToString(CultureInfo.InvariantCulture),
																Selected = Locations.Contains(x.LocationId)
															}).ToList();	// ToList forces the query.

				return items;
			}
		}

		public List<SelectListItem> RoleList
		{
			get
			{
				List<SelectListItem> items = OrganizationUtils.GetAllowedRoles(OrganizationId)
						.Select(x => new SelectListItem
						{
							Text = x.Name,
							Value = x.RoleId.ToString(CultureInfo.InvariantCulture),
							Selected = Role.HasValue && Role.Value == x.RoleId
						}).ToList();
				return items;
			}
		}
	}

	public class AddUserModel : BaseUserModel
	{
        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        public string Pin { get; set; }

		public bool IsPresetOrganization { get; set; }

        public new IEnumerable<SelectListItem> LocationList
		{
			get
			{
				return !IsPresetOrganization ? new List<SelectListItem>() : base.LocationList;
			}
		}

		public new List<SelectListItem> RoleList
		{
			get
			{
				return !IsPresetOrganization ? new List<SelectListItem>() : base.RoleList;
			}
		}
	}

	public class EditUserModel : BaseUserModel
	{
		public EditUserModel()
		{
		}

		public EditUserModel(UserEntity user)
		{
			OrganizationId = user.OrganizationId;
			UserName = user.Username;
			FirstName = user.FirstName;
			LastName = user.LastName;
			EmailAddress = user.EmailAddress;
			IsActive = user.IsActive;
			Role = user.Roles.Count > 0 ? (short?)user.Roles[0].RoleId : null;	// just in case no role
			Locations = user.UserAssignedLocations.Select(l => l.LocationId).ToArray();
			IsRegistrationPending = user.UserAccountRestrictions.Count > 0 && user.UserAccountRestrictions[0].AccountRestriction.AccountRestrictionType == AccountRestrictionType.NewUser;
			// HACK: There's no username until registration is complete. But it's a
			// required property. Instead of removing the Required attribute, we'll
			// set it to the email address. It will be in a hidden field, and it will
			// be ignored when posted back.
			if (IsRegistrationPending)
				UserName = user.EmailAddress;
		}

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        public bool IsActive { get; set; }

		public bool IsRegistrationPending { get; set; }
	}

	public class EditMeModel
	{
		public EditMeModel()
		{
		}

		public EditMeModel(UserEntity user)
		{
			UserName = user.Username;
			FirstName = user.FirstName;
			LastName = user.LastName;
			EmailAddress = user.EmailAddress;
            // set language
            var lang = user.Settings.FirstOrDefault(x => x.Name == "Language");
            CultureInfo ci;
            try
            {
                ci = lang == null ? new CultureInfo("en-US") : new CultureInfo(lang.Value);
            }
            catch
            {
                ci = new CultureInfo("en-US");
            }
		    Language = ci.Name;
            // set region
		    var region = user.Settings.FirstOrDefault(x => x.Name == "Region");
		    string zone;
		    try
		    {
		        zone = region == null ? "Etc/GMT" : region.Value;
                RegionAutoDetect = Boolean.Parse(user.Settings.FirstOrDefault(x => x.Name == "RegionAuto").Value);
            }
		    catch (Exception)
		    {
                zone = "Etc/GMT";
		        RegionAutoDetect = true;
		    }
		    Region = zone;
		}

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        public string Language { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Region(ErrorMessageResourceType = typeof(ModelRes.Account), ErrorMessageResourceName = "ValidRegion")]
        public string Region { get; set; }

        public bool RegionAutoDetect { get; set; }
    }

    public class RegionAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return Utilities.Information.TimeZones.Zones.Any(x => x.Type == value.ToString());
        } 
    }

    public class ChangePasswordModel
    {
        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Account), Name = "ChangePassword_OldPassword")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Account), Name = "ChangePassword_NewPassword")]
		[PasswordRegex(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_PasswordRegex")]
		[DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Account), Name = "ChangePassword_ConfirmPassword")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessageResourceType = typeof(ModelRes.Account), ErrorMessageResourceName = "ChangePassword_Compare")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Account), Name = "LogOn_Username")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Account), Name = "LogOn_Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
		[UsernameLength(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Length")]
		[Display(ResourceType = typeof(ModelRes.Account), Name = "Register_Username")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Email")]
        [Display(ResourceType = typeof(ModelRes.Account), Name = "Register_EmailAddress")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
		[PasswordLength(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Length")]
		[PasswordRegex(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_PasswordRegex")]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(ModelRes.Account), Name = "Register_Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(ModelRes.Account), Name = "Register_ConfirmPassword")]
        [Compare("Password", ErrorMessageResourceType = typeof(ModelRes.Account), ErrorMessageResourceName = "Register_Compare")]
        public string ConfirmPassword { get; set; }

        [Required(AllowEmptyStrings = true, ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Account), Name = "Register_Pin")]
        public string Pin { get; set; }

		public string OriginalEmail { get; set; }

		public string RegistrationKey { get; set; }
    }

	public class ResetModel
	{
        [Display(ResourceType = typeof(ModelRes.Account), Name = "Reset_Username")]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Account), Name = "Reset_EmailAddress")]
        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Email")]
        public string Email { get; set; }
	}

	public class ResetCompletionModel
	{
		public int Step { get; set; }
		public List<string> UserNames { get; set; }

        [Display(ResourceType = typeof(ModelRes.Account), Name = "ResetCompletion_Username")]
        public string UserName { get; set; }

		//[Required]
		//[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(ResourceType = typeof(ModelRes.Account), Name = "ResetCompletion_Password")]
        [DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(ResourceType = typeof(ModelRes.Account), Name = "ResetCompletion_ConfirmPassword")]
		[DataType(DataType.Password)]
        [Compare("Password", ErrorMessageResourceType = typeof(ModelRes.Account), ErrorMessageResourceName = "ResetCompletion_Compare")]
        public string ConfirmPassword { get; set; }

		public string OriginalEmail { get; set; }

		public string ResetKey { get; set; }
	}

	public class KeyedEmailModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public string Key { get; set; }
	}

	public class PasswordStrengthMeterSettings
	{
		public PasswordStrengthMeterSettings()
		{
			Policies = new List<Policy>();
		}

		// ReSharper disable UnusedAutoPropertyAccessor.Global
		[JsonProperty("policies")]
		[XmlArray(ElementName = "policies")]
		[XmlArrayItem(typeof(Policy), ElementName = "policy")]
		public List<Policy> Policies { get; set; }

		[JsonProperty("messages")]
		[XmlElement(ElementName = "messages")]
		public HintMessages Messages { get; set; }

		[JsonProperty("specials")]
		[XmlElement(ElementName = "specials")]
		public string Specials { get; set; }

		[JsonProperty("showScore")]
		[XmlElement(ElementName = "showScore")]
		public bool ShowScore { get; set; }

		[JsonProperty("showHint")]
		[XmlElement(ElementName = "showHint")]
		public bool ShowHint { get; set; }

		[JsonProperty("metricsUrl")]
		[XmlElement(ElementName = "metricsUrl")]
		public string MetricsUrl { get; set; }

		[JsonProperty("metricsUrlMethod")]
		[XmlElement(ElementName = "metricsUrlMethod")]
		public string MetricsUrlMethod { get; set; }
		// ReSharper restore UnusedAutoPropertyAccessor.Global

		public void AddPolicy(Policy policy)
		{
			Policies.Add(policy);
		}

		public class Policy
		{
			// ReSharper disable UnusedAutoPropertyAccessor.Global
			[JsonProperty("type")]
			[XmlAttribute("type")]
			public string Type { get; set; }

			[JsonProperty("minLength")]
			[XmlElement(ElementName = "minLength")]
			public int MinLength { get; set; }

			[JsonProperty("maxLength")]
			[XmlElement(ElementName = "maxLength")]
			public int MaxLength { get; set; }

			[JsonProperty("numLowers")]
			[XmlElement(ElementName = "numLowers")]
			public int NumLowers { get; set; }

			[JsonProperty("numUppers")]
			[XmlElement(ElementName = "numUppers")]
			public int NumUppers { get; set; }

			[JsonProperty("numDigits")]
			[XmlElement(ElementName = "numDigits")]
			public int NumDigits { get; set; }

			[JsonProperty("numSpecials")]
			[XmlElement(ElementName = "numSpecials")]
			public int NumSpecials { get; set; }
			// ReSharper restore UnusedAutoPropertyAccessor.Global
		}

		public class HintMessages
		{
			public HintMessages()
			{
				Needs = new List<Need>();
			}

			// ReSharper disable UnusedAutoPropertyAccessor.Global
			[JsonProperty("needs")]
			[XmlArray(ElementName = "needs")]
			[XmlArrayItem(typeof(Need), ElementName = "need")]
			public List<Need> Needs { get; set; }

			[JsonProperty("noSpace")]
			[XmlElement(ElementName = "noSpace")]
			public string NoSpace { get; set; }

			[JsonProperty("tooLong")]
			[XmlElement(ElementName = "tooLong")]
			public string TooLong { get; set; }

			[JsonProperty("invalidCharacter")]
			[XmlElement(ElementName = "invalidCharacter")]
			public string InvalidCharacter { get; set; }

			[JsonProperty("atLeast")]
			[XmlElement(ElementName = "atLeast")]
			public string AtLeast { get; set; }

			[JsonProperty("makeStronger")]
			[XmlElement(ElementName = "makeStronger")]
			public string MakeStronger { get; set; }

			[JsonProperty("strongPassword")]
			[XmlElement(ElementName = "strongPassword")]
			public string StrongPassword { get; set; }

			[JsonProperty("valid")]
			[XmlElement(ElementName = "valid")]
			public string Valid { get; set; }

			[JsonProperty("invalid")]
			[XmlElement(ElementName = "invalid")]
			public string Invalid { get; set; }
			// ReSharper restore UnusedAutoPropertyAccessor.Global

			public void AddNeed(Need need)
			{
				Needs.Add(need);
			}

			public class Need
			{
				// ReSharper disable UnusedAutoPropertyAccessor.Global
				[JsonProperty("type")]
				[XmlAttribute("type")]
				public string Type { get; set; }

				[JsonProperty("singular")]
				[XmlElement(ElementName = "singular")]
				public string Singular { get; set; }

				[JsonProperty("plural")]
				[XmlElement(ElementName = "plural")]
				public string Plural { get; set; }
				// ReSharper restore UnusedAutoPropertyAccessor.Global
			}
		}
	}
}
