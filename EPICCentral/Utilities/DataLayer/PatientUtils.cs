using System;
using EPICCentralDL.CollectionClasses;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentral.Utilities.DataLayer
{
	public static class PatientUtils
	{
		public static PatientEntity GetByUid(string patientUid)
		{
			PatientCollection patients = new PatientCollection();
			patients.GetMulti(new PredicateExpression(PatientFields.UniqueIdentifier == patientUid));
			return patients.Count > 0 ? patients[0] : null;
		}

		public static int Create(string patientUid, string firstName, string lastName, string middleInitial, string phoneNumber, string emailAddress, DateTime birthDate, Gender gender, int locationId)
		{
			PatientEntity patient = new PatientEntity
										{
											UniqueIdentifier = patientUid,
											FirstName = firstName,
											LastName = lastName,
											MiddleInitial = middleInitial,
											PhoneNumber = phoneNumber,
											EmailAddress = emailAddress,
											BirthDate = birthDate,
											Gender = gender,
											LocationId = locationId
										};
			patient.Save();

			return patient.PatientId;
		}

		public static bool Update(string patientUid, string firstName, string lastName, string middleInitial, string phoneNumber, string emailAddress, DateTime birthDate, Gender gender)
		{
			PatientEntity patientEntity = GetByUid(patientUid);
			if (patientEntity == null)
				return false;

			patientEntity.FirstName = firstName;
			patientEntity.LastName = lastName;
			patientEntity.MiddleInitial = middleInitial;
			patientEntity.PhoneNumber = phoneNumber;
			patientEntity.EmailAddress = emailAddress;
			patientEntity.BirthDate = birthDate;
			patientEntity.Gender = gender;

			patientEntity.Save();

			return true;
		}
	}
}