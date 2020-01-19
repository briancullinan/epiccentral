using System.ComponentModel.DataAnnotations;
using EPICCentralDL.EntityClasses;

namespace EPICCentral.Utilities.Attributes
{
    public class RequiredIfScansChangedAttribute : RequiredAttribute
    {
        public string DeviceId { get; private set; }
        public string ScansAvailable { get; private set; }

        public RequiredIfScansChangedAttribute(string deviceId, string scansAvailable)
        {
            DeviceId = deviceId;
            ScansAvailable = scansAvailable;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var deviceIdInfo = validationContext.ObjectType.GetProperty(DeviceId);
            var deviceId = deviceIdInfo.GetValue(validationContext.ObjectInstance, null);
            if (deviceId != null)
            {
                var device = new DeviceEntity((int)deviceId);

                var scansAvailableInfo = validationContext.ObjectType.GetProperty(ScansAvailable);
                var scansAvailable = (int)scansAvailableInfo.GetValue(validationContext.ObjectInstance, null);

                if (device.ScansAvailable != scansAvailable)
                    return base.IsValid(value, validationContext);
            }
            else
                // new device
                return base.IsValid(value, validationContext);

            return null;
        }
    }
}