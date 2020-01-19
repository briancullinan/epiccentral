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
	/// <summary>Implements the relations factory for the entity: Calibration. </summary>
	public partial class CalibrationRelations
	{
		/// <summary>CTor</summary>
		public CalibrationRelations()
		{
		}

		/// <summary>Gets all relations of the CalibrationEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.TreatmentEntityUsingCalibrationId);
			toReturn.Add(this.DeviceEntityUsingDeviceId);
			toReturn.Add(this.ImageSetEntityUsingImageSetId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CalibrationEntity and TreatmentEntity over the 1:n relation they have, using the relation between the fields:
		/// Calibration.CalibrationId - Treatment.CalibrationId
		/// </summary>
		public virtual IEntityRelation TreatmentEntityUsingCalibrationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Treatments" , true);
				relation.AddEntityFieldPair(CalibrationFields.CalibrationId, TreatmentFields.CalibrationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CalibrationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TreatmentEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CalibrationEntity and DeviceEntity over the m:1 relation they have, using the relation between the fields:
		/// Calibration.DeviceId - Device.DeviceId
		/// </summary>
		public virtual IEntityRelation DeviceEntityUsingDeviceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Device", false);
				relation.AddEntityFieldPair(DeviceFields.DeviceId, CalibrationFields.DeviceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DeviceEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CalibrationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CalibrationEntity and ImageSetEntity over the m:1 relation they have, using the relation between the fields:
		/// Calibration.ImageSetId - ImageSet.ImageSetId
		/// </summary>
		public virtual IEntityRelation ImageSetEntityUsingImageSetId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ImageSet", false);
				relation.AddEntityFieldPair(ImageSetFields.ImageSetId, CalibrationFields.ImageSetId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ImageSetEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CalibrationEntity", true);
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
	internal static class StaticCalibrationRelations
	{
		internal static readonly IEntityRelation TreatmentEntityUsingCalibrationIdStatic = new CalibrationRelations().TreatmentEntityUsingCalibrationId;
		internal static readonly IEntityRelation DeviceEntityUsingDeviceIdStatic = new CalibrationRelations().DeviceEntityUsingDeviceId;
		internal static readonly IEntityRelation ImageSetEntityUsingImageSetIdStatic = new CalibrationRelations().ImageSetEntityUsingImageSetId;

		/// <summary>CTor</summary>
		static StaticCalibrationRelations()
		{
		}
	}
}
