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

	/// <summary>Entity class which represents the entity 'AnalysisResult'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AnalysisResultEntity : CommonEntityBase
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
		static AnalysisResultEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public AnalysisResultEntity() :base("AnalysisResultEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="analysisResultId">PK value for AnalysisResult which data should be fetched into this AnalysisResult object</param>
		public AnalysisResultEntity(System.Int64 analysisResultId):base("AnalysisResultEntity")
		{
			InitClassFetch(analysisResultId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="analysisResultId">PK value for AnalysisResult which data should be fetched into this AnalysisResult object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public AnalysisResultEntity(System.Int64 analysisResultId, IPrefetchPath prefetchPathToUse):base("AnalysisResultEntity")
		{
			InitClassFetch(analysisResultId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="analysisResultId">PK value for AnalysisResult which data should be fetched into this AnalysisResult object</param>
		/// <param name="validator">The custom validator object for this AnalysisResultEntity</param>
		public AnalysisResultEntity(System.Int64 analysisResultId, IValidator validator):base("AnalysisResultEntity")
		{
			InitClassFetch(analysisResultId, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected AnalysisResultEntity(SerializationInfo info, StreamingContext context) : base(info, context)
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
			switch((AnalysisResultFieldIndex)fieldIndex)
			{
				case AnalysisResultFieldIndex.TreatmentId:
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
		/// <param name="analysisResultId">PK value for AnalysisResult which data should be fetched into this AnalysisResult object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 analysisResultId)
		{
			return FetchUsingPK(analysisResultId, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="analysisResultId">PK value for AnalysisResult which data should be fetched into this AnalysisResult object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 analysisResultId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(analysisResultId, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="analysisResultId">PK value for AnalysisResult which data should be fetched into this AnalysisResult object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 analysisResultId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(analysisResultId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="analysisResultId">PK value for AnalysisResult which data should be fetched into this AnalysisResult object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 analysisResultId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(analysisResultId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.AnalysisResultId, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new AnalysisResultRelations().GetAllRelations();
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
		/// <param name="analysisResultId">PK value for AnalysisResult which data should be fetched into this AnalysisResult object</param>
		/// <param name="validator">The validator object for this AnalysisResultEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int64 analysisResultId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(analysisResultId, prefetchPathToUse, null, null);

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
			_fieldsCustomProperties.Add("AnalysisResultId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("TreatmentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AnalysisTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IsFiltered", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("FingerDesc", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("FingerType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("SectorNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("StartAngle", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("EndAngle", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("SectorArea", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IntegralArea", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("NormalizedArea", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AverageIntensity", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Entropy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("FormCoefficient", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("FractalCoefficient", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("JsInteger", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("CenterX", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("CenterY", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("RadiusMin", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("RadiusMax", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AngleOfRotation", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Form2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("NoiseLevel", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("BreakCoefficient", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("SoftwareVersion", fieldHashtable);
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
			_fieldsCustomProperties.Add("RingThickness", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("RingIntensity", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Form2Prime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("UserName", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _treatment</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTreatment(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _treatment, new PropertyChangedEventHandler( OnTreatmentPropertyChanged ), "Treatment", EPICCentralDL.RelationClasses.StaticAnalysisResultRelations.TreatmentEntityUsingTreatmentIdStatic, true, signalRelatedEntity, "AnalysisResults", resetFKFields, new int[] { (int)AnalysisResultFieldIndex.TreatmentId } );		
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
				this.PerformSetupSyncRelatedEntity( _treatment, new PropertyChangedEventHandler( OnTreatmentPropertyChanged ), "Treatment", EPICCentralDL.RelationClasses.StaticAnalysisResultRelations.TreatmentEntityUsingTreatmentIdStatic, true, ref _alreadyFetchedTreatment, new string[] {  } );
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
		/// <param name="analysisResultId">PK value for AnalysisResult which data should be fetched into this AnalysisResult object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int64 analysisResultId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)AnalysisResultFieldIndex.AnalysisResultId].ForcedCurrentValueWrite(analysisResultId);
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
			return DAOFactory.CreateAnalysisResultDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new AnalysisResultEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static AnalysisResultRelations Relations
		{
			get	{ return new AnalysisResultRelations(); }
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
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.TreatmentCollection(), (IEntityRelation)GetRelationsForField("Treatment")[0], (int)EPICCentralDL.EntityType.AnalysisResultEntity, (int)EPICCentralDL.EntityType.TreatmentEntity, 0, null, null, null, "Treatment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The AnalysisResultId property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."AnalysisResultID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 AnalysisResultId
		{
			get { return (System.Int64)GetValue((int)AnalysisResultFieldIndex.AnalysisResultId, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.AnalysisResultId, value, true); }
		}

		/// <summary> The TreatmentId property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."TreatmentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TreatmentId
		{
			get { return (System.Int64)GetValue((int)AnalysisResultFieldIndex.TreatmentId, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.TreatmentId, value, true); }
		}

		/// <summary> The AnalysisTime property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."AnalysisTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime AnalysisTime
		{
			get { return (System.DateTime)GetValue((int)AnalysisResultFieldIndex.AnalysisTime, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.AnalysisTime, value, true); }
		}

		/// <summary> The IsFiltered property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."IsFiltered"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsFiltered
		{
			get { return (System.Boolean)GetValue((int)AnalysisResultFieldIndex.IsFiltered, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.IsFiltered, value, true); }
		}

		/// <summary> The FingerDesc property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."FingerDesc"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String FingerDesc
		{
			get { return (System.String)GetValue((int)AnalysisResultFieldIndex.FingerDesc, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.FingerDesc, value, true); }
		}

		/// <summary> The FingerType property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."FingerType"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 FingerType
		{
			get { return (System.Int32)GetValue((int)AnalysisResultFieldIndex.FingerType, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.FingerType, value, true); }
		}

		/// <summary> The SectorNumber property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."SectorNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 SectorNumber
		{
			get { return (System.Int32)GetValue((int)AnalysisResultFieldIndex.SectorNumber, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.SectorNumber, value, true); }
		}

		/// <summary> The StartAngle property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."StartAngle"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 StartAngle
		{
			get { return (System.Int32)GetValue((int)AnalysisResultFieldIndex.StartAngle, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.StartAngle, value, true); }
		}

		/// <summary> The EndAngle property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."EndAngle"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 EndAngle
		{
			get { return (System.Int32)GetValue((int)AnalysisResultFieldIndex.EndAngle, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.EndAngle, value, true); }
		}

		/// <summary> The SectorArea property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."SectorArea"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double SectorArea
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.SectorArea, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.SectorArea, value, true); }
		}

		/// <summary> The IntegralArea property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."IntegralArea"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double IntegralArea
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.IntegralArea, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.IntegralArea, value, true); }
		}

		/// <summary> The NormalizedArea property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."NormalizedArea"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double NormalizedArea
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.NormalizedArea, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.NormalizedArea, value, true); }
		}

		/// <summary> The AverageIntensity property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."AverageIntensity"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double AverageIntensity
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.AverageIntensity, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.AverageIntensity, value, true); }
		}

		/// <summary> The Entropy property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."Entropy"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double Entropy
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.Entropy, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.Entropy, value, true); }
		}

		/// <summary> The FormCoefficient property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."FormCoefficient"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double FormCoefficient
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.FormCoefficient, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.FormCoefficient, value, true); }
		}

		/// <summary> The FractalCoefficient property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."FractalCoefficient"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double FractalCoefficient
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.FractalCoefficient, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.FractalCoefficient, value, true); }
		}

		/// <summary> The JsInteger property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."JsInteger"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double JsInteger
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.JsInteger, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.JsInteger, value, true); }
		}

		/// <summary> The CenterX property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."CenterX"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double CenterX
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.CenterX, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.CenterX, value, true); }
		}

		/// <summary> The CenterY property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."CenterY"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double CenterY
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.CenterY, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.CenterY, value, true); }
		}

		/// <summary> The RadiusMin property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."RadiusMin"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double RadiusMin
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.RadiusMin, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.RadiusMin, value, true); }
		}

		/// <summary> The RadiusMax property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."RadiusMax"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double RadiusMax
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.RadiusMax, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.RadiusMax, value, true); }
		}

		/// <summary> The AngleOfRotation property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."AngleOfRotation"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double AngleOfRotation
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.AngleOfRotation, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.AngleOfRotation, value, true); }
		}

		/// <summary> The Form2 property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."Form2"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double Form2
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.Form2, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.Form2, value, true); }
		}

		/// <summary> The NoiseLevel property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."NoiseLevel"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 NoiseLevel
		{
			get { return (System.Int32)GetValue((int)AnalysisResultFieldIndex.NoiseLevel, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.NoiseLevel, value, true); }
		}

		/// <summary> The BreakCoefficient property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."BreakCoefficient"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double BreakCoefficient
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.BreakCoefficient, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.BreakCoefficient, value, true); }
		}

		/// <summary> The SoftwareVersion property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."SoftwareVersion"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String SoftwareVersion
		{
			get { return (System.String)GetValue((int)AnalysisResultFieldIndex.SoftwareVersion, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.SoftwareVersion, value, true); }
		}

		/// <summary> The AI1 property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."AI1"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double AI1
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.AI1, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.AI1, value, true); }
		}

		/// <summary> The AI2 property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."AI2"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double AI2
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.AI2, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.AI2, value, true); }
		}

		/// <summary> The AI3 property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."AI3"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double AI3
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.AI3, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.AI3, value, true); }
		}

		/// <summary> The AI4 property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."AI4"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double AI4
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.AI4, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.AI4, value, true); }
		}

		/// <summary> The Form11 property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."Form1_1"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double Form11
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.Form11, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.Form11, value, true); }
		}

		/// <summary> The Form12 property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."Form1_2"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double Form12
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.Form12, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.Form12, value, true); }
		}

		/// <summary> The Form13 property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."Form1_3"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double Form13
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.Form13, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.Form13, value, true); }
		}

		/// <summary> The Form14 property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."Form1_4"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double Form14
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.Form14, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.Form14, value, true); }
		}

		/// <summary> The RingThickness property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."RingThickness"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double RingThickness
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.RingThickness, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.RingThickness, value, true); }
		}

		/// <summary> The RingIntensity property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."RingIntensity"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double RingIntensity
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.RingIntensity, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.RingIntensity, value, true); }
		}

		/// <summary> The Form2Prime property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."Form2Prime"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double Form2Prime
		{
			get { return (System.Double)GetValue((int)AnalysisResultFieldIndex.Form2Prime, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.Form2Prime, value, true); }
		}

		/// <summary> The UserName property of the Entity AnalysisResult<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AnalysisResult"."UserName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String UserName
		{
			get { return (System.String)GetValue((int)AnalysisResultFieldIndex.UserName, true); }
			set	{ SetValue((int)AnalysisResultFieldIndex.UserName, value, true); }
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
					SetSingleRelatedEntityNavigator(value, "AnalysisResults", "Treatment", _treatment, true); 
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
			get { return (int)EPICCentralDL.EntityType.AnalysisResultEntity; }
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
