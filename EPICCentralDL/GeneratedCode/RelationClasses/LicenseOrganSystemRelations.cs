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
	/// <summary>Implements the relations factory for the entity: LicenseOrganSystem. </summary>
	public partial class LicenseOrganSystemRelations
	{
		/// <summary>CTor</summary>
		public LicenseOrganSystemRelations()
		{
		}

		/// <summary>Gets all relations of the LicenseOrganSystemEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.OrganSystemOrganEntityUsingLicenseOrganSystemId);
			toReturn.Add(this.OrganSystemEntityUsingOrganSystemId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between LicenseOrganSystemEntity and OrganSystemOrganEntity over the 1:n relation they have, using the relation between the fields:
		/// LicenseOrganSystem.LicenseOrganSystemId - OrganSystemOrgan.LicenseOrganSystemId
		/// </summary>
		public virtual IEntityRelation OrganSystemOrganEntityUsingLicenseOrganSystemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OrganSystemOrgans" , true);
				relation.AddEntityFieldPair(LicenseOrganSystemFields.LicenseOrganSystemId, OrganSystemOrganFields.LicenseOrganSystemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LicenseOrganSystemEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganSystemOrganEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between LicenseOrganSystemEntity and OrganSystemEntity over the m:1 relation they have, using the relation between the fields:
		/// LicenseOrganSystem.OrganSystemId - OrganSystem.OrganSystemId
		/// </summary>
		public virtual IEntityRelation OrganSystemEntityUsingOrganSystemId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganSystem", false);
				relation.AddEntityFieldPair(OrganSystemFields.OrganSystemId, LicenseOrganSystemFields.OrganSystemId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganSystemEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LicenseOrganSystemEntity", true);
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
	internal static class StaticLicenseOrganSystemRelations
	{
		internal static readonly IEntityRelation OrganSystemOrganEntityUsingLicenseOrganSystemIdStatic = new LicenseOrganSystemRelations().OrganSystemOrganEntityUsingLicenseOrganSystemId;
		internal static readonly IEntityRelation OrganSystemEntityUsingOrganSystemIdStatic = new LicenseOrganSystemRelations().OrganSystemEntityUsingOrganSystemId;

		/// <summary>CTor</summary>
		static StaticLicenseOrganSystemRelations()
		{
		}
	}
}
