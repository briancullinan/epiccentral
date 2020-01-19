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

	/// <summary>Entity class which represents the entity 'LicenseOrganSystem'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class LicenseOrganSystemEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EPICCentralDL.CollectionClasses.OrganSystemOrganCollection	_organSystemOrgans;
		private bool	_alwaysFetchOrganSystemOrgans, _alreadyFetchedOrganSystemOrgans;
		private OrganSystemEntity _organSystem;
		private bool	_alwaysFetchOrganSystem, _alreadyFetchedOrganSystem, _organSystemReturnsNewIfNotFound;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name OrganSystem</summary>
			public static readonly string OrganSystem = "OrganSystem";
			/// <summary>Member name OrganSystemOrgans</summary>
			public static readonly string OrganSystemOrgans = "OrganSystemOrgans";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static LicenseOrganSystemEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public LicenseOrganSystemEntity() :base("LicenseOrganSystemEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="licenseOrganSystemId">PK value for LicenseOrganSystem which data should be fetched into this LicenseOrganSystem object</param>
		public LicenseOrganSystemEntity(System.Int16 licenseOrganSystemId):base("LicenseOrganSystemEntity")
		{
			InitClassFetch(licenseOrganSystemId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="licenseOrganSystemId">PK value for LicenseOrganSystem which data should be fetched into this LicenseOrganSystem object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public LicenseOrganSystemEntity(System.Int16 licenseOrganSystemId, IPrefetchPath prefetchPathToUse):base("LicenseOrganSystemEntity")
		{
			InitClassFetch(licenseOrganSystemId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="licenseOrganSystemId">PK value for LicenseOrganSystem which data should be fetched into this LicenseOrganSystem object</param>
		/// <param name="validator">The custom validator object for this LicenseOrganSystemEntity</param>
		public LicenseOrganSystemEntity(System.Int16 licenseOrganSystemId, IValidator validator):base("LicenseOrganSystemEntity")
		{
			InitClassFetch(licenseOrganSystemId, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected LicenseOrganSystemEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_organSystemOrgans = (EPICCentralDL.CollectionClasses.OrganSystemOrganCollection)info.GetValue("_organSystemOrgans", typeof(EPICCentralDL.CollectionClasses.OrganSystemOrganCollection));
			_alwaysFetchOrganSystemOrgans = info.GetBoolean("_alwaysFetchOrganSystemOrgans");
			_alreadyFetchedOrganSystemOrgans = info.GetBoolean("_alreadyFetchedOrganSystemOrgans");
			_organSystem = (OrganSystemEntity)info.GetValue("_organSystem", typeof(OrganSystemEntity));
			if(_organSystem!=null)
			{
				_organSystem.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_organSystemReturnsNewIfNotFound = info.GetBoolean("_organSystemReturnsNewIfNotFound");
			_alwaysFetchOrganSystem = info.GetBoolean("_alwaysFetchOrganSystem");
			_alreadyFetchedOrganSystem = info.GetBoolean("_alreadyFetchedOrganSystem");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		
		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((LicenseOrganSystemFieldIndex)fieldIndex)
			{
				case LicenseOrganSystemFieldIndex.OrganSystemId:
					DesetupSyncOrganSystem(true, false);
					_alreadyFetchedOrganSystem = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedOrganSystemOrgans = (_organSystemOrgans.Count > 0);
			_alreadyFetchedOrganSystem = (_organSystem != null);
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
				case "OrganSystem":
					toReturn.Add(Relations.OrganSystemEntityUsingOrganSystemId);
					break;
				case "OrganSystemOrgans":
					toReturn.Add(Relations.OrganSystemOrganEntityUsingLicenseOrganSystemId);
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
			info.AddValue("_organSystemOrgans", (!this.MarkedForDeletion?_organSystemOrgans:null));
			info.AddValue("_alwaysFetchOrganSystemOrgans", _alwaysFetchOrganSystemOrgans);
			info.AddValue("_alreadyFetchedOrganSystemOrgans", _alreadyFetchedOrganSystemOrgans);
			info.AddValue("_organSystem", (!this.MarkedForDeletion?_organSystem:null));
			info.AddValue("_organSystemReturnsNewIfNotFound", _organSystemReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchOrganSystem", _alwaysFetchOrganSystem);
			info.AddValue("_alreadyFetchedOrganSystem", _alreadyFetchedOrganSystem);

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
				case "OrganSystem":
					_alreadyFetchedOrganSystem = true;
					this.OrganSystem = (OrganSystemEntity)entity;
					break;
				case "OrganSystemOrgans":
					_alreadyFetchedOrganSystemOrgans = true;
					if(entity!=null)
					{
						this.OrganSystemOrgans.Add((OrganSystemOrganEntity)entity);
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
				case "OrganSystem":
					SetupSyncOrganSystem(relatedEntity);
					break;
				case "OrganSystemOrgans":
					_organSystemOrgans.Add((OrganSystemOrganEntity)relatedEntity);
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
				case "OrganSystem":
					DesetupSyncOrganSystem(false, true);
					break;
				case "OrganSystemOrgans":
					this.PerformRelatedEntityRemoval(_organSystemOrgans, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_organSystem!=null)
			{
				toReturn.Add(_organSystem);
			}
			return toReturn;
		}
		
		/// <summary> Gets a List of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		protected override List<IEntityCollection> GetMemberEntityCollections()
		{
			List<IEntityCollection> toReturn = new List<IEntityCollection>();
			toReturn.Add(_organSystemOrgans);

			return toReturn;
		}


		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="licenseOrganSystemId">PK value for LicenseOrganSystem which data should be fetched into this LicenseOrganSystem object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int16 licenseOrganSystemId)
		{
			return FetchUsingPK(licenseOrganSystemId, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="licenseOrganSystemId">PK value for LicenseOrganSystem which data should be fetched into this LicenseOrganSystem object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int16 licenseOrganSystemId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(licenseOrganSystemId, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="licenseOrganSystemId">PK value for LicenseOrganSystem which data should be fetched into this LicenseOrganSystem object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int16 licenseOrganSystemId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(licenseOrganSystemId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="licenseOrganSystemId">PK value for LicenseOrganSystem which data should be fetched into this LicenseOrganSystem object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int16 licenseOrganSystemId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(licenseOrganSystemId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.LicenseOrganSystemId, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new LicenseOrganSystemRelations().GetAllRelations();
		}

		/// <summary> Retrieves all related entities of type 'OrganSystemOrganEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'OrganSystemOrganEntity'</returns>
		public EPICCentralDL.CollectionClasses.OrganSystemOrganCollection GetMultiOrganSystemOrgans(bool forceFetch)
		{
			return GetMultiOrganSystemOrgans(forceFetch, _organSystemOrgans.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'OrganSystemOrganEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'OrganSystemOrganEntity'</returns>
		public EPICCentralDL.CollectionClasses.OrganSystemOrganCollection GetMultiOrganSystemOrgans(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiOrganSystemOrgans(forceFetch, _organSystemOrgans.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'OrganSystemOrganEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.OrganSystemOrganCollection GetMultiOrganSystemOrgans(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiOrganSystemOrgans(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'OrganSystemOrganEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.OrganSystemOrganCollection GetMultiOrganSystemOrgans(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedOrganSystemOrgans || forceFetch || _alwaysFetchOrganSystemOrgans) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_organSystemOrgans);
				_organSystemOrgans.SuppressClearInGetMulti=!forceFetch;
				_organSystemOrgans.EntityFactoryToUse = entityFactoryToUse;
				_organSystemOrgans.GetMultiManyToOne(this, null, filter);
				_organSystemOrgans.SuppressClearInGetMulti=false;
				_alreadyFetchedOrganSystemOrgans = true;
			}
			return _organSystemOrgans;
		}

		/// <summary> Sets the collection parameters for the collection for 'OrganSystemOrgans'. These settings will be taken into account
		/// when the property OrganSystemOrgans is requested or GetMultiOrganSystemOrgans is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersOrganSystemOrgans(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_organSystemOrgans.SortClauses=sortClauses;
			_organSystemOrgans.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves the related entity of type 'OrganSystemEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'OrganSystemEntity' which is related to this entity.</returns>
		public OrganSystemEntity GetSingleOrganSystem()
		{
			return GetSingleOrganSystem(false);
		}

		/// <summary> Retrieves the related entity of type 'OrganSystemEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'OrganSystemEntity' which is related to this entity.</returns>
		public virtual OrganSystemEntity GetSingleOrganSystem(bool forceFetch)
		{
			if( ( !_alreadyFetchedOrganSystem || forceFetch || _alwaysFetchOrganSystem) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.OrganSystemEntityUsingOrganSystemId);
				OrganSystemEntity newEntity = new OrganSystemEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.OrganSystemId);
				}
				if(fetchResult)
				{
					newEntity = (OrganSystemEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_organSystemReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.OrganSystem = newEntity;
				_alreadyFetchedOrganSystem = fetchResult;
			}
			return _organSystem;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("OrganSystem", _organSystem);
			toReturn.Add("OrganSystemOrgans", _organSystemOrgans);
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
		/// <param name="licenseOrganSystemId">PK value for LicenseOrganSystem which data should be fetched into this LicenseOrganSystem object</param>
		/// <param name="validator">The validator object for this LicenseOrganSystemEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int16 licenseOrganSystemId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(licenseOrganSystemId, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{

			_organSystemOrgans = new EPICCentralDL.CollectionClasses.OrganSystemOrganCollection();
			_organSystemOrgans.SetContainingEntityInfo(this, "LicenseOrganSystem");
			_organSystemReturnsNewIfNotFound = false;
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
			_fieldsCustomProperties.Add("LicenseOrganSystemId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("LicenseMode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("OrganSystemId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ReportOrder", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organSystem</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganSystem(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _organSystem, new PropertyChangedEventHandler( OnOrganSystemPropertyChanged ), "OrganSystem", EPICCentralDL.RelationClasses.StaticLicenseOrganSystemRelations.OrganSystemEntityUsingOrganSystemIdStatic, true, signalRelatedEntity, "LicenseOrganSystems", resetFKFields, new int[] { (int)LicenseOrganSystemFieldIndex.OrganSystemId } );		
			_organSystem = null;
		}
		
		/// <summary> setups the sync logic for member _organSystem</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganSystem(IEntityCore relatedEntity)
		{
			if(_organSystem!=relatedEntity)
			{		
				DesetupSyncOrganSystem(true, true);
				_organSystem = (OrganSystemEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _organSystem, new PropertyChangedEventHandler( OnOrganSystemPropertyChanged ), "OrganSystem", EPICCentralDL.RelationClasses.StaticLicenseOrganSystemRelations.OrganSystemEntityUsingOrganSystemIdStatic, true, ref _alreadyFetchedOrganSystem, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganSystemPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="licenseOrganSystemId">PK value for LicenseOrganSystem which data should be fetched into this LicenseOrganSystem object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int16 licenseOrganSystemId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)LicenseOrganSystemFieldIndex.LicenseOrganSystemId].ForcedCurrentValueWrite(licenseOrganSystemId);
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
			return DAOFactory.CreateLicenseOrganSystemDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new LicenseOrganSystemEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static LicenseOrganSystemRelations Relations
		{
			get	{ return new LicenseOrganSystemRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'OrganSystemOrgan' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathOrganSystemOrgans
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.OrganSystemOrganCollection(), (IEntityRelation)GetRelationsForField("OrganSystemOrgans")[0], (int)EPICCentralDL.EntityType.LicenseOrganSystemEntity, (int)EPICCentralDL.EntityType.OrganSystemOrganEntity, 0, null, null, null, "OrganSystemOrgans", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'OrganSystem'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathOrganSystem
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.OrganSystemCollection(), (IEntityRelation)GetRelationsForField("OrganSystem")[0], (int)EPICCentralDL.EntityType.LicenseOrganSystemEntity, (int)EPICCentralDL.EntityType.OrganSystemEntity, 0, null, null, null, "OrganSystem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The LicenseOrganSystemId property of the Entity LicenseOrganSystem<br/><br/></summary>
		/// <remarks>Mapped on  table field: "LicenseOrganSystem"."LicenseOrganSystemId"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int16 LicenseOrganSystemId
		{
			get { return (System.Int16)GetValue((int)LicenseOrganSystemFieldIndex.LicenseOrganSystemId, true); }
			set	{ SetValue((int)LicenseOrganSystemFieldIndex.LicenseOrganSystemId, value, true); }
		}

		/// <summary> The LicenseMode property of the Entity LicenseOrganSystem<br/><br/></summary>
		/// <remarks>Mapped on  table field: "LicenseOrganSystem"."LicenseMode"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual EPICCentralDL.Customization.LicenseMode LicenseMode
		{
			get { return (EPICCentralDL.Customization.LicenseMode)GetValue((int)LicenseOrganSystemFieldIndex.LicenseMode, true); }
			set	{ SetValue((int)LicenseOrganSystemFieldIndex.LicenseMode, value, true); }
		}

		/// <summary> The OrganSystemId property of the Entity LicenseOrganSystem<br/><br/></summary>
		/// <remarks>Mapped on  table field: "LicenseOrganSystem"."OrganSystemId"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 OrganSystemId
		{
			get { return (System.Int16)GetValue((int)LicenseOrganSystemFieldIndex.OrganSystemId, true); }
			set	{ SetValue((int)LicenseOrganSystemFieldIndex.OrganSystemId, value, true); }
		}

		/// <summary> The ReportOrder property of the Entity LicenseOrganSystem<br/><br/></summary>
		/// <remarks>Mapped on  table field: "LicenseOrganSystem"."ReportOrder"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 ReportOrder
		{
			get { return (System.Int16)GetValue((int)LicenseOrganSystemFieldIndex.ReportOrder, true); }
			set	{ SetValue((int)LicenseOrganSystemFieldIndex.ReportOrder, value, true); }
		}

		/// <summary> Retrieves all related entities of type 'OrganSystemOrganEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiOrganSystemOrgans()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.OrganSystemOrganCollection OrganSystemOrgans
		{
			get	{ return GetMultiOrganSystemOrgans(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for OrganSystemOrgans. When set to true, OrganSystemOrgans is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time OrganSystemOrgans is accessed. You can always execute/ a forced fetch by calling GetMultiOrganSystemOrgans(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchOrganSystemOrgans
		{
			get	{ return _alwaysFetchOrganSystemOrgans; }
			set	{ _alwaysFetchOrganSystemOrgans = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property OrganSystemOrgans already has been fetched. Setting this property to false when OrganSystemOrgans has been fetched
		/// will clear the OrganSystemOrgans collection well. Setting this property to true while OrganSystemOrgans hasn't been fetched disables lazy loading for OrganSystemOrgans</summary>
		[Browsable(false)]
		public bool AlreadyFetchedOrganSystemOrgans
		{
			get { return _alreadyFetchedOrganSystemOrgans;}
			set 
			{
				if(_alreadyFetchedOrganSystemOrgans && !value && (_organSystemOrgans != null))
				{
					_organSystemOrgans.Clear();
				}
				_alreadyFetchedOrganSystemOrgans = value;
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganSystemEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleOrganSystem()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual OrganSystemEntity OrganSystem
		{
			get	{ return GetSingleOrganSystem(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncOrganSystem(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "LicenseOrganSystems", "OrganSystem", _organSystem, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for OrganSystem. When set to true, OrganSystem is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time OrganSystem is accessed. You can always execute a forced fetch by calling GetSingleOrganSystem(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchOrganSystem
		{
			get	{ return _alwaysFetchOrganSystem; }
			set	{ _alwaysFetchOrganSystem = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property OrganSystem already has been fetched. Setting this property to false when OrganSystem has been fetched
		/// will set OrganSystem to null as well. Setting this property to true while OrganSystem hasn't been fetched disables lazy loading for OrganSystem</summary>
		[Browsable(false)]
		public bool AlreadyFetchedOrganSystem
		{
			get { return _alreadyFetchedOrganSystem;}
			set 
			{
				if(_alreadyFetchedOrganSystem && !value)
				{
					this.OrganSystem = null;
				}
				_alreadyFetchedOrganSystem = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property OrganSystem is not found
		/// in the database. When set to true, OrganSystem will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: false.</summary>
		[Browsable(false)]
		public bool OrganSystemReturnsNewIfNotFound
		{
			get	{ return _organSystemReturnsNewIfNotFound; }
			set { _organSystemReturnsNewIfNotFound = value; }	
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
			get { return (int)EPICCentralDL.EntityType.LicenseOrganSystemEntity; }
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
