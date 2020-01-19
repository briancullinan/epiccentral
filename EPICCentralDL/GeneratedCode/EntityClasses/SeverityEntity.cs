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

	/// <summary>Entity class which represents the entity 'Severity'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class SeverityEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private OrganEntity _organ;
		private bool	_alwaysFetchOrgan, _alreadyFetchedOrgan, _organReturnsNewIfNotFound;
		private TreatmentEntity _treatment;
		private bool	_alwaysFetchTreatment, _alreadyFetchedTreatment, _treatmentReturnsNewIfNotFound;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Organ</summary>
			public static readonly string Organ = "Organ";
			/// <summary>Member name Treatment</summary>
			public static readonly string Treatment = "Treatment";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static SeverityEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public SeverityEntity() :base("SeverityEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="severityId">PK value for Severity which data should be fetched into this Severity object</param>
		public SeverityEntity(System.Int64 severityId):base("SeverityEntity")
		{
			InitClassFetch(severityId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="severityId">PK value for Severity which data should be fetched into this Severity object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public SeverityEntity(System.Int64 severityId, IPrefetchPath prefetchPathToUse):base("SeverityEntity")
		{
			InitClassFetch(severityId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="severityId">PK value for Severity which data should be fetched into this Severity object</param>
		/// <param name="validator">The custom validator object for this SeverityEntity</param>
		public SeverityEntity(System.Int64 severityId, IValidator validator):base("SeverityEntity")
		{
			InitClassFetch(severityId, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected SeverityEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_organ = (OrganEntity)info.GetValue("_organ", typeof(OrganEntity));
			if(_organ!=null)
			{
				_organ.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_organReturnsNewIfNotFound = info.GetBoolean("_organReturnsNewIfNotFound");
			_alwaysFetchOrgan = info.GetBoolean("_alwaysFetchOrgan");
			_alreadyFetchedOrgan = info.GetBoolean("_alreadyFetchedOrgan");

			_treatment = (TreatmentEntity)info.GetValue("_treatment", typeof(TreatmentEntity));
			if(_treatment!=null)
			{
				_treatment.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_treatmentReturnsNewIfNotFound = info.GetBoolean("_treatmentReturnsNewIfNotFound");
			_alwaysFetchTreatment = info.GetBoolean("_alwaysFetchTreatment");
			_alreadyFetchedTreatment = info.GetBoolean("_alreadyFetchedTreatment");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		
		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((SeverityFieldIndex)fieldIndex)
			{
				case SeverityFieldIndex.TreatmentId:
					DesetupSyncTreatment(true, false);
					_alreadyFetchedTreatment = false;
					break;
				case SeverityFieldIndex.OrganId:
					DesetupSyncOrgan(true, false);
					_alreadyFetchedOrgan = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedOrgan = (_organ != null);
			_alreadyFetchedTreatment = (_treatment != null);
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
				case "Organ":
					toReturn.Add(Relations.OrganEntityUsingOrganId);
					break;
				case "Treatment":
					toReturn.Add(Relations.TreatmentEntityUsingTreatmentId);
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
			info.AddValue("_organ", (!this.MarkedForDeletion?_organ:null));
			info.AddValue("_organReturnsNewIfNotFound", _organReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchOrgan", _alwaysFetchOrgan);
			info.AddValue("_alreadyFetchedOrgan", _alreadyFetchedOrgan);
			info.AddValue("_treatment", (!this.MarkedForDeletion?_treatment:null));
			info.AddValue("_treatmentReturnsNewIfNotFound", _treatmentReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchTreatment", _alwaysFetchTreatment);
			info.AddValue("_alreadyFetchedTreatment", _alreadyFetchedTreatment);

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
				case "Organ":
					_alreadyFetchedOrgan = true;
					this.Organ = (OrganEntity)entity;
					break;
				case "Treatment":
					_alreadyFetchedTreatment = true;
					this.Treatment = (TreatmentEntity)entity;
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
				case "Organ":
					SetupSyncOrgan(relatedEntity);
					break;
				case "Treatment":
					SetupSyncTreatment(relatedEntity);
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
				case "Organ":
					DesetupSyncOrgan(false, true);
					break;
				case "Treatment":
					DesetupSyncTreatment(false, true);
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
			if(_organ!=null)
			{
				toReturn.Add(_organ);
			}
			if(_treatment!=null)
			{
				toReturn.Add(_treatment);
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
		/// <param name="severityId">PK value for Severity which data should be fetched into this Severity object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 severityId)
		{
			return FetchUsingPK(severityId, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="severityId">PK value for Severity which data should be fetched into this Severity object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 severityId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(severityId, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="severityId">PK value for Severity which data should be fetched into this Severity object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 severityId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(severityId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="severityId">PK value for Severity which data should be fetched into this Severity object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 severityId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(severityId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.SeverityId, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new SeverityRelations().GetAllRelations();
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


		/// <summary> Retrieves the related entity of type 'TreatmentEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'TreatmentEntity' which is related to this entity.</returns>
		public TreatmentEntity GetSingleTreatment()
		{
			return GetSingleTreatment(false);
		}

		/// <summary> Retrieves the related entity of type 'TreatmentEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'TreatmentEntity' which is related to this entity.</returns>
		public virtual TreatmentEntity GetSingleTreatment(bool forceFetch)
		{
			if( ( !_alreadyFetchedTreatment || forceFetch || _alwaysFetchTreatment) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.TreatmentEntityUsingTreatmentId);
				TreatmentEntity newEntity = new TreatmentEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.TreatmentId);
				}
				if(fetchResult)
				{
					newEntity = (TreatmentEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_treatmentReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.Treatment = newEntity;
				_alreadyFetchedTreatment = fetchResult;
			}
			return _treatment;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Organ", _organ);
			toReturn.Add("Treatment", _treatment);
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
		/// <param name="severityId">PK value for Severity which data should be fetched into this Severity object</param>
		/// <param name="validator">The validator object for this SeverityEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int64 severityId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(severityId, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
			_organReturnsNewIfNotFound = false;
			_treatmentReturnsNewIfNotFound = false;
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
			_fieldsCustomProperties.Add("SeverityId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("TreatmentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("OrganId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("PhysicalRight", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("PhysicalLeft", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("MentalRight", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("MentalLeft", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organ</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrgan(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _organ, new PropertyChangedEventHandler( OnOrganPropertyChanged ), "Organ", EPICCentralDL.RelationClasses.StaticSeverityRelations.OrganEntityUsingOrganIdStatic, true, signalRelatedEntity, "Severities", resetFKFields, new int[] { (int)SeverityFieldIndex.OrganId } );		
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
				this.PerformSetupSyncRelatedEntity( _organ, new PropertyChangedEventHandler( OnOrganPropertyChanged ), "Organ", EPICCentralDL.RelationClasses.StaticSeverityRelations.OrganEntityUsingOrganIdStatic, true, ref _alreadyFetchedOrgan, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _treatment</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTreatment(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _treatment, new PropertyChangedEventHandler( OnTreatmentPropertyChanged ), "Treatment", EPICCentralDL.RelationClasses.StaticSeverityRelations.TreatmentEntityUsingTreatmentIdStatic, true, signalRelatedEntity, "Severities", resetFKFields, new int[] { (int)SeverityFieldIndex.TreatmentId } );		
			_treatment = null;
		}
		
		/// <summary> setups the sync logic for member _treatment</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTreatment(IEntityCore relatedEntity)
		{
			if(_treatment!=relatedEntity)
			{		
				DesetupSyncTreatment(true, true);
				_treatment = (TreatmentEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _treatment, new PropertyChangedEventHandler( OnTreatmentPropertyChanged ), "Treatment", EPICCentralDL.RelationClasses.StaticSeverityRelations.TreatmentEntityUsingTreatmentIdStatic, true, ref _alreadyFetchedTreatment, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTreatmentPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="severityId">PK value for Severity which data should be fetched into this Severity object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int64 severityId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)SeverityFieldIndex.SeverityId].ForcedCurrentValueWrite(severityId);
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
			return DAOFactory.CreateSeverityDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new SeverityEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static SeverityRelations Relations
		{
			get	{ return new SeverityRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Organ'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathOrgan
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.OrganCollection(), (IEntityRelation)GetRelationsForField("Organ")[0], (int)EPICCentralDL.EntityType.SeverityEntity, (int)EPICCentralDL.EntityType.OrganEntity, 0, null, null, null, "Organ", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Treatment'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathTreatment
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.TreatmentCollection(), (IEntityRelation)GetRelationsForField("Treatment")[0], (int)EPICCentralDL.EntityType.SeverityEntity, (int)EPICCentralDL.EntityType.TreatmentEntity, 0, null, null, null, "Treatment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The SeverityId property of the Entity Severity<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Severity"."SeverityId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 SeverityId
		{
			get { return (System.Int64)GetValue((int)SeverityFieldIndex.SeverityId, true); }
			set	{ SetValue((int)SeverityFieldIndex.SeverityId, value, true); }
		}

		/// <summary> The TreatmentId property of the Entity Severity<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Severity"."TreatmentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TreatmentId
		{
			get { return (System.Int64)GetValue((int)SeverityFieldIndex.TreatmentId, true); }
			set	{ SetValue((int)SeverityFieldIndex.TreatmentId, value, true); }
		}

		/// <summary> The OrganId property of the Entity Severity<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Severity"."OrganId"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 OrganId
		{
			get { return (System.Int16)GetValue((int)SeverityFieldIndex.OrganId, true); }
			set	{ SetValue((int)SeverityFieldIndex.OrganId, value, true); }
		}

		/// <summary> The PhysicalRight property of the Entity Severity<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Severity"."PhysicalRight"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> PhysicalRight
		{
			get { return (Nullable<System.Int32>)GetValue((int)SeverityFieldIndex.PhysicalRight, false); }
			set	{ SetValue((int)SeverityFieldIndex.PhysicalRight, value, true); }
		}

		/// <summary> The PhysicalLeft property of the Entity Severity<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Severity"."PhysicalLeft"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> PhysicalLeft
		{
			get { return (Nullable<System.Int32>)GetValue((int)SeverityFieldIndex.PhysicalLeft, false); }
			set	{ SetValue((int)SeverityFieldIndex.PhysicalLeft, value, true); }
		}

		/// <summary> The MentalRight property of the Entity Severity<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Severity"."MentalRight"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> MentalRight
		{
			get { return (Nullable<System.Int32>)GetValue((int)SeverityFieldIndex.MentalRight, false); }
			set	{ SetValue((int)SeverityFieldIndex.MentalRight, value, true); }
		}

		/// <summary> The MentalLeft property of the Entity Severity<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Severity"."MentalLeft"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> MentalLeft
		{
			get { return (Nullable<System.Int32>)GetValue((int)SeverityFieldIndex.MentalLeft, false); }
			set	{ SetValue((int)SeverityFieldIndex.MentalLeft, value, true); }
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
					SetSingleRelatedEntityNavigator(value, "Severities", "Organ", _organ, true); 
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

		/// <summary> Gets / sets related entity of type 'TreatmentEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleTreatment()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual TreatmentEntity Treatment
		{
			get	{ return GetSingleTreatment(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncTreatment(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "Severities", "Treatment", _treatment, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Treatment. When set to true, Treatment is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Treatment is accessed. You can always execute a forced fetch by calling GetSingleTreatment(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchTreatment
		{
			get	{ return _alwaysFetchTreatment; }
			set	{ _alwaysFetchTreatment = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property Treatment already has been fetched. Setting this property to false when Treatment has been fetched
		/// will set Treatment to null as well. Setting this property to true while Treatment hasn't been fetched disables lazy loading for Treatment</summary>
		[Browsable(false)]
		public bool AlreadyFetchedTreatment
		{
			get { return _alreadyFetchedTreatment;}
			set 
			{
				if(_alreadyFetchedTreatment && !value)
				{
					this.Treatment = null;
				}
				_alreadyFetchedTreatment = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Treatment is not found
		/// in the database. When set to true, Treatment will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: false.</summary>
		[Browsable(false)]
		public bool TreatmentReturnsNewIfNotFound
		{
			get	{ return _treatmentReturnsNewIfNotFound; }
			set { _treatmentReturnsNewIfNotFound = value; }	
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
			get { return (int)EPICCentralDL.EntityType.SeverityEntity; }
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
