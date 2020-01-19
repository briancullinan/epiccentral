///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using EPICCentralDL;
using EPICCentralDL.FactoryClasses;
using EPICCentralDL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentralDL.RelationClasses
{
	/// <summary>Implements the relations factory for the entity: PatientPrescanQuestion. </summary>
	public partial class PatientPrescanQuestionRelations
	{
		/// <summary>CTor</summary>
		public PatientPrescanQuestionRelations()
		{
		}

		/// <summary>Gets all relations of the PatientPrescanQuestionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.TreatmentEntityUsingTreatmentId);
			return toReturn;
		}

		#region Class Property Declarations


		/// <summary>Returns a new IEntityRelation object, between PatientPrescanQuestionEntity and TreatmentEntity over the 1:1 relation they have, using the relation between the fields:
		/// PatientPrescanQuestion.TreatmentId - Treatment.TreatmentId
		/// </summary>
		public virtual IEntityRelation TreatmentEntityUsingTreatmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "Treatment", false);



				relation.AddEntityFieldPair(TreatmentFields.TreatmentId, PatientPrescanQuestionFields.TreatmentId);

				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TreatmentEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PatientPrescanQuestionEntity", true);
				return relation;
			}
		}

		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}
		#endregion

		#region Included Code

		#endregion
	}
	
	/// <summary>Static class which is used for providing relationship instances which are re-used internally for syncing</summary>
	internal static class StaticPatientPrescanQuestionRelations
	{
		internal static readonly IEntityRelation TreatmentEntityUsingTreatmentIdStatic = new PatientPrescanQuestionRelations().TreatmentEntityUsingTreatmentId;

		/// <summary>CTor</summary>
		static StaticPatientPrescanQuestionRelations()
		{
		}
	}
}
