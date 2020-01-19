///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET35
// Templates vendor: Solutions Design.
//////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

using EPICCentralDL;
using EPICCentralDL.DaoClasses;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.FactoryClasses;
using EPICCentralDL.HelperClasses;
using EPICCentralDL.RelationClasses;

namespace EPICCentralDL.Linq
{
	/// <summary>Meta-data class for the construction of Linq queries which are to be executed using LLBLGen Pro code.</summary>
	public partial class LinqMetaData : ILinqMetaData
	{
		#region Class Member Declarations
		private ITransaction _transactionToUse;
		private FunctionMappingStore _customFunctionMappings;
		private Context _contextToUse;
		#endregion
		
		/// <summary>CTor. Using this ctor will leave the transaction object to use empty. This is ok if you're not executing queries created with this
		/// meta data inside a transaction. If you're executing the queries created with this meta-data inside a transaction, either set the Transaction property
		/// on the IQueryable.Provider instance of the created LLBLGenProQuery object prior to execution or use the ctor which accepts a transaction object.</summary>
		public LinqMetaData() : this(null, null)
		{
		}
		
		/// <summary>CTor. If you're executing the queries created with this meta-data inside a transaction, pass a live ITransaction object to this ctor.</summary>
		/// <param name="transactionToUse">the transaction to use in queries created with this meta-data</param>
		/// <remarks> Be aware that the ITransaction object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(ITransaction transactionToUse) : this(transactionToUse, null)
		{
		}
		
		/// <summary>CTor. If you're executing the queries created with this meta-data inside a transaction, pass a live ITransaction object to this ctor.</summary>
		/// <param name="transactionToUse">the transaction to use in queries created with this meta-data</param>
		/// <param name="customFunctionMappings">The custom function mappings to use. These take higher precedence than the ones in the DQE to use.</param>
		/// <remarks> Be aware that the ITransaction object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public LinqMetaData(ITransaction transactionToUse, FunctionMappingStore customFunctionMappings)
		{
			_transactionToUse = transactionToUse;
			_customFunctionMappings = customFunctionMappings;
		}
		
		/// <summary>returns the datasource to use in a Linq query for the entity type specified</summary>
		/// <param name="typeOfEntity">the type of the entity to get the datasource for</param>
		/// <returns>the requested datasource</returns>
		public IDataSource GetQueryableForEntity(int typeOfEntity)
		{
			IDataSource toReturn = null;
			switch((EPICCentralDL.EntityType)typeOfEntity)
			{
				case EPICCentralDL.EntityType.AccountRestrictionEntity:
					toReturn = this.AccountRestriction;
					break;
				case EPICCentralDL.EntityType.ActiveOrganizationEntity:
					toReturn = this.ActiveOrganization;
					break;
				case EPICCentralDL.EntityType.ActivityTypeEntity:
					toReturn = this.ActivityType;
					break;
				case EPICCentralDL.EntityType.AnalysisResultEntity:
					toReturn = this.AnalysisResult;
					break;
				case EPICCentralDL.EntityType.ApplicationEntity:
					toReturn = this.Application;
					break;
				case EPICCentralDL.EntityType.AuditEntity:
					toReturn = this.Audit;
					break;
				case EPICCentralDL.EntityType.CalculationDebugDataEntity:
					toReturn = this.CalculationDebugData;
					break;
				case EPICCentralDL.EntityType.CalibrationEntity:
					toReturn = this.Calibration;
					break;
				case EPICCentralDL.EntityType.ContactEntity:
					toReturn = this.Contact;
					break;
				case EPICCentralDL.EntityType.CreditCardEntity:
					toReturn = this.CreditCard;
					break;
				case EPICCentralDL.EntityType.DeviceEntity:
					toReturn = this.Device;
					break;
				case EPICCentralDL.EntityType.DeviceEventEntity:
					toReturn = this.DeviceEvent;
					break;
				case EPICCentralDL.EntityType.DeviceMessageEntity:
					toReturn = this.DeviceMessage;
					break;
				case EPICCentralDL.EntityType.DeviceStateTrackingEntity:
					toReturn = this.DeviceStateTracking;
					break;
				case EPICCentralDL.EntityType.ExceptionLogEntity:
					toReturn = this.ExceptionLog;
					break;
				case EPICCentralDL.EntityType.ImageCacheEntity:
					toReturn = this.ImageCache;
					break;
				case EPICCentralDL.EntityType.ImageSetEntity:
					toReturn = this.ImageSet;
					break;
				case EPICCentralDL.EntityType.LicenseOrganSystemEntity:
					toReturn = this.LicenseOrganSystem;
					break;
				case EPICCentralDL.EntityType.LocationEntity:
					toReturn = this.Location;
					break;
				case EPICCentralDL.EntityType.MessageEntity:
					toReturn = this.Message;
					break;
				case EPICCentralDL.EntityType.NBAnalysisResultEntity:
					toReturn = this.NBAnalysisResult;
					break;
				case EPICCentralDL.EntityType.OrganEntity:
					toReturn = this.Organ;
					break;
				case EPICCentralDL.EntityType.OrganizationEntity:
					toReturn = this.Organization;
					break;
				case EPICCentralDL.EntityType.OrganSystemEntity:
					toReturn = this.OrganSystem;
					break;
				case EPICCentralDL.EntityType.OrganSystemOrganEntity:
					toReturn = this.OrganSystemOrgan;
					break;
				case EPICCentralDL.EntityType.PatientEntity:
					toReturn = this.Patient;
					break;
				case EPICCentralDL.EntityType.PatientPrescanQuestionEntity:
					toReturn = this.PatientPrescanQuestion;
					break;
				case EPICCentralDL.EntityType.PurchaseHistoryEntity:
					toReturn = this.PurchaseHistory;
					break;
				case EPICCentralDL.EntityType.RoleEntity:
					toReturn = this.Role;
					break;
				case EPICCentralDL.EntityType.ScanHistoryEntity:
					toReturn = this.ScanHistory;
					break;
				case EPICCentralDL.EntityType.ScanRateEntity:
					toReturn = this.ScanRate;
					break;
				case EPICCentralDL.EntityType.SessionEntity:
					toReturn = this.Session;
					break;
				case EPICCentralDL.EntityType.SeverityEntity:
					toReturn = this.Severity;
					break;
				case EPICCentralDL.EntityType.SupportAreaEntity:
					toReturn = this.SupportArea;
					break;
				case EPICCentralDL.EntityType.SupportIssueEntity:
					toReturn = this.SupportIssue;
					break;
				case EPICCentralDL.EntityType.SystemSettingEntity:
					toReturn = this.SystemSetting;
					break;
				case EPICCentralDL.EntityType.TreatmentEntity:
					toReturn = this.Treatment;
					break;
				case EPICCentralDL.EntityType.UpdateStatusEntity:
					toReturn = this.UpdateStatus;
					break;
				case EPICCentralDL.EntityType.UserEntity:
					toReturn = this.User;
					break;
				case EPICCentralDL.EntityType.UserAccountRestrictionEntity:
					toReturn = this.UserAccountRestriction;
					break;
				case EPICCentralDL.EntityType.UserAssignedLocationEntity:
					toReturn = this.UserAssignedLocation;
					break;
				case EPICCentralDL.EntityType.UserCreditCardEntity:
					toReturn = this.UserCreditCard;
					break;
				case EPICCentralDL.EntityType.UserRoleEntity:
					toReturn = this.UserRole;
					break;
				case EPICCentralDL.EntityType.UserSaltEntity:
					toReturn = this.UserSalt;
					break;
				case EPICCentralDL.EntityType.UserSettingEntity:
					toReturn = this.UserSetting;
					break;
				default:
					toReturn = null;
					break;
			}
			return toReturn;
		}

		/// <summary>returns the datasource to use in a Linq query when targeting AccountRestrictionEntity instances in the database.</summary>
		public DataSource<AccountRestrictionEntity> AccountRestriction
		{
			get { return new DataSource<AccountRestrictionEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting ActiveOrganizationEntity instances in the database.</summary>
		public DataSource<ActiveOrganizationEntity> ActiveOrganization
		{
			get { return new DataSource<ActiveOrganizationEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting ActivityTypeEntity instances in the database.</summary>
		public DataSource<ActivityTypeEntity> ActivityType
		{
			get { return new DataSource<ActivityTypeEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting AnalysisResultEntity instances in the database.</summary>
		public DataSource<AnalysisResultEntity> AnalysisResult
		{
			get { return new DataSource<AnalysisResultEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting ApplicationEntity instances in the database.</summary>
		public DataSource<ApplicationEntity> Application
		{
			get { return new DataSource<ApplicationEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting AuditEntity instances in the database.</summary>
		public DataSource<AuditEntity> Audit
		{
			get { return new DataSource<AuditEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting CalculationDebugDataEntity instances in the database.</summary>
		public DataSource<CalculationDebugDataEntity> CalculationDebugData
		{
			get { return new DataSource<CalculationDebugDataEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting CalibrationEntity instances in the database.</summary>
		public DataSource<CalibrationEntity> Calibration
		{
			get { return new DataSource<CalibrationEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting ContactEntity instances in the database.</summary>
		public DataSource<ContactEntity> Contact
		{
			get { return new DataSource<ContactEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting CreditCardEntity instances in the database.</summary>
		public DataSource<CreditCardEntity> CreditCard
		{
			get { return new DataSource<CreditCardEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting DeviceEntity instances in the database.</summary>
		public DataSource<DeviceEntity> Device
		{
			get { return new DataSource<DeviceEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting DeviceEventEntity instances in the database.</summary>
		public DataSource<DeviceEventEntity> DeviceEvent
		{
			get { return new DataSource<DeviceEventEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting DeviceMessageEntity instances in the database.</summary>
		public DataSource<DeviceMessageEntity> DeviceMessage
		{
			get { return new DataSource<DeviceMessageEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting DeviceStateTrackingEntity instances in the database.</summary>
		public DataSource<DeviceStateTrackingEntity> DeviceStateTracking
		{
			get { return new DataSource<DeviceStateTrackingEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting ExceptionLogEntity instances in the database.</summary>
		public DataSource<ExceptionLogEntity> ExceptionLog
		{
			get { return new DataSource<ExceptionLogEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting ImageCacheEntity instances in the database.</summary>
		public DataSource<ImageCacheEntity> ImageCache
		{
			get { return new DataSource<ImageCacheEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting ImageSetEntity instances in the database.</summary>
		public DataSource<ImageSetEntity> ImageSet
		{
			get { return new DataSource<ImageSetEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting LicenseOrganSystemEntity instances in the database.</summary>
		public DataSource<LicenseOrganSystemEntity> LicenseOrganSystem
		{
			get { return new DataSource<LicenseOrganSystemEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting LocationEntity instances in the database.</summary>
		public DataSource<LocationEntity> Location
		{
			get { return new DataSource<LocationEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting MessageEntity instances in the database.</summary>
		public DataSource<MessageEntity> Message
		{
			get { return new DataSource<MessageEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting NBAnalysisResultEntity instances in the database.</summary>
		public DataSource<NBAnalysisResultEntity> NBAnalysisResult
		{
			get { return new DataSource<NBAnalysisResultEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting OrganEntity instances in the database.</summary>
		public DataSource<OrganEntity> Organ
		{
			get { return new DataSource<OrganEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting OrganizationEntity instances in the database.</summary>
		public DataSource<OrganizationEntity> Organization
		{
			get { return new DataSource<OrganizationEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting OrganSystemEntity instances in the database.</summary>
		public DataSource<OrganSystemEntity> OrganSystem
		{
			get { return new DataSource<OrganSystemEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting OrganSystemOrganEntity instances in the database.</summary>
		public DataSource<OrganSystemOrganEntity> OrganSystemOrgan
		{
			get { return new DataSource<OrganSystemOrganEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting PatientEntity instances in the database.</summary>
		public DataSource<PatientEntity> Patient
		{
			get { return new DataSource<PatientEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting PatientPrescanQuestionEntity instances in the database.</summary>
		public DataSource<PatientPrescanQuestionEntity> PatientPrescanQuestion
		{
			get { return new DataSource<PatientPrescanQuestionEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting PurchaseHistoryEntity instances in the database.</summary>
		public DataSource<PurchaseHistoryEntity> PurchaseHistory
		{
			get { return new DataSource<PurchaseHistoryEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting RoleEntity instances in the database.</summary>
		public DataSource<RoleEntity> Role
		{
			get { return new DataSource<RoleEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting ScanHistoryEntity instances in the database.</summary>
		public DataSource<ScanHistoryEntity> ScanHistory
		{
			get { return new DataSource<ScanHistoryEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting ScanRateEntity instances in the database.</summary>
		public DataSource<ScanRateEntity> ScanRate
		{
			get { return new DataSource<ScanRateEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting SessionEntity instances in the database.</summary>
		public DataSource<SessionEntity> Session
		{
			get { return new DataSource<SessionEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting SeverityEntity instances in the database.</summary>
		public DataSource<SeverityEntity> Severity
		{
			get { return new DataSource<SeverityEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting SupportAreaEntity instances in the database.</summary>
		public DataSource<SupportAreaEntity> SupportArea
		{
			get { return new DataSource<SupportAreaEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting SupportIssueEntity instances in the database.</summary>
		public DataSource<SupportIssueEntity> SupportIssue
		{
			get { return new DataSource<SupportIssueEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting SystemSettingEntity instances in the database.</summary>
		public DataSource<SystemSettingEntity> SystemSetting
		{
			get { return new DataSource<SystemSettingEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting TreatmentEntity instances in the database.</summary>
		public DataSource<TreatmentEntity> Treatment
		{
			get { return new DataSource<TreatmentEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting UpdateStatusEntity instances in the database.</summary>
		public DataSource<UpdateStatusEntity> UpdateStatus
		{
			get { return new DataSource<UpdateStatusEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting UserEntity instances in the database.</summary>
		public DataSource<UserEntity> User
		{
			get { return new DataSource<UserEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting UserAccountRestrictionEntity instances in the database.</summary>
		public DataSource<UserAccountRestrictionEntity> UserAccountRestriction
		{
			get { return new DataSource<UserAccountRestrictionEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting UserAssignedLocationEntity instances in the database.</summary>
		public DataSource<UserAssignedLocationEntity> UserAssignedLocation
		{
			get { return new DataSource<UserAssignedLocationEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting UserCreditCardEntity instances in the database.</summary>
		public DataSource<UserCreditCardEntity> UserCreditCard
		{
			get { return new DataSource<UserCreditCardEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting UserRoleEntity instances in the database.</summary>
		public DataSource<UserRoleEntity> UserRole
		{
			get { return new DataSource<UserRoleEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting UserSaltEntity instances in the database.</summary>
		public DataSource<UserSaltEntity> UserSalt
		{
			get { return new DataSource<UserSaltEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		/// <summary>returns the datasource to use in a Linq query when targeting UserSettingEntity instances in the database.</summary>
		public DataSource<UserSettingEntity> UserSetting
		{
			get { return new DataSource<UserSettingEntity>(_transactionToUse, new ElementCreator(), _customFunctionMappings, _contextToUse); }
		}
		
		#region Class Property Declarations
		/// <summary> Gets / sets the ITransaction to use for the queries created with this meta data object.</summary>
		/// <remarks> Be aware that the ITransaction object set via this property is kept alive by the LLBLGenProQuery objects created with this meta data
		/// till they go out of scope.</remarks>
		public ITransaction TransactionToUse
		{
			get { return _transactionToUse;}
			set { _transactionToUse = value;}
		}

		/// <summary>Gets or sets the custom function mappings to use. These take higher precedence than the ones in the DQE to use</summary>
		public FunctionMappingStore CustomFunctionMappings
		{
			get { return _customFunctionMappings; }
			set { _customFunctionMappings = value; }
		}
		
		/// <summary>Gets or sets the Context instance to use for entity fetches.</summary>
		public Context ContextToUse
		{
			get { return _contextToUse;}
			set { _contextToUse = value;}
		}
		#endregion
	}
}