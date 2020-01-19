extern alias CurrentAPI;
using System;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using EPICCentral.Utilities.DataLayer;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using V0100 = CurrentAPI::EPICCentralServiceAPI.REST;	// Map alias in DLL reference to an import alias.

namespace EPICCentral.REST.v0100.Scanning
{
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	public class TreatmentService : VersionService
	{
		public override ServiceProperties GetProperties()
		{
			return new ServiceProperties { Version = "v0100", Url = "treatments", MaxReceivedMessageSize = 1024 * 1024 };
		}

		[WebInvoke(UriTemplate = "", Method = "POST")]
		public long Add(V0100.Objects.Treatment treatment)
		{
			DeviceEntity device = GetDevice();

			if (device.DeviceState != DeviceState.Active)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.DEVICE_STATE_INVALID, HttpStatusCode.NotAcceptable);

			if (TreatmentUtils.GetByUid(treatment.Guid) != null)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.TREATMENT_INVALID, HttpStatusCode.Conflict);

			PatientEntity patient = PatientUtils.GetByUid(treatment.PatientGuid);
			if (patient == null)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.PATIENT_NOT_FOUND, HttpStatusCode.PreconditionFailed);

			CalibrationEntity calibration = CalibrationUtils.GetByUid(treatment.CalibrationGuid);
			if (calibration == null)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.CALIBRATION_NOT_FOUND, HttpStatusCode.PreconditionFailed);

			ImageSetEntity energizedImageSet = ImageSetUtils.GetByUid(treatment.EnergizedImageSetGuid);
			if (energizedImageSet == null)
				throw new WebFaultException<string>(V0100.Constants.StatusSubcode.IMAGE_SET_NOT_FOUND, HttpStatusCode.PreconditionFailed);

			ImageSetEntity fingerImageSet = null;
			if (treatment.FingerImageSetGuid != null)
			{
				fingerImageSet = ImageSetUtils.GetByUid(treatment.FingerImageSetGuid);
				if (fingerImageSet == null)
					throw new WebFaultException<string>(V0100.Constants.StatusSubcode.IMAGE_SET_NOT_FOUND, HttpStatusCode.PreconditionFailed);
			}

			// TODO: Refactor this into the utilities class.
			// Need to consider if it is worth it. The utilities classes exist to make support for
			// multiple versions easier. Unlike the other data layer objects, this is more complicated
			// and will need to be refactored differently.

			TreatmentEntity treatmentEntity = new TreatmentEntity
			                                  	{
			                                  			UniqueIdentifier = treatment.Guid,
			                                  			PatientId = patient.PatientId,
			                                  			CalibrationId = calibration.CalibrationId,
                                                        TreatmentType = (TreatmentType)Enum.Parse(typeof(TreatmentType), treatment.TreatmentType.ToString()),
			                                  			TreatmentTime = treatment.TreatmentTime,
			                                  			PerformedBy = treatment.PerformedBy,
			                                  			EnergizedImageSetId = energizedImageSet.ImageSetId,
			                                  			FingerImageSetId = fingerImageSet != null ? fingerImageSet.ImageSetId : (long?)null,
			                                  			SoftwareVersion = treatment.SoftwareVersion,
			                                  			FirmwareVersion = treatment.FirmwareVersion,
			                                  			AnalysisTime = treatment.AnalysisTime,
                                                        PatientPrescanQuestion = new PatientPrescanQuestionEntity
                                                                                     {
                                                                                         AlcoholQuestion = treatment.AlcoholQuestion,
                                                                                         WheatQuestion = treatment.WheatQuestion,
                                                                                         CaffeineQuestion = treatment.CaffeineQuestion
                                                                                     }
			                                  	};

			foreach (V0100.Objects.NBAnalysisResult result in treatment.NBAnalysisResults)
			{
				NBAnalysisResultEntity resultEntity = treatmentEntity.NBAnalysisResults.AddNew();
				resultEntity.OrganSystemId = (short)ConvertAnalysisGroup(result.NBAnalysisGroup);
				resultEntity.ResultScoreFiltered = result.ResultScoreFiltered;
				resultEntity.ResultScoreUnfiltered = result.ResultScoreUnfiltered;
				resultEntity.ProbabilityFiltered = result.ProbabilityFiltered;
				resultEntity.ProbabilityUnfiltered = result.ProbabilityUnfiltered;
			}

			foreach (V0100.Objects.AnalysisResult result in treatment.AnalysisResults)
			{
				AnalysisResultEntity resultEntity = treatmentEntity.AnalysisResults.AddNew();
				resultEntity.AnalysisTime = result.AnalysisTime;
				resultEntity.IsFiltered = result.IsFiltered;
				resultEntity.FingerDesc = result.FingerDescription;
				resultEntity.FingerType = result.FingerType;
				resultEntity.SectorNumber = result.SectorNumber;
				resultEntity.StartAngle = result.StartAngle;
				resultEntity.EndAngle = result.EndAngle;
				resultEntity.SectorArea = result.SectorArea;
				resultEntity.IntegralArea = result.IntegralArea;
				resultEntity.NormalizedArea = result.NormalizedArea;
				resultEntity.AverageIntensity = result.AverageIntensity;
				resultEntity.Entropy = result.Entropy;
				resultEntity.FormCoefficient = result.FormCoefficient;
				resultEntity.FractalCoefficient = result.FractalCoefficient;
				resultEntity.JsInteger = result.JsInteger;
				resultEntity.CenterX = result.CenterX;
				resultEntity.CenterY = result.CenterY;
				resultEntity.RadiusMin = result.RadiusMin;
				resultEntity.RadiusMax = result.RadiusMax;
				resultEntity.AngleOfRotation = result.AngleOfRotation;
				resultEntity.Form2 = result.Form2;
				resultEntity.NoiseLevel = result.NoiseLevel;
				resultEntity.BreakCoefficient = result.BreakCoefficient;
				resultEntity.SoftwareVersion = result.SoftwareVersion;
				resultEntity.AI1 = result.AI1;
				resultEntity.AI2 = result.AI2;
				resultEntity.AI3 = result.AI3;
				resultEntity.AI4 = result.AI4;
				resultEntity.Form11 = result.Form11;
				resultEntity.Form12 = result.Form12;
				resultEntity.Form13 = result.Form13;
				resultEntity.Form14 = result.Form14;
				resultEntity.RingThickness = result.RingThickness;
				resultEntity.RingIntensity = result.RingIntensity;
				resultEntity.Form2Prime = result.Form2Prime;
				resultEntity.UserName = result.UserName;
			}

			foreach (V0100.Objects.Severity severity in treatment.Severities)
			{
				SeverityEntity severityEntity = treatmentEntity.Severities.AddNew();
				severityEntity.OrganId = severity.OrganId;
				severityEntity.PhysicalRight = severity.PhysicalRight;
				severityEntity.PhysicalLeft = severity.PhysicalLeft;
				severityEntity.MentalRight = severity.MentalRight;
				severityEntity.MentalLeft = severity.MentalLeft;
			}

			foreach (V0100.Objects.CalculationDebug calculationDebug in treatment.CalculationDebugs)
			{
				CalculationDebugDataEntity calculationDebugDataEntity = treatmentEntity.CalculationDebugDatas.AddNew();
				calculationDebugDataEntity.FingerSector = calculationDebug.FingerSector;
				calculationDebugDataEntity.IsFiltered = calculationDebug.IsFiltered;
				calculationDebugDataEntity.OrganComponent = (OrganComponent)Enum.Parse(typeof(OrganComponent), calculationDebug.OrganComponent, true);
				calculationDebugDataEntity.Area = calculationDebug.Area;
				calculationDebugDataEntity.AverageIntensity = calculationDebug.AverageIntensity;
				calculationDebugDataEntity.BreakCoefficient = calculationDebug.BreakCoefficient;
				calculationDebugDataEntity.Entropy = calculationDebug.Entropy;
				calculationDebugDataEntity.NS = calculationDebug.NS;
				calculationDebugDataEntity.Fractal = calculationDebug.Fractal;
				calculationDebugDataEntity.Form = calculationDebug.Form;
				calculationDebugDataEntity.Form2 = calculationDebug.Form2;
				calculationDebugDataEntity.AI1 = calculationDebug.AI1;
				calculationDebugDataEntity.AI2 = calculationDebug.AI2;
				calculationDebugDataEntity.AI3 = calculationDebug.AI3;
				calculationDebugDataEntity.AI4 = calculationDebug.AI4;
				calculationDebugDataEntity.Form11 = calculationDebug.Form11;
				calculationDebugDataEntity.Form12 = calculationDebug.Form12;
				calculationDebugDataEntity.Form13 = calculationDebug.Form13;
				calculationDebugDataEntity.Form14 = calculationDebug.Form14;
				calculationDebugDataEntity.RingIntensity = calculationDebug.RingIntensity;
				calculationDebugDataEntity.RingThickness = calculationDebug.RingThickness;
				calculationDebugDataEntity.Form2Prime = calculationDebug.Form2Prime;
				calculationDebugDataEntity.EPICBaseScore = calculationDebug.EPICBaseScore;
				calculationDebugDataEntity.EPICBonusScore = calculationDebug.EPICBonusScore;
				calculationDebugDataEntity.EPICScore = calculationDebug.EPICScore;
				calculationDebugDataEntity.EPICScaledScore = calculationDebug.EPICScaledScore;
				calculationDebugDataEntity.EPICRank = calculationDebug.EPICRank;
				calculationDebugDataEntity.LRRank = calculationDebug.LRRank;
				calculationDebugDataEntity.LRScore = calculationDebug.LRScore;
				calculationDebugDataEntity.LRScaledScore = calculationDebug.LRScaledScore;
				calculationDebugDataEntity.SumZScore = calculationDebug.SumZScore;
			}

			treatmentEntity.Save(true);

			return treatmentEntity.TreatmentId;
		}

        private static OrganSystem ConvertAnalysisGroup(V0100.Objects.NBAnalysisGroup analysisGroup)
		{
            var name = Enum.GetName(typeof(V0100.Objects.NBAnalysisGroup), analysisGroup);
            OrganSystem organSystem;
            if (Enum.TryParse(name, true, out organSystem))
                return organSystem;
            else
                throw new Exception("No mapping found.");
            /*
            switch (analysisGroup)
            {
                case V0100.Objects.NBAnalysisGroup.Gastrointestinal:
                    return OrganSystem.Gastrointestinal;
                case V0100.Objects.NBAnalysisGroup.Hepatic:
                    return OrganSystem.Hepatic;
                case V0100.Objects.NBAnalysisGroup.Renal:
                    return OrganSystem.Renal;
                case V0100.Objects.NBAnalysisGroup.Respiratory:
                    return OrganSystem.Respiratory;
                default:
                    return OrganSystem.Cardiovascular;
            }
            */
		}
	}
}