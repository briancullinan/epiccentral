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
	/// <summary>Implements the relations factory for the entity: CreditCard. </summary>
	public partial class CreditCardRelations
	{
		/// <summary>CTor</summary>
		public CreditCardRelations()
		{
		}

		/// <summary>Gets all relations of the CreditCardEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.UserCreditCardEntityUsingCreditCardId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CreditCardEntity and UserCreditCardEntity over the 1:n relation they have, using the relation between the fields:
		/// CreditCard.CreditCardId - UserCreditCard.CreditCardId
		/// </summary>
		public virtual IEntityRelation UserCreditCardEntityUsingCreditCardId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "UserCreditCards" , true);
				relation.AddEntityFieldPair(CreditCardFields.CreditCardId, UserCreditCardFields.CreditCardId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CreditCardEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserCreditCardEntity", false);
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
	internal static class StaticCreditCardRelations
	{
		internal static readonly IEntityRelation UserCreditCardEntityUsingCreditCardIdStatic = new CreditCardRelations().UserCreditCardEntityUsingCreditCardId;

		/// <summary>CTor</summary>
		static StaticCreditCardRelations()
		{
		}
	}
}
