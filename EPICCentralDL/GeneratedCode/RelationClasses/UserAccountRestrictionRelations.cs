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
	/// <summary>Implements the relations factory for the entity: UserAccountRestriction. </summary>
	public partial class UserAccountRestrictionRelations
	{
		/// <summary>CTor</summary>
		public UserAccountRestrictionRelations()
		{
		}

		/// <summary>Gets all relations of the UserAccountRestrictionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AccountRestrictionEntityUsingAccountRestrictionId);
			toReturn.Add(this.UserEntityUsingUserId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between UserAccountRestrictionEntity and AccountRestrictionEntity over the m:1 relation they have, using the relation between the fields:
		/// UserAccountRestriction.AccountRestrictionId - AccountRestriction.AccountRestrictionId
		/// </summary>
		public virtual IEntityRelation AccountRestrictionEntityUsingAccountRestrictionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AccountRestriction", false);
				relation.AddEntityFieldPair(AccountRestrictionFields.AccountRestrictionId, UserAccountRestrictionFields.AccountRestrictionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountRestrictionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserAccountRestrictionEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between UserAccountRestrictionEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// UserAccountRestriction.UserId - User.UserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "User", false);
				relation.AddEntityFieldPair(UserFields.UserId, UserAccountRestrictionFields.UserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserAccountRestrictionEntity", true);
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
	internal static class StaticUserAccountRestrictionRelations
	{
		internal static readonly IEntityRelation AccountRestrictionEntityUsingAccountRestrictionIdStatic = new UserAccountRestrictionRelations().AccountRestrictionEntityUsingAccountRestrictionId;
		internal static readonly IEntityRelation UserEntityUsingUserIdStatic = new UserAccountRestrictionRelations().UserEntityUsingUserId;

		/// <summary>CTor</summary>
		static StaticUserAccountRestrictionRelations()
		{
		}
	}
}
