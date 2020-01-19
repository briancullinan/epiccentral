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

	/// <summary>Entity class which represents the entity 'ExceptionLog'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ExceptionLogEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private DeviceEntity _device;
		private bool	_alwaysFetchDevice, _alreadyFetchedDevice, _deviceReturnsNewIfNotFound;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Device</summary>
			public static readonly string Device = "Device";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ExceptionLogEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public ExceptionLogEntity() :base("ExceptionLogEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="exceptionLogId">PK value for ExceptionLog which data should be fetched into this ExceptionLog object</param>
		public ExceptionLogEntity(System.Int64 exceptionLogId):base("ExceptionLogEntity")
		{
			InitClassFetch(exceptionLogId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="exceptionLogId">PK value for ExceptionLog which data should be fetched into this ExceptionLog object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public ExceptionLogEntity(System.Int64 exceptionLogId, IPrefetchPath prefetchPathToUse):base("ExceptionLogEntity")
		{
			InitClassFetch(exceptionLogId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="exceptionLogId">PK value for ExceptionLog which data should be fetched into this ExceptionLog object</param>
		/// <param name="validator">The custom validator object for this ExceptionLogEntity</param>
		public ExceptionLogEntity(System.Int64 exceptionLogId, IValidator validator):base("ExceptionLogEntity")
		{
			InitClassFetch(exceptionLogId, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ExceptionLogEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_device = (DeviceEntity)info.GetValue("_device", typeof(DeviceEntity));
			if(_device!=null)
			{
				_device.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_deviceReturnsNewIfNotFound = info.GetBoolean("_deviceReturnsNewIfNotFound");
			_alwaysFetchDevice = info.GetBoolean("_alwaysFetchDevice");
			_alreadyFetchedDevice = info.GetBoolean("_alreadyFetchedDevice");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		
		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((ExceptionLogFieldIndex)fieldIndex)
			{
				case ExceptionLogFieldIndex.DeviceId:
					DesetupSyncDevice(true, false);
					_alreadyFetchedDevice = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedDevice = (_device != null);
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
				case "Device":
					toReturn.Add(Relations.DeviceEntityUsingDeviceId);
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
			info.AddValue("_device", (!this.MarkedForDeletion?_device:null));
			info.AddValue("_deviceReturnsNewIfNotFound", _deviceReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchDevice", _alwaysFetchDevice);
			info.AddValue("_alreadyFetchedDevice", _alreadyFetchedDevice);

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
				case "Device":
					_alreadyFetchedDevice = true;
					this.Device = (DeviceEntity)entity;
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
				case "Device":
					SetupSyncDevice(relatedEntity);
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
				case "Device":
					DesetupSyncDevice(false, true);
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
			if(_device!=null)
			{
				toReturn.Add(_device);
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
		/// <param name="exceptionLogId">PK value for ExceptionLog which data should be fetched into this ExceptionLog object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 exceptionLogId)
		{
			return FetchUsingPK(exceptionLogId, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="exceptionLogId">PK value for ExceptionLog which data should be fetched into this ExceptionLog object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 exceptionLogId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(exceptionLogId, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="exceptionLogId">PK value for ExceptionLog which data should be fetched into this ExceptionLog object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 exceptionLogId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(exceptionLogId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="exceptionLogId">PK value for ExceptionLog which data should be fetched into this ExceptionLog object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 exceptionLogId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(exceptionLogId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.ExceptionLogId, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new ExceptionLogRelations().GetAllRelations();
		}

		/// <summary> Retrieves the related entity of type 'DeviceEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'DeviceEntity' which is related to this entity.</returns>
		public DeviceEntity GetSingleDevice()
		{
			return GetSingleDevice(false);
		}

		/// <summary> Retrieves the related entity of type 'DeviceEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'DeviceEntity' which is related to this entity.</returns>
		public virtual DeviceEntity GetSingleDevice(bool forceFetch)
		{
			if( ( !_alreadyFetchedDevice || forceFetch || _alwaysFetchDevice) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.DeviceEntityUsingDeviceId);
				DeviceEntity newEntity = new DeviceEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.DeviceId);
				}
				if(fetchResult)
				{
					newEntity = (DeviceEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_deviceReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.Device = newEntity;
				_alreadyFetchedDevice = fetchResult;
			}
			return _device;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Device", _device);
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
		/// <param name="exceptionLogId">PK value for ExceptionLog which data should be fetched into this ExceptionLog object</param>
		/// <param name="validator">The validator object for this ExceptionLogEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int64 exceptionLogId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(exceptionLogId, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{
			_deviceReturnsNewIfNotFound = false;
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
			_fieldsCustomProperties.Add("ExceptionLogId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("DeviceId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("RemoteExceptionLogId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Title", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("Message", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("StackTrace", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("LogTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("User", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("FormName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("MachineName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("MachineOS", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ApplicationVersion", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("CLRVersion", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("MemoryUsage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ReceivedTime", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _device</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDevice(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _device, new PropertyChangedEventHandler( OnDevicePropertyChanged ), "Device", EPICCentralDL.RelationClasses.StaticExceptionLogRelations.DeviceEntityUsingDeviceIdStatic, true, signalRelatedEntity, "ExceptionLogs", resetFKFields, new int[] { (int)ExceptionLogFieldIndex.DeviceId } );		
			_device = null;
		}
		
		/// <summary> setups the sync logic for member _device</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDevice(IEntityCore relatedEntity)
		{
			if(_device!=relatedEntity)
			{		
				DesetupSyncDevice(true, true);
				_device = (DeviceEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _device, new PropertyChangedEventHandler( OnDevicePropertyChanged ), "Device", EPICCentralDL.RelationClasses.StaticExceptionLogRelations.DeviceEntityUsingDeviceIdStatic, true, ref _alreadyFetchedDevice, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDevicePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="exceptionLogId">PK value for ExceptionLog which data should be fetched into this ExceptionLog object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int64 exceptionLogId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)ExceptionLogFieldIndex.ExceptionLogId].ForcedCurrentValueWrite(exceptionLogId);
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
			return DAOFactory.CreateExceptionLogDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new ExceptionLogEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static ExceptionLogRelations Relations
		{
			get	{ return new ExceptionLogRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Device'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathDevice
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.DeviceCollection(), (IEntityRelation)GetRelationsForField("Device")[0], (int)EPICCentralDL.EntityType.ExceptionLogEntity, (int)EPICCentralDL.EntityType.DeviceEntity, 0, null, null, null, "Device", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The ExceptionLogId property of the Entity ExceptionLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ExceptionLog"."ExceptionLogId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ExceptionLogId
		{
			get { return (System.Int64)GetValue((int)ExceptionLogFieldIndex.ExceptionLogId, true); }
			set	{ SetValue((int)ExceptionLogFieldIndex.ExceptionLogId, value, true); }
		}

		/// <summary> The DeviceId property of the Entity ExceptionLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ExceptionLog"."DeviceId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 DeviceId
		{
			get { return (System.Int32)GetValue((int)ExceptionLogFieldIndex.DeviceId, true); }
			set	{ SetValue((int)ExceptionLogFieldIndex.DeviceId, value, true); }
		}

		/// <summary> The RemoteExceptionLogId property of the Entity ExceptionLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ExceptionLog"."RemoteExceptionLogId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 RemoteExceptionLogId
		{
			get { return (System.Int64)GetValue((int)ExceptionLogFieldIndex.RemoteExceptionLogId, true); }
			set	{ SetValue((int)ExceptionLogFieldIndex.RemoteExceptionLogId, value, true); }
		}

		/// <summary> The Title property of the Entity ExceptionLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ExceptionLog"."Title"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Title
		{
			get { return (System.String)GetValue((int)ExceptionLogFieldIndex.Title, true); }
			set	{ SetValue((int)ExceptionLogFieldIndex.Title, value, true); }
		}

		/// <summary> The Message property of the Entity ExceptionLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ExceptionLog"."Message"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 1024<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Message
		{
			get { return (System.String)GetValue((int)ExceptionLogFieldIndex.Message, true); }
			set	{ SetValue((int)ExceptionLogFieldIndex.Message, value, true); }
		}

		/// <summary> The StackTrace property of the Entity ExceptionLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ExceptionLog"."StackTrace"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String StackTrace
		{
			get { return (System.String)GetValue((int)ExceptionLogFieldIndex.StackTrace, true); }
			set	{ SetValue((int)ExceptionLogFieldIndex.StackTrace, value, true); }
		}

		/// <summary> The LogTime property of the Entity ExceptionLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ExceptionLog"."LogTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime LogTime
		{
			get { return (System.DateTime)GetValue((int)ExceptionLogFieldIndex.LogTime, true); }
			set	{ SetValue((int)ExceptionLogFieldIndex.LogTime, value, true); }
		}

		/// <summary> The User property of the Entity ExceptionLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ExceptionLog"."User"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String User
		{
			get { return (System.String)GetValue((int)ExceptionLogFieldIndex.User, true); }
			set	{ SetValue((int)ExceptionLogFieldIndex.User, value, true); }
		}

		/// <summary> The FormName property of the Entity ExceptionLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ExceptionLog"."FormName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String FormName
		{
			get { return (System.String)GetValue((int)ExceptionLogFieldIndex.FormName, true); }
			set	{ SetValue((int)ExceptionLogFieldIndex.FormName, value, true); }
		}

		/// <summary> The MachineName property of the Entity ExceptionLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ExceptionLog"."MachineName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MachineName
		{
			get { return (System.String)GetValue((int)ExceptionLogFieldIndex.MachineName, true); }
			set	{ SetValue((int)ExceptionLogFieldIndex.MachineName, value, true); }
		}

		/// <summary> The MachineOS property of the Entity ExceptionLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ExceptionLog"."MachineOS"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MachineOS
		{
			get { return (System.String)GetValue((int)ExceptionLogFieldIndex.MachineOS, true); }
			set	{ SetValue((int)ExceptionLogFieldIndex.MachineOS, value, true); }
		}

		/// <summary> The ApplicationVersion property of the Entity ExceptionLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ExceptionLog"."ApplicationVersion"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 40<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ApplicationVersion
		{
			get { return (System.String)GetValue((int)ExceptionLogFieldIndex.ApplicationVersion, true); }
			set	{ SetValue((int)ExceptionLogFieldIndex.ApplicationVersion, value, true); }
		}

		/// <summary> The CLRVersion property of the Entity ExceptionLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ExceptionLog"."CLRVersion"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CLRVersion
		{
			get { return (System.String)GetValue((int)ExceptionLogFieldIndex.CLRVersion, true); }
			set	{ SetValue((int)ExceptionLogFieldIndex.CLRVersion, value, true); }
		}

		/// <summary> The MemoryUsage property of the Entity ExceptionLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ExceptionLog"."MemoryUsage"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 40<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MemoryUsage
		{
			get { return (System.String)GetValue((int)ExceptionLogFieldIndex.MemoryUsage, true); }
			set	{ SetValue((int)ExceptionLogFieldIndex.MemoryUsage, value, true); }
		}

		/// <summary> The ReceivedTime property of the Entity ExceptionLog<br/><br/></summary>
		/// <remarks>Mapped on  table field: "ExceptionLog"."ReceivedTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime ReceivedTime
		{
			get { return (System.DateTime)GetValue((int)ExceptionLogFieldIndex.ReceivedTime, true); }
			set	{ SetValue((int)ExceptionLogFieldIndex.ReceivedTime, value, true); }
		}


		/// <summary> Gets / sets related entity of type 'DeviceEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleDevice()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual DeviceEntity Device
		{
			get	{ return GetSingleDevice(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncDevice(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "ExceptionLogs", "Device", _device, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Device. When set to true, Device is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Device is accessed. You can always execute a forced fetch by calling GetSingleDevice(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchDevice
		{
			get	{ return _alwaysFetchDevice; }
			set	{ _alwaysFetchDevice = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property Device already has been fetched. Setting this property to false when Device has been fetched
		/// will set Device to null as well. Setting this property to true while Device hasn't been fetched disables lazy loading for Device</summary>
		[Browsable(false)]
		public bool AlreadyFetchedDevice
		{
			get { return _alreadyFetchedDevice;}
			set 
			{
				if(_alreadyFetchedDevice && !value)
				{
					this.Device = null;
				}
				_alreadyFetchedDevice = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Device is not found
		/// in the database. When set to true, Device will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: false.</summary>
		[Browsable(false)]
		public bool DeviceReturnsNewIfNotFound
		{
			get	{ return _deviceReturnsNewIfNotFound; }
			set { _deviceReturnsNewIfNotFound = value; }	
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
			get { return (int)EPICCentralDL.EntityType.ExceptionLogEntity; }
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
