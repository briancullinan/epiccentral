using System;
using System.ComponentModel.DataAnnotations;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;

namespace EPICCentral.Models
{
    public class ScanRate
    {
        public ScanRate()
        {
            
        }

        public ScanRate(int? scanRateId)
        {
            ScanRateEntity scanRate;
            if (scanRateId.HasValue && !(scanRate = new ScanRateEntity(scanRateId.Value)).IsNew)
            {
                ScanType = scanRate.ScanType;
                RatePerScan = scanRate.RatePerScan;
                MinCountForRate = scanRate.MinCountForRate;
                MaxCountForRate = scanRate.MaxCountForRate;
                EffectiveDate = scanRate.EffectiveDate;
                IsActive = scanRate.IsActive;
            }
        }

        [Display(ResourceType = typeof(ModelRes.Configuration), Name = "EditRate_ScanType")]
        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        public ScanType ScanType { get; set; }

        [Display(ResourceType = typeof(ModelRes.Configuration), Name = "EditRate_RatePerScan")]
        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Range(1/double.MaxValue, double.MaxValue)]
        [DataType(DataType.Currency)]
        public decimal RatePerScan { get; set; }

        [Display(ResourceType = typeof(ModelRes.Configuration), Name = "EditRate_RateMinimum")]
        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Range(1, int.MaxValue)]
        public int MinCountForRate { get; set; }

        [Display(ResourceType = typeof(ModelRes.Configuration), Name = "EditRate_RateMaximum")]
        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Range(1, int.MaxValue)]
        public int MaxCountForRate { get; set; }

        [Display(ResourceType = typeof(ModelRes.Configuration), Name = "EditRate_EffectiveDate")]
        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [DataType(DataType.DateTime)]
        public DateTime EffectiveDate { get; set; }

        [Display(ResourceType = typeof(ModelRes.Configuration), Name = "EditRate_Active")]
        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        public bool IsActive { get; set; }
    }

    public class EditSetting
    {
        public EditSetting()
        {
            
        }

        public EditSetting(string name)
        {
            SystemSettingEntity setting;
            if (!string.IsNullOrEmpty(name) && !(setting = new SystemSettingEntity(name)).IsNew)
            {
                Name = setting.Name;
                Value = setting.Value;
            }
        }

        [Display(ResourceType = typeof(ModelRes.Configuration), Name = "EditSetting_Name")]
        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        public string Name { get; set; }

        [Display(ResourceType = typeof(ModelRes.Configuration), Name = "EditSetting_Value")]
        [Required(AllowEmptyStrings = true, ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        public string Value { get; set; }
    }
}