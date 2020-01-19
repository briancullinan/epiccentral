using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.DirectoryServices;
using System.Security;

namespace EPICCentral.Utilities.Membership
{
    /// <summary>
    /// Sets up user email boxes.
    /// </summary>
    public class Mailbox
    {
        private const string OU_COMMON_NAME = "OU=Support Center Users,DC=epic,DC=local";
        private static readonly string Key = ConfigurationManager.AppSettings["UrlKey"] ?? "";
        private static readonly string IV = ConfigurationManager.AppSettings["UrlIV"] ?? "";

        public static string CreateUser(string username)
        {

            // add the user to active directory
            //This creates the new user in the "users" container.
            var password = Crypto.KeyGen.NextKey(24, 32);
            //Set the sAMAccountName and the password
            var container = new DirectoryEntry("LDAP://" + OU_COMMON_NAME);
            var user = container.Children.Add("CN=" + username, "user");
            user.Properties["sAMAccountName"].Add(username);
            user.CommitChanges();
            user.Invoke("SetPassword", new object[] { password });

            //This enables the new user.
            user.Properties["userAccountControl"].Value = 0x200; //ADS_UF_NORMAL_ACCOUNT
            user.CommitChanges();

            return password;
        }

        public static DirectoryEntry GetDomainUser(string username)
        {
            var searchRoot = new DirectoryEntry("LDAP://" + OU_COMMON_NAME);
            var search = new DirectorySearcher(searchRoot);
            search.Filter = String.Format("(&(objectClass=user)(objectCategory=person)(sAMAccountName={0}))", username);

            SearchResultCollection resultCol = search.FindAll();
            if (resultCol.Count > 0)
                return resultCol[0].GetDirectoryEntry();
            return null;
        }
    }
}