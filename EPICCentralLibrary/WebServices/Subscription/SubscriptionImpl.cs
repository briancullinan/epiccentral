using System;
using System.Data;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.CollectionClasses;
using EPICCentralDL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentralLibrary.Webservices.Subscription
{
    public static class SubscriptionImpl
    {
        public static Boolean IsDeviceAuthorizedImpl(string locationUniqueKeyVar, string deviceUniqueKeyVar)
        {
            // This check will verify that the account, location and device are activated
            LocationEntity locationEntity;
            // Locate the customers location Id by using the unique key value and verify that the location is in 
            // fact authorized.
            LocationCollection ecCustomerLocationCollection = new LocationCollection();
            PredicateExpression filter = new PredicateExpression(LocationFields.UniqueIdentifier == locationUniqueKeyVar);
            ecCustomerLocationCollection.GetMulti(filter);
            if (ecCustomerLocationCollection.Count > 0)
            {
                locationEntity = ecCustomerLocationCollection[0];
                if (locationEntity.IsActive)
                {
                    // Verify that the device belongs to the specified location
                    DeviceCollection ecDeviceCollection = new DeviceCollection();
                    PredicateExpression filter1 = new PredicateExpression(DeviceFields.UniqueIdentifier == deviceUniqueKeyVar);
                    filter1.Add(DeviceFields.LocationId == locationEntity.LocationId);
                    ecDeviceCollection.GetMulti(filter1);
                    if (ecDeviceCollection.Count > 0)
                    {
                        // Finally verify that there are scans left in the bank for the customer to use
                        if (ecDeviceCollection[0].ScansAvailable <= 0)
                            throw (new Exception("There are no scans available for this location: " + locationUniqueKeyVar));
                    }
                    else
                        throw (new Exception("The device does not appear to belong to the specified location, the location is: " + locationUniqueKeyVar + " the device is: " + deviceUniqueKeyVar));
                }
                else
                    throw (new Exception("The location is not active, the key is: " + locationUniqueKeyVar));
            }
            else
                throw (new Exception("Unable to locate location with key: " + locationUniqueKeyVar));
            return true;
        }

        public static Int32 GetScansAvailableImpl(string deviceUniqueKeyVar)
        {
            DeviceEntity deviceEntity;
            DeviceCollection deviceCollection = new DeviceCollection();
            PredicateExpression filter = new PredicateExpression(DeviceFields.UniqueIdentifier == deviceUniqueKeyVar);
            deviceCollection.GetMulti(filter);
            if (deviceCollection.Count > 0)
            {
                deviceEntity = deviceCollection[0];
                return (deviceEntity.ScansAvailable);
            }
            return 0;
        }

        public static Boolean DecrementScansImpl(string deviceUniqueKeyVar, DateTime scanTime, short scanType)
        {
            Transaction transactionManager = new Transaction(IsolationLevel.ReadCommitted, "Decrement Scans");
            int deviceId = DataHelpers.KeyToIdHelpers.ConvertDeviceKey(deviceUniqueKeyVar);
            // Add in history record
            ScanHistoryEntity scanHistoryEntity = new ScanHistoryEntity();
            scanHistoryEntity.DeviceId = deviceId;
            //scanHistoryEntity.ScanTypeId = scanType;
            scanHistoryEntity.ScanStartTime = scanTime;
            scanHistoryEntity.Save();
            // Decrement useage counts
            DeviceEntity deviceEntity = new DeviceEntity(deviceId);
            deviceEntity.ScansAvailable = deviceEntity.ScansAvailable - 1;
            deviceEntity.Save();
            transactionManager.Commit();
            transactionManager.Dispose();
            return true;
        }
    }
}
