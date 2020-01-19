using System;
using EPICCentralServiceAPI.REST.Core;
using EPICCentralServiceAPI.REST.Objects;

namespace EPICCentralServiceAPI.REST.Services
{
	/// <summary>
	/// REST service interface for sending patient records to the server to be added
	/// to the central database, and for retrieving existing patient records.
	/// This class presents simple methods for getting the an existing patient record
	/// from the server and for adding a patient record to the server's database.
	/// Internally, it will apply all the plumbing necessary to invoke the service
	/// on the server and return its response.
	/// </summary>
	public class PatientService : Service
	{
		/// <summary>
		/// The URI for the patient service.
		/// Service methods extend this URI with method-specific parameters.
		/// </summary>
		/// <value>the root URI for the REST services</value>
		internal override Uri BaseUri
		{
			set
			{
				SetBaseUri(value, "patients/");
			}
		}

		/// <summary>
		/// Get the <see cref="Patient"/> record from the server for the patient identified
		/// by the specified GUID.
		/// </summary>
		/// <param name="patientGuid">the GUID that identifies the patient</param>
		/// <returns>all the properies of the patient as a <see cref="Patient"/> instance</returns>
		/// <exception cref="HttpInvocationException">thrown when any HTTP status code other than
		///		200 is returned by the server; fields in the exception hold the status code and
		///		error message returned</exception>
		/// <exception cref="InvocationException">thrown when an error occurs invoking the service
		///		on the server, prior to the service running</exception>
		/// <exception cref="MalformedUriException">thrown when a valid URI cannot be constructed
		///		from the base URI and additional relative path</exception>
		public Patient Get(string patientGuid)
		{
			return Invoke<Patient>("GET", string.Format("guid={0}", patientGuid));
		}

		/// <summary>
		/// Add a patient to the server's central database.
		/// </summary>
		/// <param name="patient">a <see cref="Patient"/> instance that contains all the properties
		///		that define the patient</param>
		/// <returns>the integer ID of the patient on the server</returns>
		/// <exception cref="HttpInvocationException">thrown when any HTTP status code other than
		///		200 is returned by the server; fields in the exception hold the status code and
		///		error message returned</exception>
		/// <exception cref="InvocationException">thrown when an error occurs invoking the service
		///		on the server, prior to the service running</exception>
		/// <exception cref="MalformedUriException">thrown when a valid URI cannot be constructed
		///		from the base URI and additional relative path</exception>
		public int Add(Patient patient)
		{
			patient = Invoke<Patient, Patient>("POST", "/", patient);
			return patient.PatientId;
		}

		/// <summary>
		/// Update a patient record in the server's central database.
		/// </summary>
		/// <param name="patient">a <see cref="Patient"/> instance that contains all the properties
		///		that define the patient, including the new property values to update</param>
		/// <exception cref="HttpInvocationException">thrown when any HTTP status code other than
		///		200 is returned by the server; fields in the exception hold the status code and
		///		error message returned</exception>
		/// <exception cref="InvocationException">thrown when an error occurs invoking the service
		///		on the server, prior to the service running</exception>
		/// <exception cref="MalformedUriException">thrown when a valid URI cannot be constructed
		///		from the base URI and additional relative path</exception>
		public void Update(Patient patient)
		{
			Invoke("PUT", "/", patient);
		}
	}
}
