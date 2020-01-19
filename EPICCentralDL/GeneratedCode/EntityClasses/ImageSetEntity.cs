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

	/// <summary>Entity class which represents the entity 'ImageSet'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ImageSetEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EPICCentralDL.CollectionClasses.CalibrationCollection	_calibrations;
		private bool	_alwaysFetchCalibrations, _alreadyFetchedCalibrations;
		private EPICCentralDL.CollectionClasses.TreatmentCollection	_treatments;
		private bool	_alwaysFetchTreatments, _alreadyFetchedTreatments;
		private EPICCentralDL.CollectionClasses.TreatmentCollection	_treatments_;
		private bool	_alwaysFetchTreatments_, _alreadyFetchedTreatments_;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Calibrations</summary>
			public static readonly string Calibrations = "Calibrations";
			/// <summary>Member name Treatments</summary>
			public static readonly string Treatments = "Treatments";
			/// <summary>Member name Treatments_</summary>
			public static readonly string Treatments_ = "Treatments_";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ImageSetEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public ImageSetEntity() :base("ImageSetEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="imageSetId">PK value for ImageSet which data should be fetched into this ImageSet object</param>
		public ImageSetEntity(System.Int64 imageSetId):base("ImageSetEntity")
		{
			InitClassFetch(imageSetId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="imageSetId">PK value for ImageSet which data should be fetched into this ImageSet object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public ImageSetEntity(System.Int64 imageSetId, IPrefetchPath prefetchPathToUse):base("ImageSetEntity")
		{
			InitClassFetch(imageSetId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="imageSetId">PK value for ImageSet which data should be fetched into this ImageSet object</param>
		/// <param name="validator">The custom validator object for this ImageSetEntity</param>
		public ImageSetEntity(System.Int64 imageSetId, IValidator validator):base("ImageSetEntity")
		{
			InitClassFetch(imageSetId, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ImageSetEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_calibrations = (EPICCentralDL.CollectionClasses.CalibrationCollection)info.GetValue("_calibrations", typeof(EPICCentralDL.CollectionClasses.CalibrationCollection));
			_alwaysFetchCalibrations = info.GetBoolean("_alwaysFetchCalibrations");
			_alreadyFetchedCalibrations = info.GetBoolean("_alreadyFetchedCalibrations");

			_treatments = (EPICCentralDL.CollectionClasses.TreatmentCollection)info.GetValue("_treatments", typeof(EPICCentralDL.CollectionClasses.TreatmentCollection));
			_alwaysFetchTreatments = info.GetBoolean("_alwaysFetchTreatments");
			_alreadyFetchedTreatments = info.GetBoolean("_alreadyFetchedTreatments");

			_treatments_ = (EPICCentralDL.CollectionClasses.TreatmentCollection)info.GetValue("_treatments_", typeof(EPICCentralDL.CollectionClasses.TreatmentCollection));
			_alwaysFetchTreatments_ = info.GetBoolean("_alwaysFetchTreatments_");
			_alreadyFetchedTreatments_ = info.GetBoolean("_alreadyFetchedTreatments_");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedCalibrations = (_calibrations.Count > 0);
			_alreadyFetchedTreatments = (_treatments.Count > 0);
			_alreadyFetchedTreatments_ = (_treatments_.Count > 0);
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
				case "Calibrations":
					toReturn.Add(Relations.CalibrationEntityUsingImageSetId);
					break;
				case "Treatments":
					toReturn.Add(Relations.TreatmentEntityUsingEnergizedImageSetId);
					break;
				case "Treatments_":
					toReturn.Add(Relations.TreatmentEntityUsingFingerImageSetId);
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
			info.AddValue("_calibrations", (!this.MarkedForDeletion?_calibrations:null));
			info.AddValue("_alwaysFetchCalibrations", _alwaysFetchCalibrations);
			info.AddValue("_alreadyFetchedCalibrations", _alreadyFetchedCalibrations);
			info.AddValue("_treatments", (!this.MarkedForDeletion?_treatments:null));
			info.AddValue("_alwaysFetchTreatments", _alwaysFetchTreatments);
			info.AddValue("_alreadyFetchedTreatments", _alreadyFetchedTreatments);
			info.AddValue("_treatments_", (!this.MarkedForDeletion?_treatments_:null));
			info.AddValue("_alwaysFetchTreatments_", _alwaysFetchTreatments_);
			info.AddValue("_alreadyFetchedTreatments_", _alreadyFetchedTreatments_);

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
				case "Calibrations":
					_alreadyFetchedCalibrations = true;
					if(entity!=null)
					{
						this.Calibrations.Add((CalibrationEntity)entity);
					}
					break;
				case "Treatments":
					_alreadyFetchedTreatments = true;
					if(entity!=null)
					{
						this.Treatments.Add((TreatmentEntity)entity);
					}
					break;
				case "Treatments_":
					_alreadyFetchedTreatments_ = true;
					if(entity!=null)
					{
						this.Treatments_.Add((TreatmentEntity)entity);
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
				case "Calibrations":
					_calibrations.Add((CalibrationEntity)relatedEntity);
					break;
				case "Treatments":
					_treatments.Add((TreatmentEntity)relatedEntity);
					break;
				case "Treatments_":
					_treatments_.Add((TreatmentEntity)relatedEntity);
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
				case "Calibrations":
					this.PerformRelatedEntityRemoval(_calibrations, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Treatments":
					this.PerformRelatedEntityRemoval(_treatments, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Treatments_":
					this.PerformRelatedEntityRemoval(_treatments_, relatedEntity, signalRelatedEntityManyToOne);
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
			return toReturn;
		}
		
		/// <summary> Gets a List of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		protected override List<IEntityCollection> GetMemberEntityCollections()
		{
			List<IEntityCollection> toReturn = new List<IEntityCollection>();
			toReturn.Add(_calibrations);
			toReturn.Add(_treatments);
			toReturn.Add(_treatments_);

			return toReturn;
		}


		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="imageSetId">PK value for ImageSet which data should be fetched into this ImageSet object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 imageSetId)
		{
			return FetchUsingPK(imageSetId, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="imageSetId">PK value for ImageSet which data should be fetched into this ImageSet object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 imageSetId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(imageSetId, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="imageSetId">PK value for ImageSet which data should be fetched into this ImageSet object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 imageSetId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(imageSetId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="imageSetId">PK value for ImageSet which data should be fetched into this ImageSet object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 imageSetId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(imageSetId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.ImageSetId, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new ImageSetRelations().GetAllRelations();
		}

		/// <summary> Retrieves all related entities of type 'CalibrationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'CalibrationEntity'</returns>
		public EPICCentralDL.CollectionClasses.CalibrationCollection GetMultiCalibrations(bool forceFetch)
		{
			return GetMultiCalibrations(forceFetch, _calibrations.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'CalibrationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'CalibrationEntity'</returns>
		public EPICCentralDL.CollectionClasses.CalibrationCollection GetMultiCalibrations(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiCalibrations(forceFetch, _calibrations.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'CalibrationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.CalibrationCollection GetMultiCalibrations(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiCalibrations(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'CalibrationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.CalibrationCollection GetMultiCalibrations(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedCalibrations || forceFetch || _alwaysFetchCalibrations) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_calibrations);
				_calibrations.SuppressClearInGetMulti=!forceFetch;
				_calibrations.EntityFactoryToUse = entityFactoryToUse;
				_calibrations.GetMultiManyToOne(null, this, filter);
				_calibrations.SuppressClearInGetMulti=false;
				_alreadyFetchedCalibrations = true;
			}
			return _calibrations;
		}

		/// <summary> Sets the collection parameters for the collection for 'Calibrations'. These settings will be taken into account
		/// when the property Calibrations is requested or GetMultiCalibrations is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersCalibrations(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_calibrations.SortClauses=sortClauses;
			_calibrations.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'TreatmentEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'TreatmentEntity'</returns>
		public EPICCentralDL.CollectionClasses.TreatmentCollection GetMultiTreatments(bool forceFetch)
		{
			return GetMultiTreatments(forceFetch, _treatments.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'TreatmentEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'TreatmentEntity'</returns>
		public EPICCentralDL.CollectionClasses.TreatmentCollection GetMultiTreatments(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiTreatments(forceFetch, _treatments.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'TreatmentEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.TreatmentCollection GetMultiTreatments(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiTreatments(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'TreatmentEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.TreatmentCollection GetMultiTreatments(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedTreatments || forceFetch || _alwaysFetchTreatments) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_treatments);
				_treatments.SuppressClearInGetMulti=!forceFetch;
				_treatments.EntityFactoryToUse = entityFactoryToUse;
				_treatments.GetMultiManyToOne(null, this, null, null, filter);
				_treatments.SuppressClearInGetMulti=false;
				_alreadyFetchedTreatments = true;
			}
			return _treatments;
		}

		/// <summary> Sets the collection parameters for the collection for 'Treatments'. These settings will be taken into account
		/// when the property Treatments is requested or GetMultiTreatments is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersTreatments(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_treatments.SortClauses=sortClauses;
			_treatments.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'TreatmentEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'TreatmentEntity'</returns>
		public EPICCentralDL.CollectionClasses.TreatmentCollection GetMultiTreatments_(bool forceFetch)
		{
			return GetMultiTreatments_(forceFetch, _treatments_.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'TreatmentEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'TreatmentEntity'</returns>
		public EPICCentralDL.CollectionClasses.TreatmentCollection GetMultiTreatments_(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiTreatments_(forceFetch, _treatments_.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'TreatmentEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.TreatmentCollection GetMultiTreatments_(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiTreatments_(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'TreatmentEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.TreatmentCollection GetMultiTreatments_(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedTreatments_ || forceFetch || _alwaysFetchTreatments_) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_treatments_);
				_treatments_.SuppressClearInGetMulti=!forceFetch;
				_treatments_.EntityFactoryToUse = entityFactoryToUse;
				_treatments_.GetMultiManyToOne(null, null, this, null, filter);
				_treatments_.SuppressClearInGetMulti=false;
				_alreadyFetchedTreatments_ = true;
			}
			return _treatments_;
		}

		/// <summary> Sets the collection parameters for the collection for 'Treatments_'. These settings will be taken into account
		/// when the property Treatments_ is requested or GetMultiTreatments_ is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersTreatments_(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_treatments_.SortClauses=sortClauses;
			_treatments_.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Calibrations", _calibrations);
			toReturn.Add("Treatments", _treatments);
			toReturn.Add("Treatments_", _treatments_);
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
		/// <param name="imageSetId">PK value for ImageSet which data should be fetched into this ImageSet object</param>
		/// <param name="validator">The validator object for this ImageSetEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int64 imageSetId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(imageSetId, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{

			_calibrations = new EPICCentralDL.CollectionClasses.CalibrationCollection();
			_calibrations.SetContainingEntityInfo(this, "ImageSet");

			_treatments = new EPICCentralDL.CollectionClasses.TreatmentCollection();
			_treatments.SetContainingEntityInfo(this, "ImageSet");

			_treatments_ = new EPICCentralDL.CollectionClasses.TreatmentCollection();
			_treatments_.SetContainingEntityInfo(this, "ImageSet_");
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
			_fieldsCustomProperties.Add("ImageSetId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("UniqueIdentifier", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Images", fieldHashtable);
		}
		#endregion

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="imageSetId">PK value for ImageSet which data should be fetched into this ImageSet object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int64 imageSetId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)ImageSetFieldIndex.ImageSetId].ForcedCurrentValueWrite(imageSetId);
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
			return DAOFactory.CreateImageSetDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new ImageSetEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static ImageSetRelations Relations
		{
			get	{ return new ImageSetRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Calibration' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathCalibrations
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.CalibrationCollection(), (IEntityRelation)GetRelationsForField("Calibrations")[0], (int)EPICCentralDL.EntityType.ImageSetEntity, (int)EPICCentralDL.EntityType.CalibrationEntity, 0, null, null, null, "Calibrations", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Treatment' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathTreatments
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.TreatmentCollection(), (IEntityRelation)GetRelationsForField("Treatments")[0], (int)EPICCentralDL.EntityType.ImageSetEntity, (int)EPICCentralDL.EntityType.TreatmentEntity, 0, null, null, null, "Treatments", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Treatment' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathTreatments_
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.TreatmentCollection(), (IEntityRelation)GetRelationsForField("Treatments_")[0], (int)EPICCentralDL.EntityType.ImageSetEntity, (int)EPICCentralDL.EntityType.TreatmentEntity, 0, null, null, null, "Treatments_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
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

		/// <summary> The ImageSetId property of the Entity ImageSet<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ImageSet"."ImageSetId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ImageSetId
		{
			get { return (System.Int64)GetValue((int)ImageSetFieldIndex.ImageSetId, true); }
			set	{ SetValue((int)ImageSetFieldIndex.ImageSetId, value, true); }
		}

		/// <summary> The UniqueIdentifier property of the Entity ImageSet<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ImageSet"."UniqueIdentifier"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 48<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String UniqueIdentifier
		{
			get { return (System.String)GetValue((int)ImageSetFieldIndex.UniqueIdentifier, true); }
			set	{ SetValue((int)ImageSetFieldIndex.UniqueIdentifier, value, true); }
		}

		/// <summary> The Images property of the Entity ImageSet<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ImageSet"."Images"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarBinary, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte[] Images
		{
			get { return (System.Byte[])GetValue((int)ImageSetFieldIndex.Images, true); }
			set	{ SetValue((int)ImageSetFieldIndex.Images, value, true); }
		}

		/// <summary> Retrieves all related entities of type 'CalibrationEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiCalibrations()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.CalibrationCollection Calibrations
		{
			get	{ return GetMultiCalibrations(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Calibrations. When set to true, Calibrations is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Calibrations is accessed. You can always execute/ a forced fetch by calling GetMultiCalibrations(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchCalibrations
		{
			get	{ return _alwaysFetchCalibrations; }
			set	{ _alwaysFetchCalibrations = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property Calibrations already has been fetched. Setting this property to false when Calibrations has been fetched
		/// will clear the Calibrations collection well. Setting this property to true while Calibrations hasn't been fetched disables lazy loading for Calibrations</summary>
		[Browsable(false)]
		public bool AlreadyFetchedCalibrations
		{
			get { return _alreadyFetchedCalibrations;}
			set 
			{
				if(_alreadyFetchedCalibrations && !value && (_calibrations != null))
				{
					_calibrations.Clear();
				}
				_alreadyFetchedCalibrations = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'TreatmentEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiTreatments()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.TreatmentCollection Treatments
		{
			get	{ return GetMultiTreatments(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Treatments. When set to true, Treatments is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Treatments is accessed. You can always execute/ a forced fetch by calling GetMultiTreatments(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchTreatments
		{
			get	{ return _alwaysFetchTreatments; }
			set	{ _alwaysFetchTreatments = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property Treatments already has been fetched. Setting this property to false when Treatments has been fetched
		/// will clear the Treatments collection well. Setting this property to true while Treatments hasn't been fetched disables lazy loading for Treatments</summary>
		[Browsable(false)]
		public bool AlreadyFetchedTreatments
		{
			get { return _alreadyFetchedTreatments;}
			set 
			{
				if(_alreadyFetchedTreatments && !value && (_treatments != null))
				{
					_treatments.Clear();
				}
				_alreadyFetchedTreatments = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'TreatmentEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiTreatments_()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.TreatmentCollection Treatments_
		{
			get	{ return GetMultiTreatments_(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Treatments_. When set to true, Treatments_ is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Treatments_ is accessed. You can always execute/ a forced fetch by calling GetMultiTreatments_(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchTreatments_
		{
			get	{ return _alwaysFetchTreatments_; }
			set	{ _alwaysFetchTreatments_ = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property Treatments_ already has been fetched. Setting this property to false when Treatments_ has been fetched
		/// will clear the Treatments_ collection well. Setting this property to true while Treatments_ hasn't been fetched disables lazy loading for Treatments_</summary>
		[Browsable(false)]
		public bool AlreadyFetchedTreatments_
		{
			get { return _alreadyFetchedTreatments_;}
			set 
			{
				if(_alreadyFetchedTreatments_ && !value && (_treatments_ != null))
				{
					_treatments_.Clear();
				}
				_alreadyFetchedTreatments_ = value;
			}
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
			get { return (int)EPICCentralDL.EntityType.ImageSetEntity; }
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
