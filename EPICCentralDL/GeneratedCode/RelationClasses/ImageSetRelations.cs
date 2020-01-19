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
	/// <summary>Implements the relations factory for the entity: ImageSet. </summary>
	public partial class ImageSetRelations
	{
		/// <summary>CTor</summary>
		public ImageSetRelations()
		{
		}

		/// <summary>Gets all relations of the ImageSetEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CalibrationEntityUsingImageSetId);
			toReturn.Add(this.TreatmentEntityUsingEnergizedImageSetId);
			toReturn.Add(this.TreatmentEntityUsingFingerImageSetId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ImageSetEntity and CalibrationEntity over the 1:n relation they have, using the relation between the fields:
		/// ImageSet.ImageSetId - Calibration.ImageSetId
		/// </summary>
		public virtual IEntityRelation CalibrationEntityUsingImageSetId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Calibrations" , true);
				relation.AddEntityFieldPair(ImageSetFields.ImageSetId, CalibrationFields.ImageSetId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ImageSetEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CalibrationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ImageSetEntity and TreatmentEntity over the 1:n relation they have, using the relation between the fields:
		/// ImageSet.ImageSetId - Treatment.EnergizedImageSetId
		/// </summary>
		public virtual IEntityRelation TreatmentEntityUsingEnergizedImageSetId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Treatments" , true);
				relation.AddEntityFieldPair(ImageSetFields.ImageSetId, TreatmentFields.EnergizedImageSetId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ImageSetEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TreatmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ImageSetEntity and TreatmentEntity over the 1:n relation they have, using the relation between the fields:
		/// ImageSet.ImageSetId - Treatment.FingerImageSetId
		/// </summary>
		public virtual IEntityRelation TreatmentEntityUsingFingerImageSetId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Treatments_" , true);
				relation.AddEntityFieldPair(ImageSetFields.ImageSetId, TreatmentFields.FingerImageSetId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ImageSetEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TreatmentEntity", false);
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
	internal static class StaticImageSetRelations
	{
		internal static readonly IEntityRelation CalibrationEntityUsingImageSetIdStatic = new ImageSetRelations().CalibrationEntityUsingImageSetId;
		internal static readonly IEntityRelation TreatmentEntityUsingEnergizedImageSetIdStatic = new ImageSetRelations().TreatmentEntityUsingEnergizedImageSetId;
		internal static readonly IEntityRelation TreatmentEntityUsingFingerImageSetIdStatic = new ImageSetRelations().TreatmentEntityUsingFingerImageSetId;

		/// <summary>CTor</summary>
		static StaticImageSetRelations()
		{
		}
	}
}
