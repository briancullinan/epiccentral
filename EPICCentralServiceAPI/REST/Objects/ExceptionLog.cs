using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPICCentralServiceAPI.REST.Objects
{
	/// <summary>
	/// The set of information that makes of an exception log entry.
	/// </summary>
	public class ExceptionLog
	{
		/// <summary>
		/// The ID of the exception log on the server.
		/// This ID is assigned by the database when the exception log record is created.
		/// When creating an <c>ExceptionLog</c> instance, the client to leave this set
		/// to the default value.
		/// </summary>
		public long ExceptionLogId { get; set; }

		/// <summary>
		/// The ID of the device on the server.
		/// This ID is assigned by the database when the device record is created.
		/// When creating an <c>ExceptionLog</c> instance, the client to leave this set
		/// to the default value.
		/// </summary>
		public int DeviceId { get; set; }

		/// <summary>
		/// The ID of the exception on the client.
		/// The server stores this as an opaque value; it is never modified by the server.
		/// </summary>
		public long RemoteExceptionLogId { get; set; }

		/// <summary>
		/// The title of the exception.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// The message associated with the exception.
		/// </summary>
		public string Message { get; set; }

		/// <summary>
		/// The dump of the exception's stack trace.
		/// </summary>
		public string StackTrace { get; set; }

		/// <summary>
		/// The date and time on the client when the exception occurred.
		/// Must be a UTC value.
		/// </summary>
		public DateTime LogTime { get; set; }

		/// <summary>
		/// The name of the user, from the client's perspective.
		/// </summary>
		public string User { get; set; }

		/// <summary>
		/// The name of the form on the client where the exception occurred.
		/// </summary>
		public string FormName { get; set; }

		/// <summary>
		/// The name of the client machine.
		/// </summary>
		public string MachineName { get; set; }

		/// <summary>
		/// The client machine's operating system.
		/// </summary>
		public string MachineOS { get; set; }

		/// <summary>
		/// The version of the client application which produced the exception.
		/// </summary>
		public string ApplicationVersion { get; set; }

		/// <summary>
		/// The version of the client's common language runtime (CLR).
		/// </summary>
		public string CLRVersion { get; set; }

		/// <summary>
		/// The snapshot memory usage on the client when the exception occurred.
		/// </summary>
		public string MemoryUsage { get; set; }

		/// <summary>
		/// The date and time when the exception log is received by the server.
		/// Must be a UTC value.
		/// When creating an <c>ExceptionLog</c> instance, the client to leave this set
		/// to the default value.
		/// </summary>
		public DateTime ReceivedTime { get; set; }
	}

	/// <summary>
	/// Collection of <see cref="ExceptionLog"/> instances.
	/// </summary>
	[CollectionDataContract]
	public class ExceptionLogs : List<ExceptionLog>
	{
		/// <summary>
		/// Construct an instance which is initially empty.
		/// </summary>
		public ExceptionLogs()
		{}

		/// <summary>
		/// Construct an instance initialized to contain the specified collection of
		/// <see cref="ExceptionLog"/> instances.
		/// </summary>
		/// <param name="exceptionLogs">collection of <see cref="ExceptionLog"/> instances
		///		to initialize the new instance</param>
		public ExceptionLogs(IEnumerable<ExceptionLog> exceptionLogs)
			: base(exceptionLogs)
		{}
	}
}
