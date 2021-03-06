﻿///////////////////////////////////////////////////////////////
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

	/// <summary>Entity class which represents the entity 'ActiveOrganization'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ActiveOrganizationEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private ActivityTypeEntity _activityType;
		private bool	_alwaysFetchActivityType, _alreadyFetchedActivityType, _activityTypeReturnsNewIfNotFound;
		private LocationEntity _location;
		private bool	_alwaysFetchLocation, _alreadyFetchedLocation, _locationReturnsNewIfNotFound;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name ActivityType</summary>
			public static readonly string ActivityType = "ActivityType";
			/// <summary>Member name Location</summary>
			public static readonly string Location = "Location";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ActiveOrganizationEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public ActiveOrganizationEntity() :base("ActiveOrganizationEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="activeOrganizationId">PK value for ActiveOrganization which data should be fetched into this ActiveOrganization object</param>
		public ActiveOrganizationEntity(System.Int32 activeOrganizationId):base("ActiveOrganizationEntity")
		{
			InitClassFetch(activeOrganizationId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="activeOrganizationId">PK value for ActiveOrganization which data should be fetched into this ActiveOrganization object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public ActiveOrganizationEntity(System.Int32 activeOrganizationId, IPrefetchPath prefetchPathToUse):base("ActiveOrganizationEntity")
		{
			InitClassFetch(activeOrganizationId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="activeOrganizationId">PK value for ActiveOrganization which data should be fetched into this ActiveOrganization object</param>
		/// <param name="validator">The custom validator object for this ActiveOrganizationEntity</param>
		public ActiveOrganizationEntity(System.Int32 activeOrganizationId, IValidator validator):base("ActiveOrganizationEntity")
		{
			InitClassFetch(activeOrganizationId, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ActiveOrganizationEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_activityType = (ActivityTypeEntity)info.GetValue("_activityType", typeof(ActivityTypeEntity));
			if(_activityType!=null)
			{
				_activityType.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_activityTypeReturnsNewIfNotFound = info.GetBoolean("_activityTypeReturnsNewIfNotFound");
			_alwaysFetchActivityType = info.GetBoolean("_alwaysFetchActivityType");
			_alreadyFetchedActivityType = info.GetBoolean("_alreadyFetchedActivityType");

			_location = (LocationEntity)info.GetValue("_location", typeof(LocationEntity));
			if(_location!=null)
			{
				_location.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_locationReturnsNewIfNotFound = info.GetBoolean("_locationReturnsNewIfNotFound");
			_alwaysFetchLocation = info.GetBoolean("_alwaysFetchLocation");
			_alreadyFetchedLocation = info.GetBoolean("_alreadyFetchedLocation");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		
		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((ActiveOrganizationFieldIndex)fieldIndex)
			{
				case ActiveOrganizationFieldIndex.LocationId:
					DesetupSyncLocation(true, false);
					_alreadyFetchedLocation = false;
					break;
				case ActiveOrganizationFieldIndex.ActivityTypeId:
					DesetupSyncActivityType(true, false);
					_alreadyFetchedActivityType = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedActivityType = (_activityType != null);
			_alreadyFetchedLocation = (_location != null);
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
				case "ActivityType":
					toReturn.Add(Relations.ActivityTypeEntityUsingActivityTypeId);
					break;
				case "Location":
					toReturn.Add(Relations.LocationEntityUsingLocationId);
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
			info.AddValue("_activityType", (!this.MarkedForDeletion?_activityType:null));
			info.AddValue("_activityTypeReturnsNewIfNotFound", _activityTypeReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchActivityType", _alwaysFetchActivityType);
			info.AddValue("_alreadyFetchedActivityType", _alreadyFetchedActivityType);
			info.AddValue("_location", (!this.MarkedForDeletion?_location:null));
			info.AddValue("_locationReturnsNewIfNotFound", _locationReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchLocation", _alwaysFetchLocation);
			info.AddValue("_alreadyFetchedLocation", _alreadyFetchedLocation);

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
				case "ActivityType":
					_alreadyFetchedActivityType = true;
					this.ActivityType = (ActivityTypeEntity)entity;
					break;
				case "Location":
					_alreadyFetchedLocation = true;
					this.Location = (LocationEntity)entity;
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
				case "ActivityType":
					SetupSyncActivityType(relatedEntity);
					break;
				case "Location":
					SetupSyncLocation(relatedEntity);
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
				case "ActivityType":
					DesetupSyncActivityType(false, true);
					break;
				case "Location":
					DesetupSyncLocation(false, true);
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
			if(_activityType!=null)
			{
				toReturn.Add(_activityType);
			}
			if(_location!=null)
			{
				toReturn.Add(_location);
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
		/// <param name="activeOrganizationId">PK value for ActiveOrganization which data should be fetched into this ActiveOrganization object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 activeOrganizationId)
		{
			return FetchUsingPK(activeOrganizationId, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="activeOrganizationId">PK value for ActiveOrganization which data should be fetched into this ActiveOrganization object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 activeOrganizationId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(activeOrganizationId, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="activeOrganizationId">PK value for ActiveOrganization which data should be fetched into this ActiveOrganization object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 activeOrganizationId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(activeOrganizationId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="activeOrganizationId">PK value for ActiveOrganization which data should be fetched into this ActiveOrganization object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 activeOrganizationId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(activeOrganizationId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.ActiveOrganizationId, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new ActiveOrganizationRelations().GetAllRelations();
		}

		/// <summary> Retrieves the related entity of type 'ActivityTypeEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'ActivityTypeEntity' which is related to this entity.</returns>
		public ActivityTypeEntity GetSingleActivityType()
		{
			return GetSingleActivityType(false);
		}

		/// <summary> Retrieves the related entity of type 'ActivityTypeEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'ActivityTypeEntity' which is related to this entity.</returns>
		public virtual ActivityTypeEntity GetSingleActivityType(bool forceFetch)
		{
			if( ( !_alreadyFetchedActivityType || forceFetch || _alwaysFetchActivityType) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.ActivityTypeEntityUsingActivityTypeId);
				ActivityTypeEntity newEntity = new ActivityTypeEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.ActivityTypeId);
				}
				if(fetchResult)
				{
					newEntity = (ActivityTypeEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_activityTypeReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.ActivityType = newEntity;
				_alreadyFetchedActivityType = fetchResult;
			}
			return _activityType;
		}


		/// <summary> Retrieves the related entity of type 'LocationEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'LocationEntity' which is related to this entity.</returns>
		public LocationEntity GetSingleLocation()
		{
			return GetSingleLocation(false);
		}

		/// <summary> Retrieves the related entity of type 'LocationEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'LocationEntity' which is related to this entity.</returns>
		public virtual LocationEntity GetSingleLocation(bool forceFetch)
		{
			if( ( !_alreadyFetchedLocation || forceFetch || _alwaysFetchLocation) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.LocationEntityUsingLocationId);
				LocationEntity newEntity = new LocationEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.LocationId);
				}
				if(fetchResult)
				{
					newEntity = (LocationEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_locationReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.Location = newEntity;
				_alreadyFetchedLocation = fetchResult;
			}
			return _location;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("ActivityType", _activityType);
			toReturn.Add("Location", _location);
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
		/// <param name="activeOrganizationId">PK value for ActiveOrganization which data should be fetched into this ActiveOrganization object</param>
		/// <param name="validator">The validator object for this ActiveOrganizationEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 activeOrganizationId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(activeOrganizationId, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
			_activityTypeReturnsNewIfNotFound = false;
			_locationReturnsNewIfNotFound = false;
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
			_fieldsCustomProperties.Add("ActiveOrganizationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("LocationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ActivityTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ActivityTime", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _activityType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncActivityType(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _activityType, new PropertyChangedEventHandler( OnActivityTypePropertyChanged ), "ActivityType", EPICCentralDL.RelationClasses.StaticActiveOrganizationRelations.ActivityTypeEntityUsingActivityTypeIdStatic, true, signalRelatedEntity, "ActiveOrganizations", resetFKFields, new int[] { (int)ActiveOrganizationFieldIndex.ActivityTypeId } );		
			_activityType = null;
		}
		
		/// <summary> setups the sync logic for member _activityType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncActivityType(IEntityCore relatedEntity)
		{
			if(_activityType!=relatedEntity)
			{		
				DesetupSyncActivityType(true, true);
				_activityType = (ActivityTypeEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _activityType, new PropertyChangedEventHandler( OnActivityTypePropertyChanged ), "ActivityType", EPICCentralDL.RelationClasses.StaticActiveOrganizationRelations.ActivityTypeEntityUsingActivityTypeIdStatic, true, ref _alreadyFetchedActivityType, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnActivityTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _location</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLocation(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _location, new PropertyChangedEventHandler( OnLocationPropertyChanged ), "Location", EPICCentralDL.RelationClasses.StaticActiveOrganizationRelations.LocationEntityUsingLocationIdStatic, true, signalRelatedEntity, "ActiveOrganizations", resetFKFields, new int[] { (int)ActiveOrganizationFieldIndex.LocationId } );		
			_location = null;
		}
		
		/// <summary> setups the sync logic for member _location</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLocation(IEntityCore relatedEntity)
		{
			if(_location!=relatedEntity)
			{		
				DesetupSyncLocation(true, true);
				_location = (LocationEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _location, new PropertyChangedEventHandler( OnLocationPropertyChanged ), "Location", EPICCentralDL.RelationClasses.StaticActiveOrganizationRelations.LocationEntityUsingLocationIdStatic, true, ref _alreadyFetchedLocation, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLocationPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="activeOrganizationId">PK value for ActiveOrganization which data should be fetched into this ActiveOrganization object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 activeOrganizationId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)ActiveOrganizationFieldIndex.ActiveOrganizationId].ForcedCurrentValueWrite(activeOrganizationId);
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
			return DAOFactory.CreateActiveOrganizationDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new ActiveOrganizationEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static ActiveOrganizationRelations Relations
		{
			get	{ return new ActiveOrganizationRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'ActivityType'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathActivityType
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.ActivityTypeCollection(), (IEntityRelation)GetRelationsForField("ActivityType")[0], (int)EPICCentralDL.EntityType.ActiveOrganizationEntity, (int)EPICCentralDL.EntityType.ActivityTypeEntity, 0, null, null, null, "ActivityType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Location'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathLocation
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.LocationCollection(), (IEntityRelation)GetRelationsForField("Location")[0], (int)EPICCentralDL.EntityType.ActiveOrganizationEntity, (int)EPICCentralDL.EntityType.LocationEntity, 0, null, null, null, "Location", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The ActiveOrganizationId property of the Entity ActiveOrganization<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ActiveOrganization"."ActiveOrganizationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 ActiveOrganizationId
		{
			get { return (System.Int32)GetValue((int)ActiveOrganizationFieldIndex.ActiveOrganizationId, true); }
			set	{ SetValue((int)ActiveOrganizationFieldIndex.ActiveOrganizationId, value, true); }
		}

		/// <summary> The LocationId property of the Entity ActiveOrganization<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ActiveOrganization"."LocationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 LocationId
		{
			get { return (System.Int32)GetValue((int)ActiveOrganizationFieldIndex.LocationId, true); }
			set	{ SetValue((int)ActiveOrganizationFieldIndex.LocationId, value, true); }
		}

		/// <summary> The ActivityTypeId property of the Entity ActiveOrganization<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ActiveOrganization"."ActivityTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 ActivityTypeId
		{
			get { return (System.Int16)GetValue((int)ActiveOrganizationFieldIndex.ActivityTypeId, true); }
			set	{ SetValue((int)ActiveOrganizationFieldIndex.ActivityTypeId, value, true); }
		}

		/// <summary> The ActivityTime property of the Entity ActiveOrganization<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ActiveOrganization"."ActivityTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ActivityTime
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ActiveOrganizationFieldIndex.ActivityTime, false); }
			set	{ SetValue((int)ActiveOrganizationFieldIndex.ActivityTime, value, true); }
		}


		/// <summary> Gets / sets related entity of type 'ActivityTypeEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleActivityType()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual ActivityTypeEntity ActivityType
		{
			get	{ return GetSingleActivityType(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncActivityType(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "ActiveOrganizations", "ActivityType", _activityType, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for ActivityType. When set to true, ActivityType is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time ActivityType is accessed. You can always execute a forced fetch by calling GetSingleActivityType(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchActivityType
		{
			get	{ return _alwaysFetchActivityType; }
			set	{ _alwaysFetchActivityType = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property ActivityType already has been fetched. Setting this property to false when ActivityType has been fetched
		/// will set ActivityType to null as well. Setting this property to true while ActivityType hasn't been fetched disables lazy loading for ActivityType</summary>
		[Browsable(false)]
		public bool AlreadyFetchedActivityType
		{
			get { return _alreadyFetchedActivityType;}
			set 
			{
				if(_alreadyFetchedActivityType && !value)
				{
					this.ActivityType = null;
				}
				_alreadyFetchedActivityType = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property ActivityType is not found
		/// in the database. When set to true, ActivityType will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: false.</summary>
		[Browsable(false)]
		public bool ActivityTypeReturnsNewIfNotFound
		{
			get	{ return _activityTypeReturnsNewIfNotFound; }
			set { _activityTypeReturnsNewIfNotFound = value; }	
		}

		/// <summary> Gets / sets related entity of type 'LocationEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleLocation()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual LocationEntity Location
		{
			get	{ return GetSingleLocation(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncLocation(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "ActiveOrganizations", "Location", _location, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Location. When set to true, Location is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Location is accessed. You can always execute a forced fetch by calling GetSingleLocation(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchLocation
		{
			get	{ return _alwaysFetchLocation; }
			set	{ _alwaysFetchLocation = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property Location already has been fetched. Setting this property to false when Location has been fetched
		/// will set Location to null as well. Setting this property to true while Location hasn't been fetched disables lazy loading for Location</summary>
		[Browsable(false)]
		public bool AlreadyFetchedLocation
		{
			get { return _alreadyFetchedLocation;}
			set 
			{
				if(_alreadyFetchedLocation && !value)
				{
					this.Location = null;
				}
				_alreadyFetchedLocation = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Location is not found
		/// in the database. When set to true, Location will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: false.</summary>
		[Browsable(false)]
		public bool LocationReturnsNewIfNotFound
		{
			get	{ return _locationReturnsNewIfNotFound; }
			set { _locationReturnsNewIfNotFound = value; }	
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
			get { return (int)EPICCentralDL.EntityType.ActiveOrganizationEntity; }
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
