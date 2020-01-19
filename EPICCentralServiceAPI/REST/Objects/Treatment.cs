using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EPICCentralServiceAPI.REST.Objects
{
	/// <summary>
	/// <para>
	/// A treatment is the record of a scan session and the analysis of the images.
	/// This class encapsulates all the primary information for a scan session.
	/// This includes the results of the analysis algorithms and the images.
	/// The images are only referenced by GUIDs; the image sets need to be present
	/// in the central database prior to creating a treatment record.
	/// </para><para>
	/// <seealso cref="ImageSetBlob"/>: definition of an image set</para>
	/// </summary>
	public class Treatment
	{
		/// <summary>
		/// Construct a default instance.
		/// The <see cref="NBAnalysisResults"/>, <see cref="AnalysisResults"/> and
		/// <see cref="Severities"/> collections are initialized to empty collections.
		/// </summary>
		public Treatment()
		{
			NBAnalysisResults = new NBAnalysisResults();
			AnalysisResults = new AnalysisResults();
			Severities = new Severities();
			CalculationDebugs = new CalculationDebugs();
		}

		/// <summary>
		/// The ID of the treatment on the server.
		/// This ID is assigned by the database when the treatment record is created.
		/// When creating a <c>Treatment</c> instance, the client should leave this set
		/// to the default value.
		/// </summary>
		public long TreatmentId { get; set; }

		/// <summary>
		/// The unique ID of the treatment assigned by the client.
		/// The GUID must be unique across the entire global system.
		/// </summary>
		public string Guid { get; set; }

		/// <summary>
		/// The unique ID of the patient to whom this treatment is associated.
		/// This GUID is assigned by the client when a patient record is created.
		/// It must be unique across the entire global system.
		/// </summary>
		public string PatientGuid { get; set; }

		/// <summary>
		/// The unique ID of the last calibration performed on the device.
		/// This GUID is assigned by the client when the calibration record is created.
		/// It must be unique across the entire global system.
		/// </summary>
		public string CalibrationGuid { get; set; }

		/// <summary>
		/// The type of the treatment.
		/// </summary>
		public short TreatmentType { get; set; }

		/// <summary>
		/// The time when the treatment (scan) was performed.
		/// </summary>
		public DateTime TreatmentTime { get; set; }

		/// <summary>
		/// The username of the user that performed the treatment.
		/// This is a user on the client, not the server.
		/// </summary>
		public string PerformedBy { get; set; }

		/// <summary>
		/// The unique ID of the energized image set for the treatment.
		/// This GUID is assigned by the client when the image set is created.
		/// It must be unique across the entire global system.
		/// </summary>
		public string EnergizedImageSetGuid { get; set; }

		/// <summary>
		/// The unique ID of the finger image set for the treatment.
		/// This GUID is assigned by the client when the image set is created.
		/// It must be unique across the entire global system.
		/// </summary>
		public string FingerImageSetGuid { get; set; }

		/// <summary>
		/// The current version of the software running on the client.
		/// </summary>
		public string SoftwareVersion { get; set; }

		/// <summary>
		/// The current version of the firmware running on the device.
		/// </summary>
		public string FirmwareVersion { get; set; }

		/// <summary>
		/// The time when the image analysis was performed on the client.
		/// </summary>
		public DateTime AnalysisTime { get; set; }

		/// <summary>
		/// The collection of summary analysis results from the image analysis
		/// performed by the client.
		/// </summary>
		public NBAnalysisResults NBAnalysisResults { get; set; }

		/// <summary>
		/// The collection of raw analysis results from the image analysis
		/// performed by the client.
		/// </summary>
		public AnalysisResults AnalysisResults { get; set; }

		/// <summary>
		/// The collection of severities resulting from the image analysis
		/// performed by the client.
		/// </summary>
		public Severities Severities { get; set; }

		/// <summary>
		/// The collection of calculation debugs resulting from the image analysis
		/// performed by the client.
		/// </summary>
		public CalculationDebugs CalculationDebugs { get; set; }

        /// <summary>
        /// Answer to the alcohol question
        /// </summary>
        public bool AlcoholQuestion { get; set; }

        /// <summary>
        /// Answer to the wheat question
        /// </summary>
        public bool WheatQuestion { get; set; }

        /// <summary>
        /// Answer to the caffeine question
        /// </summary>
        public bool CaffeineQuestion { get; set; }
    }

	/// <summary>
	/// Collection of <see cref="Treatment"/> instances.
	/// </summary>
	[CollectionDataContract]
	public class Treatments : List<Treatment>
	{
		/// <summary>
		/// Construct an instance which is initially empty.
		/// </summary>
		public Treatments()
		{ }

		/// <summary>
		/// Construct an instance initialized to contain the specified collection of
		/// <see cref="Treatment"/> instances.
		/// </summary>
		/// <param name="treatments">collection of <see cref="Treatment"/> instances to
		///		initialize the new instance</param>
		public Treatments(IEnumerable<Treatment> treatments)
			: base(treatments)
		{ }
	}

	public class NBAnalysisResult
	{
		public NBAnalysisGroup NBAnalysisGroup { get; set; }
		public decimal ResultScoreFiltered { get; set; }
		public decimal ResultScoreUnfiltered { get; set; }
		public decimal ProbabilityFiltered { get; set; }
		public decimal ProbabilityUnfiltered { get; set; }
	}

	[CollectionDataContract]
	public class NBAnalysisResults : List<NBAnalysisResult>
	{
		public NBAnalysisResults()
		{ }

		public NBAnalysisResults(IEnumerable<NBAnalysisResult> results)
			: base(results)
		{ }
	}

	public enum NBAnalysisGroup
	{
		// The integer values of this enum are stored in the database. So they must never
		// be changed unless all existing records in the database are updated to match the
		// new enum values.
		Cardiovascular = 1,
		Respiratory = 2,
		Hepatic = 3,
		Gastrointestinal = 4,
		Renal = 5
	}

	public class AnalysisResult
	{
		public DateTime AnalysisTime { get; set; }
		public bool IsFiltered { get; set; }
		public string FingerDescription { get; set; }
		public int FingerType { get; set; }
		public int SectorNumber { get; set; }
		public int StartAngle { get; set; }
		public int EndAngle { get; set; }
		public double SectorArea { get; set; }
		public double IntegralArea { get; set; }
		public double NormalizedArea { get; set; }
		public double AverageIntensity { get; set; }
		public double Entropy { get; set; }
		public double FormCoefficient { get; set; }
		public double FractalCoefficient { get; set; }
		public double JsInteger { get; set; }
		public double CenterX { get; set; }
		public double CenterY { get; set; }
		public double RadiusMin { get; set; }
		public double RadiusMax { get; set; }
		public double AngleOfRotation { get; set; }
		public double Form2 { get; set; }
		public int NoiseLevel { get; set; }
		public double BreakCoefficient { get; set; }
		public string SoftwareVersion { get; set; }
		public double AI1 { get; set; }
		public double AI2 { get; set; }
		public double AI3 { get; set; }
		public double AI4 { get; set; }
		public double Form11 { get; set; }
		public double Form12 { get; set; }
		public double Form13 { get; set; }
		public double Form14 { get; set; }
		public double RingThickness { get; set; }
		public double RingIntensity { get; set; }
		public double Form2Prime { get; set; }
		public string UserName { get; set; }
	}

	[CollectionDataContract]
	public class AnalysisResults : List<AnalysisResult>
	{
		public AnalysisResults()
		{ }

		public AnalysisResults(IEnumerable<AnalysisResult> results)
			: base(results)
		{ }
	}

	public class Severity
	{
		public short OrganId { get; set; }
		public int? PhysicalRight { get; set; }
		public int? PhysicalLeft { get; set; }
		public int? MentalRight { get; set; }
		public int? MentalLeft { get; set; }
	}

	public class Severities : List<Severity>
	{
		public Severities()
		{
		}

		public Severities(IEnumerable<Severity> severities)
				: base(severities)
		{
		}
	}

	public class CalculationDebug
	{
		public string FingerSector { get; set; }
		public bool IsFiltered { get; set; }
		public string OrganComponent { get; set; }
		public decimal Area { get; set; }
		public decimal AverageIntensity { get; set; }
		public decimal BreakCoefficient { get; set; }
		public decimal Entropy { get; set; }
		public decimal NS { get; set; }
		public decimal Fractal { get; set; }
		public decimal Form { get; set; }
		public decimal Form2 { get; set; }
		public decimal AI1 { get; set; }
		public decimal AI2 { get; set; }
		public decimal AI3 { get; set; }
		public decimal AI4 { get; set; }
		public decimal Form11 { get; set; }
		public decimal Form12 { get; set; }
		public decimal Form13 { get; set; }
		public decimal Form14 { get; set; }
		public decimal RingIntensity { get; set; }
		public decimal RingThickness { get; set; }
		public decimal Form2Prime { get; set; }
		public decimal EPICBaseScore { get; set; }
		public decimal EPICBonusScore { get; set; }
		public decimal EPICScore { get; set; }
		public decimal EPICScaledScore { get; set; }
		public int EPICRank { get; set; }
		public int LRRank { get; set; }
		public decimal LRScore { get; set; }
		public decimal LRScaledScore { get; set; }
		public decimal SumZScore { get; set; }
	}

	public class CalculationDebugs : List<CalculationDebug>
	{
		public CalculationDebugs()
		{
		}

		public CalculationDebugs(IEnumerable<CalculationDebug> calculationDebugs)
			: base(calculationDebugs)
		{
		}
	}
}
