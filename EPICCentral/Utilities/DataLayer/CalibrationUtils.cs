using System;
using EPICCentralDL.CollectionClasses;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentral.Utilities.DataLayer
{
	public static class CalibrationUtils
	{
		public static CalibrationEntity GetByUid(string calibrationUid)
		{
			CalibrationCollection calibrations = new CalibrationCollection();
			calibrations.GetMulti(new PredicateExpression(CalibrationFields.UniqueIdentifier == calibrationUid));
			return calibrations.Count > 0 ? calibrations[0] : null;
		}

		public static long Create(int deviceId, string calibrationUid, DateTime calibrationTime, string performedBy, long imageSetId)
		{
			CalibrationEntity calibrationEntity = new CalibrationEntity
													{
														DeviceId = deviceId,
														UniqueIdentifier = calibrationUid,
														CalibrationTime = calibrationTime,
														PerformedBy = performedBy,
														ImageSetId = imageSetId
													};
			calibrationEntity.Save();

			return calibrationEntity.CalibrationId;
		}
	}
}