extern alias CurrentAPI;

using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using EPICCentral.Utilities.DataLayer;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using V0100 = CurrentAPI::EPICCentralServiceAPI.REST;	// Map alias in DLL reference to an import alias.

namespace EPICCentral.REST.v0100.Scanning
{
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class PatientService : VersionService
	{
		public override ServiceProperties GetProperties()
		{
			return new ServiceProperties { Version = "v0100", Url = "patients" };
		}

		[WebGet(UriTemplate = "guid={guid}")]
		public V0100.Objects.Patient Get(string guid)
		{
			DeviceEntity device = GetDevice();

			if (device.DeviceState != DeviceState.Active)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.DEVICE_STATE_INVALID, HttpStatusCode.NotAcceptable);

			PatientEntity patientEntity = PatientUtils.GetByUid(guid);
			if (patientEntity == null)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.PATIENT_NOT_FOUND, HttpStatusCode.NotFound);

			return new V0100.Objects.Patient
			       	{
			       			PatientId = patientEntity.PatientId,
			       			Guid = patientEntity.UniqueIdentifier,
			       			FirstName = patientEntity.FirstName,
			       			LastName = patientEntity.LastName,
			       			MiddleInitial = patientEntity.MiddleInitial,
			       			PhoneNumber = patientEntity.PhoneNumber,
			       			EmailAddress = patientEntity.EmailAddress,
			       			BirthDate = patientEntity.BirthDate,
			       			Gender = ConvertGender(patientEntity.Gender)
			       	};
		}

		[WebInvoke(UriTemplate = "", Method = "POST")]
		public V0100.Objects.Patient Add(V0100.Objects.Patient patient)
		{
			DeviceEntity device = GetDevice();

			if (device.DeviceState != DeviceState.Active)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.DEVICE_STATE_INVALID, HttpStatusCode.NotAcceptable);

			PatientEntity patientEntity = PatientUtils.GetByUid(patient.Guid);
			patient.PatientId = patientEntity == null
								? PatientUtils.Create(patient.Guid,
													  patient.FirstName,
													  patient.LastName,
													  patient.MiddleInitial,
													  patient.PhoneNumber,
													  patient.EmailAddress,
													  patient.BirthDate,
													  ConvertGender(patient.Gender),
													  device.LocationId)
								: patientEntity.PatientId;

			return patient;
		}

		[WebInvoke(UriTemplate = "", Method = "PUT")]
		public void Update(V0100.Objects.Patient patient)
		{
			DeviceEntity device = GetDevice();

			if (device.DeviceState != DeviceState.Active)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.DEVICE_STATE_INVALID, HttpStatusCode.NotAcceptable);

			if (!PatientUtils.Update(patient.Guid, patient.FirstName, patient.LastName, patient.MiddleInitial, patient.PhoneNumber, patient.EmailAddress, patient.BirthDate, ConvertGender(patient.Gender)))
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.PATIENT_NOT_FOUND, HttpStatusCode.NotFound);
		}

		private static V0100.Objects.Gender ConvertGender(Gender gender)
		{
			switch (gender)
			{
			case Gender.Female:
				return V0100.Objects.Gender.Female;
			case Gender.Male:
				return V0100.Objects.Gender.Male;
			default:
				return V0100.Objects.Gender.NotSelected;
			}
		}

		private static Gender ConvertGender(V0100.Objects.Gender gender)
		{
			switch (gender)
			{
			case V0100.Objects.Gender.Female:
				return Gender.Female;
			case V0100.Objects.Gender.Male:
				return Gender.Male;
			default:
				return Gender.NotSelected;
			}
		}
	}
}