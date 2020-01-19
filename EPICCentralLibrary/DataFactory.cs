using System;
using EPICCentralDL.CollectionClasses;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentralLibrary
{
    public static class DataFactory
    {
        public static Int64 GetScanCount(Boolean sinceInception)
        {
            //Random r = new Random();
            //Thread.Sleep(20);
            //Int64 Newvalue = r.Next();
            //return Newvalue;
            ScanHistoryCollection scanHistoryCollection = new ScanHistoryCollection();
            try
            {
                if(sinceInception)
                    return (long)scanHistoryCollection.GetDbCount();
                PredicateExpression filter = new PredicateExpression(ScanHistoryFields.ScanStartTime >= DateTime.Now.Date);
                filter.AddWithAnd(ScanHistoryFields.ScanStartTime <  DateTime.Now.Date.AddDays(1));
                return scanHistoryCollection.GetDbCount(filter);
            }
            catch
            {
                return (0L);
            }
        }

        public static Double GetPurchases(Boolean sinceInception)
        {
            PurchaseHistoryCollection purchaseHistoryCollection = new PurchaseHistoryCollection();
            try
            {
                Decimal totalPurchases = 0;
                if (!sinceInception)
                {
                    PredicateExpression filter = new PredicateExpression(PurchaseHistoryFields.PurchaseTime >= DateTime.Now.Date);
                    filter.AddWithAnd(PurchaseHistoryFields.PurchaseTime < DateTime.Now.Date.AddDays(1));
                    purchaseHistoryCollection.GetMulti(filter);
                }
                purchaseHistoryCollection.GetMulti(null);
                foreach (PurchaseHistoryEntity ece in purchaseHistoryCollection)
                    totalPurchases = totalPurchases + ece.AmountPaid;
                return (Double) totalPurchases;
            }
            catch
            {
                return (0.00);
            }
        }

        public static int GetActiveDevices()
        {
            DeviceCollection ecDeviceCollection = new DeviceCollection();
            try
            {
                PredicateExpression filter = new PredicateExpression(DeviceFields.LastReportTime >= DateTime.Now.Date);
                filter.AddWithAnd(DeviceFields.LastReportTime < DateTime.Now.Date.AddDays(1));
				return ecDeviceCollection.GetDbCount(filter);
            }
            catch
            {
                return 0;
            }
        }

        public static int GetTotalDevices()
        {
            DeviceCollection deviceLocationCollection = new DeviceCollection();
            try
            {
                return deviceLocationCollection.GetDbCount();
            }
            catch
            {
                return 0;
            }
        }

        public static int GetTotalUsers()
        {
            UserCollection ecUserCollection = new UserCollection();
            try
            {
                PredicateExpression filter = new PredicateExpression(UserFields.IsActive == true);
                return ecUserCollection.GetDbCount(filter);
            }
            catch
            {
                return 0;
            }
        }

        public static Int64 GetTotalCompanies()
        {
            OrganizationCollection ecCustomerCollection = new OrganizationCollection();
            try
            {
                PredicateExpression filter = new PredicateExpression(OrganizationFields.IsActive == true);
                return ecCustomerCollection.GetDbCount(filter);
            }
            catch
            {
                return (0L);
            }
        }

        public static Int64 GetDaysExceptions()
        {
            ExceptionLogCollection exceptionLogCollection = new ExceptionLogCollection();
            try
            {
                PredicateExpression filter = new PredicateExpression(ExceptionLogFields.ReceivedTime  >= DateTime.Now.Date);
                filter.AddWithAnd(ExceptionLogFields.ReceivedTime < DateTime.Now.Date.AddDays(1));
                return exceptionLogCollection.GetDbCount(filter);
            }
            catch
            {
                return (0L);
            }
        }

        public static int GetDaysSupportRequests()
        {
            SupportIssueCollection supportIssueCollection = new SupportIssueCollection();
            try
            {
                PredicateExpression filter = new PredicateExpression(SupportIssueFields.CreateTime  >= DateTime.Now.Date);
                filter.AddWithAnd(SupportIssueFields.CreateTime < DateTime.Now.Date.AddDays(1));
                return supportIssueCollection.GetDbCount(filter);
            }
            catch
            {
                return 0;
            }
        }

        public static Boolean IsAnUpdateNeeded()
        {
            try
            {
				//UpdateStatusEntity updateStatusEntity = new UpdateStatusEntity(GlobalSettings.UpdateStatusTypes.EPIC_OPS_UPDATE);
				//if(updateStatusEntity.IsNew)
				//{
				//    updateStatusEntity.UpdateTypeId = GlobalSettings.UpdateStatusTypes.EPIC_OPS_UPDATE;
				//    updateStatusEntity.StatusValue = "false";
				//    updateStatusEntity.Save();
				//    return false;
				//}
				//Boolean returnValue = Convert.ToBoolean(updateStatusEntity.StatusValue);
				//// Reset the value if true
				//if (returnValue)
				//{
				//    updateStatusEntity.StatusValue = "false";
				//    updateStatusEntity.Save();
				//}
				//return (returnValue);
            	return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
