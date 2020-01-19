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
	/// <summary>Implements the relations factory for the entity: Severity. </summary>
	public partial class SeverityRelations
	{
		/// <summary>CTor</summary>
		public SeverityRelations()
		{
		}

		/// <summary>Gets all relations of the SeverityEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.OrganEntityUsingOrganId);
			toReturn.Add(this.TreatmentEntityUsingTreatmentId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between SeverityEntity and OrganEntity over the m:1 relation they have, using the relation between the fields:
		/// Severity.OrganId - Organ.OrganId
		/// </summary>
		public virtual IEntityRelation OrganEntityUsingOrganId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Organ", false);
				relation.AddEntityFieldPair(OrganFields.OrganId, SeverityFields.OrganId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SeverityEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between SeverityEntity and TreatmentEntity over the m:1 relation they have, using the relation between the fields:
		/// Severity.TreatmentId - Treatment.TreatmentId
		/// </summary>
		public virtual IEntityRelation TreatmentEntityUsingTreatmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Treatment", false);
				relation.AddEntityFieldPair(TreatmentFields.TreatmentId, SeverityFields.TreatmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TreatmentEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SeverityEntity", true);
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
	internal static class StaticSeverityRelations
	{
		internal static readonly IEntityRelation OrganEntityUsingOrganIdStatic = new SeverityRelations().OrganEntityUsingOrganId;
		internal static readonly IEntityRelation TreatmentEntityUsingTreatmentIdStatic = new SeverityRelations().TreatmentEntityUsingTreatmentId;

		/// <summary>CTor</summary>
		static StaticSeverityRelations()
		{
		}
	}
}
