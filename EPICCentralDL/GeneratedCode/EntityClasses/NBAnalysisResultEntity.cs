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

	/// <summary>Entity class which represents the entity 'NBAnalysisResult'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class NBAnalysisResultEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private OrganSystemEntity _organSystem;
		private bool	_alwaysFetchOrganSystem, _alreadyFetchedOrganSystem, _organSystemReturnsNewIfNotFound;
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
			/// <summary>Member name OrganSystem</summary>
			public static readonly string OrganSystem = "OrganSystem";
			/// <summary>Member name Treatment</summary>
			public static readonly string Treatment = "Treatment";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static NBAnalysisResultEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public NBAnalysisResultEntity() :base("NBAnalysisResultEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="nBAnalysisResultId">PK value for NBAnalysisResult which data should be fetched into this NBAnalysisResult object</param>
		public NBAnalysisResultEntity(System.Int64 nBAnalysisResultId):base("NBAnalysisResultEntity")
		{
			InitClassFetch(nBAnalysisResultId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="nBAnalysisResultId">PK value for NBAnalysisResult which data should be fetched into this NBAnalysisResult object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public NBAnalysisResultEntity(System.Int64 nBAnalysisResultId, IPrefetchPath prefetchPathToUse):base("NBAnalysisResultEntity")
		{
			InitClassFetch(nBAnalysisResultId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="nBAnalysisResultId">PK value for NBAnalysisResult which data should be fetched into this NBAnalysisResult object</param>
		/// <param name="validator">The custom validator object for this NBAnalysisResultEntity</param>
		public NBAnalysisResultEntity(System.Int64 nBAnalysisResultId, IValidator validator):base("NBAnalysisResultEntity")
		{
			InitClassFetch(nBAnalysisResultId, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected NBAnalysisResultEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_organSystem = (OrganSystemEntity)info.GetValue("_organSystem", typeof(OrganSystemEntity));
			if(_organSystem!=null)
			{
				_organSystem.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_organSystemReturnsNewIfNotFound = info.GetBoolean("_organSystemReturnsNewIfNotFound");
			_alwaysFetchOrganSystem = info.GetBoolean("_alwaysFetchOrganSystem");
			_alreadyFetchedOrganSystem = info.GetBoolean("_alreadyFetchedOrganSystem");

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
			switch((NBAnalysisResultFieldIndex)fieldIndex)
			{
				case NBAnalysisResultFieldIndex.TreatmentId:
					DesetupSyncTreatment(true, false);
					_alreadyFetchedTreatment = false;
					break;
				case NBAnalysisResultFieldIndex.OrganSystemId:
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
			_alreadyFetchedOrganSystem = (_organSystem != null);
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
				case "OrganSystem":
					toReturn.Add(Relations.OrganSystemEntityUsingOrganSystemId);
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
			info.AddValue("_organSystem", (!this.MarkedForDeletion?_organSystem:null));
			info.AddValue("_organSystemReturnsNewIfNotFound", _organSystemReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchOrganSystem", _alwaysFetchOrganSystem);
			info.AddValue("_alreadyFetchedOrganSystem", _alreadyFetchedOrganSystem);
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
				case "OrganSystem":
					_alreadyFetchedOrganSystem = true;
					this.OrganSystem = (OrganSystemEntity)entity;
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
				case "OrganSystem":
					SetupSyncOrganSystem(relatedEntity);
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
				case "OrganSystem":
					DesetupSyncOrganSystem(false, true);
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
			if(_organSystem!=null)
			{
				toReturn.Add(_organSystem);
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
		/// <param name="nBAnalysisResultId">PK value for NBAnalysisResult which data should be fetched into this NBAnalysisResult object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 nBAnalysisResultId)
		{
			return FetchUsingPK(nBAnalysisResultId, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="nBAnalysisResultId">PK value for NBAnalysisResult which data should be fetched into this NBAnalysisResult object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 nBAnalysisResultId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(nBAnalysisResultId, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="nBAnalysisResultId">PK value for NBAnalysisResult which data should be fetched into this NBAnalysisResult object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 nBAnalysisResultId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(nBAnalysisResultId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="nBAnalysisResultId">PK value for NBAnalysisResult which data should be fetched into this NBAnalysisResult object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 nBAnalysisResultId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(nBAnalysisResultId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.NBAnalysisResultId, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new NBAnalysisResultRelations().GetAllRelations();
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
			toReturn.Add("OrganSystem", _organSystem);
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
		/// <param name="nBAnalysisResultId">PK value for NBAnalysisResult which data should be fetched into this NBAnalysisResult object</param>
		/// <param name="validator">The validator object for this NBAnalysisResultEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int64 nBAnalysisResultId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(nBAnalysisResultId, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
			_organSystemReturnsNewIfNotFound = false;
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
			_fieldsCustomProperties.Add("NBAnalysisResultId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("TreatmentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("OrganSystemId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ResultScoreFiltered", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ResultScoreUnfiltered", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ProbabilityFiltered", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ProbabilityUnfiltered", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organSystem</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganSystem(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _organSystem, new PropertyChangedEventHandler( OnOrganSystemPropertyChanged ), "OrganSystem", EPICCentralDL.RelationClasses.StaticNBAnalysisResultRelations.OrganSystemEntityUsingOrganSystemIdStatic, true, signalRelatedEntity, "NBAnalysisResults", resetFKFields, new int[] { (int)NBAnalysisResultFieldIndex.OrganSystemId } );		
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
				this.PerformSetupSyncRelatedEntity( _organSystem, new PropertyChangedEventHandler( OnOrganSystemPropertyChanged ), "OrganSystem", EPICCentralDL.RelationClasses.StaticNBAnalysisResultRelations.OrganSystemEntityUsingOrganSystemIdStatic, true, ref _alreadyFetchedOrganSystem, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _treatment</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTreatment(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _treatment, new PropertyChangedEventHandler( OnTreatmentPropertyChanged ), "Treatment", EPICCentralDL.RelationClasses.StaticNBAnalysisResultRelations.TreatmentEntityUsingTreatmentIdStatic, true, signalRelatedEntity, "NBAnalysisResults", resetFKFields, new int[] { (int)NBAnalysisResultFieldIndex.TreatmentId } );		
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
				this.PerformSetupSyncRelatedEntity( _treatment, new PropertyChangedEventHandler( OnTreatmentPropertyChanged ), "Treatment", EPICCentralDL.RelationClasses.StaticNBAnalysisResultRelations.TreatmentEntityUsingTreatmentIdStatic, true, ref _alreadyFetchedTreatment, new string[] {  } );
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
		/// <param name="nBAnalysisResultId">PK value for NBAnalysisResult which data should be fetched into this NBAnalysisResult object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int64 nBAnalysisResultId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)NBAnalysisResultFieldIndex.NBAnalysisResultId].ForcedCurrentValueWrite(nBAnalysisResultId);
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
			return DAOFactory.CreateNBAnalysisResultDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new NBAnalysisResultEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static NBAnalysisResultRelations Relations
		{
			get	{ return new NBAnalysisResultRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'OrganSystem'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathOrganSystem
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.OrganSystemCollection(), (IEntityRelation)GetRelationsForField("OrganSystem")[0], (int)EPICCentralDL.EntityType.NBAnalysisResultEntity, (int)EPICCentralDL.EntityType.OrganSystemEntity, 0, null, null, null, "OrganSystem", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Treatment'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathTreatment
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.TreatmentCollection(), (IEntityRelation)GetRelationsForField("Treatment")[0], (int)EPICCentralDL.EntityType.NBAnalysisResultEntity, (int)EPICCentralDL.EntityType.TreatmentEntity, 0, null, null, null, "Treatment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The NBAnalysisResultId property of the Entity NBAnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "NBAnalysisResult"."NBAnalysisResultId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 NBAnalysisResultId
		{
			get { return (System.Int64)GetValue((int)NBAnalysisResultFieldIndex.NBAnalysisResultId, true); }
			set	{ SetValue((int)NBAnalysisResultFieldIndex.NBAnalysisResultId, value, true); }
		}

		/// <summary> The TreatmentId property of the Entity NBAnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "NBAnalysisResult"."TreatmentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TreatmentId
		{
			get { return (System.Int64)GetValue((int)NBAnalysisResultFieldIndex.TreatmentId, true); }
			set	{ SetValue((int)NBAnalysisResultFieldIndex.TreatmentId, value, true); }
		}

		/// <summary> The OrganSystemId property of the Entity NBAnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "NBAnalysisResult"."OrganSystemId"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int16 OrganSystemId
		{
			get { return (System.Int16)GetValue((int)NBAnalysisResultFieldIndex.OrganSystemId, true); }
			set	{ SetValue((int)NBAnalysisResultFieldIndex.OrganSystemId, value, true); }
		}

		/// <summary> The ResultScoreFiltered property of the Entity NBAnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "NBAnalysisResult"."ResultScoreFiltered"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal ResultScoreFiltered
		{
			get { return (System.Decimal)GetValue((int)NBAnalysisResultFieldIndex.ResultScoreFiltered, true); }
			set	{ SetValue((int)NBAnalysisResultFieldIndex.ResultScoreFiltered, value, true); }
		}

		/// <summary> The ResultScoreUnfiltered property of the Entity NBAnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "NBAnalysisResult"."ResultScoreUnfiltered"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal ResultScoreUnfiltered
		{
			get { return (System.Decimal)GetValue((int)NBAnalysisResultFieldIndex.ResultScoreUnfiltered, true); }
			set	{ SetValue((int)NBAnalysisResultFieldIndex.ResultScoreUnfiltered, value, true); }
		}

		/// <summary> The ProbabilityFiltered property of the Entity NBAnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "NBAnalysisResult"."ProbabilityFiltered"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal ProbabilityFiltered
		{
			get { return (System.Decimal)GetValue((int)NBAnalysisResultFieldIndex.ProbabilityFiltered, true); }
			set	{ SetValue((int)NBAnalysisResultFieldIndex.ProbabilityFiltered, value, true); }
		}

		/// <summary> The ProbabilityUnfiltered property of the Entity NBAnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "NBAnalysisResult"."ProbabilityUnfiltered"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal ProbabilityUnfiltered
		{
			get { return (System.Decimal)GetValue((int)NBAnalysisResultFieldIndex.ProbabilityUnfiltered, true); }
			set	{ SetValue((int)NBAnalysisResultFieldIndex.ProbabilityUnfiltered, value, true); }
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
					SetSingleRelatedEntityNavigator(value, "NBAnalysisResults", "OrganSystem", _organSystem, true); 
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
					SetSingleRelatedEntityNavigator(value, "NBAnalysisResults", "Treatment", _treatment, true); 
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
			get { return (int)EPICCentralDL.EntityType.NBAnalysisResultEntity; }
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
