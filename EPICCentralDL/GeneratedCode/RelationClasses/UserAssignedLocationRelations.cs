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
	/// <summary>Implements the relations factory for the entity: UserAssignedLocation. </summary>
	public partial class UserAssignedLocationRelations
	{
		/// <summary>CTor</summary>
		public UserAssignedLocationRelations()
		{
		}

		/// <summary>Gets all relations of the UserAssignedLocationEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.LocationEntityUsingLocationId);
			toReturn.Add(this.UserEntityUsingUserId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between UserAssignedLocationEntity and LocationEntity over the m:1 relation they have, using the relation between the fields:
		/// UserAssignedLocation.LocationId - Location.LocationId
		/// </summary>
		public virtual IEntityRelation LocationEntityUsingLocationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Location", false);
				relation.AddEntityFieldPair(LocationFields.LocationId, UserAssignedLocationFields.LocationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserAssignedLocationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between UserAssignedLocationEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// UserAssignedLocation.UserId - User.UserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "User", false);
				relation.AddEntityFieldPair(UserFields.UserId, UserAssignedLocationFields.UserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserAssignedLocationEntity", true);
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
	internal static class StaticUserAssignedLocationRelations
	{
		internal static readonly IEntityRelation LocationEntityUsingLocationIdStatic = new UserAssignedLocationRelations().LocationEntityUsingLocationId;
		internal static readonly IEntityRelation UserEntityUsingUserIdStatic = new UserAssignedLocationRelations().UserEntityUsingUserId;

		/// <summary>CTor</summary>
		static StaticUserAssignedLocationRelations()
		{
		}
	}
}
