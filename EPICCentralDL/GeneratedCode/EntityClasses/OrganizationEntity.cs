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

	/// <summary>Entity class which represents the entity 'Organization'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class OrganizationEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EPICCentralDL.CollectionClasses.ContactCollection	_contacts;
		private bool	_alwaysFetchContacts, _alreadyFetchedContacts;
		private EPICCentralDL.CollectionClasses.LocationCollection	_locations;
		private bool	_alwaysFetchLocations, _alreadyFetchedLocations;
		private EPICCentralDL.CollectionClasses.UserCollection	_users;
		private bool	_alwaysFetchUsers, _alreadyFetchedUsers;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Contacts</summary>
			public static readonly string Contacts = "Contacts";
			/// <summary>Member name Locations</summary>
			public static readonly string Locations = "Locations";
			/// <summary>Member name Users</summary>
			public static readonly string Users = "Users";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static OrganizationEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public OrganizationEntity() :base("OrganizationEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="organizationId">PK value for Organization which data should be fetched into this Organization object</param>
		public OrganizationEntity(System.Int32 organizationId):base("OrganizationEntity")
		{
			InitClassFetch(organizationId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="organizationId">PK value for Organization which data should be fetched into this Organization object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public OrganizationEntity(System.Int32 organizationId, IPrefetchPath prefetchPathToUse):base("OrganizationEntity")
		{
			InitClassFetch(organizationId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="organizationId">PK value for Organization which data should be fetched into this Organization object</param>
		/// <param name="validator">The custom validator object for this OrganizationEntity</param>
		public OrganizationEntity(System.Int32 organizationId, IValidator validator):base("OrganizationEntity")
		{
			InitClassFetch(organizationId, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected OrganizationEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_contacts = (EPICCentralDL.CollectionClasses.ContactCollection)info.GetValue("_contacts", typeof(EPICCentralDL.CollectionClasses.ContactCollection));
			_alwaysFetchContacts = info.GetBoolean("_alwaysFetchContacts");
			_alreadyFetchedContacts = info.GetBoolean("_alreadyFetchedContacts");

			_locations = (EPICCentralDL.CollectionClasses.LocationCollection)info.GetValue("_locations", typeof(EPICCentralDL.CollectionClasses.LocationCollection));
			_alwaysFetchLocations = info.GetBoolean("_alwaysFetchLocations");
			_alreadyFetchedLocations = info.GetBoolean("_alreadyFetchedLocations");

			_users = (EPICCentralDL.CollectionClasses.UserCollection)info.GetValue("_users", typeof(EPICCentralDL.CollectionClasses.UserCollection));
			_alwaysFetchUsers = info.GetBoolean("_alwaysFetchUsers");
			_alreadyFetchedUsers = info.GetBoolean("_alreadyFetchedUsers");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedContacts = (_contacts.Count > 0);
			_alreadyFetchedLocations = (_locations.Count > 0);
			_alreadyFetchedUsers = (_users.Count > 0);
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
				case "Contacts":
					toReturn.Add(Relations.ContactEntityUsingOrganizationId);
					break;
				case "Locations":
					toReturn.Add(Relations.LocationEntityUsingOrganizationId);
					break;
				case "Users":
					toReturn.Add(Relations.UserEntityUsingOrganizationId);
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
			info.AddValue("_contacts", (!this.MarkedForDeletion?_contacts:null));
			info.AddValue("_alwaysFetchContacts", _alwaysFetchContacts);
			info.AddValue("_alreadyFetchedContacts", _alreadyFetchedContacts);
			info.AddValue("_locations", (!this.MarkedForDeletion?_locations:null));
			info.AddValue("_alwaysFetchLocations", _alwaysFetchLocations);
			info.AddValue("_alreadyFetchedLocations", _alreadyFetchedLocations);
			info.AddValue("_users", (!this.MarkedForDeletion?_users:null));
			info.AddValue("_alwaysFetchUsers", _alwaysFetchUsers);
			info.AddValue("_alreadyFetchedUsers", _alreadyFetchedUsers);

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
				case "Contacts":
					_alreadyFetchedContacts = true;
					if(entity!=null)
					{
						this.Contacts.Add((ContactEntity)entity);
					}
					break;
				case "Locations":
					_alreadyFetchedLocations = true;
					if(entity!=null)
					{
						this.Locations.Add((LocationEntity)entity);
					}
					break;
				case "Users":
					_alreadyFetchedUsers = true;
					if(entity!=null)
					{
						this.Users.Add((UserEntity)entity);
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
				case "Contacts":
					_contacts.Add((ContactEntity)relatedEntity);
					break;
				case "Locations":
					_locations.Add((LocationEntity)relatedEntity);
					break;
				case "Users":
					_users.Add((UserEntity)relatedEntity);
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
				case "Contacts":
					this.PerformRelatedEntityRemoval(_contacts, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Locations":
					this.PerformRelatedEntityRemoval(_locations, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Users":
					this.PerformRelatedEntityRemoval(_users, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(_contacts);
			toReturn.Add(_locations);
			toReturn.Add(_users);

			return toReturn;
		}


		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="organizationId">PK value for Organization which data should be fetched into this Organization object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 organizationId)
		{
			return FetchUsingPK(organizationId, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="organizationId">PK value for Organization which data should be fetched into this Organization object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 organizationId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(organizationId, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="organizationId">PK value for Organization which data should be fetched into this Organization object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 organizationId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(organizationId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="organizationId">PK value for Organization which data should be fetched into this Organization object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 organizationId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(organizationId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.OrganizationId, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new OrganizationRelations().GetAllRelations();
		}

		/// <summary> Retrieves all related entities of type 'ContactEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'ContactEntity'</returns>
		public EPICCentralDL.CollectionClasses.ContactCollection GetMultiContacts(bool forceFetch)
		{
			return GetMultiContacts(forceFetch, _contacts.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ContactEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'ContactEntity'</returns>
		public EPICCentralDL.CollectionClasses.ContactCollection GetMultiContacts(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiContacts(forceFetch, _contacts.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'ContactEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.ContactCollection GetMultiContacts(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiContacts(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ContactEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.ContactCollection GetMultiContacts(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedContacts || forceFetch || _alwaysFetchContacts) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_contacts);
				_contacts.SuppressClearInGetMulti=!forceFetch;
				_contacts.EntityFactoryToUse = entityFactoryToUse;
				_contacts.GetMultiManyToOne(this, filter);
				_contacts.SuppressClearInGetMulti=false;
				_alreadyFetchedContacts = true;
			}
			return _contacts;
		}

		/// <summary> Sets the collection parameters for the collection for 'Contacts'. These settings will be taken into account
		/// when the property Contacts is requested or GetMultiContacts is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersContacts(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_contacts.SortClauses=sortClauses;
			_contacts.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'LocationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'LocationEntity'</returns>
		public EPICCentralDL.CollectionClasses.LocationCollection GetMultiLocations(bool forceFetch)
		{
			return GetMultiLocations(forceFetch, _locations.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'LocationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'LocationEntity'</returns>
		public EPICCentralDL.CollectionClasses.LocationCollection GetMultiLocations(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiLocations(forceFetch, _locations.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'LocationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.LocationCollection GetMultiLocations(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiLocations(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'LocationEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.LocationCollection GetMultiLocations(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedLocations || forceFetch || _alwaysFetchLocations) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_locations);
				_locations.SuppressClearInGetMulti=!forceFetch;
				_locations.EntityFactoryToUse = entityFactoryToUse;
				_locations.GetMultiManyToOne(this, filter);
				_locations.SuppressClearInGetMulti=false;
				_alreadyFetchedLocations = true;
			}
			return _locations;
		}

		/// <summary> Sets the collection parameters for the collection for 'Locations'. These settings will be taken into account
		/// when the property Locations is requested or GetMultiLocations is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersLocations(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_locations.SortClauses=sortClauses;
			_locations.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'UserEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'UserEntity'</returns>
		public EPICCentralDL.CollectionClasses.UserCollection GetMultiUsers(bool forceFetch)
		{
			return GetMultiUsers(forceFetch, _users.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'UserEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'UserEntity'</returns>
		public EPICCentralDL.CollectionClasses.UserCollection GetMultiUsers(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiUsers(forceFetch, _users.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'UserEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.UserCollection GetMultiUsers(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiUsers(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'UserEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.UserCollection GetMultiUsers(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedUsers || forceFetch || _alwaysFetchUsers) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_users);
				_users.SuppressClearInGetMulti=!forceFetch;
				_users.EntityFactoryToUse = entityFactoryToUse;
				_users.GetMultiManyToOne(this, filter);
				_users.SuppressClearInGetMulti=false;
				_alreadyFetchedUsers = true;
			}
			return _users;
		}

		/// <summary> Sets the collection parameters for the collection for 'Users'. These settings will be taken into account
		/// when the property Users is requested or GetMultiUsers is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersUsers(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_users.SortClauses=sortClauses;
			_users.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Contacts", _contacts);
			toReturn.Add("Locations", _locations);
			toReturn.Add("Users", _users);
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
		/// <param name="organizationId">PK value for Organization which data should be fetched into this Organization object</param>
		/// <param name="validator">The validator object for this OrganizationEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 organizationId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(organizationId, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{

			_contacts = new EPICCentralDL.CollectionClasses.ContactCollection();
			_contacts.SetContainingEntityInfo(this, "Organization");

			_locations = new EPICCentralDL.CollectionClasses.LocationCollection();
			_locations.SetContainingEntityInfo(this, "Organization");

			_users = new EPICCentralDL.CollectionClasses.UserCollection();
			_users.SetContainingEntityInfo(this, "Organization");
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
			_fieldsCustomProperties.Add("OrganizationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("OrganizationType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("UniqueIdentifier", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="organizationId">PK value for Organization which data should be fetched into this Organization object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 organizationId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)OrganizationFieldIndex.OrganizationId].ForcedCurrentValueWrite(organizationId);
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
			return DAOFactory.CreateOrganizationDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new OrganizationEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static OrganizationRelations Relations
		{
			get	{ return new OrganizationRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Contact' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathContacts
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.ContactCollection(), (IEntityRelation)GetRelationsForField("Contacts")[0], (int)EPICCentralDL.EntityType.OrganizationEntity, (int)EPICCentralDL.EntityType.ContactEntity, 0, null, null, null, "Contacts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Location' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathLocations
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.LocationCollection(), (IEntityRelation)GetRelationsForField("Locations")[0], (int)EPICCentralDL.EntityType.OrganizationEntity, (int)EPICCentralDL.EntityType.LocationEntity, 0, null, null, null, "Locations", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'User' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathUsers
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.UserCollection(), (IEntityRelation)GetRelationsForField("Users")[0], (int)EPICCentralDL.EntityType.OrganizationEntity, (int)EPICCentralDL.EntityType.UserEntity, 0, null, null, null, "Users", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
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

		/// <summary> The OrganizationId property of the Entity Organization<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Organization"."OrganizationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 OrganizationId
		{
			get { return (System.Int32)GetValue((int)OrganizationFieldIndex.OrganizationId, true); }
			set	{ SetValue((int)OrganizationFieldIndex.OrganizationId, value, true); }
		}

		/// <summary> The OrganizationType property of the Entity Organization<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Organization"."OrganizationType"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual EPICCentralDL.Customization.OrganizationType OrganizationType
		{
			get { return (EPICCentralDL.Customization.OrganizationType)GetValue((int)OrganizationFieldIndex.OrganizationType, true); }
			set	{ SetValue((int)OrganizationFieldIndex.OrganizationType, value, true); }
		}

		/// <summary> The Name property of the Entity Organization<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Organization"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 128<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)OrganizationFieldIndex.Name, true); }
			set	{ SetValue((int)OrganizationFieldIndex.Name, value, true); }
		}

		/// <summary> The UniqueIdentifier property of the Entity Organization<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Organization"."UniqueIdentifier"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 48<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String UniqueIdentifier
		{
			get { return (System.String)GetValue((int)OrganizationFieldIndex.UniqueIdentifier, true); }
			set	{ SetValue((int)OrganizationFieldIndex.UniqueIdentifier, value, true); }
		}

		/// <summary> The IsActive property of the Entity Organization<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Organization"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)OrganizationFieldIndex.IsActive, true); }
			set	{ SetValue((int)OrganizationFieldIndex.IsActive, value, true); }
		}

		/// <summary> Retrieves all related entities of type 'ContactEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiContacts()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.ContactCollection Contacts
		{
			get	{ return GetMultiContacts(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Contacts. When set to true, Contacts is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Contacts is accessed. You can always execute/ a forced fetch by calling GetMultiContacts(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchContacts
		{
			get	{ return _alwaysFetchContacts; }
			set	{ _alwaysFetchContacts = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property Contacts already has been fetched. Setting this property to false when Contacts has been fetched
		/// will clear the Contacts collection well. Setting this property to true while Contacts hasn't been fetched disables lazy loading for Contacts</summary>
		[Browsable(false)]
		public bool AlreadyFetchedContacts
		{
			get { return _alreadyFetchedContacts;}
			set 
			{
				if(_alreadyFetchedContacts && !value && (_contacts != null))
				{
					_contacts.Clear();
				}
				_alreadyFetchedContacts = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'LocationEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiLocations()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.LocationCollection Locations
		{
			get	{ return GetMultiLocations(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Locations. When set to true, Locations is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Locations is accessed. You can always execute/ a forced fetch by calling GetMultiLocations(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchLocations
		{
			get	{ return _alwaysFetchLocations; }
			set	{ _alwaysFetchLocations = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property Locations already has been fetched. Setting this property to false when Locations has been fetched
		/// will clear the Locations collection well. Setting this property to true while Locations hasn't been fetched disables lazy loading for Locations</summary>
		[Browsable(false)]
		public bool AlreadyFetchedLocations
		{
			get { return _alreadyFetchedLocations;}
			set 
			{
				if(_alreadyFetchedLocations && !value && (_locations != null))
				{
					_locations.Clear();
				}
				_alreadyFetchedLocations = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'UserEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiUsers()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.UserCollection Users
		{
			get	{ return GetMultiUsers(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Users. When set to true, Users is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Users is accessed. You can always execute/ a forced fetch by calling GetMultiUsers(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchUsers
		{
			get	{ return _alwaysFetchUsers; }
			set	{ _alwaysFetchUsers = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property Users already has been fetched. Setting this property to false when Users has been fetched
		/// will clear the Users collection well. Setting this property to true while Users hasn't been fetched disables lazy loading for Users</summary>
		[Browsable(false)]
		public bool AlreadyFetchedUsers
		{
			get { return _alreadyFetchedUsers;}
			set 
			{
				if(_alreadyFetchedUsers && !value && (_users != null))
				{
					_users.Clear();
				}
				_alreadyFetchedUsers = value;
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
			get { return (int)EPICCentralDL.EntityType.OrganizationEntity; }
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
