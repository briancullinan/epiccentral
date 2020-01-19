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
	/// <summary>Implements the relations factory for the entity: PurchaseHistory. </summary>
	public partial class PurchaseHistoryRelations
	{
		/// <summary>CTor</summary>
		public PurchaseHistoryRelations()
		{
		}

		/// <summary>Gets all relations of the PurchaseHistoryEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.DeviceEntityUsingDeviceId);
			toReturn.Add(this.LocationEntityUsingLocationId);
			toReturn.Add(this.UserEntityUsingUserId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between PurchaseHistoryEntity and DeviceEntity over the m:1 relation they have, using the relation between the fields:
		/// PurchaseHistory.DeviceId - Device.DeviceId
		/// </summary>
		public virtual IEntityRelation DeviceEntityUsingDeviceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Device", false);
				relation.AddEntityFieldPair(DeviceFields.DeviceId, PurchaseHistoryFields.DeviceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DeviceEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PurchaseHistoryEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PurchaseHistoryEntity and LocationEntity over the m:1 relation they have, using the relation between the fields:
		/// PurchaseHistory.LocationId - Location.LocationId
		/// </summary>
		public virtual IEntityRelation LocationEntityUsingLocationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Location", false);
				relation.AddEntityFieldPair(LocationFields.LocationId, PurchaseHistoryFields.LocationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PurchaseHistoryEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between PurchaseHistoryEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// PurchaseHistory.UserId - User.UserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "User", false);
				relation.AddEntityFieldPair(UserFields.UserId, PurchaseHistoryFields.UserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PurchaseHistoryEntity", true);
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
	internal static class StaticPurchaseHistoryRelations
	{
		internal static readonly IEntityRelation DeviceEntityUsingDeviceIdStatic = new PurchaseHistoryRelations().DeviceEntityUsingDeviceId;
		internal static readonly IEntityRelation LocationEntityUsingLocationIdStatic = new PurchaseHistoryRelations().LocationEntityUsingLocationId;
		internal static readonly IEntityRelation UserEntityUsingUserIdStatic = new PurchaseHistoryRelations().UserEntityUsingUserId;

		/// <summary>CTor</summary>
		static StaticPurchaseHistoryRelations()
		{
		}
	}
}
