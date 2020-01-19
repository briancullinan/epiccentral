///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Data;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentralDL.HelperClasses
{
	/// <summary>Singleton implementation of the PersistenceInfoProvider. This class is the singleton wrapper through which the actual instance is retrieved.</summary>
	/// <remarks>It uses a single instance of an internal class. The access isn't marked with locks as the PersistenceInfoProviderBase class is threadsafe.</remarks>
	internal static class PersistenceInfoProviderSingleton
	{
		#region Class Member Declarations
		private static readonly IPersistenceInfoProvider _providerInstance = new PersistenceInfoProviderCore();
		#endregion

		/// <summary>Dummy static constructor to make sure threadsafe initialization is performed.</summary>
		static PersistenceInfoProviderSingleton()
		{
		}

		/// <summary>Gets the singleton instance of the PersistenceInfoProviderCore</summary>
		/// <returns>Instance of the PersistenceInfoProvider.</returns>
		public static IPersistenceInfoProvider GetInstance()
		{
			return _providerInstance;
		}
	}

	/// <summary>Actual implementation of the PersistenceInfoProvider. Used by singleton wrapper.</summary>
	internal class PersistenceInfoProviderCore : PersistenceInfoProviderBase
	{
		/// <summary>Initializes a new instance of the <see cref="PersistenceInfoProviderCore"/> class.</summary>
		internal PersistenceInfoProviderCore()
		{
			Init();
		}

		/// <summary>Method which initializes the internal datastores with the structure of hierarchical types.</summary>
		private void Init()
		{
			this.InitClass((45 + 0));
			InitAccountRestrictionEntityMappings();
			InitActiveOrganizationEntityMappings();
			InitActivityTypeEntityMappings();
			InitAnalysisResultEntityMappings();
			InitApplicationEntityMappings();
			InitAuditEntityMappings();
			InitCalculationDebugDataEntityMappings();
			InitCalibrationEntityMappings();
			InitContactEntityMappings();
			InitCreditCardEntityMappings();
			InitDeviceEntityMappings();
			InitDeviceEventEntityMappings();
			InitDeviceMessageEntityMappings();
			InitDeviceStateTrackingEntityMappings();
			InitExceptionLogEntityMappings();
			InitImageCacheEntityMappings();
			InitImageSetEntityMappings();
			InitLicenseOrganSystemEntityMappings();
			InitLocationEntityMappings();
			InitMessageEntityMappings();
			InitNBAnalysisResultEntityMappings();
			InitOrganEntityMappings();
			InitOrganizationEntityMappings();
			InitOrganSystemEntityMappings();
			InitOrganSystemOrganEntityMappings();
			InitPatientEntityMappings();
			InitPatientPrescanQuestionEntityMappings();
			InitPurchaseHistoryEntityMappings();
			InitRoleEntityMappings();
			InitScanHistoryEntityMappings();
			InitScanRateEntityMappings();
			InitSessionEntityMappings();
			InitSeverityEntityMappings();
			InitSupportAreaEntityMappings();
			InitSupportIssueEntityMappings();
			InitSystemSettingEntityMappings();
			InitTreatmentEntityMappings();
			InitUpdateStatusEntityMappings();
			InitUserEntityMappings();
			InitUserAccountRestrictionEntityMappings();
			InitUserAssignedLocationEntityMappings();
			InitUserCreditCardEntityMappings();
			InitUserRoleEntityMappings();
			InitUserSaltEntityMappings();
			InitUserSettingEntityMappings();

		}


		/// <summary>Inits AccountRestrictionEntity's mappings</summary>
		private void InitAccountRestrictionEntityMappings()
		{
			this.AddElementMapping( "AccountRestrictionEntity", @"EPICCentral", @"dbo", "AccountRestriction", 10 );
			this.AddElementFieldMapping( "AccountRestrictionEntity", "AccountRestrictionId", "AccountRestrictionId", false, "Int", 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "AccountRestrictionEntity", "AccountRestrictionType", "AccountRestrictionType", false, "SmallInt", 0, 0, 5, false, "",  new EPICCentralDL.Customization.AccountRestrictionTypeConverter(), typeof(System.Int16), 1 );
			this.AddElementFieldMapping( "AccountRestrictionEntity", "RestrictionKey", "RestrictionKey", false, "VarChar", 128, 0, 0, false, "", null, typeof(System.String), 2 );
			this.AddElementFieldMapping( "AccountRestrictionEntity", "EmailAddress", "EmailAddress", false, "VarChar", 128, 0, 0, false, "", null, typeof(System.String), 3 );
			this.AddElementFieldMapping( "AccountRestrictionEntity", "Parameters", "Parameters", true, "VarChar", 128, 0, 0, false, "", null, typeof(System.String), 4 );
			this.AddElementFieldMapping( "AccountRestrictionEntity", "IPAddress", "IPAddress", false, "VarChar", 32, 0, 0, false, "", null, typeof(System.String), 5 );
			this.AddElementFieldMapping( "AccountRestrictionEntity", "CreatedBy", "CreatedBy", true, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 6 );
			this.AddElementFieldMapping( "AccountRestrictionEntity", "CreationTime", "CreationTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 7 );
			this.AddElementFieldMapping( "AccountRestrictionEntity", "RemovalTime", "RemovalTime", true, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 8 );
			this.AddElementFieldMapping( "AccountRestrictionEntity", "IsActive", "IsActive", false, "TinyInt", 0, 0, 3, false, "",  new SD.LLBLGen.Pro.ORMSupportClasses.BooleanNumericConverter(), typeof(System.Byte), 9 );
		}
		/// <summary>Inits ActiveOrganizationEntity's mappings</summary>
		private void InitActiveOrganizationEntityMappings()
		{
			this.AddElementMapping( "ActiveOrganizationEntity", @"EPICCentral", @"dbo", "ActiveOrganization", 4 );
			this.AddElementFieldMapping( "ActiveOrganizationEntity", "ActiveOrganizationId", "ActiveOrganizationId", false, "Int", 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "ActiveOrganizationEntity", "LocationId", "LocationId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			this.AddElementFieldMapping( "ActiveOrganizationEntity", "ActivityTypeId", "ActivityTypeId", false, "SmallInt", 0, 0, 5, false, "", null, typeof(System.Int16), 2 );
			this.AddElementFieldMapping( "ActiveOrganizationEntity", "ActivityTime", "ActivityTime", true, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 3 );
		}
		/// <summary>Inits ActivityTypeEntity's mappings</summary>
		private void InitActivityTypeEntityMappings()
		{
			this.AddElementMapping( "ActivityTypeEntity", @"EPICCentral", @"dbo", "ActivityType", 3 );
			this.AddElementFieldMapping( "ActivityTypeEntity", "ActivityTypeId", "ActivityTypeId", false, "SmallInt", 0, 0, 5, false, "", null, typeof(System.Int16), 0 );
			this.AddElementFieldMapping( "ActivityTypeEntity", "Name", "Name", false, "VarChar", 40, 0, 0, false, "", null, typeof(System.String), 1 );
			this.AddElementFieldMapping( "ActivityTypeEntity", "Description", "Description", true, "VarChar", 80, 0, 0, false, "", null, typeof(System.String), 2 );
		}
		/// <summary>Inits AnalysisResultEntity's mappings</summary>
		private void InitAnalysisResultEntityMappings()
		{
			this.AddElementMapping( "AnalysisResultEntity", @"EPICCentral", @"dbo", "AnalysisResult", 38 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "AnalysisResultId", "AnalysisResultID", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "TreatmentId", "TreatmentId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "AnalysisTime", "AnalysisTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "IsFiltered", "IsFiltered", false, "TinyInt", 0, 0, 3, false, "",  new SD.LLBLGen.Pro.ORMSupportClasses.BooleanNumericConverter(), typeof(System.Byte), 3 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "FingerDesc", "FingerDesc", true, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 4 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "FingerType", "FingerType", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 5 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "SectorNumber", "SectorNumber", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 6 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "StartAngle", "StartAngle", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 7 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "EndAngle", "EndAngle", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 8 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "SectorArea", "SectorArea", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 9 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "IntegralArea", "IntegralArea", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 10 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "NormalizedArea", "NormalizedArea", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 11 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "AverageIntensity", "AverageIntensity", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 12 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "Entropy", "Entropy", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 13 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "FormCoefficient", "FormCoefficient", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 14 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "FractalCoefficient", "FractalCoefficient", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 15 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "JsInteger", "JsInteger", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 16 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "CenterX", "CenterX", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 17 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "CenterY", "CenterY", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 18 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "RadiusMin", "RadiusMin", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 19 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "RadiusMax", "RadiusMax", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 20 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "AngleOfRotation", "AngleOfRotation", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 21 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "Form2", "Form2", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 22 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "NoiseLevel", "NoiseLevel", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 23 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "BreakCoefficient", "BreakCoefficient", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 24 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "SoftwareVersion", "SoftwareVersion", true, "VarChar", 20, 0, 0, false, "", null, typeof(System.String), 25 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "AI1", "AI1", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 26 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "AI2", "AI2", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 27 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "AI3", "AI3", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 28 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "AI4", "AI4", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 29 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "Form11", "Form1_1", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 30 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "Form12", "Form1_2", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 31 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "Form13", "Form1_3", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 32 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "Form14", "Form1_4", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 33 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "RingThickness", "RingThickness", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 34 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "RingIntensity", "RingIntensity", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 35 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "Form2Prime", "Form2Prime", false, "Float", 0, 0, 38, false, "", null, typeof(System.Double), 36 );
			this.AddElementFieldMapping( "AnalysisResultEntity", "UserName", "UserName", false, "VarChar", 20, 0, 0, false, "", null, typeof(System.String), 37 );
		}
		/// <summary>Inits ApplicationEntity's mappings</summary>
		private void InitApplicationEntityMappings()
		{
			this.AddElementMapping( "ApplicationEntity", @"EPICCentral", @"dbo", "ASPStateTempApplications", 2 );
			this.AddElementFieldMapping( "ApplicationEntity", "AppId", "AppId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "ApplicationEntity", "AppName", "AppName", false, "Char", 280, 0, 0, false, "", null, typeof(System.String), 1 );
		}
		/// <summary>Inits AuditEntity's mappings</summary>
		private void InitAuditEntityMappings()
		{
			this.AddElementMapping( "AuditEntity", @"EPICCentral", @"dbo", "Audit", 8 );
			this.AddElementFieldMapping( "AuditEntity", "AuditId", "AuditId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			this.AddElementFieldMapping( "AuditEntity", "CreatedBy", "CreatedBy", false, "VarChar", 80, 0, 0, false, "", null, typeof(System.String), 1 );
			this.AddElementFieldMapping( "AuditEntity", "CreatedDate", "CreatedDate", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
			this.AddElementFieldMapping( "AuditEntity", "Field", "Field", false, "VarChar", 128, 0, 0, false, "", null, typeof(System.String), 3 );
			this.AddElementFieldMapping( "AuditEntity", "Key", "Key", false, "VarChar", 256, 0, 0, false, "", null, typeof(System.String), 4 );
			this.AddElementFieldMapping( "AuditEntity", "NewData", "NewData", true, "VarChar", 2147483647, 0, 0, false, "", null, typeof(System.String), 5 );
			this.AddElementFieldMapping( "AuditEntity", "OldData", "OldData", true, "VarChar", 2147483647, 0, 0, false, "", null, typeof(System.String), 6 );
			this.AddElementFieldMapping( "AuditEntity", "Table", "Table", false, "VarChar", 128, 0, 0, false, "", null, typeof(System.String), 7 );
		}
		/// <summary>Inits CalculationDebugDataEntity's mappings</summary>
		private void InitCalculationDebugDataEntityMappings()
		{
			this.AddElementMapping( "CalculationDebugDataEntity", @"EPICCentral", @"dbo", "CalculationDebugData", 33 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "CalculationDebugDataId", "CalculationDebugDataId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "TreatmentId", "TreatmentId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "FingerSector", "FingerSector", false, "VarChar", 20, 0, 0, false, "", null, typeof(System.String), 2 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "IsFiltered", "IsFiltered", false, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 3 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "OrganComponent", "OrganComponent", false, "SmallInt", 0, 0, 5, false, "",  new EPICCentralDL.Customization.OrganComponentConverter(), typeof(System.Int16), 4 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "Area", "Area", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 5 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "AverageIntensity", "AverageIntensity", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 6 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "BreakCoefficient", "BreakCoefficient", true, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 7 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "Entropy", "Entropy", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 8 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "NS", "NS", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 9 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "Fractal", "Fractal", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 10 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "Form", "Form", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 11 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "Form2", "Form2", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 12 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "AI1", "AI1", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 13 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "AI2", "AI2", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 14 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "AI3", "AI3", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 15 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "AI4", "AI4", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 16 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "Form11", "Form1_1", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 17 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "Form12", "Form1_2", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 18 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "Form13", "Form1_3", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 19 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "Form14", "Form1_4", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 20 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "RingIntensity", "RingIntensity", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 21 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "RingThickness", "RingThickness", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 22 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "Form2Prime", "Form2Prime", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 23 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "EPICBaseScore", "EPICBaseScore", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 24 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "EPICBonusScore", "EPICBonusScore", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 25 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "EPICScore", "EPICScore", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 26 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "EPICScaledScore", "EPICScaledScore", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 27 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "EPICRank", "EPICRank", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 28 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "LRRank", "LRRank", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 29 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "LRScore", "LRScore", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 30 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "LRScaledScore", "LRScaledScore", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 31 );
			this.AddElementFieldMapping( "CalculationDebugDataEntity", "SumZScore", "SumZScore", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 32 );
		}
		/// <summary>Inits CalibrationEntity's mappings</summary>
		private void InitCalibrationEntityMappings()
		{
			this.AddElementMapping( "CalibrationEntity", @"EPICCentral", @"dbo", "Calibration", 7 );
			this.AddElementFieldMapping( "CalibrationEntity", "CalibrationId", "CalibrationId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			this.AddElementFieldMapping( "CalibrationEntity", "DeviceId", "DeviceId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			this.AddElementFieldMapping( "CalibrationEntity", "UniqueIdentifier", "UniqueIdentifier", false, "VarChar", 48, 0, 0, false, "", null, typeof(System.String), 2 );
			this.AddElementFieldMapping( "CalibrationEntity", "CalibrationTime", "CalibrationTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 3 );
			this.AddElementFieldMapping( "CalibrationEntity", "PerformedBy", "PerformedBy", false, "VarChar", 80, 0, 0, false, "", null, typeof(System.String), 4 );
			this.AddElementFieldMapping( "CalibrationEntity", "ImageSetId", "ImageSetId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 5 );
			this.AddElementFieldMapping( "CalibrationEntity", "ReceivedTime", "ReceivedTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 6 );
		}
		/// <summary>Inits ContactEntity's mappings</summary>
		private void InitContactEntityMappings()
		{
			this.AddElementMapping( "ContactEntity", @"EPICCentral", @"dbo", "Contact", 6 );
			this.AddElementFieldMapping( "ContactEntity", "ContactId", "ContactId", false, "Int", 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "ContactEntity", "OrganizationId", "OrganizationId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			this.AddElementFieldMapping( "ContactEntity", "FirstName", "FirstName", false, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 2 );
			this.AddElementFieldMapping( "ContactEntity", "LastName", "LastName", false, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 3 );
			this.AddElementFieldMapping( "ContactEntity", "EmailAddress", "EmailAddress", false, "VarChar", 128, 0, 0, false, "", null, typeof(System.String), 4 );
			this.AddElementFieldMapping( "ContactEntity", "PhoneNumber", "PhoneNumber", false, "VarChar", 20, 0, 0, false, "", null, typeof(System.String), 5 );
		}
		/// <summary>Inits CreditCardEntity's mappings</summary>
		private void InitCreditCardEntityMappings()
		{
			this.AddElementMapping( "CreditCardEntity", @"EPICCentral", @"dbo", "CreditCard", 6 );
			this.AddElementFieldMapping( "CreditCardEntity", "CreditCardId", "CreditCardId", false, "Int", 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "CreditCardEntity", "AuthorizeId", "AuthorizeId", false, "VarChar", 20, 0, 0, false, "", null, typeof(System.String), 1 );
			this.AddElementFieldMapping( "CreditCardEntity", "FirstName", "FirstName", false, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 2 );
			this.AddElementFieldMapping( "CreditCardEntity", "LastName", "LastName", false, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 3 );
			this.AddElementFieldMapping( "CreditCardEntity", "AccountNumber", "AccountNumber", true, "Char", 4, 0, 0, false, "", null, typeof(System.String), 4 );
			this.AddElementFieldMapping( "CreditCardEntity", "Address", "Address", true, "VarChar", 64, 0, 0, false, "", null, typeof(System.String), 5 );
		}
		/// <summary>Inits DeviceEntity's mappings</summary>
		private void InitDeviceEntityMappings()
		{
			this.AddElementMapping( "DeviceEntity", @"EPICCentral", @"dbo", "Device", 13 );
			this.AddElementFieldMapping( "DeviceEntity", "DeviceId", "DeviceId", false, "Int", 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "DeviceEntity", "LocationId", "LocationId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			this.AddElementFieldMapping( "DeviceEntity", "UniqueIdentifier", "UniqueIdentifier", false, "VarChar", 48, 0, 0, false, "", null, typeof(System.String), 2 );
			this.AddElementFieldMapping( "DeviceEntity", "AuthenticationToken", "AuthenticationToken", true, "Binary", 64, 0, 0, false, "", null, typeof(System.Byte[]), 3 );
			this.AddElementFieldMapping( "DeviceEntity", "UidQualifier", "UidQualifier", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
			this.AddElementFieldMapping( "DeviceEntity", "DeviceState", "DeviceState", false, "SmallInt", 0, 0, 5, false, "",  new EPICCentralDL.Customization.DeviceStateTypeConverter(), typeof(System.Int16), 5 );
			this.AddElementFieldMapping( "DeviceEntity", "SerialNumber", "SerialNumber", false, "VarChar", 40, 0, 0, false, "", null, typeof(System.String), 6 );
			this.AddElementFieldMapping( "DeviceEntity", "DateIssued", "DateIssued", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 7 );
			this.AddElementFieldMapping( "DeviceEntity", "RevisionLevel", "RevisionLevel", false, "VarChar", 5, 0, 0, false, "", null, typeof(System.String), 8 );
			this.AddElementFieldMapping( "DeviceEntity", "ScansAvailable", "ScansAvailable", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 9 );
			this.AddElementFieldMapping( "DeviceEntity", "ScansUsed", "ScansCompleted", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 10 );
			this.AddElementFieldMapping( "DeviceEntity", "CurrentStatus", "CurrentStatus", false, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 11 );
			this.AddElementFieldMapping( "DeviceEntity", "LastReportTime", "LastReportTime", true, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 12 );
		}
		/// <summary>Inits DeviceEventEntity's mappings</summary>
		private void InitDeviceEventEntityMappings()
		{
			this.AddElementMapping( "DeviceEventEntity", @"EPICCentral", @"dbo", "DeviceEvent", 5 );
			this.AddElementFieldMapping( "DeviceEventEntity", "DeviceEventId", "DeviceEventId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			this.AddElementFieldMapping( "DeviceEventEntity", "DeviceId", "DeviceId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			this.AddElementFieldMapping( "DeviceEventEntity", "EventType", "EventType", false, "SmallInt", 0, 0, 5, false, "",  new EPICCentralDL.Customization.EventTypeConverter(), typeof(System.Int16), 2 );
			this.AddElementFieldMapping( "DeviceEventEntity", "EventTime", "EventTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 3 );
			this.AddElementFieldMapping( "DeviceEventEntity", "ReceivedTime", "ReceivedTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
		}
		/// <summary>Inits DeviceMessageEntity's mappings</summary>
		private void InitDeviceMessageEntityMappings()
		{
			this.AddElementMapping( "DeviceMessageEntity", @"EPICCentral", @"dbo", "DeviceMessage", 3 );
			this.AddElementFieldMapping( "DeviceMessageEntity", "DeviceId", "DeviceId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "DeviceMessageEntity", "MessageId", "MessageId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			this.AddElementFieldMapping( "DeviceMessageEntity", "DeliveryTime", "DeliveryTime", true, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 2 );
		}
		/// <summary>Inits DeviceStateTrackingEntity's mappings</summary>
		private void InitDeviceStateTrackingEntityMappings()
		{
			this.AddElementMapping( "DeviceStateTrackingEntity", @"EPICCentral", @"dbo", "DeviceStateTracking", 6 );
			this.AddElementFieldMapping( "DeviceStateTrackingEntity", "DeviceStateTrackingId", "DeviceStateTrackingId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			this.AddElementFieldMapping( "DeviceStateTrackingEntity", "DeviceId", "DeviceId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			this.AddElementFieldMapping( "DeviceStateTrackingEntity", "CurrentState", "CurrentState", false, "SmallInt", 0, 0, 5, false, "",  new EPICCentralDL.Customization.DeviceStateTypeConverter(), typeof(System.Int16), 2 );
			this.AddElementFieldMapping( "DeviceStateTrackingEntity", "PreviousState", "PreviousState", false, "SmallInt", 0, 0, 5, false, "",  new EPICCentralDL.Customization.DeviceStateTypeConverter(), typeof(System.Int16), 3 );
			this.AddElementFieldMapping( "DeviceStateTrackingEntity", "ChangeReason", "ChangeReason", false, "VarChar", 512, 0, 0, false, "", null, typeof(System.String), 4 );
			this.AddElementFieldMapping( "DeviceStateTrackingEntity", "ChangeTime", "ChangeTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 5 );
		}
		/// <summary>Inits ExceptionLogEntity's mappings</summary>
		private void InitExceptionLogEntityMappings()
		{
			this.AddElementMapping( "ExceptionLogEntity", @"EPICCentral", @"dbo", "ExceptionLog", 15 );
			this.AddElementFieldMapping( "ExceptionLogEntity", "ExceptionLogId", "ExceptionLogId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			this.AddElementFieldMapping( "ExceptionLogEntity", "DeviceId", "DeviceId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			this.AddElementFieldMapping( "ExceptionLogEntity", "RemoteExceptionLogId", "RemoteExceptionLogId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			this.AddElementFieldMapping( "ExceptionLogEntity", "Title", "Title", true, "VarChar", 1024, 0, 0, false, "", null, typeof(System.String), 3 );
			this.AddElementFieldMapping( "ExceptionLogEntity", "Message", "Message", false, "VarChar", 1024, 0, 0, false, "", null, typeof(System.String), 4 );
			this.AddElementFieldMapping( "ExceptionLogEntity", "StackTrace", "StackTrace", false, "VarChar", 2147483647, 0, 0, false, "", null, typeof(System.String), 5 );
			this.AddElementFieldMapping( "ExceptionLogEntity", "LogTime", "LogTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 6 );
			this.AddElementFieldMapping( "ExceptionLogEntity", "User", "User", true, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 7 );
			this.AddElementFieldMapping( "ExceptionLogEntity", "FormName", "FormName", true, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 8 );
			this.AddElementFieldMapping( "ExceptionLogEntity", "MachineName", "MachineName", true, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 9 );
			this.AddElementFieldMapping( "ExceptionLogEntity", "MachineOS", "MachineOS", true, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 10 );
			this.AddElementFieldMapping( "ExceptionLogEntity", "ApplicationVersion", "ApplicationVersion", true, "VarChar", 40, 0, 0, false, "", null, typeof(System.String), 11 );
			this.AddElementFieldMapping( "ExceptionLogEntity", "CLRVersion", "CLRVersion", true, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 12 );
			this.AddElementFieldMapping( "ExceptionLogEntity", "MemoryUsage", "MemoryUsage", true, "VarChar", 40, 0, 0, false, "", null, typeof(System.String), 13 );
			this.AddElementFieldMapping( "ExceptionLogEntity", "ReceivedTime", "ReceivedTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 14 );
		}
		/// <summary>Inits ImageCacheEntity's mappings</summary>
		private void InitImageCacheEntityMappings()
		{
			this.AddElementMapping( "ImageCacheEntity", @"EPICCentral", @"dbo", "ImageCache", 4 );
			this.AddElementFieldMapping( "ImageCacheEntity", "Description", "Description", false, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 0 );
			this.AddElementFieldMapping( "ImageCacheEntity", "Id", "Id", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 1 );
			this.AddElementFieldMapping( "ImageCacheEntity", "Image", "Image", false, "VarBinary", 2147483647, 0, 0, false, "", null, typeof(System.Byte[]), 2 );
			this.AddElementFieldMapping( "ImageCacheEntity", "LookupKey", "LookupKey", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 3 );
		}
		/// <summary>Inits ImageSetEntity's mappings</summary>
		private void InitImageSetEntityMappings()
		{
			this.AddElementMapping( "ImageSetEntity", @"EPICCentral", @"dbo", "ImageSet", 3 );
			this.AddElementFieldMapping( "ImageSetEntity", "ImageSetId", "ImageSetId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			this.AddElementFieldMapping( "ImageSetEntity", "UniqueIdentifier", "UniqueIdentifier", false, "VarChar", 48, 0, 0, false, "", null, typeof(System.String), 1 );
			this.AddElementFieldMapping( "ImageSetEntity", "Images", "Images", false, "VarBinary", 2147483647, 0, 0, false, "", null, typeof(System.Byte[]), 2 );
		}
		/// <summary>Inits LicenseOrganSystemEntity's mappings</summary>
		private void InitLicenseOrganSystemEntityMappings()
		{
			this.AddElementMapping( "LicenseOrganSystemEntity", @"EPICCentral", @"dbo", "LicenseOrganSystem", 4 );
			this.AddElementFieldMapping( "LicenseOrganSystemEntity", "LicenseOrganSystemId", "LicenseOrganSystemId", false, "SmallInt", 0, 0, 5, true, "SCOPE_IDENTITY()", null, typeof(System.Int16), 0 );
			this.AddElementFieldMapping( "LicenseOrganSystemEntity", "LicenseMode", "LicenseMode", false, "SmallInt", 0, 0, 5, false, "",  new EPICCentralDL.Customization.LicenseModeTypeConverter(), typeof(System.Int16), 1 );
			this.AddElementFieldMapping( "LicenseOrganSystemEntity", "OrganSystemId", "OrganSystemId", false, "SmallInt", 0, 0, 5, false, "", null, typeof(System.Int16), 2 );
			this.AddElementFieldMapping( "LicenseOrganSystemEntity", "ReportOrder", "ReportOrder", false, "SmallInt", 0, 0, 5, false, "", null, typeof(System.Int16), 3 );
		}
		/// <summary>Inits LocationEntity's mappings</summary>
		private void InitLocationEntityMappings()
		{
			this.AddElementMapping( "LocationEntity", @"EPICCentral", @"dbo", "Location", 14 );
			this.AddElementFieldMapping( "LocationEntity", "LocationId", "LocationId", false, "Int", 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "LocationEntity", "OrganizationId", "OrganizationId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			this.AddElementFieldMapping( "LocationEntity", "UniqueIdentifier", "UniqueIdentifier", false, "VarChar", 48, 0, 0, false, "", null, typeof(System.String), 2 );
			this.AddElementFieldMapping( "LocationEntity", "Name", "Name", false, "VarChar", 80, 0, 0, false, "", null, typeof(System.String), 3 );
			this.AddElementFieldMapping( "LocationEntity", "AddressLine1", "AddressLine1", false, "VarChar", 80, 0, 0, false, "", null, typeof(System.String), 4 );
			this.AddElementFieldMapping( "LocationEntity", "AddressLine2", "AddressLine2", true, "VarChar", 80, 0, 0, false, "", null, typeof(System.String), 5 );
			this.AddElementFieldMapping( "LocationEntity", "City", "City", false, "VarChar", 40, 0, 0, false, "", null, typeof(System.String), 6 );
			this.AddElementFieldMapping( "LocationEntity", "State", "State", false, "VarChar", 2, 0, 0, false, "", null, typeof(System.String), 7 );
			this.AddElementFieldMapping( "LocationEntity", "Country", "Country", false, "VarChar", 2, 0, 0, false, "", null, typeof(System.String), 8 );
			this.AddElementFieldMapping( "LocationEntity", "PostalCode", "PostalCode", false, "VarChar", 10, 0, 0, false, "", null, typeof(System.String), 9 );
			this.AddElementFieldMapping( "LocationEntity", "PhoneNumber", "PhoneNumber", false, "VarChar", 20, 0, 0, false, "", null, typeof(System.String), 10 );
			this.AddElementFieldMapping( "LocationEntity", "Latitude", "Latitude", true, "Decimal", 0, 7, 18, false, "", null, typeof(System.Decimal), 11 );
			this.AddElementFieldMapping( "LocationEntity", "Longitude", "Longitude", true, "Decimal", 0, 7, 18, false, "", null, typeof(System.Decimal), 12 );
			this.AddElementFieldMapping( "LocationEntity", "IsActive", "IsActive", false, "TinyInt", 0, 0, 3, false, "",  new SD.LLBLGen.Pro.ORMSupportClasses.BooleanNumericConverter(), typeof(System.Byte), 13 );
		}
		/// <summary>Inits MessageEntity's mappings</summary>
		private void InitMessageEntityMappings()
		{
			this.AddElementMapping( "MessageEntity", @"EPICCentral", @"dbo", "Message", 8 );
			this.AddElementFieldMapping( "MessageEntity", "MessageId", "MessageId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			this.AddElementFieldMapping( "MessageEntity", "MessageType", "MessageType", false, "SmallInt", 0, 0, 5, false, "",  new EPICCentralDL.Customization.MessageTypeConverter(), typeof(System.Int16), 1 );
			this.AddElementFieldMapping( "MessageEntity", "Title", "Title", false, "VarChar", 255, 0, 0, false, "", null, typeof(System.String), 2 );
			this.AddElementFieldMapping( "MessageEntity", "Body", "Body", false, "VarChar", 4096, 0, 0, false, "", null, typeof(System.String), 3 );
			this.AddElementFieldMapping( "MessageEntity", "CreateTime", "CreateTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			this.AddElementFieldMapping( "MessageEntity", "StartTime", "StartTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 5 );
			this.AddElementFieldMapping( "MessageEntity", "EndTime", "EndTime", true, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 6 );
			this.AddElementFieldMapping( "MessageEntity", "IsActive", "IsActive", false, "TinyInt", 0, 0, 3, false, "",  new SD.LLBLGen.Pro.ORMSupportClasses.BooleanNumericConverter(), typeof(System.Byte), 7 );
		}
		/// <summary>Inits NBAnalysisResultEntity's mappings</summary>
		private void InitNBAnalysisResultEntityMappings()
		{
			this.AddElementMapping( "NBAnalysisResultEntity", @"EPICCentral", @"dbo", "NBAnalysisResult", 7 );
			this.AddElementFieldMapping( "NBAnalysisResultEntity", "NBAnalysisResultId", "NBAnalysisResultId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			this.AddElementFieldMapping( "NBAnalysisResultEntity", "TreatmentId", "TreatmentId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			this.AddElementFieldMapping( "NBAnalysisResultEntity", "OrganSystemId", "OrganSystemId", false, "SmallInt", 0, 0, 5, false, "", null, typeof(System.Int16), 2 );
			this.AddElementFieldMapping( "NBAnalysisResultEntity", "ResultScoreFiltered", "ResultScoreFiltered", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 3 );
			this.AddElementFieldMapping( "NBAnalysisResultEntity", "ResultScoreUnfiltered", "ResultScoreUnfiltered", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 4 );
			this.AddElementFieldMapping( "NBAnalysisResultEntity", "ProbabilityFiltered", "ProbabilityFiltered", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 5 );
			this.AddElementFieldMapping( "NBAnalysisResultEntity", "ProbabilityUnfiltered", "ProbabilityUnfiltered", false, "Decimal", 0, 4, 16, false, "", null, typeof(System.Decimal), 6 );
		}
		/// <summary>Inits OrganEntity's mappings</summary>
		private void InitOrganEntityMappings()
		{
			this.AddElementMapping( "OrganEntity", @"EPICCentral", @"dbo", "Organ", 5 );
			this.AddElementFieldMapping( "OrganEntity", "OrganId", "OrganId", false, "SmallInt", 0, 0, 5, false, "", null, typeof(System.Int16), 0 );
			this.AddElementFieldMapping( "OrganEntity", "OrganComponent", "OrganComponent", false, "SmallInt", 0, 0, 5, false, "",  new EPICCentralDL.Customization.OrganComponentConverter(), typeof(System.Int16), 1 );
			this.AddElementFieldMapping( "OrganEntity", "Description", "Description", false, "VarChar", 128, 0, 0, false, "", null, typeof(System.String), 2 );
			this.AddElementFieldMapping( "OrganEntity", "RComp", "RComp", true, "VarChar", 10, 0, 0, false, "", null, typeof(System.String), 3 );
			this.AddElementFieldMapping( "OrganEntity", "LComp", "LComp", true, "VarChar", 10, 0, 0, false, "", null, typeof(System.String), 4 );
		}
		/// <summary>Inits OrganizationEntity's mappings</summary>
		private void InitOrganizationEntityMappings()
		{
			this.AddElementMapping( "OrganizationEntity", @"EPICCentral", @"dbo", "Organization", 5 );
			this.AddElementFieldMapping( "OrganizationEntity", "OrganizationId", "OrganizationId", false, "Int", 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "OrganizationEntity", "OrganizationType", "OrganizationType", false, "SmallInt", 0, 0, 5, false, "",  new EPICCentralDL.Customization.OrganizationTypeConverter(), typeof(System.Int16), 1 );
			this.AddElementFieldMapping( "OrganizationEntity", "Name", "Name", false, "VarChar", 128, 0, 0, false, "", null, typeof(System.String), 2 );
			this.AddElementFieldMapping( "OrganizationEntity", "UniqueIdentifier", "UniqueIdentifier", false, "VarChar", 48, 0, 0, false, "", null, typeof(System.String), 3 );
			this.AddElementFieldMapping( "OrganizationEntity", "IsActive", "IsActive", false, "TinyInt", 0, 0, 3, false, "",  new SD.LLBLGen.Pro.ORMSupportClasses.BooleanNumericConverter(), typeof(System.Byte), 4 );
		}
		/// <summary>Inits OrganSystemEntity's mappings</summary>
		private void InitOrganSystemEntityMappings()
		{
			this.AddElementMapping( "OrganSystemEntity", @"EPICCentral", @"dbo", "OrganSystem", 2 );
			this.AddElementFieldMapping( "OrganSystemEntity", "OrganSystemId", "OrganSystemId", false, "SmallInt", 0, 0, 5, false, "", null, typeof(System.Int16), 0 );
			this.AddElementFieldMapping( "OrganSystemEntity", "Description", "Description", false, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 1 );
		}
		/// <summary>Inits OrganSystemOrganEntity's mappings</summary>
		private void InitOrganSystemOrganEntityMappings()
		{
			this.AddElementMapping( "OrganSystemOrganEntity", @"EPICCentral", @"dbo", "OrganSystemOrgan", 3 );
			this.AddElementFieldMapping( "OrganSystemOrganEntity", "OrganId", "OrganId", false, "SmallInt", 0, 0, 5, false, "", null, typeof(System.Int16), 0 );
			this.AddElementFieldMapping( "OrganSystemOrganEntity", "LicenseOrganSystemId", "LicenseOrganSystemId", false, "SmallInt", 0, 0, 5, false, "", null, typeof(System.Int16), 1 );
			this.AddElementFieldMapping( "OrganSystemOrganEntity", "ReportOrder", "ReportOrder", false, "SmallInt", 0, 0, 5, false, "", null, typeof(System.Int16), 2 );
		}
		/// <summary>Inits PatientEntity's mappings</summary>
		private void InitPatientEntityMappings()
		{
			this.AddElementMapping( "PatientEntity", @"EPICCentral", @"dbo", "Patient", 11 );
			this.AddElementFieldMapping( "PatientEntity", "PatientId", "PatientId", false, "Int", 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "PatientEntity", "UniqueIdentifier", "UniqueIdentifier", false, "VarChar", 48, 0, 0, false, "", null, typeof(System.String), 1 );
			this.AddElementFieldMapping( "PatientEntity", "FirstName", "FirstName", false, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 2 );
			this.AddElementFieldMapping( "PatientEntity", "LastName", "LastName", false, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 3 );
			this.AddElementFieldMapping( "PatientEntity", "MiddleInitial", "MiddleInitial", true, "Char", 1, 0, 0, false, "", null, typeof(System.String), 4 );
			this.AddElementFieldMapping( "PatientEntity", "PhoneNumber", "PhoneNumber", true, "VarChar", 20, 0, 0, false, "", null, typeof(System.String), 5 );
			this.AddElementFieldMapping( "PatientEntity", "EmailAddress", "EmailAddress", true, "VarChar", 128, 0, 0, false, "", null, typeof(System.String), 6 );
			this.AddElementFieldMapping( "PatientEntity", "BirthDate", "BirthDate", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 7 );
			this.AddElementFieldMapping( "PatientEntity", "Gender", "Gender", false, "SmallInt", 0, 0, 5, false, "",  new EPICCentralDL.Customization.GenderConverter(), typeof(System.Int16), 8 );
			this.AddElementFieldMapping( "PatientEntity", "LocationId", "LocationId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 9 );
			this.AddElementFieldMapping( "PatientEntity", "ReceivedTime", "ReceivedTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 10 );
		}
		/// <summary>Inits PatientPrescanQuestionEntity's mappings</summary>
		private void InitPatientPrescanQuestionEntityMappings()
		{
			this.AddElementMapping( "PatientPrescanQuestionEntity", @"EPICCentral", @"dbo", "PatientPrescanQuestion", 4 );
			this.AddElementFieldMapping( "PatientPrescanQuestionEntity", "AlcoholQuestion", "AlcoholQuestion", false, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 0 );
			this.AddElementFieldMapping( "PatientPrescanQuestionEntity", "CaffeineQuestion", "CaffeineQuestion", false, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 1 );
			this.AddElementFieldMapping( "PatientPrescanQuestionEntity", "TreatmentId", "TreatmentId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			this.AddElementFieldMapping( "PatientPrescanQuestionEntity", "WheatQuestion", "WheatQuestion", false, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 3 );
		}
		/// <summary>Inits PurchaseHistoryEntity's mappings</summary>
		private void InitPurchaseHistoryEntityMappings()
		{
			this.AddElementMapping( "PurchaseHistoryEntity", @"EPICCentral", @"dbo", "PurchaseHistory", 9 );
			this.AddElementFieldMapping( "PurchaseHistoryEntity", "PurchaseHistoryId", "PurchaseHistoryId", false, "Int", 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "PurchaseHistoryEntity", "LocationId", "LocationId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			this.AddElementFieldMapping( "PurchaseHistoryEntity", "DeviceId", "DeviceId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			this.AddElementFieldMapping( "PurchaseHistoryEntity", "UserId", "UserId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			this.AddElementFieldMapping( "PurchaseHistoryEntity", "PurchaseTime", "PurchaseTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			this.AddElementFieldMapping( "PurchaseHistoryEntity", "ScansPurchased", "ScansPurchased", true, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 5 );
			this.AddElementFieldMapping( "PurchaseHistoryEntity", "AmountPaid", "AmountPaid", false, "Money", 0, 4, 19, false, "", null, typeof(System.Decimal), 6 );
			this.AddElementFieldMapping( "PurchaseHistoryEntity", "TransactionId", "TransactionId", false, "VarChar", 64, 0, 0, false, "", null, typeof(System.String), 7 );
			this.AddElementFieldMapping( "PurchaseHistoryEntity", "PurchaseNotes", "PurchaseNotes", false, "VarChar", 2048, 0, 0, false, "", null, typeof(System.String), 8 );
		}
		/// <summary>Inits RoleEntity's mappings</summary>
		private void InitRoleEntityMappings()
		{
			this.AddElementMapping( "RoleEntity", @"EPICCentral", @"dbo", "Role", 3 );
			this.AddElementFieldMapping( "RoleEntity", "RoleId", "RoleId", false, "SmallInt", 0, 0, 5, true, "SCOPE_IDENTITY()", null, typeof(System.Int16), 0 );
			this.AddElementFieldMapping( "RoleEntity", "Name", "Name", false, "VarChar", 80, 0, 0, false, "", null, typeof(System.String), 1 );
			this.AddElementFieldMapping( "RoleEntity", "Description", "Description", true, "VarChar", 512, 0, 0, false, "", null, typeof(System.String), 2 );
		}
		/// <summary>Inits ScanHistoryEntity's mappings</summary>
		private void InitScanHistoryEntityMappings()
		{
			this.AddElementMapping( "ScanHistoryEntity", @"EPICCentral", @"dbo", "ScanHistory", 4 );
			this.AddElementFieldMapping( "ScanHistoryEntity", "ScanHistoryId", "ScanHistoryId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			this.AddElementFieldMapping( "ScanHistoryEntity", "DeviceId", "DeviceId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			this.AddElementFieldMapping( "ScanHistoryEntity", "ScanType", "ScanType", false, "SmallInt", 0, 0, 5, false, "",  new EPICCentralDL.Customization.ScanTypeConverter(), typeof(System.Int16), 2 );
			this.AddElementFieldMapping( "ScanHistoryEntity", "ScanStartTime", "ScanStartTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 3 );
		}
		/// <summary>Inits ScanRateEntity's mappings</summary>
		private void InitScanRateEntityMappings()
		{
			this.AddElementMapping( "ScanRateEntity", @"EPICCentral", @"dbo", "ScanRate", 7 );
			this.AddElementFieldMapping( "ScanRateEntity", "ScanRateId", "ScanRateId", false, "Int", 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "ScanRateEntity", "ScanType", "ScanType", false, "SmallInt", 0, 0, 5, false, "",  new EPICCentralDL.Customization.ScanTypeConverter(), typeof(System.Int16), 1 );
			this.AddElementFieldMapping( "ScanRateEntity", "RatePerScan", "RatePerScan", false, "Money", 0, 4, 19, false, "", null, typeof(System.Decimal), 2 );
			this.AddElementFieldMapping( "ScanRateEntity", "MinCountForRate", "MinCountForRate", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			this.AddElementFieldMapping( "ScanRateEntity", "MaxCountForRate", "MaxCountForRate", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
			this.AddElementFieldMapping( "ScanRateEntity", "EffectiveDate", "EffectiveDate", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 5 );
			this.AddElementFieldMapping( "ScanRateEntity", "IsActive", "IsActive", false, "TinyInt", 0, 0, 3, false, "",  new SD.LLBLGen.Pro.ORMSupportClasses.BooleanNumericConverter(), typeof(System.Byte), 6 );
		}
		/// <summary>Inits SessionEntity's mappings</summary>
		private void InitSessionEntityMappings()
		{
			this.AddElementMapping( "SessionEntity", @"EPICCentral", @"dbo", "ASPStateTempSessions", 11 );
			this.AddElementFieldMapping( "SessionEntity", "Created", "Created", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 0 );
			this.AddElementFieldMapping( "SessionEntity", "Expires", "Expires", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 1 );
			this.AddElementFieldMapping( "SessionEntity", "Flags", "Flags", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 2 );
			this.AddElementFieldMapping( "SessionEntity", "LockCookie", "LockCookie", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			this.AddElementFieldMapping( "SessionEntity", "LockDate", "LockDate", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 4 );
			this.AddElementFieldMapping( "SessionEntity", "LockDateLocal", "LockDateLocal", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 5 );
			this.AddElementFieldMapping( "SessionEntity", "Locked", "Locked", false, "Bit", 0, 0, 0, false, "", null, typeof(System.Boolean), 6 );
			this.AddElementFieldMapping( "SessionEntity", "SessionId", "SessionId", false, "NVarChar", 88, 0, 0, false, "", null, typeof(System.String), 7 );
			this.AddElementFieldMapping( "SessionEntity", "SessionItemLong", "SessionItemLong", true, "Image", 2147483647, 0, 0, false, "", null, typeof(System.Byte[]), 8 );
			this.AddElementFieldMapping( "SessionEntity", "SessionItemShort", "SessionItemShort", true, "VarBinary", 7000, 0, 0, false, "", null, typeof(System.Byte[]), 9 );
			this.AddElementFieldMapping( "SessionEntity", "Timeout", "Timeout", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 10 );
		}
		/// <summary>Inits SeverityEntity's mappings</summary>
		private void InitSeverityEntityMappings()
		{
			this.AddElementMapping( "SeverityEntity", @"EPICCentral", @"dbo", "Severity", 7 );
			this.AddElementFieldMapping( "SeverityEntity", "SeverityId", "SeverityId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			this.AddElementFieldMapping( "SeverityEntity", "TreatmentId", "TreatmentId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 1 );
			this.AddElementFieldMapping( "SeverityEntity", "OrganId", "OrganId", false, "SmallInt", 0, 0, 5, false, "", null, typeof(System.Int16), 2 );
			this.AddElementFieldMapping( "SeverityEntity", "PhysicalRight", "PhysicalRight", true, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 3 );
			this.AddElementFieldMapping( "SeverityEntity", "PhysicalLeft", "PhysicalLeft", true, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
			this.AddElementFieldMapping( "SeverityEntity", "MentalRight", "MentalRight", true, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 5 );
			this.AddElementFieldMapping( "SeverityEntity", "MentalLeft", "MentalLeft", true, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 6 );
		}
		/// <summary>Inits SupportAreaEntity's mappings</summary>
		private void InitSupportAreaEntityMappings()
		{
			this.AddElementMapping( "SupportAreaEntity", @"EPICCentral", @"dbo", "SupportArea", 4 );
			this.AddElementFieldMapping( "SupportAreaEntity", "SupportAreaId", "SupportAreaId", false, "SmallInt", 0, 0, 5, true, "SCOPE_IDENTITY()", null, typeof(System.Int16), 0 );
			this.AddElementFieldMapping( "SupportAreaEntity", "Name", "Name", false, "VarChar", 40, 0, 0, false, "", null, typeof(System.String), 1 );
			this.AddElementFieldMapping( "SupportAreaEntity", "Description", "Description", true, "VarChar", 80, 0, 0, false, "", null, typeof(System.String), 2 );
			this.AddElementFieldMapping( "SupportAreaEntity", "IsActive", "IsActive", false, "TinyInt", 0, 0, 3, false, "",  new SD.LLBLGen.Pro.ORMSupportClasses.BooleanNumericConverter(), typeof(System.Byte), 3 );
		}
		/// <summary>Inits SupportIssueEntity's mappings</summary>
		private void InitSupportIssueEntityMappings()
		{
			this.AddElementMapping( "SupportIssueEntity", @"EPICCentral", @"dbo", "SupportIssue", 14 );
			this.AddElementFieldMapping( "SupportIssueEntity", "SupportIssueId", "SupportIssueId", false, "Int", 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "SupportIssueEntity", "ParentId", "ParentId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			this.AddElementFieldMapping( "SupportIssueEntity", "SupportAreaId", "SupportAreaId", false, "SmallInt", 0, 0, 5, false, "", null, typeof(System.Int16), 2 );
			this.AddElementFieldMapping( "SupportIssueEntity", "CreateTime", "CreateTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 3 );
			this.AddElementFieldMapping( "SupportIssueEntity", "ToUserId", "ToUserId", true, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 4 );
			this.AddElementFieldMapping( "SupportIssueEntity", "FromUserId", "FromUserId", true, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 5 );
			this.AddElementFieldMapping( "SupportIssueEntity", "Subject", "Subject", false, "VarChar", 512, 0, 0, false, "", null, typeof(System.String), 6 );
			this.AddElementFieldMapping( "SupportIssueEntity", "Body", "Body", false, "VarChar", 6144, 0, 0, false, "", null, typeof(System.String), 7 );
			this.AddElementFieldMapping( "SupportIssueEntity", "Status", "Status", false, "VarChar", 128, 0, 0, false, "", null, typeof(System.String), 8 );
			this.AddElementFieldMapping( "SupportIssueEntity", "Priority", "Priority", false, "SmallInt", 0, 0, 5, false, "", null, typeof(System.Int16), 9 );
			this.AddElementFieldMapping( "SupportIssueEntity", "IsPublic", "IsPublic", false, "TinyInt", 0, 0, 3, false, "",  new SD.LLBLGen.Pro.ORMSupportClasses.BooleanNumericConverter(), typeof(System.Byte), 10 );
			this.AddElementFieldMapping( "SupportIssueEntity", "IsClosedByToUser", "IsClosedByToUser", false, "TinyInt", 0, 0, 3, false, "",  new SD.LLBLGen.Pro.ORMSupportClasses.BooleanNumericConverter(), typeof(System.Byte), 11 );
			this.AddElementFieldMapping( "SupportIssueEntity", "IsClosedByFromUser", "IsClosedByFromUser", false, "TinyInt", 0, 0, 3, false, "",  new SD.LLBLGen.Pro.ORMSupportClasses.BooleanNumericConverter(), typeof(System.Byte), 12 );
			this.AddElementFieldMapping( "SupportIssueEntity", "IsActive", "IsActive", false, "TinyInt", 0, 0, 3, false, "",  new SD.LLBLGen.Pro.ORMSupportClasses.BooleanNumericConverter(), typeof(System.Byte), 13 );
		}
		/// <summary>Inits SystemSettingEntity's mappings</summary>
		private void InitSystemSettingEntityMappings()
		{
			this.AddElementMapping( "SystemSettingEntity", @"EPICCentral", @"dbo", "SystemSetting", 2 );
			this.AddElementFieldMapping( "SystemSettingEntity", "Name", "Name", false, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 0 );
			this.AddElementFieldMapping( "SystemSettingEntity", "Value", "Value", false, "VarChar", 2048, 0, 0, false, "", null, typeof(System.String), 1 );
		}
		/// <summary>Inits TreatmentEntity's mappings</summary>
		private void InitTreatmentEntityMappings()
		{
			this.AddElementMapping( "TreatmentEntity", @"EPICCentral", @"dbo", "Treatment", 13 );
			this.AddElementFieldMapping( "TreatmentEntity", "TreatmentId", "TreatmentId", false, "BigInt", 0, 0, 19, true, "SCOPE_IDENTITY()", null, typeof(System.Int64), 0 );
			this.AddElementFieldMapping( "TreatmentEntity", "PatientId", "PatientId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			this.AddElementFieldMapping( "TreatmentEntity", "CalibrationId", "CalibrationId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 2 );
			this.AddElementFieldMapping( "TreatmentEntity", "UniqueIdentifier", "UniqueIdentifier", false, "VarChar", 48, 0, 0, false, "", null, typeof(System.String), 3 );
			this.AddElementFieldMapping( "TreatmentEntity", "TreatmentType", "TreatmentType", false, "SmallInt", 0, 0, 5, false, "",  new EPICCentralDL.Customization.TreatmentTypeConverter(), typeof(System.Int16), 4 );
			this.AddElementFieldMapping( "TreatmentEntity", "TreatmentTime", "TreatmentTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 5 );
			this.AddElementFieldMapping( "TreatmentEntity", "PerformedBy", "PerformedBy", false, "VarChar", 80, 0, 0, false, "", null, typeof(System.String), 6 );
			this.AddElementFieldMapping( "TreatmentEntity", "EnergizedImageSetId", "EnergizedImageSetId", false, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 7 );
			this.AddElementFieldMapping( "TreatmentEntity", "FingerImageSetId", "FingerImageSetId", true, "BigInt", 0, 0, 19, false, "", null, typeof(System.Int64), 8 );
			this.AddElementFieldMapping( "TreatmentEntity", "SoftwareVersion", "SoftwareVersion", false, "VarChar", 20, 0, 0, false, "", null, typeof(System.String), 9 );
			this.AddElementFieldMapping( "TreatmentEntity", "FirmwareVersion", "FirmwareVersion", false, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 10 );
			this.AddElementFieldMapping( "TreatmentEntity", "AnalysisTime", "AnalysisTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 11 );
			this.AddElementFieldMapping( "TreatmentEntity", "ReceivedTime", "ReceivedTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 12 );
		}
		/// <summary>Inits UpdateStatusEntity's mappings</summary>
		private void InitUpdateStatusEntityMappings()
		{
			this.AddElementMapping( "UpdateStatusEntity", @"EPICCentral", @"dbo", "UpdateStatus", 4 );
			this.AddElementFieldMapping( "UpdateStatusEntity", "Controller", "Controller", false, "VarChar", 512, 0, 0, false, "", null, typeof(System.String), 0 );
			this.AddElementFieldMapping( "UpdateStatusEntity", "Action", "Action", false, "VarChar", 128, 0, 0, false, "", null, typeof(System.String), 1 );
			this.AddElementFieldMapping( "UpdateStatusEntity", "Method", "Method", false, "VarChar", 16, 0, 0, false, "", null, typeof(System.String), 2 );
			this.AddElementFieldMapping( "UpdateStatusEntity", "UpdateTime", "UpdateTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 3 );
		}
		/// <summary>Inits UserEntity's mappings</summary>
		private void InitUserEntityMappings()
		{
			this.AddElementMapping( "UserEntity", @"EPICCentral", @"dbo", "User", 13 );
			this.AddElementFieldMapping( "UserEntity", "UserId", "UserId", false, "Int", 0, 0, 10, true, "SCOPE_IDENTITY()", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "UserEntity", "OrganizationId", "OrganizationId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
			this.AddElementFieldMapping( "UserEntity", "Username", "Username", false, "VarChar", 80, 0, 0, false, "", null, typeof(System.String), 2 );
			this.AddElementFieldMapping( "UserEntity", "Password", "Password", false, "VarChar", 512, 0, 0, false, "", null, typeof(System.String), 3 );
			this.AddElementFieldMapping( "UserEntity", "EmailAddress", "EmailAddress", false, "VarChar", 128, 0, 0, false, "", null, typeof(System.String), 4 );
			this.AddElementFieldMapping( "UserEntity", "FirstName", "FirstName", false, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 5 );
			this.AddElementFieldMapping( "UserEntity", "LastName", "LastName", false, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 6 );
			this.AddElementFieldMapping( "UserEntity", "CreateTime", "CreateTime", false, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 7 );
			this.AddElementFieldMapping( "UserEntity", "LastLoginTime", "LastLoginTime", true, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 8 );
			this.AddElementFieldMapping( "UserEntity", "LastActivityTime", "LastActivityTime", true, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 9 );
			this.AddElementFieldMapping( "UserEntity", "LastPasswordChangeTime", "LastPasswordChangeTime", true, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 10 );
			this.AddElementFieldMapping( "UserEntity", "LastLockoutTime", "LastLockoutTime", true, "DateTime", 0, 0, 0, false, "", null, typeof(System.DateTime), 11 );
			this.AddElementFieldMapping( "UserEntity", "IsActive", "IsActive", false, "TinyInt", 0, 0, 3, false, "",  new SD.LLBLGen.Pro.ORMSupportClasses.BooleanNumericConverter(), typeof(System.Byte), 12 );
		}
		/// <summary>Inits UserAccountRestrictionEntity's mappings</summary>
		private void InitUserAccountRestrictionEntityMappings()
		{
			this.AddElementMapping( "UserAccountRestrictionEntity", @"EPICCentral", @"dbo", "UserAccountRestriction", 2 );
			this.AddElementFieldMapping( "UserAccountRestrictionEntity", "AccountRestrictionId", "AccountRestrictionId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "UserAccountRestrictionEntity", "UserId", "UserId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits UserAssignedLocationEntity's mappings</summary>
		private void InitUserAssignedLocationEntityMappings()
		{
			this.AddElementMapping( "UserAssignedLocationEntity", @"EPICCentral", @"dbo", "UserAssignedLocation", 2 );
			this.AddElementFieldMapping( "UserAssignedLocationEntity", "UserId", "UserId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "UserAssignedLocationEntity", "LocationId", "LocationId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits UserCreditCardEntity's mappings</summary>
		private void InitUserCreditCardEntityMappings()
		{
			this.AddElementMapping( "UserCreditCardEntity", @"EPICCentral", @"dbo", "UserCreditCard", 2 );
			this.AddElementFieldMapping( "UserCreditCardEntity", "UserId", "UserId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "UserCreditCardEntity", "CreditCardId", "CreditCardId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 1 );
		}
		/// <summary>Inits UserRoleEntity's mappings</summary>
		private void InitUserRoleEntityMappings()
		{
			this.AddElementMapping( "UserRoleEntity", @"EPICCentral", @"dbo", "UserRole", 2 );
			this.AddElementFieldMapping( "UserRoleEntity", "UserId", "UserId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "UserRoleEntity", "RoleId", "RoleId", false, "SmallInt", 0, 0, 5, false, "", null, typeof(System.Int16), 1 );
		}
		/// <summary>Inits UserSaltEntity's mappings</summary>
		private void InitUserSaltEntityMappings()
		{
			this.AddElementMapping( "UserSaltEntity", @"EPICCentral", @"dbo", "UserSalt", 2 );
			this.AddElementFieldMapping( "UserSaltEntity", "UserId", "UserId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "UserSaltEntity", "Salt", "Salt", false, "VarChar", 4096, 0, 0, false, "", null, typeof(System.String), 1 );
		}
		/// <summary>Inits UserSettingEntity's mappings</summary>
		private void InitUserSettingEntityMappings()
		{
			this.AddElementMapping( "UserSettingEntity", @"EPICCentral", @"dbo", "UserSetting", 3 );
			this.AddElementFieldMapping( "UserSettingEntity", "UserId", "UserId", false, "Int", 0, 0, 10, false, "", null, typeof(System.Int32), 0 );
			this.AddElementFieldMapping( "UserSettingEntity", "Name", "Name", false, "VarChar", 50, 0, 0, false, "", null, typeof(System.String), 1 );
			this.AddElementFieldMapping( "UserSettingEntity", "Value", "Value", false, "VarChar", 2048, 0, 0, false, "", null, typeof(System.String), 2 );
		}

	}
}