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
	/// <summary>Implements the relations factory for the entity: User. </summary>
	public partial class UserRelations
	{
		/// <summary>CTor</summary>
		public UserRelations()
		{
		}

		/// <summary>Gets all relations of the UserEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.PurchaseHistoryEntityUsingUserId);
			toReturn.Add(this.SupportIssueEntityUsingFromUserId);
			toReturn.Add(this.SupportIssueEntityUsingToUserId);
			toReturn.Add(this.UserAccountRestrictionEntityUsingUserId);
			toReturn.Add(this.UserAssignedLocationEntityUsingUserId);
			toReturn.Add(this.UserCreditCardEntityUsingUserId);
			toReturn.Add(this.UserRoleEntityUsingUserId);
			toReturn.Add(this.UserSettingEntityUsingUserId);
			toReturn.Add(this.UserSaltEntityUsingUserId);
			toReturn.Add(this.OrganizationEntityUsingOrganizationId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between UserEntity and PurchaseHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - PurchaseHistory.UserId
		/// </summary>
		public virtual IEntityRelation PurchaseHistoryEntityUsingUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PurchaseHistories" , true);
				relation.AddEntityFieldPair(UserFields.UserId, PurchaseHistoryFields.UserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PurchaseHistoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and SupportIssueEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - SupportIssue.FromUserId
		/// </summary>
		public virtual IEntityRelation SupportIssueEntityUsingFromUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SupportIssues" , true);
				relation.AddEntityFieldPair(UserFields.UserId, SupportIssueFields.FromUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SupportIssueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and SupportIssueEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - SupportIssue.ToUserId
		/// </summary>
		public virtual IEntityRelation SupportIssueEntityUsingToUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SupportIssues_" , true);
				relation.AddEntityFieldPair(UserFields.UserId, SupportIssueFields.ToUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SupportIssueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and UserAccountRestrictionEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - UserAccountRestriction.UserId
		/// </summary>
		public virtual IEntityRelation UserAccountRestrictionEntityUsingUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "UserAccountRestrictions" , true);
				relation.AddEntityFieldPair(UserFields.UserId, UserAccountRestrictionFields.UserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserAccountRestrictionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and UserAssignedLocationEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - UserAssignedLocation.UserId
		/// </summary>
		public virtual IEntityRelation UserAssignedLocationEntityUsingUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "UserAssignedLocations" , true);
				relation.AddEntityFieldPair(UserFields.UserId, UserAssignedLocationFields.UserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserAssignedLocationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and UserCreditCardEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - UserCreditCard.UserId
		/// </summary>
		public virtual IEntityRelation UserCreditCardEntityUsingUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "UserCreditCards" , true);
				relation.AddEntityFieldPair(UserFields.UserId, UserCreditCardFields.UserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserCreditCardEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and UserRoleEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - UserRole.UserId
		/// </summary>
		public virtual IEntityRelation UserRoleEntityUsingUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Roles" , true);
				relation.AddEntityFieldPair(UserFields.UserId, UserRoleFields.UserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserRoleEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and UserSettingEntity over the 1:n relation they have, using the relation between the fields:
		/// User.UserId - UserSetting.UserId
		/// </summary>
		public virtual IEntityRelation UserSettingEntityUsingUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Settings" , true);
				relation.AddEntityFieldPair(UserFields.UserId, UserSettingFields.UserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserSettingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and UserSaltEntity over the 1:1 relation they have, using the relation between the fields:
		/// User.UserId - UserSalt.UserId
		/// </summary>
		public virtual IEntityRelation UserSaltEntityUsingUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "UserSalt", true);

				relation.AddEntityFieldPair(UserFields.UserId, UserSaltFields.UserId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserSaltEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between UserEntity and OrganizationEntity over the m:1 relation they have, using the relation between the fields:
		/// User.OrganizationId - Organization.OrganizationId
		/// </summary>
		public virtual IEntityRelation OrganizationEntityUsingOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Organization", false);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, UserFields.OrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", true);
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
	internal static class StaticUserRelations
	{
		internal static readonly IEntityRelation PurchaseHistoryEntityUsingUserIdStatic = new UserRelations().PurchaseHistoryEntityUsingUserId;
		internal static readonly IEntityRelation SupportIssueEntityUsingFromUserIdStatic = new UserRelations().SupportIssueEntityUsingFromUserId;
		internal static readonly IEntityRelation SupportIssueEntityUsingToUserIdStatic = new UserRelations().SupportIssueEntityUsingToUserId;
		internal static readonly IEntityRelation UserAccountRestrictionEntityUsingUserIdStatic = new UserRelations().UserAccountRestrictionEntityUsingUserId;
		internal static readonly IEntityRelation UserAssignedLocationEntityUsingUserIdStatic = new UserRelations().UserAssignedLocationEntityUsingUserId;
		internal static readonly IEntityRelation UserCreditCardEntityUsingUserIdStatic = new UserRelations().UserCreditCardEntityUsingUserId;
		internal static readonly IEntityRelation UserRoleEntityUsingUserIdStatic = new UserRelations().UserRoleEntityUsingUserId;
		internal static readonly IEntityRelation UserSettingEntityUsingUserIdStatic = new UserRelations().UserSettingEntityUsingUserId;
		internal static readonly IEntityRelation UserSaltEntityUsingUserIdStatic = new UserRelations().UserSaltEntityUsingUserId;
		internal static readonly IEntityRelation OrganizationEntityUsingOrganizationIdStatic = new UserRelations().OrganizationEntityUsingOrganizationId;

		/// <summary>CTor</summary>
		static StaticUserRelations()
		{
		}
	}
}
