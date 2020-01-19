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
	/// <summary>Implements the relations factory for the entity: LocationCreditCard. </summary>
	public partial class LocationCreditCardRelations
	{
		/// <summary>CTor</summary>
		public LocationCreditCardRelations()
		{
		}

		/// <summary>Gets all relations of the LocationCreditCardEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CreditCardEntityUsingCreditCardId);
			toReturn.Add(this.LocationEntityUsingLocationId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between LocationCreditCardEntity and CreditCardEntity over the m:1 relation they have, using the relation between the fields:
		/// LocationCreditCard.CreditCardId - CreditCard.CreditCardId
		/// </summary>
		public virtual IEntityRelation CreditCardEntityUsingCreditCardId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CreditCard", false);
				relation.AddEntityFieldPair(CreditCardFields.CreditCardId, LocationCreditCardFields.CreditCardId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CreditCardEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocationCreditCardEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between LocationCreditCardEntity and LocationEntity over the m:1 relation they have, using the relation between the fields:
		/// LocationCreditCard.LocationId - Location.LocationId
		/// </summary>
		public virtual IEntityRelation LocationEntityUsingLocationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Location", false);
				relation.AddEntityFieldPair(LocationFields.LocationId, LocationCreditCardFields.LocationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocationCreditCardEntity", true);
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
	internal static class StaticLocationCreditCardRelations
	{
		internal static readonly IEntityRelation CreditCardEntityUsingCreditCardIdStatic = new LocationCreditCardRelations().CreditCardEntityUsingCreditCardId;
		internal static readonly IEntityRelation LocationEntityUsingLocationIdStatic = new LocationCreditCardRelations().LocationEntityUsingLocationId;

		/// <summary>CTor</summary>
		static StaticLocationCreditCardRelations()
		{
		}
	}
}
