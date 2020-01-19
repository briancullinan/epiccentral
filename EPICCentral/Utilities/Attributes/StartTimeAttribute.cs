using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace EPICCentral.Utilities.Attributes
{
    public class StartTimeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime start;
            if (DateTime.TryParse(value.ToString(), out start) && TimeZoneInfo.ConvertTimeToUtc(start, (TimeZoneInfo)HttpContext.Current.Items["TimeZoneInfo"]) >= DateTime.UtcNow)
                return true;
            return false;
        }
    }
}