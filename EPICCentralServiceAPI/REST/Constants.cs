using System;
using System.Runtime.Serialization;
using EPICCentralServiceAPI.REST;
using EPICCentralServiceAPI.REST.Objects;

[assembly: ContractNamespace(Constants.OBJECT_NAMESPACE, ClrNamespace = "EPICCentralServiceAPI.REST.Objects")]

namespace EPICCentralServiceAPI.REST
{
	public class Constants
	{
		public const string OBJECT_NAMESPACE = "http://epiccentral.com/REST/v0100/objects";

		public class StatusSubcode
		{
            public const string UNAUTHORIZED = "(401) Unauthorized";
            public const string DEVICE_AUTH_REQUIRED = "(401) Device authentication required";
			public const string USER_AUTH_REQUIRED = "(402) Basic user authentication required";
			public const string LOCATION_NOT_FOUND = "(405) Location not found";
			public const string DEVICE_NOT_FOUND = "(406) Device not found";
			public const string PATIENT_NOT_FOUND = "(407) Patient not found";
			public const string CALIBRATION_NOT_FOUND = "(408) Calibration not found";
			public const string IMAGE_SET_NOT_FOUND = "(409) Image set not found";
			public const string ORGANIZATION_INVALID = "(410) Organization invalid";
			public const string LOCATION_INVALID = "(411) Location invalid";
			public const string DEVICE_INVALID = "(412) Device invalid";
			public const string TREATMENT_INVALID = "(414) Treatment invalid";
			public const string CALIBRATION_INVALID = "(415) Calibration invalid";
			public const string IMAGE_SET_INVALID = "(416) Image set invalid";
			public const string DEVICE_STATE_INVALID = "(420) Device state invalid";
			public const string DEVICE_HAS_NO_SCANS = "(421) Device has no scans";
			public const string GUID_INVALID = "(430) GUID invalid";
			public const string CHECKSUM_INVALID = "(431) Checksum invalid";
			public const string INTERNAL_DATABASE_ERROR = "(501) Internal database error";
			public const string INTERNAL_IO_ERROR = "(502) Internal I/O error";
			public const string INTERNAL_TRANSACTION_ERROR = "(503) Internal transaction error";
		}
	}
}
