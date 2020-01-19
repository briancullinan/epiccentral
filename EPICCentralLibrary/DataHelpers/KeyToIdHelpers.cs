using System;
using EPICCentralDL.CollectionClasses;
using EPICCentralDL.HelperClasses;
using EPICCentralLibrary.Utilities;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentralLibrary.DataHelpers
{
    public static class KeyToIdHelpers
    {
        public static int ConvertCustomerKey(string organizationUid)
        {
            try
            {
                OrganizationCollection organizationCollection = new OrganizationCollection();
                PredicateExpression filter = new PredicateExpression(OrganizationFields.UniqueIdentifier == organizationUid);
                organizationCollection.GetMulti(filter);
                if (organizationCollection.Count > 0)
                    return organizationCollection[0].OrganizationId; 
                else
                    throw(new Exception("Unable to locate customer with key: " + organizationUid));
            }
            catch(Exception ex)
            {
                Loggers.LogException(GlobalSettings.SYSTEM_DAEMON_USER_ID,ex);
                return -1;
            }
        }

        public static int ConvertLocationKey(string locationUid)
        {
            try
            {
                LocationCollection locationCollection = new LocationCollection();
                PredicateExpression filter = new PredicateExpression(LocationFields.UniqueIdentifier == locationUid);
                locationCollection.GetMulti(filter);
                if (locationCollection.Count > 0)
                    return locationCollection[0].LocationId;
                else
                    throw(new Exception("Unable to locate location with key: " + locationUid));
            }
            catch (Exception ex)
            {
                Loggers.LogException(GlobalSettings.SYSTEM_DAEMON_USER_ID, ex);
                return -1;
            }
        }

        public static int ConvertDeviceKey(string deviceUid)
        {
            try
            {
                DeviceCollection deviceCollection = new DeviceCollection();
                PredicateExpression filter = new PredicateExpression(DeviceFields.UniqueIdentifier == deviceUid);
                deviceCollection.GetMulti(filter);
                if (deviceCollection.Count > 0)
                    return deviceCollection[0].DeviceId;
                else
                    throw(new Exception("Unable to locate device with key: " + deviceUid));
            }
            catch (Exception ex)
            {
                Loggers.LogException(GlobalSettings.SYSTEM_DAEMON_USER_ID, ex);
                return -1;
            }
        }

    }
}
