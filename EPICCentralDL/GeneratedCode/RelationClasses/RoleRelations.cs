﻿///////////////////////////////////////////////////////////////
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
	/// <summary>Implements the relations factory for the entity: Role. </summary>
	public partial class RoleRelations
	{
		/// <summary>CTor</summary>
		public RoleRelations()
		{
		}

		/// <summary>Gets all relations of the RoleEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.UserRoleEntityUsingRoleId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between RoleEntity and UserRoleEntity over the 1:n relation they have, using the relation between the fields:
		/// Role.RoleId - UserRole.RoleId
		/// </summary>
		public virtual IEntityRelation UserRoleEntityUsingRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "UserRoles" , true);
				relation.AddEntityFieldPair(RoleFields.RoleId, UserRoleFields.RoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserRoleEntity", false);
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
	internal static class StaticRoleRelations
	{
		internal static readonly IEntityRelation UserRoleEntityUsingRoleIdStatic = new RoleRelations().UserRoleEntityUsingRoleId;

		/// <summary>CTor</summary>
		static StaticRoleRelations()
		{
		}
	}
}