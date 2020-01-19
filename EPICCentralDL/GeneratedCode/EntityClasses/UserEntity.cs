///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Data;
using System.Xml.Serialization;
using EPICCentralDL;
using EPICCentralDL.FactoryClasses;
using EPICCentralDL.DaoClasses;
using EPICCentralDL.RelationClasses;
using EPICCentralDL.HelperClasses;
using EPICCentralDL.CollectionClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentralDL.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>Entity class which represents the entity 'User'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class UserEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EPICCentralDL.CollectionClasses.PurchaseHistoryCollection	_purchaseHistories;
		private bool	_alwaysFetchPurchaseHistories, _alreadyFetchedPurchaseHistories;
		private EPICCentralDL.CollectionClasses.SupportIssueCollection	_supportIssues;
		private bool	_alwaysFetchSupportIssues, _alreadyFetchedSupportIssues;
		private EPICCentralDL.CollectionClasses.SupportIssueCollection	_supportIssues_;
		private bool	_alwaysFetchSupportIssues_, _alreadyFetchedSupportIssues_;
		private EPICCentralDL.CollectionClasses.UserAccountRestrictionCollection	_userAccountRestrictions;
		private bool	_alwaysFetchUserAccountRestrictions, _alreadyFetchedUserAccountRestrictions;
		private EPICCentralDL.CollectionClasses.UserAssignedLocationCollection	_userAssignedLocations;
		private bool	_alwaysFetchUserAssignedLocations, _alreadyFetchedUserAssignedLocations;
		private EPICCentralDL.CollectionClasses.UserCreditCardCollection	_userCreditCards;
		private bool	_alwaysFetchUserCreditCards, _alreadyFetchedUserCreditCards;
		private EPICCentralDL.CollectionClasses.UserRoleCollection	_roles;
		private bool	_alwaysFetchRoles, _alreadyFetchedRoles;
		private EPICCentralDL.CollectionClasses.UserSettingCollection	_settings;
		private bool	_alwaysFetchSettings, _alreadyFetchedSettings;
		private OrganizationEntity _organization;
		private bool	_alwaysFetchOrganization, _alreadyFetchedOrganization, _organizationReturnsNewIfNotFound;
		private UserSaltEntity _userSalt;
		private bool	_alwaysFetchUserSalt, _alreadyFetchedUserSalt, _userSaltReturnsNewIfNotFound;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Organization</summary>
			public static readonly string Organization = "Organization";
			/// <summary>Member name PurchaseHistories</summary>
			public static readonly string PurchaseHistories = "PurchaseHistories";
			/// <summary>Member name SupportIssues</summary>
			public static readonly string SupportIssues = "SupportIssues";
			/// <summary>Member name SupportIssues_</summary>
			public static readonly string SupportIssues_ = "SupportIssues_";
			/// <summary>Member name UserAccountRestrictions</summary>
			public static readonly string UserAccountRestrictions = "UserAccountRestrictions";
			/// <summary>Member name UserAssignedLocations</summary>
			public static readonly string UserAssignedLocations = "UserAssignedLocations";
			/// <summary>Member name UserCreditCards</summary>
			public static readonly string UserCreditCards = "UserCreditCards";
			/// <summary>Member name Roles</summary>
			public static readonly string Roles = "Roles";
			/// <summary>Member name Settings</summary>
			public static readonly string Settings = "Settings";
			/// <summary>Member name UserSalt</summary>
			public static readonly string UserSalt = "UserSalt";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static UserEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public UserEntity() :base("UserEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		public UserEntity(System.Int32 userId):base("UserEntity")
		{
			InitClassFetch(userId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public UserEntity(System.Int32 userId, IPrefetchPath prefetchPathToUse):base("UserEntity")
		{
			InitClassFetch(userId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		/// <param name="validator">The custom validator object for this UserEntity</param>
		public UserEntity(System.Int32 userId, IValidator validator):base("UserEntity")
		{
			InitClassFetch(userId, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected UserEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_purchaseHistories = (EPICCentralDL.CollectionClasses.PurchaseHistoryCollection)info.GetValue("_purchaseHistories", typeof(EPICCentralDL.CollectionClasses.PurchaseHistoryCollection));
			_alwaysFetchPurchaseHistories = info.GetBoolean("_alwaysFetchPurchaseHistories");
			_alreadyFetchedPurchaseHistories = info.GetBoolean("_alreadyFetchedPurchaseHistories");

			_supportIssues = (EPICCentralDL.CollectionClasses.SupportIssueCollection)info.GetValue("_supportIssues", typeof(EPICCentralDL.CollectionClasses.SupportIssueCollection));
			_alwaysFetchSupportIssues = info.GetBoolean("_alwaysFetchSupportIssues");
			_alreadyFetchedSupportIssues = info.GetBoolean("_alreadyFetchedSupportIssues");

			_supportIssues_ = (EPICCentralDL.CollectionClasses.SupportIssueCollection)info.GetValue("_supportIssues_", typeof(EPICCentralDL.CollectionClasses.SupportIssueCollection));
			_alwaysFetchSupportIssues_ = info.GetBoolean("_alwaysFetchSupportIssues_");
			_alreadyFetchedSupportIssues_ = info.GetBoolean("_alreadyFetchedSupportIssues_");

			_userAccountRestrictions = (EPICCentralDL.CollectionClasses.UserAccountRestrictionCollection)info.GetValue("_userAccountRestrictions", typeof(EPICCentralDL.CollectionClasses.UserAccountRestrictionCollection));
			_alwaysFetchUserAccountRestrictions = info.GetBoolean("_alwaysFetchUserAccountRestrictions");
			_alreadyFetchedUserAccountRestrictions = info.GetBoolean("_alreadyFetchedUserAccountRestrictions");

			_userAssignedLocations = (EPICCentralDL.CollectionClasses.UserAssignedLocationCollection)info.GetValue("_userAssignedLocations", typeof(EPICCentralDL.CollectionClasses.UserAssignedLocationCollection));
			_alwaysFetchUserAssignedLocations = info.GetBoolean("_alwaysFetchUserAssignedLocations");
			_alreadyFetchedUserAssignedLocations = info.GetBoolean("_alreadyFetchedUserAssignedLocations");

			_userCreditCards = (EPICCentralDL.CollectionClasses.UserCreditCardCollection)info.GetValue("_userCreditCards", typeof(EPICCentralDL.CollectionClasses.UserCreditCardCollection));
			_alwaysFetchUserCreditCards = info.GetBoolean("_alwaysFetchUserCreditCards");
			_alreadyFetchedUserCreditCards = info.GetBoolean("_alreadyFetchedUserCreditCards");

			_roles = (EPICCentralDL.CollectionClasses.UserRoleCollection)info.GetValue("_roles", typeof(EPICCentralDL.CollectionClasses.UserRoleCollection));
			_alwaysFetchRoles = info.GetBoolean("_alwaysFetchRoles");
			_alreadyFetchedRoles = info.GetBoolean("_alreadyFetchedRoles");

			_settings = (EPICCentralDL.CollectionClasses.UserSettingCollection)info.GetValue("_settings", typeof(EPICCentralDL.CollectionClasses.UserSettingCollection));
			_alwaysFetchSettings = info.GetBoolean("_alwaysFetchSettings");
			_alreadyFetchedSettings = info.GetBoolean("_alreadyFetchedSettings");
			_organization = (OrganizationEntity)info.GetValue("_organization", typeof(OrganizationEntity));
			if(_organization!=null)
			{
				_organization.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_organizationReturnsNewIfNotFound = info.GetBoolean("_organizationReturnsNewIfNotFound");
			_alwaysFetchOrganization = info.GetBoolean("_alwaysFetchOrganization");
			_alreadyFetchedOrganization = info.GetBoolean("_alreadyFetchedOrganization");
			_userSalt = (UserSaltEntity)info.GetValue("_userSalt", typeof(UserSaltEntity));
			if(_userSalt!=null)
			{
				_userSalt.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_userSaltReturnsNewIfNotFound = info.GetBoolean("_userSaltReturnsNewIfNotFound");
			_alwaysFetchUserSalt = info.GetBoolean("_alwaysFetchUserSalt");
			_alreadyFetchedUserSalt = info.GetBoolean("_alreadyFetchedUserSalt");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		
		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((UserFieldIndex)fieldIndex)
			{
				case UserFieldIndex.OrganizationId:
					DesetupSyncOrganization(true, false);
					_alreadyFetchedOrganization = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedPurchaseHistories = (_purchaseHistories.Count > 0);
			_alreadyFetchedSupportIssues = (_supportIssues.Count > 0);
			_alreadyFetchedSupportIssues_ = (_supportIssues_.Count > 0);
			_alreadyFetchedUserAccountRestrictions = (_userAccountRestrictions.Count > 0);
			_alreadyFetchedUserAssignedLocations = (_userAssignedLocations.Count > 0);
			_alreadyFetchedUserCreditCards = (_userCreditCards.Count > 0);
			_alreadyFetchedRoles = (_roles.Count > 0);
			_alreadyFetchedSettings = (_settings.Count > 0);
			_alreadyFetchedOrganization = (_organization != null);
			_alreadyFetchedUserSalt = (_userSalt != null);
		}
				
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		protected override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		internal static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Organization":
					toReturn.Add(Relations.OrganizationEntityUsingOrganizationId);
					break;
				case "PurchaseHistories":
					toReturn.Add(Relations.PurchaseHistoryEntityUsingUserId);
					break;
				case "SupportIssues":
					toReturn.Add(Relations.SupportIssueEntityUsingFromUserId);
					break;
				case "SupportIssues_":
					toReturn.Add(Relations.SupportIssueEntityUsingToUserId);
					break;
				case "UserAccountRestrictions":
					toReturn.Add(Relations.UserAccountRestrictionEntityUsingUserId);
					break;
				case "UserAssignedLocations":
					toReturn.Add(Relations.UserAssignedLocationEntityUsingUserId);
					break;
				case "UserCreditCards":
					toReturn.Add(Relations.UserCreditCardEntityUsingUserId);
					break;
				case "Roles":
					toReturn.Add(Relations.UserRoleEntityUsingUserId);
					break;
				case "Settings":
					toReturn.Add(Relations.UserSettingEntityUsingUserId);
					break;
				case "UserSalt":
					toReturn.Add(Relations.UserSaltEntityUsingUserId);
					break;
				default:
					break;				
			}
			return toReturn;
		}



		/// <summary> ISerializable member. Does custom serialization so event handlers do not get serialized.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("_purchaseHistories", (!this.MarkedForDeletion?_purchaseHistories:null));
			info.AddValue("_alwaysFetchPurchaseHistories", _alwaysFetchPurchaseHistories);
			info.AddValue("_alreadyFetchedPurchaseHistories", _alreadyFetchedPurchaseHistories);
			info.AddValue("_supportIssues", (!this.MarkedForDeletion?_supportIssues:null));
			info.AddValue("_alwaysFetchSupportIssues", _alwaysFetchSupportIssues);
			info.AddValue("_alreadyFetchedSupportIssues", _alreadyFetchedSupportIssues);
			info.AddValue("_supportIssues_", (!this.MarkedForDeletion?_supportIssues_:null));
			info.AddValue("_alwaysFetchSupportIssues_", _alwaysFetchSupportIssues_);
			info.AddValue("_alreadyFetchedSupportIssues_", _alreadyFetchedSupportIssues_);
			info.AddValue("_userAccountRestrictions", (!this.MarkedForDeletion?_userAccountRestrictions:null));
			info.AddValue("_alwaysFetchUserAccountRestrictions", _alwaysFetchUserAccountRestrictions);
			info.AddValue("_alreadyFetchedUserAccountRestrictions", _alreadyFetchedUserAccountRestrictions);
			info.AddValue("_userAssignedLocations", (!this.MarkedForDeletion?_userAssignedLocations:null));
			info.AddValue("_alwaysFetchUserAssignedLocations", _alwaysFetchUserAssignedLocations);
			info.AddValue("_alreadyFetchedUserAssignedLocations", _alreadyFetchedUserAssignedLocations);
			info.AddValue("_userCreditCards", (!this.MarkedForDeletion?_userCreditCards:null));
			info.AddValue("_alwaysFetchUserCreditCards", _alwaysFetchUserCreditCards);
			info.AddValue("_alreadyFetchedUserCreditCards", _alreadyFetchedUserCreditCards);
			info.AddValue("_roles", (!this.MarkedForDeletion?_roles:null));
			info.AddValue("_alwaysFetchRoles", _alwaysFetchRoles);
			info.AddValue("_alreadyFetchedRoles", _alreadyFetchedRoles);
			info.AddValue("_settings", (!this.MarkedForDeletion?_settings:null));
			info.AddValue("_alwaysFetchSettings", _alwaysFetchSettings);
			info.AddValue("_alreadyFetchedSettings", _alreadyFetchedSettings);
			info.AddValue("_organization", (!this.MarkedForDeletion?_organization:null));
			info.AddValue("_organizationReturnsNewIfNotFound", _organizationReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchOrganization", _alwaysFetchOrganization);
			info.AddValue("_alreadyFetchedOrganization", _alreadyFetchedOrganization);

			info.AddValue("_userSalt", (!this.MarkedForDeletion?_userSalt:null));
			info.AddValue("_userSaltReturnsNewIfNotFound", _userSaltReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchUserSalt", _alwaysFetchUserSalt);
			info.AddValue("_alreadyFetchedUserSalt", _alreadyFetchedUserSalt);

			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}
		
		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override void SetRelatedEntityProperty(string propertyName, IEntityCore entity)
		{
			switch(propertyName)
			{
				case "Organization":
					_alreadyFetchedOrganization = true;
					this.Organization = (OrganizationEntity)entity;
					break;
				case "PurchaseHistories":
					_alreadyFetchedPurchaseHistories = true;
					if(entity!=null)
					{
						this.PurchaseHistories.Add((PurchaseHistoryEntity)entity);
					}
					break;
				case "SupportIssues":
					_alreadyFetchedSupportIssues = true;
					if(entity!=null)
					{
						this.SupportIssues.Add((SupportIssueEntity)entity);
					}
					break;
				case "SupportIssues_":
					_alreadyFetchedSupportIssues_ = true;
					if(entity!=null)
					{
						this.SupportIssues_.Add((SupportIssueEntity)entity);
					}
					break;
				case "UserAccountRestrictions":
					_alreadyFetchedUserAccountRestrictions = true;
					if(entity!=null)
					{
						this.UserAccountRestrictions.Add((UserAccountRestrictionEntity)entity);
					}
					break;
				case "UserAssignedLocations":
					_alreadyFetchedUserAssignedLocations = true;
					if(entity!=null)
					{
						this.UserAssignedLocations.Add((UserAssignedLocationEntity)entity);
					}
					break;
				case "UserCreditCards":
					_alreadyFetchedUserCreditCards = true;
					if(entity!=null)
					{
						this.UserCreditCards.Add((UserCreditCardEntity)entity);
					}
					break;
				case "Roles":
					_alreadyFetchedRoles = true;
					if(entity!=null)
					{
						this.Roles.Add((UserRoleEntity)entity);
					}
					break;
				case "Settings":
					_alreadyFetchedSettings = true;
					if(entity!=null)
					{
						this.Settings.Add((UserSettingEntity)entity);
					}
					break;
				case "UserSalt":
					_alreadyFetchedUserSalt = true;
					this.UserSalt = (UserSaltEntity)entity;
					break;
				default:
					this.OnSetRelatedEntityProperty(propertyName, entity);
					break;
			}
		}

		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override void SetRelatedEntity(IEntityCore relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "Organization":
					SetupSyncOrganization(relatedEntity);
					break;
				case "PurchaseHistories":
					_purchaseHistories.Add((PurchaseHistoryEntity)relatedEntity);
					break;
				case "SupportIssues":
					_supportIssues.Add((SupportIssueEntity)relatedEntity);
					break;
				case "SupportIssues_":
					_supportIssues_.Add((SupportIssueEntity)relatedEntity);
					break;
				case "UserAccountRestrictions":
					_userAccountRestrictions.Add((UserAccountRestrictionEntity)relatedEntity);
					break;
				case "UserAssignedLocations":
					_userAssignedLocations.Add((UserAssignedLocationEntity)relatedEntity);
					break;
				case "UserCreditCards":
					_userCreditCards.Add((UserCreditCardEntity)relatedEntity);
					break;
				case "Roles":
					_roles.Add((UserRoleEntity)relatedEntity);
					break;
				case "Settings":
					_settings.Add((UserSettingEntity)relatedEntity);
					break;
				case "UserSalt":
					SetupSyncUserSalt(relatedEntity);
					break;
				default:
					break;
			}
		}
		
		/// <summary> Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		/// <param name="signalRelatedEntityManyToOne">if set to true it will notify the manytoone side, if applicable.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override void UnsetRelatedEntity(IEntityCore relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
		{
			switch(fieldName)
			{
				case "Organization":
					DesetupSyncOrganization(false, true);
					break;
				case "PurchaseHistories":
					this.PerformRelatedEntityRemoval(_purchaseHistories, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SupportIssues":
					this.PerformRelatedEntityRemoval(_supportIssues, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SupportIssues_":
					this.PerformRelatedEntityRemoval(_supportIssues_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "UserAccountRestrictions":
					this.PerformRelatedEntityRemoval(_userAccountRestrictions, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "UserAssignedLocations":
					this.PerformRelatedEntityRemoval(_userAssignedLocations, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "UserCreditCards":
					this.PerformRelatedEntityRemoval(_userCreditCards, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Roles":
					this.PerformRelatedEntityRemoval(_roles, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Settings":
					this.PerformRelatedEntityRemoval(_settings, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "UserSalt":
					DesetupSyncUserSalt(false, true);
					break;
				default:
					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		protected override List<IEntity> GetDependingRelatedEntities()
		{
			List<IEntity> toReturn = new List<IEntity>();
			if(_userSalt!=null)
			{
				toReturn.Add(_userSalt);
			}
			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		protected override List<IEntity> GetDependentRelatedEntities()
		{
			List<IEntity> toReturn = new List<IEntity>();
			if(_organization!=null)
			{
				toReturn.Add(_organization);
			}
			return toReturn;
		}
		
		/// <summary> Gets a List of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		protected override List<IEntityCollection> GetMemberEntityCollections()
		{
			List<IEntityCollection> toReturn = new List<IEntityCollection>();
			toReturn.Add(_purchaseHistories);
			toReturn.Add(_supportIssues);
			toReturn.Add(_supportIssues_);
			toReturn.Add(_userAccountRestrictions);
			toReturn.Add(_userAssignedLocations);
			toReturn.Add(_userCreditCards);
			toReturn.Add(_roles);
			toReturn.Add(_settings);

			return toReturn;
		}


		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 userId)
		{
			return FetchUsingPK(userId, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 userId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(userId, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 userId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(userId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 userId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(userId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.UserId, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new UserRelations().GetAllRelations();
		}

		/// <summary> Retrieves all related entities of type 'PurchaseHistoryEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'PurchaseHistoryEntity'</returns>
		public EPICCentralDL.CollectionClasses.PurchaseHistoryCollection GetMultiPurchaseHistories(bool forceFetch)
		{
			return GetMultiPurchaseHistories(forceFetch, _purchaseHistories.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'PurchaseHistoryEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'PurchaseHistoryEntity'</returns>
		public EPICCentralDL.CollectionClasses.PurchaseHistoryCollection GetMultiPurchaseHistories(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiPurchaseHistories(forceFetch, _purchaseHistories.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'PurchaseHistoryEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.PurchaseHistoryCollection GetMultiPurchaseHistories(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiPurchaseHistories(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'PurchaseHistoryEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.PurchaseHistoryCollection GetMultiPurchaseHistories(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedPurchaseHistories || forceFetch || _alwaysFetchPurchaseHistories) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_purchaseHistories);
				_purchaseHistories.SuppressClearInGetMulti=!forceFetch;
				_purchaseHistories.EntityFactoryToUse = entityFactoryToUse;
				_purchaseHistories.GetMultiManyToOne(null, null, this, filter);
				_purchaseHistories.SuppressClearInGetMulti=false;
				_alreadyFetchedPurchaseHistories = true;
			}
			return _purchaseHistories;
		}

		/// <summary> Sets the collection parameters for the collection for 'PurchaseHistories'. These settings will be taken into account
		/// when the property PurchaseHistories is requested or GetMultiPurchaseHistories is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersPurchaseHistories(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_purchaseHistories.SortClauses=sortClauses;
			_purchaseHistories.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'SupportIssueEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'SupportIssueEntity'</returns>
		public EPICCentralDL.CollectionClasses.SupportIssueCollection GetMultiSupportIssues(bool forceFetch)
		{
			return GetMultiSupportIssues(forceFetch, _supportIssues.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'SupportIssueEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'SupportIssueEntity'</returns>
		public EPICCentralDL.CollectionClasses.SupportIssueCollection GetMultiSupportIssues(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiSupportIssues(forceFetch, _supportIssues.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'SupportIssueEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.SupportIssueCollection GetMultiSupportIssues(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiSupportIssues(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'SupportIssueEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.SupportIssueCollection GetMultiSupportIssues(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedSupportIssues || forceFetch || _alwaysFetchSupportIssues) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_supportIssues);
				_supportIssues.SuppressClearInGetMulti=!forceFetch;
				_supportIssues.EntityFactoryToUse = entityFactoryToUse;
				_supportIssues.GetMultiManyToOne(null, this, null, filter);
				_supportIssues.SuppressClearInGetMulti=false;
				_alreadyFetchedSupportIssues = true;
			}
			return _supportIssues;
		}

		/// <summary> Sets the collection parameters for the collection for 'SupportIssues'. These settings will be taken into account
		/// when the property SupportIssues is requested or GetMultiSupportIssues is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersSupportIssues(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_supportIssues.SortClauses=sortClauses;
			_supportIssues.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'SupportIssueEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'SupportIssueEntity'</returns>
		public EPICCentralDL.CollectionClasses.SupportIssueCollection GetMultiSupportIssues_(bool forceFetch)
		{
			return GetMultiSupportIssues_(forceFetch, _supportIssues_.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'SupportIssueEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'SupportIssueEntity'</returns>
		public EPICCentralDL.CollectionClasses.SupportIssueCollection GetMultiSupportIssues_(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiSupportIssues_(forceFetch, _supportIssues_.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'SupportIssueEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.SupportIssueCollection GetMultiSupportIssues_(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiSupportIssues_(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'SupportIssueEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.SupportIssueCollection GetMultiSupportIssues_(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedSupportIssues_ || forceFetch || _alwaysFetchSupportIssues_) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_supportIssues_);
				_supportIssues_.SuppressClearInGetMulti=!forceFetch;
				_supportIssues_.EntityFactoryToUse = entityFactoryToUse;
				_supportIssues_.GetMultiManyToOne(null, null, this, filter);
				_supportIssues_.SuppressClearInGetMulti=false;
				_alreadyFetchedSupportIssues_ = true;
			}
			return _supportIssues_;
		}

		/// <summary> Sets the collection parameters for the collection for 'SupportIssues_'. These settings will be taken into account
		/// when the property SupportIssues_ is requested or GetMultiSupportIssues_ is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersSupportIssues_(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_supportIssues_.SortClauses=sortClauses;
			_supportIssues_.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'UserAccountRestrictionEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'UserAccountRestrictionEntity'</returns>
		public EPICCentralDL.CollectionClasses.UserAccountRestrictionCollection GetMultiUserAccountRestrictions(bool forceFetch)
		{
			return GetMultiUserAccountRestrictions(forceFetch, _userAccountRestrictions.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'UserAccountRestrictionEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'UserAccountRestrictionEntity'</returns>
		public EPICCentralDL.CollectionClasses.UserAccountRestrictionCollection GetMultiUserAccountRestrictions(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiUserAccountRestrictions(forceFetch, _userAccountRestrictions.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'UserAccountRestrictionEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.UserAccountRestrictionCollection GetMultiUserAccountRestrictions(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiUserAccountRestrictions(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'UserAccountRestrictionEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.UserAccountRestrictionCollection GetMultiUserAccountRestrictions(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedUserAccountRestrictions || forceFetch || _alwaysFetchUserAccountRestrictions) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_userAccountRestrictions);
				_userAccountRestrictions.SuppressClearInGetMulti=!forceFetch;
				_userAccountRestrictions.EntityFactoryToUse = entityFactoryToUse;
				_userAccountRestrictions.GetMultiManyToOne(null, this, filter);
				_userAccountRestrictions.SuppressClearInGetMulti=false;
				_alreadyFetchedUserAccountRestrictions = true;
			}
			return _userAccountRestrictions;
		}

		/// <summary> Sets the collection parameters for the collection for 'UserAccountRestrictions'. These settings will be taken into account
		/// when the property UserAccountRestrictions is requested or GetMultiUserAccountRestrictions is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersUserAccountRestrictions(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_userAccountRestrictions.SortClauses=sortClauses;
			_userAccountRestrictions.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'UserAssignedLocationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'UserAssignedLocationEntity'</returns>
		public EPICCentralDL.CollectionClasses.UserAssignedLocationCollection GetMultiUserAssignedLocations(bool forceFetch)
		{
			return GetMultiUserAssignedLocations(forceFetch, _userAssignedLocations.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'UserAssignedLocationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'UserAssignedLocationEntity'</returns>
		public EPICCentralDL.CollectionClasses.UserAssignedLocationCollection GetMultiUserAssignedLocations(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiUserAssignedLocations(forceFetch, _userAssignedLocations.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'UserAssignedLocationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.UserAssignedLocationCollection GetMultiUserAssignedLocations(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiUserAssignedLocations(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'UserAssignedLocationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.UserAssignedLocationCollection GetMultiUserAssignedLocations(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedUserAssignedLocations || forceFetch || _alwaysFetchUserAssignedLocations) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_userAssignedLocations);
				_userAssignedLocations.SuppressClearInGetMulti=!forceFetch;
				_userAssignedLocations.EntityFactoryToUse = entityFactoryToUse;
				_userAssignedLocations.GetMultiManyToOne(null, this, filter);
				_userAssignedLocations.SuppressClearInGetMulti=false;
				_alreadyFetchedUserAssignedLocations = true;
			}
			return _userAssignedLocations;
		}

		/// <summary> Sets the collection parameters for the collection for 'UserAssignedLocations'. These settings will be taken into account
		/// when the property UserAssignedLocations is requested or GetMultiUserAssignedLocations is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersUserAssignedLocations(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_userAssignedLocations.SortClauses=sortClauses;
			_userAssignedLocations.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'UserCreditCardEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'UserCreditCardEntity'</returns>
		public EPICCentralDL.CollectionClasses.UserCreditCardCollection GetMultiUserCreditCards(bool forceFetch)
		{
			return GetMultiUserCreditCards(forceFetch, _userCreditCards.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'UserCreditCardEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'UserCreditCardEntity'</returns>
		public EPICCentralDL.CollectionClasses.UserCreditCardCollection GetMultiUserCreditCards(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiUserCreditCards(forceFetch, _userCreditCards.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'UserCreditCardEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.UserCreditCardCollection GetMultiUserCreditCards(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiUserCreditCards(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'UserCreditCardEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.UserCreditCardCollection GetMultiUserCreditCards(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedUserCreditCards || forceFetch || _alwaysFetchUserCreditCards) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_userCreditCards);
				_userCreditCards.SuppressClearInGetMulti=!forceFetch;
				_userCreditCards.EntityFactoryToUse = entityFactoryToUse;
				_userCreditCards.GetMultiManyToOne(null, this, filter);
				_userCreditCards.SuppressClearInGetMulti=false;
				_alreadyFetchedUserCreditCards = true;
			}
			return _userCreditCards;
		}

		/// <summary> Sets the collection parameters for the collection for 'UserCreditCards'. These settings will be taken into account
		/// when the property UserCreditCards is requested or GetMultiUserCreditCards is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersUserCreditCards(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_userCreditCards.SortClauses=sortClauses;
			_userCreditCards.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'UserRoleEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'UserRoleEntity'</returns>
		public EPICCentralDL.CollectionClasses.UserRoleCollection GetMultiRoles(bool forceFetch)
		{
			return GetMultiRoles(forceFetch, _roles.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'UserRoleEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'UserRoleEntity'</returns>
		public EPICCentralDL.CollectionClasses.UserRoleCollection GetMultiRoles(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiRoles(forceFetch, _roles.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'UserRoleEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.UserRoleCollection GetMultiRoles(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiRoles(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'UserRoleEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.UserRoleCollection GetMultiRoles(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedRoles || forceFetch || _alwaysFetchRoles) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_roles);
				_roles.SuppressClearInGetMulti=!forceFetch;
				_roles.EntityFactoryToUse = entityFactoryToUse;
				_roles.GetMultiManyToOne(null, this, filter);
				_roles.SuppressClearInGetMulti=false;
				_alreadyFetchedRoles = true;
			}
			return _roles;
		}

		/// <summary> Sets the collection parameters for the collection for 'Roles'. These settings will be taken into account
		/// when the property Roles is requested or GetMultiRoles is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersRoles(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_roles.SortClauses=sortClauses;
			_roles.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'UserSettingEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'UserSettingEntity'</returns>
		public EPICCentralDL.CollectionClasses.UserSettingCollection GetMultiSettings(bool forceFetch)
		{
			return GetMultiSettings(forceFetch, _settings.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'UserSettingEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'UserSettingEntity'</returns>
		public EPICCentralDL.CollectionClasses.UserSettingCollection GetMultiSettings(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiSettings(forceFetch, _settings.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'UserSettingEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.UserSettingCollection GetMultiSettings(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiSettings(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'UserSettingEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.UserSettingCollection GetMultiSettings(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedSettings || forceFetch || _alwaysFetchSettings) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_settings);
				_settings.SuppressClearInGetMulti=!forceFetch;
				_settings.EntityFactoryToUse = entityFactoryToUse;
				_settings.GetMultiManyToOne(this, filter);
				_settings.SuppressClearInGetMulti=false;
				_alreadyFetchedSettings = true;
			}
			return _settings;
		}

		/// <summary> Sets the collection parameters for the collection for 'Settings'. These settings will be taken into account
		/// when the property Settings is requested or GetMultiSettings is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersSettings(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_settings.SortClauses=sortClauses;
			_settings.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves the related entity of type 'OrganizationEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'OrganizationEntity' which is related to this entity.</returns>
		public OrganizationEntity GetSingleOrganization()
		{
			return GetSingleOrganization(false);
		}

		/// <summary> Retrieves the related entity of type 'OrganizationEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'OrganizationEntity' which is related to this entity.</returns>
		public virtual OrganizationEntity GetSingleOrganization(bool forceFetch)
		{
			if( ( !_alreadyFetchedOrganization || forceFetch || _alwaysFetchOrganization) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.OrganizationEntityUsingOrganizationId);
				OrganizationEntity newEntity = new OrganizationEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.OrganizationId);
				}
				if(fetchResult)
				{
					newEntity = (OrganizationEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_organizationReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.Organization = newEntity;
				_alreadyFetchedOrganization = fetchResult;
			}
			return _organization;
		}

		/// <summary> Retrieves the related entity of type 'UserSaltEntity', using a relation of type '1:1'</summary>
		/// <returns>A fetched entity of type 'UserSaltEntity' which is related to this entity.</returns>
		public UserSaltEntity GetSingleUserSalt()
		{
			return GetSingleUserSalt(false);
		}
		
		/// <summary> Retrieves the related entity of type 'UserSaltEntity', using a relation of type '1:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'UserSaltEntity' which is related to this entity.</returns>
		public virtual UserSaltEntity GetSingleUserSalt(bool forceFetch)
		{
			if( ( !_alreadyFetchedUserSalt || forceFetch || _alwaysFetchUserSalt) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode )
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.UserSaltEntityUsingUserId);
				UserSaltEntity newEntity = new UserSaltEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.UserId);
				}
				if(fetchResult)
				{
					newEntity = (UserSaltEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_userSaltReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.UserSalt = newEntity;
				_alreadyFetchedUserSalt = fetchResult;
			}
			return _userSalt;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Organization", _organization);
			toReturn.Add("PurchaseHistories", _purchaseHistories);
			toReturn.Add("SupportIssues", _supportIssues);
			toReturn.Add("SupportIssues_", _supportIssues_);
			toReturn.Add("UserAccountRestrictions", _userAccountRestrictions);
			toReturn.Add("UserAssignedLocations", _userAssignedLocations);
			toReturn.Add("UserCreditCards", _userCreditCards);
			toReturn.Add("Roles", _roles);
			toReturn.Add("Settings", _settings);
			toReturn.Add("UserSalt", _userSalt);
			return toReturn;
		}
	
		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validatorToUse">Validator to use.</param>
		private void InitClassEmpty(IValidator validatorToUse)
		{
			OnInitializing();
			this.Fields = CreateFields();
			this.Validator = validatorToUse;
			InitClassMembers();

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}		

		/// <summary> Initializes the the entity and fetches the data related to the entity in this entity.</summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		/// <param name="validator">The validator object for this UserEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 userId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(userId, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{

			_purchaseHistories = new EPICCentralDL.CollectionClasses.PurchaseHistoryCollection();
			_purchaseHistories.SetContainingEntityInfo(this, "User");

			_supportIssues = new EPICCentralDL.CollectionClasses.SupportIssueCollection();
			_supportIssues.SetContainingEntityInfo(this, "User");

			_supportIssues_ = new EPICCentralDL.CollectionClasses.SupportIssueCollection();
			_supportIssues_.SetContainingEntityInfo(this, "User_");

			_userAccountRestrictions = new EPICCentralDL.CollectionClasses.UserAccountRestrictionCollection();
			_userAccountRestrictions.SetContainingEntityInfo(this, "User");

			_userAssignedLocations = new EPICCentralDL.CollectionClasses.UserAssignedLocationCollection();
			_userAssignedLocations.SetContainingEntityInfo(this, "User");

			_userCreditCards = new EPICCentralDL.CollectionClasses.UserCreditCardCollection();
			_userCreditCards.SetContainingEntityInfo(this, "User");

			_roles = new EPICCentralDL.CollectionClasses.UserRoleCollection();
			_roles.SetContainingEntityInfo(this, "User");

			_settings = new EPICCentralDL.CollectionClasses.UserSettingCollection();
			_settings.SetContainingEntityInfo(this, "User");
			_organizationReturnsNewIfNotFound = false;
			_userSaltReturnsNewIfNotFound = false;
			PerformDependencyInjection();

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}

		#region Custom Property Hashtable Setup
		/// <summary> Initializes the hashtables for the entity type and entity field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Dictionary<string, string>();
			_fieldsCustomProperties = new Dictionary<string, Dictionary<string, string>>();
			Dictionary<string, string> fieldHashtable;
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("UserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("OrganizationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Username", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Password", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("EmailAddress", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("CreateTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("LastLoginTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("LastActivityTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("LastPasswordChangeTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("LastLockoutTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organization</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganization(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _organization, new PropertyChangedEventHandler( OnOrganizationPropertyChanged ), "Organization", EPICCentralDL.RelationClasses.StaticUserRelations.OrganizationEntityUsingOrganizationIdStatic, true, signalRelatedEntity, "Users", resetFKFields, new int[] { (int)UserFieldIndex.OrganizationId } );		
			_organization = null;
		}
		
		/// <summary> setups the sync logic for member _organization</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganization(IEntityCore relatedEntity)
		{
			if(_organization!=relatedEntity)
			{		
				DesetupSyncOrganization(true, true);
				_organization = (OrganizationEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _organization, new PropertyChangedEventHandler( OnOrganizationPropertyChanged ), "Organization", EPICCentralDL.RelationClasses.StaticUserRelations.OrganizationEntityUsingOrganizationIdStatic, true, ref _alreadyFetchedOrganization, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _userSalt</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncUserSalt(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _userSalt, new PropertyChangedEventHandler( OnUserSaltPropertyChanged ), "UserSalt", EPICCentralDL.RelationClasses.StaticUserRelations.UserSaltEntityUsingUserIdStatic, false, signalRelatedEntity, "User", false, new int[] { (int)UserFieldIndex.UserId } );
			_userSalt = null;
		}
	
		/// <summary> setups the sync logic for member _userSalt</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncUserSalt(IEntityCore relatedEntity)
		{
			if(_userSalt!=relatedEntity)
			{
				DesetupSyncUserSalt(true, true);
				_userSalt = (UserSaltEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _userSalt, new PropertyChangedEventHandler( OnUserSaltPropertyChanged ), "UserSalt", EPICCentralDL.RelationClasses.StaticUserRelations.UserSaltEntityUsingUserIdStatic, false, ref _alreadyFetchedUserSalt, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnUserSaltPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="userId">PK value for User which data should be fetched into this User object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 userId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)UserFieldIndex.UserId].ForcedCurrentValueWrite(userId);
				CreateDAOInstance().FetchExisting(this, this.Transaction, prefetchPathToUse, contextToUse, excludedIncludedFields);
				return (this.Fields.State == EntityState.Fetched);
			}
			finally
			{
				OnFetchComplete();
			}
		}

		/// <summary> Creates the DAO instance for this type</summary>
		/// <returns></returns>
		protected override IDao CreateDAOInstance()
		{
			return DAOFactory.CreateUserDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new UserEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static UserRelations Relations
		{
			get	{ return new UserRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'PurchaseHistory' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathPurchaseHistories
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.PurchaseHistoryCollection(), (IEntityRelation)GetRelationsForField("PurchaseHistories")[0], (int)EPICCentralDL.EntityType.UserEntity, (int)EPICCentralDL.EntityType.PurchaseHistoryEntity, 0, null, null, null, "PurchaseHistories", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'SupportIssue' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathSupportIssues
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.SupportIssueCollection(), (IEntityRelation)GetRelationsForField("SupportIssues")[0], (int)EPICCentralDL.EntityType.UserEntity, (int)EPICCentralDL.EntityType.SupportIssueEntity, 0, null, null, null, "SupportIssues", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'SupportIssue' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathSupportIssues_
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.SupportIssueCollection(), (IEntityRelation)GetRelationsForField("SupportIssues_")[0], (int)EPICCentralDL.EntityType.UserEntity, (int)EPICCentralDL.EntityType.SupportIssueEntity, 0, null, null, null, "SupportIssues_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'UserAccountRestriction' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathUserAccountRestrictions
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.UserAccountRestrictionCollection(), (IEntityRelation)GetRelationsForField("UserAccountRestrictions")[0], (int)EPICCentralDL.EntityType.UserEntity, (int)EPICCentralDL.EntityType.UserAccountRestrictionEntity, 0, null, null, null, "UserAccountRestrictions", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'UserAssignedLocation' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathUserAssignedLocations
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.UserAssignedLocationCollection(), (IEntityRelation)GetRelationsForField("UserAssignedLocations")[0], (int)EPICCentralDL.EntityType.UserEntity, (int)EPICCentralDL.EntityType.UserAssignedLocationEntity, 0, null, null, null, "UserAssignedLocations", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'UserCreditCard' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathUserCreditCards
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.UserCreditCardCollection(), (IEntityRelation)GetRelationsForField("UserCreditCards")[0], (int)EPICCentralDL.EntityType.UserEntity, (int)EPICCentralDL.EntityType.UserCreditCardEntity, 0, null, null, null, "UserCreditCards", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'UserRole' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathRoles
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.UserRoleCollection(), (IEntityRelation)GetRelationsForField("Roles")[0], (int)EPICCentralDL.EntityType.UserEntity, (int)EPICCentralDL.EntityType.UserRoleEntity, 0, null, null, null, "Roles", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'UserSetting' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathSettings
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.UserSettingCollection(), (IEntityRelation)GetRelationsForField("Settings")[0], (int)EPICCentralDL.EntityType.UserEntity, (int)EPICCentralDL.EntityType.UserSettingEntity, 0, null, null, null, "Settings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Organization'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathOrganization
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.OrganizationCollection(), (IEntityRelation)GetRelationsForField("Organization")[0], (int)EPICCentralDL.EntityType.UserEntity, (int)EPICCentralDL.EntityType.OrganizationEntity, 0, null, null, null, "Organization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'UserSalt'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathUserSalt
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.UserSaltCollection(), (IEntityRelation)GetRelationsForField("UserSalt")[0], (int)EPICCentralDL.EntityType.UserEntity, (int)EPICCentralDL.EntityType.UserSaltEntity, 0, null, null, null, "UserSalt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);	}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		protected override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CustomProperties;}
		}

		/// <summary> The custom properties for the fields of this entity type. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, Dictionary<string, string>> FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary> The custom properties for the fields of the type of this entity instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		protected override Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType
		{
			get { return FieldsCustomProperties;}
		}

		/// <summary> The UserId property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."UserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 UserId
		{
			get { return (System.Int32)GetValue((int)UserFieldIndex.UserId, true); }
			set	{ SetValue((int)UserFieldIndex.UserId, value, true); }
		}

		/// <summary> The OrganizationId property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."OrganizationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 OrganizationId
		{
			get { return (System.Int32)GetValue((int)UserFieldIndex.OrganizationId, true); }
			set	{ SetValue((int)UserFieldIndex.OrganizationId, value, true); }
		}

		/// <summary> The Username property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."Username"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 80<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Username
		{
			get { return (System.String)GetValue((int)UserFieldIndex.Username, true); }
			set	{ SetValue((int)UserFieldIndex.Username, value, true); }
		}

		/// <summary> The Password property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."Password"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Password
		{
			get { return (System.String)GetValue((int)UserFieldIndex.Password, true); }
			set	{ SetValue((int)UserFieldIndex.Password, value, true); }
		}

		/// <summary> The EmailAddress property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."EmailAddress"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 128<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String EmailAddress
		{
			get { return (System.String)GetValue((int)UserFieldIndex.EmailAddress, true); }
			set	{ SetValue((int)UserFieldIndex.EmailAddress, value, true); }
		}

		/// <summary> The FirstName property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."FirstName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String FirstName
		{
			get { return (System.String)GetValue((int)UserFieldIndex.FirstName, true); }
			set	{ SetValue((int)UserFieldIndex.FirstName, value, true); }
		}

		/// <summary> The LastName property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."LastName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String LastName
		{
			get { return (System.String)GetValue((int)UserFieldIndex.LastName, true); }
			set	{ SetValue((int)UserFieldIndex.LastName, value, true); }
		}

		/// <summary> The CreateTime property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."CreateTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CreateTime
		{
			get { return (System.DateTime)GetValue((int)UserFieldIndex.CreateTime, true); }
			set	{ SetValue((int)UserFieldIndex.CreateTime, value, true); }
		}

		/// <summary> The LastLoginTime property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."LastLoginTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastLoginTime
		{
			get { return (Nullable<System.DateTime>)GetValue((int)UserFieldIndex.LastLoginTime, false); }
			set	{ SetValue((int)UserFieldIndex.LastLoginTime, value, true); }
		}

		/// <summary> The LastActivityTime property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."LastActivityTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastActivityTime
		{
			get { return (Nullable<System.DateTime>)GetValue((int)UserFieldIndex.LastActivityTime, false); }
			set	{ SetValue((int)UserFieldIndex.LastActivityTime, value, true); }
		}

		/// <summary> The LastPasswordChangeTime property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."LastPasswordChangeTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastPasswordChangeTime
		{
			get { return (Nullable<System.DateTime>)GetValue((int)UserFieldIndex.LastPasswordChangeTime, false); }
			set	{ SetValue((int)UserFieldIndex.LastPasswordChangeTime, value, true); }
		}

		/// <summary> The LastLockoutTime property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."LastLockoutTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastLockoutTime
		{
			get { return (Nullable<System.DateTime>)GetValue((int)UserFieldIndex.LastLockoutTime, false); }
			set	{ SetValue((int)UserFieldIndex.LastLockoutTime, value, true); }
		}

		/// <summary> The IsActive property of the Entity User<br/><br/></summary>
		/// <remarks>Mapped on  table field: "User"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)UserFieldIndex.IsActive, true); }
			set	{ SetValue((int)UserFieldIndex.IsActive, value, true); }
		}

		/// <summary> Retrieves all related entities of type 'PurchaseHistoryEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiPurchaseHistories()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.PurchaseHistoryCollection PurchaseHistories
		{
			get	{ return GetMultiPurchaseHistories(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for PurchaseHistories. When set to true, PurchaseHistories is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time PurchaseHistories is accessed. You can always execute/ a forced fetch by calling GetMultiPurchaseHistories(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchPurchaseHistories
		{
			get	{ return _alwaysFetchPurchaseHistories; }
			set	{ _alwaysFetchPurchaseHistories = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property PurchaseHistories already has been fetched. Setting this property to false when PurchaseHistories has been fetched
		/// will clear the PurchaseHistories collection well. Setting this property to true while PurchaseHistories hasn't been fetched disables lazy loading for PurchaseHistories</summary>
		[Browsable(false)]
		public bool AlreadyFetchedPurchaseHistories
		{
			get { return _alreadyFetchedPurchaseHistories;}
			set 
			{
				if(_alreadyFetchedPurchaseHistories && !value && (_purchaseHistories != null))
				{
					_purchaseHistories.Clear();
				}
				_alreadyFetchedPurchaseHistories = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'SupportIssueEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiSupportIssues()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.SupportIssueCollection SupportIssues
		{
			get	{ return GetMultiSupportIssues(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for SupportIssues. When set to true, SupportIssues is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time SupportIssues is accessed. You can always execute/ a forced fetch by calling GetMultiSupportIssues(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchSupportIssues
		{
			get	{ return _alwaysFetchSupportIssues; }
			set	{ _alwaysFetchSupportIssues = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property SupportIssues already has been fetched. Setting this property to false when SupportIssues has been fetched
		/// will clear the SupportIssues collection well. Setting this property to true while SupportIssues hasn't been fetched disables lazy loading for SupportIssues</summary>
		[Browsable(false)]
		public bool AlreadyFetchedSupportIssues
		{
			get { return _alreadyFetchedSupportIssues;}
			set 
			{
				if(_alreadyFetchedSupportIssues && !value && (_supportIssues != null))
				{
					_supportIssues.Clear();
				}
				_alreadyFetchedSupportIssues = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'SupportIssueEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiSupportIssues_()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.SupportIssueCollection SupportIssues_
		{
			get	{ return GetMultiSupportIssues_(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for SupportIssues_. When set to true, SupportIssues_ is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time SupportIssues_ is accessed. You can always execute/ a forced fetch by calling GetMultiSupportIssues_(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchSupportIssues_
		{
			get	{ return _alwaysFetchSupportIssues_; }
			set	{ _alwaysFetchSupportIssues_ = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property SupportIssues_ already has been fetched. Setting this property to false when SupportIssues_ has been fetched
		/// will clear the SupportIssues_ collection well. Setting this property to true while SupportIssues_ hasn't been fetched disables lazy loading for SupportIssues_</summary>
		[Browsable(false)]
		public bool AlreadyFetchedSupportIssues_
		{
			get { return _alreadyFetchedSupportIssues_;}
			set 
			{
				if(_alreadyFetchedSupportIssues_ && !value && (_supportIssues_ != null))
				{
					_supportIssues_.Clear();
				}
				_alreadyFetchedSupportIssues_ = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'UserAccountRestrictionEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiUserAccountRestrictions()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.UserAccountRestrictionCollection UserAccountRestrictions
		{
			get	{ return GetMultiUserAccountRestrictions(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for UserAccountRestrictions. When set to true, UserAccountRestrictions is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time UserAccountRestrictions is accessed. You can always execute/ a forced fetch by calling GetMultiUserAccountRestrictions(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchUserAccountRestrictions
		{
			get	{ return _alwaysFetchUserAccountRestrictions; }
			set	{ _alwaysFetchUserAccountRestrictions = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property UserAccountRestrictions already has been fetched. Setting this property to false when UserAccountRestrictions has been fetched
		/// will clear the UserAccountRestrictions collection well. Setting this property to true while UserAccountRestrictions hasn't been fetched disables lazy loading for UserAccountRestrictions</summary>
		[Browsable(false)]
		public bool AlreadyFetchedUserAccountRestrictions
		{
			get { return _alreadyFetchedUserAccountRestrictions;}
			set 
			{
				if(_alreadyFetchedUserAccountRestrictions && !value && (_userAccountRestrictions != null))
				{
					_userAccountRestrictions.Clear();
				}
				_alreadyFetchedUserAccountRestrictions = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'UserAssignedLocationEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiUserAssignedLocations()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.UserAssignedLocationCollection UserAssignedLocations
		{
			get	{ return GetMultiUserAssignedLocations(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for UserAssignedLocations. When set to true, UserAssignedLocations is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time UserAssignedLocations is accessed. You can always execute/ a forced fetch by calling GetMultiUserAssignedLocations(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchUserAssignedLocations
		{
			get	{ return _alwaysFetchUserAssignedLocations; }
			set	{ _alwaysFetchUserAssignedLocations = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property UserAssignedLocations already has been fetched. Setting this property to false when UserAssignedLocations has been fetched
		/// will clear the UserAssignedLocations collection well. Setting this property to true while UserAssignedLocations hasn't been fetched disables lazy loading for UserAssignedLocations</summary>
		[Browsable(false)]
		public bool AlreadyFetchedUserAssignedLocations
		{
			get { return _alreadyFetchedUserAssignedLocations;}
			set 
			{
				if(_alreadyFetchedUserAssignedLocations && !value && (_userAssignedLocations != null))
				{
					_userAssignedLocations.Clear();
				}
				_alreadyFetchedUserAssignedLocations = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'UserCreditCardEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiUserCreditCards()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.UserCreditCardCollection UserCreditCards
		{
			get	{ return GetMultiUserCreditCards(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for UserCreditCards. When set to true, UserCreditCards is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time UserCreditCards is accessed. You can always execute/ a forced fetch by calling GetMultiUserCreditCards(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchUserCreditCards
		{
			get	{ return _alwaysFetchUserCreditCards; }
			set	{ _alwaysFetchUserCreditCards = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property UserCreditCards already has been fetched. Setting this property to false when UserCreditCards has been fetched
		/// will clear the UserCreditCards collection well. Setting this property to true while UserCreditCards hasn't been fetched disables lazy loading for UserCreditCards</summary>
		[Browsable(false)]
		public bool AlreadyFetchedUserCreditCards
		{
			get { return _alreadyFetchedUserCreditCards;}
			set 
			{
				if(_alreadyFetchedUserCreditCards && !value && (_userCreditCards != null))
				{
					_userCreditCards.Clear();
				}
				_alreadyFetchedUserCreditCards = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'UserRoleEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiRoles()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.UserRoleCollection Roles
		{
			get	{ return GetMultiRoles(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Roles. When set to true, Roles is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Roles is accessed. You can always execute/ a forced fetch by calling GetMultiRoles(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchRoles
		{
			get	{ return _alwaysFetchRoles; }
			set	{ _alwaysFetchRoles = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property Roles already has been fetched. Setting this property to false when Roles has been fetched
		/// will clear the Roles collection well. Setting this property to true while Roles hasn't been fetched disables lazy loading for Roles</summary>
		[Browsable(false)]
		public bool AlreadyFetchedRoles
		{
			get { return _alreadyFetchedRoles;}
			set 
			{
				if(_alreadyFetchedRoles && !value && (_roles != null))
				{
					_roles.Clear();
				}
				_alreadyFetchedRoles = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'UserSettingEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiSettings()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.UserSettingCollection Settings
		{
			get	{ return GetMultiSettings(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Settings. When set to true, Settings is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Settings is accessed. You can always execute/ a forced fetch by calling GetMultiSettings(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchSettings
		{
			get	{ return _alwaysFetchSettings; }
			set	{ _alwaysFetchSettings = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property Settings already has been fetched. Setting this property to false when Settings has been fetched
		/// will clear the Settings collection well. Setting this property to true while Settings hasn't been fetched disables lazy loading for Settings</summary>
		[Browsable(false)]
		public bool AlreadyFetchedSettings
		{
			get { return _alreadyFetchedSettings;}
			set 
			{
				if(_alreadyFetchedSettings && !value && (_settings != null))
				{
					_settings.Clear();
				}
				_alreadyFetchedSettings = value;
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleOrganization()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual OrganizationEntity Organization
		{
			get	{ return GetSingleOrganization(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncOrganization(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "Users", "Organization", _organization, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Organization. When set to true, Organization is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Organization is accessed. You can always execute a forced fetch by calling GetSingleOrganization(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchOrganization
		{
			get	{ return _alwaysFetchOrganization; }
			set	{ _alwaysFetchOrganization = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property Organization already has been fetched. Setting this property to false when Organization has been fetched
		/// will set Organization to null as well. Setting this property to true while Organization hasn't been fetched disables lazy loading for Organization</summary>
		[Browsable(false)]
		public bool AlreadyFetchedOrganization
		{
			get { return _alreadyFetchedOrganization;}
			set 
			{
				if(_alreadyFetchedOrganization && !value)
				{
					this.Organization = null;
				}
				_alreadyFetchedOrganization = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Organization is not found
		/// in the database. When set to true, Organization will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: false.</summary>
		[Browsable(false)]
		public bool OrganizationReturnsNewIfNotFound
		{
			get	{ return _organizationReturnsNewIfNotFound; }
			set { _organizationReturnsNewIfNotFound = value; }	
		}

		/// <summary> Gets / sets related entity of type 'UserSaltEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/></summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleUserSalt()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual UserSaltEntity UserSalt
		{
			get	{ return GetSingleUserSalt(false); }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncUserSalt(value);
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_userSalt !=null);
						DesetupSyncUserSalt(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("UserSalt");
						}
					}
					else
					{
						if(_userSalt!=value)
						{
							((IEntity)value).SetRelatedEntity(this, "User");
							SetupSyncUserSalt(value);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for UserSalt. When set to true, UserSalt is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time UserSalt is accessed. You can always execute a forced fetch by calling GetSingleUserSalt(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchUserSalt
		{
			get	{ return _alwaysFetchUserSalt; }
			set	{ _alwaysFetchUserSalt = value; }	
		}
		
		/// <summary>Gets / Sets the lazy loading flag if the property UserSalt already has been fetched. Setting this property to false when UserSalt has been fetched
		/// will set UserSalt to null as well. Setting this property to true while UserSalt hasn't been fetched disables lazy loading for UserSalt</summary>
		[Browsable(false)]
		public bool AlreadyFetchedUserSalt
		{
			get { return _alreadyFetchedUserSalt;}
			set 
			{
				if(_alreadyFetchedUserSalt && !value)
				{
					this.UserSalt = null;
				}
				_alreadyFetchedUserSalt = value;
			}
		}
		
		/// <summary> Gets / sets the flag for what to do if the related entity available through the property UserSalt is not found
		/// in the database. When set to true, UserSalt will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: false.</summary>
		[Browsable(false)]
		public bool UserSaltReturnsNewIfNotFound
		{
			get	{ return _userSaltReturnsNewIfNotFound; }
			set	{ _userSaltReturnsNewIfNotFound = value; }	
		}

		/// <summary> Gets or sets a value indicating whether this entity is a subtype</summary>
		protected override bool LLBLGenProIsSubType
		{
			get { return false;}
		}

		/// <summary> Gets the type of the hierarchy this entity is in. </summary>
		[System.ComponentModel.Browsable(false), XmlIgnore]
		protected override InheritanceHierarchyType LLBLGenProIsInHierarchyOfType
		{
			get { return InheritanceHierarchyType.None;}
		}
		
		/// <summary>Returns the EPICCentralDL.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		protected override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)EPICCentralDL.EntityType.UserEntity; }
		}

		#endregion


		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included code

		#endregion
	}
}
