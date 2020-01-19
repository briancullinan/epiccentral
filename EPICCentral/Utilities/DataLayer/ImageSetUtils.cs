using EPICCentralDL.CollectionClasses;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentral.Utilities.DataLayer
{
	public static class ImageSetUtils
	{
		public static ImageSetEntity GetByUid(string imageSetUid)
		{
			ImageSetCollection imageSets = new ImageSetCollection();
			imageSets.GetMulti(new PredicateExpression(ImageSetFields.UniqueIdentifier == imageSetUid));
			return imageSets.Count > 0 ? imageSets[0] : null;
		}

		public static long Create(string imageSetUid, byte[] images)
		{
			ImageSetEntity imageSet = new ImageSetEntity { UniqueIdentifier = imageSetUid, Images = images };
			imageSet.Save();

			return imageSet.ImageSetId;
		}
	}
}