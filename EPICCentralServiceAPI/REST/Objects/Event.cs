using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPICCentralServiceAPI.REST.Objects
{
	/// <summary>
	/// The record of an event.
	/// </summary>
	public class Event
	{
		/// <summary>
		/// The ID of the event on the server.
		/// This ID is assigned by the database when the event record is created.
		/// When creating an <c>Event</c> instance, the client should leave this set
		/// to the default value.
		/// </summary>
		public long EventId { get; set; }

		/// <summary>
		/// The type of event that has occurred.
		/// </summary>
		public EventType Type { get; set; }

		/// <summary>
		/// The date and time when the event occurred.
		/// Must be a UTC value.
		/// </summary>
		public DateTime Time { get; set; }
	}

	/// <summary>
	/// Collection of <see cref="Event"/> instances.
	/// </summary>
	[CollectionDataContract]
	public class Events : List<Event>
	{
		/// <summary>
		/// Construct an instance which is initially empty.
		/// </summary>
		public Events()
		{ }

		/// <summary>
		/// Construct an instance initialized to contain the specified collection of
		/// <see cref="Event"/> instances.
		/// </summary>
		/// <param name="events">collection of <see cref="Event"/> instances to initialize
		///		the new instance</param>
		public Events(IEnumerable<Event> events)
			: base(events)
		{ }
	}

	/// <summary>
	/// Enumeration of the types of events that can be tracked.
	/// </summary>
	public enum EventType
	{
		// The integer values of this enum are stored in the database. So they must never
		// be changed unless all existing records in the database are updated to match the
		// new enum values.
		Ping = 1,
		ScanBegin = 2,
		ScanEnd = 3,
		CalibrationBegin = 4,
		CalibrationEnd = 5,
		ApplicationBegin = 6,
		ApplicationEnd = 7
	}
}
