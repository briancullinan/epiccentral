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

	/// <summary>Entity class which represents the entity 'Device'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class DeviceEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EPICCentralDL.CollectionClasses.CalibrationCollection	_calibrations;
		private bool	_alwaysFetchCalibrations, _alreadyFetchedCalibrations;
		private EPICCentralDL.CollectionClasses.DeviceEventCollection	_deviceEvents;
		private bool	_alwaysFetchDeviceEvents, _alreadyFetchedDeviceEvents;
		private EPICCentralDL.CollectionClasses.DeviceMessageCollection	_deviceMessages;
		private bool	_alwaysFetchDeviceMessages, _alreadyFetchedDeviceMessages;
		private EPICCentralDL.CollectionClasses.DeviceStateTrackingCollection	_deviceStateTrackings;
		private bool	_alwaysFetchDeviceStateTrackings, _alreadyFetchedDeviceStateTrackings;
		private EPICCentralDL.CollectionClasses.ExceptionLogCollection	_exceptionLogs;
		private bool	_alwaysFetchExceptionLogs, _alreadyFetchedExceptionLogs;
		private EPICCentralDL.CollectionClasses.PurchaseHistoryCollection	_purchaseHistories;
		private bool	_alwaysFetchPurchaseHistories, _alreadyFetchedPurchaseHistories;
		private EPICCentralDL.CollectionClasses.ScanHistoryCollection	_scanHistories;
		private bool	_alwaysFetchScanHistories, _alreadyFetchedScanHistories;
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
			/// <summary>Member name Location</summary>
			public static readonly string Location = "Location";
			/// <summary>Member name Calibrations</summary>
			public static readonly string Calibrations = "Calibrations";
			/// <summary>Member name DeviceEvents</summary>
			public static readonly string DeviceEvents = "DeviceEvents";
			/// <summary>Member name DeviceMessages</summary>
			public static readonly string DeviceMessages = "DeviceMessages";
			/// <summary>Member name DeviceStateTrackings</summary>
			public static readonly string DeviceStateTrackings = "DeviceStateTrackings";
			/// <summary>Member name ExceptionLogs</summary>
			public static readonly string ExceptionLogs = "ExceptionLogs";
			/// <summary>Member name PurchaseHistories</summary>
			public static readonly string PurchaseHistories = "PurchaseHistories";
			/// <summary>Member name ScanHistories</summary>
			public static readonly string ScanHistories = "ScanHistories";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static DeviceEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public DeviceEntity() :base("DeviceEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="deviceId">PK value for Device which data should be fetched into this Device object</param>
		public DeviceEntity(System.Int32 deviceId):base("DeviceEntity")
		{
			InitClassFetch(deviceId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="deviceId">PK value for Device which data should be fetched into this Device object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public DeviceEntity(System.Int32 deviceId, IPrefetchPath prefetchPathToUse):base("DeviceEntity")
		{
			InitClassFetch(deviceId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="deviceId">PK value for Device which data should be fetched into this Device object</param>
		/// <param name="validator">The custom validator object for this DeviceEntity</param>
		public DeviceEntity(System.Int32 deviceId, IValidator validator):base("DeviceEntity")
		{
			InitClassFetch(deviceId, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected DeviceEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_calibrations = (EPICCentralDL.CollectionClasses.CalibrationCollection)info.GetValue("_calibrations", typeof(EPICCentralDL.CollectionClasses.CalibrationCollection));
			_alwaysFetchCalibrations = info.GetBoolean("_alwaysFetchCalibrations");
			_alreadyFetchedCalibrations = info.GetBoolean("_alreadyFetchedCalibrations");

			_deviceEvents = (EPICCentralDL.CollectionClasses.DeviceEventCollection)info.GetValue("_deviceEvents", typeof(EPICCentralDL.CollectionClasses.DeviceEventCollection));
			_alwaysFetchDeviceEvents = info.GetBoolean("_alwaysFetchDeviceEvents");
			_alreadyFetchedDeviceEvents = info.GetBoolean("_alreadyFetchedDeviceEvents");

			_deviceMessages = (EPICCentralDL.CollectionClasses.DeviceMessageCollection)info.GetValue("_deviceMessages", typeof(EPICCentralDL.CollectionClasses.DeviceMessageCollection));
			_alwaysFetchDeviceMessages = info.GetBoolean("_alwaysFetchDeviceMessages");
			_alreadyFetchedDeviceMessages = info.GetBoolean("_alreadyFetchedDeviceMessages");

			_deviceStateTrackings = (EPICCentralDL.CollectionClasses.DeviceStateTrackingCollection)info.GetValue("_deviceStateTrackings", typeof(EPICCentralDL.CollectionClasses.DeviceStateTrackingCollection));
			_alwaysFetchDeviceStateTrackings = info.GetBoolean("_alwaysFetchDeviceStateTrackings");
			_alreadyFetchedDeviceStateTrackings = info.GetBoolean("_alreadyFetchedDeviceStateTrackings");

			_exceptionLogs = (EPICCentralDL.CollectionClasses.ExceptionLogCollection)info.GetValue("_exceptionLogs", typeof(EPICCentralDL.CollectionClasses.ExceptionLogCollection));
			_alwaysFetchExceptionLogs = info.GetBoolean("_alwaysFetchExceptionLogs");
			_alreadyFetchedExceptionLogs = info.GetBoolean("_alreadyFetchedExceptionLogs");

			_purchaseHistories = (EPICCentralDL.CollectionClasses.PurchaseHistoryCollection)info.GetValue("_purchaseHistories", typeof(EPICCentralDL.CollectionClasses.PurchaseHistoryCollection));
			_alwaysFetchPurchaseHistories = info.GetBoolean("_alwaysFetchPurchaseHistories");
			_alreadyFetchedPurchaseHistories = info.GetBoolean("_alreadyFetchedPurchaseHistories");

			_scanHistories = (EPICCentralDL.CollectionClasses.ScanHistoryCollection)info.GetValue("_scanHistories", typeof(EPICCentralDL.CollectionClasses.ScanHistoryCollection));
			_alwaysFetchScanHistories = info.GetBoolean("_alwaysFetchScanHistories");
			_alreadyFetchedScanHistories = info.GetBoolean("_alreadyFetchedScanHistories");
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
			switch((DeviceFieldIndex)fieldIndex)
			{
				case DeviceFieldIndex.LocationId:
					DesetupSyncLocation(true, false);
					_alreadyFetchedLocation = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedCalibrations = (_calibrations.Count > 0);
			_alreadyFetchedDeviceEvents = (_deviceEvents.Count > 0);
			_alreadyFetchedDeviceMessages = (_deviceMessages.Count > 0);
			_alreadyFetchedDeviceStateTrackings = (_deviceStateTrackings.Count > 0);
			_alreadyFetchedExceptionLogs = (_exceptionLogs.Count > 0);
			_alreadyFetchedPurchaseHistories = (_purchaseHistories.Count > 0);
			_alreadyFetchedScanHistories = (_scanHistories.Count > 0);
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
				case "Location":
					toReturn.Add(Relations.LocationEntityUsingLocationId);
					break;
				case "Calibrations":
					toReturn.Add(Relations.CalibrationEntityUsingDeviceId);
					break;
				case "DeviceEvents":
					toReturn.Add(Relations.DeviceEventEntityUsingDeviceId);
					break;
				case "DeviceMessages":
					toReturn.Add(Relations.DeviceMessageEntityUsingDeviceId);
					break;
				case "DeviceStateTrackings":
					toReturn.Add(Relations.DeviceStateTrackingEntityUsingDeviceId);
					break;
				case "ExceptionLogs":
					toReturn.Add(Relations.ExceptionLogEntityUsingDeviceId);
					break;
				case "PurchaseHistories":
					toReturn.Add(Relations.PurchaseHistoryEntityUsingDeviceId);
					break;
				case "ScanHistories":
					toReturn.Add(Relations.ScanHistoryEntityUsingDeviceId);
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
			info.AddValue("_deviceEvents", (!this.MarkedForDeletion?_deviceEvents:null));
			info.AddValue("_alwaysFetchDeviceEvents", _alwaysFetchDeviceEvents);
			info.AddValue("_alreadyFetchedDeviceEvents", _alreadyFetchedDeviceEvents);
			info.AddValue("_deviceMessages", (!this.MarkedForDeletion?_deviceMessages:null));
			info.AddValue("_alwaysFetchDeviceMessages", _alwaysFetchDeviceMessages);
			info.AddValue("_alreadyFetchedDeviceMessages", _alreadyFetchedDeviceMessages);
			info.AddValue("_deviceStateTrackings", (!this.MarkedForDeletion?_deviceStateTrackings:null));
			info.AddValue("_alwaysFetchDeviceStateTrackings", _alwaysFetchDeviceStateTrackings);
			info.AddValue("_alreadyFetchedDeviceStateTrackings", _alreadyFetchedDeviceStateTrackings);
			info.AddValue("_exceptionLogs", (!this.MarkedForDeletion?_exceptionLogs:null));
			info.AddValue("_alwaysFetchExceptionLogs", _alwaysFetchExceptionLogs);
			info.AddValue("_alreadyFetchedExceptionLogs", _alreadyFetchedExceptionLogs);
			info.AddValue("_purchaseHistories", (!this.MarkedForDeletion?_purchaseHistories:null));
			info.AddValue("_alwaysFetchPurchaseHistories", _alwaysFetchPurchaseHistories);
			info.AddValue("_alreadyFetchedPurchaseHistories", _alreadyFetchedPurchaseHistories);
			info.AddValue("_scanHistories", (!this.MarkedForDeletion?_scanHistories:null));
			info.AddValue("_alwaysFetchScanHistories", _alwaysFetchScanHistories);
			info.AddValue("_alreadyFetchedScanHistories", _alreadyFetchedScanHistories);
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
				case "Location":
					_alreadyFetchedLocation = true;
					this.Location = (LocationEntity)entity;
					break;
				case "Calibrations":
					_alreadyFetchedCalibrations = true;
					if(entity!=null)
					{
						this.Calibrations.Add((CalibrationEntity)entity);
					}
					break;
				case "DeviceEvents":
					_alreadyFetchedDeviceEvents = true;
					if(entity!=null)
					{
						this.DeviceEvents.Add((DeviceEventEntity)entity);
					}
					break;
				case "DeviceMessages":
					_alreadyFetchedDeviceMessages = true;
					if(entity!=null)
					{
						this.DeviceMessages.Add((DeviceMessageEntity)entity);
					}
					break;
				case "DeviceStateTrackings":
					_alreadyFetchedDeviceStateTrackings = true;
					if(entity!=null)
					{
						this.DeviceStateTrackings.Add((DeviceStateTrackingEntity)entity);
					}
					break;
				case "ExceptionLogs":
					_alreadyFetchedExceptionLogs = true;
					if(entity!=null)
					{
						this.ExceptionLogs.Add((ExceptionLogEntity)entity);
					}
					break;
				case "PurchaseHistories":
					_alreadyFetchedPurchaseHistories = true;
					if(entity!=null)
					{
						this.PurchaseHistories.Add((PurchaseHistoryEntity)entity);
					}
					break;
				case "ScanHistories":
					_alreadyFetchedScanHistories = true;
					if(entity!=null)
					{
						this.ScanHistories.Add((ScanHistoryEntity)entity);
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
				case "Location":
					SetupSyncLocation(relatedEntity);
					break;
				case "Calibrations":
					_calibrations.Add((CalibrationEntity)relatedEntity);
					break;
				case "DeviceEvents":
					_deviceEvents.Add((DeviceEventEntity)relatedEntity);
					break;
				case "DeviceMessages":
					_deviceMessages.Add((DeviceMessageEntity)relatedEntity);
					break;
				case "DeviceStateTrackings":
					_deviceStateTrackings.Add((DeviceStateTrackingEntity)relatedEntity);
					break;
				case "ExceptionLogs":
					_exceptionLogs.Add((ExceptionLogEntity)relatedEntity);
					break;
				case "PurchaseHistories":
					_purchaseHistories.Add((PurchaseHistoryEntity)relatedEntity);
					break;
				case "ScanHistories":
					_scanHistories.Add((ScanHistoryEntity)relatedEntity);
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
				case "Location":
					DesetupSyncLocation(false, true);
					break;
				case "Calibrations":
					this.PerformRelatedEntityRemoval(_calibrations, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "DeviceEvents":
					this.PerformRelatedEntityRemoval(_deviceEvents, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "DeviceMessages":
					this.PerformRelatedEntityRemoval(_deviceMessages, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "DeviceStateTrackings":
					this.PerformRelatedEntityRemoval(_deviceStateTrackings, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ExceptionLogs":
					this.PerformRelatedEntityRemoval(_exceptionLogs, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PurchaseHistories":
					this.PerformRelatedEntityRemoval(_purchaseHistories, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ScanHistories":
					this.PerformRelatedEntityRemoval(_scanHistories, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(_calibrations);
			toReturn.Add(_deviceEvents);
			toReturn.Add(_deviceMessages);
			toReturn.Add(_deviceStateTrackings);
			toReturn.Add(_exceptionLogs);
			toReturn.Add(_purchaseHistories);
			toReturn.Add(_scanHistories);

			return toReturn;
		}


		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="deviceId">PK value for Device which data should be fetched into this Device object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 deviceId)
		{
			return FetchUsingPK(deviceId, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="deviceId">PK value for Device which data should be fetched into this Device object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 deviceId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(deviceId, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="deviceId">PK value for Device which data should be fetched into this Device object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 deviceId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(deviceId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="deviceId">PK value for Device which data should be fetched into this Device object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int32 deviceId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(deviceId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.DeviceId, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new DeviceRelations().GetAllRelations();
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
				_calibrations.GetMultiManyToOne(this, null, filter);
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

		/// <summary> Retrieves all related entities of type 'DeviceEventEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'DeviceEventEntity'</returns>
		public EPICCentralDL.CollectionClasses.DeviceEventCollection GetMultiDeviceEvents(bool forceFetch)
		{
			return GetMultiDeviceEvents(forceFetch, _deviceEvents.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'DeviceEventEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'DeviceEventEntity'</returns>
		public EPICCentralDL.CollectionClasses.DeviceEventCollection GetMultiDeviceEvents(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiDeviceEvents(forceFetch, _deviceEvents.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'DeviceEventEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.DeviceEventCollection GetMultiDeviceEvents(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiDeviceEvents(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'DeviceEventEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.DeviceEventCollection GetMultiDeviceEvents(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedDeviceEvents || forceFetch || _alwaysFetchDeviceEvents) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_deviceEvents);
				_deviceEvents.SuppressClearInGetMulti=!forceFetch;
				_deviceEvents.EntityFactoryToUse = entityFactoryToUse;
				_deviceEvents.GetMultiManyToOne(this, filter);
				_deviceEvents.SuppressClearInGetMulti=false;
				_alreadyFetchedDeviceEvents = true;
			}
			return _deviceEvents;
		}

		/// <summary> Sets the collection parameters for the collection for 'DeviceEvents'. These settings will be taken into account
		/// when the property DeviceEvents is requested or GetMultiDeviceEvents is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersDeviceEvents(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_deviceEvents.SortClauses=sortClauses;
			_deviceEvents.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'DeviceMessageEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'DeviceMessageEntity'</returns>
		public EPICCentralDL.CollectionClasses.DeviceMessageCollection GetMultiDeviceMessages(bool forceFetch)
		{
			return GetMultiDeviceMessages(forceFetch, _deviceMessages.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'DeviceMessageEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'DeviceMessageEntity'</returns>
		public EPICCentralDL.CollectionClasses.DeviceMessageCollection GetMultiDeviceMessages(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiDeviceMessages(forceFetch, _deviceMessages.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'DeviceMessageEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.DeviceMessageCollection GetMultiDeviceMessages(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiDeviceMessages(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'DeviceMessageEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.DeviceMessageCollection GetMultiDeviceMessages(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedDeviceMessages || forceFetch || _alwaysFetchDeviceMessages) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_deviceMessages);
				_deviceMessages.SuppressClearInGetMulti=!forceFetch;
				_deviceMessages.EntityFactoryToUse = entityFactoryToUse;
				_deviceMessages.GetMultiManyToOne(this, null, filter);
				_deviceMessages.SuppressClearInGetMulti=false;
				_alreadyFetchedDeviceMessages = true;
			}
			return _deviceMessages;
		}

		/// <summary> Sets the collection parameters for the collection for 'DeviceMessages'. These settings will be taken into account
		/// when the property DeviceMessages is requested or GetMultiDeviceMessages is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersDeviceMessages(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_deviceMessages.SortClauses=sortClauses;
			_deviceMessages.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'DeviceStateTrackingEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'DeviceStateTrackingEntity'</returns>
		public EPICCentralDL.CollectionClasses.DeviceStateTrackingCollection GetMultiDeviceStateTrackings(bool forceFetch)
		{
			return GetMultiDeviceStateTrackings(forceFetch, _deviceStateTrackings.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'DeviceStateTrackingEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'DeviceStateTrackingEntity'</returns>
		public EPICCentralDL.CollectionClasses.DeviceStateTrackingCollection GetMultiDeviceStateTrackings(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiDeviceStateTrackings(forceFetch, _deviceStateTrackings.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'DeviceStateTrackingEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.DeviceStateTrackingCollection GetMultiDeviceStateTrackings(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiDeviceStateTrackings(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'DeviceStateTrackingEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.DeviceStateTrackingCollection GetMultiDeviceStateTrackings(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedDeviceStateTrackings || forceFetch || _alwaysFetchDeviceStateTrackings) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_deviceStateTrackings);
				_deviceStateTrackings.SuppressClearInGetMulti=!forceFetch;
				_deviceStateTrackings.EntityFactoryToUse = entityFactoryToUse;
				_deviceStateTrackings.GetMultiManyToOne(this, filter);
				_deviceStateTrackings.SuppressClearInGetMulti=false;
				_alreadyFetchedDeviceStateTrackings = true;
			}
			return _deviceStateTrackings;
		}

		/// <summary> Sets the collection parameters for the collection for 'DeviceStateTrackings'. These settings will be taken into account
		/// when the property DeviceStateTrackings is requested or GetMultiDeviceStateTrackings is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersDeviceStateTrackings(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_deviceStateTrackings.SortClauses=sortClauses;
			_deviceStateTrackings.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'ExceptionLogEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'ExceptionLogEntity'</returns>
		public EPICCentralDL.CollectionClasses.ExceptionLogCollection GetMultiExceptionLogs(bool forceFetch)
		{
			return GetMultiExceptionLogs(forceFetch, _exceptionLogs.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ExceptionLogEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'ExceptionLogEntity'</returns>
		public EPICCentralDL.CollectionClasses.ExceptionLogCollection GetMultiExceptionLogs(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiExceptionLogs(forceFetch, _exceptionLogs.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'ExceptionLogEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.ExceptionLogCollection GetMultiExceptionLogs(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiExceptionLogs(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ExceptionLogEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.ExceptionLogCollection GetMultiExceptionLogs(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedExceptionLogs || forceFetch || _alwaysFetchExceptionLogs) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_exceptionLogs);
				_exceptionLogs.SuppressClearInGetMulti=!forceFetch;
				_exceptionLogs.EntityFactoryToUse = entityFactoryToUse;
				_exceptionLogs.GetMultiManyToOne(this, filter);
				_exceptionLogs.SuppressClearInGetMulti=false;
				_alreadyFetchedExceptionLogs = true;
			}
			return _exceptionLogs;
		}

		/// <summary> Sets the collection parameters for the collection for 'ExceptionLogs'. These settings will be taken into account
		/// when the property ExceptionLogs is requested or GetMultiExceptionLogs is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersExceptionLogs(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_exceptionLogs.SortClauses=sortClauses;
			_exceptionLogs.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'PurchaseHistoryEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'PurchaseHistoryEntity'</returns>
		public EPICCentralDL.CollectionClasses.PurchaseHistoryCollection GetMultiPurchaseHistories(bool forceFetch)
		{
			return GetMultiPurchaseHistories(forceFetch, _purchaseHistories.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'PurchaseHistoryEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'PurchaseHistoryEntity'</returns>
		public EPICCentralDL.CollectionClasses.PurchaseHistoryCollection GetMultiPurchaseHistories(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiPurchaseHistories(forceFetch, _purchaseHistories.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'PurchaseHistoryEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.PurchaseHistoryCollection GetMultiPurchaseHistories(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiPurchaseHistories(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'PurchaseHistoryEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.PurchaseHistoryCollection GetMultiPurchaseHistories(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedPurchaseHistories || forceFetch || _alwaysFetchPurchaseHistories) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_purchaseHistories);
				_purchaseHistories.SuppressClearInGetMulti=!forceFetch;
				_purchaseHistories.EntityFactoryToUse = entityFactoryToUse;
				_purchaseHistories.GetMultiManyToOne(this, null, null, filter);
				_purchaseHistories.SuppressClearInGetMulti=false;
				_alreadyFetchedPurchaseHistories = true;
			}
			return _purchaseHistories;
		}

		/// <summary> Sets the collection parameters for the collection for 'PurchaseHistories'. These settings will be taken into account
		/// when the property PurchaseHistories is requested or GetMultiPurchaseHistories is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersPurchaseHistories(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_purchaseHistories.SortClauses=sortClauses;
			_purchaseHistories.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'ScanHistoryEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'ScanHistoryEntity'</returns>
		public EPICCentralDL.CollectionClasses.ScanHistoryCollection GetMultiScanHistories(bool forceFetch)
		{
			return GetMultiScanHistories(forceFetch, _scanHistories.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ScanHistoryEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'ScanHistoryEntity'</returns>
		public EPICCentralDL.CollectionClasses.ScanHistoryCollection GetMultiScanHistories(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiScanHistories(forceFetch, _scanHistories.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'ScanHistoryEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.ScanHistoryCollection GetMultiScanHistories(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiScanHistories(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'ScanHistoryEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.ScanHistoryCollection GetMultiScanHistories(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedScanHistories || forceFetch || _alwaysFetchScanHistories) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_scanHistories);
				_scanHistories.SuppressClearInGetMulti=!forceFetch;
				_scanHistories.EntityFactoryToUse = entityFactoryToUse;
				_scanHistories.GetMultiManyToOne(this, filter);
				_scanHistories.SuppressClearInGetMulti=false;
				_alreadyFetchedScanHistories = true;
			}
			return _scanHistories;
		}

		/// <summary> Sets the collection parameters for the collection for 'ScanHistories'. These settings will be taken into account
		/// when the property ScanHistories is requested or GetMultiScanHistories is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersScanHistories(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_scanHistories.SortClauses=sortClauses;
			_scanHistories.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
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
			toReturn.Add("Location", _location);
			toReturn.Add("Calibrations", _calibrations);
			toReturn.Add("DeviceEvents", _deviceEvents);
			toReturn.Add("DeviceMessages", _deviceMessages);
			toReturn.Add("DeviceStateTrackings", _deviceStateTrackings);
			toReturn.Add("ExceptionLogs", _exceptionLogs);
			toReturn.Add("PurchaseHistories", _purchaseHistories);
			toReturn.Add("ScanHistories", _scanHistories);
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
		/// <param name="deviceId">PK value for Device which data should be fetched into this Device object</param>
		/// <param name="validator">The validator object for this DeviceEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int32 deviceId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(deviceId, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{

			_calibrations = new EPICCentralDL.CollectionClasses.CalibrationCollection();
			_calibrations.SetContainingEntityInfo(this, "Device");

			_deviceEvents = new EPICCentralDL.CollectionClasses.DeviceEventCollection();
			_deviceEvents.SetContainingEntityInfo(this, "Device");

			_deviceMessages = new EPICCentralDL.CollectionClasses.DeviceMessageCollection();
			_deviceMessages.SetContainingEntityInfo(this, "Device");

			_deviceStateTrackings = new EPICCentralDL.CollectionClasses.DeviceStateTrackingCollection();
			_deviceStateTrackings.SetContainingEntityInfo(this, "Device");

			_exceptionLogs = new EPICCentralDL.CollectionClasses.ExceptionLogCollection();
			_exceptionLogs.SetContainingEntityInfo(this, "Device");

			_purchaseHistories = new EPICCentralDL.CollectionClasses.PurchaseHistoryCollection();
			_purchaseHistories.SetContainingEntityInfo(this, "Device");

			_scanHistories = new EPICCentralDL.CollectionClasses.ScanHistoryCollection();
			_scanHistories.SetContainingEntityInfo(this, "Device");
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
			_fieldsCustomProperties.Add("DeviceId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("LocationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("UniqueIdentifier", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AuthenticationToken", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("UidQualifier", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("DeviceState", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("SerialNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("DateIssued", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("RevisionLevel", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ScansAvailable", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ScansUsed", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("CurrentStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("LastReportTime", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _location</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLocation(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _location, new PropertyChangedEventHandler( OnLocationPropertyChanged ), "Location", EPICCentralDL.RelationClasses.StaticDeviceRelations.LocationEntityUsingLocationIdStatic, true, signalRelatedEntity, "Devices", resetFKFields, new int[] { (int)DeviceFieldIndex.LocationId } );		
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
				this.PerformSetupSyncRelatedEntity( _location, new PropertyChangedEventHandler( OnLocationPropertyChanged ), "Location", EPICCentralDL.RelationClasses.StaticDeviceRelations.LocationEntityUsingLocationIdStatic, true, ref _alreadyFetchedLocation, new string[] {  } );
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
		/// <param name="deviceId">PK value for Device which data should be fetched into this Device object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int32 deviceId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)DeviceFieldIndex.DeviceId].ForcedCurrentValueWrite(deviceId);
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
			return DAOFactory.CreateDeviceDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new DeviceEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static DeviceRelations Relations
		{
			get	{ return new DeviceRelations(); }
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
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.CalibrationCollection(), (IEntityRelation)GetRelationsForField("Calibrations")[0], (int)EPICCentralDL.EntityType.DeviceEntity, (int)EPICCentralDL.EntityType.CalibrationEntity, 0, null, null, null, "Calibrations", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'DeviceEvent' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathDeviceEvents
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.DeviceEventCollection(), (IEntityRelation)GetRelationsForField("DeviceEvents")[0], (int)EPICCentralDL.EntityType.DeviceEntity, (int)EPICCentralDL.EntityType.DeviceEventEntity, 0, null, null, null, "DeviceEvents", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'DeviceMessage' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathDeviceMessages
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.DeviceMessageCollection(), (IEntityRelation)GetRelationsForField("DeviceMessages")[0], (int)EPICCentralDL.EntityType.DeviceEntity, (int)EPICCentralDL.EntityType.DeviceMessageEntity, 0, null, null, null, "DeviceMessages", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'DeviceStateTracking' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathDeviceStateTrackings
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.DeviceStateTrackingCollection(), (IEntityRelation)GetRelationsForField("DeviceStateTrackings")[0], (int)EPICCentralDL.EntityType.DeviceEntity, (int)EPICCentralDL.EntityType.DeviceStateTrackingEntity, 0, null, null, null, "DeviceStateTrackings", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'ExceptionLog' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathExceptionLogs
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.ExceptionLogCollection(), (IEntityRelation)GetRelationsForField("ExceptionLogs")[0], (int)EPICCentralDL.EntityType.DeviceEntity, (int)EPICCentralDL.EntityType.ExceptionLogEntity, 0, null, null, null, "ExceptionLogs", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'PurchaseHistory' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathPurchaseHistories
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.PurchaseHistoryCollection(), (IEntityRelation)GetRelationsForField("PurchaseHistories")[0], (int)EPICCentralDL.EntityType.DeviceEntity, (int)EPICCentralDL.EntityType.PurchaseHistoryEntity, 0, null, null, null, "PurchaseHistories", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'ScanHistory' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathScanHistories
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.ScanHistoryCollection(), (IEntityRelation)GetRelationsForField("ScanHistories")[0], (int)EPICCentralDL.EntityType.DeviceEntity, (int)EPICCentralDL.EntityType.ScanHistoryEntity, 0, null, null, null, "ScanHistories", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Location'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathLocation
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.LocationCollection(), (IEntityRelation)GetRelationsForField("Location")[0], (int)EPICCentralDL.EntityType.DeviceEntity, (int)EPICCentralDL.EntityType.LocationEntity, 0, null, null, null, "Location", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
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

		/// <summary> The DeviceId property of the Entity Device<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Device"."DeviceId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 DeviceId
		{
			get { return (System.Int32)GetValue((int)DeviceFieldIndex.DeviceId, true); }
			set	{ SetValue((int)DeviceFieldIndex.DeviceId, value, true); }
		}

		/// <summary> The LocationId property of the Entity Device<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Device"."LocationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 LocationId
		{
			get { return (System.Int32)GetValue((int)DeviceFieldIndex.LocationId, true); }
			set	{ SetValue((int)DeviceFieldIndex.LocationId, value, true); }
		}

		/// <summary> The UniqueIdentifier property of the Entity Device<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Device"."UniqueIdentifier"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 48<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String UniqueIdentifier
		{
			get { return (System.String)GetValue((int)DeviceFieldIndex.UniqueIdentifier, true); }
			set	{ SetValue((int)DeviceFieldIndex.UniqueIdentifier, value, true); }
		}

		/// <summary> The AuthenticationToken property of the Entity Device<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Device"."AuthenticationToken"<br/>
		/// Table field type characteristics (type, precision, scale, length): Binary, 0, 0, 64<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.Byte[] AuthenticationToken
		{
			get { return (System.Byte[])GetValue((int)DeviceFieldIndex.AuthenticationToken, true); }
			set	{ SetValue((int)DeviceFieldIndex.AuthenticationToken, value, true); }
		}

		/// <summary> The UidQualifier property of the Entity Device<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Device"."UidQualifier"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 UidQualifier
		{
			get { return (System.Int32)GetValue((int)DeviceFieldIndex.UidQualifier, true); }

		}

		/// <summary> The DeviceState property of the Entity Device<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Device"."DeviceState"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual EPICCentralDL.Customization.DeviceState DeviceState
		{
			get { return (EPICCentralDL.Customization.DeviceState)GetValue((int)DeviceFieldIndex.DeviceState, true); }
			set	{ SetValue((int)DeviceFieldIndex.DeviceState, value, true); }
		}

		/// <summary> The SerialNumber property of the Entity Device<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Device"."SerialNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 40<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String SerialNumber
		{
			get { return (System.String)GetValue((int)DeviceFieldIndex.SerialNumber, true); }
			set	{ SetValue((int)DeviceFieldIndex.SerialNumber, value, true); }
		}

		/// <summary> The DateIssued property of the Entity Device<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Device"."DateIssued"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateIssued
		{
			get { return (System.DateTime)GetValue((int)DeviceFieldIndex.DateIssued, true); }
			set	{ SetValue((int)DeviceFieldIndex.DateIssued, value, true); }
		}

		/// <summary> The RevisionLevel property of the Entity Device<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Device"."RevisionLevel"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String RevisionLevel
		{
			get { return (System.String)GetValue((int)DeviceFieldIndex.RevisionLevel, true); }
			set	{ SetValue((int)DeviceFieldIndex.RevisionLevel, value, true); }
		}

		/// <summary> The ScansAvailable property of the Entity Device<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Device"."ScansAvailable"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ScansAvailable
		{
			get { return (System.Int32)GetValue((int)DeviceFieldIndex.ScansAvailable, true); }
			set	{ SetValue((int)DeviceFieldIndex.ScansAvailable, value, true); }
		}

		/// <summary> The ScansUsed property of the Entity Device<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Device"."ScansCompleted"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 ScansUsed
		{
			get { return (System.Int32)GetValue((int)DeviceFieldIndex.ScansUsed, true); }
			set	{ SetValue((int)DeviceFieldIndex.ScansUsed, value, true); }
		}

		/// <summary> The CurrentStatus property of the Entity Device<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Device"."CurrentStatus"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String CurrentStatus
		{
			get { return (System.String)GetValue((int)DeviceFieldIndex.CurrentStatus, true); }
			set	{ SetValue((int)DeviceFieldIndex.CurrentStatus, value, true); }
		}

		/// <summary> The LastReportTime property of the Entity Device<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Device"."LastReportTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastReportTime
		{
			get { return (Nullable<System.DateTime>)GetValue((int)DeviceFieldIndex.LastReportTime, false); }
			set	{ SetValue((int)DeviceFieldIndex.LastReportTime, value, true); }
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
		/// <summary> Retrieves all related entities of type 'DeviceEventEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiDeviceEvents()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.DeviceEventCollection DeviceEvents
		{
			get	{ return GetMultiDeviceEvents(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for DeviceEvents. When set to true, DeviceEvents is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time DeviceEvents is accessed. You can always execute/ a forced fetch by calling GetMultiDeviceEvents(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchDeviceEvents
		{
			get	{ return _alwaysFetchDeviceEvents; }
			set	{ _alwaysFetchDeviceEvents = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property DeviceEvents already has been fetched. Setting this property to false when DeviceEvents has been fetched
		/// will clear the DeviceEvents collection well. Setting this property to true while DeviceEvents hasn't been fetched disables lazy loading for DeviceEvents</summary>
		[Browsable(false)]
		public bool AlreadyFetchedDeviceEvents
		{
			get { return _alreadyFetchedDeviceEvents;}
			set 
			{
				if(_alreadyFetchedDeviceEvents && !value && (_deviceEvents != null))
				{
					_deviceEvents.Clear();
				}
				_alreadyFetchedDeviceEvents = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'DeviceMessageEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiDeviceMessages()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.DeviceMessageCollection DeviceMessages
		{
			get	{ return GetMultiDeviceMessages(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for DeviceMessages. When set to true, DeviceMessages is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time DeviceMessages is accessed. You can always execute/ a forced fetch by calling GetMultiDeviceMessages(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchDeviceMessages
		{
			get	{ return _alwaysFetchDeviceMessages; }
			set	{ _alwaysFetchDeviceMessages = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property DeviceMessages already has been fetched. Setting this property to false when DeviceMessages has been fetched
		/// will clear the DeviceMessages collection well. Setting this property to true while DeviceMessages hasn't been fetched disables lazy loading for DeviceMessages</summary>
		[Browsable(false)]
		public bool AlreadyFetchedDeviceMessages
		{
			get { return _alreadyFetchedDeviceMessages;}
			set 
			{
				if(_alreadyFetchedDeviceMessages && !value && (_deviceMessages != null))
				{
					_deviceMessages.Clear();
				}
				_alreadyFetchedDeviceMessages = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'DeviceStateTrackingEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiDeviceStateTrackings()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.DeviceStateTrackingCollection DeviceStateTrackings
		{
			get	{ return GetMultiDeviceStateTrackings(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for DeviceStateTrackings. When set to true, DeviceStateTrackings is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time DeviceStateTrackings is accessed. You can always execute/ a forced fetch by calling GetMultiDeviceStateTrackings(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchDeviceStateTrackings
		{
			get	{ return _alwaysFetchDeviceStateTrackings; }
			set	{ _alwaysFetchDeviceStateTrackings = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property DeviceStateTrackings already has been fetched. Setting this property to false when DeviceStateTrackings has been fetched
		/// will clear the DeviceStateTrackings collection well. Setting this property to true while DeviceStateTrackings hasn't been fetched disables lazy loading for DeviceStateTrackings</summary>
		[Browsable(false)]
		public bool AlreadyFetchedDeviceStateTrackings
		{
			get { return _alreadyFetchedDeviceStateTrackings;}
			set 
			{
				if(_alreadyFetchedDeviceStateTrackings && !value && (_deviceStateTrackings != null))
				{
					_deviceStateTrackings.Clear();
				}
				_alreadyFetchedDeviceStateTrackings = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'ExceptionLogEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiExceptionLogs()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.ExceptionLogCollection ExceptionLogs
		{
			get	{ return GetMultiExceptionLogs(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for ExceptionLogs. When set to true, ExceptionLogs is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time ExceptionLogs is accessed. You can always execute/ a forced fetch by calling GetMultiExceptionLogs(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchExceptionLogs
		{
			get	{ return _alwaysFetchExceptionLogs; }
			set	{ _alwaysFetchExceptionLogs = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property ExceptionLogs already has been fetched. Setting this property to false when ExceptionLogs has been fetched
		/// will clear the ExceptionLogs collection well. Setting this property to true while ExceptionLogs hasn't been fetched disables lazy loading for ExceptionLogs</summary>
		[Browsable(false)]
		public bool AlreadyFetchedExceptionLogs
		{
			get { return _alreadyFetchedExceptionLogs;}
			set 
			{
				if(_alreadyFetchedExceptionLogs && !value && (_exceptionLogs != null))
				{
					_exceptionLogs.Clear();
				}
				_alreadyFetchedExceptionLogs = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'PurchaseHistoryEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiPurchaseHistories()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.PurchaseHistoryCollection PurchaseHistories
		{
			get	{ return GetMultiPurchaseHistories(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for PurchaseHistories. When set to true, PurchaseHistories is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time PurchaseHistories is accessed. You can always execute/ a forced fetch by calling GetMultiPurchaseHistories(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchPurchaseHistories
		{
			get	{ return _alwaysFetchPurchaseHistories; }
			set	{ _alwaysFetchPurchaseHistories = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property PurchaseHistories already has been fetched. Setting this property to false when PurchaseHistories has been fetched
		/// will clear the PurchaseHistories collection well. Setting this property to true while PurchaseHistories hasn't been fetched disables lazy loading for PurchaseHistories</summary>
		[Browsable(false)]
		public bool AlreadyFetchedPurchaseHistories
		{
			get { return _alreadyFetchedPurchaseHistories;}
			set 
			{
				if(_alreadyFetchedPurchaseHistories && !value && (_purchaseHistories != null))
				{
					_purchaseHistories.Clear();
				}
				_alreadyFetchedPurchaseHistories = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'ScanHistoryEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiScanHistories()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.ScanHistoryCollection ScanHistories
		{
			get	{ return GetMultiScanHistories(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for ScanHistories. When set to true, ScanHistories is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time ScanHistories is accessed. You can always execute/ a forced fetch by calling GetMultiScanHistories(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchScanHistories
		{
			get	{ return _alwaysFetchScanHistories; }
			set	{ _alwaysFetchScanHistories = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property ScanHistories already has been fetched. Setting this property to false when ScanHistories has been fetched
		/// will clear the ScanHistories collection well. Setting this property to true while ScanHistories hasn't been fetched disables lazy loading for ScanHistories</summary>
		[Browsable(false)]
		public bool AlreadyFetchedScanHistories
		{
			get { return _alreadyFetchedScanHistories;}
			set 
			{
				if(_alreadyFetchedScanHistories && !value && (_scanHistories != null))
				{
					_scanHistories.Clear();
				}
				_alreadyFetchedScanHistories = value;
			}
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
					SetSingleRelatedEntityNavigator(value, "Devices", "Location", _location, true); 
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
			get { return (int)EPICCentralDL.EntityType.DeviceEntity; }
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
