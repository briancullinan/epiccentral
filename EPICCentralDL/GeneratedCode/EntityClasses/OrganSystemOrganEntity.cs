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

	/// <summary>Entity class which represents the entity 'OrganSystemOrgan'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class OrganSystemOrganEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private LicenseOrganSystemEntity _licenseOrganSystem;
		private bool	_alwaysFetchLicenseOrganSystem, _alreadyFetchedLicenseOrganSystem, _licenseOrganSystemReturnsNewIfNotFound;
		private OrganEntity _organ;
		private bool	_alwaysFetchOrgan, _alreadyFetchedOrgan, _organReturnsNewIfNotFound;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name LicenseOrganSystem</summary>
			public static readonly string LicenseOrganSystem = "LicenseOrganSystem";
			/// <summary>Member name Organ</summary>
			public static readonly string Organ = "Organ";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static OrganSystemOrganEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public OrganSystemOrganEntity() :base("OrganSystemOrganEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="organId">PK value for OrganSystemOrgan which data should be fetched into this OrganSystemOrgan object</param>
		/// <param name="licenseOrganSystemId">PK value for OrganSystemOrgan which data should be fetched into this OrganSystemOrgan object</param>
		public OrganSystemOrganEntity(System.Int16 organId, System.Int16 licenseOrganSystemId):base("OrganSystemOrganEntity")
		{
			InitClassFetch(organId, licenseOrganSystemId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="organId">PK value for OrganSystemOrgan which data should be fetched into this OrganSystemOrgan object</param>
		/// <param name="licenseOrganSystemId">PK value for OrganSystemOrgan which data should be fetched into this OrganSystemOrgan object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public OrganSystemOrganEntity(System.Int16 organId, System.Int16 licenseOrganSystemId, IPrefetchPath prefetchPathToUse):base("OrganSystemOrganEntity")
		{
			InitClassFetch(organId, licenseOrganSystemId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="organId">PK value for OrganSystemOrgan which data should be fetched into this OrganSystemOrgan object</param>
		/// <param name="licenseOrganSystemId">PK value for OrganSystemOrgan which data should be fetched into this OrganSystemOrgan object</param>
		/// <param name="validator">The custom validator object for this OrganSystemOrganEntity</param>
		public OrganSystemOrganEntity(System.Int16 organId, System.Int16 licenseOrganSystemId, IValidator validator):base("OrganSystemOrganEntity")
		{
			InitClassFetch(organId, licenseOrganSystemId, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected OrganSystemOrganEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_licenseOrganSystem = (LicenseOrganSystemEntity)info.GetValue("_licenseOrganSystem", typeof(LicenseOrganSystemEntity));
			if(_licenseOrganSystem!=null)
			{
				_licenseOrganSystem.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_licenseOrganSystemReturnsNewIfNotFound = info.GetBoolean("_licenseOrganSystemReturnsNewIfNotFound");
			_alwaysFetchLicenseOrganSystem = info.GetBoolean("_alwaysFetchLicenseOrganSystem");
			_alreadyFetchedLicenseOrganSystem = info.GetBoolean("_alreadyFetchedLicenseOrganSystem");

			_organ = (OrganEntity)info.GetValue("_organ", typeof(OrganEntity));
			if(_organ!=null)
			{
				_organ.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_organReturnsNewIfNotFound = info.GetBoolean("_organReturnsNewIfNotFound");
			_alwaysFetchOrgan = info.GetBoolean("_alwaysFetchOrgan");
			_alreadyFetchedOrgan = info.GetBoolean("_alreadyFetchedOrgan");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		
		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((OrganSystemOrganFieldIndex)fieldIndex)
			{
				case OrganSystemOrganFieldIndex.OrganId:
					DesetupSyncOrgan(true, false);
					_alreadyFetchedOrgan = false;
					break;
				case OrganSystemOrganFieldIndex.LicenseOrganSystemId:
					DesetupSyncLicenseOrganSystem(true, false);
					_alreadyFetchedLicenseOrganSystem = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedLicenseOrganSystem = (_licenseOrganSystem != null);
			_alreadyFetchedOrgan = (_organ != null);
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
				case "LicenseOrganSystem":
					toReturn.Add(Relations.LicenseOrganSystemEntityUsingLicenseOrganSystemId);
					break;
				case "Organ":
					toReturn.Add(Relations.OrganEntityUsingOrganId);
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
			info.AddValue("_licenseOrganSystem", (!this.MarkedForDeletion?_licenseOrganSystem:null));
			info.AddValue("_licenseOrganSystemReturnsNewIfNotFound", _licenseOrganSystemReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchLicenseOrganSystem", _alwaysFetchLicenseOrganSystem);
			info.AddValue("_alreadyFetchedLicenseOrganSystem", _alreadyFetchedLicenseOrganSystem);
			info.AddValue("_organ", (!this.MarkedForDeletion?_organ:null));
			info.AddValue("_organReturnsNewIfNotFound", _organReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchOrgan", _alwaysFetchOrgan);
			info.AddValue("_alreadyFetchedOrgan", _alreadyFetchedOrgan);

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
				case "LicenseOrganSystem":
					_alreadyFetchedLicenseOrganSystem = true;
					this.LicenseOrganSystem = (LicenseOrganSystemEntity)entity;
					break;
				case "Organ":
					_alreadyFetchedOrgan = true;
					this.Organ = (OrganEntity)entity;
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
				case "LicenseOrganSystem":
					SetupSyncLicenseOrganSystem(relatedEntity);
					break;
				case "Organ":
					SetupSyncOrgan(relatedEntity);
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
				case "LicenseOrganSystem":
					DesetupSyncLicenseOrganSystem(false, true);
					break;
				case "Organ":
					DesetupSyncOrgan(false, true);
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
			if(_licenseOrganSystem!=null)
			{
				toReturn.Add(_licenseOrganSystem);
			}
			if(_organ!=null)
			{
				toReturn.Add(_organ);
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
		/// <param name="organId">PK value for OrganSystemOrgan which data should be fetched into this OrganSystemOrgan object</param>
		/// <param name="licenseOrganSystemId">PK value for OrganSystemOrgan which data should be fetched into this OrganSystemOrgan object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int16 organId, System.Int16 licenseOrganSystemId)
		{
			return FetchUsingPK(organId, licenseOrganSystemId, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="organId">PK value for OrganSystemOrgan which data should be fetched into this OrganSystemOrgan object</param>
		/// <param name="licenseOrganSystemId">PK value for OrganSystemOrgan which data should be fetched into this OrganSystemOrgan object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int16 organId, System.Int16 licenseOrganSystemId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(organId, licenseOrganSystemId, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="organId">PK value for OrganSystemOrgan which data should be fetched into this OrganSystemOrgan object</param>
		/// <param name="licenseOrganSystemId">PK value for OrganSystemOrgan which data should be fetched into this OrganSystemOrgan object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int16 organId, System.Int16 licenseOrganSystemId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(organId, licenseOrganSystemId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="organId">PK value for OrganSystemOrgan which data should be fetched into this OrganSystemOrgan object</param>
		/// <param name="licenseOrganSystemId">PK value for OrganSystemOrgan which data should be fetched into this OrganSystemOrgan object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int16 organId, System.Int16 licenseOrganSystemId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(organId, licenseOrganSystemId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.OrganId, this.LicenseOrganSystemId, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new OrganSystemOrganRelations().GetAllRelations();
		}

		/// <summary> Retrieves the related entity of type 'LicenseOrganSystemEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'LicenseOrganSystemEntity' which is related to this entity.</returns>
		public LicenseOrganSystemEntity GetSingleLicenseOrganSystem()
		{
			return GetSingleLicenseOrganSystem(false);
		}

		/// <summary> Retrieves the related entity of type 'LicenseOrganSystemEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'LicenseOrganSystemEntity' which is related to this entity.</returns>
		public virtual LicenseOrganSystemEntity GetSingleLicenseOrganSystem(bool forceFetch)
		{
			if( ( !_alreadyFetchedLicenseOrganSystem || forceFetch || _alwaysFetchLicenseOrganSystem) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.LicenseOrganSystemEntityUsingLicenseOrganSystemId);
				LicenseOrganSystemEntity newEntity = new LicenseOrganSystemEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.LicenseOrganSystemId);
				}
				if(fetchResult)
				{
					newEntity = (LicenseOrganSystemEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_licenseOrganSystemReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.LicenseOrganSystem = newEntity;
				_alreadyFetchedLicenseOrganSystem = fetchResult;
			}
			return _licenseOrganSystem;
		}


		/// <summary> Retrieves the related entity of type 'OrganEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'OrganEntity' which is related to this entity.</returns>
		public OrganEntity GetSingleOrgan()
		{
			return GetSingleOrgan(false);
		}

		/// <summary> Retrieves the related entity of type 'OrganEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'OrganEntity' which is related to this entity.</returns>
		public virtual OrganEntity GetSingleOrgan(bool forceFetch)
		{
			if( ( !_alreadyFetchedOrgan || forceFetch || _alwaysFetchOrgan) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.OrganEntityUsingOrganId);
				OrganEntity newEntity = new OrganEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.OrganId);
				}
				if(fetchResult)
				{
					newEntity = (OrganEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_organReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.Organ = newEntity;
				_alreadyFetchedOrgan = fetchResult;
			}
			return _organ;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("LicenseOrganSystem", _licenseOrganSystem);
			toReturn.Add("Organ", _organ);
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
		/// <param name="organId">PK value for OrganSystemOrgan which data should be fetched into this OrganSystemOrgan object</param>
		/// <param name="licenseOrganSystemId">PK value for OrganSystemOrgan which data should be fetched into this OrganSystemOrgan object</param>
		/// <param name="validator">The validator object for this OrganSystemOrganEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int16 organId, System.Int16 licenseOrganSystemId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(organId, licenseOrganSystemId, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
			_licenseOrganSystemReturnsNewIfNotFound = false;
			_organReturnsNewIfNotFound = false;
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
			_fieldsCustomProperties.Add("OrganId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("LicenseOrganSystemId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ReportOrder", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _licenseOrganSystem</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLicenseOrganSystem(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _licenseOrganSystem, new PropertyChangedEventHandler( OnLicenseOrganSystemPropertyChanged ), "LicenseOrganSystem", EPICCentralDL.RelationClasses.StaticOrganSystemOrganRelations.LicenseOrganSystemEntityUsingLicenseOrganSystemIdStatic, true, signalRelatedEntity, "OrganSystemOrgans", resetFKFields, new int[] { (int)OrganSystemOrganFieldIndex.LicenseOrganSystemId } );		
			_licenseOrganSystem = null;
		}
		
		/// <summary> setups the sync logic for member _licenseOrganSystem</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLicenseOrganSystem(IEntityCore relatedEntity)
		{
			if(_licenseOrganSystem!=relatedEntity)
			{		
				DesetupSyncLicenseOrganSystem(true, true);
				_licenseOrganSystem = (LicenseOrganSystemEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _licenseOrganSystem, new PropertyChangedEventHandler( OnLicenseOrganSystemPropertyChanged ), "LicenseOrganSystem", EPICCentralDL.RelationClasses.StaticOrganSystemOrganRelations.LicenseOrganSystemEntityUsingLicenseOrganSystemIdStatic, true, ref _alreadyFetchedLicenseOrganSystem, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLicenseOrganSystemPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organ</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrgan(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _organ, new PropertyChangedEventHandler( OnOrganPropertyChanged ), "Organ", EPICCentralDL.RelationClasses.StaticOrganSystemOrganRelations.OrganEntityUsingOrganIdStatic, true, signalRelatedEntity, "OrganSystemOrgans", resetFKFields, new int[] { (int)OrganSystemOrganFieldIndex.OrganId } );		
			_organ = null;
		}
		
		/// <summary> setups the sync logic for member _organ</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrgan(IEntityCore relatedEntity)
		{
			if(_organ!=relatedEntity)
			{		
				DesetupSyncOrgan(true, true);
				_organ = (OrganEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _organ, new PropertyChangedEventHandler( OnOrganPropertyChanged ), "Organ", EPICCentralDL.RelationClasses.StaticOrganSystemOrganRelations.OrganEntityUsingOrganIdStatic, true, ref _alreadyFetchedOrgan, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="organId">PK value for OrganSystemOrgan which data should be fetched into this OrganSystemOrgan object</param>
		/// <param name="licenseOrganSystemId">PK value for OrganSystemOrgan which data should be fetched into this OrganSystemOrgan object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int16 organId, System.Int16 licenseOrganSystemId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)OrganSystemOrganFieldIndex.OrganId].ForcedCurrentValueWrite(organId);
				this.Fields[(int)OrganSystemOrganFieldIndex.LicenseOrganSystemId].ForcedCurrentValueWrite(licenseOrganSystemId);
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
			return DAOFactory.CreateOrganSystemOrganDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new OrganSystemOrganEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static OrganSystemOrganRelations Relations
		{
			get	{ return new OrganSystemOrganRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'LicenseOrganSystem'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathLicenseOrganSystem
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.LicenseOrganSystemCollection(), (IEntityRelation)GetRelationsForField("LicenseOrganSystem")[0], (int)EPICCentralDL.EntityType.OrganSystemOrganEntity, (int)EPICCentralDL.EntityType.LicenseOrganSystemEntity, 0, null, null, null, "LicenseOrganSystem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Organ'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathOrgan
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.OrganCollection(), (IEntityRelation)GetRelationsForField("Organ")[0], (int)EPICCentralDL.EntityType.OrganSystemOrganEntity, (int)EPICCentralDL.EntityType.OrganEntity, 0, null, null, null, "Organ", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The OrganId property of the Entity OrganSystemOrgan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "OrganSystemOrgan"."OrganId"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int16 OrganId
		{
			get { return (System.Int16)GetValue((int)OrganSystemOrganFieldIndex.OrganId, true); }
			set	{ SetValue((int)OrganSystemOrganFieldIndex.OrganId, value, true); }
		}

		/// <summary> The LicenseOrganSystemId property of the Entity OrganSystemOrgan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "OrganSystemOrgan"."LicenseOrganSystemId"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int16 LicenseOrganSystemId
		{
			get { return (System.Int16)GetValue((int)OrganSystemOrganFieldIndex.LicenseOrganSystemId, true); }
			set	{ SetValue((int)OrganSystemOrganFieldIndex.LicenseOrganSystemId, value, true); }
		}

		/// <summary> The ReportOrder property of the Entity OrganSystemOrgan<br/><br/></summary>
		/// <remarks>Mapped on  table field: "OrganSystemOrgan"."ReportOrder"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 ReportOrder
		{
			get { return (System.Int16)GetValue((int)OrganSystemOrganFieldIndex.ReportOrder, true); }
			set	{ SetValue((int)OrganSystemOrganFieldIndex.ReportOrder, value, true); }
		}


		/// <summary> Gets / sets related entity of type 'LicenseOrganSystemEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleLicenseOrganSystem()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual LicenseOrganSystemEntity LicenseOrganSystem
		{
			get	{ return GetSingleLicenseOrganSystem(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncLicenseOrganSystem(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "OrganSystemOrgans", "LicenseOrganSystem", _licenseOrganSystem, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for LicenseOrganSystem. When set to true, LicenseOrganSystem is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time LicenseOrganSystem is accessed. You can always execute a forced fetch by calling GetSingleLicenseOrganSystem(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchLicenseOrganSystem
		{
			get	{ return _alwaysFetchLicenseOrganSystem; }
			set	{ _alwaysFetchLicenseOrganSystem = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property LicenseOrganSystem already has been fetched. Setting this property to false when LicenseOrganSystem has been fetched
		/// will set LicenseOrganSystem to null as well. Setting this property to true while LicenseOrganSystem hasn't been fetched disables lazy loading for LicenseOrganSystem</summary>
		[Browsable(false)]
		public bool AlreadyFetchedLicenseOrganSystem
		{
			get { return _alreadyFetchedLicenseOrganSystem;}
			set 
			{
				if(_alreadyFetchedLicenseOrganSystem && !value)
				{
					this.LicenseOrganSystem = null;
				}
				_alreadyFetchedLicenseOrganSystem = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property LicenseOrganSystem is not found
		/// in the database. When set to true, LicenseOrganSystem will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: false.</summary>
		[Browsable(false)]
		public bool LicenseOrganSystemReturnsNewIfNotFound
		{
			get	{ return _licenseOrganSystemReturnsNewIfNotFound; }
			set { _licenseOrganSystemReturnsNewIfNotFound = value; }	
		}

		/// <summary> Gets / sets related entity of type 'OrganEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleOrgan()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual OrganEntity Organ
		{
			get	{ return GetSingleOrgan(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncOrgan(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "OrganSystemOrgans", "Organ", _organ, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Organ. When set to true, Organ is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Organ is accessed. You can always execute a forced fetch by calling GetSingleOrgan(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchOrgan
		{
			get	{ return _alwaysFetchOrgan; }
			set	{ _alwaysFetchOrgan = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property Organ already has been fetched. Setting this property to false when Organ has been fetched
		/// will set Organ to null as well. Setting this property to true while Organ hasn't been fetched disables lazy loading for Organ</summary>
		[Browsable(false)]
		public bool AlreadyFetchedOrgan
		{
			get { return _alreadyFetchedOrgan;}
			set 
			{
				if(_alreadyFetchedOrgan && !value)
				{
					this.Organ = null;
				}
				_alreadyFetchedOrgan = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Organ is not found
		/// in the database. When set to true, Organ will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: false.</summary>
		[Browsable(false)]
		public bool OrganReturnsNewIfNotFound
		{
			get	{ return _organReturnsNewIfNotFound; }
			set { _organReturnsNewIfNotFound = value; }	
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
			get { return (int)EPICCentralDL.EntityType.OrganSystemOrganEntity; }
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
