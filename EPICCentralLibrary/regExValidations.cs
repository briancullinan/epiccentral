using System;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace EPICCentralLibrary
{
    public class regExValidations
    {
        public static string emailRegEx = "^((?>[a-zA-Z\\d!#$%&'*+\\-/=?^_`{|}~]+\\x20*|\"((?=[\\x01-\\x7f])[^\"\\\\]|\\\\[\\x01-\\x7f])*\"\\x20*)*(?<angle><))?((?!\\.)(?>\\.?[a-zA-Z\\d!#$%&'*+\\-/=?^_`{|}~]+)+|\"((?=[\\x01-\\x7f])[^\"\\\\]|\\\\[\\x01-\\x7f])*\")@(((?!-)[a-zA-Z\\d\\-]+(?<!-)\\.)+[a-zA-Z]{2,}|\\[(((?(?<!\\[)\\.)(25[0-5]|2[0-4]\\d|[01]?\\d?\\d)){4}|[a-zA-Z\\d\\-]*[a-zA-Z\\d]:((?=[\\x01-\\x7f])[^\\\\\\[\\]]|\\\\[\\x01-\\x7f])+)\\])(?(angle)>)$";
        public static string USPhoneRegEx = "^([\\(]{1}[0-9]{3}[\\)]{1}[\\.| |\\-]{0,1}|^[0-9]{3}[\\.|\\-| ]?)?[0-9]{3}(\\.|\\-| )?[0-9]{4}$";
        public static string USCanPostalCodeRegEx = "^((\\d{5}-\\d{4})|(\\d{5})|([AaBbCcEeGgHhJjKkLlMmNnPpRrSsTtVvXxYy]\\d[A-Za-z]\\s?\\d[A-Za-z]\\d))$";
        public static string defaultUsernameRegEx = "^[a-zA-Z]?[\\w]*\\.?[\\w]*$";
        public static string defaultPasswordRegEx = "^[\\w!@#$%^&*()+.,?-]*$";
        public static string currencyAmoutnRegEx = "^\\$?([0-9]{1,3},([0-9]{3},)*[0-9]{3}|[0-9]+)(\\.[0-9][0-9])?$";
        public static string isANumberRegEx = "^\\d?-*\\.{0,1}\\d+$";
        public static string isAURLRegEx = "^(http|https|ftp)\\://[a-zA-Z0-9\\-\\.]+\\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\\-\\._\\?\\,\\'/\\\\+&amp;%\\$#\\=~])*$";
        public static string isWholeNumber = "^\\s*\\d+\\s*$";

        public static string matchMergeTag = "<~[^<>]+~>"; // Matches <~ Table.Column ~>

        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, emailRegEx);
        }

        public static bool IsValid(string ValueToTest, string expressionToTextWith)
        {
            return Regex.IsMatch(ValueToTest, expressionToTextWith);
        }
    }

    public class Validations
    {
        public static bool IsInRange(decimal ValueToTest, decimal LowValue, decimal highValue)
        {
            if ((ValueToTest >= LowValue) && (ValueToTest >= LowValue))
                return true;
            return false;
        }

        public static bool isEmpty(string ValueToTest)
        {
            try
            {
                return String.IsNullOrEmpty(ValueToTest.Trim());
            }
            catch
            {
                return true;
            }
        }

        public static bool IsValidDate(string ValueToTest)
        {
            try
            {
                DateTime.Parse(ValueToTest);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsDateRangeValid(string StartDateValue, string EndDateValue)
        {
            try
            {
                if (DateTime.Parse(StartDateValue) <= DateTime.Parse(EndDateValue))
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsXCheckboxChecked(CheckBoxList ListToCheck, Int16 minItemsSelected)
        {
            Int16 itemsSelected = 0;
            try
            {
                foreach (ListItem testItem in ListToCheck.Items)
                    if (testItem.Selected)
                        itemsSelected++;
                if (itemsSelected >= minItemsSelected)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }



    }
}
