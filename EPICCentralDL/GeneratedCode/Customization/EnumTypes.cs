using System.ComponentModel.DataAnnotations;

namespace EPICCentralDL.Customization
{
	/// <summary>
	/// Enumeration of the types of organizations that can be configured.
	/// </summary>
	public enum OrganizationType
	{
		// The integer values of this enum are stored in the database. So they must never
		// be changed unless all existing records in the database are updated to match the
		// new enum values.
        [Display(ResourceType = typeof(Language), Name = "OrganizationType_Host")]
        Host = 1,
        [Display(ResourceType = typeof(Language), Name = "OrganizationType_EndUser")]
        EndUser = 2
	}

	public enum LicenseMode
	{
		// The integer values of this enum are stored in the database. So they must never
		// be changed unless all existing records in the database are updated to match the
		// new enum values.
		Cardiovascular = 1,
		Full = 2
	}

	public enum AccountRestrictionType
	{
		// The integer values of this enum are stored in the database. So they must never
		// be changed unless all existing records in the database are updated to match the
		// new enum values.
		NewUser = 1,
		PasswordReset = 2,
		LostUsername = 3
	}

	/// <summary>
	/// Enumeration of the states a device can have during its lifetime.
	/// </summary>
	public enum DeviceState
	{
		// The integer values of this enum are stored in the database. So they must never
		// be changed unless all existing records in the database are updated to match the
		// new enum values.
		New = 1,
		Active = 2,
		Transitioning = 3,
		Locked = 4,
		Retired = 5
	}

	/// <summary>
	/// Enumeration of the types of events that can be tracked.
	/// </summary>
	public enum EventType
	{
		// The integer values of this enum are stored in the database. So they must never
		// be changed unless all existing records in the database are updated to match the
		// new enum values.
		Ping = 1,
		ScanBegin = 2,
		ScanEnd = 3,
		CalibrationBegin = 4,
		CalibrationEnd = 5,
		ApplicationBegin = 6,
		ApplicationEnd = 7
	}

	/// <summary>
	/// Enumeration of the types of messages that can be sent to a device.
	/// </summary>
	public enum MessageType
	{
		// The integer values of this enum are stored in the database. So they must never
		// be changed unless all existing records in the database are updated to match the
		// new enum values.
        [Display(ResourceType = typeof(Language), Name = "MessageType_Information")]
        Information = 1,
        [Display(ResourceType = typeof(Language), Name = "MessageType_Marketing")]
        Marketing = 2,
        [Display(ResourceType = typeof(Language), Name = "MessageType_Sale")]
        Sale = 3,
        [Display(ResourceType = typeof(Language), Name = "MessageType_Attention")]
        Attention = 4
	}

	/// <summary>
	/// Enumeration of the types of scans that can be performed.
	/// </summary>
	public enum ScanType
	{
		// The integer values of this enum are stored in the database. So they must never
		// be changed unless all existing records in the database are updated to match the
		// new enum values.
        [Display(ResourceType = typeof(Language), Name = "ScanType_ClearViewScan")]
        ClearViewScan = 1,
	}

    /// <summary>
    /// Enumeration of the types of treatments that are uploaded from ClearView.
    /// </summary>
    public enum TreatmentType
    {
        // The integer values of this enum are stored in the database. So they must never
        // be changed unless all existing records in the database are updated to match the
        // new enum values.
        [Display(ResourceType = typeof(Language), Name = "TreatmentType_Unknown")]
        Unknown = 0,
        [Display(ResourceType = typeof(Language), Name = "TreatmentType_ClearViewScan")]
        ClearViewScan = 1,
        [Display(ResourceType = typeof(Language), Name = "TreatmentType_FollowUp")]
        FollowUp = 2,
    }

	/// <summary>
	/// Enumeration of possible gender settings.
	/// </summary>
	public enum Gender
	{
		// The integer values of this enum are stored in the database. So they must never
		// be changed unless all existing records in the database are updated to match the
		// new enum values.
		NotSelected = 0,
		Female = 1,
		Male = 2
	}

	// ReSharper disable InconsistentNaming
	//public enum NBAnalysisGroup
	// ReSharper restore InconsistentNaming
	//{
		// The integer values of this enum are stored in the database. So they must never
		// be changed unless all existing records in the database are updated to match the
		// new enum values.
	//	Cardiovascular = 1,
	//	Respiratory = 2,
	//	Hepatic = 3,
	//	Gastrointestinal = 4,
	//	Renal = 5
	//}

    public enum OrganSystem
    {
        // The integer values of this enum are stored in the database. So they must never
        // be changed unless all existing records in the database are updated to match the
        // new enum values.
        Cardiovascular = 4,
        Respiratory = 5,
        Hepatic = 2,
        Gastrointestinal = 1,
        Renal = 6
    }

    /// <summary>
    /// Enumeration that defines the different types of organ compoents available in the solution.
    /// </summary>
    /// <remarks>
    /// Organs apply to different sectors on different fingers of a scan.  This enumeration
    /// is used when instanciating a sector and when calculating the final values after image
    /// processing and analysis.
    /// </remarks>
    public enum OrganComponent
    {
		// The integer values of this enum are stored in the database. So they must never
		// be changed unless all existing records in the database are updated to match the
		// new enum values.
		NotSet = 0,
        //0 - 9  Cardiovascular
        Heart,
        LeftCardiovascularSystem,
        LeftCoronaryVessels,
        LeftHeart,
        LeftThroatLarynxTracheaThyroid,
        RightCardiovascularSystem,
        RightCoronaryVessels,
        RightHeart,
        RightThroatLarynxTracheaThyroid,
        // 10 - 15 Respiratory 
        LeftLEarNoseMaxillarySinus,
        LeftRespiratoryMammary,
        LeftThoraxRespiratory,
        RightREarNoseMaxillarySinus,
        RightRespiratoryMammary,
        RightThoraxZoneRespiratory,
        // 16 - 21 Gastro Large
        ColonAscending,
        ColonDescending,
        ColonSigmoid,
        LeftColonTransverse,
        Rectum,
        RightColonTransverse,
        // 22 - 26 Stomach/Sm Int
        AbdominalZone,
        BlindGut,
        Duodenum,
        Ileum,
        Jejunum,
        //27 - 31 Immune
        Appendix,
        LeftImmuneSystem,
        LeftSpleen,
        RightImmuneSystem,
        RightSpleen,
        //32 - 39 Renal/Reproductive
        LeftAdrenal,
        LeftKidney,
        LeftUrogenital,
        RightAdrenal,
        RightKidney,
        RightUrogenital,
        UroKidneyLeft,
        UroKidneyRight,
        // 40 - 56 Endocrine
        Gallbladder,
        LeftCerebralCortexZone,
        LeftCerebralVessels,
        LeftHypothalamus,
        LeftLiver,
        LeftPancreas,
        LeftPinealEpiphysis,
        LeftPituitaryHypophysis,
        LeftThyroid,
        RightCerebralCortexZone,
        RightCerebralVessels,
        RightHypothalamus,
        RightLiver,
        RightPancreas,
        RightPinealEpiphysis,
        RightPituitaryHypophysis,
        RightThyroid,
        // 57 -   Skeletal
        LeftCervicalSpine,
        LeftCoccyxPelvis,
        LeftLSideEye,
        LeftLJawTeeth,
        LeftLumbarSpine,
        LeftNervousSystem,
        LeftSacrum,
        LeftThorax,
        RightCervicalSpine,
        RightCoccyxPelvis,
        RightRSideEye,
        RightRJawTeeth,
        RightLumbarSpine,
        RightNervousSystem,
        RightSacrum,
        RightThorax,
        LeftREarNoseMaxillarySinus,
        RightLEarNoseMaxillarySinus,
        RightLJawTeeth,
        LeftRJawTeeth,
        RightLSideEye,
        LeftRSideEye
    };

}
