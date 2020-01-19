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
	/// <summary>Implements the relations factory for the entity: OrganSystemOrgan. </summary>
	public partial class OrganSystemOrganRelations
	{
		/// <summary>CTor</summary>
		public OrganSystemOrganRelations()
		{
		}

		/// <summary>Gets all relations of the OrganSystemOrganEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.LicenseOrganSystemEntityUsingLicenseOrganSystemId);
			toReturn.Add(this.OrganEntityUsingOrganId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between OrganSystemOrganEntity and LicenseOrganSystemEntity over the m:1 relation they have, using the relation between the fields:
		/// OrganSystemOrgan.LicenseOrganSystemId - LicenseOrganSystem.LicenseOrganSystemId
		/// </summary>
		public virtual IEntityRelation LicenseOrganSystemEntityUsingLicenseOrganSystemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "LicenseOrganSystem", false);
				relation.AddEntityFieldPair(LicenseOrganSystemFields.LicenseOrganSystemId, OrganSystemOrganFields.LicenseOrganSystemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LicenseOrganSystemEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganSystemOrganEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between OrganSystemOrganEntity and OrganEntity over the m:1 relation they have, using the relation between the fields:
		/// OrganSystemOrgan.OrganId - Organ.OrganId
		/// </summary>
		public virtual IEntityRelation OrganEntityUsingOrganId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Organ", false);
				relation.AddEntityFieldPair(OrganFields.OrganId, OrganSystemOrganFields.OrganId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganSystemOrganEntity", true);
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
	internal static class StaticOrganSystemOrganRelations
	{
		internal static readonly IEntityRelation LicenseOrganSystemEntityUsingLicenseOrganSystemIdStatic = new OrganSystemOrganRelations().LicenseOrganSystemEntityUsingLicenseOrganSystemId;
		internal static readonly IEntityRelation OrganEntityUsingOrganIdStatic = new OrganSystemOrganRelations().OrganEntityUsingOrganId;

		/// <summary>CTor</summary>
		static StaticOrganSystemOrganRelations()
		{
		}
	}
}
