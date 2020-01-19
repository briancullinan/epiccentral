///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentralDL.HelperClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	/// <summary>Singleton implementation of the FieldInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the FieldInfoProviderBase class is threadsafe.</remarks>
	internal static class FieldInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IFieldInfoProvider _providerInstance = new FieldInfoProviderCore();
		#endregion

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static FieldInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the FieldInfoProviderCore</summary>
		/// <returns>Instance of the FieldInfoProvider.</returns>
		public static IFieldInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the FieldInfoProvider. Used by singleton wrapper.</summary>
	internal class FieldInfoProviderCore : FieldInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="FieldInfoProviderCore"/> class.</summary>
		internal FieldInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores.</summary>
		private void Init()
		{
			this.InitClass( (45 + 0));
			InitAccountRestrictionEntityInfos();
			InitActiveOrganizationEntityInfos();
			InitActivityTypeEntityInfos();
			InitAnalysisResultEntityInfos();
			InitApplicationEntityInfos();
			InitAuditEntityInfos();
			InitCalculationDebugDataEntityInfos();
			InitCalibrationEntityInfos();
			InitContactEntityInfos();
			InitCreditCardEntityInfos();
			InitDeviceEntityInfos();
			InitDeviceEventEntityInfos();
			InitDeviceMessageEntityInfos();
			InitDeviceStateTrackingEntityInfos();
			InitExceptionLogEntityInfos();
			InitImageCacheEntityInfos();
			InitImageSetEntityInfos();
			InitLicenseOrganSystemEntityInfos();
			InitLocationEntityInfos();
			InitMessageEntityInfos();
			InitNBAnalysisResultEntityInfos();
			InitOrganEntityInfos();
			InitOrganizationEntityInfos();
			InitOrganSystemEntityInfos();
			InitOrganSystemOrganEntityInfos();
			InitPatientEntityInfos();
			InitPatientPrescanQuestionEntityInfos();
			InitPurchaseHistoryEntityInfos();
			InitRoleEntityInfos();
			InitScanHistoryEntityInfos();
			InitScanRateEntityInfos();
			InitSessionEntityInfos();
			InitSeverityEntityInfos();
			InitSupportAreaEntityInfos();
			InitSupportIssueEntityInfos();
			InitSystemSettingEntityInfos();
			InitTreatmentEntityInfos();
			InitUpdateStatusEntityInfos();
			InitUserEntityInfos();
			InitUserAccountRestrictionEntityInfos();
			InitUserAssignedLocationEntityInfos();
			InitUserCreditCardEntityInfos();
			InitUserRoleEntityInfos();
			InitUserSaltEntityInfos();
			InitUserSettingEntityInfos();

			this.ConstructElementFieldStructures(InheritanceInfoProviderSingleton.GetInstance());
		}

		/// <summary>Inits AccountRestrictionEntity's FieldInfo objects</summary>
		private void InitAccountRestrictionEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(AccountRestrictionFieldIndex), "AccountRestrictionEntity");
			this.AddElementFieldInfo("AccountRestrictionEntity", "AccountRestrictionId", typeof(System.Int32), true, false, true, false,  (int)AccountRestrictionFieldIndex.AccountRestrictionId, 0, 0, 10);
			this.AddElementFieldInfo("AccountRestrictionEntity", "AccountRestrictionType", typeof(EPICCentralDL.Customization.AccountRestrictionType), false, false, false, false,  (int)AccountRestrictionFieldIndex.AccountRestrictionType, 0, 0, 5);
			this.AddElementFieldInfo("AccountRestrictionEntity", "RestrictionKey", typeof(System.String), false, false, false, false,  (int)AccountRestrictionFieldIndex.RestrictionKey, 128, 0, 0);
			this.AddElementFieldInfo("AccountRestrictionEntity", "EmailAddress", typeof(System.String), false, false, false, false,  (int)AccountRestrictionFieldIndex.EmailAddress, 128, 0, 0);
			this.AddElementFieldInfo("AccountRestrictionEntity", "Parameters", typeof(System.String), false, false, false, true,  (int)AccountRestrictionFieldIndex.Parameters, 128, 0, 0);
			this.AddElementFieldInfo("AccountRestrictionEntity", "IPAddress", typeof(System.String), false, false, false, false,  (int)AccountRestrictionFieldIndex.IPAddress, 32, 0, 0);
			this.AddElementFieldInfo("AccountRestrictionEntity", "CreatedBy", typeof(Nullable<System.Int32>), false, false, false, true,  (int)AccountRestrictionFieldIndex.CreatedBy, 0, 0, 10);
			this.AddElementFieldInfo("AccountRestrictionEntity", "CreationTime", typeof(System.DateTime), false, false, false, false,  (int)AccountRestrictionFieldIndex.CreationTime, 0, 0, 0);
			this.AddElementFieldInfo("AccountRestrictionEntity", "RemovalTime", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)AccountRestrictionFieldIndex.RemovalTime, 0, 0, 0);
			this.AddElementFieldInfo("AccountRestrictionEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)AccountRestrictionFieldIndex.IsActive, 0, 0, 3);
		}
		/// <summary>Inits ActiveOrganizationEntity's FieldInfo objects</summary>
		private void InitActiveOrganizationEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(ActiveOrganizationFieldIndex), "ActiveOrganizationEntity");
			this.AddElementFieldInfo("ActiveOrganizationEntity", "ActiveOrganizationId", typeof(System.Int32), true, false, true, false,  (int)ActiveOrganizationFieldIndex.ActiveOrganizationId, 0, 0, 10);
			this.AddElementFieldInfo("ActiveOrganizationEntity", "LocationId", typeof(System.Int32), false, true, false, false,  (int)ActiveOrganizationFieldIndex.LocationId, 0, 0, 10);
			this.AddElementFieldInfo("ActiveOrganizationEntity", "ActivityTypeId", typeof(System.Int16), false, true, false, false,  (int)ActiveOrganizationFieldIndex.ActivityTypeId, 0, 0, 5);
			this.AddElementFieldInfo("ActiveOrganizationEntity", "ActivityTime", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)ActiveOrganizationFieldIndex.ActivityTime, 0, 0, 0);
		}
		/// <summary>Inits ActivityTypeEntity's FieldInfo objects</summary>
		private void InitActivityTypeEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(ActivityTypeFieldIndex), "ActivityTypeEntity");
			this.AddElementFieldInfo("ActivityTypeEntity", "ActivityTypeId", typeof(System.Int16), true, false, false, false,  (int)ActivityTypeFieldIndex.ActivityTypeId, 0, 0, 5);
			this.AddElementFieldInfo("ActivityTypeEntity", "Name", typeof(System.String), false, false, false, false,  (int)ActivityTypeFieldIndex.Name, 40, 0, 0);
			this.AddElementFieldInfo("ActivityTypeEntity", "Description", typeof(System.String), false, false, false, true,  (int)ActivityTypeFieldIndex.Description, 80, 0, 0);
		}
		/// <summary>Inits AnalysisResultEntity's FieldInfo objects</summary>
		private void InitAnalysisResultEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(AnalysisResultFieldIndex), "AnalysisResultEntity");
			this.AddElementFieldInfo("AnalysisResultEntity", "AnalysisResultId", typeof(System.Int64), true, false, true, false,  (int)AnalysisResultFieldIndex.AnalysisResultId, 0, 0, 19);
			this.AddElementFieldInfo("AnalysisResultEntity", "TreatmentId", typeof(System.Int64), false, true, false, false,  (int)AnalysisResultFieldIndex.TreatmentId, 0, 0, 19);
			this.AddElementFieldInfo("AnalysisResultEntity", "AnalysisTime", typeof(System.DateTime), false, false, false, false,  (int)AnalysisResultFieldIndex.AnalysisTime, 0, 0, 0);
			this.AddElementFieldInfo("AnalysisResultEntity", "IsFiltered", typeof(System.Boolean), false, false, false, false,  (int)AnalysisResultFieldIndex.IsFiltered, 0, 0, 3);
			this.AddElementFieldInfo("AnalysisResultEntity", "FingerDesc", typeof(System.String), false, false, false, true,  (int)AnalysisResultFieldIndex.FingerDesc, 50, 0, 0);
			this.AddElementFieldInfo("AnalysisResultEntity", "FingerType", typeof(System.Int32), false, false, false, false,  (int)AnalysisResultFieldIndex.FingerType, 0, 0, 10);
			this.AddElementFieldInfo("AnalysisResultEntity", "SectorNumber", typeof(System.Int32), false, false, false, false,  (int)AnalysisResultFieldIndex.SectorNumber, 0, 0, 10);
			this.AddElementFieldInfo("AnalysisResultEntity", "StartAngle", typeof(System.Int32), false, false, false, false,  (int)AnalysisResultFieldIndex.StartAngle, 0, 0, 10);
			this.AddElementFieldInfo("AnalysisResultEntity", "EndAngle", typeof(System.Int32), false, false, false, false,  (int)AnalysisResultFieldIndex.EndAngle, 0, 0, 10);
			this.AddElementFieldInfo("AnalysisResultEntity", "SectorArea", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.SectorArea, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "IntegralArea", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.IntegralArea, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "NormalizedArea", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.NormalizedArea, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "AverageIntensity", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.AverageIntensity, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "Entropy", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.Entropy, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "FormCoefficient", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.FormCoefficient, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "FractalCoefficient", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.FractalCoefficient, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "JsInteger", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.JsInteger, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "CenterX", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.CenterX, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "CenterY", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.CenterY, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "RadiusMin", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.RadiusMin, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "RadiusMax", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.RadiusMax, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "AngleOfRotation", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.AngleOfRotation, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "Form2", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.Form2, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "NoiseLevel", typeof(System.Int32), false, false, false, false,  (int)AnalysisResultFieldIndex.NoiseLevel, 0, 0, 10);
			this.AddElementFieldInfo("AnalysisResultEntity", "BreakCoefficient", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.BreakCoefficient, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "SoftwareVersion", typeof(System.String), false, false, false, true,  (int)AnalysisResultFieldIndex.SoftwareVersion, 20, 0, 0);
			this.AddElementFieldInfo("AnalysisResultEntity", "AI1", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.AI1, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "AI2", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.AI2, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "AI3", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.AI3, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "AI4", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.AI4, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "Form11", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.Form11, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "Form12", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.Form12, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "Form13", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.Form13, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "Form14", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.Form14, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "RingThickness", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.RingThickness, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "RingIntensity", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.RingIntensity, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "Form2Prime", typeof(System.Double), false, false, false, false,  (int)AnalysisResultFieldIndex.Form2Prime, 0, 0, 38);
			this.AddElementFieldInfo("AnalysisResultEntity", "UserName", typeof(System.String), false, false, false, false,  (int)AnalysisResultFieldIndex.UserName, 20, 0, 0);
		}
		/// <summary>Inits ApplicationEntity's FieldInfo objects</summary>
		private void InitApplicationEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(ApplicationFieldIndex), "ApplicationEntity");
			this.AddElementFieldInfo("ApplicationEntity", "AppId", typeof(System.Int32), true, false, false, false,  (int)ApplicationFieldIndex.AppId, 0, 0, 10);
			this.AddElementFieldInfo("ApplicationEntity", "AppName", typeof(System.String), false, false, false, false,  (int)ApplicationFieldIndex.AppName, 280, 0, 0);
		}
		/// <summary>Inits AuditEntity's FieldInfo objects</summary>
		private void InitAuditEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(AuditFieldIndex), "AuditEntity");
			this.AddElementFieldInfo("AuditEntity", "AuditId", typeof(System.Int64), true, false, true, false,  (int)AuditFieldIndex.AuditId, 0, 0, 19);
			this.AddElementFieldInfo("AuditEntity", "CreatedBy", typeof(System.String), false, false, false, false,  (int)AuditFieldIndex.CreatedBy, 80, 0, 0);
			this.AddElementFieldInfo("AuditEntity", "CreatedDate", typeof(System.DateTime), false, false, false, false,  (int)AuditFieldIndex.CreatedDate, 0, 0, 0);
			this.AddElementFieldInfo("AuditEntity", "Field", typeof(System.String), false, false, false, false,  (int)AuditFieldIndex.Field, 128, 0, 0);
			this.AddElementFieldInfo("AuditEntity", "Key", typeof(System.String), false, false, false, false,  (int)AuditFieldIndex.Key, 256, 0, 0);
			this.AddElementFieldInfo("AuditEntity", "NewData", typeof(System.String), false, false, false, true,  (int)AuditFieldIndex.NewData, 2147483647, 0, 0);
			this.AddElementFieldInfo("AuditEntity", "OldData", typeof(System.String), false, false, false, true,  (int)AuditFieldIndex.OldData, 2147483647, 0, 0);
			this.AddElementFieldInfo("AuditEntity", "Table", typeof(System.String), false, false, false, false,  (int)AuditFieldIndex.Table, 128, 0, 0);
		}
		/// <summary>Inits CalculationDebugDataEntity's FieldInfo objects</summary>
		private void InitCalculationDebugDataEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(CalculationDebugDataFieldIndex), "CalculationDebugDataEntity");
			this.AddElementFieldInfo("CalculationDebugDataEntity", "CalculationDebugDataId", typeof(System.Int64), true, false, true, false,  (int)CalculationDebugDataFieldIndex.CalculationDebugDataId, 0, 0, 19);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "TreatmentId", typeof(System.Int64), false, true, false, false,  (int)CalculationDebugDataFieldIndex.TreatmentId, 0, 0, 19);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "FingerSector", typeof(System.String), false, false, false, false,  (int)CalculationDebugDataFieldIndex.FingerSector, 20, 0, 0);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "IsFiltered", typeof(System.Boolean), false, false, false, false,  (int)CalculationDebugDataFieldIndex.IsFiltered, 0, 0, 0);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "OrganComponent", typeof(EPICCentralDL.Customization.OrganComponent), false, false, false, false,  (int)CalculationDebugDataFieldIndex.OrganComponent, 0, 0, 5);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "Area", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.Area, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "AverageIntensity", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.AverageIntensity, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "BreakCoefficient", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)CalculationDebugDataFieldIndex.BreakCoefficient, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "Entropy", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.Entropy, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "NS", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.NS, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "Fractal", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.Fractal, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "Form", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.Form, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "Form2", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.Form2, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "AI1", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.AI1, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "AI2", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.AI2, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "AI3", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.AI3, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "AI4", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.AI4, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "Form11", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.Form11, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "Form12", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.Form12, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "Form13", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.Form13, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "Form14", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.Form14, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "RingIntensity", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.RingIntensity, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "RingThickness", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.RingThickness, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "Form2Prime", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.Form2Prime, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "EPICBaseScore", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.EPICBaseScore, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "EPICBonusScore", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.EPICBonusScore, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "EPICScore", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.EPICScore, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "EPICScaledScore", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.EPICScaledScore, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "EPICRank", typeof(System.Int32), false, false, false, false,  (int)CalculationDebugDataFieldIndex.EPICRank, 0, 0, 10);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "LRRank", typeof(System.Int32), false, false, false, false,  (int)CalculationDebugDataFieldIndex.LRRank, 0, 0, 10);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "LRScore", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.LRScore, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "LRScaledScore", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.LRScaledScore, 0, 4, 16);
			this.AddElementFieldInfo("CalculationDebugDataEntity", "SumZScore", typeof(System.Decimal), false, false, false, false,  (int)CalculationDebugDataFieldIndex.SumZScore, 0, 4, 16);
		}
		/// <summary>Inits CalibrationEntity's FieldInfo objects</summary>
		private void InitCalibrationEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(CalibrationFieldIndex), "CalibrationEntity");
			this.AddElementFieldInfo("CalibrationEntity", "CalibrationId", typeof(System.Int64), true, false, true, false,  (int)CalibrationFieldIndex.CalibrationId, 0, 0, 19);
			this.AddElementFieldInfo("CalibrationEntity", "DeviceId", typeof(System.Int32), false, true, false, false,  (int)CalibrationFieldIndex.DeviceId, 0, 0, 10);
			this.AddElementFieldInfo("CalibrationEntity", "UniqueIdentifier", typeof(System.String), false, false, false, false,  (int)CalibrationFieldIndex.UniqueIdentifier, 48, 0, 0);
			this.AddElementFieldInfo("CalibrationEntity", "CalibrationTime", typeof(System.DateTime), false, false, false, false,  (int)CalibrationFieldIndex.CalibrationTime, 0, 0, 0);
			this.AddElementFieldInfo("CalibrationEntity", "PerformedBy", typeof(System.String), false, false, false, false,  (int)CalibrationFieldIndex.PerformedBy, 80, 0, 0);
			this.AddElementFieldInfo("CalibrationEntity", "ImageSetId", typeof(System.Int64), false, true, false, false,  (int)CalibrationFieldIndex.ImageSetId, 0, 0, 19);
			this.AddElementFieldInfo("CalibrationEntity", "ReceivedTime", typeof(System.DateTime), false, false, false, false,  (int)CalibrationFieldIndex.ReceivedTime, 0, 0, 0);
		}
		/// <summary>Inits ContactEntity's FieldInfo objects</summary>
		private void InitContactEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(ContactFieldIndex), "ContactEntity");
			this.AddElementFieldInfo("ContactEntity", "ContactId", typeof(System.Int32), true, false, true, false,  (int)ContactFieldIndex.ContactId, 0, 0, 10);
			this.AddElementFieldInfo("ContactEntity", "OrganizationId", typeof(System.Int32), false, true, false, false,  (int)ContactFieldIndex.OrganizationId, 0, 0, 10);
			this.AddElementFieldInfo("ContactEntity", "FirstName", typeof(System.String), false, false, false, false,  (int)ContactFieldIndex.FirstName, 50, 0, 0);
			this.AddElementFieldInfo("ContactEntity", "LastName", typeof(System.String), false, false, false, false,  (int)ContactFieldIndex.LastName, 50, 0, 0);
			this.AddElementFieldInfo("ContactEntity", "EmailAddress", typeof(System.String), false, false, false, false,  (int)ContactFieldIndex.EmailAddress, 128, 0, 0);
			this.AddElementFieldInfo("ContactEntity", "PhoneNumber", typeof(System.String), false, false, false, false,  (int)ContactFieldIndex.PhoneNumber, 20, 0, 0);
		}
		/// <summary>Inits CreditCardEntity's FieldInfo objects</summary>
		private void InitCreditCardEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(CreditCardFieldIndex), "CreditCardEntity");
			this.AddElementFieldInfo("CreditCardEntity", "CreditCardId", typeof(System.Int32), true, false, true, false,  (int)CreditCardFieldIndex.CreditCardId, 0, 0, 10);
			this.AddElementFieldInfo("CreditCardEntity", "AuthorizeId", typeof(System.String), false, false, false, false,  (int)CreditCardFieldIndex.AuthorizeId, 20, 0, 0);
			this.AddElementFieldInfo("CreditCardEntity", "FirstName", typeof(System.String), false, false, false, false,  (int)CreditCardFieldIndex.FirstName, 50, 0, 0);
			this.AddElementFieldInfo("CreditCardEntity", "LastName", typeof(System.String), false, false, false, false,  (int)CreditCardFieldIndex.LastName, 50, 0, 0);
			this.AddElementFieldInfo("CreditCardEntity", "AccountNumber", typeof(System.String), false, false, false, true,  (int)CreditCardFieldIndex.AccountNumber, 4, 0, 0);
			this.AddElementFieldInfo("CreditCardEntity", "Address", typeof(System.String), false, false, false, true,  (int)CreditCardFieldIndex.Address, 64, 0, 0);
		}
		/// <summary>Inits DeviceEntity's FieldInfo objects</summary>
		private void InitDeviceEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(DeviceFieldIndex), "DeviceEntity");
			this.AddElementFieldInfo("DeviceEntity", "DeviceId", typeof(System.Int32), true, false, true, false,  (int)DeviceFieldIndex.DeviceId, 0, 0, 10);
			this.AddElementFieldInfo("DeviceEntity", "LocationId", typeof(System.Int32), false, true, false, false,  (int)DeviceFieldIndex.LocationId, 0, 0, 10);
			this.AddElementFieldInfo("DeviceEntity", "UniqueIdentifier", typeof(System.String), false, false, false, false,  (int)DeviceFieldIndex.UniqueIdentifier, 48, 0, 0);
			this.AddElementFieldInfo("DeviceEntity", "AuthenticationToken", typeof(System.Byte[]), false, false, false, true,  (int)DeviceFieldIndex.AuthenticationToken, 64, 0, 0);
			this.AddElementFieldInfo("DeviceEntity", "UidQualifier", typeof(System.Int32), false, false, true, false,  (int)DeviceFieldIndex.UidQualifier, 0, 0, 10);
			this.AddElementFieldInfo("DeviceEntity", "DeviceState", typeof(EPICCentralDL.Customization.DeviceState), false, false, false, false,  (int)DeviceFieldIndex.DeviceState, 0, 0, 5);
			this.AddElementFieldInfo("DeviceEntity", "SerialNumber", typeof(System.String), false, false, false, false,  (int)DeviceFieldIndex.SerialNumber, 40, 0, 0);
			this.AddElementFieldInfo("DeviceEntity", "DateIssued", typeof(System.DateTime), false, false, false, false,  (int)DeviceFieldIndex.DateIssued, 0, 0, 0);
			this.AddElementFieldInfo("DeviceEntity", "RevisionLevel", typeof(System.String), false, false, false, false,  (int)DeviceFieldIndex.RevisionLevel, 5, 0, 0);
			this.AddElementFieldInfo("DeviceEntity", "ScansAvailable", typeof(System.Int32), false, false, false, false,  (int)DeviceFieldIndex.ScansAvailable, 0, 0, 10);
			this.AddElementFieldInfo("DeviceEntity", "ScansUsed", typeof(System.Int32), false, false, false, false,  (int)DeviceFieldIndex.ScansUsed, 0, 0, 10);
			this.AddElementFieldInfo("DeviceEntity", "CurrentStatus", typeof(System.String), false, false, false, false,  (int)DeviceFieldIndex.CurrentStatus, 50, 0, 0);
			this.AddElementFieldInfo("DeviceEntity", "LastReportTime", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)DeviceFieldIndex.LastReportTime, 0, 0, 0);
		}
		/// <summary>Inits DeviceEventEntity's FieldInfo objects</summary>
		private void InitDeviceEventEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(DeviceEventFieldIndex), "DeviceEventEntity");
			this.AddElementFieldInfo("DeviceEventEntity", "DeviceEventId", typeof(System.Int64), true, false, false, false,  (int)DeviceEventFieldIndex.DeviceEventId, 0, 0, 19);
			this.AddElementFieldInfo("DeviceEventEntity", "DeviceId", typeof(System.Int32), false, true, false, false,  (int)DeviceEventFieldIndex.DeviceId, 0, 0, 10);
			this.AddElementFieldInfo("DeviceEventEntity", "EventType", typeof(EPICCentralDL.Customization.EventType), false, false, false, false,  (int)DeviceEventFieldIndex.EventType, 0, 0, 5);
			this.AddElementFieldInfo("DeviceEventEntity", "EventTime", typeof(System.DateTime), false, false, false, false,  (int)DeviceEventFieldIndex.EventTime, 0, 0, 0);
			this.AddElementFieldInfo("DeviceEventEntity", "ReceivedTime", typeof(System.DateTime), false, false, false, false,  (int)DeviceEventFieldIndex.ReceivedTime, 0, 0, 0);
		}
		/// <summary>Inits DeviceMessageEntity's FieldInfo objects</summary>
		private void InitDeviceMessageEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(DeviceMessageFieldIndex), "DeviceMessageEntity");
			this.AddElementFieldInfo("DeviceMessageEntity", "DeviceId", typeof(System.Int32), true, true, false, false,  (int)DeviceMessageFieldIndex.DeviceId, 0, 0, 10);
			this.AddElementFieldInfo("DeviceMessageEntity", "MessageId", typeof(System.Int64), true, true, false, false,  (int)DeviceMessageFieldIndex.MessageId, 0, 0, 19);
			this.AddElementFieldInfo("DeviceMessageEntity", "DeliveryTime", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)DeviceMessageFieldIndex.DeliveryTime, 0, 0, 0);
		}
		/// <summary>Inits DeviceStateTrackingEntity's FieldInfo objects</summary>
		private void InitDeviceStateTrackingEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(DeviceStateTrackingFieldIndex), "DeviceStateTrackingEntity");
			this.AddElementFieldInfo("DeviceStateTrackingEntity", "DeviceStateTrackingId", typeof(System.Int64), true, false, true, false,  (int)DeviceStateTrackingFieldIndex.DeviceStateTrackingId, 0, 0, 19);
			this.AddElementFieldInfo("DeviceStateTrackingEntity", "DeviceId", typeof(System.Int32), false, true, false, false,  (int)DeviceStateTrackingFieldIndex.DeviceId, 0, 0, 10);
			this.AddElementFieldInfo("DeviceStateTrackingEntity", "CurrentState", typeof(EPICCentralDL.Customization.DeviceState), false, false, false, false,  (int)DeviceStateTrackingFieldIndex.CurrentState, 0, 0, 5);
			this.AddElementFieldInfo("DeviceStateTrackingEntity", "PreviousState", typeof(EPICCentralDL.Customization.DeviceState), false, false, false, false,  (int)DeviceStateTrackingFieldIndex.PreviousState, 0, 0, 5);
			this.AddElementFieldInfo("DeviceStateTrackingEntity", "ChangeReason", typeof(System.String), false, false, false, false,  (int)DeviceStateTrackingFieldIndex.ChangeReason, 512, 0, 0);
			this.AddElementFieldInfo("DeviceStateTrackingEntity", "ChangeTime", typeof(System.DateTime), false, false, false, false,  (int)DeviceStateTrackingFieldIndex.ChangeTime, 0, 0, 0);
		}
		/// <summary>Inits ExceptionLogEntity's FieldInfo objects</summary>
		private void InitExceptionLogEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(ExceptionLogFieldIndex), "ExceptionLogEntity");
			this.AddElementFieldInfo("ExceptionLogEntity", "ExceptionLogId", typeof(System.Int64), true, false, false, false,  (int)ExceptionLogFieldIndex.ExceptionLogId, 0, 0, 19);
			this.AddElementFieldInfo("ExceptionLogEntity", "DeviceId", typeof(System.Int32), false, true, false, false,  (int)ExceptionLogFieldIndex.DeviceId, 0, 0, 10);
			this.AddElementFieldInfo("ExceptionLogEntity", "RemoteExceptionLogId", typeof(System.Int64), false, false, false, false,  (int)ExceptionLogFieldIndex.RemoteExceptionLogId, 0, 0, 19);
			this.AddElementFieldInfo("ExceptionLogEntity", "Title", typeof(System.String), false, false, false, true,  (int)ExceptionLogFieldIndex.Title, 1024, 0, 0);
			this.AddElementFieldInfo("ExceptionLogEntity", "Message", typeof(System.String), false, false, false, false,  (int)ExceptionLogFieldIndex.Message, 1024, 0, 0);
			this.AddElementFieldInfo("ExceptionLogEntity", "StackTrace", typeof(System.String), false, false, false, false,  (int)ExceptionLogFieldIndex.StackTrace, 2147483647, 0, 0);
			this.AddElementFieldInfo("ExceptionLogEntity", "LogTime", typeof(System.DateTime), false, false, false, false,  (int)ExceptionLogFieldIndex.LogTime, 0, 0, 0);
			this.AddElementFieldInfo("ExceptionLogEntity", "User", typeof(System.String), false, false, false, true,  (int)ExceptionLogFieldIndex.User, 50, 0, 0);
			this.AddElementFieldInfo("ExceptionLogEntity", "FormName", typeof(System.String), false, false, false, true,  (int)ExceptionLogFieldIndex.FormName, 50, 0, 0);
			this.AddElementFieldInfo("ExceptionLogEntity", "MachineName", typeof(System.String), false, false, false, true,  (int)ExceptionLogFieldIndex.MachineName, 50, 0, 0);
			this.AddElementFieldInfo("ExceptionLogEntity", "MachineOS", typeof(System.String), false, false, false, true,  (int)ExceptionLogFieldIndex.MachineOS, 50, 0, 0);
			this.AddElementFieldInfo("ExceptionLogEntity", "ApplicationVersion", typeof(System.String), false, false, false, true,  (int)ExceptionLogFieldIndex.ApplicationVersion, 40, 0, 0);
			this.AddElementFieldInfo("ExceptionLogEntity", "CLRVersion", typeof(System.String), false, false, false, true,  (int)ExceptionLogFieldIndex.CLRVersion, 50, 0, 0);
			this.AddElementFieldInfo("ExceptionLogEntity", "MemoryUsage", typeof(System.String), false, false, false, true,  (int)ExceptionLogFieldIndex.MemoryUsage, 40, 0, 0);
			this.AddElementFieldInfo("ExceptionLogEntity", "ReceivedTime", typeof(System.DateTime), false, false, false, false,  (int)ExceptionLogFieldIndex.ReceivedTime, 0, 0, 0);
		}
		/// <summary>Inits ImageCacheEntity's FieldInfo objects</summary>
		private void InitImageCacheEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(ImageCacheFieldIndex), "ImageCacheEntity");
			this.AddElementFieldInfo("ImageCacheEntity", "Description", typeof(System.String), false, false, false, false,  (int)ImageCacheFieldIndex.Description, 50, 0, 0);
			this.AddElementFieldInfo("ImageCacheEntity", "Id", typeof(System.Int64), true, false, false, false,  (int)ImageCacheFieldIndex.Id, 0, 0, 19);
			this.AddElementFieldInfo("ImageCacheEntity", "Image", typeof(System.Byte[]), false, false, false, false,  (int)ImageCacheFieldIndex.Image, 2147483647, 0, 0);
			this.AddElementFieldInfo("ImageCacheEntity", "LookupKey", typeof(System.Int64), false, false, false, false,  (int)ImageCacheFieldIndex.LookupKey, 0, 0, 19);
		}
		/// <summary>Inits ImageSetEntity's FieldInfo objects</summary>
		private void InitImageSetEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(ImageSetFieldIndex), "ImageSetEntity");
			this.AddElementFieldInfo("ImageSetEntity", "ImageSetId", typeof(System.Int64), true, false, true, false,  (int)ImageSetFieldIndex.ImageSetId, 0, 0, 19);
			this.AddElementFieldInfo("ImageSetEntity", "UniqueIdentifier", typeof(System.String), false, false, false, false,  (int)ImageSetFieldIndex.UniqueIdentifier, 48, 0, 0);
			this.AddElementFieldInfo("ImageSetEntity", "Images", typeof(System.Byte[]), false, false, false, false,  (int)ImageSetFieldIndex.Images, 2147483647, 0, 0);
		}
		/// <summary>Inits LicenseOrganSystemEntity's FieldInfo objects</summary>
		private void InitLicenseOrganSystemEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(LicenseOrganSystemFieldIndex), "LicenseOrganSystemEntity");
			this.AddElementFieldInfo("LicenseOrganSystemEntity", "LicenseOrganSystemId", typeof(System.Int16), true, false, true, false,  (int)LicenseOrganSystemFieldIndex.LicenseOrganSystemId, 0, 0, 5);
			this.AddElementFieldInfo("LicenseOrganSystemEntity", "LicenseMode", typeof(EPICCentralDL.Customization.LicenseMode), false, false, false, false,  (int)LicenseOrganSystemFieldIndex.LicenseMode, 0, 0, 5);
			this.AddElementFieldInfo("LicenseOrganSystemEntity", "OrganSystemId", typeof(System.Int16), false, true, false, false,  (int)LicenseOrganSystemFieldIndex.OrganSystemId, 0, 0, 5);
			this.AddElementFieldInfo("LicenseOrganSystemEntity", "ReportOrder", typeof(System.Int16), false, false, false, false,  (int)LicenseOrganSystemFieldIndex.ReportOrder, 0, 0, 5);
		}
		/// <summary>Inits LocationEntity's FieldInfo objects</summary>
		private void InitLocationEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(LocationFieldIndex), "LocationEntity");
			this.AddElementFieldInfo("LocationEntity", "LocationId", typeof(System.Int32), true, false, true, false,  (int)LocationFieldIndex.LocationId, 0, 0, 10);
			this.AddElementFieldInfo("LocationEntity", "OrganizationId", typeof(System.Int32), false, true, false, false,  (int)LocationFieldIndex.OrganizationId, 0, 0, 10);
			this.AddElementFieldInfo("LocationEntity", "UniqueIdentifier", typeof(System.String), false, false, false, false,  (int)LocationFieldIndex.UniqueIdentifier, 48, 0, 0);
			this.AddElementFieldInfo("LocationEntity", "Name", typeof(System.String), false, false, false, false,  (int)LocationFieldIndex.Name, 80, 0, 0);
			this.AddElementFieldInfo("LocationEntity", "AddressLine1", typeof(System.String), false, false, false, false,  (int)LocationFieldIndex.AddressLine1, 80, 0, 0);
			this.AddElementFieldInfo("LocationEntity", "AddressLine2", typeof(System.String), false, false, false, true,  (int)LocationFieldIndex.AddressLine2, 80, 0, 0);
			this.AddElementFieldInfo("LocationEntity", "City", typeof(System.String), false, false, false, false,  (int)LocationFieldIndex.City, 40, 0, 0);
			this.AddElementFieldInfo("LocationEntity", "State", typeof(System.String), false, false, false, false,  (int)LocationFieldIndex.State, 2, 0, 0);
			this.AddElementFieldInfo("LocationEntity", "Country", typeof(System.String), false, false, false, false,  (int)LocationFieldIndex.Country, 2, 0, 0);
			this.AddElementFieldInfo("LocationEntity", "PostalCode", typeof(System.String), false, false, false, false,  (int)LocationFieldIndex.PostalCode, 10, 0, 0);
			this.AddElementFieldInfo("LocationEntity", "PhoneNumber", typeof(System.String), false, false, false, false,  (int)LocationFieldIndex.PhoneNumber, 20, 0, 0);
			this.AddElementFieldInfo("LocationEntity", "Latitude", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)LocationFieldIndex.Latitude, 0, 7, 18);
			this.AddElementFieldInfo("LocationEntity", "Longitude", typeof(Nullable<System.Decimal>), false, false, false, true,  (int)LocationFieldIndex.Longitude, 0, 7, 18);
			this.AddElementFieldInfo("LocationEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)LocationFieldIndex.IsActive, 0, 0, 3);
		}
		/// <summary>Inits MessageEntity's FieldInfo objects</summary>
		private void InitMessageEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(MessageFieldIndex), "MessageEntity");
			this.AddElementFieldInfo("MessageEntity", "MessageId", typeof(System.Int64), true, false, true, false,  (int)MessageFieldIndex.MessageId, 0, 0, 19);
			this.AddElementFieldInfo("MessageEntity", "MessageType", typeof(EPICCentralDL.Customization.MessageType), false, false, false, false,  (int)MessageFieldIndex.MessageType, 0, 0, 5);
			this.AddElementFieldInfo("MessageEntity", "Title", typeof(System.String), false, false, false, false,  (int)MessageFieldIndex.Title, 255, 0, 0);
			this.AddElementFieldInfo("MessageEntity", "Body", typeof(System.String), false, false, false, false,  (int)MessageFieldIndex.Body, 4096, 0, 0);
			this.AddElementFieldInfo("MessageEntity", "CreateTime", typeof(System.DateTime), false, false, false, false,  (int)MessageFieldIndex.CreateTime, 0, 0, 0);
			this.AddElementFieldInfo("MessageEntity", "StartTime", typeof(System.DateTime), false, false, false, false,  (int)MessageFieldIndex.StartTime, 0, 0, 0);
			this.AddElementFieldInfo("MessageEntity", "EndTime", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)MessageFieldIndex.EndTime, 0, 0, 0);
			this.AddElementFieldInfo("MessageEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)MessageFieldIndex.IsActive, 0, 0, 3);
		}
		/// <summary>Inits NBAnalysisResultEntity's FieldInfo objects</summary>
		private void InitNBAnalysisResultEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(NBAnalysisResultFieldIndex), "NBAnalysisResultEntity");
			this.AddElementFieldInfo("NBAnalysisResultEntity", "NBAnalysisResultId", typeof(System.Int64), true, false, true, false,  (int)NBAnalysisResultFieldIndex.NBAnalysisResultId, 0, 0, 19);
			this.AddElementFieldInfo("NBAnalysisResultEntity", "TreatmentId", typeof(System.Int64), false, true, false, false,  (int)NBAnalysisResultFieldIndex.TreatmentId, 0, 0, 19);
			this.AddElementFieldInfo("NBAnalysisResultEntity", "OrganSystemId", typeof(System.Int16), false, true, false, false,  (int)NBAnalysisResultFieldIndex.OrganSystemId, 0, 0, 5);
			this.AddElementFieldInfo("NBAnalysisResultEntity", "ResultScoreFiltered", typeof(System.Decimal), false, false, false, false,  (int)NBAnalysisResultFieldIndex.ResultScoreFiltered, 0, 4, 16);
			this.AddElementFieldInfo("NBAnalysisResultEntity", "ResultScoreUnfiltered", typeof(System.Decimal), false, false, false, false,  (int)NBAnalysisResultFieldIndex.ResultScoreUnfiltered, 0, 4, 16);
			this.AddElementFieldInfo("NBAnalysisResultEntity", "ProbabilityFiltered", typeof(System.Decimal), false, false, false, false,  (int)NBAnalysisResultFieldIndex.ProbabilityFiltered, 0, 4, 16);
			this.AddElementFieldInfo("NBAnalysisResultEntity", "ProbabilityUnfiltered", typeof(System.Decimal), false, false, false, false,  (int)NBAnalysisResultFieldIndex.ProbabilityUnfiltered, 0, 4, 16);
		}
		/// <summary>Inits OrganEntity's FieldInfo objects</summary>
		private void InitOrganEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(OrganFieldIndex), "OrganEntity");
			this.AddElementFieldInfo("OrganEntity", "OrganId", typeof(System.Int16), true, false, false, false,  (int)OrganFieldIndex.OrganId, 0, 0, 5);
			this.AddElementFieldInfo("OrganEntity", "OrganComponent", typeof(EPICCentralDL.Customization.OrganComponent), false, false, false, false,  (int)OrganFieldIndex.OrganComponent, 0, 0, 5);
			this.AddElementFieldInfo("OrganEntity", "Description", typeof(System.String), false, false, false, false,  (int)OrganFieldIndex.Description, 128, 0, 0);
			this.AddElementFieldInfo("OrganEntity", "RComp", typeof(System.String), false, false, false, true,  (int)OrganFieldIndex.RComp, 10, 0, 0);
			this.AddElementFieldInfo("OrganEntity", "LComp", typeof(System.String), false, false, false, true,  (int)OrganFieldIndex.LComp, 10, 0, 0);
		}
		/// <summary>Inits OrganizationEntity's FieldInfo objects</summary>
		private void InitOrganizationEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(OrganizationFieldIndex), "OrganizationEntity");
			this.AddElementFieldInfo("OrganizationEntity", "OrganizationId", typeof(System.Int32), true, false, true, false,  (int)OrganizationFieldIndex.OrganizationId, 0, 0, 10);
			this.AddElementFieldInfo("OrganizationEntity", "OrganizationType", typeof(EPICCentralDL.Customization.OrganizationType), false, false, false, false,  (int)OrganizationFieldIndex.OrganizationType, 0, 0, 5);
			this.AddElementFieldInfo("OrganizationEntity", "Name", typeof(System.String), false, false, false, false,  (int)OrganizationFieldIndex.Name, 128, 0, 0);
			this.AddElementFieldInfo("OrganizationEntity", "UniqueIdentifier", typeof(System.String), false, false, false, false,  (int)OrganizationFieldIndex.UniqueIdentifier, 48, 0, 0);
			this.AddElementFieldInfo("OrganizationEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)OrganizationFieldIndex.IsActive, 0, 0, 3);
		}
		/// <summary>Inits OrganSystemEntity's FieldInfo objects</summary>
		private void InitOrganSystemEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(OrganSystemFieldIndex), "OrganSystemEntity");
			this.AddElementFieldInfo("OrganSystemEntity", "OrganSystemId", typeof(System.Int16), true, false, false, false,  (int)OrganSystemFieldIndex.OrganSystemId, 0, 0, 5);
			this.AddElementFieldInfo("OrganSystemEntity", "Description", typeof(System.String), false, false, false, false,  (int)OrganSystemFieldIndex.Description, 50, 0, 0);
		}
		/// <summary>Inits OrganSystemOrganEntity's FieldInfo objects</summary>
		private void InitOrganSystemOrganEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(OrganSystemOrganFieldIndex), "OrganSystemOrganEntity");
			this.AddElementFieldInfo("OrganSystemOrganEntity", "OrganId", typeof(System.Int16), true, true, false, false,  (int)OrganSystemOrganFieldIndex.OrganId, 0, 0, 5);
			this.AddElementFieldInfo("OrganSystemOrganEntity", "LicenseOrganSystemId", typeof(System.Int16), true, true, false, false,  (int)OrganSystemOrganFieldIndex.LicenseOrganSystemId, 0, 0, 5);
			this.AddElementFieldInfo("OrganSystemOrganEntity", "ReportOrder", typeof(System.Int16), false, false, false, false,  (int)OrganSystemOrganFieldIndex.ReportOrder, 0, 0, 5);
		}
		/// <summary>Inits PatientEntity's FieldInfo objects</summary>
		private void InitPatientEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(PatientFieldIndex), "PatientEntity");
			this.AddElementFieldInfo("PatientEntity", "PatientId", typeof(System.Int32), true, false, true, false,  (int)PatientFieldIndex.PatientId, 0, 0, 10);
			this.AddElementFieldInfo("PatientEntity", "UniqueIdentifier", typeof(System.String), false, false, false, false,  (int)PatientFieldIndex.UniqueIdentifier, 48, 0, 0);
			this.AddElementFieldInfo("PatientEntity", "FirstName", typeof(System.String), false, false, false, false,  (int)PatientFieldIndex.FirstName, 50, 0, 0);
			this.AddElementFieldInfo("PatientEntity", "LastName", typeof(System.String), false, false, false, false,  (int)PatientFieldIndex.LastName, 50, 0, 0);
			this.AddElementFieldInfo("PatientEntity", "MiddleInitial", typeof(System.String), false, false, false, true,  (int)PatientFieldIndex.MiddleInitial, 1, 0, 0);
			this.AddElementFieldInfo("PatientEntity", "PhoneNumber", typeof(System.String), false, false, false, true,  (int)PatientFieldIndex.PhoneNumber, 20, 0, 0);
			this.AddElementFieldInfo("PatientEntity", "EmailAddress", typeof(System.String), false, false, false, true,  (int)PatientFieldIndex.EmailAddress, 128, 0, 0);
			this.AddElementFieldInfo("PatientEntity", "BirthDate", typeof(System.DateTime), false, false, false, false,  (int)PatientFieldIndex.BirthDate, 0, 0, 0);
			this.AddElementFieldInfo("PatientEntity", "Gender", typeof(EPICCentralDL.Customization.Gender), false, false, false, false,  (int)PatientFieldIndex.Gender, 0, 0, 5);
			this.AddElementFieldInfo("PatientEntity", "LocationId", typeof(System.Int32), false, true, false, false,  (int)PatientFieldIndex.LocationId, 0, 0, 10);
			this.AddElementFieldInfo("PatientEntity", "ReceivedTime", typeof(System.DateTime), false, false, false, false,  (int)PatientFieldIndex.ReceivedTime, 0, 0, 0);
		}
		/// <summary>Inits PatientPrescanQuestionEntity's FieldInfo objects</summary>
		private void InitPatientPrescanQuestionEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(PatientPrescanQuestionFieldIndex), "PatientPrescanQuestionEntity");
			this.AddElementFieldInfo("PatientPrescanQuestionEntity", "AlcoholQuestion", typeof(System.Boolean), false, false, false, false,  (int)PatientPrescanQuestionFieldIndex.AlcoholQuestion, 0, 0, 0);
			this.AddElementFieldInfo("PatientPrescanQuestionEntity", "CaffeineQuestion", typeof(System.Boolean), false, false, false, false,  (int)PatientPrescanQuestionFieldIndex.CaffeineQuestion, 0, 0, 0);
			this.AddElementFieldInfo("PatientPrescanQuestionEntity", "TreatmentId", typeof(System.Int64), true, true, false, false,  (int)PatientPrescanQuestionFieldIndex.TreatmentId, 0, 0, 19);
			this.AddElementFieldInfo("PatientPrescanQuestionEntity", "WheatQuestion", typeof(System.Boolean), false, false, false, false,  (int)PatientPrescanQuestionFieldIndex.WheatQuestion, 0, 0, 0);
		}
		/// <summary>Inits PurchaseHistoryEntity's FieldInfo objects</summary>
		private void InitPurchaseHistoryEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(PurchaseHistoryFieldIndex), "PurchaseHistoryEntity");
			this.AddElementFieldInfo("PurchaseHistoryEntity", "PurchaseHistoryId", typeof(System.Int32), true, false, true, false,  (int)PurchaseHistoryFieldIndex.PurchaseHistoryId, 0, 0, 10);
			this.AddElementFieldInfo("PurchaseHistoryEntity", "LocationId", typeof(System.Int32), false, true, false, false,  (int)PurchaseHistoryFieldIndex.LocationId, 0, 0, 10);
			this.AddElementFieldInfo("PurchaseHistoryEntity", "DeviceId", typeof(System.Int32), false, true, false, false,  (int)PurchaseHistoryFieldIndex.DeviceId, 0, 0, 10);
			this.AddElementFieldInfo("PurchaseHistoryEntity", "UserId", typeof(System.Int32), false, true, false, false,  (int)PurchaseHistoryFieldIndex.UserId, 0, 0, 10);
			this.AddElementFieldInfo("PurchaseHistoryEntity", "PurchaseTime", typeof(System.DateTime), false, false, false, false,  (int)PurchaseHistoryFieldIndex.PurchaseTime, 0, 0, 0);
			this.AddElementFieldInfo("PurchaseHistoryEntity", "ScansPurchased", typeof(Nullable<System.Int32>), false, false, false, true,  (int)PurchaseHistoryFieldIndex.ScansPurchased, 0, 0, 10);
			this.AddElementFieldInfo("PurchaseHistoryEntity", "AmountPaid", typeof(System.Decimal), false, false, false, false,  (int)PurchaseHistoryFieldIndex.AmountPaid, 0, 4, 19);
			this.AddElementFieldInfo("PurchaseHistoryEntity", "TransactionId", typeof(System.String), false, false, false, false,  (int)PurchaseHistoryFieldIndex.TransactionId, 64, 0, 0);
			this.AddElementFieldInfo("PurchaseHistoryEntity", "PurchaseNotes", typeof(System.String), false, false, false, false,  (int)PurchaseHistoryFieldIndex.PurchaseNotes, 2048, 0, 0);
		}
		/// <summary>Inits RoleEntity's FieldInfo objects</summary>
		private void InitRoleEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(RoleFieldIndex), "RoleEntity");
			this.AddElementFieldInfo("RoleEntity", "RoleId", typeof(System.Int16), true, false, true, false,  (int)RoleFieldIndex.RoleId, 0, 0, 5);
			this.AddElementFieldInfo("RoleEntity", "Name", typeof(System.String), false, false, false, false,  (int)RoleFieldIndex.Name, 80, 0, 0);
			this.AddElementFieldInfo("RoleEntity", "Description", typeof(System.String), false, false, false, true,  (int)RoleFieldIndex.Description, 512, 0, 0);
		}
		/// <summary>Inits ScanHistoryEntity's FieldInfo objects</summary>
		private void InitScanHistoryEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(ScanHistoryFieldIndex), "ScanHistoryEntity");
			this.AddElementFieldInfo("ScanHistoryEntity", "ScanHistoryId", typeof(System.Int64), true, false, true, false,  (int)ScanHistoryFieldIndex.ScanHistoryId, 0, 0, 19);
			this.AddElementFieldInfo("ScanHistoryEntity", "DeviceId", typeof(System.Int32), false, true, false, false,  (int)ScanHistoryFieldIndex.DeviceId, 0, 0, 10);
			this.AddElementFieldInfo("ScanHistoryEntity", "ScanType", typeof(EPICCentralDL.Customization.ScanType), false, false, false, false,  (int)ScanHistoryFieldIndex.ScanType, 0, 0, 5);
			this.AddElementFieldInfo("ScanHistoryEntity", "ScanStartTime", typeof(System.DateTime), false, false, false, false,  (int)ScanHistoryFieldIndex.ScanStartTime, 0, 0, 0);
		}
		/// <summary>Inits ScanRateEntity's FieldInfo objects</summary>
		private void InitScanRateEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(ScanRateFieldIndex), "ScanRateEntity");
			this.AddElementFieldInfo("ScanRateEntity", "ScanRateId", typeof(System.Int32), true, false, true, false,  (int)ScanRateFieldIndex.ScanRateId, 0, 0, 10);
			this.AddElementFieldInfo("ScanRateEntity", "ScanType", typeof(EPICCentralDL.Customization.ScanType), false, false, false, false,  (int)ScanRateFieldIndex.ScanType, 0, 0, 5);
			this.AddElementFieldInfo("ScanRateEntity", "RatePerScan", typeof(System.Decimal), false, false, false, false,  (int)ScanRateFieldIndex.RatePerScan, 0, 4, 19);
			this.AddElementFieldInfo("ScanRateEntity", "MinCountForRate", typeof(System.Int32), false, false, false, false,  (int)ScanRateFieldIndex.MinCountForRate, 0, 0, 10);
			this.AddElementFieldInfo("ScanRateEntity", "MaxCountForRate", typeof(System.Int32), false, false, false, false,  (int)ScanRateFieldIndex.MaxCountForRate, 0, 0, 10);
			this.AddElementFieldInfo("ScanRateEntity", "EffectiveDate", typeof(System.DateTime), false, false, false, false,  (int)ScanRateFieldIndex.EffectiveDate, 0, 0, 0);
			this.AddElementFieldInfo("ScanRateEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)ScanRateFieldIndex.IsActive, 0, 0, 3);
		}
		/// <summary>Inits SessionEntity's FieldInfo objects</summary>
		private void InitSessionEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(SessionFieldIndex), "SessionEntity");
			this.AddElementFieldInfo("SessionEntity", "Created", typeof(System.DateTime), false, false, false, false,  (int)SessionFieldIndex.Created, 0, 0, 0);
			this.AddElementFieldInfo("SessionEntity", "Expires", typeof(System.DateTime), false, false, false, false,  (int)SessionFieldIndex.Expires, 0, 0, 0);
			this.AddElementFieldInfo("SessionEntity", "Flags", typeof(System.Int32), false, false, false, false,  (int)SessionFieldIndex.Flags, 0, 0, 10);
			this.AddElementFieldInfo("SessionEntity", "LockCookie", typeof(System.Int32), false, false, false, false,  (int)SessionFieldIndex.LockCookie, 0, 0, 10);
			this.AddElementFieldInfo("SessionEntity", "LockDate", typeof(System.DateTime), false, false, false, false,  (int)SessionFieldIndex.LockDate, 0, 0, 0);
			this.AddElementFieldInfo("SessionEntity", "LockDateLocal", typeof(System.DateTime), false, false, false, false,  (int)SessionFieldIndex.LockDateLocal, 0, 0, 0);
			this.AddElementFieldInfo("SessionEntity", "Locked", typeof(System.Boolean), false, false, false, false,  (int)SessionFieldIndex.Locked, 0, 0, 0);
			this.AddElementFieldInfo("SessionEntity", "SessionId", typeof(System.String), true, false, false, false,  (int)SessionFieldIndex.SessionId, 88, 0, 0);
			this.AddElementFieldInfo("SessionEntity", "SessionItemLong", typeof(System.Byte[]), false, false, false, true,  (int)SessionFieldIndex.SessionItemLong, 2147483647, 0, 0);
			this.AddElementFieldInfo("SessionEntity", "SessionItemShort", typeof(System.Byte[]), false, false, false, true,  (int)SessionFieldIndex.SessionItemShort, 7000, 0, 0);
			this.AddElementFieldInfo("SessionEntity", "Timeout", typeof(System.Int32), false, false, false, false,  (int)SessionFieldIndex.Timeout, 0, 0, 10);
		}
		/// <summary>Inits SeverityEntity's FieldInfo objects</summary>
		private void InitSeverityEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(SeverityFieldIndex), "SeverityEntity");
			this.AddElementFieldInfo("SeverityEntity", "SeverityId", typeof(System.Int64), true, false, true, false,  (int)SeverityFieldIndex.SeverityId, 0, 0, 19);
			this.AddElementFieldInfo("SeverityEntity", "TreatmentId", typeof(System.Int64), false, true, false, false,  (int)SeverityFieldIndex.TreatmentId, 0, 0, 19);
			this.AddElementFieldInfo("SeverityEntity", "OrganId", typeof(System.Int16), false, true, false, false,  (int)SeverityFieldIndex.OrganId, 0, 0, 5);
			this.AddElementFieldInfo("SeverityEntity", "PhysicalRight", typeof(Nullable<System.Int32>), false, false, false, true,  (int)SeverityFieldIndex.PhysicalRight, 0, 0, 10);
			this.AddElementFieldInfo("SeverityEntity", "PhysicalLeft", typeof(Nullable<System.Int32>), false, false, false, true,  (int)SeverityFieldIndex.PhysicalLeft, 0, 0, 10);
			this.AddElementFieldInfo("SeverityEntity", "MentalRight", typeof(Nullable<System.Int32>), false, false, false, true,  (int)SeverityFieldIndex.MentalRight, 0, 0, 10);
			this.AddElementFieldInfo("SeverityEntity", "MentalLeft", typeof(Nullable<System.Int32>), false, false, false, true,  (int)SeverityFieldIndex.MentalLeft, 0, 0, 10);
		}
		/// <summary>Inits SupportAreaEntity's FieldInfo objects</summary>
		private void InitSupportAreaEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(SupportAreaFieldIndex), "SupportAreaEntity");
			this.AddElementFieldInfo("SupportAreaEntity", "SupportAreaId", typeof(System.Int16), true, false, true, false,  (int)SupportAreaFieldIndex.SupportAreaId, 0, 0, 5);
			this.AddElementFieldInfo("SupportAreaEntity", "Name", typeof(System.String), false, false, false, false,  (int)SupportAreaFieldIndex.Name, 40, 0, 0);
			this.AddElementFieldInfo("SupportAreaEntity", "Description", typeof(System.String), false, false, false, true,  (int)SupportAreaFieldIndex.Description, 80, 0, 0);
			this.AddElementFieldInfo("SupportAreaEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)SupportAreaFieldIndex.IsActive, 0, 0, 3);
		}
		/// <summary>Inits SupportIssueEntity's FieldInfo objects</summary>
		private void InitSupportIssueEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(SupportIssueFieldIndex), "SupportIssueEntity");
			this.AddElementFieldInfo("SupportIssueEntity", "SupportIssueId", typeof(System.Int32), true, false, true, false,  (int)SupportIssueFieldIndex.SupportIssueId, 0, 0, 10);
			this.AddElementFieldInfo("SupportIssueEntity", "ParentId", typeof(System.Int32), false, false, false, false,  (int)SupportIssueFieldIndex.ParentId, 0, 0, 10);
			this.AddElementFieldInfo("SupportIssueEntity", "SupportAreaId", typeof(System.Int16), false, true, false, false,  (int)SupportIssueFieldIndex.SupportAreaId, 0, 0, 5);
			this.AddElementFieldInfo("SupportIssueEntity", "CreateTime", typeof(System.DateTime), false, false, false, false,  (int)SupportIssueFieldIndex.CreateTime, 0, 0, 0);
			this.AddElementFieldInfo("SupportIssueEntity", "ToUserId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)SupportIssueFieldIndex.ToUserId, 0, 0, 10);
			this.AddElementFieldInfo("SupportIssueEntity", "FromUserId", typeof(Nullable<System.Int32>), false, true, false, true,  (int)SupportIssueFieldIndex.FromUserId, 0, 0, 10);
			this.AddElementFieldInfo("SupportIssueEntity", "Subject", typeof(System.String), false, false, false, false,  (int)SupportIssueFieldIndex.Subject, 512, 0, 0);
			this.AddElementFieldInfo("SupportIssueEntity", "Body", typeof(System.String), false, false, false, false,  (int)SupportIssueFieldIndex.Body, 6144, 0, 0);
			this.AddElementFieldInfo("SupportIssueEntity", "Status", typeof(System.String), false, false, false, false,  (int)SupportIssueFieldIndex.Status, 128, 0, 0);
			this.AddElementFieldInfo("SupportIssueEntity", "Priority", typeof(System.Int16), false, false, false, false,  (int)SupportIssueFieldIndex.Priority, 0, 0, 5);
			this.AddElementFieldInfo("SupportIssueEntity", "IsPublic", typeof(System.Boolean), false, false, false, false,  (int)SupportIssueFieldIndex.IsPublic, 0, 0, 3);
			this.AddElementFieldInfo("SupportIssueEntity", "IsClosedByToUser", typeof(System.Boolean), false, false, false, false,  (int)SupportIssueFieldIndex.IsClosedByToUser, 0, 0, 3);
			this.AddElementFieldInfo("SupportIssueEntity", "IsClosedByFromUser", typeof(System.Boolean), false, false, false, false,  (int)SupportIssueFieldIndex.IsClosedByFromUser, 0, 0, 3);
			this.AddElementFieldInfo("SupportIssueEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)SupportIssueFieldIndex.IsActive, 0, 0, 3);
		}
		/// <summary>Inits SystemSettingEntity's FieldInfo objects</summary>
		private void InitSystemSettingEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(SystemSettingFieldIndex), "SystemSettingEntity");
			this.AddElementFieldInfo("SystemSettingEntity", "Name", typeof(System.String), true, false, false, false,  (int)SystemSettingFieldIndex.Name, 50, 0, 0);
			this.AddElementFieldInfo("SystemSettingEntity", "Value", typeof(System.String), false, false, false, false,  (int)SystemSettingFieldIndex.Value, 2048, 0, 0);
		}
		/// <summary>Inits TreatmentEntity's FieldInfo objects</summary>
		private void InitTreatmentEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(TreatmentFieldIndex), "TreatmentEntity");
			this.AddElementFieldInfo("TreatmentEntity", "TreatmentId", typeof(System.Int64), true, false, true, false,  (int)TreatmentFieldIndex.TreatmentId, 0, 0, 19);
			this.AddElementFieldInfo("TreatmentEntity", "PatientId", typeof(System.Int32), false, true, false, false,  (int)TreatmentFieldIndex.PatientId, 0, 0, 10);
			this.AddElementFieldInfo("TreatmentEntity", "CalibrationId", typeof(System.Int64), false, true, false, false,  (int)TreatmentFieldIndex.CalibrationId, 0, 0, 19);
			this.AddElementFieldInfo("TreatmentEntity", "UniqueIdentifier", typeof(System.String), false, false, false, false,  (int)TreatmentFieldIndex.UniqueIdentifier, 48, 0, 0);
			this.AddElementFieldInfo("TreatmentEntity", "TreatmentType", typeof(EPICCentralDL.Customization.TreatmentType), false, false, false, false,  (int)TreatmentFieldIndex.TreatmentType, 0, 0, 5);
			this.AddElementFieldInfo("TreatmentEntity", "TreatmentTime", typeof(System.DateTime), false, false, false, false,  (int)TreatmentFieldIndex.TreatmentTime, 0, 0, 0);
			this.AddElementFieldInfo("TreatmentEntity", "PerformedBy", typeof(System.String), false, false, false, false,  (int)TreatmentFieldIndex.PerformedBy, 80, 0, 0);
			this.AddElementFieldInfo("TreatmentEntity", "EnergizedImageSetId", typeof(System.Int64), false, true, false, false,  (int)TreatmentFieldIndex.EnergizedImageSetId, 0, 0, 19);
			this.AddElementFieldInfo("TreatmentEntity", "FingerImageSetId", typeof(Nullable<System.Int64>), false, true, false, true,  (int)TreatmentFieldIndex.FingerImageSetId, 0, 0, 19);
			this.AddElementFieldInfo("TreatmentEntity", "SoftwareVersion", typeof(System.String), false, false, false, false,  (int)TreatmentFieldIndex.SoftwareVersion, 20, 0, 0);
			this.AddElementFieldInfo("TreatmentEntity", "FirmwareVersion", typeof(System.String), false, false, false, false,  (int)TreatmentFieldIndex.FirmwareVersion, 50, 0, 0);
			this.AddElementFieldInfo("TreatmentEntity", "AnalysisTime", typeof(System.DateTime), false, false, false, false,  (int)TreatmentFieldIndex.AnalysisTime, 0, 0, 0);
			this.AddElementFieldInfo("TreatmentEntity", "ReceivedTime", typeof(System.DateTime), false, false, false, false,  (int)TreatmentFieldIndex.ReceivedTime, 0, 0, 0);
		}
		/// <summary>Inits UpdateStatusEntity's FieldInfo objects</summary>
		private void InitUpdateStatusEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(UpdateStatusFieldIndex), "UpdateStatusEntity");
			this.AddElementFieldInfo("UpdateStatusEntity", "Controller", typeof(System.String), true, false, false, false,  (int)UpdateStatusFieldIndex.Controller, 512, 0, 0);
			this.AddElementFieldInfo("UpdateStatusEntity", "Action", typeof(System.String), true, false, false, false,  (int)UpdateStatusFieldIndex.Action, 128, 0, 0);
			this.AddElementFieldInfo("UpdateStatusEntity", "Method", typeof(System.String), false, false, false, false,  (int)UpdateStatusFieldIndex.Method, 16, 0, 0);
			this.AddElementFieldInfo("UpdateStatusEntity", "UpdateTime", typeof(System.DateTime), false, false, false, false,  (int)UpdateStatusFieldIndex.UpdateTime, 0, 0, 0);
		}
		/// <summary>Inits UserEntity's FieldInfo objects</summary>
		private void InitUserEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(UserFieldIndex), "UserEntity");
			this.AddElementFieldInfo("UserEntity", "UserId", typeof(System.Int32), true, false, true, false,  (int)UserFieldIndex.UserId, 0, 0, 10);
			this.AddElementFieldInfo("UserEntity", "OrganizationId", typeof(System.Int32), false, true, false, false,  (int)UserFieldIndex.OrganizationId, 0, 0, 10);
			this.AddElementFieldInfo("UserEntity", "Username", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.Username, 80, 0, 0);
			this.AddElementFieldInfo("UserEntity", "Password", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.Password, 512, 0, 0);
			this.AddElementFieldInfo("UserEntity", "EmailAddress", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.EmailAddress, 128, 0, 0);
			this.AddElementFieldInfo("UserEntity", "FirstName", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.FirstName, 50, 0, 0);
			this.AddElementFieldInfo("UserEntity", "LastName", typeof(System.String), false, false, false, false,  (int)UserFieldIndex.LastName, 50, 0, 0);
			this.AddElementFieldInfo("UserEntity", "CreateTime", typeof(System.DateTime), false, false, false, false,  (int)UserFieldIndex.CreateTime, 0, 0, 0);
			this.AddElementFieldInfo("UserEntity", "LastLoginTime", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)UserFieldIndex.LastLoginTime, 0, 0, 0);
			this.AddElementFieldInfo("UserEntity", "LastActivityTime", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)UserFieldIndex.LastActivityTime, 0, 0, 0);
			this.AddElementFieldInfo("UserEntity", "LastPasswordChangeTime", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)UserFieldIndex.LastPasswordChangeTime, 0, 0, 0);
			this.AddElementFieldInfo("UserEntity", "LastLockoutTime", typeof(Nullable<System.DateTime>), false, false, false, true,  (int)UserFieldIndex.LastLockoutTime, 0, 0, 0);
			this.AddElementFieldInfo("UserEntity", "IsActive", typeof(System.Boolean), false, false, false, false,  (int)UserFieldIndex.IsActive, 0, 0, 3);
		}
		/// <summary>Inits UserAccountRestrictionEntity's FieldInfo objects</summary>
		private void InitUserAccountRestrictionEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(UserAccountRestrictionFieldIndex), "UserAccountRestrictionEntity");
			this.AddElementFieldInfo("UserAccountRestrictionEntity", "AccountRestrictionId", typeof(System.Int32), true, true, false, false,  (int)UserAccountRestrictionFieldIndex.AccountRestrictionId, 0, 0, 10);
			this.AddElementFieldInfo("UserAccountRestrictionEntity", "UserId", typeof(System.Int32), true, true, false, false,  (int)UserAccountRestrictionFieldIndex.UserId, 0, 0, 10);
		}
		/// <summary>Inits UserAssignedLocationEntity's FieldInfo objects</summary>
		private void InitUserAssignedLocationEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(UserAssignedLocationFieldIndex), "UserAssignedLocationEntity");
			this.AddElementFieldInfo("UserAssignedLocationEntity", "UserId", typeof(System.Int32), true, true, false, false,  (int)UserAssignedLocationFieldIndex.UserId, 0, 0, 10);
			this.AddElementFieldInfo("UserAssignedLocationEntity", "LocationId", typeof(System.Int32), true, true, false, false,  (int)UserAssignedLocationFieldIndex.LocationId, 0, 0, 10);
		}
		/// <summary>Inits UserCreditCardEntity's FieldInfo objects</summary>
		private void InitUserCreditCardEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(UserCreditCardFieldIndex), "UserCreditCardEntity");
			this.AddElementFieldInfo("UserCreditCardEntity", "UserId", typeof(System.Int32), true, true, false, false,  (int)UserCreditCardFieldIndex.UserId, 0, 0, 10);
			this.AddElementFieldInfo("UserCreditCardEntity", "CreditCardId", typeof(System.Int32), true, true, false, false,  (int)UserCreditCardFieldIndex.CreditCardId, 0, 0, 10);
		}
		/// <summary>Inits UserRoleEntity's FieldInfo objects</summary>
		private void InitUserRoleEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(UserRoleFieldIndex), "UserRoleEntity");
			this.AddElementFieldInfo("UserRoleEntity", "UserId", typeof(System.Int32), true, true, false, false,  (int)UserRoleFieldIndex.UserId, 0, 0, 10);
			this.AddElementFieldInfo("UserRoleEntity", "RoleId", typeof(System.Int16), true, true, false, false,  (int)UserRoleFieldIndex.RoleId, 0, 0, 5);
		}
		/// <summary>Inits UserSaltEntity's FieldInfo objects</summary>
		private void InitUserSaltEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(UserSaltFieldIndex), "UserSaltEntity");
			this.AddElementFieldInfo("UserSaltEntity", "UserId", typeof(System.Int32), true, true, false, false,  (int)UserSaltFieldIndex.UserId, 0, 0, 10);
			this.AddElementFieldInfo("UserSaltEntity", "Salt", typeof(System.String), false, false, false, false,  (int)UserSaltFieldIndex.Salt, 4096, 0, 0);
		}
		/// <summary>Inits UserSettingEntity's FieldInfo objects</summary>
		private void InitUserSettingEntityInfos()
		{
			this.AddFieldIndexEnumForElementName(typeof(UserSettingFieldIndex), "UserSettingEntity");
			this.AddElementFieldInfo("UserSettingEntity", "UserId", typeof(System.Int32), true, true, false, false,  (int)UserSettingFieldIndex.UserId, 0, 0, 10);
			this.AddElementFieldInfo("UserSettingEntity", "Name", typeof(System.String), true, false, false, false,  (int)UserSettingFieldIndex.Name, 50, 0, 0);
			this.AddElementFieldInfo("UserSettingEntity", "Value", typeof(System.String), false, false, false, false,  (int)UserSettingFieldIndex.Value, 2048, 0, 0);
		}
		
	}
}




