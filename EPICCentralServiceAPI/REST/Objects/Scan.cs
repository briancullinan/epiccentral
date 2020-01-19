using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPICCentralServiceAPI.REST.Objects
{
	/// <summary>
	/// The set of keys required to validate that a device can scan.
	/// </summary>
	public class ValidationKeys
	{
		/// <summary>
		/// The GUID for the location where the device is installed.
		/// </summary>
		public string LocationGuid { get; set; }

		/// <summary>
		/// The GUID for the customer that owns/leases the device.
		/// </summary>
		public string OrganizationGuid { get; set; }
	}

	/// <summary>
	/// The record of a scan.
	/// </summary>
	public class ScanRecord
	{
		/// <summary>
		/// The type of scan performed.
		/// </summary>
		public ScanType ScanType { get; set; }

		/// <summary>
		/// The date and time the scan started.
		/// Must be UTC value.
		/// </summary>
		public DateTime ScanStartTime { get; set; }
	}

	/// <summary>
	/// Collection of <see cref="ScanRecord"/> instances
	/// </summary>
	[CollectionDataContract]
	public class ScanRecords : List<ScanRecord>
	{
		/// <summary>
		/// Construct an instance which is initially empty.
		/// </summary>
		public ScanRecords()
		{ }

		/// <summary>
		/// Construct an instance initialized to contain the specified collection of
		/// <see cref="ScanRecord"/> instances.
		/// </summary>
		/// <param name="scanRecords">collection of <see cref="ScanRecord"/> instances to
		///		initialize the new instance</param>
		public ScanRecords(IEnumerable<ScanRecord> scanRecords)
			: base(scanRecords)
		{ }
	}

	/// <summary>
	/// Set of scan counts for a device.
	/// </summary>
	public class ScanCount
	{
		/// <summary>
		/// The number of scans completed by a device.
		/// </summary>
		public int ScansCompleted { get; set; }

		/// <summary>
		/// The number of scans available to be used by a device.
		/// </summary>
		public int ScansAvailable { get; set; }
	}

	/// <summary>
	/// Enumeration of the types of scans that can be performed.
	/// </summary>
	public enum ScanType
	{
		// The integer values of this enum are stored in the database. So they must never
		// be changed unless all existing records in the database are updated to match the
		// new enum values.
		ClearViewScan = 1
	}
}
