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

	/// <summary>Entity class which represents the entity 'DeviceStateTracking'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class DeviceStateTrackingEntity : CommonEntityBase
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
		static DeviceStateTrackingEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public DeviceStateTrackingEntity() :base("DeviceStateTrackingEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="deviceStateTrackingId">PK value for DeviceStateTracking which data should be fetched into this DeviceStateTracking object</param>
		public DeviceStateTrackingEntity(System.Int64 deviceStateTrackingId):base("DeviceStateTrackingEntity")
		{
			InitClassFetch(deviceStateTrackingId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="deviceStateTrackingId">PK value for DeviceStateTracking which data should be fetched into this DeviceStateTracking object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public DeviceStateTrackingEntity(System.Int64 deviceStateTrackingId, IPrefetchPath prefetchPathToUse):base("DeviceStateTrackingEntity")
		{
			InitClassFetch(deviceStateTrackingId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="deviceStateTrackingId">PK value for DeviceStateTracking which data should be fetched into this DeviceStateTracking object</param>
		/// <param name="validator">The custom validator object for this DeviceStateTrackingEntity</param>
		public DeviceStateTrackingEntity(System.Int64 deviceStateTrackingId, IValidator validator):base("DeviceStateTrackingEntity")
		{
			InitClassFetch(deviceStateTrackingId, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected DeviceStateTrackingEntity(SerializationInfo info, StreamingContext context) : base(info, context)
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
			switch((DeviceStateTrackingFieldIndex)fieldIndex)
			{
				case DeviceStateTrackingFieldIndex.DeviceId:
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
		/// <param name="deviceStateTrackingId">PK value for DeviceStateTracking which data should be fetched into this DeviceStateTracking object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 deviceStateTrackingId)
		{
			return FetchUsingPK(deviceStateTrackingId, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="deviceStateTrackingId">PK value for DeviceStateTracking which data should be fetched into this DeviceStateTracking object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 deviceStateTrackingId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(deviceStateTrackingId, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="deviceStateTrackingId">PK value for DeviceStateTracking which data should be fetched into this DeviceStateTracking object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 deviceStateTrackingId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(deviceStateTrackingId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="deviceStateTrackingId">PK value for DeviceStateTracking which data should be fetched into this DeviceStateTracking object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 deviceStateTrackingId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(deviceStateTrackingId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.DeviceStateTrackingId, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new DeviceStateTrackingRelations().GetAllRelations();
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
		/// <param name="deviceStateTrackingId">PK value for DeviceStateTracking which data should be fetched into this DeviceStateTracking object</param>
		/// <param name="validator">The validator object for this DeviceStateTrackingEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int64 deviceStateTrackingId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(deviceStateTrackingId, prefetchPathToUse, null, null);

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
			_fieldsCustomProperties.Add("DeviceStateTrackingId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("DeviceId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("CurrentState", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("PreviousState", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ChangeReason", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ChangeTime", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _device</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDevice(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _device, new PropertyChangedEventHandler( OnDevicePropertyChanged ), "Device", EPICCentralDL.RelationClasses.StaticDeviceStateTrackingRelations.DeviceEntityUsingDeviceIdStatic, true, signalRelatedEntity, "DeviceStateTrackings", resetFKFields, new int[] { (int)DeviceStateTrackingFieldIndex.DeviceId } );		
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
				this.PerformSetupSyncRelatedEntity( _device, new PropertyChangedEventHandler( OnDevicePropertyChanged ), "Device", EPICCentralDL.RelationClasses.StaticDeviceStateTrackingRelations.DeviceEntityUsingDeviceIdStatic, true, ref _alreadyFetchedDevice, new string[] {  } );
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
		/// <param name="deviceStateTrackingId">PK value for DeviceStateTracking which data should be fetched into this DeviceStateTracking object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int64 deviceStateTrackingId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)DeviceStateTrackingFieldIndex.DeviceStateTrackingId].ForcedCurrentValueWrite(deviceStateTrackingId);
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
			return DAOFactory.CreateDeviceStateTrackingDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new DeviceStateTrackingEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static DeviceStateTrackingRelations Relations
		{
			get	{ return new DeviceStateTrackingRelations(); }
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
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.DeviceCollection(), (IEntityRelation)GetRelationsForField("Device")[0], (int)EPICCentralDL.EntityType.DeviceStateTrackingEntity, (int)EPICCentralDL.EntityType.DeviceEntity, 0, null, null, null, "Device", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The DeviceStateTrackingId property of the Entity DeviceStateTracking<br/><br/></summary>
		/// <remarks>Mapped on  table field: "DeviceStateTracking"."DeviceStateTrackingId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 DeviceStateTrackingId
		{
			get { return (System.Int64)GetValue((int)DeviceStateTrackingFieldIndex.DeviceStateTrackingId, true); }
			set	{ SetValue((int)DeviceStateTrackingFieldIndex.DeviceStateTrackingId, value, true); }
		}

		/// <summary> The DeviceId property of the Entity DeviceStateTracking<br/><br/></summary>
		/// <remarks>Mapped on  table field: "DeviceStateTracking"."DeviceId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 DeviceId
		{
			get { return (System.Int32)GetValue((int)DeviceStateTrackingFieldIndex.DeviceId, true); }
			set	{ SetValue((int)DeviceStateTrackingFieldIndex.DeviceId, value, true); }
		}

		/// <summary> The CurrentState property of the Entity DeviceStateTracking<br/><br/></summary>
		/// <remarks>Mapped on  table field: "DeviceStateTracking"."CurrentState"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual EPICCentralDL.Customization.DeviceState CurrentState
		{
			get { return (EPICCentralDL.Customization.DeviceState)GetValue((int)DeviceStateTrackingFieldIndex.CurrentState, true); }
			set	{ SetValue((int)DeviceStateTrackingFieldIndex.CurrentState, value, true); }
		}

		/// <summary> The PreviousState property of the Entity DeviceStateTracking<br/><br/></summary>
		/// <remarks>Mapped on  table field: "DeviceStateTracking"."PreviousState"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual EPICCentralDL.Customization.DeviceState PreviousState
		{
			get { return (EPICCentralDL.Customization.DeviceState)GetValue((int)DeviceStateTrackingFieldIndex.PreviousState, true); }
			set	{ SetValue((int)DeviceStateTrackingFieldIndex.PreviousState, value, true); }
		}

		/// <summary> The ChangeReason property of the Entity DeviceStateTracking<br/><br/></summary>
		/// <remarks>Mapped on  table field: "DeviceStateTracking"."ChangeReason"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ChangeReason
		{
			get { return (System.String)GetValue((int)DeviceStateTrackingFieldIndex.ChangeReason, true); }
			set	{ SetValue((int)DeviceStateTrackingFieldIndex.ChangeReason, value, true); }
		}

		/// <summary> The ChangeTime property of the Entity DeviceStateTracking<br/><br/></summary>
		/// <remarks>Mapped on  table field: "DeviceStateTracking"."ChangeTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime ChangeTime
		{
			get { return (System.DateTime)GetValue((int)DeviceStateTrackingFieldIndex.ChangeTime, true); }
			set	{ SetValue((int)DeviceStateTrackingFieldIndex.ChangeTime, value, true); }
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
					SetSingleRelatedEntityNavigator(value, "DeviceStateTrackings", "Device", _device, true); 
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
			get { return (int)EPICCentralDL.EntityType.DeviceStateTrackingEntity; }
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
