// Type: SD.LLBLGen.Pro.ORMSupportClasses.EntityCollectionBase`1
// Assembly: SD.LLBLGen.Pro.ORMSupportClasses.NET20, Version=3.5.0.0, Culture=neutral, PublicKeyToken=ca73b74ba4e3ff27
// Assembly location: C:\EPICSource\developer1_ARIZONA21\EPIC Website\EPICCentral\EPICCentral\bin\SD.LLBLGen.Pro.ORMSupportClasses.NET20.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
  /// <summary>
  /// Implementation of the entity collection base class.
  /// 
  /// </summary>
  [Serializable]
  public abstract class EntityCollectionBase<TEntity> : CollectionCore<TEntity>, IEntityCollection, IEntityCollectionCore, IEnumerable, IActiveContextParticipant, ITransactionalElement, IXmlSerializable, IListSource, IEntityCollectionAccess, IXmlCollectionSerializable, ICollectionMaintenance where TEntity : EntityBase, IEntity
  {
    private long _maxNumberOfItemsToReturn;
    private ISortExpression _sortClauses;
    private IEntityFactory _entityFactoryToUse;
    private bool _suppressClearInGetMulti;
    private IEntity _containingEntity;
    private string _containingEntityMappedField;
    [NonSerialized]
    private ITransaction _containingTransaction;
    [NonSerialized]
    private Context _activeContext;
    [NonSerialized]
    private EntityView<TEntity> _defaultView;
    [NonSerialized]
    private IEntityCollection _removedEntitiesTracker;

    bool ICollectionMaintenance.SurpressListChangedEvents
    {
      get
      {
        return this.SuppressListChangedEventsInternal;
      }
      set
      {
        this.SuppressListChangedEventsInternal = value;
      }
    }

    bool ICollectionMaintenance.DeserializationInProgress
    {
      get
      {
        return this.DeserializationInProgress;
      }
      set
      {
        this.DeserializationInProgress = value;
      }
    }

    List<IEntity> IEntityCollection.DirtyEntities
    {
      get
      {
        List<IEntity> list = new List<IEntity>();
        foreach (TEntity entity in this.DirtyEntities)
          list.Add((IEntity) entity);
        return list;
      }
    }

    IEntityView IEntityCollection.DefaultView
    {
      get
      {
        return (IEntityView) this.DefaultView;
      }
    }

    int IEntityCollection.Capacity
    {
      get
      {
        return this.Capacity;
      }
      set
      {
        this.Capacity = value;
      }
    }

    /// <summary>
    /// Gets a value indicating whether the collection is a collection of <see cref="T:System.Collections.IList"/> objects.
    /// 
    /// </summary>
    /// 
    /// <value/>
    /// 
    /// <returns>
    /// true if the collection is a collection of <see cref="T:System.Collections.IList"/> objects; otherwise, false.
    /// </returns>
    [XmlIgnore]
    [Browsable(false)]
    public bool ContainsListCollection
    {
      get
      {
        return false;
      }
    }

    /// <summary>
    /// The <see cref="T:SD.LLBLGen.Pro.ORMSupportClasses.ITransaction"/> this ITransactionalElement implementing object is participating in. Only valid if
    ///             <see cref="P:SD.LLBLGen.Pro.ORMSupportClasses.EntityCollectionBase`1.ParticipatesInTransaction"/> is true. If set to null, the ITransactionalElement is no longer participating
    ///             in a transaction.
    /// 
    /// </summary>
    [XmlIgnore]
    public virtual ITransaction Transaction
    {
      get
      {
        return this._containingTransaction;
      }
      set
      {
        if (value != null && this._containingTransaction != null)
          return;
        this._containingTransaction = value;
      }
    }

    /// <summary>
    /// Flag to check if the ITransactionalElement implementing object is participating in a transaction or not.
    /// 
    /// </summary>
    [XmlIgnore]
    public virtual bool ParticipatesInTransaction
    {
      get
      {
        return this._containingTransaction != null;
      }
    }

    /// <summary>
    /// The maximum number of items to return with this retrieval query.
    ///             If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return.
    ///             When set to 0, no limitations are specified.
    /// 
    /// </summary>
    [XmlIgnore]
    public long MaxNumberOfItemsToReturn
    {
      get
      {
        return this._maxNumberOfItemsToReturn;
      }
      set
      {
        this._maxNumberOfItemsToReturn = value;
      }
    }

    /// <summary>
    /// The order by specifications for the sorting of the resultset when fetching it from the persistent storage.
    ///             When not specified, no sorting is applied.
    /// 
    /// </summary>
    [XmlIgnore]
    public ISortExpression SortClauses
    {
      get
      {
        return this._sortClauses;
      }
      set
      {
        this._sortClauses = value;
      }
    }

    /// <summary>
    /// Returns true if this collection contains dirty objects. If this collection contains dirty objects, an
    ///             already filled collection should not be refreshed until a save is performed. This property is calculated in real time
    ///             and can be time consuming when the collection contains a lot of objects. Use this property only in cases when the value
    ///             of this property is used to do a refetch or not.
    /// 
    /// </summary>
    [XmlIgnore]
    public bool ContainsDirtyContents
    {
      get
      {
        for (int index = 0; index < this.Count; ++index)
        {
          if (this[index].Fields.IsDirty)
            return true;
        }
        return false;
      }
    }

    /// <summary>
    /// Surpresses the removal of all contents of the collection in a GetMulti*() call. Used by code in related entities to prevent the removal
    ///             of objects when collection properties are accessed.
    /// 
    /// </summary>
    public bool SuppressClearInGetMulti
    {
      get
      {
        return this._suppressClearInGetMulti;
      }
      set
      {
        this._suppressClearInGetMulti = value;
      }
    }

    /// <summary>
    /// Gets / sets the active context this entity collection is in. Setting this property is not adding the entity collection to the context,
    ///             it will make contained entities be added to the passed in context. If the entity collection is already in a context, setting this property has no effect.
    ///             Setting this property is done by framework code, use the Context's Add/Get methods to work with contexts and entity collections.
    /// 
    /// </summary>
    [XmlIgnore]
    public Context ActiveContext
    {
      get
      {
        return this._activeContext;
      }
      set
      {
        if ((this._activeContext != null || value == null) && (this._activeContext == null || value != null))
          return;
        if (this._activeContext == null && value != null)
          this.DoNotPerformAddIfPresent = true;
        this._activeContext = value;
        this.AddContainedEntitiesToContext();
      }
    }

    /// <summary>
    /// The EntityFactory to use when creating entity objects during a GetMulti() call or other logic which requires the creation of new entities.
    /// 
    /// </summary>
    /// 
    /// <value/>
    public IEntityFactory EntityFactoryToUse
    {
      get
      {
        return this._entityFactoryToUse;
      }
      set
      {
        if (this._entityFactoryToUse != null && value == null)
          return;
        this._entityFactoryToUse = value;
      }
    }

    /// <summary>
    /// Gets the default view for this entitycollection. The returned value is the same instance every time this property is read.
    ///             It's an entity view without a filter or a sorter.
    /// 
    /// </summary>
    /// 
    /// <value>
    /// The default view.
    /// </value>
    [XmlIgnore]
    [Browsable(false)]
    public EntityView<TEntity> DefaultView
    {
      get
      {
        if (this._defaultView == null)
          this._defaultView = this.CreateDefaultEntityView();
        return this._defaultView;
      }
    }

    /// <summary>
    /// Gets or sets the entity collection which should be used as removed entities tracker. If this property is set to an IEntityCollection instance,
    ///             all entities which are removed from this collection are marked for deletion and placed in this removed entities tracker collection.
    ///             This collection can then later on be used to delete these entities from the database in one go.
    /// 
    /// </summary>
    [Browsable(false)]
    [XmlIgnore]
    public IEntityCollection RemovedEntitiesTracker
    {
      get
      {
        return this._removedEntitiesTracker;
      }
      set
      {
        this._removedEntitiesTracker = value;
      }
    }

    /// <summary>
    /// Gets the entity which contains this collection (e.g. Customer, if this collection is the Customer's Orders collection), or null if this
    ///             collection isn't part of any entity.
    /// 
    /// </summary>
    [XmlIgnore]
    [Browsable(false)]
    protected IEntity ContainingEntity
    {
      get
      {
        return this._containingEntity;
      }
    }

    /// <summary>
    /// Gets the name of the field mapped onto the relation in the opposite entity which is represented by this collection, if this collection is
    ///             contained by an entity. E.g. it will return "Customer" if the relation Customer - Order has the field 'Customer' mapped onto it in Order and
    ///             this collection is the Orders collection in Customer. If this collection isn't contained in any entity, an empty string is returned.
    /// 
    /// </summary>
    [XmlIgnore]
    [Browsable(false)]
    protected string ContainingEntityMappedField
    {
      get
      {
        return this._containingEntityMappedField;
      }
    }

    /// <summary>
    /// CTor
    /// 
    /// </summary>
    /// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
    protected EntityCollectionBase(IEntityFactory entityFactoryToUse)
    {
      this.InitClass(entityFactoryToUse);
    }

    /// <summary>
    /// Private CTor for deserialization
    /// 
    /// </summary>
    /// <param name="info"/><param name="context"/>
    protected EntityCollectionBase(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      try
      {
        this.DeserializationInProgress = true;
        this._maxNumberOfItemsToReturn = info.GetInt64("_maxNumberOfItemsToReturn");
        this._sortClauses = (ISortExpression) info.GetValue("_sortClauses", typeof (ISortExpression));
        this._entityFactoryToUse = (IEntityFactory) info.GetValue("_entityFactoryToUse", typeof (IEntityFactory));
        this._suppressClearInGetMulti = info.GetBoolean("_suppressClearInGetMulti");
        this._containingEntity = (IEntity) info.GetValue("_containingEntity", typeof (IEntity));
        this._containingEntityMappedField = info.GetString("_containingEntityMappedField");
      }
      finally
      {
        this.DeserializationInProgress = false;
      }
    }

    /// <summary>
    /// Will add a new entity to the list, will set its parent collection property so CancelEdit will remove
    ///             it from the list again, and will set its flag that it is added by databinding.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// Do not call this method from your own code. This is a databinding ONLY method.
    /// </remarks>
    /// <exception cref="T:System.InvalidOperationException">If this collection is set to ReadOnly</exception>
    public override TEntity AddNew()
    {
      if (this.IsReadOnly && this.Site == null)
        throw new InvalidOperationException("This collection is read-only.");
      TEntity entity = (TEntity) this._entityFactoryToUse.Create();
      entity.IsNewViaDataBinding = true;
      entity.ParentCollection = (IEntityCollection) this;
      if (this.ConcurrencyPredicateFactoryToUse != null)
        entity.ConcurrencyPredicateFactoryToUse = this.ConcurrencyPredicateFactoryToUse;
      this.Add(entity);
      return entity;
    }

    /// <summary>
    /// Sets the entity information of the entity object containing this collection. Call this method only from
    ///             entity classes which contain EntityCollection members, like 'Customer' which contains 'Orders' entity collection.
    /// 
    /// </summary>
    /// <param name="containingEntity">The entity containing this entity collection as a member variable</param><param name="fieldName">The field the related entity has mapped onto the relation which delivers the entities contained
    ///             in this collection</param>
    public void SetContainingEntityInfo(IEntity containingEntity, string fieldName)
    {
      this._containingEntity = containingEntity;
      this._containingEntityMappedField = fieldName;
      this.ActiveContext = this._containingEntity.ActiveContext;
      EntityBase entityBase = containingEntity as EntityBase;
      if (entityBase != null)
        this.Site = entityBase.Site;
      this.AddContainedEntitiesToContext();
    }

    /// <summary>
    /// When the <see cref="T:SD.LLBLGen.Pro.ORMSupportClasses.ITransaction"/> in which this IEntity participates is commited, this IEntity can succesfully finish actions performed by this
    ///             IEntity. This method is called by <see cref="T:SD.LLBLGen.Pro.ORMSupportClasses.ITransaction"/>, you should not call it by yourself. When this IEntity doesn't participate in a
    ///             transaction it finishes the actions itself, calling this method is not needed.
    /// 
    /// </summary>
    public void TransactionCommit()
    {
    }

    /// <summary>
    /// When the <see cref="T:SD.LLBLGen.Pro.ORMSupportClasses.ITransaction"/> in which this IEntity participates is rolled back, this IEntity has to roll back its internal variables.
    ///             This method is called by <see cref="T:SD.LLBLGen.Pro.ORMSupportClasses.ITransaction"/>, you should not call it by yourself.
    /// 
    /// </summary>
    public void TransactionRollback()
    {
    }

    /// <summary>
    /// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in
    ///             this collection. Per entity type found, a new datatable is created inside destination or if one with the name of the entity is already present,
    ///             that one is used. It will simply project every data element.
    /// 
    /// </summary>
    /// <param name="destination">The destination dataset in which the projection result is stored. Each DataTable has the name of the entity contained,
    ///             e.g. "CustomerEntity". DataRelations are created between the data if applicable.</param>
    /// <remarks>
    /// Data in destination's datatables (if present) is removed before a projection is performed.
    /// </remarks>
    public void CreateHierarchicalProjection(DataSet destination)
    {
      List<IViewProjectionData> list = new List<IViewProjectionData>();
      Dictionary<Type, IEntityCollection> entitiesPerType;
      this.BuildCollectionProjectors((ICollection<IViewProjectionData>) list, out entitiesPerType);
      EntityCollectionBase<TEntity>.CreateHierarchicalProjectionInternal((IEnumerable<IViewProjectionData>) list, destination, entitiesPerType);
    }

    /// <summary>
    /// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in
    ///             this collection. Per entity type found, an entry is stored inside the destination dictionary. It will simply project every data element.
    /// 
    /// </summary>
    /// <param name="destination">The destination dictionary in which the projection result is stored.</param>
    /// <remarks>
    /// destination is cleared before a projection is performed.
    /// </remarks>
    public void CreateHierarchicalProjection(Dictionary<Type, IEntityCollection> destination)
    {
      List<IViewProjectionData> list = new List<IViewProjectionData>();
      Dictionary<Type, IEntityCollection> entitiesPerType;
      this.BuildCollectionProjectors((ICollection<IViewProjectionData>) list, out entitiesPerType);
      EntityCollectionBase<TEntity>.CreateHierarchicalProjectionInternal((IEnumerable<IViewProjectionData>) list, destination, entitiesPerType);
    }

    /// <summary>
    /// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in this
    ///             collection, using the collectionProjections data passed in. Per entity type found, a new datatable is created inside destination or if one with
    ///             the name of the entity is already present, that one is used.
    /// 
    /// </summary>
    /// <param name="collectionProjections">The projection data per entity type</param><param name="destination">The destination dataset in which the projection result is stored. Each DataTable has the name of the entity contained,
    ///             e.g. "CustomerEntity". DataRelations are created between the data if applicable.</param>
    /// <remarks>
    /// Data in destination's datatables (if present) is removed before a projection is performed.
    /// </remarks>
    public void CreateHierarchicalProjection(List<IViewProjectionData> collectionProjections, DataSet destination)
    {
      Dictionary<Type, IEntityCollection> entitiesPerType = new ObjectGraphUtils().ProduceCollectionsPerTypeFromGraph<IEntityCollection>((IEntityCollection) this);
      EntityCollectionBase<TEntity>.CreateHierarchicalProjectionInternal((IEnumerable<IViewProjectionData>) collectionProjections, destination, entitiesPerType);
    }

    /// <summary>
    /// Creates a hierarchical projection of all the data in this view and for each type in the complete graph found starting with each entity in this view,
    ///             using the viewProjections data passed in. Per entity type found, an entry is stored inside the destination dictionary.
    /// 
    /// </summary>
    /// <param name="collectionProjections">The projection data per entity type</param><param name="destination">The destination dictionary in which the projection result is stored.</param>
    /// <remarks>
    /// destination is cleared before a projection is performed.
    /// </remarks>
    public void CreateHierarchicalProjection(List<IViewProjectionData> collectionProjections, Dictionary<Type, IEntityCollection> destination)
    {
      Dictionary<Type, IEntityCollection> entitiesPerType = new ObjectGraphUtils().ProduceCollectionsPerTypeFromGraph<IEntityCollection>((IEntityCollection) this);
      EntityCollectionBase<TEntity>.CreateHierarchicalProjectionInternal((IEnumerable<IViewProjectionData>) collectionProjections, destination, entitiesPerType);
    }

    /// <summary>
    /// Builds the collection projectors for this collection.
    /// 
    /// </summary>
    /// <param name="collectionProjections">The collection projections.</param><param name="entitiesPerType">Type of the entities per.</param>
    private void BuildCollectionProjectors(ICollection<IViewProjectionData> collectionProjections, out Dictionary<Type, IEntityCollection> entitiesPerType)
    {
      ObjectGraphUtils objectGraphUtils = new ObjectGraphUtils();
      entitiesPerType = objectGraphUtils.ProduceCollectionsPerTypeFromGraph<IEntityCollection>((IEntityCollection) this);
      foreach (KeyValuePair<Type, IEntityCollection> keyValuePair in entitiesPerType)
      {
        ViewProjectionData<EntityBase> viewProjectionData = new ViewProjectionData<EntityBase>(EntityFieldsCore<IEntityField>.ConvertToProjectors((IEntityFieldsCore) ((IEntity) Activator.CreateInstance(keyValuePair.Key)).Fields), (IPredicate) null, true, keyValuePair.Key);
        collectionProjections.Add((IViewProjectionData) viewProjectionData);
      }
    }

    /// <summary>
    /// Creates the hierarchical projection for the entities per type passed in into the destination specified.
    /// 
    /// </summary>
    /// <param name="collectionProjections">The collection projections.</param><param name="destination">The destination.</param><param name="entitiesPerType">Type of the entities per.</param>
    private static void CreateHierarchicalProjectionInternal(IEnumerable<IViewProjectionData> collectionProjections, DataSet destination, Dictionary<Type, IEntityCollection> entitiesPerType)
    {
      Dictionary<Type, List<IEntityRelation>> dictionary = new Dictionary<Type, List<IEntityRelation>>();
      foreach (IViewProjectionData viewProjectionData in collectionProjections)
      {
        IEntity entity = (IEntity) Activator.CreateInstance(viewProjectionData.TypeOfTargetEntity);
        dictionary[viewProjectionData.TypeOfTargetEntity] = entity.GetAllRelations();
        IEntityCollection entityCollection;
        if (!entitiesPerType.TryGetValue(viewProjectionData.TypeOfTargetEntity, out entityCollection))
          entityCollection = entity.GetEntityFactory().CreateEntityCollection();
        bool flag = false;
        DataTable dataTable = destination.Tables[entity.LLBLGenProEntityName];
        if (dataTable == null)
        {
          dataTable = new DataTable(entity.LLBLGenProEntityName);
          destination.Tables.Add(dataTable);
          flag = true;
        }
        else
          dataTable.Clear();
        entityCollection.DefaultView.CreateProjection(viewProjectionData.Projectors, dataTable, viewProjectionData.AllowDuplicates, viewProjectionData.AdditionalFilter);
        if (flag)
        {
          int length = FieldUtilities.DetermineNumberOfPkFields((IList) entity.PrimaryKeyFields);
          if (length > 0)
          {
            DataColumn[] dataColumnArray = new DataColumn[length];
            int num = entity.PrimaryKeyFields.Count - length;
            for (int index = 0; index < length; ++index)
            {
              IEntityField entityField = entity.PrimaryKeyFields[num + index];
              dataColumnArray[index] = dataTable.Columns[entityField.Name];
            }
            dataTable.PrimaryKey = dataColumnArray;
          }
        }
      }
      foreach (IViewProjectionData viewProjectionData in collectionProjections)
      {
        List<IEntityRelation> relations = dictionary[viewProjectionData.TypeOfTargetEntity];
        GeneralUtils.CreateDataRelations(destination, relations);
      }
    }

    /// <summary>
    /// Creates the hierarchical projection for the entities per type passed in into the destination specified.
    /// 
    /// </summary>
    /// <param name="collectionProjections">The collection projections.</param><param name="destination">The destination.</param><param name="entitiesPerType">Type of the entities per.</param>
    private static void CreateHierarchicalProjectionInternal(IEnumerable<IViewProjectionData> collectionProjections, Dictionary<Type, IEntityCollection> destination, Dictionary<Type, IEntityCollection> entitiesPerType)
    {
      destination.Clear();
      Dictionary<Type, List<IEntityRelation>> dictionary = new Dictionary<Type, List<IEntityRelation>>();
      foreach (IViewProjectionData viewProjectionData in collectionProjections)
      {
        IEntity entity = (IEntity) Activator.CreateInstance(viewProjectionData.TypeOfTargetEntity);
        dictionary[viewProjectionData.TypeOfTargetEntity] = entity.GetAllRelations();
        IEntityCollection entityCollection1;
        if (!entitiesPerType.TryGetValue(viewProjectionData.TypeOfTargetEntity, out entityCollection1))
          entityCollection1 = entity.GetEntityFactory().CreateEntityCollection();
        IEntityCollection entityCollection2 = entity.GetEntityFactory().CreateEntityCollection();
        entityCollection1.DefaultView.CreateProjection(viewProjectionData.Projectors, entityCollection2, viewProjectionData.AllowDuplicates, viewProjectionData.AdditionalFilter);
        destination.Add(entity.GetType(), entityCollection2);
      }
    }

    /// <summary>
    /// Creates a new EntityView object of the right type on this collection with no filter nor sorter applied.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// new EntityView on this collection
    /// </returns>
    public IEntityView CreateView()
    {
      return this.CreateView((IPredicate) null, (ISortExpression) null, PostCollectionChangeAction.ReapplyFilterAndSorter);
    }

    /// <summary>
    /// Creates a new EntityView object of the right type on this collection with the passed in filter applied
    /// 
    /// </summary>
    /// <param name="filter">The filter.</param>
    /// <returns>
    /// new EntityView on this collection
    /// </returns>
    public IEntityView CreateView(IPredicate filter)
    {
      return this.CreateView(filter, (ISortExpression) null, PostCollectionChangeAction.ReapplyFilterAndSorter);
    }

    /// <summary>
    /// Creates a new EntityView object of the right type on this collection with the passed in filter and sorter applied to it.
    /// 
    /// </summary>
    /// <param name="filter">The filter.</param><param name="sorter">The sorter.</param>
    /// <returns>
    /// new EntityView on this collection
    /// </returns>
    public IEntityView CreateView(IPredicate filter, ISortExpression sorter)
    {
      return this.CreateView(filter, sorter, PostCollectionChangeAction.ReapplyFilterAndSorter);
    }

    /// <summary>
    /// Creates a new EntityView object of the right type on this collection with the passed in filter and sorter applied to it and the
    ///             dataChangeAction set to the passed in value.
    /// 
    /// </summary>
    /// <param name="filter">The filter.</param><param name="sorter">The sorter.</param><param name="dataChangeAction">The data change action to take if data in the related collection changes.</param>
    /// <returns>
    /// new EntityView on this collection
    /// </returns>
    public IEntityView CreateView(IPredicate filter, ISortExpression sorter, PostCollectionChangeAction dataChangeAction)
    {
      return (IEntityView) new EntityView<TEntity>((CollectionCore<TEntity>) this, filter, sorter, dataChangeAction);
    }

    /// <summary>
    /// Saves all new/dirty Entities in the IEntityCollection in the persistent storage. If this IEntityCollection is added
    ///             to a transaction, the save processes will be done in that transaction, if the entity isn't already added to another transaction.
    ///             If the entity is already in another transaction, it will use that transaction. If no transaction is present, the saves are done in a
    ///             new Transaction (which is created in an inherited method.). Will not recursively save entities inside the collection.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// Amount of entities inserted
    /// </returns>
    /// 
    /// <remarks>
    /// All exceptions will be bubbled upwards so transaction code can anticipate on exceptions.
    /// </remarks>
    public int SaveMulti()
    {
      return this.SaveMulti(false);
    }

    /// <summary>
    /// Saves all new/dirty Entities in the IEntityCollection in the persistent storage. If this IEntityCollection is added to a transaction, the save processes will be done in that transaction, if the entity isn't already added to another transaction.
    ///             If the entity is already in another transaction, it will use that transaction. If no transaction is present, the saves are done in a new Transaction (which is created in an inherited method.)
    /// </summary>
    /// <param name="recurse">If true, will recursively save the entities inside the collection</param>
    /// <returns>
    /// Amount of entities inserted
    /// </returns>
    /// 
    /// <remarks>
    /// All exceptions will be bubbled upwards so transaction code can anticipate on exceptions.
    /// </remarks>
    public virtual int SaveMulti(bool recurse)
    {
      int num;
      if (!this.ParticipatesInTransaction)
      {
        ITransaction transaction = this.CreateTransaction(IsolationLevel.ReadCommitted, "SaveMulti");
        transaction.Add((ITransactionalElement) this);
        try
        {
          num = this.PerformSaveMulti(recurse);
          transaction.Commit();
        }
        catch
        {
          transaction.Rollback();
          throw;
        }
      }
      else
        num = this.PerformSaveMulti(recurse);
      return num;
    }

    /// <summary>
    /// Deletes all Entities in the IEntityCollection from the persistent storage. If this IEntityCollection is added
    ///             to a transaction, the delete processes will be done in that transaction, if the entity isn't already added to another transaction.
    ///             If the entity is already in another transaction, it will use that transaction. If no transaction is present, the deletes are done in a/ new Transaction.
    ///             Deleted entities are marked deleted and are removed from the collection.
    /// </summary>
    /// 
    /// <returns>
    /// Amount of entities deleted
    /// </returns>
    public virtual int DeleteMulti()
    {
      int num;
      if (!this.ParticipatesInTransaction)
      {
        ITransaction transaction = this.CreateTransaction(IsolationLevel.ReadCommitted, "DeleteMulti");
        transaction.Add((ITransactionalElement) this);
        try
        {
          num = this.PerformDeleteMulti();
          transaction.Commit();
        }
        catch
        {
          transaction.Rollback();
          throw;
        }
      }
      else
        num = this.PerformDeleteMulti();
      return num;
    }

    /// <summary>
    /// Deletes from the persistent storage all entities of the type this collection is for which match with the specified filter,
    ///             formulated in the predicate or predicate expression definition.
    /// </summary>
    /// <param name="deleteFilter">A predicate or predicate expression which should be used as filter for the entities to delete. Can be null,
    ///             which will result in a query removing all entities of the type this collection is for from the persistent storage</param>
    /// <returns>
    /// Amount of entities affected, if the used persistent storage has rowcounting enabled.
    /// </returns>
    /// 
    /// <remarks>
    /// Not supported for entities which are in a hierarchy of TargetPerEntity
    /// </remarks>
    public virtual int DeleteMulti(IPredicate deleteFilter)
    {
      return this.DeleteMulti(deleteFilter, (IRelationCollection) null);
    }

    /// <summary>
    /// Deletes from the persistent storage all entities of the type this collection is for which match with the specified filter,
    ///             formulated in the predicate or predicate expression definition.
    /// </summary>
    /// <param name="deleteFilter">A predicate or predicate expression which should be used as filter for the entities to delete. Can be null,
    ///             which will result in a query removing all entities of the type this collection is for from the persistent storage</param><param name="relations">The set of relations to walk to construct the total query.</param>
    /// <remarks>
    /// Not supported for entities which are in a hierarchy of TargetPerEntity
    /// </remarks>
    public virtual int DeleteMulti(IPredicate deleteFilter, IRelationCollection relations)
    {
      IDao daoInstance = this.CreateDAOInstance();
      bool flag = false;
      ITransaction transaction = (ITransaction) null;
      int num;
      try
      {
        if (!this.ParticipatesInTransaction && this._entityFactoryToUse != null && ((EntityCore<IEntityFields>) this._entityFactoryToUse.Create()).CallOnRequiresTransactionForAuditEntities(SingleStatementQueryAction.DirectDeleteEntities))
        {
          transaction = this.CreateTransaction(IsolationLevel.ReadCommitted, "delDirectTrans");
          flag = true;
          transaction.Add((ITransactionalElement) this);
        }
        num = daoInstance.DeleteMulti(this.Transaction, deleteFilter, relations);
        if (flag)
          transaction.Commit();
      }
      catch
      {
        if (flag)
          transaction.Rollback();
        throw;
      }
      finally
      {
        if (flag)
          transaction.Dispose();
      }
      return num;
    }

    /// <summary>
    /// Updates in the persistent storage all entities of the type this collection is for which have data in common with the specified
    ///             entity. Which fields are updated in those matching entities depends on which fields are
    ///             <i>changed</i> in entityWithNewValues. The new values of these fields are read from entityWithNewValues.
    /// </summary>
    /// <param name="entityWithNewValues">entity instance which holds the new values for the matching entities to update. Only changed fields are taken
    ///             into account</param><param name="updateFilter">A predicate or predicate expression which should be used as filter for the entities to update. Can be null, which
    ///             will result in an update action which will affect all Customer entities.</param>
    /// <returns>
    /// Amount of entities affected, if the used persistent storage has rowcounting enabled.
    /// </returns>
    public int UpdateMulti(IEntity entityWithNewValues, IPredicate updateFilter)
    {
      return this.UpdateMulti(entityWithNewValues, updateFilter, (IRelationCollection) null);
    }

    /// <summary>
    /// Updates in the persistent storage all entities of the type this collection is for which have data in common with the specified
    ///             entity. Which fields are updated in those matching entities depends on which fields are
    ///             <i>changed</i> in entityWithNewValues. The new values of these fields are read from entityWithNewValues.
    /// </summary>
    /// <param name="entityWithNewValues">entity instance which holds the new values for the matching entities to update. Only changed fields are taken
    ///             into account</param><param name="updateFilter">A predicate or predicate expression which should be used as filter for the entities to update.</param><param name="relations">The set of relations to walk to construct the total query.</param>
    /// <returns>
    /// Amount of entities affected, if the used persistent storage has rowcounting enabled.
    /// </returns>
    public int UpdateMulti(IEntity entityWithNewValues, IPredicate updateFilter, IRelationCollection relations)
    {
      IDao daoInstance = this.CreateDAOInstance();
      bool flag = false;
      ITransaction transaction = (ITransaction) null;
      int num;
      try
      {
        if (!this.ParticipatesInTransaction && ((EntityCore<IEntityFields>) entityWithNewValues).CallOnRequiresTransactionForAuditEntities(SingleStatementQueryAction.DirectUpdateEntities))
        {
          transaction = this.CreateTransaction(IsolationLevel.ReadCommitted, "delDirectTrans");
          flag = true;
          transaction.Add((ITransactionalElement) this);
        }
        num = daoInstance.UpdateMulti(entityWithNewValues, this.Transaction, updateFilter, relations);
        if (flag)
          transaction.Commit();
      }
      catch
      {
        if (flag)
          transaction.Rollback();
        throw;
      }
      finally
      {
        if (flag)
          transaction.Dispose();
      }
      return num;
    }

    /// <summary>
    /// Loads the data for the excluded fields specified in the list of excluded fields into all the entities in this collection.
    /// 
    /// </summary>
    /// <param name="excludedIncludedFields">The excludedIncludedFields object as it is used when fetching the entity. If you used
    ///             the excludedIncludedFields object to fetch only the fields in that list (i.e. excludedIncludedFields.ExcludeContainedFields==false), the routine
    ///             will fetch all other fields in the resultset for the entities in the collection excluding the fields in excludedIncludedFields.</param>
    /// <remarks>
    /// The field data is set like a normal field value set, so authorization is applied to it.
    ///             This routine batches fetches to have at most 5*DaoBase.ParameterisedPrefetchPathThreshold of parameters per fetch. Keep in mind
    ///             that most databases have a limit on the # of parameters per query.
    /// 
    /// </remarks>
    public virtual void FetchExcludedFields(ExcludeIncludeFieldsList excludedIncludedFields)
    {
      this.CreateDAOInstance().FetchExcludedFields((IEntityCollection) this, this.Transaction, excludedIncludedFields);
    }

    /// <summary>
    /// Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.
    /// </summary>
    /// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param>
    /// <returns>
    /// true if succeeded, false otherwise
    /// </returns>
    public bool GetMulti(IPredicate selectFilter)
    {
      return this.GetMulti(selectFilter, this.MaxNumberOfItemsToReturn, this.SortClauses, (IRelationCollection) null, (IPrefetchPath) null, (ExcludeIncludeFieldsList) null, 0, 0);
    }

    /// <summary>
    /// Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.
    /// </summary>
    /// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param><param name="maxNumberOfItemsToReturn">The maximum number of items to return with this retrieval query.</param>
    /// <returns>
    /// true if succeeded, false otherwise
    /// </returns>
    public bool GetMulti(IPredicate selectFilter, long maxNumberOfItemsToReturn)
    {
      return this.GetMulti(selectFilter, maxNumberOfItemsToReturn, this.SortClauses, (IRelationCollection) null, (IPrefetchPath) null, (ExcludeIncludeFieldsList) null, 0, 0);
    }

    /// <summary>
    /// Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.
    /// </summary>
    /// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param><param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch.
    ///             If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
    ///             is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param><param name="maxNumberOfItemsToReturn">The maximum number of items to return with this retrieval query.</param>
    /// <returns>
    /// true if succeeded, false otherwise
    /// </returns>
    public bool GetMulti(IPredicate selectFilter, ExcludeIncludeFieldsList excludedIncludedFields, long maxNumberOfItemsToReturn)
    {
      return this.GetMulti(selectFilter, maxNumberOfItemsToReturn, this.SortClauses, (IRelationCollection) null, (IPrefetchPath) null, excludedIncludedFields, 0, 0);
    }

    /// <summary>
    /// Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.
    /// </summary>
    /// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param><param name="maxNumberOfItemsToReturn">The maximum number of items to return with this retrieval query.</param><param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
    /// <returns>
    /// true if succeeded, false otherwise
    /// </returns>
    public bool GetMulti(IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses)
    {
      return this.GetMulti(selectFilter, maxNumberOfItemsToReturn, sortClauses, (IRelationCollection) null, (IPrefetchPath) null, (ExcludeIncludeFieldsList) null, 0, 0);
    }

    /// <summary>
    /// Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.
    /// </summary>
    /// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param><param name="relations">The set of relations to walk to construct the total query.</param>
    /// <returns>
    /// true if succeeded, false otherwise
    /// </returns>
    public bool GetMulti(IPredicate selectFilter, IRelationCollection relations)
    {
      return this.GetMulti(selectFilter, this.MaxNumberOfItemsToReturn, this.SortClauses, relations, (IPrefetchPath) null, (ExcludeIncludeFieldsList) null, 0, 0);
    }

    /// <summary>
    /// Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.
    /// </summary>
    /// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param><param name="maxNumberOfItemsToReturn">The maximum number of items to return with this retrieval query.</param><param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param><param name="relations">The set of relations to walk to construct the total query.</param>
    /// <returns>
    /// true if succeeded, false otherwise
    /// </returns>
    public bool GetMulti(IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations)
    {
      return this.GetMulti(selectFilter, maxNumberOfItemsToReturn, sortClauses, relations, (IPrefetchPath) null, (ExcludeIncludeFieldsList) null, 0, 0);
    }

    /// <summary>
    /// Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.
    /// </summary>
    /// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param><param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
    /// <returns>
    /// true if succeeded, false otherwise
    /// </returns>
    public bool GetMulti(IPredicate selectFilter, IPrefetchPath prefetchPathToUse)
    {
      return this.GetMulti(selectFilter, this.MaxNumberOfItemsToReturn, this.SortClauses, (IRelationCollection) null, prefetchPathToUse, (ExcludeIncludeFieldsList) null, 0, 0);
    }

    /// <summary>
    /// Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.
    /// </summary>
    /// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param><param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch.
    ///             If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
    ///             is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param><param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
    /// <returns>
    /// true if succeeded, false otherwise
    /// </returns>
    public bool GetMulti(IPredicate selectFilter, ExcludeIncludeFieldsList excludedIncludedFields, IPrefetchPath prefetchPathToUse)
    {
      return this.GetMulti(selectFilter, this.MaxNumberOfItemsToReturn, this.SortClauses, (IRelationCollection) null, prefetchPathToUse, excludedIncludedFields, 0, 0);
    }

    /// <summary>
    /// Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.
    /// </summary>
    /// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param><param name="maxNumberOfItemsToReturn">The maximum number of items to return with this retrieval query.</param><param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param><param name="relations">The set of relations to walk to construct the total query.</param><param name="pageNumber">The page number to retrieve.</param><param name="pageSize">The page size of the page to retrieve.</param>
    /// <returns>
    /// true if succeeded, false otherwise
    /// </returns>
    public bool GetMulti(IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations, int pageNumber, int pageSize)
    {
      return this.GetMulti(selectFilter, maxNumberOfItemsToReturn, sortClauses, relations, (IPrefetchPath) null, (ExcludeIncludeFieldsList) null, pageNumber, pageSize);
    }

    /// <summary>
    /// Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.
    /// </summary>
    /// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param><param name="maxNumberOfItemsToReturn">The maximum number of items to return with this retrieval query.</param><param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param><param name="relations">The set of relations to walk to construct the total query.</param><param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
    /// <returns>
    /// true if succeeded, false otherwise
    /// </returns>
    public bool GetMulti(IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations, IPrefetchPath prefetchPathToUse)
    {
      return this.GetMulti(selectFilter, maxNumberOfItemsToReturn, sortClauses, relations, prefetchPathToUse, (ExcludeIncludeFieldsList) null, 0, 0);
    }

    /// <summary>
    /// Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.
    /// </summary>
    /// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param><param name="maxNumberOfItemsToReturn">The maximum number of items to return with this retrieval query.</param><param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param><param name="relations">The set of relations to walk to construct the total query.</param><param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param><param name="pageNumber">The page number to retrieve.</param><param name="pageSize">The page size of the page to retrieve.</param>
    /// <returns>
    /// true if succeeded, false otherwise
    /// </returns>
    public bool GetMulti(IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations, IPrefetchPath prefetchPathToUse, int pageNumber, int pageSize)
    {
      return this.GetMulti(selectFilter, maxNumberOfItemsToReturn, sortClauses, relations, prefetchPathToUse, (ExcludeIncludeFieldsList) null, pageNumber, pageSize);
    }

    /// <summary>
    /// Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.
    /// </summary>
    /// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param><param name="maxNumberOfItemsToReturn">The maximum number of items to return with this retrieval query.</param><param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param><param name="relations">The set of relations to walk to construct the total query.</param><param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param><param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch.
    ///             If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
    ///             is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param><param name="pageNumber">The page number to retrieve.</param><param name="pageSize">The page size of the page to retrieve.</param>
    /// <returns>
    /// true if succeeded, false otherwise
    /// </returns>
    public bool GetMulti(IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations, IPrefetchPath prefetchPathToUse, ExcludeIncludeFieldsList excludedIncludedFields, int pageNumber, int pageSize)
    {
      if (!this.SuppressClearInGetMulti)
        this.Clear();
      return ((DaoBase) this.CreateDAOInstance()).GetMulti(this.Transaction, (IEntityCollection) this, maxNumberOfItemsToReturn, sortClauses, this.EntityFactoryToUse, selectFilter, relations, prefetchPathToUse, excludedIncludedFields, pageNumber, pageSize);
    }

    /// <summary>
    /// Gets the amount of Entity objects in the database.
    /// </summary>
    /// 
    /// <returns>
    /// the amount of objects found
    /// </returns>
    public int GetDbCount()
    {
      return this.GetDbCount((IPredicate) null, (IRelationCollection) null);
    }

    /// <summary>
    /// Gets the amount of Entity objects in the database, when taking into account the filter specified.
    /// </summary>
    /// <param name="filter">the filter to apply</param>
    /// <returns>
    /// the amount of objects found
    /// </returns>
    public int GetDbCount(IPredicate filter)
    {
      return this.GetDbCount(filter, (IRelationCollection) null);
    }

    /// <summary>
    /// Gets the amount of Entity objects in the database, when taking into account the filter specified and the relations specified.
    /// </summary>
    /// <param name="filter">the filter to apply</param><param name="relations">The relations to walk</param>
    /// <returns>
    /// the amount of objects found
    /// </returns>
    public int GetDbCount(IPredicate filter, IRelationCollection relations)
    {
      return ((DaoBase) this.CreateDAOInstance()).GetDbCount(this.EntityFactoryToUse.Create().Fields, this.Transaction, filter, relations, (IGroupByCollection) null);
    }

    /// <summary>
    /// ISerializable member.
    /// 
    /// </summary>
    /// <param name="info"/><param name="context"/>
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      base.GetObjectData(info, context);
      info.AddValue("_maxNumberOfItemsToReturn", this._maxNumberOfItemsToReturn);
      info.AddValue("_sortClauses", (object) this._sortClauses, typeof (ISortExpression));
      info.AddValue("_entityFactoryToUse", (object) this._entityFactoryToUse);
      info.AddValue("_suppressClearInGetMulti", this._suppressClearInGetMulti);
      info.AddValue("_containingEntity", (object) this._containingEntity, typeof (IEntity));
      info.AddValue("_containingEntityMappedField", (object) this._containingEntityMappedField);
    }

    /// <summary>
    /// Sorts the collection.
    /// 
    /// </summary>
    /// <param name="fieldIndex">Field to sort on</param><param name="direction">the sort direction</param><param name="comparerToUse">The comparer to use. If null, it will use the default comparer.</param>
    /// <remarks>
    /// For backwards compatibility.
    /// </remarks>
    public override void Sort(int fieldIndex, ListSortDirection direction, IComparer<object> comparerToUse)
    {
      if (this.Count <= 0 || fieldIndex < 0 || fieldIndex >= this[0].Fields.Count)
        return;
      base.Sort(TypeDescriptor.GetProperties(this[0].GetType())[this[0].Fields[fieldIndex].Name], direction, comparerToUse);
    }

    /// <summary>
    /// Converts this entity collection to XML, recursively. Uses "EntityCollection" for the rootnode name
    /// 
    /// </summary>
    /// <param name="aspects">The aspect flags to control the format of the XML produced</param><param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
    public void WriteXml(XmlFormatAspect aspects, out string entityCollectionXml)
    {
      this.WriteXml(aspects, "EntityCollection", out entityCollectionXml);
    }

    /// <summary>
    /// Converts this entity collection to XML. Uses "EntityCollection" for the rootnode name
    /// 
    /// </summary>
    /// <param name="aspects">The aspect flags to control the format of the XML produced</param><param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
    ///             to create the new node object</param><param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
    public void WriteXml(XmlFormatAspect aspects, XmlDocument parentDocument, out XmlNode entityCollectionNode)
    {
      this.WriteXml(aspects, "EntityCollection", parentDocument, out entityCollectionNode);
    }

    /// <summary>
    /// Converts this entity collection to XML.
    /// 
    /// </summary>
    /// <param name="aspects">The aspect flags to control the format of the XML produced</param><param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param><param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
    public void WriteXml(XmlFormatAspect aspects, string rootNodeName, out string entityCollectionXml)
    {
      XmlNode entityCollectionNode;
      this.WriteXml(aspects, rootNodeName, new XmlDocument(), out entityCollectionNode);
      entityCollectionXml = entityCollectionNode.OuterXml;
    }

    /// <summary>
    /// Converts this entity collection to XML.
    /// 
    /// </summary>
    /// <param name="aspects">The aspect flags to control the format of the XML produced</param><param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param><param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
    ///             to create the new node object</param><param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
    public virtual void WriteXml(XmlFormatAspect aspects, string rootNodeName, XmlDocument parentDocument, out XmlNode entityCollectionNode)
    {
      this.EntityCollection2Xml(rootNodeName, parentDocument, new Dictionary<Guid, IEntityCore>(), aspects, out entityCollectionNode);
    }

    /// <summary>
    /// Converts this entity collection to XML, recursively. Uses "EntityCollection" for the rootnode name
    /// 
    /// </summary>
    /// <param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
    public void WriteXml(out string entityCollectionXml)
    {
      this.WriteXml("EntityCollection", out entityCollectionXml);
    }

    /// <summary>
    /// Converts this entity collection to XML. Uses "EntityCollection" for the rootnode name
    /// 
    /// </summary>
    /// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
    ///             to create the new node object</param><param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
    public void WriteXml(XmlDocument parentDocument, out XmlNode entityCollectionNode)
    {
      this.WriteXml("EntityCollection", parentDocument, out entityCollectionNode);
    }

    /// <summary>
    /// Converts this entity collection to XML.
    /// 
    /// </summary>
    /// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param><param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
    public void WriteXml(string rootNodeName, out string entityCollectionXml)
    {
      XmlNode entityCollectionNode;
      this.WriteXml(rootNodeName, new XmlDocument(), out entityCollectionNode);
      entityCollectionXml = entityCollectionNode.OuterXml;
    }

    /// <summary>
    /// Converts this entity collection to XML.
    /// 
    /// </summary>
    /// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param><param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
    ///             to create the new node object</param><param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
    public void WriteXml(string rootNodeName, XmlDocument parentDocument, out XmlNode entityCollectionNode)
    {
      this.EntityCollection2Xml(rootNodeName, parentDocument, new Dictionary<Guid, IEntityCore>(), XmlFormatAspect.None, out entityCollectionNode);
    }

    /// <summary>
    /// Will fill the entity collection and its containing members (recursively) with the data stored in the XmlNode passed in. The XmlNode has to
    ///             be filled with Xml in the format written by IEntityCollection2.WriteXml() and the Xml has to be compatible with the structure of this entity collection.
    /// 
    /// </summary>
    /// <param name="xmlData">string with Xml data which should be read into this entity collection and its members. This string has to be in the
    ///             correct format and should be loadable into a new XmlDocument without problems</param>
    public void ReadXml(string xmlData)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(xmlData);
      this.ReadXml((XmlNode) xmlDocument.DocumentElement);
    }

    /// <summary>
    /// Will fill the entity collection and its containing members (recursively) with the data stored in the XmlNode passed in. The XmlNode has to
    ///             be filled with Xml in the format written by IEntityCollection2.WriteXml() and the Xml has to be compatible with the structure of this entity collection.
    /// 
    /// </summary>
    /// <param name="node">XmlNode with Xml data which should be read into this entity and its members. Node's root element is the root element
    ///             of the entity collection's Xml data</param>
    public virtual void ReadXml(XmlNode node)
    {
      List<NodeEntityReference> nodeEntityReferences = new List<NodeEntityReference>();
      Dictionary<Guid, IEntityCore> processedObjectIDs = new Dictionary<Guid, IEntityCore>();
      this.Xml2EntityCollection(node, processedObjectIDs, nodeEntityReferences);
      XmlHelper.SetReadReferences(nodeEntityReferences, processedObjectIDs);
    }

    /// <summary>
    /// Gets the entity collection description. This string is used in verbose trace messages.
    ///             It will produce "EntityCollectionBase", if the passed in switch flag is false, to prevent performance loss due to
    ///             reflection activity for trace results which will never be seen.
    /// 
    /// </summary>
    /// <param name="switchFlag">switch flag. If this flag is false, "EntityCollectionBase" will be returned</param>
    /// <returns/>
    internal string GetEntityCollectionDescription(bool switchFlag)
    {
      if (!switchFlag || this.DeserializationInProgress)
        return "EntityCollectionBase";
      StringBuilder stringBuilder = new StringBuilder(256);
      stringBuilder.AppendFormat((IFormatProvider) null, "\r\n\tEntityCollection: {0}.\r\n", new object[1]
      {
        (object) this.GetType().FullName
      });
      if (this._containingEntity != null)
        stringBuilder.AppendFormat((IFormatProvider) null, "\tContained in: \r\n{0} via property: {1}\r\n", new object[2]
        {
          (object) ((EntityCore<IEntityFields>) this._containingEntity).GetEntityDescription(true),
          (object) this._containingEntityMappedField
        });
      return ((object) stringBuilder).ToString();
    }

    /// <summary>
    /// Produces the actual XML for this entity collection, recursively. Because it recurses through contained entities,
    ///             it keeps track of which objects are processed so cyclic references are not resulting in cyclic recursion and thus a crash.
    /// 
    /// </summary>
    /// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param><param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
    ///             to create the new node object</param><param name="processedObjectIDs">Hashtable with ObjectIDs of all the objects already processed. If an entity's ObjectID is in the
    ///             hashtable's key list, a ProcessedObjectReference tag is emitted and the entity will not recurse further. </param><param name="aspects">The aspect flags to control the format of the XML produced</param><param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
    internal void EntityCollection2Xml(string rootNodeName, XmlDocument parentDocument, Dictionary<Guid, IEntityCore> processedObjectIDs, XmlFormatAspect aspects, out XmlNode entityCollectionNode)
    {
      TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.EntityCollection2Xml", "Method Enter");
      XmlHelper xmlHelper = new XmlHelper();
      bool flag1 = (aspects & XmlFormatAspect.Compact) == XmlFormatAspect.Compact;
      bool datesInXmlDataType = (aspects & XmlFormatAspect.DatesInXmlDataType) == XmlFormatAspect.DatesInXmlDataType;
      bool mlInCDataBlocks = (aspects & XmlFormatAspect.MLTextInCDataBlocks) == XmlFormatAspect.MLTextInCDataBlocks;
      entityCollectionNode = parentDocument.CreateNode(XmlNodeType.Element, rootNodeName, "");
      XmlNode xmlNode1 = xmlHelper.AddNode(entityCollectionNode, "Entities");
      for (int index = 0; index < this.Count; ++index)
      {
        XmlNode entityNode;
        this[index].Entity2Xml("Entity", parentDocument, processedObjectIDs, aspects, out entityNode);
        xmlNode1.AppendChild(entityNode);
      }
      if (!flag1)
      {
        xmlHelper.AddAttribute(entityCollectionNode, "Assembly", this.GetType().Assembly.FullName);
        xmlHelper.AddAttribute(entityCollectionNode, "Type", this.GetType().FullName);
      }
      PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this.GetType());
      for (int index = 0; index < properties.Count; ++index)
      {
        if (!properties[index].Attributes.Contains((Attribute) new XmlIgnoreAttribute()))
        {
          if (properties[index].PropertyType.IsInterface)
          {
            if (properties[index].PropertyType.Equals(typeof (IEntityFactory)))
            {
              if (!flag1)
              {
                XmlNode parentNode = xmlHelper.AddNode(entityCollectionNode, "EntityFactoryToUse");
                IEntityFactory entityFactory = properties[index].GetValue((object) this) as IEntityFactory;
                if (entityFactory == null)
                {
                  xmlHelper.AddAttribute(parentNode, "Assembly", "Unknown");
                  continue;
                }
                else
                {
                  xmlHelper.AddAttribute(parentNode, "Assembly", entityFactory.GetType().Assembly.FullName);
                  xmlHelper.AddAttribute(parentNode, "Type", entityFactory.GetType().FullName);
                  continue;
                }
              }
              else
                continue;
            }
            else if (properties[index].PropertyType.Equals(typeof (IConcurrencyPredicateFactory)))
            {
              if (!flag1)
              {
                XmlNode parentNode = xmlHelper.AddNode(entityCollectionNode, "ConcurrencyPredicateFactoryToUse");
                IConcurrencyPredicateFactory predicateFactory = properties[index].GetValue((object) this) as IConcurrencyPredicateFactory;
                if (predicateFactory == null)
                {
                  xmlHelper.AddAttribute(parentNode, "Assembly", "Unknown");
                  continue;
                }
                else
                {
                  xmlHelper.AddAttribute(parentNode, "Assembly", predicateFactory.GetType().Assembly.FullName);
                  xmlHelper.AddAttribute(parentNode, "Type", predicateFactory.GetType().FullName);
                  continue;
                }
              }
              else
                continue;
            }
          }
          if (flag1)
          {
            bool flag2 = properties[index].Attributes.Contains((Attribute) new IncludeInCompactXmlAttribute());
            if (!properties[index].Name.StartsWith("Allow") && !flag2)
              continue;
          }
          XmlNode xmlNode2 = xmlHelper.AddNode(entityCollectionNode, properties[index].Name);
          string fullName = properties[index].PropertyType.UnderlyingSystemType.FullName;
          if (!flag1)
            xmlHelper.AddAttribute(xmlNode2, "Type", fullName);
          XmlHelper.AddPropertyValueAsStringChildNode(parentDocument, datesInXmlDataType, mlInCDataBlocks, properties[index].GetValue((object) this), xmlNode2, properties[index].PropertyType);
        }
      }
      TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.EntityCollection2Xml", "Method Exit");
    }

    /// <summary>
    /// Performs the actual conversion from Xml to entity collection data.
    /// 
    /// </summary>
    /// <param name="node">current node which points to an entity collection node.</param><param name="processedObjectIDs">ObjectID's of all entities instantiated</param><param name="nodeEntityReferences">List with all the references to entity objects we probably do not yet have instantiated. This list
    ///             is traversed after the xml tree has been processed. (not done by this routine, but by the caller)</param>
    internal void Xml2EntityCollection(XmlNode node, Dictionary<Guid, IEntityCore> processedObjectIDs, List<NodeEntityReference> nodeEntityReferences)
    {
      try
      {
        TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.Xml2EntityCollection", "Method Enter");
        this.DeserializationInProgress = true;
        XmlHelper xmlHelper = new XmlHelper();
        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this.GetType());
        foreach (XmlNode xmlNode in node.ChildNodes)
        {
          switch (xmlNode.Name)
          {
            case "Entities":
              if (xmlNode.ChildNodes.Count > 0)
              {
                int num = -1;
                IEnumerator enumerator = xmlNode.ChildNodes.GetEnumerator();
                try
                {
                  while (enumerator.MoveNext())
                  {
                    XmlNode node1 = (XmlNode) enumerator.Current;
                    ++num;
                    if (node1.Name == "ProcessedObjectReference")
                    {
                      nodeEntityReferences.Add(new NodeEntityReference()
                      {
                        ObjectID = new Guid(node1.Attributes["ObjectID"].Value),
                        PropertyHoldingInstance = (object) this,
                        IsCollectionAdd = true,
                        ReferencingProperty = (PropertyDescriptor) null,
                        Position = num
                      });
                    }
                    else
                    {
                      TEntity entity;
                      if (node1.Attributes.GetNamedItem("Assembly") == null)
                      {
                        XmlNode namedItem = node1.Attributes.GetNamedItem("EntityType");
                        entity = namedItem == null ? (TEntity) this.EntityFactoryToUse.Create() : (TEntity) this.EntityFactoryToUse.CreateEntityFromEntityTypeValue(Convert.ToInt32(namedItem.Value));
                      }
                      else
                        entity = (TEntity) Assembly.Load(node1.Attributes["Assembly"].Value).CreateInstance(node1.Attributes["Type"].Value);
                      entity.IsDeserializing = true;
                      try
                      {
                        entity.Xml2Entity(node1, processedObjectIDs, nodeEntityReferences);
                        this.Add(entity);
                      }
                      finally
                      {
                        entity.IsDeserializing = false;
                      }
                    }
                  }
                  continue;
                }
                finally
                {
                  IDisposable disposable = enumerator as IDisposable;
                  if (disposable != null)
                    disposable.Dispose();
                }
              }
              else
                continue;
            case "EntityFactoryToUse":
              string assemblyString1 = xmlNode.Attributes["Assembly"].Value;
              if (!(assemblyString1 == "Unknown"))
              {
                this.EntityFactoryToUse = (IEntityFactory) Assembly.Load(assemblyString1).CreateInstance(xmlNode.Attributes["Type"].Value);
                continue;
              }
              else
                continue;
            case "ConcurrencyPredicateFactoryToUse":
              string assemblyString2 = xmlNode.Attributes["Assembly"].Value;
              if (!(assemblyString2 == "Unknown"))
              {
                this.ConcurrencyPredicateFactoryToUse = (IConcurrencyPredicateFactory) Assembly.Load(assemblyString2).CreateInstance(xmlNode.Attributes["Type"].Value);
                continue;
              }
              else
                continue;
            default:
              string typeName = xmlNode.Attributes.GetNamedItem("Type") != null ? xmlNode.Attributes["Type"].Value : properties[xmlNode.Name].PropertyType.UnderlyingSystemType.FullName;
              string innerText = xmlNode.InnerText;
              PropertyDescriptor propertyDescriptor = properties[xmlNode.Name];
              if (propertyDescriptor != null)
              {
                propertyDescriptor.SetValue((object) this, xmlHelper.XmlValueToObject(typeName, innerText));
                continue;
              }
              else
                continue;
          }
        }
      }
      finally
      {
        this.DeserializationInProgress = false;
        TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase.Xml2EntityCollection", "Method Enter");
      }
    }

    void ICollectionMaintenance.SilentRemove(IEntityCore toRemove)
    {
      this.SilentRemove((TEntity) toRemove);
    }

    void ICollectionMaintenance.RaiseListChanged(int index, ListChangedType typeOfChange)
    {
      this.OnListChanged(index, typeOfChange);
    }

    void ICollectionMaintenance.ResetCachedPkHashes()
    {
      this.CachedPkHashes = (Dictionary<int, List<IEntityCore>>) null;
    }

    string ICollectionMaintenance.GetEntityCollectionDescription(bool switchFlag)
    {
      return this.GetEntityCollectionDescription(switchFlag);
    }

    IEntityCore ICollectionMaintenance.CreateDummyInstance()
    {
      if (this._entityFactoryToUse != null)
        return (IEntityCore) this._entityFactoryToUse.Create();
      else
        return (IEntityCore) null;
    }

    bool IEntityCollectionAccess.GetMultiInternal(ref IPredicateExpression selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, ref IRelationCollection relations, ExcludeIncludeFieldsList excludedIncludedFields, int pageNumber, int pageSize)
    {
      return this.GetMultiInternal(ref selectFilter, maxNumberOfItemsToReturn, sortClauses, ref relations, excludedIncludedFields, pageNumber, pageSize);
    }

    void IXmlCollectionSerializable.EntityCollection2Xml(string rootNodeName, XmlDocument parentDocument, Dictionary<Guid, IEntityCore> processedObjectIDs, XmlFormatAspect aspects, out XmlNode entityCollectionNode)
    {
      this.EntityCollection2Xml(rootNodeName, parentDocument, processedObjectIDs, aspects, out entityCollectionNode);
    }

    void IXmlCollectionSerializable.EntityCollection2Xml(string rootNodeName, XmlWriter writer, Dictionary<Guid, IEntityCore> processedObjectIDs, XmlFormatAspect aspects, bool emitFactory, bool isRootElement)
    {
    }

    void IXmlCollectionSerializable.Xml2EntityCollection(XmlNode node, Dictionary<Guid, IEntityCore> processedObjectIDs, List<NodeEntityReference> nodeEntityReferences)
    {
      this.Xml2EntityCollection(node, processedObjectIDs, nodeEntityReferences);
    }

    void IXmlCollectionSerializable.Xml2EntityCollection(XmlReader reader, Dictionary<Guid, IEntityCore> processedObjectIDs, List<NodeEntityReference> nodeEntityReferences)
    {
    }

    void IXmlCollectionSerializable.Insert(int index, IEntityCore entityToAdd)
    {
      this.Insert(index, entityToAdd as TEntity);
    }

    /// <summary>
    /// Performs the set related entity action on the passed in entity. This action is delegated to an inheritor.
    /// 
    /// </summary>
    /// <param name="entity">The entity to perform the setrelated entity action on.</param>
    protected override void PerformSetRelatedEntity(TEntity entity)
    {
      if (this._containingEntity == null || DesignTimeTracker.InDesignMode)
        return;
      entity.SetRelatedEntity((IEntityCore) this._containingEntity, this._containingEntityMappedField);
      if (this.DeserializationInProgress || this._containingEntity.GetType() == typeof (TEntity))
        return;
      ((EntityCore<IEntityFields>) this._containingEntity).OnRelatedEntitySet((IEntityCore) entity, this._containingEntityMappedField);
    }

    /// <summary>
    /// Performs the unset related entity action on the passed in entity. This action is delegated to an inheritor.
    /// 
    /// </summary>
    /// <param name="entity">The entity to perform the unsetrelated entity action on.</param>
    protected override void PerformUnsetRelatedEntity(TEntity entity)
    {
      if (this._containingEntity == null || DesignTimeTracker.InDesignMode)
        return;
      entity.UnsetRelatedEntity((IEntityCore) this._containingEntity, this._containingEntityMappedField, true);
      if (this._containingEntity.GetType() == typeof (TEntity))
        return;
      ((EntityCore<IEntityFields>) this._containingEntity).OnRelatedEntityUnset((IEntityCore) entity, this._containingEntityMappedField);
    }

    /// <summary>
    /// Performs the add action to the active context for this collection
    /// 
    /// </summary>
    /// <param name="entity">The entity.</param>
    protected override void PerformAddToActiveContext(TEntity entity)
    {
      if (this._activeContext == null)
        return;
      this._activeContext.Add((IEntity) entity);
    }

    /// <summary>
    /// Gets the entity description for the entity passed in.
    /// 
    /// </summary>
    /// <param name="entity">The entity.</param><param name="switchFlag">if true, the method will produce TEntity.GetEntityDescription, otherwise it's a no-op</param>
    /// <returns/>
    protected override string GetEntityDescription(TEntity entity, bool switchFlag)
    {
      if (!this.DeserializationInProgress)
        return entity.GetEntityDescription(switchFlag);
      else
        return "EntityBase";
    }

    /// <summary>
    /// Places the item in the set RemovedEntitiesTracker.
    /// 
    /// </summary>
    /// <param name="item">The item to add to the tracker.</param>
    protected override void PlaceInRemovedEntitiesTracker(TEntity item)
    {
      if (this._removedEntitiesTracker == null || this.Contains(item))
        return;
      item.MarkedForDeletion = true;
      this._removedEntitiesTracker.Add((IEntity) item);
    }

    /// <summary>
    /// Creats a new DAO instance so code which is in the base class can still use the proper DAO object.
    /// </summary>
    protected abstract IDao CreateDAOInstance();

    /// <summary>
    /// Creates a new transaction object
    /// </summary>
    /// <param name="levelOfIsolation">The level of isolation.</param><param name="name">The name.</param>
    /// <returns>
    /// Transaction ready to use
    /// </returns>
    protected abstract ITransaction CreateTransaction(IsolationLevel levelOfIsolation, string name);

    /// <summary>
    /// Creates the default entity view instance. By default it creates a new EntityView(Of TEntity) instance, passing in this collection.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// new entity view on this collection, to be used as the default entity view, returned by DefaultView
    /// </returns>
    protected virtual EntityView<TEntity> CreateDefaultEntityView()
    {
      return new EntityView<TEntity>((CollectionCore<TEntity>) this);
    }

    /// <summary>
    /// Adds the contained entities to the active set context.
    /// 
    /// </summary>
    protected virtual void AddContainedEntitiesToContext()
    {
      if (this._activeContext == null)
        return;
      foreach (TEntity entity in (CollectionCore<TEntity>) this)
      {
        IEntity toAdd = (IEntity) entity;
        if (toAdd.ActiveContext == null)
          this._activeContext.Add(toAdd);
      }
    }

    /// <summary>
    /// Inits the class
    /// 
    /// </summary>
    /// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
    private void InitClass(IEntityFactory entityFactoryToUse)
    {
      this.InitCoreClass(0);
      this._entityFactoryToUse = entityFactoryToUse;
      this.InitClass();
    }

    /// <summary>
    /// Inits the class.
    /// 
    /// </summary>
    private void InitClass()
    {
      this._containingTransaction = (ITransaction) null;
      this._maxNumberOfItemsToReturn = 0L;
      this._sortClauses = (ISortExpression) null;
      this._suppressClearInGetMulti = false;
      this._containingEntity = (IEntity) null;
      this._containingEntityMappedField = string.Empty;
      this._activeContext = (Context) null;
      this._defaultView = (EntityView<TEntity>) null;
      this._removedEntitiesTracker = (IEntityCollection) null;
    }

    /// <summary>
    /// Saves all new/dirty Entities in the IEntityCollection in the persistent storage. If this IEntityCollection is added
    ///             to a transaction, the save processes will be done in that transaction, if the entity isn't already added to another transaction.
    ///             If the entity is already in another transaction, it will use that transaction. If no transaction is present, the saves are done in a
    ///             new Transaction (which is created in an inherited method.)
    /// 
    /// </summary>
    /// <param name="recurse">If true, will recursively save the entities inside the collection</param>
    /// <returns>
    /// Amount of entities inserted
    /// </returns>
    /// 
    /// <remarks>
    /// All exceptions will be bubbled upwards so transaction code can anticipate on exceptions.
    /// </remarks>
    private int PerformSaveMulti(bool recurse)
    {
      TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "EntityCollectionBase.PerformSaveMulti", "Method Enter");
      List<ActionQueueElement<IEntity>> insertQueue = new List<ActionQueueElement<IEntity>>(1024);
      List<ActionQueueElement<IEntity>> updateQueue = new List<ActionQueueElement<IEntity>>(1024);
      if (recurse)
      {
        new ObjectGraphUtils().DetermineActionQueues<IEntity, EntityCollectionBase<TEntity>>(this, ref insertQueue, ref updateQueue);
      }
      else
      {
        foreach (TEntity entity1 in (CollectionCore<TEntity>) this)
        {
          IEntity entity2 = (IEntity) entity1;
          if (entity2.IsDirty || !entity2.IsDirty && entity2.IsNew && ((EntityCore<IEntityFields>) entity2).GetInheritanceHierarchyType() == InheritanceHierarchyType.TargetPerEntityHierarchy)
          {
            if (entity2.IsNew)
              insertQueue.Add(new ActionQueueElement<IEntity>(entity2, (IPredicateExpression) null, false));
            else
              updateQueue.Add(new ActionQueueElement<IEntity>(entity2, entity2.GetConcurrencyPredicate(ConcurrencyPredicateType.Save), false));
          }
        }
      }
      if (insertQueue.Count <= 0 && updateQueue.Count <= 0)
      {
        TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "EntityCollectionBase.PerformSaveMulti: no entities to save.", "Method Exit");
        return 0;
      }
      else
      {
        int totalAmountSaved1 = 0;
        int totalAmountSaved2 = 0;
        bool flag = DaoBase.PersistQueue(insertQueue, true, this._containingTransaction, out totalAmountSaved1) & DaoBase.PersistQueue(updateQueue, false, this._containingTransaction, out totalAmountSaved2);
        TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "EntityCollectionBase.PerformSaveMulti", "Method Exit");
        return totalAmountSaved1 + totalAmountSaved2;
      }
    }

    /// <summary>
    /// Deletes all Entities in the IEntityCollection from the persistent storage. If this IEntityCollection is added
    ///             to a transaction, the delete processes will be done in that transaction, if the entity isn't already added to another transaction.
    ///             If the entity is already in another transaction, it will use that transaction. If no transaction is present, the deletes are done in a
    ///             new Transaction (which is created in an inherited method.)
    ///             Deleted entities are marked deleted and are removed from the collection.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// Amount of entities deleted
    /// </returns>
    /// 
    /// <remarks>
    /// All exceptions will be bubbled upwards so transaction code can anticipate on exceptions.
    /// </remarks>
    private int PerformDeleteMulti()
    {
      TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "EntityCollectionBase.PerformDeleteMulti", "Method Enter");
      int num = 0;
      List<TEntity> list = new List<TEntity>();
      for (int index = 0; index < this.Count; ++index)
      {
        TEntity entity = this[index];
        if (!entity.ParticipatesInTransaction)
          this._containingTransaction.Add((ITransactionalElement) entity);
        if (entity.Delete())
        {
          list.Add(entity);
          ++num;
        }
      }
      bool changedEventsInternal = this.SuppressListChangedEventsInternal;
      this.SuppressListChangedEventsInternal = true;
      try
      {
        for (int index = 0; index < list.Count; ++index)
          this.Remove(list[index]);
      }
      finally
      {
        this.SuppressListChangedEventsInternal = changedEventsInternal;
      }
      list.Clear();
      this.OnListChanged(0, ListChangedType.Reset);
      TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "EntityCollectionBase.PerformDeleteMulti", "Method Exit");
      return num;
    }

    /// <summary>
    /// Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.
    /// </summary>
    /// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param><param name="maxNumberOfItemsToReturn">The maximum number of items to return with this retrieval query.</param><param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param><param name="relations">The set of relations to walk to construct the total query.</param><param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch.
    ///             If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
    ///             is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param><param name="pageNumber">The page number to retrieve.</param><param name="pageSize">The page size of the page to retrieve.</param>
    /// <returns>
    /// true if succeeded, false otherwise
    /// </returns>
    /// 
    /// <remarks>
    /// special version which is used by prefetch path code, and which modifies the relation collection and filter for hierarchical fetches
    /// </remarks>
    private bool GetMultiInternal(ref IPredicateExpression selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, ref IRelationCollection relations, ExcludeIncludeFieldsList excludedIncludedFields, int pageNumber, int pageSize)
    {
      if (!this.SuppressClearInGetMulti)
        this.Clear();
      return ((DaoBase) this.CreateDAOInstance()).GetMultiInternal(this.Transaction, (IEntityCollection) this, maxNumberOfItemsToReturn, sortClauses, this.EntityFactoryToUse, ref selectFilter, ref relations, excludedIncludedFields, pageNumber, pageSize);
    }

    bool IEntityCollection.GetMulti(IPredicate selectFilter)
    {
      return this.GetMulti(selectFilter);
    }

    bool IEntityCollection.GetMulti(IPredicate selectFilter, long maxNumberOfItemsToReturn)
    {
      return this.GetMulti(selectFilter, maxNumberOfItemsToReturn);
    }

    bool IEntityCollection.GetMulti(IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses)
    {
      return this.GetMulti(selectFilter, maxNumberOfItemsToReturn, sortClauses);
    }

    bool IEntityCollection.GetMulti(IPredicate selectFilter, IRelationCollection relations)
    {
      return this.GetMulti(selectFilter, relations);
    }

    bool IEntityCollection.GetMulti(IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations)
    {
      return this.GetMulti(selectFilter, maxNumberOfItemsToReturn, sortClauses, relations);
    }

    bool IEntityCollection.GetMulti(IPredicate selectFilter, IPrefetchPath prefetchPathToUse)
    {
      return this.GetMulti(selectFilter, prefetchPathToUse);
    }

    bool IEntityCollection.GetMulti(IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations, int pageNumber, int pageSize)
    {
      return this.GetMulti(selectFilter, maxNumberOfItemsToReturn, sortClauses, relations, pageNumber, pageSize);
    }

    bool IEntityCollection.GetMulti(IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations, IPrefetchPath prefetchPathToUse)
    {
      return this.GetMulti(selectFilter, maxNumberOfItemsToReturn, sortClauses, relations, prefetchPathToUse);
    }

    bool IEntityCollection.GetMulti(IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations, IPrefetchPath prefetchPathToUse, int pageNumber, int pageSize)
    {
      return this.GetMulti(selectFilter, maxNumberOfItemsToReturn, sortClauses, relations, prefetchPathToUse, pageNumber, pageSize);
    }

    int IEntityCollection.GetDbCount()
    {
      return this.GetDbCount();
    }

    int IEntityCollection.GetDbCount(IPredicate filter)
    {
      return this.GetDbCount(filter);
    }

    int IEntityCollection.GetDbCount(IPredicate filter, IRelationCollection relations)
    {
      return this.GetDbCount(filter, relations);
    }

    void IEntityCollection.Clear()
    {
      this.Clear();
    }

    int IEntityCollection.Add(IEntity entityToAdd)
    {
      TEntity entity = entityToAdd as TEntity;
      if ((object) entity == null)
        throw new ArgumentException("entityToAdd isn't of the right type.");
      this.Add(entity);
      return this.Count - 1;
    }

    void IEntityCollection.AddRange(IEntityCollection c)
    {
      ICollection<TEntity> collection = c as ICollection<TEntity>;
      if (collection == null)
        throw new ArgumentException("c isn't of the right type");
      this.AddRange((IEnumerable<TEntity>) collection);
    }

    void IEntityCollection.Insert(int index, IEntity entityToAdd)
    {
      TEntity entity = entityToAdd as TEntity;
      if ((object) entity == null)
        throw new ArgumentException("entityToAdd isn't of the right type.");
      this.Insert(index, entity);
    }

    void IEntityCollection.Remove(IEntity entityToRemove)
    {
      TEntity entity = entityToRemove as TEntity;
      if ((object) entity == null)
        throw new ArgumentException("entityToRemove isn't of the right type.");
      this.Remove(entity);
    }

    bool IEntityCollection.Contains(IEntity entityToFind)
    {
      TEntity entity = entityToFind as TEntity;
      if ((object) entity == null)
        throw new ArgumentException("entityToFind isn't of the right type");
      else
        return this.Contains(entity);
    }

    int IEntityCollection.IndexOf(IEntity entityToFind)
    {
      TEntity entity = entityToFind as TEntity;
      if ((object) entity == null)
        throw new ArgumentException("entityToFind isn't of the right type");
      else
        return this.IndexOf(entity);
    }

    void IEntityCollection.CopyTo(IEntity[] destination, int index)
    {
      this.CopyTo((Array) destination, index);
    }

    void IEntityCollection.SetContainingEntityInfo(IEntity containingEntity, string fieldName)
    {
      this.SetContainingEntityInfo(containingEntity, fieldName);
    }

    void IEntityCollection.CreateHierarchicalProjection(List<IViewProjectionData> collectionProjections, DataSet destination)
    {
      this.CreateHierarchicalProjection(collectionProjections, destination);
    }

    void IEntityCollection.CreateHierarchicalProjection(List<IViewProjectionData> collectionProjections, Dictionary<Type, IEntityCollection> destination)
    {
      this.CreateHierarchicalProjection(collectionProjections, destination);
    }

    IEntityView IEntityCollection.CreateView()
    {
      return this.CreateView((IPredicate) null, (ISortExpression) null, PostCollectionChangeAction.ReapplyFilterAndSorter);
    }

    IEntityView IEntityCollection.CreateView(IPredicate filter)
    {
      return this.CreateView(filter, (ISortExpression) null, PostCollectionChangeAction.ReapplyFilterAndSorter);
    }

    IEntityView IEntityCollection.CreateView(IPredicate filter, ISortExpression sorter)
    {
      return this.CreateView(filter, sorter, PostCollectionChangeAction.ReapplyFilterAndSorter);
    }

    IEntityView IEntityCollection.CreateView(IPredicate filter, ISortExpression sorter, PostCollectionChangeAction dataChangeAction)
    {
      return this.CreateView(filter, sorter, dataChangeAction);
    }

    IEntity IEntityCollection.get_Item(int index)
    {
      return (IEntity) this[index];
    }

    void IEntityCollection.set_Item(int index, IEntity value)
    {
      TEntity entity = value as TEntity;
      if ((object) entity == null)
        throw new ArgumentException("Value isn't of the right type.");
      this[index] = entity;
    }

    /// <summary>
    /// Returns an <see cref="T:System.Collections.IList"/> that can be bound to a data source from an object that does not implement an <see cref="T:System.Collections.IList"/> itself.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// An <see cref="T:System.Collections.IList"/> that can be bound to a data source from the object.
    /// 
    /// </returns>
    public IList GetList()
    {
      return (IList) this.DefaultView;
    }

    /// <summary>
    /// Constructs the XML output from the object graph which has this object as the root.
    /// 
    /// </summary>
    /// <param name="writer">Writer to which the xml is written to</param>
    /// <remarks>
    /// Uses XmlFormatAspect.Compact | XmlFormatAspect.MLTextInCDataBlocks | XmlFormatAspect.DatesInXmlDataType.
    /// </remarks>
    public virtual void WriteXml(XmlWriter writer)
    {
      string entityCollectionXml;
      this.WriteXml(XmlFormatAspect.Compact | XmlFormatAspect.MLTextInCDataBlocks | XmlFormatAspect.DatesInXmlDataType, out entityCollectionXml);
      writer.WriteRaw(entityCollectionXml);
    }

    /// <summary>
    /// Produce the schema, always return null, as the XmlSerializer object otherwise can't handle our code.
    /// 
    /// </summary>
    /// 
    /// <returns/>
    public XmlSchema GetSchema()
    {
      return (XmlSchema) null;
    }

    /// <summary>
    /// Constructs an object graph with this object as the root from the xml contained by the passed in XmlReader object.
    /// 
    /// </summary>
    /// <param name="reader">Reader with xml used to produce an object graph</param>
    /// <remarks>
    /// Uses XmlFormatAspect.Compact | XmlFormatAspect.MLTextInCDataBlocks | XmlFormatAspect.DatesInXmlDataType. Xml data should have been
    ///             produced with WriteXml(writer) or a similar routine which is able to produce similar formatted XML
    /// </remarks>
    public virtual void ReadXml(XmlReader reader)
    {
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.LoadXml(reader.ReadOuterXml());
      if (xmlDocument.DocumentElement == null)
        return;
      this.ReadXml(xmlDocument.DocumentElement.FirstChild);
    }
  }
}
