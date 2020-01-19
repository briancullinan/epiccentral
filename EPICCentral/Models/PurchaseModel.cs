using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using AuthorizeNet;
using EPICCentral.Utilities.Attributes;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;
using ModelRes;

namespace EPICCentral.Models
{
    public class NewPurchaseModel
    {
        public IQueryable<UserCreditCardEntity> Cards { get; set; }

        public List<Purchase> Cart { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "CreditCard")]
        public int CreditCardId { get; set; }

        public CreditCardEntity CreditCard
        {
            get { return new CreditCardEntity(CreditCardId); }
        }

        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "PurchaseNotes")]
        public string PurchaseNotes { get; set; }
    }

    public class PurchaseHistoryModel
    {
        public IQueryable<PurchaseHistoryEntity> Puchases { get; set; }

        public IEnumerable<SelectListItem> Devices
        {
            get
            {
                var devices = new[]
                                  {
                                      new SelectListItem {Text = SharedRes.General.NotSelected, Value = ""}
                                  }
                    .Concat(new LinqMetaData()
                                .Device.WithPermissions().ToList()
                                .Select(x => new SelectListItem
                                                 {
                                                     Text = SharedRes.Formats.Device.FormatWith(x) + " (" + x.ScansAvailable + ")",
                                                     Value = x.ScansAvailable > 0
                                                                 ? x.DeviceId.ToString(CultureInfo.InvariantCulture)
                                                                 : ""
                                                 }));

                return devices;
            }
        }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "List_FromDevice")]
        public int FromDeviceId { get; set; }

        public DeviceEntity FromDevice
        {
            get { return new DeviceEntity(FromDeviceId); }
        }

        public DeviceEntity ToDevice
        {
            get { return new DeviceEntity(ToDeviceId); }
        }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "List_ToDevice")]
        [NotEqual("FromDeviceId", ErrorMessageResourceType = typeof(ModelRes.Purchase), ErrorMessageResourceName = "List_SameDeviceError")]
        public int ToDeviceId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [TransferQuantity("FromDeviceId", ErrorMessageResourceType = typeof(ModelRes.Purchase), ErrorMessageResourceName = "Add_QuantityError")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "List_Quantity")]
        public int Quantity { get; set; }
    }

    [Serializable]
    public class Purchase
    {
        private int _quantity;
        private int _scanRateId;
        private int _deviceId;

        [NonSerialized]
        public IQueryable<DeviceEntity> Devices;


        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Quantity("ScanRateId", ErrorMessageResourceType = typeof(ModelRes.Purchase), ErrorMessageResourceName = "Add_QuantityError")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "Add_Quantity")]
        public int Quantity { get { return _quantity; } set { _quantity = value; } }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "Add_Rate")]
        public int ScanRateId
        {
            get { return _scanRateId; }
            set { _scanRateId = value; }
        }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "Add_Device")]
        public int DeviceId
        {
            get { return _deviceId; }
            set { _deviceId = value; }
        }

        public ScanRateEntity ScanRate { get { return new ScanRateEntity(_scanRateId); } }
        public DeviceEntity Device { get { return new DeviceEntity(_deviceId); } }

        public IEnumerable<SelectListItem> ScanTypes
        {
            get { return new LinqMetaData().ScanRate.WithPermissions().ToSelectList(); }
        }

        public decimal Price
        {
            get
            {
                return ScanRate.RatePerScan * Quantity;
            }
        }
    }

    public class AddCard
    {
        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_CardNumber")]
        public string CardNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_Month")]
        [Range(1, 12, ErrorMessageResourceType = typeof(ModelRes.Purchase), ErrorMessageResourceName = "AddCard_MonthFormat")]
        public int CardMonth { get; set; }

        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_ExpirationDate")]
        public string Expiration { get { return CardMonth + "/" + CardYear; } }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [FullYear(ErrorMessageResourceType = typeof(ModelRes.Purchase), ErrorMessageResourceName = "AddCard_YearFormat")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_Year")]
        public int CardYear { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_SecurityCode")]
        public string SecurityCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_Address")]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_City")]
        public string City { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_State")]
        public string State { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_Country")]
        public string Country { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_Zip")]
        public string Zip { get; set; }

    }

    public class EditCard
    {
        private string _cardNumber = "";
        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_LastName")]
        public string LastName { get; set; }

        [Display(ResourceType = typeof (ModelRes.Purchase), Name = "AddCard_CardNumber")]
        public string CardNumber
        {
            get { return _cardNumber ?? ""; }
            set { _cardNumber = value; }
        }

        [RequiredIf("CardNumber", "", Condition.NotEqualTo, ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_Month")]
        [Range(1, 12, ErrorMessageResourceType = typeof(ModelRes.Purchase), ErrorMessageResourceName = "AddCard_MonthFormat")]
        public string CardMonth { get; set; }

        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_ExpirationDate")]
        public string Expiration { get { return CardMonth + "/" + CardYear; } }

        [RequiredIf("CardNumber", "", Condition.NotEqualTo, ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [FullYear(ErrorMessageResourceType = typeof(ModelRes.Purchase), ErrorMessageResourceName = "AddCard_YearFormat")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_Year")]
        public string CardYear { get; set; }

        [RequiredIf("CardNumber", "", Condition.NotEqualTo, ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_SecurityCode")]
        public string SecurityCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_Address")]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_City")]
        public string City { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_State")]
        public string State { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_Country")]
        public string Country { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [Display(ResourceType = typeof(ModelRes.Purchase), Name = "AddCard_Zip")]
        public string Zip { get; set; }

    }
}
