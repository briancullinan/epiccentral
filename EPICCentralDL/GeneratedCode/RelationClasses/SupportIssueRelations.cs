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
	/// <summary>Implements the relations factory for the entity: SupportIssue. </summary>
	public partial class SupportIssueRelations
	{
		/// <summary>CTor</summary>
		public SupportIssueRelations()
		{
		}

		/// <summary>Gets all relations of the SupportIssueEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.SupportAreaEntityUsingSupportAreaId);
			toReturn.Add(this.UserEntityUsingFromUserId);
			toReturn.Add(this.UserEntityUsingToUserId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between SupportIssueEntity and SupportAreaEntity over the m:1 relation they have, using the relation between the fields:
		/// SupportIssue.SupportAreaId - SupportArea.SupportAreaId
		/// </summary>
		public virtual IEntityRelation SupportAreaEntityUsingSupportAreaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "SupportArea", false);
				relation.AddEntityFieldPair(SupportAreaFields.SupportAreaId, SupportIssueFields.SupportAreaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SupportAreaEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SupportIssueEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between SupportIssueEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// SupportIssue.FromUserId - User.UserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingFromUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "User", false);
				relation.AddEntityFieldPair(UserFields.UserId, SupportIssueFields.FromUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SupportIssueEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between SupportIssueEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// SupportIssue.ToUserId - User.UserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingToUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "User_", false);
				relation.AddEntityFieldPair(UserFields.UserId, SupportIssueFields.ToUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SupportIssueEntity", true);
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
	internal static class StaticSupportIssueRelations
	{
		internal static readonly IEntityRelation SupportAreaEntityUsingSupportAreaIdStatic = new SupportIssueRelations().SupportAreaEntityUsingSupportAreaId;
		internal static readonly IEntityRelation UserEntityUsingFromUserIdStatic = new SupportIssueRelations().UserEntityUsingFromUserId;
		internal static readonly IEntityRelation UserEntityUsingToUserIdStatic = new SupportIssueRelations().UserEntityUsingToUserId;

		/// <summary>CTor</summary>
		static StaticSupportIssueRelations()
		{
		}
	}
}
