using System;
using System.Data;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using EPICCentralLibrary.Utilities;

namespace EPICCentralLibrary.Messaging
{
    public static class MessageUtils
    {
        public const Int16 MESSAGE_TYPE_ERROR = 1;
        public const Int16 MESSAGE_TYPE_WARNING = 2;
        public const Int16 MESSAGE_TYPE_INFO = 3;

        public static Boolean CreateMessage(string title, string body, MessageType type, int deviceId)
        {
            var transaction = new Transaction(IsolationLevel.ReadCommitted, "create message");

            try
            {
                var messageEntity = new MessageEntity {MessageType = type, Title = title, Body = body, CreateTime = DateTime.Now, StartTime = DateTime.Now};
                transaction.Add(messageEntity);
                messageEntity.Save();

                var deviceMessage = new DeviceMessageEntity {DeviceId = deviceId, MessageId = messageEntity.MessageId};
                transaction.Add(deviceMessage);
                deviceMessage.Save();

                transaction.Commit();

                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Loggers.LogException(GlobalSettings.SYSTEM_DAEMON_USER_ID, ex);
                return false;
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public static Boolean DeleteMessage(long messageId)
        {
            try
            {
                MessageEntity messageEntity = new MessageEntity(messageId);
                messageEntity.Delete();
                return true;
            }
            catch (Exception ex)
            {
                Loggers.LogException(GlobalSettings.SYSTEM_DAEMON_USER_ID, ex);
                return false;
            }
        }


    }
}
