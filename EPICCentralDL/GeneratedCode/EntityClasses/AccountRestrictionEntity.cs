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

	/// <summary>Entity class which represents the entity 'AccountRestriction'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AccountRestrictionEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EPICCentralDL.CollectionClasses.UserAccountRestrictionCollection	_userAccountRestrictions;
		private bool	_alwaysFetchUserAccountRestrictions, _alreadyFetchedUserAccountRestrictions;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name UserAccountRestrictions</summary>
			public static readonly string UserAccountRestrictions = "UserAccountRestrictions";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AccountRestrictionEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public AccountRestrictionEntity() :base("AccountRestrictionEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="accountRestrictionId">PK value for AccountRestriction which data should be fetched into this AccountRestriction object</param>
		public AccountRestrictionEntity(System.Int32 accountRestrictionId):base("AccountRestrictionEntity")
		{
			InitClassFetch(accountRestrictionId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="accountRestrictionId">PK value for AccountRestriction which data should be fetched into this AccountRestriction object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public AccountRestrictionEntity(System.Int32 accountRestrictionId, IPrefetchPath prefetchPathToUse):base("AccountRestrictionEntity")
		{
			InitClassFetch(accountRestrictionId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="accountRestrictionId">PK value for AccountRestriction which data should be fetched into this AccountRestriction object</param>
		/// <param name="validator">The custom validator object for this AccountRestrictionEntity</param>
		public AccountRestrictionEntity(System.Int32 accountRestrictionId, IValidator validator):base("AccountRestrictionEntity")
		{
			InitClassFetch(accountRestrictionId, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected AccountRestrictionEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_userAccountRestrictions = (EPICCentralDL.CollectionClasses.UserAccountRestrictionCollection)info.GetValue("_userAccountRestrictions", typeof(EPICCentralDL.CollectionClasses.UserAccountRestrictionCollection));
			_alwaysFetchUserAccountRestrictions = info.GetBoolean("_alwaysFetchUserAccountRestrictions");
			_alreadyFetchedUserAccountRestrictions = info.GetBoolean("_alreadyFetchedUserAccountRestrictions");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedUserAccountRestrictions = (_userAccountRestrictions.Count > 0);
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
				case "UserAccountRestrictions":
					toReturn.Add(Relations.UserAccountRestrictionEntityUsingAccountRestrictionId);
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
			info.AddValue("_userAccountRestrictions", (!this.MarkedForDeletion?_userAccountRestrictions:null));
			info.AddValue("_alwaysFetchUserAccountRestrictions", _alwaysFetchUserAccountRestrictions);
			info.AddValue("_alreadyFetchedUserAccountRestrictions", _alreadyFetchedUserAccountRestrictions);

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
				case "UserAccountRestrictions":
					_alreadyFetchedUserAccountRestrictions = true;
					if(entity!=null)
					{
						this.UserAccountRestrictions.Add((UserAccountRestrictionEntity)entity);
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
				case "UserAccountRestrictions":
					_userAccountRestrictions.Add((UserAccountRestrictionEntity)relatedEntity);
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
				case "UserAccountRestrictions":
					this.PerformRelatedEntityRemoval(_userAccountRestrictions, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(_userAccountRestrictions);

			return toReturn;
		}


		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="accountRestrictionId">PK value for AccountRestriction which data should be fetched into this AccountRestriction object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 accountRestrictionId)
		{
			return FetchUsingPK(accountRestrictionId, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="accountRestrictionId">PK value for AccountRestriction which data should be fetched into this AccountRestriction object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 accountRestrictionId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(accountRestrictionId, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="accountRestrictionId">PK value for AccountRestriction which data should be fetched into this AccountRestriction object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 accountRestrictionId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(accountRestrictionId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="accountRestrictionId">PK value for AccountRestriction which data should be fetched into this AccountRestriction object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 accountRestrictionId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(accountRestrictionId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.AccountRestrictionId, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new AccountRestrictionRelations().GetAllRelations();
		}

		/// <summary> Retrieves all related entities of type 'UserAccountRestrictionEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'UserAccountRestrictionEntity'</returns>
		public EPICCentralDL.CollectionClasses.UserAccountRestrictionCollection GetMultiUserAccountRestrictions(bool forceFetch)
		{
			return GetMultiUserAccountRestrictions(forceFetch, _userAccountRestrictions.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'UserAccountRestrictionEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'UserAccountRestrictionEntity'</returns>
		public EPICCentralDL.CollectionClasses.UserAccountRestrictionCollection GetMultiUserAccountRestrictions(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiUserAccountRestrictions(forceFetch, _userAccountRestrictions.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'UserAccountRestrictionEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.UserAccountRestrictionCollection GetMultiUserAccountRestrictions(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiUserAccountRestrictions(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'UserAccountRestrictionEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.UserAccountRestrictionCollection GetMultiUserAccountRestrictions(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedUserAccountRestrictions || forceFetch || _alwaysFetchUserAccountRestrictions) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_userAccountRestrictions);
				_userAccountRestrictions.SuppressClearInGetMulti=!forceFetch;
				_userAccountRestrictions.EntityFactoryToUse = entityFactoryToUse;
				_userAccountRestrictions.GetMultiManyToOne(this, null, filter);
				_userAccountRestrictions.SuppressClearInGetMulti=false;
				_alreadyFetchedUserAccountRestrictions = true;
			}
			return _userAccountRestrictions;
		}

		/// <summary> Sets the collection parameters for the collection for 'UserAccountRestrictions'. These settings will be taken into account
		/// when the property UserAccountRestrictions is requested or GetMultiUserAccountRestrictions is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersUserAccountRestrictions(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_userAccountRestrictions.SortClauses=sortClauses;
			_userAccountRestrictions.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("UserAccountRestrictions", _userAccountRestrictions);
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
		/// <param name="accountRestrictionId">PK value for AccountRestriction which data should be fetched into this AccountRestriction object</param>
		/// <param name="validator">The validator object for this AccountRestrictionEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 accountRestrictionId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(accountRestrictionId, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{

			_userAccountRestrictions = new EPICCentralDL.CollectionClasses.UserAccountRestrictionCollection();
			_userAccountRestrictions.SetContainingEntityInfo(this, "AccountRestriction");
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
			_fieldsCustomProperties.Add("AccountRestrictionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AccountRestrictionType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("RestrictionKey", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("EmailAddress", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Parameters", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IPAddress", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("CreatedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("CreationTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("RemovalTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="accountRestrictionId">PK value for AccountRestriction which data should be fetched into this AccountRestriction object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 accountRestrictionId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)AccountRestrictionFieldIndex.AccountRestrictionId].ForcedCurrentValueWrite(accountRestrictionId);
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
			return DAOFactory.CreateAccountRestrictionDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new AccountRestrictionEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static AccountRestrictionRelations Relations
		{
			get	{ return new AccountRestrictionRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'UserAccountRestriction' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathUserAccountRestrictions
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.UserAccountRestrictionCollection(), (IEntityRelation)GetRelationsForField("UserAccountRestrictions")[0], (int)EPICCentralDL.EntityType.AccountRestrictionEntity, (int)EPICCentralDL.EntityType.UserAccountRestrictionEntity, 0, null, null, null, "UserAccountRestrictions", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
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

		/// <summary> The AccountRestrictionId property of the Entity AccountRestriction<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AccountRestriction"."AccountRestrictionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 AccountRestrictionId
		{
			get { return (System.Int32)GetValue((int)AccountRestrictionFieldIndex.AccountRestrictionId, true); }
			set	{ SetValue((int)AccountRestrictionFieldIndex.AccountRestrictionId, value, true); }
		}

		/// <summary> The AccountRestrictionType property of the Entity AccountRestriction<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AccountRestriction"."AccountRestrictionType"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual EPICCentralDL.Customization.AccountRestrictionType AccountRestrictionType
		{
			get { return (EPICCentralDL.Customization.AccountRestrictionType)GetValue((int)AccountRestrictionFieldIndex.AccountRestrictionType, true); }
			set	{ SetValue((int)AccountRestrictionFieldIndex.AccountRestrictionType, value, true); }
		}

		/// <summary> The RestrictionKey property of the Entity AccountRestriction<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AccountRestriction"."RestrictionKey"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 128<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String RestrictionKey
		{
			get { return (System.String)GetValue((int)AccountRestrictionFieldIndex.RestrictionKey, true); }
			set	{ SetValue((int)AccountRestrictionFieldIndex.RestrictionKey, value, true); }
		}

		/// <summary> The EmailAddress property of the Entity AccountRestriction<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AccountRestriction"."EmailAddress"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 128<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String EmailAddress
		{
			get { return (System.String)GetValue((int)AccountRestrictionFieldIndex.EmailAddress, true); }
			set	{ SetValue((int)AccountRestrictionFieldIndex.EmailAddress, value, true); }
		}

		/// <summary> The Parameters property of the Entity AccountRestriction<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AccountRestriction"."Parameters"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 128<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Parameters
		{
			get { return (System.String)GetValue((int)AccountRestrictionFieldIndex.Parameters, true); }
			set	{ SetValue((int)AccountRestrictionFieldIndex.Parameters, value, true); }
		}

		/// <summary> The IPAddress property of the Entity AccountRestriction<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AccountRestriction"."IPAddress"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 32<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String IPAddress
		{
			get { return (System.String)GetValue((int)AccountRestrictionFieldIndex.IPAddress, true); }
			set	{ SetValue((int)AccountRestrictionFieldIndex.IPAddress, value, true); }
		}

		/// <summary> The CreatedBy property of the Entity AccountRestriction<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AccountRestriction"."CreatedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> CreatedBy
		{
			get { return (Nullable<System.Int32>)GetValue((int)AccountRestrictionFieldIndex.CreatedBy, false); }
			set	{ SetValue((int)AccountRestrictionFieldIndex.CreatedBy, value, true); }
		}

		/// <summary> The CreationTime property of the Entity AccountRestriction<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AccountRestriction"."CreationTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CreationTime
		{
			get { return (System.DateTime)GetValue((int)AccountRestrictionFieldIndex.CreationTime, true); }
			set	{ SetValue((int)AccountRestrictionFieldIndex.CreationTime, value, true); }
		}

		/// <summary> The RemovalTime property of the Entity AccountRestriction<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AccountRestriction"."RemovalTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> RemovalTime
		{
			get { return (Nullable<System.DateTime>)GetValue((int)AccountRestrictionFieldIndex.RemovalTime, false); }
			set	{ SetValue((int)AccountRestrictionFieldIndex.RemovalTime, value, true); }
		}

		/// <summary> The IsActive property of the Entity AccountRestriction<br/><br/></summary>
		/// <remarks>Mapped on  table field: "AccountRestriction"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)AccountRestrictionFieldIndex.IsActive, true); }
			set	{ SetValue((int)AccountRestrictionFieldIndex.IsActive, value, true); }
		}

		/// <summary> Retrieves all related entities of type 'UserAccountRestrictionEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiUserAccountRestrictions()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.UserAccountRestrictionCollection UserAccountRestrictions
		{
			get	{ return GetMultiUserAccountRestrictions(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for UserAccountRestrictions. When set to true, UserAccountRestrictions is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time UserAccountRestrictions is accessed. You can always execute/ a forced fetch by calling GetMultiUserAccountRestrictions(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchUserAccountRestrictions
		{
			get	{ return _alwaysFetchUserAccountRestrictions; }
			set	{ _alwaysFetchUserAccountRestrictions = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property UserAccountRestrictions already has been fetched. Setting this property to false when UserAccountRestrictions has been fetched
		/// will clear the UserAccountRestrictions collection well. Setting this property to true while UserAccountRestrictions hasn't been fetched disables lazy loading for UserAccountRestrictions</summary>
		[Browsable(false)]
		public bool AlreadyFetchedUserAccountRestrictions
		{
			get { return _alreadyFetchedUserAccountRestrictions;}
			set 
			{
				if(_alreadyFetchedUserAccountRestrictions && !value && (_userAccountRestrictions != null))
				{
					_userAccountRestrictions.Clear();
				}
				_alreadyFetchedUserAccountRestrictions = value;
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
			get { return (int)EPICCentralDL.EntityType.AccountRestrictionEntity; }
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
