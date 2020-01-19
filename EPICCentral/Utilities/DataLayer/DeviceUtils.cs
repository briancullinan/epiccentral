using System;
using System.Data;
using EPICCentral.Utilities.Crypto;
using EPICCentralDL.CollectionClasses;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentral.Utilities.DataLayer
{
	public static class DeviceUtils
	{
		public static string CreateUid()
		{
			string uid;

			do
			{
				uid = string.Format("000030-{0}", Guid.NewGuid());
			} while (GetByUid(uid) != null);

			return uid;
		}

		public static DeviceEntity GetByUid(string deviceUid)
		{
            // check system wide access
		    var system = new SystemSettingEntity("Enabled");
		    bool value;
            // this is pretty fail safe, the setting Enabled must exist and be set to "0" in order for this to pass, otherwise authentication is done at the device level
            if (!system.IsNew && bool.TryParse(system.Value, out value) && value == false)
                return null;
            // NOTE:  device Active is checked at the individual service level because some services like uploading depend on old devices.

			DeviceCollection devices = new DeviceCollection();
			devices.GetMulti(new PredicateExpression(DeviceFields.UniqueIdentifier == deviceUid));
			return devices.Count > 0 ? devices[0] : null;
		}

		public static bool RecordScan(int deviceId, ScanType scanType, DateTime scanStartTime)
		{
			Transaction transaction = new Transaction(IsolationLevel.RepeatableRead, "ScanHistoryUpdate");

			try
			{
				DeviceEntity device = new DeviceEntity();
				transaction.Add(device);
				device.FetchUsingPK(deviceId);

				device.ScansUsed = device.ScansUsed + 1;
				device.ScansAvailable = device.ScansAvailable - 1;

				ScanHistoryEntity history = device.ScanHistories.AddNew();
				history.ScanType = scanType;
				history.ScanStartTime = scanStartTime;

				device.Save(true);		// recurse=true; will also save the history record

				transaction.Commit();

				return true;
			}
			catch (Exception)
			{
				transaction.Rollback();
				return false;
			}
			finally
			{
				transaction.Dispose();
			}
		}

		public static void SetState(DeviceEntity device, DeviceState newState, string reason, bool save = true)
		{
			DeviceStateTrackingEntity tracking = new DeviceStateTrackingEntity
			                                     	{
			                                     			DeviceId = device.DeviceId,
															CurrentState = newState,
															PreviousState = device.DeviceState,
															ChangeReason = reason,
															ChangeTime = DateTime.UtcNow
			                                     	};

			// Not using a transaction; seems like overkill for this.
			device.DeviceState = newState;
			if (save)
				device.Save();

			tracking.Save();
		}

		public static string GetAuthenticationToken(DeviceEntity device, bool save = true)
		{
			string authToken = KeyGen.NextKey(36, 48);

			device.AuthenticationToken = Hash.GetHash(authToken);
			if (save)
				device.Save();

			return authToken;
		}

		public static string GetUidQualifier(DeviceEntity device, bool addSeparator = true)
		{
			return ToHexString(device.UidQualifier, 6) + (addSeparator ? "-" : "");
		}

		private static readonly char[] HexDigitChars = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

		private static string ToHexString(int value, int length)
		{
			if (length > 8)
				length = 8;

			char[] hexChars = new char[length];

			for (int i = hexChars.Length - 1; i >= 0; i--)
			{
				hexChars[i] = HexDigitChars[value & 0xf];
				value = value >> 4;
			}

			return new string(hexChars);
		}
	}
}