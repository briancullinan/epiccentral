using System;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.CollectionClasses;
using EPICCentralDL.HelperClasses;
using EPICCentralDL.RelationClasses;
using EPICCentralLibrary.DataHelpers;
using System.Collections;
using EPICCentralLibrary.Utilities;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentralLibrary.Webservices.Tracking
{
    public class TrackingImpl
    {
        private static readonly string[] StatusValues = new[] { "ClearView Ping", "New Purchase", "Start Scan", "End Scan", "Load Scan", "Start Calibration", "End Calibration", "Application Timeout", "Login Completed", "Logout Completed", "Exception Created", "Support Request Logged", "User Created", "Subject Created", "Sync App Ping" };

        public class MessageTransport
        {
            public Decimal MessageId;
            public string MessageTitle;
            public string MessageBody;
            public DateTime MessageTime;
            public Int16 MessageType;
        }

        public enum TrackableActions
        {
            ClearViewPing, // 0
            NewPurchase, // 1
            StartScan, // 2
            EndScan, // 3
            LoadScan, // 4
            StartCalibration, // 5
            EndCalibration, // 6
            ApplicationTimeout, // 7
            LoginCompleted, // 8
            LogoutCompleted, // 9
            ExceptionCreated, // 10
            SupportRequestLogged, // 11
            UserCreated, // 12
            PatientCreated, // 13
            SyncAppPing //14
        }

        public class ExceptionAdditionalInfo
        {
            public Decimal CustomersLogExceptionId;
            public DateTime ExceptionDateTime;
            public string ExceptionUser;
            public string ExceptionFormName;
            public string ExceptionMachineName;
            public string ExceptionMachineOS;
            public string ExceptionApplicationVersion;
            public string ExceptionCLRVersion;
            public string ExceptionMemoryUsage;
        }

        public static Boolean IsAliveImpl()
        {
            // check database status
            try
            {
                SystemSettingEntity is_enabled = new SystemSettingEntity("Enabled");
                // check site enabled
                if (is_enabled.IsNew || is_enabled.Value == "1")
                    return true;
            }
            catch
            {
                return false;
            }
            return false;
        }

        public static Boolean SendCurrentStatusImpl(string deviceUniqueIdentifier, string locationUniqueKey, TrackableActions currentStatusCode, DateTime actionDateTime)
        {
            int deviceId = KeyToIdHelpers.ConvertDeviceKey(deviceUniqueIdentifier);
            int locationId = KeyToIdHelpers.ConvertLocationKey(locationUniqueKey);
            // Update the device
            DeviceEntity ecDeviceEntity = new DeviceEntity(deviceId);
            if (!ecDeviceEntity.IsNew)
            {
                ecDeviceEntity.CurrentStatus = StatusValues[(int)currentStatusCode];
                ecDeviceEntity.LastReportTime = DateTime.UtcNow;
                ecDeviceEntity.Save();
            }
            // Update the active Customers table for EPIC Ops View
            ActiveOrganizationEntity ecActiveCustomersEntity = new ActiveOrganizationEntity();
            ecActiveCustomersEntity.ActivityTypeId = (short)currentStatusCode;
            ecActiveCustomersEntity.LocationId = locationId;
            ecActiveCustomersEntity.ActivityTime = actionDateTime;  // Should be sent in through the request
            ecActiveCustomersEntity.Save();
            return true;
        }


        public static Boolean GetCurrentMessagesImpl(string deviceUniqueKeyVar, ref ArrayList messages)
        {
            ArrayList returnValues = new ArrayList();
            int deviceId = KeyToIdHelpers.ConvertDeviceKey(deviceUniqueKeyVar);
            if (deviceId != -1)
            {
                DeviceMessageCollection deviceMessages = new DeviceMessageCollection();
                PredicateExpression filter = new PredicateExpression(DeviceMessageFields.DeviceId == deviceId);
                deviceMessages.GetMulti(filter);

                foreach (DeviceMessageEntity deviceMessage in deviceMessages)
                {
                    if (deviceMessage.DeliveryTime == null)
                    {
                        MessageEntity message = deviceMessage.Message;
                        if (message.IsActive)
                        {
                            MessageTransport messageTransport = new MessageTransport
                                                                    {
                                                                       MessageId = message.MessageId,
                                                                       MessageType = (short)message.MessageType,
                                                                       MessageTitle = message.Title,
                                                                       MessageBody = message.Body,
                                                                       MessageTime = message.CreateTime
                                                                    };
                            returnValues.Add(messageTransport);
                        }

                        deviceMessage.DeliveryTime = DateTime.UtcNow;
                        deviceMessage.Save();
                    }
                }

                messages = returnValues;
                return true;
            }

            return false;
        }

        public static Boolean DeleteAMessageImpl(long messageId, int organizationId)
        {
            // Make sure customer owns the message, thus preventing customers from possibly 
            // deleting other customers messages.
            OrganizationEntity organization = new OrganizationEntity(organizationId);
            foreach (LocationEntity location in organization.Locations)
            {
                DeviceCollection devices = new DeviceCollection();
                devices.GetMulti(new PredicateExpression(DeviceFields.LocationId == location.LocationId));
                foreach (DeviceEntity device in devices)
                {
                    DeviceMessageCollection deviceMessages = new DeviceMessageCollection();
                    PredicateExpression filter = new PredicateExpression {DeviceMessageFields.DeviceId == device.DeviceId, DeviceMessageFields.MessageId == messageId};
                	deviceMessages.GetMulti(filter);
                    if (deviceMessages.Count > 0)
                    {
                        DeviceMessageEntity deviceMessage = deviceMessages[0];
                        deviceMessage.DeliveryTime = DateTime.UtcNow;
                        deviceMessage.Save();
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool SendExceptionImpl(string deviceUniqueKey, Exception ex, ExceptionAdditionalInfo exInfo)
        {
            ExceptionLogEntity ecExceptionLogEntity = new ExceptionLogEntity();
            //ecExceptionLogEntity.CustomerId = customerId;
            ecExceptionLogEntity.DeviceId = KeyToIdHelpers.ConvertDeviceKey(deviceUniqueKey);
            ecExceptionLogEntity.RemoteExceptionLogId = (long)exInfo.CustomersLogExceptionId;
            //ecExceptionLogEntity.CustomerExceptionObject = ObjectSerialization.ObjectToByteArray(ex);
            ecExceptionLogEntity.Title = String.Empty;
            ecExceptionLogEntity.Message = ex.Message;
            ecExceptionLogEntity.StackTrace = ex.StackTrace;
            //ecExceptionLogEntity.CustomerExceptionInnerStackTrace = ex.InnerException.StackTrace;
            ecExceptionLogEntity.LogTime = exInfo.ExceptionDateTime;
            ecExceptionLogEntity.User = exInfo.ExceptionUser;
            ecExceptionLogEntity.FormName = exInfo.ExceptionFormName;
            ecExceptionLogEntity.MachineName = exInfo.ExceptionMachineName;
            ecExceptionLogEntity.MachineOS = exInfo.ExceptionMachineOS;
            ecExceptionLogEntity.ApplicationVersion = exInfo.ExceptionApplicationVersion;
            ecExceptionLogEntity.CLRVersion = exInfo.ExceptionCLRVersion;
            ecExceptionLogEntity.MemoryUsage = exInfo.ExceptionMemoryUsage;
            ecExceptionLogEntity.ReceivedTime = DateTime.Now;
            ecExceptionLogEntity.Save();
            return true;
        }
    }
}
