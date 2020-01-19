using EPICCentralDL.CollectionClasses;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentral.Utilities.DataLayer
{
	public static class TreatmentUtils
	{
		public static TreatmentEntity GetByUid(string treatmentUid)
		{
			TreatmentCollection treatments = new TreatmentCollection();
			treatments.GetMulti(new PredicateExpression(TreatmentFields.UniqueIdentifier == treatmentUid));
			return treatments.Count > 0 ? treatments[0] : null;
		}
	}
}