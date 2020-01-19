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
	/// <summary>Implements the relations factory for the entity: Organ. </summary>
	public partial class OrganRelations
	{
		/// <summary>CTor</summary>
		public OrganRelations()
		{
		}

		/// <summary>Gets all relations of the OrganEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.OrganSystemOrganEntityUsingOrganId);
			toReturn.Add(this.SeverityEntityUsingOrganId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between OrganEntity and OrganSystemOrganEntity over the 1:n relation they have, using the relation between the fields:
		/// Organ.OrganId - OrganSystemOrgan.OrganId
		/// </summary>
		public virtual IEntityRelation OrganSystemOrganEntityUsingOrganId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OrganSystemOrgans" , true);
				relation.AddEntityFieldPair(OrganFields.OrganId, OrganSystemOrganFields.OrganId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganSystemOrganEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganEntity and SeverityEntity over the 1:n relation they have, using the relation between the fields:
		/// Organ.OrganId - Severity.OrganId
		/// </summary>
		public virtual IEntityRelation SeverityEntityUsingOrganId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Severities" , true);
				relation.AddEntityFieldPair(OrganFields.OrganId, SeverityFields.OrganId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SeverityEntity", false);
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
	internal static class StaticOrganRelations
	{
		internal static readonly IEntityRelation OrganSystemOrganEntityUsingOrganIdStatic = new OrganRelations().OrganSystemOrganEntityUsingOrganId;
		internal static readonly IEntityRelation SeverityEntityUsingOrganIdStatic = new OrganRelations().SeverityEntityUsingOrganId;

		/// <summary>CTor</summary>
		static StaticOrganRelations()
		{
		}
	}
}
