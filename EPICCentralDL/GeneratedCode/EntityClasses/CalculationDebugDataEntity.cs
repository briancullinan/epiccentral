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

	/// <summary>Entity class which represents the entity 'CalculationDebugData'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CalculationDebugDataEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
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
			/// <summary>Member name Treatment</summary>
			public static readonly string Treatment = "Treatment";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CalculationDebugDataEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public CalculationDebugDataEntity() :base("CalculationDebugDataEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="calculationDebugDataId">PK value for CalculationDebugData which data should be fetched into this CalculationDebugData object</param>
		public CalculationDebugDataEntity(System.Int64 calculationDebugDataId):base("CalculationDebugDataEntity")
		{
			InitClassFetch(calculationDebugDataId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="calculationDebugDataId">PK value for CalculationDebugData which data should be fetched into this CalculationDebugData object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public CalculationDebugDataEntity(System.Int64 calculationDebugDataId, IPrefetchPath prefetchPathToUse):base("CalculationDebugDataEntity")
		{
			InitClassFetch(calculationDebugDataId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="calculationDebugDataId">PK value for CalculationDebugData which data should be fetched into this CalculationDebugData object</param>
		/// <param name="validator">The custom validator object for this CalculationDebugDataEntity</param>
		public CalculationDebugDataEntity(System.Int64 calculationDebugDataId, IValidator validator):base("CalculationDebugDataEntity")
		{
			InitClassFetch(calculationDebugDataId, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CalculationDebugDataEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
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
			switch((CalculationDebugDataFieldIndex)fieldIndex)
			{
				case CalculationDebugDataFieldIndex.TreatmentId:
					DesetupSyncTreatment(true, false);
					_alreadyFetchedTreatment = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
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
		/// <param name="calculationDebugDataId">PK value for CalculationDebugData which data should be fetched into this CalculationDebugData object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 calculationDebugDataId)
		{
			return FetchUsingPK(calculationDebugDataId, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="calculationDebugDataId">PK value for CalculationDebugData which data should be fetched into this CalculationDebugData object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 calculationDebugDataId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(calculationDebugDataId, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="calculationDebugDataId">PK value for CalculationDebugData which data should be fetched into this CalculationDebugData object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 calculationDebugDataId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(calculationDebugDataId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="calculationDebugDataId">PK value for CalculationDebugData which data should be fetched into this CalculationDebugData object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 calculationDebugDataId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(calculationDebugDataId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.CalculationDebugDataId, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new CalculationDebugDataRelations().GetAllRelations();
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
		/// <param name="calculationDebugDataId">PK value for CalculationDebugData which data should be fetched into this CalculationDebugData object</param>
		/// <param name="validator">The validator object for this CalculationDebugDataEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int64 calculationDebugDataId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(calculationDebugDataId, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
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
			_fieldsCustomProperties.Add("CalculationDebugDataId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("TreatmentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("FingerSector", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IsFiltered", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("OrganComponent", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Area", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AverageIntensity", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("BreakCoefficient", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Entropy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("NS", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Fractal", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Form", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Form2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AI1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AI2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AI3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AI4", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Form11", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Form12", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Form13", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Form14", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("RingIntensity", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("RingThickness", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Form2Prime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("EPICBaseScore", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("EPICBonusScore", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("EPICScore", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("EPICScaledScore", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("EPICRank", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("LRRank", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("LRScore", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("LRScaledScore", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("SumZScore", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _treatment</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTreatment(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _treatment, new PropertyChangedEventHandler( OnTreatmentPropertyChanged ), "Treatment", EPICCentralDL.RelationClasses.StaticCalculationDebugDataRelations.TreatmentEntityUsingTreatmentIdStatic, true, signalRelatedEntity, "CalculationDebugDatas", resetFKFields, new int[] { (int)CalculationDebugDataFieldIndex.TreatmentId } );		
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
				this.PerformSetupSyncRelatedEntity( _treatment, new PropertyChangedEventHandler( OnTreatmentPropertyChanged ), "Treatment", EPICCentralDL.RelationClasses.StaticCalculationDebugDataRelations.TreatmentEntityUsingTreatmentIdStatic, true, ref _alreadyFetchedTreatment, new string[] {  } );
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
		/// <param name="calculationDebugDataId">PK value for CalculationDebugData which data should be fetched into this CalculationDebugData object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int64 calculationDebugDataId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)CalculationDebugDataFieldIndex.CalculationDebugDataId].ForcedCurrentValueWrite(calculationDebugDataId);
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
			return DAOFactory.CreateCalculationDebugDataDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new CalculationDebugDataEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static CalculationDebugDataRelations Relations
		{
			get	{ return new CalculationDebugDataRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Treatment'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathTreatment
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.TreatmentCollection(), (IEntityRelation)GetRelationsForField("Treatment")[0], (int)EPICCentralDL.EntityType.CalculationDebugDataEntity, (int)EPICCentralDL.EntityType.TreatmentEntity, 0, null, null, null, "Treatment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The CalculationDebugDataId property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."CalculationDebugDataId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CalculationDebugDataId
		{
			get { return (System.Int64)GetValue((int)CalculationDebugDataFieldIndex.CalculationDebugDataId, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.CalculationDebugDataId, value, true); }
		}

		/// <summary> The TreatmentId property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."TreatmentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TreatmentId
		{
			get { return (System.Int64)GetValue((int)CalculationDebugDataFieldIndex.TreatmentId, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.TreatmentId, value, true); }
		}

		/// <summary> The FingerSector property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."FingerSector"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String FingerSector
		{
			get { return (System.String)GetValue((int)CalculationDebugDataFieldIndex.FingerSector, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.FingerSector, value, true); }
		}

		/// <summary> The IsFiltered property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."IsFiltered"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsFiltered
		{
			get { return (System.Boolean)GetValue((int)CalculationDebugDataFieldIndex.IsFiltered, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.IsFiltered, value, true); }
		}

		/// <summary> The OrganComponent property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."OrganComponent"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual EPICCentralDL.Customization.OrganComponent OrganComponent
		{
			get { return (EPICCentralDL.Customization.OrganComponent)GetValue((int)CalculationDebugDataFieldIndex.OrganComponent, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.OrganComponent, value, true); }
		}

		/// <summary> The Area property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."Area"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Area
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.Area, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.Area, value, true); }
		}

		/// <summary> The AverageIntensity property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."AverageIntensity"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal AverageIntensity
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.AverageIntensity, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.AverageIntensity, value, true); }
		}

		/// <summary> The BreakCoefficient property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."BreakCoefficient"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> BreakCoefficient
		{
			get { return (Nullable<System.Decimal>)GetValue((int)CalculationDebugDataFieldIndex.BreakCoefficient, false); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.BreakCoefficient, value, true); }
		}

		/// <summary> The Entropy property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."Entropy"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Entropy
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.Entropy, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.Entropy, value, true); }
		}

		/// <summary> The NS property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."NS"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal NS
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.NS, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.NS, value, true); }
		}

		/// <summary> The Fractal property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."Fractal"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Fractal
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.Fractal, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.Fractal, value, true); }
		}

		/// <summary> The Form property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."Form"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Form
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.Form, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.Form, value, true); }
		}

		/// <summary> The Form2 property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."Form2"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Form2
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.Form2, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.Form2, value, true); }
		}

		/// <summary> The AI1 property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."AI1"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal AI1
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.AI1, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.AI1, value, true); }
		}

		/// <summary> The AI2 property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."AI2"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal AI2
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.AI2, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.AI2, value, true); }
		}

		/// <summary> The AI3 property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."AI3"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal AI3
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.AI3, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.AI3, value, true); }
		}

		/// <summary> The AI4 property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."AI4"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal AI4
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.AI4, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.AI4, value, true); }
		}

		/// <summary> The Form11 property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."Form1_1"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Form11
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.Form11, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.Form11, value, true); }
		}

		/// <summary> The Form12 property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."Form1_2"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Form12
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.Form12, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.Form12, value, true); }
		}

		/// <summary> The Form13 property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."Form1_3"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Form13
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.Form13, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.Form13, value, true); }
		}

		/// <summary> The Form14 property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."Form1_4"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Form14
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.Form14, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.Form14, value, true); }
		}

		/// <summary> The RingIntensity property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."RingIntensity"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal RingIntensity
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.RingIntensity, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.RingIntensity, value, true); }
		}

		/// <summary> The RingThickness property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."RingThickness"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal RingThickness
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.RingThickness, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.RingThickness, value, true); }
		}

		/// <summary> The Form2Prime property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."Form2Prime"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal Form2Prime
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.Form2Prime, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.Form2Prime, value, true); }
		}

		/// <summary> The EPICBaseScore property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."EPICBaseScore"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal EPICBaseScore
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.EPICBaseScore, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.EPICBaseScore, value, true); }
		}

		/// <summary> The EPICBonusScore property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."EPICBonusScore"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal EPICBonusScore
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.EPICBonusScore, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.EPICBonusScore, value, true); }
		}

		/// <summary> The EPICScore property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."EPICScore"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal EPICScore
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.EPICScore, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.EPICScore, value, true); }
		}

		/// <summary> The EPICScaledScore property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."EPICScaledScore"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal EPICScaledScore
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.EPICScaledScore, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.EPICScaledScore, value, true); }
		}

		/// <summary> The EPICRank property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."EPICRank"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 EPICRank
		{
			get { return (System.Int32)GetValue((int)CalculationDebugDataFieldIndex.EPICRank, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.EPICRank, value, true); }
		}

		/// <summary> The LRRank property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."LRRank"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 LRRank
		{
			get { return (System.Int32)GetValue((int)CalculationDebugDataFieldIndex.LRRank, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.LRRank, value, true); }
		}

		/// <summary> The LRScore property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."LRScore"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal LRScore
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.LRScore, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.LRScore, value, true); }
		}

		/// <summary> The LRScaledScore property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."LRScaledScore"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal LRScaledScore
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.LRScaledScore, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.LRScaledScore, value, true); }
		}

		/// <summary> The SumZScore property of the Entity CalculationDebugData<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CalculationDebugData"."SumZScore"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 16, 4, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal SumZScore
		{
			get { return (System.Decimal)GetValue((int)CalculationDebugDataFieldIndex.SumZScore, true); }
			set	{ SetValue((int)CalculationDebugDataFieldIndex.SumZScore, value, true); }
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
					SetSingleRelatedEntityNavigator(value, "CalculationDebugDatas", "Treatment", _treatment, true); 
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
			get { return (int)EPICCentralDL.EntityType.CalculationDebugDataEntity; }
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
