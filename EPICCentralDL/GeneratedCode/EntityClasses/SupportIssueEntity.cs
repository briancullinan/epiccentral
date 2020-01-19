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

	/// <summary>Entity class which represents the entity 'SupportIssue'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class SupportIssueEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private SupportAreaEntity _supportArea;
		private bool	_alwaysFetchSupportArea, _alreadyFetchedSupportArea, _supportAreaReturnsNewIfNotFound;
		private UserEntity _user;
		private bool	_alwaysFetchUser, _alreadyFetchedUser, _userReturnsNewIfNotFound;
		private UserEntity _user_;
		private bool	_alwaysFetchUser_, _alreadyFetchedUser_, _user_ReturnsNewIfNotFound;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name SupportArea</summary>
			public static readonly string SupportArea = "SupportArea";
			/// <summary>Member name User</summary>
			public static readonly string User = "User";
			/// <summary>Member name User_</summary>
			public static readonly string User_ = "User_";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static SupportIssueEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public SupportIssueEntity() :base("SupportIssueEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="supportIssueId">PK value for SupportIssue which data should be fetched into this SupportIssue object</param>
		public SupportIssueEntity(System.Int32 supportIssueId):base("SupportIssueEntity")
		{
			InitClassFetch(supportIssueId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="supportIssueId">PK value for SupportIssue which data should be fetched into this SupportIssue object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public SupportIssueEntity(System.Int32 supportIssueId, IPrefetchPath prefetchPathToUse):base("SupportIssueEntity")
		{
			InitClassFetch(supportIssueId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="supportIssueId">PK value for SupportIssue which data should be fetched into this SupportIssue object</param>
		/// <param name="validator">The custom validator object for this SupportIssueEntity</param>
		public SupportIssueEntity(System.Int32 supportIssueId, IValidator validator):base("SupportIssueEntity")
		{
			InitClassFetch(supportIssueId, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected SupportIssueEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_supportArea = (SupportAreaEntity)info.GetValue("_supportArea", typeof(SupportAreaEntity));
			if(_supportArea!=null)
			{
				_supportArea.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_supportAreaReturnsNewIfNotFound = info.GetBoolean("_supportAreaReturnsNewIfNotFound");
			_alwaysFetchSupportArea = info.GetBoolean("_alwaysFetchSupportArea");
			_alreadyFetchedSupportArea = info.GetBoolean("_alreadyFetchedSupportArea");

			_user = (UserEntity)info.GetValue("_user", typeof(UserEntity));
			if(_user!=null)
			{
				_user.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_userReturnsNewIfNotFound = info.GetBoolean("_userReturnsNewIfNotFound");
			_alwaysFetchUser = info.GetBoolean("_alwaysFetchUser");
			_alreadyFetchedUser = info.GetBoolean("_alreadyFetchedUser");

			_user_ = (UserEntity)info.GetValue("_user_", typeof(UserEntity));
			if(_user_!=null)
			{
				_user_.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_user_ReturnsNewIfNotFound = info.GetBoolean("_user_ReturnsNewIfNotFound");
			_alwaysFetchUser_ = info.GetBoolean("_alwaysFetchUser_");
			_alreadyFetchedUser_ = info.GetBoolean("_alreadyFetchedUser_");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		
		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((SupportIssueFieldIndex)fieldIndex)
			{
				case SupportIssueFieldIndex.SupportAreaId:
					DesetupSyncSupportArea(true, false);
					_alreadyFetchedSupportArea = false;
					break;
				case SupportIssueFieldIndex.ToUserId:
					DesetupSyncUser_(true, false);
					_alreadyFetchedUser_ = false;
					break;
				case SupportIssueFieldIndex.FromUserId:
					DesetupSyncUser(true, false);
					_alreadyFetchedUser = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedSupportArea = (_supportArea != null);
			_alreadyFetchedUser = (_user != null);
			_alreadyFetchedUser_ = (_user_ != null);
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
				case "SupportArea":
					toReturn.Add(Relations.SupportAreaEntityUsingSupportAreaId);
					break;
				case "User":
					toReturn.Add(Relations.UserEntityUsingFromUserId);
					break;
				case "User_":
					toReturn.Add(Relations.UserEntityUsingToUserId);
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
			info.AddValue("_supportArea", (!this.MarkedForDeletion?_supportArea:null));
			info.AddValue("_supportAreaReturnsNewIfNotFound", _supportAreaReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchSupportArea", _alwaysFetchSupportArea);
			info.AddValue("_alreadyFetchedSupportArea", _alreadyFetchedSupportArea);
			info.AddValue("_user", (!this.MarkedForDeletion?_user:null));
			info.AddValue("_userReturnsNewIfNotFound", _userReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchUser", _alwaysFetchUser);
			info.AddValue("_alreadyFetchedUser", _alreadyFetchedUser);
			info.AddValue("_user_", (!this.MarkedForDeletion?_user_:null));
			info.AddValue("_user_ReturnsNewIfNotFound", _user_ReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchUser_", _alwaysFetchUser_);
			info.AddValue("_alreadyFetchedUser_", _alreadyFetchedUser_);

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
				case "SupportArea":
					_alreadyFetchedSupportArea = true;
					this.SupportArea = (SupportAreaEntity)entity;
					break;
				case "User":
					_alreadyFetchedUser = true;
					this.User = (UserEntity)entity;
					break;
				case "User_":
					_alreadyFetchedUser_ = true;
					this.User_ = (UserEntity)entity;
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
				case "SupportArea":
					SetupSyncSupportArea(relatedEntity);
					break;
				case "User":
					SetupSyncUser(relatedEntity);
					break;
				case "User_":
					SetupSyncUser_(relatedEntity);
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
				case "SupportArea":
					DesetupSyncSupportArea(false, true);
					break;
				case "User":
					DesetupSyncUser(false, true);
					break;
				case "User_":
					DesetupSyncUser_(false, true);
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
			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		protected override List<IEntity> GetDependentRelatedEntities()
		{
			List<IEntity> toReturn = new List<IEntity>();
			if(_supportArea!=null)
			{
				toReturn.Add(_supportArea);
			}
			if(_user!=null)
			{
				toReturn.Add(_user);
			}
			if(_user_!=null)
			{
				toReturn.Add(_user_);
			}
			return toReturn;
		}
		
		/// <summary> Gets a List of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		protected override List<IEntityCollection> GetMemberEntityCollections()
		{
			List<IEntityCollection> toReturn = new List<IEntityCollection>();


			return toReturn;
		}


		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="supportIssueId">PK value for SupportIssue which data should be fetched into this SupportIssue object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 supportIssueId)
		{
			return FetchUsingPK(supportIssueId, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="supportIssueId">PK value for SupportIssue which data should be fetched into this SupportIssue object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 supportIssueId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(supportIssueId, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="supportIssueId">PK value for SupportIssue which data should be fetched into this SupportIssue object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 supportIssueId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(supportIssueId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="supportIssueId">PK value for SupportIssue which data should be fetched into this SupportIssue object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 supportIssueId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(supportIssueId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.SupportIssueId, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new SupportIssueRelations().GetAllRelations();
		}

		/// <summary> Retrieves the related entity of type 'SupportAreaEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'SupportAreaEntity' which is related to this entity.</returns>
		public SupportAreaEntity GetSingleSupportArea()
		{
			return GetSingleSupportArea(false);
		}

		/// <summary> Retrieves the related entity of type 'SupportAreaEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'SupportAreaEntity' which is related to this entity.</returns>
		public virtual SupportAreaEntity GetSingleSupportArea(bool forceFetch)
		{
			if( ( !_alreadyFetchedSupportArea || forceFetch || _alwaysFetchSupportArea) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.SupportAreaEntityUsingSupportAreaId);
				SupportAreaEntity newEntity = new SupportAreaEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.SupportAreaId);
				}
				if(fetchResult)
				{
					newEntity = (SupportAreaEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_supportAreaReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.SupportArea = newEntity;
				_alreadyFetchedSupportArea = fetchResult;
			}
			return _supportArea;
		}


		/// <summary> Retrieves the related entity of type 'UserEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'UserEntity' which is related to this entity.</returns>
		public UserEntity GetSingleUser()
		{
			return GetSingleUser(false);
		}

		/// <summary> Retrieves the related entity of type 'UserEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'UserEntity' which is related to this entity.</returns>
		public virtual UserEntity GetSingleUser(bool forceFetch)
		{
			if( ( !_alreadyFetchedUser || forceFetch || _alwaysFetchUser) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.UserEntityUsingFromUserId);
				UserEntity newEntity = new UserEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.FromUserId.GetValueOrDefault());
				}
				if(fetchResult)
				{
					newEntity = (UserEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_userReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.User = newEntity;
				_alreadyFetchedUser = fetchResult;
			}
			return _user;
		}


		/// <summary> Retrieves the related entity of type 'UserEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'UserEntity' which is related to this entity.</returns>
		public UserEntity GetSingleUser_()
		{
			return GetSingleUser_(false);
		}

		/// <summary> Retrieves the related entity of type 'UserEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'UserEntity' which is related to this entity.</returns>
		public virtual UserEntity GetSingleUser_(bool forceFetch)
		{
			if( ( !_alreadyFetchedUser_ || forceFetch || _alwaysFetchUser_) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.UserEntityUsingToUserId);
				UserEntity newEntity = new UserEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.ToUserId.GetValueOrDefault());
				}
				if(fetchResult)
				{
					newEntity = (UserEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_user_ReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.User_ = newEntity;
				_alreadyFetchedUser_ = fetchResult;
			}
			return _user_;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("SupportArea", _supportArea);
			toReturn.Add("User", _user);
			toReturn.Add("User_", _user_);
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
		/// <param name="supportIssueId">PK value for SupportIssue which data should be fetched into this SupportIssue object</param>
		/// <param name="validator">The validator object for this SupportIssueEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 supportIssueId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(supportIssueId, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
			_supportAreaReturnsNewIfNotFound = false;
			_userReturnsNewIfNotFound = false;
			_user_ReturnsNewIfNotFound = false;
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
			_fieldsCustomProperties.Add("SupportIssueId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ParentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("SupportAreaId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("CreateTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ToUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("FromUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Subject", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Body", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Status", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Priority", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IsPublic", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IsClosedByToUser", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IsClosedByFromUser", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _supportArea</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncSupportArea(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _supportArea, new PropertyChangedEventHandler( OnSupportAreaPropertyChanged ), "SupportArea", EPICCentralDL.RelationClasses.StaticSupportIssueRelations.SupportAreaEntityUsingSupportAreaIdStatic, true, signalRelatedEntity, "SupportIssues", resetFKFields, new int[] { (int)SupportIssueFieldIndex.SupportAreaId } );		
			_supportArea = null;
		}
		
		/// <summary> setups the sync logic for member _supportArea</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncSupportArea(IEntityCore relatedEntity)
		{
			if(_supportArea!=relatedEntity)
			{		
				DesetupSyncSupportArea(true, true);
				_supportArea = (SupportAreaEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _supportArea, new PropertyChangedEventHandler( OnSupportAreaPropertyChanged ), "SupportArea", EPICCentralDL.RelationClasses.StaticSupportIssueRelations.SupportAreaEntityUsingSupportAreaIdStatic, true, ref _alreadyFetchedSupportArea, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSupportAreaPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _user</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncUser(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _user, new PropertyChangedEventHandler( OnUserPropertyChanged ), "User", EPICCentralDL.RelationClasses.StaticSupportIssueRelations.UserEntityUsingFromUserIdStatic, true, signalRelatedEntity, "SupportIssues", resetFKFields, new int[] { (int)SupportIssueFieldIndex.FromUserId } );		
			_user = null;
		}
		
		/// <summary> setups the sync logic for member _user</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncUser(IEntityCore relatedEntity)
		{
			if(_user!=relatedEntity)
			{		
				DesetupSyncUser(true, true);
				_user = (UserEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _user, new PropertyChangedEventHandler( OnUserPropertyChanged ), "User", EPICCentralDL.RelationClasses.StaticSupportIssueRelations.UserEntityUsingFromUserIdStatic, true, ref _alreadyFetchedUser, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _user_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncUser_(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _user_, new PropertyChangedEventHandler( OnUser_PropertyChanged ), "User_", EPICCentralDL.RelationClasses.StaticSupportIssueRelations.UserEntityUsingToUserIdStatic, true, signalRelatedEntity, "SupportIssues_", resetFKFields, new int[] { (int)SupportIssueFieldIndex.ToUserId } );		
			_user_ = null;
		}
		
		/// <summary> setups the sync logic for member _user_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncUser_(IEntityCore relatedEntity)
		{
			if(_user_!=relatedEntity)
			{		
				DesetupSyncUser_(true, true);
				_user_ = (UserEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _user_, new PropertyChangedEventHandler( OnUser_PropertyChanged ), "User_", EPICCentralDL.RelationClasses.StaticSupportIssueRelations.UserEntityUsingToUserIdStatic, true, ref _alreadyFetchedUser_, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnUser_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="supportIssueId">PK value for SupportIssue which data should be fetched into this SupportIssue object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 supportIssueId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)SupportIssueFieldIndex.SupportIssueId].ForcedCurrentValueWrite(supportIssueId);
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
			return DAOFactory.CreateSupportIssueDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new SupportIssueEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static SupportIssueRelations Relations
		{
			get	{ return new SupportIssueRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'SupportArea'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathSupportArea
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.SupportAreaCollection(), (IEntityRelation)GetRelationsForField("SupportArea")[0], (int)EPICCentralDL.EntityType.SupportIssueEntity, (int)EPICCentralDL.EntityType.SupportAreaEntity, 0, null, null, null, "SupportArea", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'User'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathUser
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.UserCollection(), (IEntityRelation)GetRelationsForField("User")[0], (int)EPICCentralDL.EntityType.SupportIssueEntity, (int)EPICCentralDL.EntityType.UserEntity, 0, null, null, null, "User", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'User'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathUser_
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.UserCollection(), (IEntityRelation)GetRelationsForField("User_")[0], (int)EPICCentralDL.EntityType.SupportIssueEntity, (int)EPICCentralDL.EntityType.UserEntity, 0, null, null, null, "User_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The SupportIssueId property of the Entity SupportIssue<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportIssue"."SupportIssueId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 SupportIssueId
		{
			get { return (System.Int32)GetValue((int)SupportIssueFieldIndex.SupportIssueId, true); }
			set	{ SetValue((int)SupportIssueFieldIndex.SupportIssueId, value, true); }
		}

		/// <summary> The ParentId property of the Entity SupportIssue<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportIssue"."ParentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ParentId
		{
			get { return (System.Int32)GetValue((int)SupportIssueFieldIndex.ParentId, true); }
			set	{ SetValue((int)SupportIssueFieldIndex.ParentId, value, true); }
		}

		/// <summary> The SupportAreaId property of the Entity SupportIssue<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportIssue"."SupportAreaId"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 SupportAreaId
		{
			get { return (System.Int16)GetValue((int)SupportIssueFieldIndex.SupportAreaId, true); }
			set	{ SetValue((int)SupportIssueFieldIndex.SupportAreaId, value, true); }
		}

		/// <summary> The CreateTime property of the Entity SupportIssue<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportIssue"."CreateTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CreateTime
		{
			get { return (System.DateTime)GetValue((int)SupportIssueFieldIndex.CreateTime, true); }
			set	{ SetValue((int)SupportIssueFieldIndex.CreateTime, value, true); }
		}

		/// <summary> The ToUserId property of the Entity SupportIssue<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportIssue"."ToUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> ToUserId
		{
			get { return (Nullable<System.Int32>)GetValue((int)SupportIssueFieldIndex.ToUserId, false); }
			set	{ SetValue((int)SupportIssueFieldIndex.ToUserId, value, true); }
		}

		/// <summary> The FromUserId property of the Entity SupportIssue<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportIssue"."FromUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> FromUserId
		{
			get { return (Nullable<System.Int32>)GetValue((int)SupportIssueFieldIndex.FromUserId, false); }
			set	{ SetValue((int)SupportIssueFieldIndex.FromUserId, value, true); }
		}

		/// <summary> The Subject property of the Entity SupportIssue<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportIssue"."Subject"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Subject
		{
			get { return (System.String)GetValue((int)SupportIssueFieldIndex.Subject, true); }
			set	{ SetValue((int)SupportIssueFieldIndex.Subject, value, true); }
		}

		/// <summary> The Body property of the Entity SupportIssue<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportIssue"."Body"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 6144<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Body
		{
			get { return (System.String)GetValue((int)SupportIssueFieldIndex.Body, true); }
			set	{ SetValue((int)SupportIssueFieldIndex.Body, value, true); }
		}

		/// <summary> The Status property of the Entity SupportIssue<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportIssue"."Status"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 128<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Status
		{
			get { return (System.String)GetValue((int)SupportIssueFieldIndex.Status, true); }
			set	{ SetValue((int)SupportIssueFieldIndex.Status, value, true); }
		}

		/// <summary> The Priority property of the Entity SupportIssue<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportIssue"."Priority"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 Priority
		{
			get { return (System.Int16)GetValue((int)SupportIssueFieldIndex.Priority, true); }
			set	{ SetValue((int)SupportIssueFieldIndex.Priority, value, true); }
		}

		/// <summary> The IsPublic property of the Entity SupportIssue<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportIssue"."IsPublic"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPublic
		{
			get { return (System.Boolean)GetValue((int)SupportIssueFieldIndex.IsPublic, true); }
			set	{ SetValue((int)SupportIssueFieldIndex.IsPublic, value, true); }
		}

		/// <summary> The IsClosedByToUser property of the Entity SupportIssue<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportIssue"."IsClosedByToUser"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsClosedByToUser
		{
			get { return (System.Boolean)GetValue((int)SupportIssueFieldIndex.IsClosedByToUser, true); }
			set	{ SetValue((int)SupportIssueFieldIndex.IsClosedByToUser, value, true); }
		}

		/// <summary> The IsClosedByFromUser property of the Entity SupportIssue<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportIssue"."IsClosedByFromUser"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsClosedByFromUser
		{
			get { return (System.Boolean)GetValue((int)SupportIssueFieldIndex.IsClosedByFromUser, true); }
			set	{ SetValue((int)SupportIssueFieldIndex.IsClosedByFromUser, value, true); }
		}

		/// <summary> The IsActive property of the Entity SupportIssue<br/><br/></summary>
		/// <remarks>Mapped on  table field: "SupportIssue"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)SupportIssueFieldIndex.IsActive, true); }
			set	{ SetValue((int)SupportIssueFieldIndex.IsActive, value, true); }
		}


		/// <summary> Gets / sets related entity of type 'SupportAreaEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleSupportArea()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual SupportAreaEntity SupportArea
		{
			get	{ return GetSingleSupportArea(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncSupportArea(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "SupportIssues", "SupportArea", _supportArea, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for SupportArea. When set to true, SupportArea is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time SupportArea is accessed. You can always execute a forced fetch by calling GetSingleSupportArea(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchSupportArea
		{
			get	{ return _alwaysFetchSupportArea; }
			set	{ _alwaysFetchSupportArea = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property SupportArea already has been fetched. Setting this property to false when SupportArea has been fetched
		/// will set SupportArea to null as well. Setting this property to true while SupportArea hasn't been fetched disables lazy loading for SupportArea</summary>
		[Browsable(false)]
		public bool AlreadyFetchedSupportArea
		{
			get { return _alreadyFetchedSupportArea;}
			set 
			{
				if(_alreadyFetchedSupportArea && !value)
				{
					this.SupportArea = null;
				}
				_alreadyFetchedSupportArea = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property SupportArea is not found
		/// in the database. When set to true, SupportArea will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: false.</summary>
		[Browsable(false)]
		public bool SupportAreaReturnsNewIfNotFound
		{
			get	{ return _supportAreaReturnsNewIfNotFound; }
			set { _supportAreaReturnsNewIfNotFound = value; }	
		}

		/// <summary> Gets / sets related entity of type 'UserEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleUser()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual UserEntity User
		{
			get	{ return GetSingleUser(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncUser(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "SupportIssues", "User", _user, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for User. When set to true, User is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time User is accessed. You can always execute a forced fetch by calling GetSingleUser(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchUser
		{
			get	{ return _alwaysFetchUser; }
			set	{ _alwaysFetchUser = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property User already has been fetched. Setting this property to false when User has been fetched
		/// will set User to null as well. Setting this property to true while User hasn't been fetched disables lazy loading for User</summary>
		[Browsable(false)]
		public bool AlreadyFetchedUser
		{
			get { return _alreadyFetchedUser;}
			set 
			{
				if(_alreadyFetchedUser && !value)
				{
					this.User = null;
				}
				_alreadyFetchedUser = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property User is not found
		/// in the database. When set to true, User will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: false.</summary>
		[Browsable(false)]
		public bool UserReturnsNewIfNotFound
		{
			get	{ return _userReturnsNewIfNotFound; }
			set { _userReturnsNewIfNotFound = value; }	
		}

		/// <summary> Gets / sets related entity of type 'UserEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleUser_()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual UserEntity User_
		{
			get	{ return GetSingleUser_(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncUser_(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "SupportIssues_", "User_", _user_, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for User_. When set to true, User_ is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time User_ is accessed. You can always execute a forced fetch by calling GetSingleUser_(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchUser_
		{
			get	{ return _alwaysFetchUser_; }
			set	{ _alwaysFetchUser_ = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property User_ already has been fetched. Setting this property to false when User_ has been fetched
		/// will set User_ to null as well. Setting this property to true while User_ hasn't been fetched disables lazy loading for User_</summary>
		[Browsable(false)]
		public bool AlreadyFetchedUser_
		{
			get { return _alreadyFetchedUser_;}
			set 
			{
				if(_alreadyFetchedUser_ && !value)
				{
					this.User_ = null;
				}
				_alreadyFetchedUser_ = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property User_ is not found
		/// in the database. When set to true, User_ will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: false.</summary>
		[Browsable(false)]
		public bool User_ReturnsNewIfNotFound
		{
			get	{ return _user_ReturnsNewIfNotFound; }
			set { _user_ReturnsNewIfNotFound = value; }	
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
			get { return (int)EPICCentralDL.EntityType.SupportIssueEntity; }
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
