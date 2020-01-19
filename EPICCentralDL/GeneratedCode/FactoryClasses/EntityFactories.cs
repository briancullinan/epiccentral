///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using EPICCentralDL.HelperClasses;

using EPICCentralDL.EntityClasses;
using EPICCentralDL.RelationClasses;
using EPICCentralDL.DaoClasses;
using EPICCentralDL.CollectionClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentralDL.FactoryClasses
{
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	/// <summary>general base class for the generated factories</summary>
	[Serializable]
	public partial class EntityFactoryBase : EntityFactoryCore
	{
		private readonly EPICCentralDL.EntityType _typeOfEntity;
		
		/// <summary>CTor</summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <param name="typeOfEntity">The type of entity.</param>
		public EntityFactoryBase(string entityName, EPICCentralDL.EntityType typeOfEntity) : base(entityName)
		{
			_typeOfEntity = typeOfEntity;
		}

		/// <summary>Creates a new entity instance using the GeneralEntityFactory in the generated code, using the passed in entitytype value</summary>
		/// <param name="entityTypeValue">The entity type value of the entity to create an instance for.</param>
		/// <returns>new IEntity instance</returns>
		public override IEntity CreateEntityFromEntityTypeValue(int entityTypeValue)
		{
			return GeneralEntityFactory.Create((EPICCentralDL.EntityType)entityTypeValue);
		}
		
		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public override IEntityFields CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(_typeOfEntity);
		}

		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <param name="objectAlias">The object alias to use for the elements in the relations.</param>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public override IRelationCollection CreateHierarchyRelations(string objectAlias) 
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetHierarchyRelations(ForEntityName, objectAlias);
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public override IEntityFactory GetEntityFactory(object[] fieldValues, Dictionary<string, int> entityFieldStartIndexesPerEntity)
		{
			return (IEntityFactory)InheritanceInfoProviderSingleton.GetInstance().GetEntityFactory(ForEntityName, fieldValues, entityFieldStartIndexesPerEntity) ?? this;
		}
						
		/// <summary>Creates a new entity collection for the entity of this factory.</summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		public override IEntityCollection CreateEntityCollection()
		{
			return GeneralEntityCollectionFactory.Create(_typeOfEntity);
		}
	}
	
	/// <summary>Factory to create new, empty AccountRestrictionEntity objects.</summary>
	[Serializable]
	public partial class AccountRestrictionEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public AccountRestrictionEntityFactory() : base("AccountRestrictionEntity", EPICCentralDL.EntityType.AccountRestrictionEntity) { }

		/// <summary>Creates a new, empty AccountRestrictionEntity object.</summary>
		/// <returns>A new, empty AccountRestrictionEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new AccountRestrictionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAccountRestriction
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty ActiveOrganizationEntity objects.</summary>
	[Serializable]
	public partial class ActiveOrganizationEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public ActiveOrganizationEntityFactory() : base("ActiveOrganizationEntity", EPICCentralDL.EntityType.ActiveOrganizationEntity) { }

		/// <summary>Creates a new, empty ActiveOrganizationEntity object.</summary>
		/// <returns>A new, empty ActiveOrganizationEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new ActiveOrganizationEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewActiveOrganization
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty ActivityTypeEntity objects.</summary>
	[Serializable]
	public partial class ActivityTypeEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public ActivityTypeEntityFactory() : base("ActivityTypeEntity", EPICCentralDL.EntityType.ActivityTypeEntity) { }

		/// <summary>Creates a new, empty ActivityTypeEntity object.</summary>
		/// <returns>A new, empty ActivityTypeEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new ActivityTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewActivityType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty AnalysisResultEntity objects.</summary>
	[Serializable]
	public partial class AnalysisResultEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public AnalysisResultEntityFactory() : base("AnalysisResultEntity", EPICCentralDL.EntityType.AnalysisResultEntity) { }

		/// <summary>Creates a new, empty AnalysisResultEntity object.</summary>
		/// <returns>A new, empty AnalysisResultEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new AnalysisResultEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAnalysisResult
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty ApplicationEntity objects.</summary>
	[Serializable]
	public partial class ApplicationEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public ApplicationEntityFactory() : base("ApplicationEntity", EPICCentralDL.EntityType.ApplicationEntity) { }

		/// <summary>Creates a new, empty ApplicationEntity object.</summary>
		/// <returns>A new, empty ApplicationEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new ApplicationEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewApplication
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty AuditEntity objects.</summary>
	[Serializable]
	public partial class AuditEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public AuditEntityFactory() : base("AuditEntity", EPICCentralDL.EntityType.AuditEntity) { }

		/// <summary>Creates a new, empty AuditEntity object.</summary>
		/// <returns>A new, empty AuditEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new AuditEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewAudit
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty CalculationDebugDataEntity objects.</summary>
	[Serializable]
	public partial class CalculationDebugDataEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public CalculationDebugDataEntityFactory() : base("CalculationDebugDataEntity", EPICCentralDL.EntityType.CalculationDebugDataEntity) { }

		/// <summary>Creates a new, empty CalculationDebugDataEntity object.</summary>
		/// <returns>A new, empty CalculationDebugDataEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new CalculationDebugDataEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCalculationDebugData
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty CalibrationEntity objects.</summary>
	[Serializable]
	public partial class CalibrationEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public CalibrationEntityFactory() : base("CalibrationEntity", EPICCentralDL.EntityType.CalibrationEntity) { }

		/// <summary>Creates a new, empty CalibrationEntity object.</summary>
		/// <returns>A new, empty CalibrationEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new CalibrationEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCalibration
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty ContactEntity objects.</summary>
	[Serializable]
	public partial class ContactEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public ContactEntityFactory() : base("ContactEntity", EPICCentralDL.EntityType.ContactEntity) { }

		/// <summary>Creates a new, empty ContactEntity object.</summary>
		/// <returns>A new, empty ContactEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new ContactEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewContact
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty CreditCardEntity objects.</summary>
	[Serializable]
	public partial class CreditCardEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public CreditCardEntityFactory() : base("CreditCardEntity", EPICCentralDL.EntityType.CreditCardEntity) { }

		/// <summary>Creates a new, empty CreditCardEntity object.</summary>
		/// <returns>A new, empty CreditCardEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new CreditCardEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCreditCard
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty DeviceEntity objects.</summary>
	[Serializable]
	public partial class DeviceEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public DeviceEntityFactory() : base("DeviceEntity", EPICCentralDL.EntityType.DeviceEntity) { }

		/// <summary>Creates a new, empty DeviceEntity object.</summary>
		/// <returns>A new, empty DeviceEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new DeviceEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewDevice
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty DeviceEventEntity objects.</summary>
	[Serializable]
	public partial class DeviceEventEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public DeviceEventEntityFactory() : base("DeviceEventEntity", EPICCentralDL.EntityType.DeviceEventEntity) { }

		/// <summary>Creates a new, empty DeviceEventEntity object.</summary>
		/// <returns>A new, empty DeviceEventEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new DeviceEventEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewDeviceEvent
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty DeviceMessageEntity objects.</summary>
	[Serializable]
	public partial class DeviceMessageEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public DeviceMessageEntityFactory() : base("DeviceMessageEntity", EPICCentralDL.EntityType.DeviceMessageEntity) { }

		/// <summary>Creates a new, empty DeviceMessageEntity object.</summary>
		/// <returns>A new, empty DeviceMessageEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new DeviceMessageEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewDeviceMessage
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty DeviceStateTrackingEntity objects.</summary>
	[Serializable]
	public partial class DeviceStateTrackingEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public DeviceStateTrackingEntityFactory() : base("DeviceStateTrackingEntity", EPICCentralDL.EntityType.DeviceStateTrackingEntity) { }

		/// <summary>Creates a new, empty DeviceStateTrackingEntity object.</summary>
		/// <returns>A new, empty DeviceStateTrackingEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new DeviceStateTrackingEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewDeviceStateTracking
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty ExceptionLogEntity objects.</summary>
	[Serializable]
	public partial class ExceptionLogEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public ExceptionLogEntityFactory() : base("ExceptionLogEntity", EPICCentralDL.EntityType.ExceptionLogEntity) { }

		/// <summary>Creates a new, empty ExceptionLogEntity object.</summary>
		/// <returns>A new, empty ExceptionLogEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new ExceptionLogEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewExceptionLog
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty ImageCacheEntity objects.</summary>
	[Serializable]
	public partial class ImageCacheEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public ImageCacheEntityFactory() : base("ImageCacheEntity", EPICCentralDL.EntityType.ImageCacheEntity) { }

		/// <summary>Creates a new, empty ImageCacheEntity object.</summary>
		/// <returns>A new, empty ImageCacheEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new ImageCacheEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewImageCache
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty ImageSetEntity objects.</summary>
	[Serializable]
	public partial class ImageSetEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public ImageSetEntityFactory() : base("ImageSetEntity", EPICCentralDL.EntityType.ImageSetEntity) { }

		/// <summary>Creates a new, empty ImageSetEntity object.</summary>
		/// <returns>A new, empty ImageSetEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new ImageSetEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewImageSet
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty LicenseOrganSystemEntity objects.</summary>
	[Serializable]
	public partial class LicenseOrganSystemEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public LicenseOrganSystemEntityFactory() : base("LicenseOrganSystemEntity", EPICCentralDL.EntityType.LicenseOrganSystemEntity) { }

		/// <summary>Creates a new, empty LicenseOrganSystemEntity object.</summary>
		/// <returns>A new, empty LicenseOrganSystemEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new LicenseOrganSystemEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewLicenseOrganSystem
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty LocationEntity objects.</summary>
	[Serializable]
	public partial class LocationEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public LocationEntityFactory() : base("LocationEntity", EPICCentralDL.EntityType.LocationEntity) { }

		/// <summary>Creates a new, empty LocationEntity object.</summary>
		/// <returns>A new, empty LocationEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new LocationEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewLocation
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty MessageEntity objects.</summary>
	[Serializable]
	public partial class MessageEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public MessageEntityFactory() : base("MessageEntity", EPICCentralDL.EntityType.MessageEntity) { }

		/// <summary>Creates a new, empty MessageEntity object.</summary>
		/// <returns>A new, empty MessageEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new MessageEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewMessage
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty NBAnalysisResultEntity objects.</summary>
	[Serializable]
	public partial class NBAnalysisResultEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public NBAnalysisResultEntityFactory() : base("NBAnalysisResultEntity", EPICCentralDL.EntityType.NBAnalysisResultEntity) { }

		/// <summary>Creates a new, empty NBAnalysisResultEntity object.</summary>
		/// <returns>A new, empty NBAnalysisResultEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new NBAnalysisResultEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewNBAnalysisResult
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty OrganEntity objects.</summary>
	[Serializable]
	public partial class OrganEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public OrganEntityFactory() : base("OrganEntity", EPICCentralDL.EntityType.OrganEntity) { }

		/// <summary>Creates a new, empty OrganEntity object.</summary>
		/// <returns>A new, empty OrganEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new OrganEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewOrgan
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty OrganizationEntity objects.</summary>
	[Serializable]
	public partial class OrganizationEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public OrganizationEntityFactory() : base("OrganizationEntity", EPICCentralDL.EntityType.OrganizationEntity) { }

		/// <summary>Creates a new, empty OrganizationEntity object.</summary>
		/// <returns>A new, empty OrganizationEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new OrganizationEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewOrganization
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty OrganSystemEntity objects.</summary>
	[Serializable]
	public partial class OrganSystemEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public OrganSystemEntityFactory() : base("OrganSystemEntity", EPICCentralDL.EntityType.OrganSystemEntity) { }

		/// <summary>Creates a new, empty OrganSystemEntity object.</summary>
		/// <returns>A new, empty OrganSystemEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new OrganSystemEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewOrganSystem
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty OrganSystemOrganEntity objects.</summary>
	[Serializable]
	public partial class OrganSystemOrganEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public OrganSystemOrganEntityFactory() : base("OrganSystemOrganEntity", EPICCentralDL.EntityType.OrganSystemOrganEntity) { }

		/// <summary>Creates a new, empty OrganSystemOrganEntity object.</summary>
		/// <returns>A new, empty OrganSystemOrganEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new OrganSystemOrganEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewOrganSystemOrgan
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty PatientEntity objects.</summary>
	[Serializable]
	public partial class PatientEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public PatientEntityFactory() : base("PatientEntity", EPICCentralDL.EntityType.PatientEntity) { }

		/// <summary>Creates a new, empty PatientEntity object.</summary>
		/// <returns>A new, empty PatientEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new PatientEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewPatient
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty PatientPrescanQuestionEntity objects.</summary>
	[Serializable]
	public partial class PatientPrescanQuestionEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public PatientPrescanQuestionEntityFactory() : base("PatientPrescanQuestionEntity", EPICCentralDL.EntityType.PatientPrescanQuestionEntity) { }

		/// <summary>Creates a new, empty PatientPrescanQuestionEntity object.</summary>
		/// <returns>A new, empty PatientPrescanQuestionEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new PatientPrescanQuestionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewPatientPrescanQuestion
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty PurchaseHistoryEntity objects.</summary>
	[Serializable]
	public partial class PurchaseHistoryEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public PurchaseHistoryEntityFactory() : base("PurchaseHistoryEntity", EPICCentralDL.EntityType.PurchaseHistoryEntity) { }

		/// <summary>Creates a new, empty PurchaseHistoryEntity object.</summary>
		/// <returns>A new, empty PurchaseHistoryEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new PurchaseHistoryEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewPurchaseHistory
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty RoleEntity objects.</summary>
	[Serializable]
	public partial class RoleEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public RoleEntityFactory() : base("RoleEntity", EPICCentralDL.EntityType.RoleEntity) { }

		/// <summary>Creates a new, empty RoleEntity object.</summary>
		/// <returns>A new, empty RoleEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new RoleEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRole
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty ScanHistoryEntity objects.</summary>
	[Serializable]
	public partial class ScanHistoryEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public ScanHistoryEntityFactory() : base("ScanHistoryEntity", EPICCentralDL.EntityType.ScanHistoryEntity) { }

		/// <summary>Creates a new, empty ScanHistoryEntity object.</summary>
		/// <returns>A new, empty ScanHistoryEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new ScanHistoryEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewScanHistory
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty ScanRateEntity objects.</summary>
	[Serializable]
	public partial class ScanRateEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public ScanRateEntityFactory() : base("ScanRateEntity", EPICCentralDL.EntityType.ScanRateEntity) { }

		/// <summary>Creates a new, empty ScanRateEntity object.</summary>
		/// <returns>A new, empty ScanRateEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new ScanRateEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewScanRate
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty SessionEntity objects.</summary>
	[Serializable]
	public partial class SessionEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public SessionEntityFactory() : base("SessionEntity", EPICCentralDL.EntityType.SessionEntity) { }

		/// <summary>Creates a new, empty SessionEntity object.</summary>
		/// <returns>A new, empty SessionEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new SessionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSession
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty SeverityEntity objects.</summary>
	[Serializable]
	public partial class SeverityEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public SeverityEntityFactory() : base("SeverityEntity", EPICCentralDL.EntityType.SeverityEntity) { }

		/// <summary>Creates a new, empty SeverityEntity object.</summary>
		/// <returns>A new, empty SeverityEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new SeverityEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSeverity
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty SupportAreaEntity objects.</summary>
	[Serializable]
	public partial class SupportAreaEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public SupportAreaEntityFactory() : base("SupportAreaEntity", EPICCentralDL.EntityType.SupportAreaEntity) { }

		/// <summary>Creates a new, empty SupportAreaEntity object.</summary>
		/// <returns>A new, empty SupportAreaEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new SupportAreaEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSupportArea
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty SupportIssueEntity objects.</summary>
	[Serializable]
	public partial class SupportIssueEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public SupportIssueEntityFactory() : base("SupportIssueEntity", EPICCentralDL.EntityType.SupportIssueEntity) { }

		/// <summary>Creates a new, empty SupportIssueEntity object.</summary>
		/// <returns>A new, empty SupportIssueEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new SupportIssueEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSupportIssue
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty SystemSettingEntity objects.</summary>
	[Serializable]
	public partial class SystemSettingEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public SystemSettingEntityFactory() : base("SystemSettingEntity", EPICCentralDL.EntityType.SystemSettingEntity) { }

		/// <summary>Creates a new, empty SystemSettingEntity object.</summary>
		/// <returns>A new, empty SystemSettingEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new SystemSettingEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSystemSetting
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty TreatmentEntity objects.</summary>
	[Serializable]
	public partial class TreatmentEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public TreatmentEntityFactory() : base("TreatmentEntity", EPICCentralDL.EntityType.TreatmentEntity) { }

		/// <summary>Creates a new, empty TreatmentEntity object.</summary>
		/// <returns>A new, empty TreatmentEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new TreatmentEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTreatment
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty UpdateStatusEntity objects.</summary>
	[Serializable]
	public partial class UpdateStatusEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public UpdateStatusEntityFactory() : base("UpdateStatusEntity", EPICCentralDL.EntityType.UpdateStatusEntity) { }

		/// <summary>Creates a new, empty UpdateStatusEntity object.</summary>
		/// <returns>A new, empty UpdateStatusEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new UpdateStatusEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUpdateStatus
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty UserEntity objects.</summary>
	[Serializable]
	public partial class UserEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public UserEntityFactory() : base("UserEntity", EPICCentralDL.EntityType.UserEntity) { }

		/// <summary>Creates a new, empty UserEntity object.</summary>
		/// <returns>A new, empty UserEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new UserEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUser
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty UserAccountRestrictionEntity objects.</summary>
	[Serializable]
	public partial class UserAccountRestrictionEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public UserAccountRestrictionEntityFactory() : base("UserAccountRestrictionEntity", EPICCentralDL.EntityType.UserAccountRestrictionEntity) { }

		/// <summary>Creates a new, empty UserAccountRestrictionEntity object.</summary>
		/// <returns>A new, empty UserAccountRestrictionEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new UserAccountRestrictionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUserAccountRestriction
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty UserAssignedLocationEntity objects.</summary>
	[Serializable]
	public partial class UserAssignedLocationEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public UserAssignedLocationEntityFactory() : base("UserAssignedLocationEntity", EPICCentralDL.EntityType.UserAssignedLocationEntity) { }

		/// <summary>Creates a new, empty UserAssignedLocationEntity object.</summary>
		/// <returns>A new, empty UserAssignedLocationEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new UserAssignedLocationEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUserAssignedLocation
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty UserCreditCardEntity objects.</summary>
	[Serializable]
	public partial class UserCreditCardEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public UserCreditCardEntityFactory() : base("UserCreditCardEntity", EPICCentralDL.EntityType.UserCreditCardEntity) { }

		/// <summary>Creates a new, empty UserCreditCardEntity object.</summary>
		/// <returns>A new, empty UserCreditCardEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new UserCreditCardEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUserCreditCard
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty UserRoleEntity objects.</summary>
	[Serializable]
	public partial class UserRoleEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public UserRoleEntityFactory() : base("UserRoleEntity", EPICCentralDL.EntityType.UserRoleEntity) { }

		/// <summary>Creates a new, empty UserRoleEntity object.</summary>
		/// <returns>A new, empty UserRoleEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new UserRoleEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUserRole
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty UserSaltEntity objects.</summary>
	[Serializable]
	public partial class UserSaltEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public UserSaltEntityFactory() : base("UserSaltEntity", EPICCentralDL.EntityType.UserSaltEntity) { }

		/// <summary>Creates a new, empty UserSaltEntity object.</summary>
		/// <returns>A new, empty UserSaltEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new UserSaltEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUserSalt
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}
	
	/// <summary>Factory to create new, empty UserSettingEntity objects.</summary>
	[Serializable]
	public partial class UserSettingEntityFactory : EntityFactoryBase {
		/// <summary>CTor</summary>
		public UserSettingEntityFactory() : base("UserSettingEntity", EPICCentralDL.EntityType.UserSettingEntity) { }

		/// <summary>Creates a new, empty UserSettingEntity object.</summary>
		/// <returns>A new, empty UserSettingEntity object.</returns>
		public override IEntity Create() {
			IEntity toReturn = new UserSettingEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewUserSetting
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}


		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new entity collection objects</summary>
	[Serializable]
	public partial class GeneralEntityCollectionFactory
	{
		/// <summary>Creates a new entity collection</summary>
		/// <param name="typeToUse">The entity type to create the collection for.</param>
		/// <returns>A new entity collection object.</returns>
		public static IEntityCollection Create(EPICCentralDL.EntityType typeToUse)
		{
			switch(typeToUse)
			{
				case EPICCentralDL.EntityType.AccountRestrictionEntity:
					return new AccountRestrictionCollection();
				case EPICCentralDL.EntityType.ActiveOrganizationEntity:
					return new ActiveOrganizationCollection();
				case EPICCentralDL.EntityType.ActivityTypeEntity:
					return new ActivityTypeCollection();
				case EPICCentralDL.EntityType.AnalysisResultEntity:
					return new AnalysisResultCollection();
				case EPICCentralDL.EntityType.ApplicationEntity:
					return new ApplicationCollection();
				case EPICCentralDL.EntityType.AuditEntity:
					return new AuditCollection();
				case EPICCentralDL.EntityType.CalculationDebugDataEntity:
					return new CalculationDebugDataCollection();
				case EPICCentralDL.EntityType.CalibrationEntity:
					return new CalibrationCollection();
				case EPICCentralDL.EntityType.ContactEntity:
					return new ContactCollection();
				case EPICCentralDL.EntityType.CreditCardEntity:
					return new CreditCardCollection();
				case EPICCentralDL.EntityType.DeviceEntity:
					return new DeviceCollection();
				case EPICCentralDL.EntityType.DeviceEventEntity:
					return new DeviceEventCollection();
				case EPICCentralDL.EntityType.DeviceMessageEntity:
					return new DeviceMessageCollection();
				case EPICCentralDL.EntityType.DeviceStateTrackingEntity:
					return new DeviceStateTrackingCollection();
				case EPICCentralDL.EntityType.ExceptionLogEntity:
					return new ExceptionLogCollection();
				case EPICCentralDL.EntityType.ImageCacheEntity:
					return new ImageCacheCollection();
				case EPICCentralDL.EntityType.ImageSetEntity:
					return new ImageSetCollection();
				case EPICCentralDL.EntityType.LicenseOrganSystemEntity:
					return new LicenseOrganSystemCollection();
				case EPICCentralDL.EntityType.LocationEntity:
					return new LocationCollection();
				case EPICCentralDL.EntityType.MessageEntity:
					return new MessageCollection();
				case EPICCentralDL.EntityType.NBAnalysisResultEntity:
					return new NBAnalysisResultCollection();
				case EPICCentralDL.EntityType.OrganEntity:
					return new OrganCollection();
				case EPICCentralDL.EntityType.OrganizationEntity:
					return new OrganizationCollection();
				case EPICCentralDL.EntityType.OrganSystemEntity:
					return new OrganSystemCollection();
				case EPICCentralDL.EntityType.OrganSystemOrganEntity:
					return new OrganSystemOrganCollection();
				case EPICCentralDL.EntityType.PatientEntity:
					return new PatientCollection();
				case EPICCentralDL.EntityType.PatientPrescanQuestionEntity:
					return new PatientPrescanQuestionCollection();
				case EPICCentralDL.EntityType.PurchaseHistoryEntity:
					return new PurchaseHistoryCollection();
				case EPICCentralDL.EntityType.RoleEntity:
					return new RoleCollection();
				case EPICCentralDL.EntityType.ScanHistoryEntity:
					return new ScanHistoryCollection();
				case EPICCentralDL.EntityType.ScanRateEntity:
					return new ScanRateCollection();
				case EPICCentralDL.EntityType.SessionEntity:
					return new SessionCollection();
				case EPICCentralDL.EntityType.SeverityEntity:
					return new SeverityCollection();
				case EPICCentralDL.EntityType.SupportAreaEntity:
					return new SupportAreaCollection();
				case EPICCentralDL.EntityType.SupportIssueEntity:
					return new SupportIssueCollection();
				case EPICCentralDL.EntityType.SystemSettingEntity:
					return new SystemSettingCollection();
				case EPICCentralDL.EntityType.TreatmentEntity:
					return new TreatmentCollection();
				case EPICCentralDL.EntityType.UpdateStatusEntity:
					return new UpdateStatusCollection();
				case EPICCentralDL.EntityType.UserEntity:
					return new UserCollection();
				case EPICCentralDL.EntityType.UserAccountRestrictionEntity:
					return new UserAccountRestrictionCollection();
				case EPICCentralDL.EntityType.UserAssignedLocationEntity:
					return new UserAssignedLocationCollection();
				case EPICCentralDL.EntityType.UserCreditCardEntity:
					return new UserCreditCardCollection();
				case EPICCentralDL.EntityType.UserRoleEntity:
					return new UserRoleCollection();
				case EPICCentralDL.EntityType.UserSaltEntity:
					return new UserSaltCollection();
				case EPICCentralDL.EntityType.UserSettingEntity:
					return new UserSettingCollection();
				default:
					return null;
			}
		}		
	}
	
	/// <summary>Factory to create new, empty Entity objects based on the entity type specified. Uses entity specific factory objects</summary>
	[Serializable]
	public partial class GeneralEntityFactory
	{
		/// <summary>Creates a new, empty Entity object of the type specified</summary>
		/// <param name="entityTypeToCreate">The entity type to create.</param>
		/// <returns>A new, empty Entity object.</returns>
		public static IEntity Create(EPICCentralDL.EntityType entityTypeToCreate)
		{
			IEntityFactory factoryToUse = null;
			switch(entityTypeToCreate)
			{
				case EPICCentralDL.EntityType.AccountRestrictionEntity:
					factoryToUse = new AccountRestrictionEntityFactory();
					break;
				case EPICCentralDL.EntityType.ActiveOrganizationEntity:
					factoryToUse = new ActiveOrganizationEntityFactory();
					break;
				case EPICCentralDL.EntityType.ActivityTypeEntity:
					factoryToUse = new ActivityTypeEntityFactory();
					break;
				case EPICCentralDL.EntityType.AnalysisResultEntity:
					factoryToUse = new AnalysisResultEntityFactory();
					break;
				case EPICCentralDL.EntityType.ApplicationEntity:
					factoryToUse = new ApplicationEntityFactory();
					break;
				case EPICCentralDL.EntityType.AuditEntity:
					factoryToUse = new AuditEntityFactory();
					break;
				case EPICCentralDL.EntityType.CalculationDebugDataEntity:
					factoryToUse = new CalculationDebugDataEntityFactory();
					break;
				case EPICCentralDL.EntityType.CalibrationEntity:
					factoryToUse = new CalibrationEntityFactory();
					break;
				case EPICCentralDL.EntityType.ContactEntity:
					factoryToUse = new ContactEntityFactory();
					break;
				case EPICCentralDL.EntityType.CreditCardEntity:
					factoryToUse = new CreditCardEntityFactory();
					break;
				case EPICCentralDL.EntityType.DeviceEntity:
					factoryToUse = new DeviceEntityFactory();
					break;
				case EPICCentralDL.EntityType.DeviceEventEntity:
					factoryToUse = new DeviceEventEntityFactory();
					break;
				case EPICCentralDL.EntityType.DeviceMessageEntity:
					factoryToUse = new DeviceMessageEntityFactory();
					break;
				case EPICCentralDL.EntityType.DeviceStateTrackingEntity:
					factoryToUse = new DeviceStateTrackingEntityFactory();
					break;
				case EPICCentralDL.EntityType.ExceptionLogEntity:
					factoryToUse = new ExceptionLogEntityFactory();
					break;
				case EPICCentralDL.EntityType.ImageCacheEntity:
					factoryToUse = new ImageCacheEntityFactory();
					break;
				case EPICCentralDL.EntityType.ImageSetEntity:
					factoryToUse = new ImageSetEntityFactory();
					break;
				case EPICCentralDL.EntityType.LicenseOrganSystemEntity:
					factoryToUse = new LicenseOrganSystemEntityFactory();
					break;
				case EPICCentralDL.EntityType.LocationEntity:
					factoryToUse = new LocationEntityFactory();
					break;
				case EPICCentralDL.EntityType.MessageEntity:
					factoryToUse = new MessageEntityFactory();
					break;
				case EPICCentralDL.EntityType.NBAnalysisResultEntity:
					factoryToUse = new NBAnalysisResultEntityFactory();
					break;
				case EPICCentralDL.EntityType.OrganEntity:
					factoryToUse = new OrganEntityFactory();
					break;
				case EPICCentralDL.EntityType.OrganizationEntity:
					factoryToUse = new OrganizationEntityFactory();
					break;
				case EPICCentralDL.EntityType.OrganSystemEntity:
					factoryToUse = new OrganSystemEntityFactory();
					break;
				case EPICCentralDL.EntityType.OrganSystemOrganEntity:
					factoryToUse = new OrganSystemOrganEntityFactory();
					break;
				case EPICCentralDL.EntityType.PatientEntity:
					factoryToUse = new PatientEntityFactory();
					break;
				case EPICCentralDL.EntityType.PatientPrescanQuestionEntity:
					factoryToUse = new PatientPrescanQuestionEntityFactory();
					break;
				case EPICCentralDL.EntityType.PurchaseHistoryEntity:
					factoryToUse = new PurchaseHistoryEntityFactory();
					break;
				case EPICCentralDL.EntityType.RoleEntity:
					factoryToUse = new RoleEntityFactory();
					break;
				case EPICCentralDL.EntityType.ScanHistoryEntity:
					factoryToUse = new ScanHistoryEntityFactory();
					break;
				case EPICCentralDL.EntityType.ScanRateEntity:
					factoryToUse = new ScanRateEntityFactory();
					break;
				case EPICCentralDL.EntityType.SessionEntity:
					factoryToUse = new SessionEntityFactory();
					break;
				case EPICCentralDL.EntityType.SeverityEntity:
					factoryToUse = new SeverityEntityFactory();
					break;
				case EPICCentralDL.EntityType.SupportAreaEntity:
					factoryToUse = new SupportAreaEntityFactory();
					break;
				case EPICCentralDL.EntityType.SupportIssueEntity:
					factoryToUse = new SupportIssueEntityFactory();
					break;
				case EPICCentralDL.EntityType.SystemSettingEntity:
					factoryToUse = new SystemSettingEntityFactory();
					break;
				case EPICCentralDL.EntityType.TreatmentEntity:
					factoryToUse = new TreatmentEntityFactory();
					break;
				case EPICCentralDL.EntityType.UpdateStatusEntity:
					factoryToUse = new UpdateStatusEntityFactory();
					break;
				case EPICCentralDL.EntityType.UserEntity:
					factoryToUse = new UserEntityFactory();
					break;
				case EPICCentralDL.EntityType.UserAccountRestrictionEntity:
					factoryToUse = new UserAccountRestrictionEntityFactory();
					break;
				case EPICCentralDL.EntityType.UserAssignedLocationEntity:
					factoryToUse = new UserAssignedLocationEntityFactory();
					break;
				case EPICCentralDL.EntityType.UserCreditCardEntity:
					factoryToUse = new UserCreditCardEntityFactory();
					break;
				case EPICCentralDL.EntityType.UserRoleEntity:
					factoryToUse = new UserRoleEntityFactory();
					break;
				case EPICCentralDL.EntityType.UserSaltEntity:
					factoryToUse = new UserSaltEntityFactory();
					break;
				case EPICCentralDL.EntityType.UserSettingEntity:
					factoryToUse = new UserSettingEntityFactory();
					break;
			}
			IEntity toReturn = null;
			if(factoryToUse != null)
			{
				toReturn = factoryToUse.Create();
			}
			return toReturn;
		}		
	}
	
	/// <summary>Class which is used to obtain the entity factory based on the .NET type of the entity. </summary>
	[Serializable]
	public static class EntityFactoryFactory
	{
#if CF
		/// <summary>Gets the factory of the entity with the EPICCentralDL.EntityType specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory GetFactory(EPICCentralDL.EntityType typeOfEntity)
		{
			return GeneralEntityFactory.Create(typeOfEntity).GetEntityFactory();
		}
#else
		private static readonly Dictionary<Type, IEntityFactory> _factoryPerType = new Dictionary<Type, IEntityFactory>();

		/// <summary>Initializes the <see cref="EntityFactoryFactory"/> class.</summary>
		static EntityFactoryFactory()
		{
			Array entityTypeValues = Enum.GetValues(typeof(EPICCentralDL.EntityType));
			foreach(int entityTypeValue in entityTypeValues)
			{
				IEntity dummy = GeneralEntityFactory.Create((EPICCentralDL.EntityType)entityTypeValue);
				_factoryPerType.Add(dummy.GetType(), dummy.GetEntityFactory());
			}
		}

		/// <summary>Gets the factory of the entity with the .NET type specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory GetFactory(Type typeOfEntity)
		{
			IEntityFactory toReturn = null;
			_factoryPerType.TryGetValue(typeOfEntity, out toReturn);
			return toReturn;
		}

		/// <summary>Gets the factory of the entity with the EPICCentralDL.EntityType specified</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>factory to use or null if not found</returns>
		public static IEntityFactory GetFactory(EPICCentralDL.EntityType typeOfEntity)
		{
			return GetFactory(GeneralEntityFactory.Create(typeOfEntity).GetType());
		}
#endif
	}
	
	/// <summary>Element creator for creating project elements from somewhere else, like inside Linq providers.</summary>
	public class ElementCreator : ElementCreatorBase, IElementCreator
	{
		/// <summary>Gets the factory of the Entity type with the EPICCentralDL.EntityType value passed in</summary>
		/// <param name="entityTypeValue">The entity type value.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory GetFactory(int entityTypeValue)
		{
			return (IEntityFactory)this.GetFactoryImpl(entityTypeValue);
		}

		/// <summary>Gets the factory of the Entity type with the .NET type passed in</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		public IEntityFactory GetFactory(Type typeOfEntity)
		{
			return (IEntityFactory)this.GetFactoryImpl(typeOfEntity);
		}

		/// <summary>Creates a new resultset fields object with the number of field slots reserved as specified</summary>
		/// <param name="numberOfFields">The number of fields.</param>
		/// <returns>ready to use resultsetfields object</returns>
		public IEntityFields CreateResultsetFields(int numberOfFields)
		{
			return new ResultsetFields(numberOfFields);
		}
		
		/// <summary>Gets an instance of the TypedListDAO class to execute dynamic lists and projections.</summary>
		/// <returns>ready to use typedlistDAO</returns>
		public IDao GetTypedListDao()
		{
			return new TypedListDAO();
		}
		
		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperand">The left operand.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand)
		{
			return new DynamicRelation(leftOperand);
		}

		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperand">The left operand.</param>
		/// <param name="joinType">Type of the join. If None is specified, Inner is assumed.</param>
		/// <param name="rightOperand">The right operand.</param>
		/// <param name="onClause">The on clause for the join.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand, JoinHint joinType, DerivedTableDefinition rightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, rightOperand, onClause);
		}

		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperand">The left operand.</param>
		/// <param name="joinType">Type of the join. If None is specified, Inner is assumed.</param>
		/// <param name="rightOperandEntityName">Name of the entity, which is used as the right operand.</param>
		/// <param name="aliasRightOperand">The alias of the right operand. If you don't want to / need to alias the right operand (only alias if you have to), specify string.Empty.</param>
		/// <param name="onClause">The on clause for the join.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(DerivedTableDefinition leftOperand, JoinHint joinType, string rightOperandEntityName, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation(leftOperand, joinType, (EPICCentralDL.EntityType)Enum.Parse(typeof(EPICCentralDL.EntityType), rightOperandEntityName, false), aliasRightOperand, onClause);
		}

		/// <summary>Creates a new dynamic relation instance</summary>
		/// <param name="leftOperandEntityName">Name of the entity which is used as the left operand.</param>
		/// <param name="joinType">Type of the join. If None is specified, Inner is assumed.</param>
		/// <param name="rightOperandEntityName">Name of the entity, which is used as the right operand.</param>
		/// <param name="aliasLeftOperand">The alias of the left operand. If you don't want to / need to alias the right operand (only alias if you have to), specify string.Empty.</param>
		/// <param name="aliasRightOperand">The alias of the right operand. If you don't want to / need to alias the right operand (only alias if you have to), specify string.Empty.</param>
		/// <param name="onClause">The on clause for the join.</param>
		/// <returns>ready to use dynamic relation</returns>
		public override IDynamicRelation CreateDynamicRelation(string leftOperandEntityName, JoinHint joinType, string rightOperandEntityName, string aliasLeftOperand, string aliasRightOperand, IPredicate onClause)
		{
			return new DynamicRelation((EPICCentralDL.EntityType)Enum.Parse(typeof(EPICCentralDL.EntityType), leftOperandEntityName, false), joinType, (EPICCentralDL.EntityType)Enum.Parse(typeof(EPICCentralDL.EntityType), rightOperandEntityName, false), aliasLeftOperand, aliasRightOperand, onClause);
		}
				
		/// <summary>Obtains the inheritance info provider instance from the singleton </summary>
		/// <returns>The singleton instance of the inheritance info provider</returns>
		public override IInheritanceInfoProvider ObtainInheritanceInfoProviderInstance()
		{
			return InheritanceInfoProviderSingleton.GetInstance();
		}

		/// <summary>Implementation of the routine which gets the factory of the Entity type with the EPICCentralDL.EntityType value passed in</summary>
		/// <param name="entityTypeValue">The entity type value.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		protected override IEntityFactoryCore GetFactoryImpl(int entityTypeValue)
		{
			return EntityFactoryFactory.GetFactory((EPICCentralDL.EntityType)entityTypeValue);
		}
#if !CF		
		/// <summary>Implementation of the routine which gets the factory of the Entity type with the .NET type passed in</summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>the entity factory of the entity type or null if not found</returns>
		protected override IEntityFactoryCore GetFactoryImpl(Type typeOfEntity)
		{
			return EntityFactoryFactory.GetFactory(typeOfEntity);
		}
#endif
	}
}
