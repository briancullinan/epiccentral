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

	/// <summary>Entity class which represents the entity 'Location'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class LocationEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EPICCentralDL.CollectionClasses.ActiveOrganizationCollection	_activeOrganizations;
		private bool	_alwaysFetchActiveOrganizations, _alreadyFetchedActiveOrganizations;
		private EPICCentralDL.CollectionClasses.DeviceCollection	_devices;
		private bool	_alwaysFetchDevices, _alreadyFetchedDevices;
		private EPICCentralDL.CollectionClasses.PatientCollection	_patients;
		private bool	_alwaysFetchPatients, _alreadyFetchedPatients;
		private EPICCentralDL.CollectionClasses.PurchaseHistoryCollection	_purchaseHistories;
		private bool	_alwaysFetchPurchaseHistories, _alreadyFetchedPurchaseHistories;
		private EPICCentralDL.CollectionClasses.UserAssignedLocationCollection	_userAssignedLocations;
		private bool	_alwaysFetchUserAssignedLocations, _alreadyFetchedUserAssignedLocations;
		private OrganizationEntity _organization;
		private bool	_alwaysFetchOrganization, _alreadyFetchedOrganization, _organizationReturnsNewIfNotFound;

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
			/// <summary>Member name ActiveOrganizations</summary>
			public static readonly string ActiveOrganizations = "ActiveOrganizations";
			/// <summary>Member name Devices</summary>
			public static readonly string Devices = "Devices";
			/// <summary>Member name Patients</summary>
			public static readonly string Patients = "Patients";
			/// <summary>Member name PurchaseHistories</summary>
			public static readonly string PurchaseHistories = "PurchaseHistories";
			/// <summary>Member name UserAssignedLocations</summary>
			public static readonly string UserAssignedLocations = "UserAssignedLocations";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static LocationEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public LocationEntity() :base("LocationEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="locationId">PK value for Location which data should be fetched into this Location object</param>
		public LocationEntity(System.Int32 locationId):base("LocationEntity")
		{
			InitClassFetch(locationId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="locationId">PK value for Location which data should be fetched into this Location object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public LocationEntity(System.Int32 locationId, IPrefetchPath prefetchPathToUse):base("LocationEntity")
		{
			InitClassFetch(locationId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="locationId">PK value for Location which data should be fetched into this Location object</param>
		/// <param name="validator">The custom validator object for this LocationEntity</param>
		public LocationEntity(System.Int32 locationId, IValidator validator):base("LocationEntity")
		{
			InitClassFetch(locationId, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected LocationEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_activeOrganizations = (EPICCentralDL.CollectionClasses.ActiveOrganizationCollection)info.GetValue("_activeOrganizations", typeof(EPICCentralDL.CollectionClasses.ActiveOrganizationCollection));
			_alwaysFetchActiveOrganizations = info.GetBoolean("_alwaysFetchActiveOrganizations");
			_alreadyFetchedActiveOrganizations = info.GetBoolean("_alreadyFetchedActiveOrganizations");

			_devices = (EPICCentralDL.CollectionClasses.DeviceCollection)info.GetValue("_devices", typeof(EPICCentralDL.CollectionClasses.DeviceCollection));
			_alwaysFetchDevices = info.GetBoolean("_alwaysFetchDevices");
			_alreadyFetchedDevices = info.GetBoolean("_alreadyFetchedDevices");

			_patients = (EPICCentralDL.CollectionClasses.PatientCollection)info.GetValue("_patients", typeof(EPICCentralDL.CollectionClasses.PatientCollection));
			_alwaysFetchPatients = info.GetBoolean("_alwaysFetchPatients");
			_alreadyFetchedPatients = info.GetBoolean("_alreadyFetchedPatients");

			_purchaseHistories = (EPICCentralDL.CollectionClasses.PurchaseHistoryCollection)info.GetValue("_purchaseHistories", typeof(EPICCentralDL.CollectionClasses.PurchaseHistoryCollection));
			_alwaysFetchPurchaseHistories = info.GetBoolean("_alwaysFetchPurchaseHistories");
			_alreadyFetchedPurchaseHistories = info.GetBoolean("_alreadyFetchedPurchaseHistories");

			_userAssignedLocations = (EPICCentralDL.CollectionClasses.UserAssignedLocationCollection)info.GetValue("_userAssignedLocations", typeof(EPICCentralDL.CollectionClasses.UserAssignedLocationCollection));
			_alwaysFetchUserAssignedLocations = info.GetBoolean("_alwaysFetchUserAssignedLocations");
			_alreadyFetchedUserAssignedLocations = info.GetBoolean("_alreadyFetchedUserAssignedLocations");
			_organization = (OrganizationEntity)info.GetValue("_organization", typeof(OrganizationEntity));
			if(_organization!=null)
			{
				_organization.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_organizationReturnsNewIfNotFound = info.GetBoolean("_organizationReturnsNewIfNotFound");
			_alwaysFetchOrganization = info.GetBoolean("_alwaysFetchOrganization");
			_alreadyFetchedOrganization = info.GetBoolean("_alreadyFetchedOrganization");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		
		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((LocationFieldIndex)fieldIndex)
			{
				case LocationFieldIndex.OrganizationId:
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
			_alreadyFetchedActiveOrganizations = (_activeOrganizations.Count > 0);
			_alreadyFetchedDevices = (_devices.Count > 0);
			_alreadyFetchedPatients = (_patients.Count > 0);
			_alreadyFetchedPurchaseHistories = (_purchaseHistories.Count > 0);
			_alreadyFetchedUserAssignedLocations = (_userAssignedLocations.Count > 0);
			_alreadyFetchedOrganization = (_organization != null);
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
				case "ActiveOrganizations":
					toReturn.Add(Relations.ActiveOrganizationEntityUsingLocationId);
					break;
				case "Devices":
					toReturn.Add(Relations.DeviceEntityUsingLocationId);
					break;
				case "Patients":
					toReturn.Add(Relations.PatientEntityUsingLocationId);
					break;
				case "PurchaseHistories":
					toReturn.Add(Relations.PurchaseHistoryEntityUsingLocationId);
					break;
				case "UserAssignedLocations":
					toReturn.Add(Relations.UserAssignedLocationEntityUsingLocationId);
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
			info.AddValue("_activeOrganizations", (!this.MarkedForDeletion?_activeOrganizations:null));
			info.AddValue("_alwaysFetchActiveOrganizations", _alwaysFetchActiveOrganizations);
			info.AddValue("_alreadyFetchedActiveOrganizations", _alreadyFetchedActiveOrganizations);
			info.AddValue("_devices", (!this.MarkedForDeletion?_devices:null));
			info.AddValue("_alwaysFetchDevices", _alwaysFetchDevices);
			info.AddValue("_alreadyFetchedDevices", _alreadyFetchedDevices);
			info.AddValue("_patients", (!this.MarkedForDeletion?_patients:null));
			info.AddValue("_alwaysFetchPatients", _alwaysFetchPatients);
			info.AddValue("_alreadyFetchedPatients", _alreadyFetchedPatients);
			info.AddValue("_purchaseHistories", (!this.MarkedForDeletion?_purchaseHistories:null));
			info.AddValue("_alwaysFetchPurchaseHistories", _alwaysFetchPurchaseHistories);
			info.AddValue("_alreadyFetchedPurchaseHistories", _alreadyFetchedPurchaseHistories);
			info.AddValue("_userAssignedLocations", (!this.MarkedForDeletion?_userAssignedLocations:null));
			info.AddValue("_alwaysFetchUserAssignedLocations", _alwaysFetchUserAssignedLocations);
			info.AddValue("_alreadyFetchedUserAssignedLocations", _alreadyFetchedUserAssignedLocations);
			info.AddValue("_organization", (!this.MarkedForDeletion?_organization:null));
			info.AddValue("_organizationReturnsNewIfNotFound", _organizationReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchOrganization", _alwaysFetchOrganization);
			info.AddValue("_alreadyFetchedOrganization", _alreadyFetchedOrganization);

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
				case "ActiveOrganizations":
					_alreadyFetchedActiveOrganizations = true;
					if(entity!=null)
					{
						this.ActiveOrganizations.Add((ActiveOrganizationEntity)entity);
					}
					break;
				case "Devices":
					_alreadyFetchedDevices = true;
					if(entity!=null)
					{
						this.Devices.Add((DeviceEntity)entity);
					}
					break;
				case "Patients":
					_alreadyFetchedPatients = true;
					if(entity!=null)
					{
						this.Patients.Add((PatientEntity)entity);
					}
					break;
				case "PurchaseHistories":
					_alreadyFetchedPurchaseHistories = true;
					if(entity!=null)
					{
						this.PurchaseHistories.Add((PurchaseHistoryEntity)entity);
					}
					break;
				case "UserAssignedLocations":
					_alreadyFetchedUserAssignedLocations = true;
					if(entity!=null)
					{
						this.UserAssignedLocations.Add((UserAssignedLocationEntity)entity);
					}
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
				case "ActiveOrganizations":
					_activeOrganizations.Add((ActiveOrganizationEntity)relatedEntity);
					break;
				case "Devices":
					_devices.Add((DeviceEntity)relatedEntity);
					break;
				case "Patients":
					_patients.Add((PatientEntity)relatedEntity);
					break;
				case "PurchaseHistories":
					_purchaseHistories.Add((PurchaseHistoryEntity)relatedEntity);
					break;
				case "UserAssignedLocations":
					_userAssignedLocations.Add((UserAssignedLocationEntity)relatedEntity);
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
				case "ActiveOrganizations":
					this.PerformRelatedEntityRemoval(_activeOrganizations, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Devices":
					this.PerformRelatedEntityRemoval(_devices, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Patients":
					this.PerformRelatedEntityRemoval(_patients, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PurchaseHistories":
					this.PerformRelatedEntityRemoval(_purchaseHistories, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "UserAssignedLocations":
					this.PerformRelatedEntityRemoval(_userAssignedLocations, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(_activeOrganizations);
			toReturn.Add(_devices);
			toReturn.Add(_patients);
			toReturn.Add(_purchaseHistories);
			toReturn.Add(_userAssignedLocations);

			return toReturn;
		}


		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="locationId">PK value for Location which data should be fetched into this Location object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 locationId)
		{
			return FetchUsingPK(locationId, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="locationId">PK value for Location which data should be fetched into this Location object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 locationId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(locationId, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="locationId">PK value for Location which data should be fetched into this Location object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 locationId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(locationId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="locationId">PK value for Location which data should be fetched into this Location object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 locationId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(locationId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.LocationId, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new LocationRelations().GetAllRelations();
		}

		/// <summary> Retrieves all related entities of type 'ActiveOrganizationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'ActiveOrganizationEntity'</returns>
		public EPICCentralDL.CollectionClasses.ActiveOrganizationCollection GetMultiActiveOrganizations(bool forceFetch)
		{
			return GetMultiActiveOrganizations(forceFetch, _activeOrganizations.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ActiveOrganizationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'ActiveOrganizationEntity'</returns>
		public EPICCentralDL.CollectionClasses.ActiveOrganizationCollection GetMultiActiveOrganizations(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiActiveOrganizations(forceFetch, _activeOrganizations.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'ActiveOrganizationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.ActiveOrganizationCollection GetMultiActiveOrganizations(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiActiveOrganizations(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ActiveOrganizationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.ActiveOrganizationCollection GetMultiActiveOrganizations(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedActiveOrganizations || forceFetch || _alwaysFetchActiveOrganizations) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_activeOrganizations);
				_activeOrganizations.SuppressClearInGetMulti=!forceFetch;
				_activeOrganizations.EntityFactoryToUse = entityFactoryToUse;
				_activeOrganizations.GetMultiManyToOne(null, this, filter);
				_activeOrganizations.SuppressClearInGetMulti=false;
				_alreadyFetchedActiveOrganizations = true;
			}
			return _activeOrganizations;
		}

		/// <summary> Sets the collection parameters for the collection for 'ActiveOrganizations'. These settings will be taken into account
		/// when the property ActiveOrganizations is requested or GetMultiActiveOrganizations is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersActiveOrganizations(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_activeOrganizations.SortClauses=sortClauses;
			_activeOrganizations.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'DeviceEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'DeviceEntity'</returns>
		public EPICCentralDL.CollectionClasses.DeviceCollection GetMultiDevices(bool forceFetch)
		{
			return GetMultiDevices(forceFetch, _devices.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'DeviceEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'DeviceEntity'</returns>
		public EPICCentralDL.CollectionClasses.DeviceCollection GetMultiDevices(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiDevices(forceFetch, _devices.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'DeviceEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.DeviceCollection GetMultiDevices(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiDevices(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'DeviceEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.DeviceCollection GetMultiDevices(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedDevices || forceFetch || _alwaysFetchDevices) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_devices);
				_devices.SuppressClearInGetMulti=!forceFetch;
				_devices.EntityFactoryToUse = entityFactoryToUse;
				_devices.GetMultiManyToOne(this, filter);
				_devices.SuppressClearInGetMulti=false;
				_alreadyFetchedDevices = true;
			}
			return _devices;
		}

		/// <summary> Sets the collection parameters for the collection for 'Devices'. These settings will be taken into account
		/// when the property Devices is requested or GetMultiDevices is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersDevices(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_devices.SortClauses=sortClauses;
			_devices.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'PatientEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'PatientEntity'</returns>
		public EPICCentralDL.CollectionClasses.PatientCollection GetMultiPatients(bool forceFetch)
		{
			return GetMultiPatients(forceFetch, _patients.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'PatientEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'PatientEntity'</returns>
		public EPICCentralDL.CollectionClasses.PatientCollection GetMultiPatients(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiPatients(forceFetch, _patients.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'PatientEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.PatientCollection GetMultiPatients(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiPatients(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'PatientEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.PatientCollection GetMultiPatients(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedPatients || forceFetch || _alwaysFetchPatients) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_patients);
				_patients.SuppressClearInGetMulti=!forceFetch;
				_patients.EntityFactoryToUse = entityFactoryToUse;
				_patients.GetMultiManyToOne(this, filter);
				_patients.SuppressClearInGetMulti=false;
				_alreadyFetchedPatients = true;
			}
			return _patients;
		}

		/// <summary> Sets the collection parameters for the collection for 'Patients'. These settings will be taken into account
		/// when the property Patients is requested or GetMultiPatients is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersPatients(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_patients.SortClauses=sortClauses;
			_patients.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
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
				_purchaseHistories.GetMultiManyToOne(null, this, null, filter);
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
				_userAssignedLocations.GetMultiManyToOne(this, null, filter);
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


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Organization", _organization);
			toReturn.Add("ActiveOrganizations", _activeOrganizations);
			toReturn.Add("Devices", _devices);
			toReturn.Add("Patients", _patients);
			toReturn.Add("PurchaseHistories", _purchaseHistories);
			toReturn.Add("UserAssignedLocations", _userAssignedLocations);
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
		/// <param name="locationId">PK value for Location which data should be fetched into this Location object</param>
		/// <param name="validator">The validator object for this LocationEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 locationId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(locationId, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{

			_activeOrganizations = new EPICCentralDL.CollectionClasses.ActiveOrganizationCollection();
			_activeOrganizations.SetContainingEntityInfo(this, "Location");

			_devices = new EPICCentralDL.CollectionClasses.DeviceCollection();
			_devices.SetContainingEntityInfo(this, "Location");

			_patients = new EPICCentralDL.CollectionClasses.PatientCollection();
			_patients.SetContainingEntityInfo(this, "Location");

			_purchaseHistories = new EPICCentralDL.CollectionClasses.PurchaseHistoryCollection();
			_purchaseHistories.SetContainingEntityInfo(this, "Location");

			_userAssignedLocations = new EPICCentralDL.CollectionClasses.UserAssignedLocationCollection();
			_userAssignedLocations.SetContainingEntityInfo(this, "Location");
			_organizationReturnsNewIfNotFound = false;
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
			_fieldsCustomProperties.Add("LocationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("OrganizationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("UniqueIdentifier", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AddressLine1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AddressLine2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("City", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("State", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Country", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("PostalCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("PhoneNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Latitude", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Longitude", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organization</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganization(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _organization, new PropertyChangedEventHandler( OnOrganizationPropertyChanged ), "Organization", EPICCentralDL.RelationClasses.StaticLocationRelations.OrganizationEntityUsingOrganizationIdStatic, true, signalRelatedEntity, "Locations", resetFKFields, new int[] { (int)LocationFieldIndex.OrganizationId } );		
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
				this.PerformSetupSyncRelatedEntity( _organization, new PropertyChangedEventHandler( OnOrganizationPropertyChanged ), "Organization", EPICCentralDL.RelationClasses.StaticLocationRelations.OrganizationEntityUsingOrganizationIdStatic, true, ref _alreadyFetchedOrganization, new string[] {  } );
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

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="locationId">PK value for Location which data should be fetched into this Location object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 locationId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)LocationFieldIndex.LocationId].ForcedCurrentValueWrite(locationId);
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
			return DAOFactory.CreateLocationDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new LocationEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static LocationRelations Relations
		{
			get	{ return new LocationRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'ActiveOrganization' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathActiveOrganizations
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.ActiveOrganizationCollection(), (IEntityRelation)GetRelationsForField("ActiveOrganizations")[0], (int)EPICCentralDL.EntityType.LocationEntity, (int)EPICCentralDL.EntityType.ActiveOrganizationEntity, 0, null, null, null, "ActiveOrganizations", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Device' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathDevices
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.DeviceCollection(), (IEntityRelation)GetRelationsForField("Devices")[0], (int)EPICCentralDL.EntityType.LocationEntity, (int)EPICCentralDL.EntityType.DeviceEntity, 0, null, null, null, "Devices", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Patient' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathPatients
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.PatientCollection(), (IEntityRelation)GetRelationsForField("Patients")[0], (int)EPICCentralDL.EntityType.LocationEntity, (int)EPICCentralDL.EntityType.PatientEntity, 0, null, null, null, "Patients", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'PurchaseHistory' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathPurchaseHistories
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.PurchaseHistoryCollection(), (IEntityRelation)GetRelationsForField("PurchaseHistories")[0], (int)EPICCentralDL.EntityType.LocationEntity, (int)EPICCentralDL.EntityType.PurchaseHistoryEntity, 0, null, null, null, "PurchaseHistories", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'UserAssignedLocation' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathUserAssignedLocations
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.UserAssignedLocationCollection(), (IEntityRelation)GetRelationsForField("UserAssignedLocations")[0], (int)EPICCentralDL.EntityType.LocationEntity, (int)EPICCentralDL.EntityType.UserAssignedLocationEntity, 0, null, null, null, "UserAssignedLocations", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Organization'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathOrganization
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.OrganizationCollection(), (IEntityRelation)GetRelationsForField("Organization")[0], (int)EPICCentralDL.EntityType.LocationEntity, (int)EPICCentralDL.EntityType.OrganizationEntity, 0, null, null, null, "Organization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The LocationId property of the Entity Location<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Location"."LocationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 LocationId
		{
			get { return (System.Int32)GetValue((int)LocationFieldIndex.LocationId, true); }
			set	{ SetValue((int)LocationFieldIndex.LocationId, value, true); }
		}

		/// <summary> The OrganizationId property of the Entity Location<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Location"."OrganizationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 OrganizationId
		{
			get { return (System.Int32)GetValue((int)LocationFieldIndex.OrganizationId, true); }
			set	{ SetValue((int)LocationFieldIndex.OrganizationId, value, true); }
		}

		/// <summary> The UniqueIdentifier property of the Entity Location<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Location"."UniqueIdentifier"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 48<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String UniqueIdentifier
		{
			get { return (System.String)GetValue((int)LocationFieldIndex.UniqueIdentifier, true); }
			set	{ SetValue((int)LocationFieldIndex.UniqueIdentifier, value, true); }
		}

		/// <summary> The Name property of the Entity Location<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Location"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 80<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)LocationFieldIndex.Name, true); }
			set	{ SetValue((int)LocationFieldIndex.Name, value, true); }
		}

		/// <summary> The AddressLine1 property of the Entity Location<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Location"."AddressLine1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 80<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String AddressLine1
		{
			get { return (System.String)GetValue((int)LocationFieldIndex.AddressLine1, true); }
			set	{ SetValue((int)LocationFieldIndex.AddressLine1, value, true); }
		}

		/// <summary> The AddressLine2 property of the Entity Location<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Location"."AddressLine2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 80<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AddressLine2
		{
			get { return (System.String)GetValue((int)LocationFieldIndex.AddressLine2, true); }
			set	{ SetValue((int)LocationFieldIndex.AddressLine2, value, true); }
		}

		/// <summary> The City property of the Entity Location<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Location"."City"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 40<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String City
		{
			get { return (System.String)GetValue((int)LocationFieldIndex.City, true); }
			set	{ SetValue((int)LocationFieldIndex.City, value, true); }
		}

		/// <summary> The State property of the Entity Location<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Location"."State"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String State
		{
			get { return (System.String)GetValue((int)LocationFieldIndex.State, true); }
			set	{ SetValue((int)LocationFieldIndex.State, value, true); }
		}

		/// <summary> The Country property of the Entity Location<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Location"."Country"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Country
		{
			get { return (System.String)GetValue((int)LocationFieldIndex.Country, true); }
			set	{ SetValue((int)LocationFieldIndex.Country, value, true); }
		}

		/// <summary> The PostalCode property of the Entity Location<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Location"."PostalCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 10<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String PostalCode
		{
			get { return (System.String)GetValue((int)LocationFieldIndex.PostalCode, true); }
			set	{ SetValue((int)LocationFieldIndex.PostalCode, value, true); }
		}

		/// <summary> The PhoneNumber property of the Entity Location<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Location"."PhoneNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String PhoneNumber
		{
			get { return (System.String)GetValue((int)LocationFieldIndex.PhoneNumber, true); }
			set	{ SetValue((int)LocationFieldIndex.PhoneNumber, value, true); }
		}

		/// <summary> The Latitude property of the Entity Location<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Location"."Latitude"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 7, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Latitude
		{
			get { return (Nullable<System.Decimal>)GetValue((int)LocationFieldIndex.Latitude, false); }
			set	{ SetValue((int)LocationFieldIndex.Latitude, value, true); }
		}

		/// <summary> The Longitude property of the Entity Location<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Location"."Longitude"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 7, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Longitude
		{
			get { return (Nullable<System.Decimal>)GetValue((int)LocationFieldIndex.Longitude, false); }
			set	{ SetValue((int)LocationFieldIndex.Longitude, value, true); }
		}

		/// <summary> The IsActive property of the Entity Location<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Location"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)LocationFieldIndex.IsActive, true); }
			set	{ SetValue((int)LocationFieldIndex.IsActive, value, true); }
		}

		/// <summary> Retrieves all related entities of type 'ActiveOrganizationEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiActiveOrganizations()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.ActiveOrganizationCollection ActiveOrganizations
		{
			get	{ return GetMultiActiveOrganizations(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for ActiveOrganizations. When set to true, ActiveOrganizations is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time ActiveOrganizations is accessed. You can always execute/ a forced fetch by calling GetMultiActiveOrganizations(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchActiveOrganizations
		{
			get	{ return _alwaysFetchActiveOrganizations; }
			set	{ _alwaysFetchActiveOrganizations = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property ActiveOrganizations already has been fetched. Setting this property to false when ActiveOrganizations has been fetched
		/// will clear the ActiveOrganizations collection well. Setting this property to true while ActiveOrganizations hasn't been fetched disables lazy loading for ActiveOrganizations</summary>
		[Browsable(false)]
		public bool AlreadyFetchedActiveOrganizations
		{
			get { return _alreadyFetchedActiveOrganizations;}
			set 
			{
				if(_alreadyFetchedActiveOrganizations && !value && (_activeOrganizations != null))
				{
					_activeOrganizations.Clear();
				}
				_alreadyFetchedActiveOrganizations = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'DeviceEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiDevices()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.DeviceCollection Devices
		{
			get	{ return GetMultiDevices(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Devices. When set to true, Devices is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Devices is accessed. You can always execute/ a forced fetch by calling GetMultiDevices(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchDevices
		{
			get	{ return _alwaysFetchDevices; }
			set	{ _alwaysFetchDevices = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property Devices already has been fetched. Setting this property to false when Devices has been fetched
		/// will clear the Devices collection well. Setting this property to true while Devices hasn't been fetched disables lazy loading for Devices</summary>
		[Browsable(false)]
		public bool AlreadyFetchedDevices
		{
			get { return _alreadyFetchedDevices;}
			set 
			{
				if(_alreadyFetchedDevices && !value && (_devices != null))
				{
					_devices.Clear();
				}
				_alreadyFetchedDevices = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'PatientEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiPatients()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.PatientCollection Patients
		{
			get	{ return GetMultiPatients(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Patients. When set to true, Patients is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Patients is accessed. You can always execute/ a forced fetch by calling GetMultiPatients(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchPatients
		{
			get	{ return _alwaysFetchPatients; }
			set	{ _alwaysFetchPatients = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property Patients already has been fetched. Setting this property to false when Patients has been fetched
		/// will clear the Patients collection well. Setting this property to true while Patients hasn't been fetched disables lazy loading for Patients</summary>
		[Browsable(false)]
		public bool AlreadyFetchedPatients
		{
			get { return _alreadyFetchedPatients;}
			set 
			{
				if(_alreadyFetchedPatients && !value && (_patients != null))
				{
					_patients.Clear();
				}
				_alreadyFetchedPatients = value;
			}
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
					SetSingleRelatedEntityNavigator(value, "Locations", "Organization", _organization, true); 
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
			get { return (int)EPICCentralDL.EntityType.LocationEntity; }
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
