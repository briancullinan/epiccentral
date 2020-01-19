using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPICCentralServiceAPI.REST.Objects
{
	/// <summary>
	/// The record of a device calibration performed by the client.
	/// </summary>
	public class Calibration
	{
		/// <summary>
		/// The ID of the calibration on the server.
		/// This ID is assigned by the database when the calibration record is created.
		/// When creating a <c>Calibration</c> instance, the client should leave this set
		/// to the default value.
		/// </summary>
		public long CalibrationId { get; set; }

		/// <summary>
		/// The unique ID of the calibration assigned by the client.
		/// The GUID must be unique across the entire global system.
		/// </summary>
		public string Guid { get; set; }

		/// <summary>
		/// The date and time when the calibration was peformed by the client.
		/// </summary>
		public DateTime Timestamp { get; set; }

		/// <summary>
		/// The username of the user that performed the calibration.
		/// This is a user on the client, not the server.
		/// </summary>
		public string PerformedBy { get; set; }

		/// <summary>
		/// The unique ID of the image set for the calibration.
		/// This GUID is assigned by the client when the image set is created.
		/// It must be unique across the entire global system.
		/// </summary>
		public string ImageSetGuid { get; set; }

		/// <summary>
		/// The unique ID of the device that performed the calibration.
		/// This GUID is assigned when the device registers.
		/// It must be unique across the entire global system.
		/// This ID can change on a ClearView client if the actual scanner is replaced
		/// with a new one.
		/// Passing up this ID with the calibration record allows uploading data for a
		/// previously attached scanner.
		/// </summary>
		public string DeviceGuid { get; set; }
	}

	/// <summary>
	/// Collection of <see cref="Calibration"/> instances.
	/// </summary>
	[CollectionDataContract]
	public class Calibrations : List<Calibration>
	{
		/// <summary>
		/// Construct an instance which is initially empty.
		/// </summary>
		public Calibrations()
		{ }

		/// <summary>
		/// Construct an instance initialized to contain the specified collection of
		/// <see cref="Calibration"/> instances.
		/// </summary>
		/// <param name="calibrations">collection of <see cref="Calibration"/> instances to
		///		initialize the new instance</param>
		public Calibrations(IEnumerable<Calibration> calibrations)
			: base(calibrations)
		{ }
	}
}
