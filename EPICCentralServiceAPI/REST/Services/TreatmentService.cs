using System;
using EPICCentralServiceAPI.REST.Core;
using EPICCentralServiceAPI.REST.Objects;

namespace EPICCentralServiceAPI.REST.Services
{
	/// <summary>
	/// REST service interface for sending treatment records to the server to be added to the
	/// central database.
	/// This class present simple methods for adding treatment records to the server's database
	/// along with corresponding calibration and patient records, if necessary.
	/// Internally, it will apply all the plumbing necessary to invoke the service
	/// on the server and return its response.
	/// </summary>
	public class TreatmentService : Service
	{
		/// <summary>
		/// The URI for the treatment service.
		/// Service methods extend this URI with method-specific parameters.
		/// </summary>
		/// <value>the root URI for the REST services</value>
		internal override Uri BaseUri
		{
			set
			{
				SetBaseUri(value, "treatments/");
			}
		}

		/// <summary>
		/// <para>
		/// Add a treatment to the central database.
		/// Use this method to add a treatment along with patient associated with the treatment and
		/// the calibration associated with the treatment.
		/// </para><para>
		/// A treatment consists of a <see cref="Treatment"/> instance that defines the properties of
		/// the treatment record and two image sets, an energized image set and a finger image set.
		/// Each image set is encapsulated as an <see cref="ImageSetBlob"/> instance which provides a
		/// way to read the binary data of the image set and the GUID that identifies the image set.
		/// This method also accepts a <see cref="Patient"/> instance that defines the patient
		/// associated with the treatment and a <see cref="Calibration"/> instance that defines the
		/// calibration associated with the treatment.
		/// It will send both the calibration and patient to the server to create the corresponding
		/// records in the central database before the treatment is sent.
		/// </para><para>
		/// Before attempting to send a request to the server, this method will validate that the
		/// GUIDs in the <code>Treatment</code> instance that refer to the energized image set and
		/// the finger image set match the corresponding GUIDs in the <code>ImageSetBlob</code>s.
		/// It will also validate that the GUID in the <code>Treatment</code> that refers to the patient
		/// matches the GUID in the <code>Patient</code> instance.
		/// And it will validate that the GUID in the <code>Calibration</code> that refers to the
		/// calibration matches the GUID in the <code>Calibration</code> instance and that the GUID in
		/// the <see cref="Calibration"/> that refers to the calibration image set matches the GUID in
		/// the corresponding <code>ImageSetBlob</code> that contains the calibration image set.
		/// If the GUIDs do not match as expected, an exception is thrown.
		/// If they match, each of the image sets is sent to the server and then the treatment
		/// record is sent.
		/// </para>
		/// </summary>
		/// <param name="treatment">a <see cref="Treatment"/> instance that contains all the properties
		///		that define the treatment</param>
		/// <param name="patient">a <see cref="Patient"/> instance that contains all the properties
		///		that define the patient</param>
		/// <param name="calibration">a <see cref="Calibration"/> instance that contains all the properties
		///		of the calibration</param>
		/// <param name="calibrationImageSet">an <see cref="ImageSetBlob"/> that contains the images of the
		///		image set and the GUID that identifies the set</param>
		/// <param name="energizedImageSet">an <see cref="ImageSetBlob"/> that contains the images of the
		///		energized image set and the GUID that identifies the set</param>
		/// <param name="fingerImageSet">an <see cref="ImageSetBlob"/> that contains the images of the
		///		finger image set and the GUID that identifies the set</param>
		/// <returns>the ID of the treatment record from the server's database</returns>
		/// <exception cref="InvalidArgumentException">if either of the sets of GUIDs do not match as
		///		required</exception>
		/// <exception cref="HttpInvocationException">when any HTTP status code other than 200 (OK)
		///		is returned by the server; fields in the exception hold the status code and error
		///		message returned</exception>
		/// <exception cref="InvocationException">when an error occurs invoking the service on the
		///		server, prior to the service running</exception>
		/// <exception cref="MalformedUriException">thrown when a valid URI cannot be constructed from
		///		the base URI and additional relative path</exception>
		public long Add(Treatment treatment, Patient patient, Calibration calibration, ImageSetBlob calibrationImageSet, ImageSetBlob energizedImageSet, ImageSetBlob fingerImageSet)
		{
			ValidateGuids(treatment, patient);
			ValidateGuids(treatment, calibration);
			ValidateGuids(calibration, calibrationImageSet);
			ValidateGuids(treatment, energizedImageSet, fingerImageSet);

			CalibrationService calibrationService = Gateway.GetService<CalibrationService>();
			calibrationService.Add(calibration, calibrationImageSet);

			return Add(treatment, patient, energizedImageSet, fingerImageSet);
		}

		/// <summary>
		/// <para>
		/// Add a treatment to the central database.
		/// Use this method to add a treatment when the calibration associated with the treatment has
		/// not be sent to the server but the patient associated with the treatment has already been
		/// successfully sent to the server.
		/// </para><para>
		/// A treatment consists of a <see cref="Treatment"/> instance that defines the properties of
		/// the treatment record and two image sets, an energized image set and a finger image set.
		/// Each image set is encapsulated as an <see cref="ImageSetBlob"/> instance which provides a
		/// way to read the binary data of the image set and the GUID that identifies the image set.
		/// This method also accepts a <see cref="Calibration"/> instance that defines the calibration
		/// associated with the treatment.
		/// It will be sent to the server to create the calibration record before the treatment is sent.
		/// </para><para>
		/// Before attempting to send a request to the server, this method will validate that the
		/// GUIDs in the <code>Treatment</code> instance that refer to the energized image set and
		/// the finger image set match the corresponding GUIDs in the <code>ImageSetBlob</code>s.
		/// It will also validate that the GUID in the <code>Calibration</code> that refers to the
		/// calibration matches the GUID in the <code>Calibration</code> instance and that the GUID in
		/// the <see cref="Calibration"/> that refers to the calibration image set matches the GUID in
		/// the corresponding <code>ImageSetBlob</code> that contains the calibration image set.
		/// If the GUIDs do not match as expected, an exception is thrown.
		/// If they match, each of the image sets is sent to the server and then the treatment
		/// record is sent.
		/// </para>
		/// </summary>
		/// <param name="treatment">a <see cref="Treatment"/> instance that contains all the properties
		///		that define the treatment</param>
		/// <param name="calibration">a <see cref="Calibration"/> instance that contains all the properties
		///		of the calibration</param>
		/// <param name="calibrationImageSet">an <see cref="ImageSetBlob"/> that contains the images of the
		///		image set and the GUID that identifies the set</param>
		/// <param name="energizedImageSet">an <see cref="ImageSetBlob"/> that contains the images of the
		///		energized image set and the GUID that identifies the set</param>
		/// <param name="fingerImageSet">an <see cref="ImageSetBlob"/> that contains the images of the
		///		finger image set and the GUID that identifies the set</param>
		/// <returns>the ID of the treatment record from the server's database</returns>
		/// <exception cref="InvalidArgumentException">if either of the sets of GUIDs do not match as
		///		required</exception>
		/// <exception cref="HttpInvocationException">when any HTTP status code other than 200 (OK)
		///		is returned by the server; fields in the exception hold the status code and error
		///		message returned</exception>
		/// <exception cref="InvocationException">when an error occurs invoking the service on the
		///		server, prior to the service running</exception>
		/// <exception cref="MalformedUriException">thrown when a valid URI cannot be constructed from
		///		the base URI and additional relative path</exception>
		public long Add(Treatment treatment, Calibration calibration, ImageSetBlob calibrationImageSet, ImageSetBlob energizedImageSet, ImageSetBlob fingerImageSet)
		{
			ValidateGuids(treatment, calibration);
			ValidateGuids(calibration, calibrationImageSet);
			ValidateGuids(treatment, energizedImageSet, fingerImageSet);

			CalibrationService calibrationService = Gateway.GetService<CalibrationService>();
			calibrationService.Add(calibration, calibrationImageSet);

			return Add(treatment, energizedImageSet, fingerImageSet);
		}

		/// <summary>
		/// <para>
		/// Add a treatment to the central database.
		/// Use this method to add a treatment when the patient associated with the treatment has
		/// not be sent to the server but the calibration associated with the treatment has
		/// already been successfully sent to the server.
		/// </para><para>
		/// A treatment consists of a <see cref="Treatment"/> instance that defines the properties of
		/// the treatment record and two image sets, an energized image set and a finger image set.
		/// Each image set is encapsulated as an <see cref="ImageSetBlob"/> instance which provides a
		/// way to read the binary data of the image set and the GUID that identifies the image set.
		/// This method also accepts a <see cref="Patient"/> instance that defines the patient
		/// associated with the treatment.
		/// It will be sent to the server to create the patient record before the treatment is sent.
		/// </para><para>
		/// Before attempting to send a request to the server, this method will validate that the
		/// GUIDs in the <code>Treatment</code> instance that refer to the energized image set and
		/// the finger image set match the corresponding GUIDs in the <code>ImageSetBlob</code>s.
		/// It will also validate that the GUID in the <code>Treatment</code> that refers to the patient
		/// matches the GUID in the <code>Patient</code> instance.
		/// If the GUIDs do not match as expected, an exception is thrown.
		/// If they match, each of the image sets is sent to the server and then the treatment
		/// record is sent.
		/// </para>
		/// </summary>
		/// <param name="treatment">a <see cref="Treatment"/> instance that contains all the properties
		///		that define the treatment</param>
		/// <param name="patient">a <see cref="Patient"/> instance that contains all the properties
		///		that define the patient</param>
		/// <param name="energizedImageSet">an <see cref="ImageSetBlob"/> that contains the images of the
		///		energized image set and the GUID that identifies the set</param>
		/// <param name="fingerImageSet">an <see cref="ImageSetBlob"/> that contains the images of the
		///		finger image set and the GUID that identifies the set</param>
		/// <returns>the ID of the treatment record from the server's database</returns>
		/// <exception cref="InvalidArgumentException">if either of the sets of GUIDs do not match as
		///		required</exception>
		/// <exception cref="HttpInvocationException">when any HTTP status code other than 200 (OK)
		///		is returned by the server; fields in the exception hold the status code and error
		///		message returned</exception>
		/// <exception cref="InvocationException">when an error occurs invoking the service on the
		///		server, prior to the service running</exception>
		/// <exception cref="MalformedUriException">thrown when a valid URI cannot be constructed from
		///		the base URI and additional relative path</exception>
		public long Add(Treatment treatment, Patient patient, ImageSetBlob energizedImageSet, ImageSetBlob fingerImageSet)
		{
			ValidateGuids(treatment, patient);
			ValidateGuids(treatment, energizedImageSet, fingerImageSet);

			PatientService patientService = Gateway.GetService<PatientService>();
			patientService.Add(patient);

			return Add(treatment, energizedImageSet, fingerImageSet);
		}

		/// <summary>
		/// <para>
		/// Add a treatment to the central database.
		/// Use this method to add a treatment when the patient and calibration associated with the
		/// treatment have already been successfully sent to the server.
		/// </para><para>
		/// A treatment consists of a <see cref="Treatment"/> instance that defines the properties of
		/// the treatment record and two image sets, an energized image set and a finger image set.
		/// Each image set is encapsulated as an <see cref="ImageSetBlob"/> instance which provides a
		/// way to read the binary data of the image set and the GUID that identifies the image set.
		/// The finger image set is optional; if there is none, the input parameter will be null and
		/// the corresponding GUID parameter in the <code>Treatment</code> must be null.
		/// </para><para>
		/// Before attempting to send a request to the server, this method will validate that the
		/// GUIDs in the <code>Treatment</code> instance that refer to the energized image set and
		/// the finger image set match the corresponding GUIDs in the <code>ImageSetBlob</code>s.
		/// If the GUIDs do not match as expected, an exception is thrown.
		/// If they match, each of the image sets is sent to the server and then the treatment
		/// record is sent.
		/// </para>
		/// </summary>
		/// <param name="treatment">a <see cref="Treatment"/> instance that contains all the properties
		///		that define the treatment</param>
		/// <param name="energizedImageSet">an <see cref="ImageSetBlob"/> that contains the images of the
		///		energized image set and the GUID that identifies the set</param>
		/// <param name="fingerImageSet">an <see cref="ImageSetBlob"/> that contains the images of the
		///		finger image set and the GUID that identifies the set</param>
		/// <returns>the ID of the treatment record from the server's database</returns>
		/// <exception cref="InvalidArgumentException">if either of the sets of GUIDs do not match as
		///		required</exception>
		/// <exception cref="HttpInvocationException">when any HTTP status code other than 200 (OK)
		///		is returned by the server; fields in the exception hold the status code and error
		///		message returned</exception>
		/// <exception cref="InvocationException">when an error occurs invoking the service on the
		///		server, prior to the service running</exception>
		/// <exception cref="MalformedUriException">thrown when a valid URI cannot be constructed from
		///		the base URI and additional relative path</exception>
		public long Add(Treatment treatment, ImageSetBlob energizedImageSet, ImageSetBlob fingerImageSet)
		{
			ValidateGuids(treatment, energizedImageSet, fingerImageSet);

			ImageService imageService = Gateway.GetService<ImageService>();
			imageService.Add(energizedImageSet);
			if (fingerImageSet != null)
				imageService.Add(fingerImageSet);

			return Invoke<Treatment, long>("POST", "/", treatment);
		}

		/// <summary>
		/// Validate that the GUID in the <see cref="Treatment"/> that refers to the calibration matches
		/// the GUID in the <see cref="Calibration"/> instance that defines the calibration record.
		/// An exception will be thrown if the GUIDs do not match as expected.
		/// If they match, the method simply returns.
		/// </summary>
		/// <param name="treatment">a <see cref="Treatment"/> instance that contains all the properties
		///		that define the treatment</param>
		/// <param name="calibration">a <see cref="Calibration"/> instance that contains all the properties
		///		that define the calibration</param>
		/// <exception cref="InvalidArgumentException">if the GUIDs do not match as required</exception>
		private static void ValidateGuids(Treatment treatment, Calibration calibration)
		{
			if (treatment.CalibrationGuid != calibration.Guid)
				throw new InvalidArgumentException("Two GUIDs for the calibration do not match");
		}

		/// <summary>
		/// Validate that the GUID in the <see cref="Treatment"/> that refers to the patient matches the
		/// GUID in the <see cref="Patient"/> instance that defines the patient record.
		/// An exception will be thrown if the GUIDs do not match as expected.
		/// If they match, the method simply returns.
		/// </summary>
		/// <param name="treatment">a <see cref="Treatment"/> instance that contains all the properties
		///		that define the treatment</param>
		/// <param name="patient">a <see cref="Patient"/> instance that contains all the properties
		///		that define the patient</param>
		/// <exception cref="InvalidArgumentException">if the GUIDs do not match as required</exception>
		private static void ValidateGuids(Treatment treatment, Patient patient)
		{
			if (treatment.PatientGuid != patient.Guid)
				throw new InvalidArgumentException("Two GUIDs for the patient do not match");
		}

		/// <summary>
		/// <para>
		/// Validate that the GUIDs in the <see cref="Treatment"/> instance that refer to the
		/// energized and finger image sets match the GUIDs in the corresponding <see cref="ImageSetBlob"/>
		/// instances that containing the image sets.
		/// An exception will be thrown if the GUIDs do not match as expected.
		/// If they match, the method simply returns.
		/// </para><para>
		/// The finger image set is optional.
		/// If there is no finger image set, both the input <code>ImageSetBlob</code> for the finger
		/// image set and the corresponding GUID in the <code>Treatment</code> must be null.
		/// </para>
		/// </summary>
		/// <param name="treatment">a <see cref="Treatment"/> instance that contains all the properties
		///		that define the treatment</param>
		/// <param name="energizedImageSet">an <see cref="ImageSetBlob"/> that contains the images of the
		///		energized image set and the GUID that identifies the set</param>
		/// <param name="fingerImageSet">an <see cref="ImageSetBlob"/> that contains the images of the
		///		finger image set and the GUID that identifies the set</param>
		/// <exception cref="InvalidArgumentException">if either of the sets of GUIDs do not match as
		///		required</exception>
		private static void ValidateGuids(Treatment treatment, ImageSetBlob energizedImageSet, ImageSetBlob fingerImageSet)
		{
			if (treatment.EnergizedImageSetGuid != energizedImageSet.Guid)
				throw new InvalidArgumentException("Two GUIDs for the energized image set do not match");

			if (fingerImageSet == null && treatment.FingerImageSetGuid == null)
				return;

			if (fingerImageSet == null ||treatment.FingerImageSetGuid != fingerImageSet.Guid)
				throw new InvalidArgumentException("Two GUIDs for the finger image set do not match");
		}

		/// <summary>
		/// Validate that the GUID in the <see cref="Calibration"/> instance that refers to the calibration
		/// image set matches the GUID in the <see cref="ImageSetBlob"/> that contains the iamges.
		/// An exception is throw if they do not match.
		/// If they match, the method simply returns.
		/// </summary>
		/// <param name="calibration">a <see cref="Calibration"/> instance that contains all the properties
		///		of the calibration</param>
		/// <param name="calibrationImageSet">an <see cref="ImageSetBlob"/> that contains the images of the
		///		image set and the GUID that identifies the set</param>
		/// <exception cref="InvalidArgumentException">if the GUIDs do not match as required</exception>
		private static void ValidateGuids(Calibration calibration, ImageSetBlob calibrationImageSet)
		{
			if (calibration.ImageSetGuid != calibrationImageSet.Guid)
				throw new InvalidArgumentException("Two GUIDs for the calibration and its image set do not match");
		}
	}
}
