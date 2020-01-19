using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using EPICCentralDL;
using EPICCentralDL.CollectionClasses;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using EPICCentralDL.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace EPICCentral.Utilities.Treatment
{
    public class ImageRetrievalHelper
    {
        /// <summary>
        /// A helper method that will extract images from the 
        /// database and return a list of ImageObjectData 
        /// objects.
        /// </summary>
        /// <param name="CalibrationIdVar">The calibration Id to extract images from</param>
        /// <returns>A list of ImageObjectData objects</returns>
        public static List<ImageCompressionUtility.ImageObjectData> GetCalibrationImageSet(Int64 CalibrationIdVar)
        {
            try
            {
                // Get the data
                var imageEntity = new LinqMetaData().Calibration.First(x => x.CalibrationId == CalibrationIdVar).ImageSet;
                // Uncompress images
                return ImageCompressionUtility.UnzipByteArray(imageEntity.Images);
            }
            catch (Exception ex)
            {
                throw (new Exception("Unable to locate calibration images", ex));
            }
        }

        /// <summary>
        /// A helper method that will extract images from the 
        /// database and return a list of ImageObjectData 
        /// objects.
        /// </summary>
        /// <param name="PatientImageIdVar">The patient image id to extract images for</param>
        /// <returns>A list of ImageObjectData objects</returns>
        public static List<ImageCompressionUtility.ImageObjectData> GetPatientImages(Int64 PatientImageIdVar)
        {
            try
            {
                ImageSetEntity imageEntity = new ImageSetEntity(PatientImageIdVar);
                List<ImageCompressionUtility.ImageObjectData> ImagesVar =
                    ImageCompressionUtility.UnzipByteArray(imageEntity.Images);
                return ImagesVar;
            }
            catch (Exception ex)
            {
                throw (new Exception("Unable to locate calibration images", ex));
            }
        }
    }
}