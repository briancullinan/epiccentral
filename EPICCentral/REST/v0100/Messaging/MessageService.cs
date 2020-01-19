extern alias CurrentAPI;

using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using EPICCentralDL;
using EPICCentralDL.CollectionClasses;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using EPICCentralDL.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using V0100 = CurrentAPI::EPICCentralServiceAPI.REST;	// Map alias in DLL reference to an import alias.

namespace EPICCentral.REST.v0100.Messaging
{
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class MessageService : VersionService
	{
		public override ServiceProperties GetProperties()
		{
			return new ServiceProperties { Version = "v0100", Url = "messages" };
		}

		[WebGet(UriTemplate = "")]
		public V0100.Objects.Messages GetCollection()
		{
			DeviceEntity device = GetDevice();

			// Snapshot current time so it's the same for all uses in the method.
			DateTime now = DateTime.UtcNow;

			// Create WHERE clause as predicate. We want all MessageEnitity instances
			// where StartTime is now or past and EndTime is either null or future, but
			// only those that have not been delivered to the device (and deleted).
			// Must join through the DeviceMessageEntity.
			var messageCollection = (IQueryable<DeviceMessageEntity>)new LinqMetaData().DeviceMessage;
		    messageCollection = messageCollection.Where(x =>
		                                                x.DeviceId == device.DeviceId &&
		                                                x.DeliveryTime == null &&
                                                        x.Message.IsActive &&
		                                                x.Message.StartTime <= DateTime.UtcNow &&
		                                                (x.Message.EndTime == null || x.Message.EndTime >= DateTime.UtcNow));


			// Create output collection.
			V0100.Objects.Messages messages = new V0100.Objects.Messages();
		    messages.AddRange(messageCollection
		                          // Do the query. Join Message on DeviceMessage via MessageId. Prefetch
		                          // the MessageEntity instances because each is required to be used.
		                          .Select(deviceMessage => deviceMessage.Message).ToList()
		                          .Select(message => new V0100.Objects.Message
		                                                 {
		                                                     MessageId = message.MessageId,
		                                                     Type = ConvertMessageType(message.MessageType),
		                                                     Title = message.Title,
		                                                     Body = message.Body,
		                                                     CreateTime = message.CreateTime,
		                                                     StartTime = message.StartTime,
		                                                     EndTime = message.EndTime
		                                                 }));

			// Mark each DeviceMessage as delivered and deleted.
			foreach (DeviceMessageEntity deviceMessage in messageCollection)
			{
				deviceMessage.DeliveryTime = now;
				deviceMessage.Save();
			}

			// Return collection.
			return messages;
		}

		private static V0100.Objects.MessageType ConvertMessageType(MessageType messageType)
		{
			switch (messageType)
			{
			case MessageType.Attention:
				return V0100.Objects.MessageType.Attention;
			case MessageType.Marketing:
				return V0100.Objects.MessageType.Marketing;
			case MessageType.Sale:
				return V0100.Objects.MessageType.Sale;
			default:
				return V0100.Objects.MessageType.Information;
			}
		}
	}
}