extern alias CurrentAPI;

using System;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web.Mvc;
using EPICCentral.Controllers;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using V0100 = CurrentAPI::EPICCentralServiceAPI.REST;	// Map alias in DLL reference to an import alias.

namespace EPICCentral.REST.v0100.Logging
{
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class EventService : VersionService
	{
		public override ServiceProperties GetProperties()
		{
			return new ServiceProperties { Version = "v0100", Url = "events" };
		}

		// NOT CURRENTLY USED.
		[WebGet(UriTemplate = "{id}")]
		public V0100.Objects.Event Get(string id)
		{
			DeviceEntity device = GetDevice();

			DeviceEventEntity deviceEvent = GetEvent(id);

			if (deviceEvent.DeviceId != device.DeviceId)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.DEVICE_INVALID, HttpStatusCode.Forbidden);

			return new V0100.Objects.Event {EventId = deviceEvent.DeviceEventId, Type = ConvertEventType(deviceEvent.EventType), Time = deviceEvent.EventTime};
		}

		[WebGet(UriTemplate = "count={count}")]
		public V0100.Objects.Events GetCollection(string count)
		{
			// TODO: For later implementation.
			// Need to understand more about the requirements for this, if there are any. It should probably
			// specify a starting ID and some number of events to return. There could be thousands, so some
			// way to page is necessary.
			throw new WebFaultException<string>("Coming soon to your favorite cloud service!", HttpStatusCode.NotImplemented);
		}

		[WebInvoke(UriTemplate = "", Method = "POST")]
		public V0100.Objects.Event Create(V0100.Objects.Event eventt)
		{
			DeviceEntity device = GetDevice();

			DeviceEventEntity deviceEvent = new DeviceEventEntity {DeviceId = device.DeviceId, EventType = ConvertEventType(eventt.Type), EventTime = eventt.Time, ReceivedTime = DateTime.UtcNow};
			deviceEvent.Save();

			eventt.EventId = deviceEvent.DeviceEventId;

			// TODO: This is presently necessary to cause the map to update.
            OperationController.Update();

			// Might want to change this, or at least do some cleanup.
			device.CurrentStatus = eventt.Type.ToString();
			device.LastReportTime = DateTime.UtcNow;
			device.Save();

			return eventt;
		}

		private static DeviceEventEntity GetEvent(string id)
		{
			long eventId;

			if (long.TryParse(id, out eventId))
			{
				DeviceEventEntity deviceEvent = new DeviceEventEntity(eventId);
				if (!deviceEvent.IsNew)
					return deviceEvent;

				throw new WebFaultException<string>("Item not found", HttpStatusCode.NotFound);
			}

			throw new WebFaultException<string>("Input id must be integer", HttpStatusCode.BadRequest);
		}

		private static V0100.Objects.EventType ConvertEventType(EventType eventType)
		{
			switch (eventType)
			{
			case EventType.Ping:
				return V0100.Objects.EventType.Ping;
			case EventType.ScanBegin:
				return V0100.Objects.EventType.ScanBegin;
			case EventType.ScanEnd:
				return V0100.Objects.EventType.ScanEnd;
			case EventType.CalibrationBegin:
				return V0100.Objects.EventType.CalibrationBegin;
			case EventType.CalibrationEnd:
				return V0100.Objects.EventType.CalibrationEnd;
			case EventType.ApplicationBegin:
				return V0100.Objects.EventType.ApplicationBegin;
			case EventType.ApplicationEnd:
				return V0100.Objects.EventType.ApplicationEnd;
			default:
				return V0100.Objects.EventType.Ping;
			}
		}

		private static EventType ConvertEventType(V0100.Objects.EventType eventType)
		{
			switch (eventType)
			{
			case V0100.Objects.EventType.Ping:
				return EventType.Ping;
			case V0100.Objects.EventType.ScanBegin:
				return EventType.ScanBegin;
			case V0100.Objects.EventType.ScanEnd:
				return EventType.ScanEnd;
			case V0100.Objects.EventType.CalibrationBegin:
				return EventType.CalibrationBegin;
			case V0100.Objects.EventType.CalibrationEnd:
				return EventType.CalibrationEnd;
			case V0100.Objects.EventType.ApplicationBegin:
				return EventType.ApplicationBegin;
			case V0100.Objects.EventType.ApplicationEnd:
				return EventType.ApplicationEnd;
			default:
				return EventType.Ping;
			}
		}
	}
}