using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPICCentralServiceAPI.REST.Objects
{
	/// <summary>
	/// The record of a patient who has been scanned one or more times.
	/// </summary>
	public class Patient
	{
		/// <summary>
		/// The ID of the patient on the server.
		/// This ID is assigned by the database when the patient record is created.
		/// When creating a <c>Patient</c> instance, the client should leave this set
		/// to the default value.
		/// </summary>
		public int PatientId { get; set; }

		/// <summary>
		/// The unique ID of the patient assigned by the client.
		/// The GUID must be unique across the entire global system.
		/// </summary>
		public string Guid { get; set; }

		/// <summary>
		/// The patient's first name (given name).
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// The patient's last name (surname).
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// The patient's intitial for his/her middle name.
		/// </summary>
		public string MiddleInitial { get; set; }

		/// <summary>
		/// The patient's primary telephone number.
		/// </summary>
		public string PhoneNumber { get; set; }

		/// <summary>
		/// The patient's email address.
		/// </summary>
		public string EmailAddress { get; set; }

		/// <summary>
		/// The patient's birth date.
		/// Only the date portion is significant; the time portion is ignored.
		/// </summary>
		public DateTime BirthDate { get; set; }

		/// <summary>
		/// The patient's gender.
		/// </summary>
		public Gender Gender { get; set; }
	}

	/// <summary>
	/// Collection of <see cref="Patient"/> instances.
	/// </summary>
	[CollectionDataContract]
	public class Patients : List<Patient>
	{
		/// <summary>
		/// Construct an instance which is initially empty.
		/// </summary>
		public Patients()
		{ }

		/// <summary>
		/// Construct an instance initialized to contain the specified collection of
		/// <see cref="Patient"/> instances.
		/// </summary>
		/// <param name="patients">collection of <see cref="Patient"/> instances to initialize
		///		the new instance</param>
		public Patients(IEnumerable<Patient> patients)
			: base(patients)
		{ }
	}

	/// <summary>
	/// Enumeration of possible gender settings.
	/// </summary>
	public enum Gender
	{
		// The integer values of this enum are stored in the database. So they must never
		// be changed unless all existing records in the database are updated to match the
		// new enum values.
		NotSelected = 0,
		Female = 1,
		Male = 2
	}
}
