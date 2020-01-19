using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPICCentralServiceAPI.REST.Objects
{
	/// <summary>
	/// A message to be displayed to users of a client.
	/// </summary>
	public class Message
	{
		/// <summary>
		/// The ID of the message on the server.
		/// This ID is assigned by the database when the message is created.
		/// </summary>
		public long MessageId { get; set; }

		/// <summary>
		/// The type of message, <see cref="MessageType"/> enumeration.
		/// </summary>
		public MessageType Type { get; set; }

		/// <summary>
		/// The title of the message.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// The body of the message.
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// The time when the message was created.
		/// </summary>
		public DateTime CreateTime { get; set; }

		/// <summary>
		/// The time after which the message can be displayed.
		/// </summary>
		public DateTime StartTime { get; set; }

		/// <summary>
		/// The time after which the message can no longer be displayed.
		/// </summary>
		public DateTime? EndTime { get; set; }
	}

	/// <summary>
	/// Collection of <see cref="Message"/> instances.
	/// </summary>
	[CollectionDataContract]
	public class Messages : List<Message>
	{
		/// <summary>
		/// Construct an instance which is initially empty.
		/// </summary>
		public Messages()
		{ }

		/// <summary>
		/// Construct an instance initialized to contain the specified collection of
		/// <see cref="Message"/> instances.
		/// </summary>
		/// <param name="messages">collection of <see cref="Message"/> instances to initialize
		///		the new instance</param>
		public Messages(IEnumerable<Message> messages)
			: base(messages)
		{ }
	}

	/// <summary>
	/// Enumeration of the types of messages that can be sent to a device.
	/// </summary>
	public enum MessageType
	{
		// The integer values of this enum are stored in the database. So they must never
		// be changed unless all existing records in the database are updated to match the
		// new enum values.
		Information = 1,
		Marketing = 2,
		Sale = 3,
		Attention = 4
	}
}
