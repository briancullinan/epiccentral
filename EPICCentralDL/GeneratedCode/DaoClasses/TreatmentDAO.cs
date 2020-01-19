///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.FactoryClasses;
using EPICCentralDL.CollectionClasses;
using EPICCentralDL.HelperClasses;
using EPICCentralDL;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.DQE.SqlServer;


namespace EPICCentralDL.DaoClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>General DAO class for the Treatment Entity. It will perform database oriented actions for a entity of type 'TreatmentEntity'.</summary>
	public partial class TreatmentDAO : CommonDaoBase
	{
		/// <summary>CTor</summary>
		public TreatmentDAO() : base(InheritanceHierarchyType.None, "TreatmentEntity", new TreatmentEntityFactory())
		{
		}



		/// <summary>Retrieves in the calling TreatmentCollection object all TreatmentEntity objects which have data in common with the specified related Entities. If one is omitted, that entity is not used as a filter. </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="collectionToFill">Collection to fill with the entity objects retrieved</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="filter">Extra filter to limit the resultset. Predicate expression can be null, in which case it will be ignored.</param>
		/// <param name="calibrationInstance">CalibrationEntity instance to use as a filter for the TreatmentEntity objects to return</param>
		/// <param name="imageSetInstance">ImageSetEntity instance to use as a filter for the TreatmentEntity objects to return</param>
		/// <param name="imageSet_Instance">ImageSetEntity instance to use as a filter for the TreatmentEntity objects to return</param>
		/// <param name="patientInstance">PatientEntity instance to use as a filter for the TreatmentEntity objects to return</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		public bool GetMulti(ITransaction containingTransaction, IEntityCollection collectionToFill, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IEntityFactory entityFactoryToUse, IPredicateExpression filter, IEntity calibrationInstance, IEntity imageSetInstance, IEntity imageSet_Instance, IEntity patientInstance, int pageNumber, int pageSize)
		{
			this.EntityFactoryToUse = entityFactoryToUse;
			IEntityFields fieldsToReturn = EntityFieldsFactory.CreateEntityFieldsObject(EPICCentralDL.EntityType.TreatmentEntity);
			IPredicateExpression selectFilter = CreateFilterUsingForeignKeys(calibrationInstance, imageSetInstance, imageSet_Instance, patientInstance, fieldsToReturn);
			if(filter!=null)
			{
				selectFilter.AddWithAnd(filter);
			}
			return this.PerformGetMultiAction(containingTransaction, collectionToFill, maxNumberOfItemsToReturn, sortClauses, selectFilter, null, null, null, pageNumber, pageSize);
		}




		/// <summary>Deletes from the persistent storage all 'Treatment' entities which have data in common with the specified related Entities. If one is omitted, that entity is not used as a filter.</summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="calibrationInstance">CalibrationEntity instance to use as a filter for the TreatmentEntity objects to delete</param>
		/// <param name="imageSetInstance">ImageSetEntity instance to use as a filter for the TreatmentEntity objects to delete</param>
		/// <param name="imageSet_Instance">ImageSetEntity instance to use as a filter for the TreatmentEntity objects to delete</param>
		/// <param name="patientInstance">PatientEntity instance to use as a filter for the TreatmentEntity objects to delete</param>
		/// <returns>Amount of entities affected, if the used persistent storage has rowcounting enabled.</returns>
		public int DeleteMulti(ITransaction containingTransaction, IEntity calibrationInstance, IEntity imageSetInstance, IEntity imageSet_Instance, IEntity patientInstance)
		{
			IEntityFields fields = EntityFieldsFactory.CreateEntityFieldsObject(EPICCentralDL.EntityType.TreatmentEntity);
			IPredicateExpression deleteFilter = CreateFilterUsingForeignKeys(calibrationInstance, imageSetInstance, imageSet_Instance, patientInstance, fields);
			return this.DeleteMulti(containingTransaction, deleteFilter);
		}

		/// <summary>Updates all entities of the same type or subtype of the entity <i>entityWithNewValues</i> directly in the persistent storage if they match the filter
		/// supplied in <i>filterBucket</i>. Only the fields changed in entityWithNewValues are updated for these fields. Entities of a subtype of the type
		/// of <i>entityWithNewValues</i> which are affected by the filterBucket's filter will thus also be updated.</summary>
		/// <param name="entityWithNewValues">IEntity instance which holds the new values for the matching entities to update. Only changed fields are taken into account</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="calibrationInstance">CalibrationEntity instance to use as a filter for the TreatmentEntity objects to update</param>
		/// <param name="imageSetInstance">ImageSetEntity instance to use as a filter for the TreatmentEntity objects to update</param>
		/// <param name="imageSet_Instance">ImageSetEntity instance to use as a filter for the TreatmentEntity objects to update</param>
		/// <param name="patientInstance">PatientEntity instance to use as a filter for the TreatmentEntity objects to update</param>
		/// <returns>Amount of entities affected, if the used persistent storage has rowcounting enabled.</returns>
		public int UpdateMulti(IEntity entityWithNewValues, ITransaction containingTransaction, IEntity calibrationInstance, IEntity imageSetInstance, IEntity imageSet_Instance, IEntity patientInstance)
		{
			IEntityFields fields = EntityFieldsFactory.CreateEntityFieldsObject(EPICCentralDL.EntityType.TreatmentEntity);
			IPredicateExpression updateFilter = CreateFilterUsingForeignKeys(calibrationInstance, imageSetInstance, imageSet_Instance, patientInstance, fields);
			return this.UpdateMulti(entityWithNewValues, containingTransaction, updateFilter);
		}

		/// <summary>Creates a PredicateExpression which should be used as a filter when any combination of available foreign keys is specified.</summary>
		/// <param name="calibrationInstance">CalibrationEntity instance to use as a filter for the TreatmentEntity objects</param>
		/// <param name="imageSetInstance">ImageSetEntity instance to use as a filter for the TreatmentEntity objects</param>
		/// <param name="imageSet_Instance">ImageSetEntity instance to use as a filter for the TreatmentEntity objects</param>
		/// <param name="patientInstance">PatientEntity instance to use as a filter for the TreatmentEntity objects</param>
		/// <param name="fieldsToReturn">IEntityFields implementation which forms the definition of the fieldset of the target entity.</param>
		/// <returns>A ready to use PredicateExpression based on the passed in foreign key value holders.</returns>
		private IPredicateExpression CreateFilterUsingForeignKeys(IEntity calibrationInstance, IEntity imageSetInstance, IEntity imageSet_Instance, IEntity patientInstance, IEntityFields fieldsToReturn)
		{
			IPredicateExpression selectFilter = new PredicateExpression();
			
			if(calibrationInstance != null)
			{
				selectFilter.Add(new FieldCompareValuePredicate(fieldsToReturn[(int)TreatmentFieldIndex.CalibrationId], ComparisonOperator.Equal, ((CalibrationEntity)calibrationInstance).CalibrationId));
			}
			if(imageSetInstance != null)
			{
				selectFilter.Add(new FieldCompareValuePredicate(fieldsToReturn[(int)TreatmentFieldIndex.EnergizedImageSetId], ComparisonOperator.Equal, ((ImageSetEntity)imageSetInstance).ImageSetId));
			}
			if(imageSet_Instance != null)
			{
				selectFilter.Add(new FieldCompareValuePredicate(fieldsToReturn[(int)TreatmentFieldIndex.FingerImageSetId], ComparisonOperator.Equal, ((ImageSetEntity)imageSet_Instance).ImageSetId));
			}
			if(patientInstance != null)
			{
				selectFilter.Add(new FieldCompareValuePredicate(fieldsToReturn[(int)TreatmentFieldIndex.PatientId], ComparisonOperator.Equal, ((PatientEntity)patientInstance).PatientId));
			}
			return selectFilter;
		}
		
		#region Custom DAO code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomDAOCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion
		
		#region Included Code

		#endregion
	}
}
