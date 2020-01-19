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
	/// <summary>Implements the relations factory for the entity: Treatment. </summary>
	public partial class TreatmentRelations
	{
		/// <summary>CTor</summary>
		public TreatmentRelations()
		{
		}

		/// <summary>Gets all relations of the TreatmentEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AnalysisResultEntityUsingTreatmentId);
			toReturn.Add(this.CalculationDebugDataEntityUsingTreatmentId);
			toReturn.Add(this.NBAnalysisResultEntityUsingTreatmentId);
			toReturn.Add(this.SeverityEntityUsingTreatmentId);
			toReturn.Add(this.PatientPrescanQuestionEntityUsingTreatmentId);
			toReturn.Add(this.CalibrationEntityUsingCalibrationId);
			toReturn.Add(this.ImageSetEntityUsingEnergizedImageSetId);
			toReturn.Add(this.ImageSetEntityUsingFingerImageSetId);
			toReturn.Add(this.PatientEntityUsingPatientId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between TreatmentEntity and AnalysisResultEntity over the 1:n relation they have, using the relation between the fields:
		/// Treatment.TreatmentId - AnalysisResult.TreatmentId
		/// </summary>
		public virtual IEntityRelation AnalysisResultEntityUsingTreatmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AnalysisResults" , true);
				relation.AddEntityFieldPair(TreatmentFields.TreatmentId, AnalysisResultFields.TreatmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TreatmentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AnalysisResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TreatmentEntity and CalculationDebugDataEntity over the 1:n relation they have, using the relation between the fields:
		/// Treatment.TreatmentId - CalculationDebugData.TreatmentId
		/// </summary>
		public virtual IEntityRelation CalculationDebugDataEntityUsingTreatmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CalculationDebugDatas" , true);
				relation.AddEntityFieldPair(TreatmentFields.TreatmentId, CalculationDebugDataFields.TreatmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TreatmentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CalculationDebugDataEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TreatmentEntity and NBAnalysisResultEntity over the 1:n relation they have, using the relation between the fields:
		/// Treatment.TreatmentId - NBAnalysisResult.TreatmentId
		/// </summary>
		public virtual IEntityRelation NBAnalysisResultEntityUsingTreatmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "NBAnalysisResults" , true);
				relation.AddEntityFieldPair(TreatmentFields.TreatmentId, NBAnalysisResultFields.TreatmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TreatmentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NBAnalysisResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TreatmentEntity and SeverityEntity over the 1:n relation they have, using the relation between the fields:
		/// Treatment.TreatmentId - Severity.TreatmentId
		/// </summary>
		public virtual IEntityRelation SeverityEntityUsingTreatmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Severities" , true);
				relation.AddEntityFieldPair(TreatmentFields.TreatmentId, SeverityFields.TreatmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TreatmentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SeverityEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TreatmentEntity and PatientPrescanQuestionEntity over the 1:1 relation they have, using the relation between the fields:
		/// Treatment.TreatmentId - PatientPrescanQuestion.TreatmentId
		/// </summary>
		public virtual IEntityRelation PatientPrescanQuestionEntityUsingTreatmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "PatientPrescanQuestion", true);

				relation.AddEntityFieldPair(TreatmentFields.TreatmentId, PatientPrescanQuestionFields.TreatmentId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TreatmentEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PatientPrescanQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TreatmentEntity and CalibrationEntity over the m:1 relation they have, using the relation between the fields:
		/// Treatment.CalibrationId - Calibration.CalibrationId
		/// </summary>
		public virtual IEntityRelation CalibrationEntityUsingCalibrationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Calibration", false);
				relation.AddEntityFieldPair(CalibrationFields.CalibrationId, TreatmentFields.CalibrationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CalibrationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TreatmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TreatmentEntity and ImageSetEntity over the m:1 relation they have, using the relation between the fields:
		/// Treatment.EnergizedImageSetId - ImageSet.ImageSetId
		/// </summary>
		public virtual IEntityRelation ImageSetEntityUsingEnergizedImageSetId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ImageSet", false);
				relation.AddEntityFieldPair(ImageSetFields.ImageSetId, TreatmentFields.EnergizedImageSetId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ImageSetEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TreatmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TreatmentEntity and ImageSetEntity over the m:1 relation they have, using the relation between the fields:
		/// Treatment.FingerImageSetId - ImageSet.ImageSetId
		/// </summary>
		public virtual IEntityRelation ImageSetEntityUsingFingerImageSetId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ImageSet_", false);
				relation.AddEntityFieldPair(ImageSetFields.ImageSetId, TreatmentFields.FingerImageSetId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ImageSetEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TreatmentEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TreatmentEntity and PatientEntity over the m:1 relation they have, using the relation between the fields:
		/// Treatment.PatientId - Patient.PatientId
		/// </summary>
		public virtual IEntityRelation PatientEntityUsingPatientId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Patient", false);
				relation.AddEntityFieldPair(PatientFields.PatientId, TreatmentFields.PatientId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PatientEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TreatmentEntity", true);
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
	internal static class StaticTreatmentRelations
	{
		internal static readonly IEntityRelation AnalysisResultEntityUsingTreatmentIdStatic = new TreatmentRelations().AnalysisResultEntityUsingTreatmentId;
		internal static readonly IEntityRelation CalculationDebugDataEntityUsingTreatmentIdStatic = new TreatmentRelations().CalculationDebugDataEntityUsingTreatmentId;
		internal static readonly IEntityRelation NBAnalysisResultEntityUsingTreatmentIdStatic = new TreatmentRelations().NBAnalysisResultEntityUsingTreatmentId;
		internal static readonly IEntityRelation SeverityEntityUsingTreatmentIdStatic = new TreatmentRelations().SeverityEntityUsingTreatmentId;
		internal static readonly IEntityRelation PatientPrescanQuestionEntityUsingTreatmentIdStatic = new TreatmentRelations().PatientPrescanQuestionEntityUsingTreatmentId;
		internal static readonly IEntityRelation CalibrationEntityUsingCalibrationIdStatic = new TreatmentRelations().CalibrationEntityUsingCalibrationId;
		internal static readonly IEntityRelation ImageSetEntityUsingEnergizedImageSetIdStatic = new TreatmentRelations().ImageSetEntityUsingEnergizedImageSetId;
		internal static readonly IEntityRelation ImageSetEntityUsingFingerImageSetIdStatic = new TreatmentRelations().ImageSetEntityUsingFingerImageSetId;
		internal static readonly IEntityRelation PatientEntityUsingPatientIdStatic = new TreatmentRelations().PatientEntityUsingPatientId;

		/// <summary>CTor</summary>
		static StaticTreatmentRelations()
		{
		}
	}
}
