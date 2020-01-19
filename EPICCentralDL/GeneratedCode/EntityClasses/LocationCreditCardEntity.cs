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

	/// <summary>Entity class which represents the entity 'LocationCreditCard'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class LocationCreditCardEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private CreditCardEntity _creditCard;
		private bool	_alwaysFetchCreditCard, _alreadyFetchedCreditCard, _creditCardReturnsNewIfNotFound;
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
			/// <summary>Member name CreditCard</summary>
			public static readonly string CreditCard = "CreditCard";
			/// <summary>Member name Location</summary>
			public static readonly string Location = "Location";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static LocationCreditCardEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public LocationCreditCardEntity() :base("LocationCreditCardEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="locationId">PK value for LocationCreditCard which data should be fetched into this LocationCreditCard object</param>
		/// <param name="creditCardId">PK value for LocationCreditCard which data should be fetched into this LocationCreditCard object</param>
		public LocationCreditCardEntity(System.Int32 locationId, System.Int32 creditCardId):base("LocationCreditCardEntity")
		{
			InitClassFetch(locationId, creditCardId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="locationId">PK value for LocationCreditCard which data should be fetched into this LocationCreditCard object</param>
		/// <param name="creditCardId">PK value for LocationCreditCard which data should be fetched into this LocationCreditCard object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public LocationCreditCardEntity(System.Int32 locationId, System.Int32 creditCardId, IPrefetchPath prefetchPathToUse):base("LocationCreditCardEntity")
		{
			InitClassFetch(locationId, creditCardId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="locationId">PK value for LocationCreditCard which data should be fetched into this LocationCreditCard object</param>
		/// <param name="creditCardId">PK value for LocationCreditCard which data should be fetched into this LocationCreditCard object</param>
		/// <param name="validator">The custom validator object for this LocationCreditCardEntity</param>
		public LocationCreditCardEntity(System.Int32 locationId, System.Int32 creditCardId, IValidator validator):base("LocationCreditCardEntity")
		{
			InitClassFetch(locationId, creditCardId, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected LocationCreditCardEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_creditCard = (CreditCardEntity)info.GetValue("_creditCard", typeof(CreditCardEntity));
			if(_creditCard!=null)
			{
				_creditCard.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_creditCardReturnsNewIfNotFound = info.GetBoolean("_creditCardReturnsNewIfNotFound");
			_alwaysFetchCreditCard = info.GetBoolean("_alwaysFetchCreditCard");
			_alreadyFetchedCreditCard = info.GetBoolean("_alreadyFetchedCreditCard");

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
			switch((LocationCreditCardFieldIndex)fieldIndex)
			{
				case LocationCreditCardFieldIndex.LocationId:
					DesetupSyncLocation(true, false);
					_alreadyFetchedLocation = false;
					break;
				case LocationCreditCardFieldIndex.CreditCardId:
					DesetupSyncCreditCard(true, false);
					_alreadyFetchedCreditCard = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedCreditCard = (_creditCard != null);
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
				case "CreditCard":
					toReturn.Add(Relations.CreditCardEntityUsingCreditCardId);
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
			info.AddValue("_creditCard", (!this.MarkedForDeletion?_creditCard:null));
			info.AddValue("_creditCardReturnsNewIfNotFound", _creditCardReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchCreditCard", _alwaysFetchCreditCard);
			info.AddValue("_alreadyFetchedCreditCard", _alreadyFetchedCreditCard);
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
				case "CreditCard":
					_alreadyFetchedCreditCard = true;
					this.CreditCard = (CreditCardEntity)entity;
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
				case "CreditCard":
					SetupSyncCreditCard(relatedEntity);
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
				case "CreditCard":
					DesetupSyncCreditCard(false, true);
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
			if(_creditCard!=null)
			{
				toReturn.Add(_creditCard);
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
		/// <param name="locationId">PK value for LocationCreditCard which data should be fetched into this LocationCreditCard object</param>
		/// <param name="creditCardId">PK value for LocationCreditCard which data should be fetched into this LocationCreditCard object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 locationId, System.Int32 creditCardId)
		{
			return FetchUsingPK(locationId, creditCardId, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="locationId">PK value for LocationCreditCard which data should be fetched into this LocationCreditCard object</param>
		/// <param name="creditCardId">PK value for LocationCreditCard which data should be fetched into this LocationCreditCard object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 locationId, System.Int32 creditCardId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(locationId, creditCardId, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="locationId">PK value for LocationCreditCard which data should be fetched into this LocationCreditCard object</param>
		/// <param name="creditCardId">PK value for LocationCreditCard which data should be fetched into this LocationCreditCard object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 locationId, System.Int32 creditCardId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(locationId, creditCardId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="locationId">PK value for LocationCreditCard which data should be fetched into this LocationCreditCard object</param>
		/// <param name="creditCardId">PK value for LocationCreditCard which data should be fetched into this LocationCreditCard object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 locationId, System.Int32 creditCardId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(locationId, creditCardId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.LocationId, this.CreditCardId, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new LocationCreditCardRelations().GetAllRelations();
		}

		/// <summary> Retrieves the related entity of type 'CreditCardEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'CreditCardEntity' which is related to this entity.</returns>
		public CreditCardEntity GetSingleCreditCard()
		{
			return GetSingleCreditCard(false);
		}

		/// <summary> Retrieves the related entity of type 'CreditCardEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'CreditCardEntity' which is related to this entity.</returns>
		public virtual CreditCardEntity GetSingleCreditCard(bool forceFetch)
		{
			if( ( !_alreadyFetchedCreditCard || forceFetch || _alwaysFetchCreditCard) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.CreditCardEntityUsingCreditCardId);
				CreditCardEntity newEntity = new CreditCardEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.CreditCardId);
				}
				if(fetchResult)
				{
					newEntity = (CreditCardEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_creditCardReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.CreditCard = newEntity;
				_alreadyFetchedCreditCard = fetchResult;
			}
			return _creditCard;
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
			toReturn.Add("CreditCard", _creditCard);
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
		/// <param name="locationId">PK value for LocationCreditCard which data should be fetched into this LocationCreditCard object</param>
		/// <param name="creditCardId">PK value for LocationCreditCard which data should be fetched into this LocationCreditCard object</param>
		/// <param name="validator">The validator object for this LocationCreditCardEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 locationId, System.Int32 creditCardId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(locationId, creditCardId, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
			_creditCardReturnsNewIfNotFound = false;
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
			_fieldsCustomProperties.Add("LocationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("CreditCardId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _creditCard</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCreditCard(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _creditCard, new PropertyChangedEventHandler( OnCreditCardPropertyChanged ), "CreditCard", EPICCentralDL.RelationClasses.StaticLocationCreditCardRelations.CreditCardEntityUsingCreditCardIdStatic, true, signalRelatedEntity, "LocationCreditCards", resetFKFields, new int[] { (int)LocationCreditCardFieldIndex.CreditCardId } );		
			_creditCard = null;
		}
		
		/// <summary> setups the sync logic for member _creditCard</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCreditCard(IEntityCore relatedEntity)
		{
			if(_creditCard!=relatedEntity)
			{		
				DesetupSyncCreditCard(true, true);
				_creditCard = (CreditCardEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _creditCard, new PropertyChangedEventHandler( OnCreditCardPropertyChanged ), "CreditCard", EPICCentralDL.RelationClasses.StaticLocationCreditCardRelations.CreditCardEntityUsingCreditCardIdStatic, true, ref _alreadyFetchedCreditCard, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCreditCardPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			this.PerformDesetupSyncRelatedEntity( _location, new PropertyChangedEventHandler( OnLocationPropertyChanged ), "Location", EPICCentralDL.RelationClasses.StaticLocationCreditCardRelations.LocationEntityUsingLocationIdStatic, true, signalRelatedEntity, "LocationCreditCards", resetFKFields, new int[] { (int)LocationCreditCardFieldIndex.LocationId } );		
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
				this.PerformSetupSyncRelatedEntity( _location, new PropertyChangedEventHandler( OnLocationPropertyChanged ), "Location", EPICCentralDL.RelationClasses.StaticLocationCreditCardRelations.LocationEntityUsingLocationIdStatic, true, ref _alreadyFetchedLocation, new string[] {  } );
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
		/// <param name="locationId">PK value for LocationCreditCard which data should be fetched into this LocationCreditCard object</param>
		/// <param name="creditCardId">PK value for LocationCreditCard which data should be fetched into this LocationCreditCard object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 locationId, System.Int32 creditCardId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)LocationCreditCardFieldIndex.LocationId].ForcedCurrentValueWrite(locationId);
				this.Fields[(int)LocationCreditCardFieldIndex.CreditCardId].ForcedCurrentValueWrite(creditCardId);
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
			return DAOFactory.CreateLocationCreditCardDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new LocationCreditCardEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static LocationCreditCardRelations Relations
		{
			get	{ return new LocationCreditCardRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'CreditCard'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathCreditCard
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.CreditCardCollection(), (IEntityRelation)GetRelationsForField("CreditCard")[0], (int)EPICCentralDL.EntityType.LocationCreditCardEntity, (int)EPICCentralDL.EntityType.CreditCardEntity, 0, null, null, null, "CreditCard", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Location'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathLocation
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.LocationCollection(), (IEntityRelation)GetRelationsForField("Location")[0], (int)EPICCentralDL.EntityType.LocationCreditCardEntity, (int)EPICCentralDL.EntityType.LocationEntity, 0, null, null, null, "Location", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The LocationId property of the Entity LocationCreditCard<br/><br/></summary>
		/// <remarks>Mapped on  table field: "LocationCreditCard"."LocationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 LocationId
		{
			get { return (System.Int32)GetValue((int)LocationCreditCardFieldIndex.LocationId, true); }
			set	{ SetValue((int)LocationCreditCardFieldIndex.LocationId, value, true); }
		}

		/// <summary> The CreditCardId property of the Entity LocationCreditCard<br/><br/></summary>
		/// <remarks>Mapped on  table field: "LocationCreditCard"."CreditCardId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int32 CreditCardId
		{
			get { return (System.Int32)GetValue((int)LocationCreditCardFieldIndex.CreditCardId, true); }
			set	{ SetValue((int)LocationCreditCardFieldIndex.CreditCardId, value, true); }
		}


		/// <summary> Gets / sets related entity of type 'CreditCardEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleCreditCard()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual CreditCardEntity CreditCard
		{
			get	{ return GetSingleCreditCard(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncCreditCard(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "LocationCreditCards", "CreditCard", _creditCard, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for CreditCard. When set to true, CreditCard is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time CreditCard is accessed. You can always execute a forced fetch by calling GetSingleCreditCard(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchCreditCard
		{
			get	{ return _alwaysFetchCreditCard; }
			set	{ _alwaysFetchCreditCard = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property CreditCard already has been fetched. Setting this property to false when CreditCard has been fetched
		/// will set CreditCard to null as well. Setting this property to true while CreditCard hasn't been fetched disables lazy loading for CreditCard</summary>
		[Browsable(false)]
		public bool AlreadyFetchedCreditCard
		{
			get { return _alreadyFetchedCreditCard;}
			set 
			{
				if(_alreadyFetchedCreditCard && !value)
				{
					this.CreditCard = null;
				}
				_alreadyFetchedCreditCard = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property CreditCard is not found
		/// in the database. When set to true, CreditCard will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: false.</summary>
		[Browsable(false)]
		public bool CreditCardReturnsNewIfNotFound
		{
			get	{ return _creditCardReturnsNewIfNotFound; }
			set { _creditCardReturnsNewIfNotFound = value; }	
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
					SetSingleRelatedEntityNavigator(value, "LocationCreditCards", "Location", _location, true); 
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
			get { return (int)EPICCentralDL.EntityType.LocationCreditCardEntity; }
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
