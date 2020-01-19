using System;
using EPICCentralDL.CollectionClasses;
using EPICCentralDL.HelperClasses;
using EPICCentralLibrary.Utilities;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentralLibrary.DataHelpers
{
    public static class UniqueIdGenerator
    {
        public enum UniqueIdType
        {
            OrganizationUniqueId,
            LocationUniqueId,
            DeviceUniqueId
        }

        public static string CreateUniqueId(UniqueIdType idType)
        {
            Int32 attempts = 0;
            string returnValue = String.Empty;
            try
            {
                do
                {
                    attempts++;
                    returnValue = Guid.NewGuid().ToString();
                    if (idType == UniqueIdType.OrganizationUniqueId)
                    {
                        OrganizationCollection ecCustomerCollection = new OrganizationCollection();
                        PredicateExpression filter = new PredicateExpression(OrganizationFields.UniqueIdentifier == returnValue);
                        ecCustomerCollection.GetMulti(filter);
                        if(ecCustomerCollection.Count == 0)
                            break;
                    }
                    else if (idType == UniqueIdType.DeviceUniqueId)
                    {
                        DeviceCollection ecDeviceCollection = new DeviceCollection();
                        PredicateExpression filter = new PredicateExpression(DeviceFields.UniqueIdentifier == returnValue);
                        ecDeviceCollection.GetMulti(filter);
                        if (ecDeviceCollection.Count == 0)
                            break;
                    }
                    else if (idType == UniqueIdType.LocationUniqueId )
                    {
                        LocationCollection ecCustomerLocationCollection = new LocationCollection();
                        PredicateExpression filter = new PredicateExpression(LocationFields.UniqueIdentifier == returnValue);
                        ecCustomerLocationCollection.GetMulti(filter);
                        if (ecCustomerLocationCollection.Count == 0)
                            break;
                    }
                } while (attempts < GlobalSettings.MAX_KEYGEN_ATTEMPTS);
                return returnValue;
            }
            catch (Exception ex)
            {
                Loggers.LogException(GlobalSettings.SYSTEM_DAEMON_USER_ID,ex);
                return returnValue;
            }
        }
    }
}
