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
	/// <summary>Implements the relations factory for the entity: ActiveOrganization. </summary>
	public partial class ActiveOrganizationRelations
	{
		/// <summary>CTor</summary>
		public ActiveOrganizationRelations()
		{
		}

		/// <summary>Gets all relations of the ActiveOrganizationEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ActivityTypeEntityUsingActivityTypeId);
			toReturn.Add(this.LocationEntityUsingLocationId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ActiveOrganizationEntity and ActivityTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ActiveOrganization.ActivityTypeId - ActivityType.ActivityTypeId
		/// </summary>
		public virtual IEntityRelation ActivityTypeEntityUsingActivityTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ActivityType", false);
				relation.AddEntityFieldPair(ActivityTypeFields.ActivityTypeId, ActiveOrganizationFields.ActivityTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActivityTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActiveOrganizationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ActiveOrganizationEntity and LocationEntity over the m:1 relation they have, using the relation between the fields:
		/// ActiveOrganization.LocationId - Location.LocationId
		/// </summary>
		public virtual IEntityRelation LocationEntityUsingLocationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Location", false);
				relation.AddEntityFieldPair(LocationFields.LocationId, ActiveOrganizationFields.LocationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActiveOrganizationEntity", true);
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
	internal static class StaticActiveOrganizationRelations
	{
		internal static readonly IEntityRelation ActivityTypeEntityUsingActivityTypeIdStatic = new ActiveOrganizationRelations().ActivityTypeEntityUsingActivityTypeId;
		internal static readonly IEntityRelation LocationEntityUsingLocationIdStatic = new ActiveOrganizationRelations().LocationEntityUsingLocationId;

		/// <summary>CTor</summary>
		static StaticActiveOrganizationRelations()
		{
		}
	}
}
