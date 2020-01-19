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

	/// <summary>Entity class which represents the entity 'CreditCard'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CreditCardEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EPICCentralDL.CollectionClasses.UserCreditCardCollection	_userCreditCards;
		private bool	_alwaysFetchUserCreditCards, _alreadyFetchedUserCreditCards;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name UserCreditCards</summary>
			public static readonly string UserCreditCards = "UserCreditCards";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CreditCardEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public CreditCardEntity() :base("CreditCardEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="creditCardId">PK value for CreditCard which data should be fetched into this CreditCard object</param>
		public CreditCardEntity(System.Int32 creditCardId):base("CreditCardEntity")
		{
			InitClassFetch(creditCardId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="creditCardId">PK value for CreditCard which data should be fetched into this CreditCard object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public CreditCardEntity(System.Int32 creditCardId, IPrefetchPath prefetchPathToUse):base("CreditCardEntity")
		{
			InitClassFetch(creditCardId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="creditCardId">PK value for CreditCard which data should be fetched into this CreditCard object</param>
		/// <param name="validator">The custom validator object for this CreditCardEntity</param>
		public CreditCardEntity(System.Int32 creditCardId, IValidator validator):base("CreditCardEntity")
		{
			InitClassFetch(creditCardId, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected CreditCardEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_userCreditCards = (EPICCentralDL.CollectionClasses.UserCreditCardCollection)info.GetValue("_userCreditCards", typeof(EPICCentralDL.CollectionClasses.UserCreditCardCollection));
			_alwaysFetchUserCreditCards = info.GetBoolean("_alwaysFetchUserCreditCards");
			_alreadyFetchedUserCreditCards = info.GetBoolean("_alreadyFetchedUserCreditCards");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedUserCreditCards = (_userCreditCards.Count > 0);
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
				case "UserCreditCards":
					toReturn.Add(Relations.UserCreditCardEntityUsingCreditCardId);
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
			info.AddValue("_userCreditCards", (!this.MarkedForDeletion?_userCreditCards:null));
			info.AddValue("_alwaysFetchUserCreditCards", _alwaysFetchUserCreditCards);
			info.AddValue("_alreadyFetchedUserCreditCards", _alreadyFetchedUserCreditCards);

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
				case "UserCreditCards":
					_alreadyFetchedUserCreditCards = true;
					if(entity!=null)
					{
						this.UserCreditCards.Add((UserCreditCardEntity)entity);
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
				case "UserCreditCards":
					_userCreditCards.Add((UserCreditCardEntity)relatedEntity);
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
				case "UserCreditCards":
					this.PerformRelatedEntityRemoval(_userCreditCards, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(_userCreditCards);

			return toReturn;
		}


		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="creditCardId">PK value for CreditCard which data should be fetched into this CreditCard object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 creditCardId)
		{
			return FetchUsingPK(creditCardId, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="creditCardId">PK value for CreditCard which data should be fetched into this CreditCard object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 creditCardId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(creditCardId, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="creditCardId">PK value for CreditCard which data should be fetched into this CreditCard object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 creditCardId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(creditCardId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="creditCardId">PK value for CreditCard which data should be fetched into this CreditCard object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 creditCardId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(creditCardId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.CreditCardId, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new CreditCardRelations().GetAllRelations();
		}

		/// <summary> Retrieves all related entities of type 'UserCreditCardEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'UserCreditCardEntity'</returns>
		public EPICCentralDL.CollectionClasses.UserCreditCardCollection GetMultiUserCreditCards(bool forceFetch)
		{
			return GetMultiUserCreditCards(forceFetch, _userCreditCards.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'UserCreditCardEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'UserCreditCardEntity'</returns>
		public EPICCentralDL.CollectionClasses.UserCreditCardCollection GetMultiUserCreditCards(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiUserCreditCards(forceFetch, _userCreditCards.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'UserCreditCardEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.UserCreditCardCollection GetMultiUserCreditCards(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiUserCreditCards(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'UserCreditCardEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.UserCreditCardCollection GetMultiUserCreditCards(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedUserCreditCards || forceFetch || _alwaysFetchUserCreditCards) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_userCreditCards);
				_userCreditCards.SuppressClearInGetMulti=!forceFetch;
				_userCreditCards.EntityFactoryToUse = entityFactoryToUse;
				_userCreditCards.GetMultiManyToOne(this, null, filter);
				_userCreditCards.SuppressClearInGetMulti=false;
				_alreadyFetchedUserCreditCards = true;
			}
			return _userCreditCards;
		}

		/// <summary> Sets the collection parameters for the collection for 'UserCreditCards'. These settings will be taken into account
		/// when the property UserCreditCards is requested or GetMultiUserCreditCards is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersUserCreditCards(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_userCreditCards.SortClauses=sortClauses;
			_userCreditCards.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("UserCreditCards", _userCreditCards);
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
		/// <param name="creditCardId">PK value for CreditCard which data should be fetched into this CreditCard object</param>
		/// <param name="validator">The validator object for this CreditCardEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 creditCardId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(creditCardId, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{

			_userCreditCards = new EPICCentralDL.CollectionClasses.UserCreditCardCollection();
			_userCreditCards.SetContainingEntityInfo(this, "CreditCard");
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
			_fieldsCustomProperties.Add("CreditCardId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AuthorizeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AccountNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Address", fieldHashtable);
		}
		#endregion

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="creditCardId">PK value for CreditCard which data should be fetched into this CreditCard object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 creditCardId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)CreditCardFieldIndex.CreditCardId].ForcedCurrentValueWrite(creditCardId);
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
			return DAOFactory.CreateCreditCardDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new CreditCardEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static CreditCardRelations Relations
		{
			get	{ return new CreditCardRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'UserCreditCard' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathUserCreditCards
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.UserCreditCardCollection(), (IEntityRelation)GetRelationsForField("UserCreditCards")[0], (int)EPICCentralDL.EntityType.CreditCardEntity, (int)EPICCentralDL.EntityType.UserCreditCardEntity, 0, null, null, null, "UserCreditCards", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
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

		/// <summary> The CreditCardId property of the Entity CreditCard<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CreditCard"."CreditCardId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 CreditCardId
		{
			get { return (System.Int32)GetValue((int)CreditCardFieldIndex.CreditCardId, true); }
			set	{ SetValue((int)CreditCardFieldIndex.CreditCardId, value, true); }
		}

		/// <summary> The AuthorizeId property of the Entity CreditCard<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CreditCard"."AuthorizeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String AuthorizeId
		{
			get { return (System.String)GetValue((int)CreditCardFieldIndex.AuthorizeId, true); }
			set	{ SetValue((int)CreditCardFieldIndex.AuthorizeId, value, true); }
		}

		/// <summary> The FirstName property of the Entity CreditCard<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CreditCard"."FirstName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String FirstName
		{
			get { return (System.String)GetValue((int)CreditCardFieldIndex.FirstName, true); }
			set	{ SetValue((int)CreditCardFieldIndex.FirstName, value, true); }
		}

		/// <summary> The LastName property of the Entity CreditCard<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CreditCard"."LastName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String LastName
		{
			get { return (System.String)GetValue((int)CreditCardFieldIndex.LastName, true); }
			set	{ SetValue((int)CreditCardFieldIndex.LastName, value, true); }
		}

		/// <summary> The AccountNumber property of the Entity CreditCard<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CreditCard"."AccountNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): Char, 0, 0, 4<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AccountNumber
		{
			get { return (System.String)GetValue((int)CreditCardFieldIndex.AccountNumber, true); }
			set	{ SetValue((int)CreditCardFieldIndex.AccountNumber, value, true); }
		}

		/// <summary> The Address property of the Entity CreditCard<br/><br/></summary>
		/// <remarks>Mapped on  table field: "CreditCard"."Address"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 64<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Address
		{
			get { return (System.String)GetValue((int)CreditCardFieldIndex.Address, true); }
			set	{ SetValue((int)CreditCardFieldIndex.Address, value, true); }
		}

		/// <summary> Retrieves all related entities of type 'UserCreditCardEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiUserCreditCards()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.UserCreditCardCollection UserCreditCards
		{
			get	{ return GetMultiUserCreditCards(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for UserCreditCards. When set to true, UserCreditCards is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time UserCreditCards is accessed. You can always execute/ a forced fetch by calling GetMultiUserCreditCards(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchUserCreditCards
		{
			get	{ return _alwaysFetchUserCreditCards; }
			set	{ _alwaysFetchUserCreditCards = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property UserCreditCards already has been fetched. Setting this property to false when UserCreditCards has been fetched
		/// will clear the UserCreditCards collection well. Setting this property to true while UserCreditCards hasn't been fetched disables lazy loading for UserCreditCards</summary>
		[Browsable(false)]
		public bool AlreadyFetchedUserCreditCards
		{
			get { return _alreadyFetchedUserCreditCards;}
			set 
			{
				if(_alreadyFetchedUserCreditCards && !value && (_userCreditCards != null))
				{
					_userCreditCards.Clear();
				}
				_alreadyFetchedUserCreditCards = value;
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
			get { return (int)EPICCentralDL.EntityType.CreditCardEntity; }
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
