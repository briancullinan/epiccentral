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
	/// <summary>Implements the relations factory for the entity: Organization. </summary>
	public partial class OrganizationRelations
	{
		/// <summary>CTor</summary>
		public OrganizationRelations()
		{
		}

		/// <summary>Gets all relations of the OrganizationEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ContactEntityUsingOrganizationId);
			toReturn.Add(this.LocationEntityUsingOrganizationId);
			toReturn.Add(this.UserEntityUsingOrganizationId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and ContactEntity over the 1:n relation they have, using the relation between the fields:
		/// Organization.OrganizationId - Contact.OrganizationId
		/// </summary>
		public virtual IEntityRelation ContactEntityUsingOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Contacts" , true);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, ContactFields.OrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and LocationEntity over the 1:n relation they have, using the relation between the fields:
		/// Organization.OrganizationId - Location.OrganizationId
		/// </summary>
		public virtual IEntityRelation LocationEntityUsingOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Locations" , true);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, LocationFields.OrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationEntity and UserEntity over the 1:n relation they have, using the relation between the fields:
		/// Organization.OrganizationId - User.OrganizationId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Users" , true);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, UserFields.OrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
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
	internal static class StaticOrganizationRelations
	{
		internal static readonly IEntityRelation ContactEntityUsingOrganizationIdStatic = new OrganizationRelations().ContactEntityUsingOrganizationId;
		internal static readonly IEntityRelation LocationEntityUsingOrganizationIdStatic = new OrganizationRelations().LocationEntityUsingOrganizationId;
		internal static readonly IEntityRelation UserEntityUsingOrganizationIdStatic = new OrganizationRelations().UserEntityUsingOrganizationId;

		/// <summary>CTor</summary>
		static StaticOrganizationRelations()
		{
		}
	}
}
