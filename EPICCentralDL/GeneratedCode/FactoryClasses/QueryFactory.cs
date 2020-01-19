///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET35
// Templates vendor: Solutions Design.
////////////////////////////////////////////////////////////// 
using System;
using EPICCentralDL.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.QuerySpec;

namespace EPICCentralDL.FactoryClasses
{
	/// <summary>Factory class to produce DynamicQuery instances and EntityQuery instances</summary>
	public partial class QueryFactory
	{
		private int _aliasCounter = 0;

		/// <summary>Creates a new DynamicQuery instance with no alias set.</summary>
		/// <returns>Ready to use DynamicQuery instance</returns>
		public DynamicQuery Create()
		{
			return Create(string.Empty);
		}

		/// <summary>Creates a new DynamicQuery instance with the alias specified as the alias set.</summary>
		/// <param name="alias">The alias.</param>
		/// <returns>Ready to use DynamicQuery instance</returns>
		public DynamicQuery Create(string alias)
		{
			return new DynamicQuery(new ElementCreator(), alias, this.GetNextAliasCounterValue());
		}

		/// <summary>Creates a new EntityQuery for the entity of the type specified with no alias set.</summary>
		/// <typeparam name="TEntity">The type of the entity to produce the query for.</typeparam>
		/// <returns>ready to use EntityQuery instance</returns>
		public EntityQuery<TEntity> Create<TEntity>()
			where TEntity : IEntityCore
		{
			return Create<TEntity>(string.Empty);
		}

		/// <summary>Creates a new EntityQuery for the entity of the type specified with the alias specified as the alias set.</summary>
		/// <typeparam name="TEntity">The type of the entity to produce the query for.</typeparam>
		/// <param name="alias">The alias.</param>
		/// <returns>ready to use EntityQuery instance</returns>
		public EntityQuery<TEntity> Create<TEntity>(string alias)
			where TEntity : IEntityCore
		{
			return new EntityQuery<TEntity>(new ElementCreator(), alias, this.GetNextAliasCounterValue());
		}
				
		/// <summary>Creates a new field object with the name specified and of resulttype 'object'. Used for referring to aliased fields in another projection.</summary>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>Ready to use field object</returns>
		public EntityField Field(string fieldName)
		{
			return Field<object>(string.Empty, fieldName);
		}

		/// <summary>Creates a new field object with the name specified and of resulttype 'object'. Used for referring to aliased fields in another projection.</summary>
		/// <param name="targetAlias">The alias of the table/query to target.</param>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>Ready to use field object</returns>
		public EntityField Field(string targetAlias, string fieldName)
		{
			return Field<object>(targetAlias, fieldName);
		}

		/// <summary>Creates a new field object with the name specified and of resulttype 'TValue'. Used for referring to aliased fields in another projection.</summary>
		/// <typeparam name="TValue">The type of the value represented by the field.</typeparam>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>Ready to use field object</returns>
		public EntityField Field<TValue>(string fieldName)
		{
			return Field<TValue>(string.Empty, fieldName);
		}

		/// <summary>Creates a new field object with the name specified and of resulttype 'TValue'. Used for referring to aliased fields in another projection.</summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="targetAlias">The alias of the table/query to target.</param>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>Ready to use field object</returns>
		public EntityField Field<TValue>(string targetAlias, string fieldName)
		{
			return new EntityField(fieldName, targetAlias, typeof(TValue));
		}
						
		/// <summary>Gets the next alias counter value to produce artifical aliases with</summary>
		private int GetNextAliasCounterValue()
		{
			_aliasCounter++;
			return _aliasCounter;
		}
		
		/// <summary>Creates and returns a new EntityQuery for the AccountRestriction entity</summary>
		public EntityQuery<AccountRestrictionEntity> AccountRestriction
		{
			get { return Create<AccountRestrictionEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ActiveOrganization entity</summary>
		public EntityQuery<ActiveOrganizationEntity> ActiveOrganization
		{
			get { return Create<ActiveOrganizationEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ActivityType entity</summary>
		public EntityQuery<ActivityTypeEntity> ActivityType
		{
			get { return Create<ActivityTypeEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the AnalysisResult entity</summary>
		public EntityQuery<AnalysisResultEntity> AnalysisResult
		{
			get { return Create<AnalysisResultEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Application entity</summary>
		public EntityQuery<ApplicationEntity> Application
		{
			get { return Create<ApplicationEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Audit entity</summary>
		public EntityQuery<AuditEntity> Audit
		{
			get { return Create<AuditEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the CalculationDebugData entity</summary>
		public EntityQuery<CalculationDebugDataEntity> CalculationDebugData
		{
			get { return Create<CalculationDebugDataEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Calibration entity</summary>
		public EntityQuery<CalibrationEntity> Calibration
		{
			get { return Create<CalibrationEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Contact entity</summary>
		public EntityQuery<ContactEntity> Contact
		{
			get { return Create<ContactEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the CreditCard entity</summary>
		public EntityQuery<CreditCardEntity> CreditCard
		{
			get { return Create<CreditCardEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Device entity</summary>
		public EntityQuery<DeviceEntity> Device
		{
			get { return Create<DeviceEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the DeviceEvent entity</summary>
		public EntityQuery<DeviceEventEntity> DeviceEvent
		{
			get { return Create<DeviceEventEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the DeviceMessage entity</summary>
		public EntityQuery<DeviceMessageEntity> DeviceMessage
		{
			get { return Create<DeviceMessageEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the DeviceStateTracking entity</summary>
		public EntityQuery<DeviceStateTrackingEntity> DeviceStateTracking
		{
			get { return Create<DeviceStateTrackingEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ExceptionLog entity</summary>
		public EntityQuery<ExceptionLogEntity> ExceptionLog
		{
			get { return Create<ExceptionLogEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ImageCache entity</summary>
		public EntityQuery<ImageCacheEntity> ImageCache
		{
			get { return Create<ImageCacheEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ImageSet entity</summary>
		public EntityQuery<ImageSetEntity> ImageSet
		{
			get { return Create<ImageSetEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the LicenseOrganSystem entity</summary>
		public EntityQuery<LicenseOrganSystemEntity> LicenseOrganSystem
		{
			get { return Create<LicenseOrganSystemEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Location entity</summary>
		public EntityQuery<LocationEntity> Location
		{
			get { return Create<LocationEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Message entity</summary>
		public EntityQuery<MessageEntity> Message
		{
			get { return Create<MessageEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the NBAnalysisResult entity</summary>
		public EntityQuery<NBAnalysisResultEntity> NBAnalysisResult
		{
			get { return Create<NBAnalysisResultEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Organ entity</summary>
		public EntityQuery<OrganEntity> Organ
		{
			get { return Create<OrganEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Organization entity</summary>
		public EntityQuery<OrganizationEntity> Organization
		{
			get { return Create<OrganizationEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the OrganSystem entity</summary>
		public EntityQuery<OrganSystemEntity> OrganSystem
		{
			get { return Create<OrganSystemEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the OrganSystemOrgan entity</summary>
		public EntityQuery<OrganSystemOrganEntity> OrganSystemOrgan
		{
			get { return Create<OrganSystemOrganEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Patient entity</summary>
		public EntityQuery<PatientEntity> Patient
		{
			get { return Create<PatientEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the PatientPrescanQuestion entity</summary>
		public EntityQuery<PatientPrescanQuestionEntity> PatientPrescanQuestion
		{
			get { return Create<PatientPrescanQuestionEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the PurchaseHistory entity</summary>
		public EntityQuery<PurchaseHistoryEntity> PurchaseHistory
		{
			get { return Create<PurchaseHistoryEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Role entity</summary>
		public EntityQuery<RoleEntity> Role
		{
			get { return Create<RoleEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ScanHistory entity</summary>
		public EntityQuery<ScanHistoryEntity> ScanHistory
		{
			get { return Create<ScanHistoryEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the ScanRate entity</summary>
		public EntityQuery<ScanRateEntity> ScanRate
		{
			get { return Create<ScanRateEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Session entity</summary>
		public EntityQuery<SessionEntity> Session
		{
			get { return Create<SessionEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Severity entity</summary>
		public EntityQuery<SeverityEntity> Severity
		{
			get { return Create<SeverityEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the SupportArea entity</summary>
		public EntityQuery<SupportAreaEntity> SupportArea
		{
			get { return Create<SupportAreaEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the SupportIssue entity</summary>
		public EntityQuery<SupportIssueEntity> SupportIssue
		{
			get { return Create<SupportIssueEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the SystemSetting entity</summary>
		public EntityQuery<SystemSettingEntity> SystemSetting
		{
			get { return Create<SystemSettingEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the Treatment entity</summary>
		public EntityQuery<TreatmentEntity> Treatment
		{
			get { return Create<TreatmentEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the UpdateStatus entity</summary>
		public EntityQuery<UpdateStatusEntity> UpdateStatus
		{
			get { return Create<UpdateStatusEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the User entity</summary>
		public EntityQuery<UserEntity> User
		{
			get { return Create<UserEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the UserAccountRestriction entity</summary>
		public EntityQuery<UserAccountRestrictionEntity> UserAccountRestriction
		{
			get { return Create<UserAccountRestrictionEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the UserAssignedLocation entity</summary>
		public EntityQuery<UserAssignedLocationEntity> UserAssignedLocation
		{
			get { return Create<UserAssignedLocationEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the UserCreditCard entity</summary>
		public EntityQuery<UserCreditCardEntity> UserCreditCard
		{
			get { return Create<UserCreditCardEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the UserRole entity</summary>
		public EntityQuery<UserRoleEntity> UserRole
		{
			get { return Create<UserRoleEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the UserSalt entity</summary>
		public EntityQuery<UserSaltEntity> UserSalt
		{
			get { return Create<UserSaltEntity>(); }
		}

		/// <summary>Creates and returns a new EntityQuery for the UserSetting entity</summary>
		public EntityQuery<UserSettingEntity> UserSetting
		{
			get { return Create<UserSettingEntity>(); }
		}

	}
}