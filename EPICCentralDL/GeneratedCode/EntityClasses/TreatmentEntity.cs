///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 3.5
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Data;
using System.Xml.Serialization;
using EPICCentralDL;
using EPICCentralDL.FactoryClasses;
using EPICCentralDL.DaoClasses;
using EPICCentralDL.RelationClasses;
using EPICCentralDL.HelperClasses;
using EPICCentralDL.CollectionClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentralDL.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>Entity class which represents the entity 'Treatment'. <br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class TreatmentEntity : CommonEntityBase
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EPICCentralDL.CollectionClasses.AnalysisResultCollection	_analysisResults;
		private bool	_alwaysFetchAnalysisResults, _alreadyFetchedAnalysisResults;
		private EPICCentralDL.CollectionClasses.CalculationDebugDataCollection	_calculationDebugDatas;
		private bool	_alwaysFetchCalculationDebugDatas, _alreadyFetchedCalculationDebugDatas;
		private EPICCentralDL.CollectionClasses.NBAnalysisResultCollection	_nBAnalysisResults;
		private bool	_alwaysFetchNBAnalysisResults, _alreadyFetchedNBAnalysisResults;
		private EPICCentralDL.CollectionClasses.SeverityCollection	_severities;
		private bool	_alwaysFetchSeverities, _alreadyFetchedSeverities;
		private CalibrationEntity _calibration;
		private bool	_alwaysFetchCalibration, _alreadyFetchedCalibration, _calibrationReturnsNewIfNotFound;
		private ImageSetEntity _imageSet;
		private bool	_alwaysFetchImageSet, _alreadyFetchedImageSet, _imageSetReturnsNewIfNotFound;
		private ImageSetEntity _imageSet_;
		private bool	_alwaysFetchImageSet_, _alreadyFetchedImageSet_, _imageSet_ReturnsNewIfNotFound;
		private PatientEntity _patient;
		private bool	_alwaysFetchPatient, _alreadyFetchedPatient, _patientReturnsNewIfNotFound;
		private PatientPrescanQuestionEntity _patientPrescanQuestion;
		private bool	_alwaysFetchPatientPrescanQuestion, _alreadyFetchedPatientPrescanQuestion, _patientPrescanQuestionReturnsNewIfNotFound;

		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Calibration</summary>
			public static readonly string Calibration = "Calibration";
			/// <summary>Member name ImageSet</summary>
			public static readonly string ImageSet = "ImageSet";
			/// <summary>Member name ImageSet_</summary>
			public static readonly string ImageSet_ = "ImageSet_";
			/// <summary>Member name Patient</summary>
			public static readonly string Patient = "Patient";
			/// <summary>Member name AnalysisResults</summary>
			public static readonly string AnalysisResults = "AnalysisResults";
			/// <summary>Member name CalculationDebugDatas</summary>
			public static readonly string CalculationDebugDatas = "CalculationDebugDatas";
			/// <summary>Member name NBAnalysisResults</summary>
			public static readonly string NBAnalysisResults = "NBAnalysisResults";
			/// <summary>Member name Severities</summary>
			public static readonly string Severities = "Severities";
			/// <summary>Member name PatientPrescanQuestion</summary>
			public static readonly string PatientPrescanQuestion = "PatientPrescanQuestion";
		}
		#endregion
		
		/// <summary>Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static TreatmentEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary>CTor</summary>
		public TreatmentEntity() :base("TreatmentEntity")
		{
			InitClassEmpty(null);
		}
		
		/// <summary>CTor</summary>
		/// <param name="treatmentId">PK value for Treatment which data should be fetched into this Treatment object</param>
		public TreatmentEntity(System.Int64 treatmentId):base("TreatmentEntity")
		{
			InitClassFetch(treatmentId, null, null);
		}

		/// <summary>CTor</summary>
		/// <param name="treatmentId">PK value for Treatment which data should be fetched into this Treatment object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		public TreatmentEntity(System.Int64 treatmentId, IPrefetchPath prefetchPathToUse):base("TreatmentEntity")
		{
			InitClassFetch(treatmentId, null, prefetchPathToUse);
		}

		/// <summary>CTor</summary>
		/// <param name="treatmentId">PK value for Treatment which data should be fetched into this Treatment object</param>
		/// <param name="validator">The custom validator object for this TreatmentEntity</param>
		public TreatmentEntity(System.Int64 treatmentId, IValidator validator):base("TreatmentEntity")
		{
			InitClassFetch(treatmentId, validator, null);
		}

		/// <summary>Private CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected TreatmentEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			_analysisResults = (EPICCentralDL.CollectionClasses.AnalysisResultCollection)info.GetValue("_analysisResults", typeof(EPICCentralDL.CollectionClasses.AnalysisResultCollection));
			_alwaysFetchAnalysisResults = info.GetBoolean("_alwaysFetchAnalysisResults");
			_alreadyFetchedAnalysisResults = info.GetBoolean("_alreadyFetchedAnalysisResults");

			_calculationDebugDatas = (EPICCentralDL.CollectionClasses.CalculationDebugDataCollection)info.GetValue("_calculationDebugDatas", typeof(EPICCentralDL.CollectionClasses.CalculationDebugDataCollection));
			_alwaysFetchCalculationDebugDatas = info.GetBoolean("_alwaysFetchCalculationDebugDatas");
			_alreadyFetchedCalculationDebugDatas = info.GetBoolean("_alreadyFetchedCalculationDebugDatas");

			_nBAnalysisResults = (EPICCentralDL.CollectionClasses.NBAnalysisResultCollection)info.GetValue("_nBAnalysisResults", typeof(EPICCentralDL.CollectionClasses.NBAnalysisResultCollection));
			_alwaysFetchNBAnalysisResults = info.GetBoolean("_alwaysFetchNBAnalysisResults");
			_alreadyFetchedNBAnalysisResults = info.GetBoolean("_alreadyFetchedNBAnalysisResults");

			_severities = (EPICCentralDL.CollectionClasses.SeverityCollection)info.GetValue("_severities", typeof(EPICCentralDL.CollectionClasses.SeverityCollection));
			_alwaysFetchSeverities = info.GetBoolean("_alwaysFetchSeverities");
			_alreadyFetchedSeverities = info.GetBoolean("_alreadyFetchedSeverities");
			_calibration = (CalibrationEntity)info.GetValue("_calibration", typeof(CalibrationEntity));
			if(_calibration!=null)
			{
				_calibration.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_calibrationReturnsNewIfNotFound = info.GetBoolean("_calibrationReturnsNewIfNotFound");
			_alwaysFetchCalibration = info.GetBoolean("_alwaysFetchCalibration");
			_alreadyFetchedCalibration = info.GetBoolean("_alreadyFetchedCalibration");

			_imageSet = (ImageSetEntity)info.GetValue("_imageSet", typeof(ImageSetEntity));
			if(_imageSet!=null)
			{
				_imageSet.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_imageSetReturnsNewIfNotFound = info.GetBoolean("_imageSetReturnsNewIfNotFound");
			_alwaysFetchImageSet = info.GetBoolean("_alwaysFetchImageSet");
			_alreadyFetchedImageSet = info.GetBoolean("_alreadyFetchedImageSet");

			_imageSet_ = (ImageSetEntity)info.GetValue("_imageSet_", typeof(ImageSetEntity));
			if(_imageSet_!=null)
			{
				_imageSet_.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_imageSet_ReturnsNewIfNotFound = info.GetBoolean("_imageSet_ReturnsNewIfNotFound");
			_alwaysFetchImageSet_ = info.GetBoolean("_alwaysFetchImageSet_");
			_alreadyFetchedImageSet_ = info.GetBoolean("_alreadyFetchedImageSet_");

			_patient = (PatientEntity)info.GetValue("_patient", typeof(PatientEntity));
			if(_patient!=null)
			{
				_patient.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_patientReturnsNewIfNotFound = info.GetBoolean("_patientReturnsNewIfNotFound");
			_alwaysFetchPatient = info.GetBoolean("_alwaysFetchPatient");
			_alreadyFetchedPatient = info.GetBoolean("_alreadyFetchedPatient");
			_patientPrescanQuestion = (PatientPrescanQuestionEntity)info.GetValue("_patientPrescanQuestion", typeof(PatientPrescanQuestionEntity));
			if(_patientPrescanQuestion!=null)
			{
				_patientPrescanQuestion.AfterSave+=new EventHandler(OnEntityAfterSave);
			}
			_patientPrescanQuestionReturnsNewIfNotFound = info.GetBoolean("_patientPrescanQuestionReturnsNewIfNotFound");
			_alwaysFetchPatientPrescanQuestion = info.GetBoolean("_alwaysFetchPatientPrescanQuestion");
			_alreadyFetchedPatientPrescanQuestion = info.GetBoolean("_alreadyFetchedPatientPrescanQuestion");
			this.FixupDeserialization(FieldInfoProviderSingleton.GetInstance(), PersistenceInfoProviderSingleton.GetInstance());
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}
		
		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((TreatmentFieldIndex)fieldIndex)
			{
				case TreatmentFieldIndex.PatientId:
					DesetupSyncPatient(true, false);
					_alreadyFetchedPatient = false;
					break;
				case TreatmentFieldIndex.CalibrationId:
					DesetupSyncCalibration(true, false);
					_alreadyFetchedCalibration = false;
					break;
				case TreatmentFieldIndex.EnergizedImageSetId:
					DesetupSyncImageSet(true, false);
					_alreadyFetchedImageSet = false;
					break;
				case TreatmentFieldIndex.FingerImageSetId:
					DesetupSyncImageSet_(true, false);
					_alreadyFetchedImageSet_ = false;
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}

		/// <summary> Will perform post-ReadXml actions</summary>
		protected override void PerformPostReadXmlFixups()
		{
			_alreadyFetchedAnalysisResults = (_analysisResults.Count > 0);
			_alreadyFetchedCalculationDebugDatas = (_calculationDebugDatas.Count > 0);
			_alreadyFetchedNBAnalysisResults = (_nBAnalysisResults.Count > 0);
			_alreadyFetchedSeverities = (_severities.Count > 0);
			_alreadyFetchedCalibration = (_calibration != null);
			_alreadyFetchedImageSet = (_imageSet != null);
			_alreadyFetchedImageSet_ = (_imageSet_ != null);
			_alreadyFetchedPatient = (_patient != null);
			_alreadyFetchedPatientPrescanQuestion = (_patientPrescanQuestion != null);
		}
				
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		protected override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		internal static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Calibration":
					toReturn.Add(Relations.CalibrationEntityUsingCalibrationId);
					break;
				case "ImageSet":
					toReturn.Add(Relations.ImageSetEntityUsingEnergizedImageSetId);
					break;
				case "ImageSet_":
					toReturn.Add(Relations.ImageSetEntityUsingFingerImageSetId);
					break;
				case "Patient":
					toReturn.Add(Relations.PatientEntityUsingPatientId);
					break;
				case "AnalysisResults":
					toReturn.Add(Relations.AnalysisResultEntityUsingTreatmentId);
					break;
				case "CalculationDebugDatas":
					toReturn.Add(Relations.CalculationDebugDataEntityUsingTreatmentId);
					break;
				case "NBAnalysisResults":
					toReturn.Add(Relations.NBAnalysisResultEntityUsingTreatmentId);
					break;
				case "Severities":
					toReturn.Add(Relations.SeverityEntityUsingTreatmentId);
					break;
				case "PatientPrescanQuestion":
					toReturn.Add(Relations.PatientPrescanQuestionEntityUsingTreatmentId);
					break;
				default:
					break;				
			}
			return toReturn;
		}



		/// <summary> ISerializable member. Does custom serialization so event handlers do not get serialized.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("_analysisResults", (!this.MarkedForDeletion?_analysisResults:null));
			info.AddValue("_alwaysFetchAnalysisResults", _alwaysFetchAnalysisResults);
			info.AddValue("_alreadyFetchedAnalysisResults", _alreadyFetchedAnalysisResults);
			info.AddValue("_calculationDebugDatas", (!this.MarkedForDeletion?_calculationDebugDatas:null));
			info.AddValue("_alwaysFetchCalculationDebugDatas", _alwaysFetchCalculationDebugDatas);
			info.AddValue("_alreadyFetchedCalculationDebugDatas", _alreadyFetchedCalculationDebugDatas);
			info.AddValue("_nBAnalysisResults", (!this.MarkedForDeletion?_nBAnalysisResults:null));
			info.AddValue("_alwaysFetchNBAnalysisResults", _alwaysFetchNBAnalysisResults);
			info.AddValue("_alreadyFetchedNBAnalysisResults", _alreadyFetchedNBAnalysisResults);
			info.AddValue("_severities", (!this.MarkedForDeletion?_severities:null));
			info.AddValue("_alwaysFetchSeverities", _alwaysFetchSeverities);
			info.AddValue("_alreadyFetchedSeverities", _alreadyFetchedSeverities);
			info.AddValue("_calibration", (!this.MarkedForDeletion?_calibration:null));
			info.AddValue("_calibrationReturnsNewIfNotFound", _calibrationReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchCalibration", _alwaysFetchCalibration);
			info.AddValue("_alreadyFetchedCalibration", _alreadyFetchedCalibration);
			info.AddValue("_imageSet", (!this.MarkedForDeletion?_imageSet:null));
			info.AddValue("_imageSetReturnsNewIfNotFound", _imageSetReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchImageSet", _alwaysFetchImageSet);
			info.AddValue("_alreadyFetchedImageSet", _alreadyFetchedImageSet);
			info.AddValue("_imageSet_", (!this.MarkedForDeletion?_imageSet_:null));
			info.AddValue("_imageSet_ReturnsNewIfNotFound", _imageSet_ReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchImageSet_", _alwaysFetchImageSet_);
			info.AddValue("_alreadyFetchedImageSet_", _alreadyFetchedImageSet_);
			info.AddValue("_patient", (!this.MarkedForDeletion?_patient:null));
			info.AddValue("_patientReturnsNewIfNotFound", _patientReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchPatient", _alwaysFetchPatient);
			info.AddValue("_alreadyFetchedPatient", _alreadyFetchedPatient);

			info.AddValue("_patientPrescanQuestion", (!this.MarkedForDeletion?_patientPrescanQuestion:null));
			info.AddValue("_patientPrescanQuestionReturnsNewIfNotFound", _patientPrescanQuestionReturnsNewIfNotFound);
			info.AddValue("_alwaysFetchPatientPrescanQuestion", _alwaysFetchPatientPrescanQuestion);
			info.AddValue("_alreadyFetchedPatientPrescanQuestion", _alreadyFetchedPatientPrescanQuestion);

			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}
		
		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override void SetRelatedEntityProperty(string propertyName, IEntityCore entity)
		{
			switch(propertyName)
			{
				case "Calibration":
					_alreadyFetchedCalibration = true;
					this.Calibration = (CalibrationEntity)entity;
					break;
				case "ImageSet":
					_alreadyFetchedImageSet = true;
					this.ImageSet = (ImageSetEntity)entity;
					break;
				case "ImageSet_":
					_alreadyFetchedImageSet_ = true;
					this.ImageSet_ = (ImageSetEntity)entity;
					break;
				case "Patient":
					_alreadyFetchedPatient = true;
					this.Patient = (PatientEntity)entity;
					break;
				case "AnalysisResults":
					_alreadyFetchedAnalysisResults = true;
					if(entity!=null)
					{
						this.AnalysisResults.Add((AnalysisResultEntity)entity);
					}
					break;
				case "CalculationDebugDatas":
					_alreadyFetchedCalculationDebugDatas = true;
					if(entity!=null)
					{
						this.CalculationDebugDatas.Add((CalculationDebugDataEntity)entity);
					}
					break;
				case "NBAnalysisResults":
					_alreadyFetchedNBAnalysisResults = true;
					if(entity!=null)
					{
						this.NBAnalysisResults.Add((NBAnalysisResultEntity)entity);
					}
					break;
				case "Severities":
					_alreadyFetchedSeverities = true;
					if(entity!=null)
					{
						this.Severities.Add((SeverityEntity)entity);
					}
					break;
				case "PatientPrescanQuestion":
					_alreadyFetchedPatientPrescanQuestion = true;
					this.PatientPrescanQuestion = (PatientPrescanQuestionEntity)entity;
					break;
				default:
					this.OnSetRelatedEntityProperty(propertyName, entity);
					break;
			}
		}

		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override void SetRelatedEntity(IEntityCore relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "Calibration":
					SetupSyncCalibration(relatedEntity);
					break;
				case "ImageSet":
					SetupSyncImageSet(relatedEntity);
					break;
				case "ImageSet_":
					SetupSyncImageSet_(relatedEntity);
					break;
				case "Patient":
					SetupSyncPatient(relatedEntity);
					break;
				case "AnalysisResults":
					_analysisResults.Add((AnalysisResultEntity)relatedEntity);
					break;
				case "CalculationDebugDatas":
					_calculationDebugDatas.Add((CalculationDebugDataEntity)relatedEntity);
					break;
				case "NBAnalysisResults":
					_nBAnalysisResults.Add((NBAnalysisResultEntity)relatedEntity);
					break;
				case "Severities":
					_severities.Add((SeverityEntity)relatedEntity);
					break;
				case "PatientPrescanQuestion":
					SetupSyncPatientPrescanQuestion(relatedEntity);
					break;
				default:
					break;
			}
		}
		
		/// <summary> Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		/// <param name="signalRelatedEntityManyToOne">if set to true it will notify the manytoone side, if applicable.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override void UnsetRelatedEntity(IEntityCore relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
		{
			switch(fieldName)
			{
				case "Calibration":
					DesetupSyncCalibration(false, true);
					break;
				case "ImageSet":
					DesetupSyncImageSet(false, true);
					break;
				case "ImageSet_":
					DesetupSyncImageSet_(false, true);
					break;
				case "Patient":
					DesetupSyncPatient(false, true);
					break;
				case "AnalysisResults":
					this.PerformRelatedEntityRemoval(_analysisResults, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CalculationDebugDatas":
					this.PerformRelatedEntityRemoval(_calculationDebugDatas, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "NBAnalysisResults":
					this.PerformRelatedEntityRemoval(_nBAnalysisResults, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Severities":
					this.PerformRelatedEntityRemoval(_severities, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PatientPrescanQuestion":
					DesetupSyncPatientPrescanQuestion(false, true);
					break;
				default:
					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		protected override List<IEntity> GetDependingRelatedEntities()
		{
			List<IEntity> toReturn = new List<IEntity>();
			if(_patientPrescanQuestion!=null)
			{
				toReturn.Add(_patientPrescanQuestion);
			}
			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		protected override List<IEntity> GetDependentRelatedEntities()
		{
			List<IEntity> toReturn = new List<IEntity>();
			if(_calibration!=null)
			{
				toReturn.Add(_calibration);
			}
			if(_imageSet!=null)
			{
				toReturn.Add(_imageSet);
			}
			if(_imageSet_!=null)
			{
				toReturn.Add(_imageSet_);
			}
			if(_patient!=null)
			{
				toReturn.Add(_patient);
			}
			return toReturn;
		}
		
		/// <summary> Gets a List of all entity collections stored as member variables in this entity. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		protected override List<IEntityCollection> GetMemberEntityCollections()
		{
			List<IEntityCollection> toReturn = new List<IEntityCollection>();
			toReturn.Add(_analysisResults);
			toReturn.Add(_calculationDebugDatas);
			toReturn.Add(_nBAnalysisResults);
			toReturn.Add(_severities);

			return toReturn;
		}


		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="treatmentId">PK value for Treatment which data should be fetched into this Treatment object</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 treatmentId)
		{
			return FetchUsingPK(treatmentId, null, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="treatmentId">PK value for Treatment which data should be fetched into this Treatment object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 treatmentId, IPrefetchPath prefetchPathToUse)
		{
			return FetchUsingPK(treatmentId, prefetchPathToUse, null, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="treatmentId">PK value for Treatment which data should be fetched into this Treatment object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 treatmentId, IPrefetchPath prefetchPathToUse, Context contextToUse)
		{
			return FetchUsingPK(treatmentId, prefetchPathToUse, contextToUse, null);
		}

		/// <summary> Fetches the contents of this entity from the persistent storage using the primary key.</summary>
		/// <param name="treatmentId">PK value for Treatment which data should be fetched into this Treatment object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		public bool FetchUsingPK(System.Int64 treatmentId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Fetch(treatmentId, prefetchPathToUse, contextToUse, excludedIncludedFields);
		}

		/// <summary> Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. Refetching an empty Entity has no effect. </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		public override bool Refetch()
		{
			return Fetch(this.TreatmentId, null, null, null);
		}


				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		protected override List<IEntityRelation> GetAllRelations()
		{
			return new TreatmentRelations().GetAllRelations();
		}

		/// <summary> Retrieves all related entities of type 'AnalysisResultEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'AnalysisResultEntity'</returns>
		public EPICCentralDL.CollectionClasses.AnalysisResultCollection GetMultiAnalysisResults(bool forceFetch)
		{
			return GetMultiAnalysisResults(forceFetch, _analysisResults.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'AnalysisResultEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'AnalysisResultEntity'</returns>
		public EPICCentralDL.CollectionClasses.AnalysisResultCollection GetMultiAnalysisResults(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiAnalysisResults(forceFetch, _analysisResults.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'AnalysisResultEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.AnalysisResultCollection GetMultiAnalysisResults(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiAnalysisResults(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'AnalysisResultEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.AnalysisResultCollection GetMultiAnalysisResults(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedAnalysisResults || forceFetch || _alwaysFetchAnalysisResults) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_analysisResults);
				_analysisResults.SuppressClearInGetMulti=!forceFetch;
				_analysisResults.EntityFactoryToUse = entityFactoryToUse;
				_analysisResults.GetMultiManyToOne(this, filter);
				_analysisResults.SuppressClearInGetMulti=false;
				_alreadyFetchedAnalysisResults = true;
			}
			return _analysisResults;
		}

		/// <summary> Sets the collection parameters for the collection for 'AnalysisResults'. These settings will be taken into account
		/// when the property AnalysisResults is requested or GetMultiAnalysisResults is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersAnalysisResults(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_analysisResults.SortClauses=sortClauses;
			_analysisResults.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'CalculationDebugDataEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'CalculationDebugDataEntity'</returns>
		public EPICCentralDL.CollectionClasses.CalculationDebugDataCollection GetMultiCalculationDebugDatas(bool forceFetch)
		{
			return GetMultiCalculationDebugDatas(forceFetch, _calculationDebugDatas.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'CalculationDebugDataEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'CalculationDebugDataEntity'</returns>
		public EPICCentralDL.CollectionClasses.CalculationDebugDataCollection GetMultiCalculationDebugDatas(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiCalculationDebugDatas(forceFetch, _calculationDebugDatas.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'CalculationDebugDataEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.CalculationDebugDataCollection GetMultiCalculationDebugDatas(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiCalculationDebugDatas(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'CalculationDebugDataEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.CalculationDebugDataCollection GetMultiCalculationDebugDatas(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedCalculationDebugDatas || forceFetch || _alwaysFetchCalculationDebugDatas) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_calculationDebugDatas);
				_calculationDebugDatas.SuppressClearInGetMulti=!forceFetch;
				_calculationDebugDatas.EntityFactoryToUse = entityFactoryToUse;
				_calculationDebugDatas.GetMultiManyToOne(this, filter);
				_calculationDebugDatas.SuppressClearInGetMulti=false;
				_alreadyFetchedCalculationDebugDatas = true;
			}
			return _calculationDebugDatas;
		}

		/// <summary> Sets the collection parameters for the collection for 'CalculationDebugDatas'. These settings will be taken into account
		/// when the property CalculationDebugDatas is requested or GetMultiCalculationDebugDatas is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersCalculationDebugDatas(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_calculationDebugDatas.SortClauses=sortClauses;
			_calculationDebugDatas.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'NBAnalysisResultEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'NBAnalysisResultEntity'</returns>
		public EPICCentralDL.CollectionClasses.NBAnalysisResultCollection GetMultiNBAnalysisResults(bool forceFetch)
		{
			return GetMultiNBAnalysisResults(forceFetch, _nBAnalysisResults.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'NBAnalysisResultEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'NBAnalysisResultEntity'</returns>
		public EPICCentralDL.CollectionClasses.NBAnalysisResultCollection GetMultiNBAnalysisResults(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiNBAnalysisResults(forceFetch, _nBAnalysisResults.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'NBAnalysisResultEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.NBAnalysisResultCollection GetMultiNBAnalysisResults(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiNBAnalysisResults(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'NBAnalysisResultEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.NBAnalysisResultCollection GetMultiNBAnalysisResults(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedNBAnalysisResults || forceFetch || _alwaysFetchNBAnalysisResults) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_nBAnalysisResults);
				_nBAnalysisResults.SuppressClearInGetMulti=!forceFetch;
				_nBAnalysisResults.EntityFactoryToUse = entityFactoryToUse;
				_nBAnalysisResults.GetMultiManyToOne(null, this, filter);
				_nBAnalysisResults.SuppressClearInGetMulti=false;
				_alreadyFetchedNBAnalysisResults = true;
			}
			return _nBAnalysisResults;
		}

		/// <summary> Sets the collection parameters for the collection for 'NBAnalysisResults'. These settings will be taken into account
		/// when the property NBAnalysisResults is requested or GetMultiNBAnalysisResults is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersNBAnalysisResults(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_nBAnalysisResults.SortClauses=sortClauses;
			_nBAnalysisResults.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves all related entities of type 'SeverityEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <returns>Filled collection with all related entities of type 'SeverityEntity'</returns>
		public EPICCentralDL.CollectionClasses.SeverityCollection GetMultiSeverities(bool forceFetch)
		{
			return GetMultiSeverities(forceFetch, _severities.EntityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'SeverityEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of type 'SeverityEntity'</returns>
		public EPICCentralDL.CollectionClasses.SeverityCollection GetMultiSeverities(bool forceFetch, IPredicateExpression filter)
		{
			return GetMultiSeverities(forceFetch, _severities.EntityFactoryToUse, filter);
		}

		/// <summary> Retrieves all related entities of type 'SeverityEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public EPICCentralDL.CollectionClasses.SeverityCollection GetMultiSeverities(bool forceFetch, IEntityFactory entityFactoryToUse)
		{
			return GetMultiSeverities(forceFetch, entityFactoryToUse, null);
		}

		/// <summary> Retrieves all related entities of type 'SeverityEntity' using a relation of type '1:n'.</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the collection and will rerun the complete query instead</param>
		/// <param name="entityFactoryToUse">The entity factory to use for the GetMultiManyToOne() routine.</param>
		/// <param name="filter">Extra filter to limit the resultset.</param>
		/// <returns>Filled collection with all related entities of the type constructed by the passed in entity factory</returns>
		public virtual EPICCentralDL.CollectionClasses.SeverityCollection GetMultiSeverities(bool forceFetch, IEntityFactory entityFactoryToUse, IPredicateExpression filter)
		{
 			if( ( !_alreadyFetchedSeverities || forceFetch || _alwaysFetchSeverities) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode)
			{
				AddToTransactionIfNecessary(_severities);
				_severities.SuppressClearInGetMulti=!forceFetch;
				_severities.EntityFactoryToUse = entityFactoryToUse;
				_severities.GetMultiManyToOne(null, this, filter);
				_severities.SuppressClearInGetMulti=false;
				_alreadyFetchedSeverities = true;
			}
			return _severities;
		}

		/// <summary> Sets the collection parameters for the collection for 'Severities'. These settings will be taken into account
		/// when the property Severities is requested or GetMultiSeverities is called.</summary>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return. When set to 0, this parameter is ignored</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified (null), no sorting is applied.</param>
		public virtual void SetCollectionParametersSeverities(long maxNumberOfItemsToReturn, ISortExpression sortClauses)
		{
			_severities.SortClauses=sortClauses;
			_severities.MaxNumberOfItemsToReturn=maxNumberOfItemsToReturn;
		}

		/// <summary> Retrieves the related entity of type 'CalibrationEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'CalibrationEntity' which is related to this entity.</returns>
		public CalibrationEntity GetSingleCalibration()
		{
			return GetSingleCalibration(false);
		}

		/// <summary> Retrieves the related entity of type 'CalibrationEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'CalibrationEntity' which is related to this entity.</returns>
		public virtual CalibrationEntity GetSingleCalibration(bool forceFetch)
		{
			if( ( !_alreadyFetchedCalibration || forceFetch || _alwaysFetchCalibration) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.CalibrationEntityUsingCalibrationId);
				CalibrationEntity newEntity = new CalibrationEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.CalibrationId);
				}
				if(fetchResult)
				{
					newEntity = (CalibrationEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_calibrationReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.Calibration = newEntity;
				_alreadyFetchedCalibration = fetchResult;
			}
			return _calibration;
		}


		/// <summary> Retrieves the related entity of type 'ImageSetEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'ImageSetEntity' which is related to this entity.</returns>
		public ImageSetEntity GetSingleImageSet()
		{
			return GetSingleImageSet(false);
		}

		/// <summary> Retrieves the related entity of type 'ImageSetEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'ImageSetEntity' which is related to this entity.</returns>
		public virtual ImageSetEntity GetSingleImageSet(bool forceFetch)
		{
			if( ( !_alreadyFetchedImageSet || forceFetch || _alwaysFetchImageSet) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.ImageSetEntityUsingEnergizedImageSetId);
				ImageSetEntity newEntity = new ImageSetEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.EnergizedImageSetId);
				}
				if(fetchResult)
				{
					newEntity = (ImageSetEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_imageSetReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.ImageSet = newEntity;
				_alreadyFetchedImageSet = fetchResult;
			}
			return _imageSet;
		}


		/// <summary> Retrieves the related entity of type 'ImageSetEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'ImageSetEntity' which is related to this entity.</returns>
		public ImageSetEntity GetSingleImageSet_()
		{
			return GetSingleImageSet_(false);
		}

		/// <summary> Retrieves the related entity of type 'ImageSetEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'ImageSetEntity' which is related to this entity.</returns>
		public virtual ImageSetEntity GetSingleImageSet_(bool forceFetch)
		{
			if( ( !_alreadyFetchedImageSet_ || forceFetch || _alwaysFetchImageSet_) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.ImageSetEntityUsingFingerImageSetId);
				ImageSetEntity newEntity = new ImageSetEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.FingerImageSetId.GetValueOrDefault());
				}
				if(fetchResult)
				{
					newEntity = (ImageSetEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_imageSet_ReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.ImageSet_ = newEntity;
				_alreadyFetchedImageSet_ = fetchResult;
			}
			return _imageSet_;
		}


		/// <summary> Retrieves the related entity of type 'PatientEntity', using a relation of type 'n:1'</summary>
		/// <returns>A fetched entity of type 'PatientEntity' which is related to this entity.</returns>
		public PatientEntity GetSinglePatient()
		{
			return GetSinglePatient(false);
		}

		/// <summary> Retrieves the related entity of type 'PatientEntity', using a relation of type 'n:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'PatientEntity' which is related to this entity.</returns>
		public virtual PatientEntity GetSinglePatient(bool forceFetch)
		{
			if( ( !_alreadyFetchedPatient || forceFetch || _alwaysFetchPatient) && !this.IsSerializing && !this.IsDeserializing  && !this.InDesignMode)			
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.PatientEntityUsingPatientId);
				PatientEntity newEntity = new PatientEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.PatientId);
				}
				if(fetchResult)
				{
					newEntity = (PatientEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_patientReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.Patient = newEntity;
				_alreadyFetchedPatient = fetchResult;
			}
			return _patient;
		}

		/// <summary> Retrieves the related entity of type 'PatientPrescanQuestionEntity', using a relation of type '1:1'</summary>
		/// <returns>A fetched entity of type 'PatientPrescanQuestionEntity' which is related to this entity.</returns>
		public PatientPrescanQuestionEntity GetSinglePatientPrescanQuestion()
		{
			return GetSinglePatientPrescanQuestion(false);
		}
		
		/// <summary> Retrieves the related entity of type 'PatientPrescanQuestionEntity', using a relation of type '1:1'</summary>
		/// <param name="forceFetch">if true, it will discard any changes currently in the currently loaded related entity and will refetch the entity from the persistent storage</param>
		/// <returns>A fetched entity of type 'PatientPrescanQuestionEntity' which is related to this entity.</returns>
		public virtual PatientPrescanQuestionEntity GetSinglePatientPrescanQuestion(bool forceFetch)
		{
			if( ( !_alreadyFetchedPatientPrescanQuestion || forceFetch || _alwaysFetchPatientPrescanQuestion) && !this.IsSerializing && !this.IsDeserializing && !this.InDesignMode )
			{
				bool performLazyLoading = this.CheckIfLazyLoadingShouldOccur(Relations.PatientPrescanQuestionEntityUsingTreatmentId);
				PatientPrescanQuestionEntity newEntity = new PatientPrescanQuestionEntity();
				bool fetchResult = false;
				if(performLazyLoading)
				{
					AddToTransactionIfNecessary(newEntity);
					fetchResult = newEntity.FetchUsingPK(this.TreatmentId);
				}
				if(fetchResult)
				{
					newEntity = (PatientPrescanQuestionEntity)GetFromActiveContext(newEntity);
				}
				else
				{
					if(!_patientPrescanQuestionReturnsNewIfNotFound)
					{
						RemoveFromTransactionIfNecessary(newEntity);
						newEntity = null;
					}
				}
				this.PatientPrescanQuestion = newEntity;
				_alreadyFetchedPatientPrescanQuestion = fetchResult;
			}
			return _patientPrescanQuestion;
		}


		/// <summary>Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element.</summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		protected override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Calibration", _calibration);
			toReturn.Add("ImageSet", _imageSet);
			toReturn.Add("ImageSet_", _imageSet_);
			toReturn.Add("Patient", _patient);
			toReturn.Add("AnalysisResults", _analysisResults);
			toReturn.Add("CalculationDebugDatas", _calculationDebugDatas);
			toReturn.Add("NBAnalysisResults", _nBAnalysisResults);
			toReturn.Add("Severities", _severities);
			toReturn.Add("PatientPrescanQuestion", _patientPrescanQuestion);
			return toReturn;
		}
	
		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validatorToUse">Validator to use.</param>
		private void InitClassEmpty(IValidator validatorToUse)
		{
			OnInitializing();
			this.Fields = CreateFields();
			this.Validator = validatorToUse;
			InitClassMembers();

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}		

		/// <summary> Initializes the the entity and fetches the data related to the entity in this entity.</summary>
		/// <param name="treatmentId">PK value for Treatment which data should be fetched into this Treatment object</param>
		/// <param name="validator">The validator object for this TreatmentEntity</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		private void InitClassFetch(System.Int64 treatmentId, IValidator validator, IPrefetchPath prefetchPathToUse)
		{
			OnInitializing();
			this.Validator = validator;
			this.Fields = CreateFields();
			InitClassMembers();	
			Fetch(treatmentId, prefetchPathToUse, null, null);

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassFetch
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		/// <summary> Initializes the class members</summary>
		private void InitClassMembers()
		{

			_analysisResults = new EPICCentralDL.CollectionClasses.AnalysisResultCollection();
			_analysisResults.SetContainingEntityInfo(this, "Treatment");

			_calculationDebugDatas = new EPICCentralDL.CollectionClasses.CalculationDebugDataCollection();
			_calculationDebugDatas.SetContainingEntityInfo(this, "Treatment");

			_nBAnalysisResults = new EPICCentralDL.CollectionClasses.NBAnalysisResultCollection();
			_nBAnalysisResults.SetContainingEntityInfo(this, "Treatment");

			_severities = new EPICCentralDL.CollectionClasses.SeverityCollection();
			_severities.SetContainingEntityInfo(this, "Treatment");
			_calibrationReturnsNewIfNotFound = false;
			_imageSetReturnsNewIfNotFound = false;
			_imageSet_ReturnsNewIfNotFound = false;
			_patientReturnsNewIfNotFound = false;
			_patientPrescanQuestionReturnsNewIfNotFound = false;
			PerformDependencyInjection();

			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}

		#region Custom Property Hashtable Setup
		/// <summary> Initializes the hashtables for the entity type and entity field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Dictionary<string, string>();
			_fieldsCustomProperties = new Dictionary<string, Dictionary<string, string>>();
			Dictionary<string, string> fieldHashtable;
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("TreatmentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("PatientId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("CalibrationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("UniqueIdentifier", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("TreatmentType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("TreatmentTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("PerformedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("EnergizedImageSetId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("FingerImageSetId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("SoftwareVersion", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("FirmwareVersion", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("AnalysisTime", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();
			_fieldsCustomProperties.Add("ReceivedTime", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _calibration</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCalibration(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _calibration, new PropertyChangedEventHandler( OnCalibrationPropertyChanged ), "Calibration", EPICCentralDL.RelationClasses.StaticTreatmentRelations.CalibrationEntityUsingCalibrationIdStatic, true, signalRelatedEntity, "Treatments", resetFKFields, new int[] { (int)TreatmentFieldIndex.CalibrationId } );		
			_calibration = null;
		}
		
		/// <summary> setups the sync logic for member _calibration</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCalibration(IEntityCore relatedEntity)
		{
			if(_calibration!=relatedEntity)
			{		
				DesetupSyncCalibration(true, true);
				_calibration = (CalibrationEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _calibration, new PropertyChangedEventHandler( OnCalibrationPropertyChanged ), "Calibration", EPICCentralDL.RelationClasses.StaticTreatmentRelations.CalibrationEntityUsingCalibrationIdStatic, true, ref _alreadyFetchedCalibration, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCalibrationPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _imageSet</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncImageSet(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _imageSet, new PropertyChangedEventHandler( OnImageSetPropertyChanged ), "ImageSet", EPICCentralDL.RelationClasses.StaticTreatmentRelations.ImageSetEntityUsingEnergizedImageSetIdStatic, true, signalRelatedEntity, "Treatments", resetFKFields, new int[] { (int)TreatmentFieldIndex.EnergizedImageSetId } );		
			_imageSet = null;
		}
		
		/// <summary> setups the sync logic for member _imageSet</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncImageSet(IEntityCore relatedEntity)
		{
			if(_imageSet!=relatedEntity)
			{		
				DesetupSyncImageSet(true, true);
				_imageSet = (ImageSetEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _imageSet, new PropertyChangedEventHandler( OnImageSetPropertyChanged ), "ImageSet", EPICCentralDL.RelationClasses.StaticTreatmentRelations.ImageSetEntityUsingEnergizedImageSetIdStatic, true, ref _alreadyFetchedImageSet, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnImageSetPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _imageSet_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncImageSet_(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _imageSet_, new PropertyChangedEventHandler( OnImageSet_PropertyChanged ), "ImageSet_", EPICCentralDL.RelationClasses.StaticTreatmentRelations.ImageSetEntityUsingFingerImageSetIdStatic, true, signalRelatedEntity, "Treatments_", resetFKFields, new int[] { (int)TreatmentFieldIndex.FingerImageSetId } );		
			_imageSet_ = null;
		}
		
		/// <summary> setups the sync logic for member _imageSet_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncImageSet_(IEntityCore relatedEntity)
		{
			if(_imageSet_!=relatedEntity)
			{		
				DesetupSyncImageSet_(true, true);
				_imageSet_ = (ImageSetEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _imageSet_, new PropertyChangedEventHandler( OnImageSet_PropertyChanged ), "ImageSet_", EPICCentralDL.RelationClasses.StaticTreatmentRelations.ImageSetEntityUsingFingerImageSetIdStatic, true, ref _alreadyFetchedImageSet_, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnImageSet_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _patient</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPatient(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _patient, new PropertyChangedEventHandler( OnPatientPropertyChanged ), "Patient", EPICCentralDL.RelationClasses.StaticTreatmentRelations.PatientEntityUsingPatientIdStatic, true, signalRelatedEntity, "Treatments", resetFKFields, new int[] { (int)TreatmentFieldIndex.PatientId } );		
			_patient = null;
		}
		
		/// <summary> setups the sync logic for member _patient</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPatient(IEntityCore relatedEntity)
		{
			if(_patient!=relatedEntity)
			{		
				DesetupSyncPatient(true, true);
				_patient = (PatientEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _patient, new PropertyChangedEventHandler( OnPatientPropertyChanged ), "Patient", EPICCentralDL.RelationClasses.StaticTreatmentRelations.PatientEntityUsingPatientIdStatic, true, ref _alreadyFetchedPatient, new string[] {  } );
			}
		}

		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPatientPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _patientPrescanQuestion</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncPatientPrescanQuestion(bool signalRelatedEntity, bool resetFKFields)
		{
			this.PerformDesetupSyncRelatedEntity( _patientPrescanQuestion, new PropertyChangedEventHandler( OnPatientPrescanQuestionPropertyChanged ), "PatientPrescanQuestion", EPICCentralDL.RelationClasses.StaticTreatmentRelations.PatientPrescanQuestionEntityUsingTreatmentIdStatic, false, signalRelatedEntity, "Treatment", false, new int[] { (int)TreatmentFieldIndex.TreatmentId } );
			_patientPrescanQuestion = null;
		}
	
		/// <summary> setups the sync logic for member _patientPrescanQuestion</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncPatientPrescanQuestion(IEntityCore relatedEntity)
		{
			if(_patientPrescanQuestion!=relatedEntity)
			{
				DesetupSyncPatientPrescanQuestion(true, true);
				_patientPrescanQuestion = (PatientPrescanQuestionEntity)relatedEntity;
				this.PerformSetupSyncRelatedEntity( _patientPrescanQuestion, new PropertyChangedEventHandler( OnPatientPrescanQuestionPropertyChanged ), "PatientPrescanQuestion", EPICCentralDL.RelationClasses.StaticTreatmentRelations.PatientPrescanQuestionEntityUsingTreatmentIdStatic, false, ref _alreadyFetchedPatientPrescanQuestion, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnPatientPrescanQuestionPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Fetches the entity from the persistent storage. Fetch simply reads the entity into an EntityFields object. </summary>
		/// <param name="treatmentId">PK value for Treatment which data should be fetched into this Treatment object</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch as well</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>True if succeeded, false otherwise.</returns>
		private bool Fetch(System.Int64 treatmentId, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			try
			{
				OnFetch();
				this.Fields[(int)TreatmentFieldIndex.TreatmentId].ForcedCurrentValueWrite(treatmentId);
				CreateDAOInstance().FetchExisting(this, this.Transaction, prefetchPathToUse, contextToUse, excludedIncludedFields);
				return (this.Fields.State == EntityState.Fetched);
			}
			finally
			{
				OnFetchComplete();
			}
		}

		/// <summary> Creates the DAO instance for this type</summary>
		/// <returns></returns>
		protected override IDao CreateDAOInstance()
		{
			return DAOFactory.CreateTreatmentDAO();
		}
		
		/// <summary> Creates the entity factory for this type.</summary>
		/// <returns></returns>
		protected override IEntityFactory CreateEntityFactory()
		{
			return new TreatmentEntityFactory();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static TreatmentRelations Relations
		{
			get	{ return new TreatmentRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'AnalysisResult' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathAnalysisResults
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.AnalysisResultCollection(), (IEntityRelation)GetRelationsForField("AnalysisResults")[0], (int)EPICCentralDL.EntityType.TreatmentEntity, (int)EPICCentralDL.EntityType.AnalysisResultEntity, 0, null, null, null, "AnalysisResults", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'CalculationDebugData' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathCalculationDebugDatas
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.CalculationDebugDataCollection(), (IEntityRelation)GetRelationsForField("CalculationDebugDatas")[0], (int)EPICCentralDL.EntityType.TreatmentEntity, (int)EPICCentralDL.EntityType.CalculationDebugDataEntity, 0, null, null, null, "CalculationDebugDatas", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'NBAnalysisResult' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathNBAnalysisResults
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.NBAnalysisResultCollection(), (IEntityRelation)GetRelationsForField("NBAnalysisResults")[0], (int)EPICCentralDL.EntityType.TreatmentEntity, (int)EPICCentralDL.EntityType.NBAnalysisResultEntity, 0, null, null, null, "NBAnalysisResults", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Severity' for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathSeverities
		{
			get { return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.SeverityCollection(), (IEntityRelation)GetRelationsForField("Severities")[0], (int)EPICCentralDL.EntityType.TreatmentEntity, (int)EPICCentralDL.EntityType.SeverityEntity, 0, null, null, null, "Severities", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Calibration'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathCalibration
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.CalibrationCollection(), (IEntityRelation)GetRelationsForField("Calibration")[0], (int)EPICCentralDL.EntityType.TreatmentEntity, (int)EPICCentralDL.EntityType.CalibrationEntity, 0, null, null, null, "Calibration", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'ImageSet'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathImageSet
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.ImageSetCollection(), (IEntityRelation)GetRelationsForField("ImageSet")[0], (int)EPICCentralDL.EntityType.TreatmentEntity, (int)EPICCentralDL.EntityType.ImageSetEntity, 0, null, null, null, "ImageSet", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'ImageSet'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathImageSet_
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.ImageSetCollection(), (IEntityRelation)GetRelationsForField("ImageSet_")[0], (int)EPICCentralDL.EntityType.TreatmentEntity, (int)EPICCentralDL.EntityType.ImageSetEntity, 0, null, null, null, "ImageSet_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'Patient'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathPatient
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.PatientCollection(), (IEntityRelation)GetRelationsForField("Patient")[0], (int)EPICCentralDL.EntityType.TreatmentEntity, (int)EPICCentralDL.EntityType.PatientEntity, 0, null, null, null, "Patient", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne); }
		}

		/// <summary> Creates a new PrefetchPathElement object which contains all the information to prefetch the related entities of type 'PatientPrescanQuestion'  for this entity.</summary>
		/// <returns>Ready to use IPrefetchPathElement implementation.</returns>
		public static IPrefetchPathElement PrefetchPathPatientPrescanQuestion
		{
			get	{ return new PrefetchPathElement(new EPICCentralDL.CollectionClasses.PatientPrescanQuestionCollection(), (IEntityRelation)GetRelationsForField("PatientPrescanQuestion")[0], (int)EPICCentralDL.EntityType.TreatmentEntity, (int)EPICCentralDL.EntityType.PatientPrescanQuestionEntity, 0, null, null, null, "PatientPrescanQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);	}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		protected override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CustomProperties;}
		}

		/// <summary> The custom properties for the fields of this entity type. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, Dictionary<string, string>> FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary> The custom properties for the fields of the type of this entity instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		protected override Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType
		{
			get { return FieldsCustomProperties;}
		}

		/// <summary> The TreatmentId property of the Entity Treatment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Treatment"."TreatmentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 TreatmentId
		{
			get { return (System.Int64)GetValue((int)TreatmentFieldIndex.TreatmentId, true); }
			set	{ SetValue((int)TreatmentFieldIndex.TreatmentId, value, true); }
		}

		/// <summary> The PatientId property of the Entity Treatment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Treatment"."PatientId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 PatientId
		{
			get { return (System.Int32)GetValue((int)TreatmentFieldIndex.PatientId, true); }
			set	{ SetValue((int)TreatmentFieldIndex.PatientId, value, true); }
		}

		/// <summary> The CalibrationId property of the Entity Treatment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Treatment"."CalibrationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CalibrationId
		{
			get { return (System.Int64)GetValue((int)TreatmentFieldIndex.CalibrationId, true); }
			set	{ SetValue((int)TreatmentFieldIndex.CalibrationId, value, true); }
		}

		/// <summary> The UniqueIdentifier property of the Entity Treatment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Treatment"."UniqueIdentifier"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 48<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String UniqueIdentifier
		{
			get { return (System.String)GetValue((int)TreatmentFieldIndex.UniqueIdentifier, true); }
			set	{ SetValue((int)TreatmentFieldIndex.UniqueIdentifier, value, true); }
		}

		/// <summary> The TreatmentType property of the Entity Treatment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Treatment"."TreatmentType"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallInt, 5, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual EPICCentralDL.Customization.TreatmentType TreatmentType
		{
			get { return (EPICCentralDL.Customization.TreatmentType)GetValue((int)TreatmentFieldIndex.TreatmentType, true); }
			set	{ SetValue((int)TreatmentFieldIndex.TreatmentType, value, true); }
		}

		/// <summary> The TreatmentTime property of the Entity Treatment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Treatment"."TreatmentTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime TreatmentTime
		{
			get { return (System.DateTime)GetValue((int)TreatmentFieldIndex.TreatmentTime, true); }
			set	{ SetValue((int)TreatmentFieldIndex.TreatmentTime, value, true); }
		}

		/// <summary> The PerformedBy property of the Entity Treatment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Treatment"."PerformedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 80<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String PerformedBy
		{
			get { return (System.String)GetValue((int)TreatmentFieldIndex.PerformedBy, true); }
			set	{ SetValue((int)TreatmentFieldIndex.PerformedBy, value, true); }
		}

		/// <summary> The EnergizedImageSetId property of the Entity Treatment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Treatment"."EnergizedImageSetId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 EnergizedImageSetId
		{
			get { return (System.Int64)GetValue((int)TreatmentFieldIndex.EnergizedImageSetId, true); }
			set	{ SetValue((int)TreatmentFieldIndex.EnergizedImageSetId, value, true); }
		}

		/// <summary> The FingerImageSetId property of the Entity Treatment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Treatment"."FingerImageSetId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> FingerImageSetId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TreatmentFieldIndex.FingerImageSetId, false); }
			set	{ SetValue((int)TreatmentFieldIndex.FingerImageSetId, value, true); }
		}

		/// <summary> The SoftwareVersion property of the Entity Treatment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Treatment"."SoftwareVersion"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String SoftwareVersion
		{
			get { return (System.String)GetValue((int)TreatmentFieldIndex.SoftwareVersion, true); }
			set	{ SetValue((int)TreatmentFieldIndex.SoftwareVersion, value, true); }
		}

		/// <summary> The FirmwareVersion property of the Entity Treatment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Treatment"."FirmwareVersion"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String FirmwareVersion
		{
			get { return (System.String)GetValue((int)TreatmentFieldIndex.FirmwareVersion, true); }
			set	{ SetValue((int)TreatmentFieldIndex.FirmwareVersion, value, true); }
		}

		/// <summary> The AnalysisTime property of the Entity Treatment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Treatment"."AnalysisTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime AnalysisTime
		{
			get { return (System.DateTime)GetValue((int)TreatmentFieldIndex.AnalysisTime, true); }
			set	{ SetValue((int)TreatmentFieldIndex.AnalysisTime, value, true); }
		}

		/// <summary> The ReceivedTime property of the Entity Treatment<br/><br/></summary>
		/// <remarks>Mapped on  table field: "Treatment"."ReceivedTime"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime ReceivedTime
		{
			get { return (System.DateTime)GetValue((int)TreatmentFieldIndex.ReceivedTime, true); }
			set	{ SetValue((int)TreatmentFieldIndex.ReceivedTime, value, true); }
		}

		/// <summary> Retrieves all related entities of type 'AnalysisResultEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiAnalysisResults()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.AnalysisResultCollection AnalysisResults
		{
			get	{ return GetMultiAnalysisResults(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for AnalysisResults. When set to true, AnalysisResults is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time AnalysisResults is accessed. You can always execute/ a forced fetch by calling GetMultiAnalysisResults(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchAnalysisResults
		{
			get	{ return _alwaysFetchAnalysisResults; }
			set	{ _alwaysFetchAnalysisResults = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property AnalysisResults already has been fetched. Setting this property to false when AnalysisResults has been fetched
		/// will clear the AnalysisResults collection well. Setting this property to true while AnalysisResults hasn't been fetched disables lazy loading for AnalysisResults</summary>
		[Browsable(false)]
		public bool AlreadyFetchedAnalysisResults
		{
			get { return _alreadyFetchedAnalysisResults;}
			set 
			{
				if(_alreadyFetchedAnalysisResults && !value && (_analysisResults != null))
				{
					_analysisResults.Clear();
				}
				_alreadyFetchedAnalysisResults = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'CalculationDebugDataEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiCalculationDebugDatas()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.CalculationDebugDataCollection CalculationDebugDatas
		{
			get	{ return GetMultiCalculationDebugDatas(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for CalculationDebugDatas. When set to true, CalculationDebugDatas is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time CalculationDebugDatas is accessed. You can always execute/ a forced fetch by calling GetMultiCalculationDebugDatas(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchCalculationDebugDatas
		{
			get	{ return _alwaysFetchCalculationDebugDatas; }
			set	{ _alwaysFetchCalculationDebugDatas = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property CalculationDebugDatas already has been fetched. Setting this property to false when CalculationDebugDatas has been fetched
		/// will clear the CalculationDebugDatas collection well. Setting this property to true while CalculationDebugDatas hasn't been fetched disables lazy loading for CalculationDebugDatas</summary>
		[Browsable(false)]
		public bool AlreadyFetchedCalculationDebugDatas
		{
			get { return _alreadyFetchedCalculationDebugDatas;}
			set 
			{
				if(_alreadyFetchedCalculationDebugDatas && !value && (_calculationDebugDatas != null))
				{
					_calculationDebugDatas.Clear();
				}
				_alreadyFetchedCalculationDebugDatas = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'NBAnalysisResultEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiNBAnalysisResults()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.NBAnalysisResultCollection NBAnalysisResults
		{
			get	{ return GetMultiNBAnalysisResults(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for NBAnalysisResults. When set to true, NBAnalysisResults is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time NBAnalysisResults is accessed. You can always execute/ a forced fetch by calling GetMultiNBAnalysisResults(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchNBAnalysisResults
		{
			get	{ return _alwaysFetchNBAnalysisResults; }
			set	{ _alwaysFetchNBAnalysisResults = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property NBAnalysisResults already has been fetched. Setting this property to false when NBAnalysisResults has been fetched
		/// will clear the NBAnalysisResults collection well. Setting this property to true while NBAnalysisResults hasn't been fetched disables lazy loading for NBAnalysisResults</summary>
		[Browsable(false)]
		public bool AlreadyFetchedNBAnalysisResults
		{
			get { return _alreadyFetchedNBAnalysisResults;}
			set 
			{
				if(_alreadyFetchedNBAnalysisResults && !value && (_nBAnalysisResults != null))
				{
					_nBAnalysisResults.Clear();
				}
				_alreadyFetchedNBAnalysisResults = value;
			}
		}
		/// <summary> Retrieves all related entities of type 'SeverityEntity' using a relation of type '1:n'.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for databinding conveniance, however it is recommeded to use the method 'GetMultiSeverities()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the same scope.</remarks>
		public virtual EPICCentralDL.CollectionClasses.SeverityCollection Severities
		{
			get	{ return GetMultiSeverities(false); }
		}

		/// <summary> Gets / sets the lazy loading flag for Severities. When set to true, Severities is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Severities is accessed. You can always execute/ a forced fetch by calling GetMultiSeverities(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchSeverities
		{
			get	{ return _alwaysFetchSeverities; }
			set	{ _alwaysFetchSeverities = value; }	
		}		
				
		/// <summary>Gets / Sets the lazy loading flag if the property Severities already has been fetched. Setting this property to false when Severities has been fetched
		/// will clear the Severities collection well. Setting this property to true while Severities hasn't been fetched disables lazy loading for Severities</summary>
		[Browsable(false)]
		public bool AlreadyFetchedSeverities
		{
			get { return _alreadyFetchedSeverities;}
			set 
			{
				if(_alreadyFetchedSeverities && !value && (_severities != null))
				{
					_severities.Clear();
				}
				_alreadyFetchedSeverities = value;
			}
		}

		/// <summary> Gets / sets related entity of type 'CalibrationEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleCalibration()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual CalibrationEntity Calibration
		{
			get	{ return GetSingleCalibration(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncCalibration(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "Treatments", "Calibration", _calibration, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Calibration. When set to true, Calibration is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Calibration is accessed. You can always execute a forced fetch by calling GetSingleCalibration(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchCalibration
		{
			get	{ return _alwaysFetchCalibration; }
			set	{ _alwaysFetchCalibration = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property Calibration already has been fetched. Setting this property to false when Calibration has been fetched
		/// will set Calibration to null as well. Setting this property to true while Calibration hasn't been fetched disables lazy loading for Calibration</summary>
		[Browsable(false)]
		public bool AlreadyFetchedCalibration
		{
			get { return _alreadyFetchedCalibration;}
			set 
			{
				if(_alreadyFetchedCalibration && !value)
				{
					this.Calibration = null;
				}
				_alreadyFetchedCalibration = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Calibration is not found
		/// in the database. When set to true, Calibration will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: false.</summary>
		[Browsable(false)]
		public bool CalibrationReturnsNewIfNotFound
		{
			get	{ return _calibrationReturnsNewIfNotFound; }
			set { _calibrationReturnsNewIfNotFound = value; }	
		}

		/// <summary> Gets / sets related entity of type 'ImageSetEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleImageSet()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual ImageSetEntity ImageSet
		{
			get	{ return GetSingleImageSet(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncImageSet(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "Treatments", "ImageSet", _imageSet, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for ImageSet. When set to true, ImageSet is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time ImageSet is accessed. You can always execute a forced fetch by calling GetSingleImageSet(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchImageSet
		{
			get	{ return _alwaysFetchImageSet; }
			set	{ _alwaysFetchImageSet = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property ImageSet already has been fetched. Setting this property to false when ImageSet has been fetched
		/// will set ImageSet to null as well. Setting this property to true while ImageSet hasn't been fetched disables lazy loading for ImageSet</summary>
		[Browsable(false)]
		public bool AlreadyFetchedImageSet
		{
			get { return _alreadyFetchedImageSet;}
			set 
			{
				if(_alreadyFetchedImageSet && !value)
				{
					this.ImageSet = null;
				}
				_alreadyFetchedImageSet = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property ImageSet is not found
		/// in the database. When set to true, ImageSet will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: false.</summary>
		[Browsable(false)]
		public bool ImageSetReturnsNewIfNotFound
		{
			get	{ return _imageSetReturnsNewIfNotFound; }
			set { _imageSetReturnsNewIfNotFound = value; }	
		}

		/// <summary> Gets / sets related entity of type 'ImageSetEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSingleImageSet_()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual ImageSetEntity ImageSet_
		{
			get	{ return GetSingleImageSet_(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncImageSet_(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "Treatments_", "ImageSet_", _imageSet_, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for ImageSet_. When set to true, ImageSet_ is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time ImageSet_ is accessed. You can always execute a forced fetch by calling GetSingleImageSet_(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchImageSet_
		{
			get	{ return _alwaysFetchImageSet_; }
			set	{ _alwaysFetchImageSet_ = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property ImageSet_ already has been fetched. Setting this property to false when ImageSet_ has been fetched
		/// will set ImageSet_ to null as well. Setting this property to true while ImageSet_ hasn't been fetched disables lazy loading for ImageSet_</summary>
		[Browsable(false)]
		public bool AlreadyFetchedImageSet_
		{
			get { return _alreadyFetchedImageSet_;}
			set 
			{
				if(_alreadyFetchedImageSet_ && !value)
				{
					this.ImageSet_ = null;
				}
				_alreadyFetchedImageSet_ = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property ImageSet_ is not found
		/// in the database. When set to true, ImageSet_ will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: false.</summary>
		[Browsable(false)]
		public bool ImageSet_ReturnsNewIfNotFound
		{
			get	{ return _imageSet_ReturnsNewIfNotFound; }
			set { _imageSet_ReturnsNewIfNotFound = value; }	
		}

		/// <summary> Gets / sets related entity of type 'PatientEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/>
		/// </summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSinglePatient()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual PatientEntity Patient
		{
			get	{ return GetSinglePatient(false); }
			set 
			{ 
				if(this.IsDeserializing)
				{
					SetupSyncPatient(value);
				}
				else
				{
					SetSingleRelatedEntityNavigator(value, "Treatments", "Patient", _patient, true); 
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for Patient. When set to true, Patient is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time Patient is accessed. You can always execute a forced fetch by calling GetSinglePatient(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchPatient
		{
			get	{ return _alwaysFetchPatient; }
			set	{ _alwaysFetchPatient = value; }	
		}
				
		/// <summary>Gets / Sets the lazy loading flag if the property Patient already has been fetched. Setting this property to false when Patient has been fetched
		/// will set Patient to null as well. Setting this property to true while Patient hasn't been fetched disables lazy loading for Patient</summary>
		[Browsable(false)]
		public bool AlreadyFetchedPatient
		{
			get { return _alreadyFetchedPatient;}
			set 
			{
				if(_alreadyFetchedPatient && !value)
				{
					this.Patient = null;
				}
				_alreadyFetchedPatient = value;
			}
		}

		/// <summary> Gets / sets the flag for what to do if the related entity available through the property Patient is not found
		/// in the database. When set to true, Patient will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: false.</summary>
		[Browsable(false)]
		public bool PatientReturnsNewIfNotFound
		{
			get	{ return _patientReturnsNewIfNotFound; }
			set { _patientReturnsNewIfNotFound = value; }	
		}

		/// <summary> Gets / sets related entity of type 'PatientPrescanQuestionEntity'. This property is not visible in databound grids.
		/// Setting this property to a new object will make the load-on-demand feature to stop fetching data from the database, until you set this
		/// property to null. Setting this property to an entity will make sure that FK-PK relations are synchronized when appropriate.<br/><br/></summary>
		/// <remarks>This property is added for conveniance, however it is recommeded to use the method 'GetSinglePatientPrescanQuestion()', because 
		/// this property is rather expensive and a method tells the user to cache the result when it has to be used more than once in the
		/// same scope. The property is marked non-browsable to make it hidden in bound controls, f.e. datagrids.</remarks>
		[Browsable(false)]
		public virtual PatientPrescanQuestionEntity PatientPrescanQuestion
		{
			get	{ return GetSinglePatientPrescanQuestion(false); }
			set
			{
				if(this.IsDeserializing)
				{
					SetupSyncPatientPrescanQuestion(value);
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_patientPrescanQuestion !=null);
						DesetupSyncPatientPrescanQuestion(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("PatientPrescanQuestion");
						}
					}
					else
					{
						if(_patientPrescanQuestion!=value)
						{
							((IEntity)value).SetRelatedEntity(this, "Treatment");
							SetupSyncPatientPrescanQuestion(value);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets the lazy loading flag for PatientPrescanQuestion. When set to true, PatientPrescanQuestion is always refetched from the 
		/// persistent storage. When set to false, the data is only fetched the first time PatientPrescanQuestion is accessed. You can always execute a forced fetch by calling GetSinglePatientPrescanQuestion(true).</summary>
		[Browsable(false)]
		public bool AlwaysFetchPatientPrescanQuestion
		{
			get	{ return _alwaysFetchPatientPrescanQuestion; }
			set	{ _alwaysFetchPatientPrescanQuestion = value; }	
		}
		
		/// <summary>Gets / Sets the lazy loading flag if the property PatientPrescanQuestion already has been fetched. Setting this property to false when PatientPrescanQuestion has been fetched
		/// will set PatientPrescanQuestion to null as well. Setting this property to true while PatientPrescanQuestion hasn't been fetched disables lazy loading for PatientPrescanQuestion</summary>
		[Browsable(false)]
		public bool AlreadyFetchedPatientPrescanQuestion
		{
			get { return _alreadyFetchedPatientPrescanQuestion;}
			set 
			{
				if(_alreadyFetchedPatientPrescanQuestion && !value)
				{
					this.PatientPrescanQuestion = null;
				}
				_alreadyFetchedPatientPrescanQuestion = value;
			}
		}
		
		/// <summary> Gets / sets the flag for what to do if the related entity available through the property PatientPrescanQuestion is not found
		/// in the database. When set to true, PatientPrescanQuestion will return a new entity instance if the related entity is not found, otherwise 
		/// null be returned if the related entity is not found. Default: false.</summary>
		[Browsable(false)]
		public bool PatientPrescanQuestionReturnsNewIfNotFound
		{
			get	{ return _patientPrescanQuestionReturnsNewIfNotFound; }
			set	{ _patientPrescanQuestionReturnsNewIfNotFound = value; }	
		}

		/// <summary> Gets or sets a value indicating whether this entity is a subtype</summary>
		protected override bool LLBLGenProIsSubType
		{
			get { return false;}
		}

		/// <summary> Gets the type of the hierarchy this entity is in. </summary>
		[System.ComponentModel.Browsable(false), XmlIgnore]
		protected override InheritanceHierarchyType LLBLGenProIsInHierarchyOfType
		{
			get { return InheritanceHierarchyType.None;}
		}
		
		/// <summary>Returns the EPICCentralDL.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		protected override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)EPICCentralDL.EntityType.TreatmentEntity; }
		}

		#endregion


		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included code

		#endregion
	}
}
