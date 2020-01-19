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
	/// <summary>Implements the relations factory for the entity: Device. </summary>
	public partial class DeviceRelations
	{
		/// <summary>CTor</summary>
		public DeviceRelations()
		{
		}

		/// <summary>Gets all relations of the DeviceEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CalibrationEntityUsingDeviceId);
			toReturn.Add(this.DeviceEventEntityUsingDeviceId);
			toReturn.Add(this.DeviceMessageEntityUsingDeviceId);
			toReturn.Add(this.DeviceStateTrackingEntityUsingDeviceId);
			toReturn.Add(this.ExceptionLogEntityUsingDeviceId);
			toReturn.Add(this.PurchaseHistoryEntityUsingDeviceId);
			toReturn.Add(this.ScanHistoryEntityUsingDeviceId);
			toReturn.Add(this.LocationEntityUsingLocationId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between DeviceEntity and CalibrationEntity over the 1:n relation they have, using the relation between the fields:
		/// Device.DeviceId - Calibration.DeviceId
		/// </summary>
		public virtual IEntityRelation CalibrationEntityUsingDeviceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Calibrations" , true);
				relation.AddEntityFieldPair(DeviceFields.DeviceId, CalibrationFields.DeviceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DeviceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CalibrationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DeviceEntity and DeviceEventEntity over the 1:n relation they have, using the relation between the fields:
		/// Device.DeviceId - DeviceEvent.DeviceId
		/// </summary>
		public virtual IEntityRelation DeviceEventEntityUsingDeviceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DeviceEvents" , true);
				relation.AddEntityFieldPair(DeviceFields.DeviceId, DeviceEventFields.DeviceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DeviceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DeviceEventEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DeviceEntity and DeviceMessageEntity over the 1:n relation they have, using the relation between the fields:
		/// Device.DeviceId - DeviceMessage.DeviceId
		/// </summary>
		public virtual IEntityRelation DeviceMessageEntityUsingDeviceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DeviceMessages" , true);
				relation.AddEntityFieldPair(DeviceFields.DeviceId, DeviceMessageFields.DeviceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DeviceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DeviceMessageEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DeviceEntity and DeviceStateTrackingEntity over the 1:n relation they have, using the relation between the fields:
		/// Device.DeviceId - DeviceStateTracking.DeviceId
		/// </summary>
		public virtual IEntityRelation DeviceStateTrackingEntityUsingDeviceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DeviceStateTrackings" , true);
				relation.AddEntityFieldPair(DeviceFields.DeviceId, DeviceStateTrackingFields.DeviceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DeviceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DeviceStateTrackingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DeviceEntity and ExceptionLogEntity over the 1:n relation they have, using the relation between the fields:
		/// Device.DeviceId - ExceptionLog.DeviceId
		/// </summary>
		public virtual IEntityRelation ExceptionLogEntityUsingDeviceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ExceptionLogs" , true);
				relation.AddEntityFieldPair(DeviceFields.DeviceId, ExceptionLogFields.DeviceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DeviceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExceptionLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DeviceEntity and PurchaseHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// Device.DeviceId - PurchaseHistory.DeviceId
		/// </summary>
		public virtual IEntityRelation PurchaseHistoryEntityUsingDeviceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PurchaseHistories" , true);
				relation.AddEntityFieldPair(DeviceFields.DeviceId, PurchaseHistoryFields.DeviceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DeviceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PurchaseHistoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DeviceEntity and ScanHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// Device.DeviceId - ScanHistory.DeviceId
		/// </summary>
		public virtual IEntityRelation ScanHistoryEntityUsingDeviceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ScanHistories" , true);
				relation.AddEntityFieldPair(DeviceFields.DeviceId, ScanHistoryFields.DeviceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DeviceEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ScanHistoryEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between DeviceEntity and LocationEntity over the m:1 relation they have, using the relation between the fields:
		/// Device.LocationId - Location.LocationId
		/// </summary>
		public virtual IEntityRelation LocationEntityUsingLocationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Location", false);
				relation.AddEntityFieldPair(LocationFields.LocationId, DeviceFields.LocationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DeviceEntity", true);
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
	internal static class StaticDeviceRelations
	{
		internal static readonly IEntityRelation CalibrationEntityUsingDeviceIdStatic = new DeviceRelations().CalibrationEntityUsingDeviceId;
		internal static readonly IEntityRelation DeviceEventEntityUsingDeviceIdStatic = new DeviceRelations().DeviceEventEntityUsingDeviceId;
		internal static readonly IEntityRelation DeviceMessageEntityUsingDeviceIdStatic = new DeviceRelations().DeviceMessageEntityUsingDeviceId;
		internal static readonly IEntityRelation DeviceStateTrackingEntityUsingDeviceIdStatic = new DeviceRelations().DeviceStateTrackingEntityUsingDeviceId;
		internal static readonly IEntityRelation ExceptionLogEntityUsingDeviceIdStatic = new DeviceRelations().ExceptionLogEntityUsingDeviceId;
		internal static readonly IEntityRelation PurchaseHistoryEntityUsingDeviceIdStatic = new DeviceRelations().PurchaseHistoryEntityUsingDeviceId;
		internal static readonly IEntityRelation ScanHistoryEntityUsingDeviceIdStatic = new DeviceRelations().ScanHistoryEntityUsingDeviceId;
		internal static readonly IEntityRelation LocationEntityUsingLocationIdStatic = new DeviceRelations().LocationEntityUsingLocationId;

		/// <summary>CTor</summary>
		static StaticDeviceRelations()
		{
		}
	}
}
