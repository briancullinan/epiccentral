using System;

namespace EPICCentralLibrary
{
    public class GlobalSettings
    {
        public const string DEFAULT_BASE_SITE_URL = "epicdiagnostics.com";
        public const string VERSION_NUMBER = "0.9.5 (Beta)";
        public const Boolean ACTIVE_FLAG = true;
        public const Boolean INACTIVE_FLAG = false;
        public const Int16 INACTIVE = 0;
        public const Int16 ACTIVE = 1;
        public const string ZERO_INT_STRING = "0";
        public const string ZERO_DOLLAR_STRING = "0.00";
        public const Int32 LOCATION_ID = 1;
        public const Int32 SYSTEM_DAEMON_USER_ID = 1;
        public const string SUPERUSER_NAME = "EPICAdmin";
        public const string MESSAGE_DISPLAY_SESSION_TAG = "DisplayMessage";
        public const string MESSAGE_DISPLAY_TYPE = "DisplayMessageType";
        public const Int32 MAX_KEYGEN_ATTEMPTS = 40;
        public const Int32 MAX_TTL_WS_TOKEN_SECONDS = 120;

        public static class Emails
        {
            public const string DEFAULT_FROM_ADDRESS = "host@" + DEFAULT_BASE_SITE_URL;
            public const string DEFAULT_DEFAULT_FROM_NAME = "EPIC Host";
            public const string DEFAULT_EMAIL_BODY_TYPE = "H"; //HTML not text
        }

		public static class ConfigFileVales
		{
			public static String MAPS_API_KEY = "GoogleMapsApiKey";
		}

		public static class UpdateStatusTypes
		{
			public static int EPIC_OPS_UPDATE = 1;
		}

		public static class ActivityTypes
		{
			public static Int16 DEVICE_PING = 0;
			public static Int16 NEW_PURCHASE = 1;
			public static Int16 NEW_SCAN = 2;
			public static Int16 NEW_EXCEPTION = 3;
			public static Int16 NEW_SUPPORT_REQUEST = 4;
		}
	}

}
