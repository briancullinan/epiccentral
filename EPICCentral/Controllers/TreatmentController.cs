using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.SessionState;
using EPICCentral.Models;
using EPICCentral.Utilities.Attributes;
using EPICCentral.Utilities.Filters;
using EPICCentral.Utilities.Membership;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;

namespace EPICCentral.Controllers
{
    /// <summary>
    /// Displays a patient treatment uploaded from ClearView.
    /// </summary>
    public class TreatmentController : DataTablesController
    {
        /// <summary>
        /// Primary treatment page lists all of the treatments with the current users permissions.  Only treatments uploaded from locations that the user has access to can be viewed.
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="patientId"></param>
        /// <param name="dtRequestModel"></param>
        /// <returns></returns>
        [HttpGet]
        [Allow(Users = "*")]
        [ActionMenu(Rank = 800, ResourceName = "PatientTreatments_Treatments")]
        public ActionResult Index(int? locationId, int? patientId, [ModelBinder(typeof(DataTablesRequestModelBinder))] DataTablesRequestModel dtRequestModel)
        {
            IQueryable<TreatmentEntity> treatments;
            if (locationId.HasValue)
            {
                var location = new LocationEntity(locationId.Value);
                if (location.IsNew)
                    throw new HttpException(404, SharedRes.Error.NotFound_Location);

                if (!Permissions.UserHasPermission("View", location))
                    throw new HttpException(401, SharedRes.Error.Unauthorized_Location);

                treatments = new LinqMetaData().Treatment.Where(x => x.Patient.LocationId == locationId.Value);
            }
            else if (patientId.HasValue)
            {
                var patient = new PatientEntity(patientId.Value);
                if (patient.IsNew)
                    throw new HttpException(404, SharedRes.Error.NotFound_Patient);

                if (!Permissions.UserHasPermission("View", patient))
                    throw new HttpException(401, SharedRes.Error.Unauthorized_Patient);

                treatments = new LinqMetaData().Treatment.Where(x => x.PatientId == patientId.Value);
            }
            else
            {
                treatments = new LinqMetaData().Treatment.WithPermissions();
            }


            ViewResult result = View(treatments);

            if (dtRequestModel == null)
                return result;

            return Query(result, dtRequestModel);
        }

        /// <summary>
        /// Shows a user a treatment.  This is similar functionality to ClearView.
        /// </summary>
        /// <param name="treatmentId"></param>
        /// <param name="page"></param>
        /// <param name="model"></param>
        /// <param name="dtRequestModel"></param>
        /// <returns></returns>
        [HttpGet]
        [Allow(Users = "*")]
        public ActionResult View(long treatmentId, Treatment model, [ModelBinder(typeof(DataTablesRequestModelBinder))] DataTablesRequestModel dtRequestModel)
        {
            var treatment = new TreatmentEntity(treatmentId);
            if (treatment.IsNew)
                throw new HttpException(404, SharedRes.Error.NotFound_Treatment);

            // make sure the user has access to this treatment
            if (!Permissions.UserHasPermission("View", treatment))
                throw new HttpException(401, SharedRes.Error.Unauthorized_Treatment);

            // make sure user has access to this page
            if(!RoleUtils.IsUserServiceAdmin() && model.Page != TreatmentPage.Summary && model.Page != TreatmentPage.System &&
                model.Page != TreatmentPage.Definitions)
                throw new HttpException(401, SharedRes.Error.Unauthorized);

            // make sure treatment can be accessed by this user
            model.License = LicenseMode.Full;

            model.Name = treatment.Patient.FirstName + " " + treatment.Patient.MiddleInitial + " " + treatment.Patient.LastName;
            model.DateOfBirth = treatment.Patient.BirthDate;
            model.Gender = treatment.Patient.Gender;
            var age = treatment.TreatmentTime.Year - treatment.Patient.BirthDate.Year;
            if (treatment.TreatmentTime < treatment.Patient.BirthDate.AddYears(age)) age--;
            model.Age = age;
            model.VisitDate = treatment.TreatmentTime;

            // only load data used for each page
            // severities is used on the summary and the raw report page
            if (model.Page == TreatmentPage.Summary || model.Page == TreatmentPage.RawReport)
            {
                model.Severities =
                    new LinqMetaData().OrganSystemOrgan
                    .Where(x => x.LicenseOrganSystem.LicenseMode == model.License)
                    .OrderBy(x => x.ReportOrder)
                    .OrderBy(x => x.LicenseOrganSystem.ReportOrder)
                    .SelectMany(x => x.Organ.Severities.Where(y => y.TreatmentId == treatmentId))
                    .DistinctBy(x => x.Organ.Description.Replace(" - Left", "").Replace(" - Right", ""));
            }

            // organ systems is only used on the summary page
            if (model.Page == TreatmentPage.Summary)
            {
                model.OrganSystems =
                    new LinqMetaData().LicenseOrganSystem.Where(x => x.LicenseMode == model.License).OrderBy(
                        x => x.ReportOrder).Select(x => x.OrganSystem);

                model.PatientPrescanQuestion = treatment.PatientPrescanQuestion;
            }

            // load all analysis results for the raw data page
            if (model.Page == TreatmentPage.Raw || model.Page == TreatmentPage.Summary)
                model.Raw = new LinqMetaData().AnalysisResult.Where(x => x.TreatmentId == model.TreatmentId);

            // load the debug data for the raw report page
            if (model.Page == TreatmentPage.RawReport)
            {
                model.Debug = GetDebugData(new LinqMetaData().CalculationDebugData.Where(x => x.TreatmentId == model.TreatmentId), model.Severities, model.License);

                model.NBScores = new LinqMetaData().NBAnalysisResult.Where(x => x.TreatmentId == model.TreatmentId);
            }

            // only load images for the images page
            if (!Request.IsAjaxRequest() && !ControllerContext.IsChildAction)
            {
                // get database images
                var energizedImages = Utilities.Treatment.ImageRetrievalHelper.GetPatientImages(treatment.EnergizedImageSetId);
                var calibrationImages = Utilities.Treatment.ImageRetrievalHelper.GetCalibrationImageSet(treatment.CalibrationId);

                // save in cache for a few minutes
                var caches = new LinqMetaData().ImageCache.Where(
                    x => x.LookupKey == treatmentId &&
                    (x.Description.StartsWith("Finger-") || x.Description.StartsWith("Calibration-"))).Select(x => x.Description).ToList();

                // save extracted images to database
                for(var i = 0; i < energizedImages.Count; i++)
                {
                    if (caches.All(x => x != "Finger-" + i))
                        using (var mem = new MemoryStream())
                        {
                            energizedImages[i].Image.Save(mem, ImageFormat.Png);
                            new ImageCacheEntity
                            {
                                LookupKey = treatmentId,
                                Description = "Finger-" + i,
                                Image = mem.ToArray()
                            }.Save();
                            energizedImages[i].Image.Dispose();
                        }
                }
                for(var i = 0; i < calibrationImages.Count; i++)
                {
                    if (caches.All(x => x != "Calibration-" + i))
                        using (var mem = new MemoryStream())
                        {
                            calibrationImages[i].Image.Save(mem, ImageFormat.Png);
                            new ImageCacheEntity
                                {
                                    LookupKey = treatmentId,
                                    Description = "Calibration-" + i,
                                    Image = mem.ToArray()
                                }.Save();
                            calibrationImages[i].Image.Dispose();
                        }
                }
            }

            ViewResult result = View(model);

            if (dtRequestModel == null)
                return result;

            return Query(result, dtRequestModel);
        }

        /// <summary>
        /// Generates the system comparison image for a given treatment.
        /// </summary>
        /// <param name="treatmentId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SystemComparison(long treatmentId)
        {
            var treatment = new TreatmentEntity(treatmentId);
            if (treatment.IsNew)
                throw new HttpException(404, SharedRes.Error.NotFound_Treatment);

            // make sure the user has access to this treatment
            if (!Permissions.UserHasPermission("View", treatment))
                throw new HttpException(401, SharedRes.Error.Unauthorized_Treatment);

            using (var stream = new MemoryStream())
            {
                using (var image = Utilities.Treatment.SystemComparison.PlotNSData(treatment.AnalysisResults, treatment.Patient.Gender))
                {
                    image.Save(stream, ImageFormat.Png);
                    return File(stream.ToArray(), "image/png");
                }
            }
        }

        /// <summary>
        /// Primary function for the Images page, displays patient images for the treatment.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="treatmentId"></param>
        /// <param name="calibration"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Image(int index, long treatmentId, bool calibration)
        {
            var treatment = new TreatmentEntity(treatmentId);
            if (treatment.IsNew)
                throw new HttpException(404, SharedRes.Error.NotFound_Treatment);

            // make sure the user has access to this treatment
            if (!Permissions.UserHasPermission("View", treatment))
                throw new HttpException(401, SharedRes.Error.Unauthorized_Treatment);

            var cache =
                new LinqMetaData().ImageCache.FirstOrDefault(
                x => x.LookupKey == treatmentId && (x.Description == (calibration ? ("Calibration-" + index) : ("Finger-" + index))));
            if (cache == null)
                throw new HttpException(404, ViewRes.Treatment.NoImageAvailable);

            return File(cache.Image, "image/png");
        }

        /// <summary>
        /// Not used directly, only called by sectors.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="treatmentId"></param>
        /// <param name="colored"></param>
        /// <returns>A flattened finger image.</returns>
        [HttpGet]
        public ActionResult Flattened(int index, long treatmentId, bool colored = false)
        {
            var treatment = new TreatmentEntity(treatmentId);
            if (treatment.IsNew)
                throw new HttpException(404, SharedRes.Error.NotFound_Treatment);

            // make sure the user has access to this treatment
            if (!Permissions.UserHasPermission("View", treatment))
                throw new HttpException(401, SharedRes.Error.Unauthorized_Treatment);

            // set up variables that define the image
            var finger = (index % 5 + 1) + (index % 10 >= 5 ? "L" : "R");
            var filtered = (index >= 10);
            var fingerEntity =
                new LinqMetaData().AnalysisResult.First(
                    x => x.TreatmentId == treatmentId && x.FingerDesc.Contains(finger) && x.IsFiltered == filtered);

            var cache =
                new LinqMetaData().ImageCache.FirstOrDefault(
                x => x.LookupKey == treatmentId && (x.Description == (colored ? ("Colorized-" + index) : ("Flattened-" + index))));

            // create colorized
            if (cache == null)
            {
                cache =
                    new LinqMetaData().ImageCache.FirstOrDefault(
                        x => x.LookupKey == treatmentId && (x.Description == ("Finger-" + index)));
                if (cache == null)
                    throw new HttpException(404, ViewRes.Treatment.NoImageAvailable);

                using (var image = new Bitmap(new MemoryStream(cache.Image)) as Image)
                {
                    Image colorized = null;
                    if (colored)
                    {
                        colorized = Utilities.Treatment.ImageManipulation.CreateColorizedImages(
                            (Bitmap) image, finger + '-' + index, fingerEntity.NoiseLevel);
                    }

                    using (var flattenedColorizedImage =
                        Utilities.Treatment.ImageManipulation.ProcessFullBiofieldInnerEllipse(finger,
                                                                                              filtered,
                                                                                              colorized ?? image,
                                                                                              treatmentId))
                    {
                        if (colorized != null)
                            colorized.Dispose();

                        using (var mem = new MemoryStream())
                        {
                            flattenedColorizedImage.Save(mem, ImageFormat.Png);
                            cache = new ImageCacheEntity
                                        {
                                            LookupKey = treatmentId,
                                            Description = colored ? "Colorized-" + index : "Flattened-" + index,
                                            Image = mem.ToArray()
                                        };
                            cache.Save();
                        }
                    }
                }
            }

            return File(cache.Image, "image/png");
        }

        /// <summary>
        /// Primary function for the Summary page which displays finger sectors.
        /// </summary>
        /// <param name="fingerDesc"></param>
        /// <param name="treatmentId"></param>
        /// <param name="colored"></param>
        /// <param name="filtered"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Sectors(string fingerDesc, long treatmentId, bool colored = false, bool filtered = false)
        {
            var treatment = new TreatmentEntity(treatmentId);
            if (treatment.IsNew)
                throw new HttpException(404, SharedRes.Error.NotFound_Treatment);

            // make sure the user has access to this treatment
            if (!Permissions.UserHasPermission("View", treatment))
                throw new HttpException(401, SharedRes.Error.Unauthorized_Treatment);

            // set up variables that define the image
            var index = int.Parse(fingerDesc.Substring(0, 1)) - 1 + (fingerDesc.Substring(1, 1) == "R" ? 0 : 5) + (filtered ? 10 : 0);

            var flattenedResult = Flattened(index, treatmentId, colored);
            if(flattenedResult is FileContentResult)
            {
                // get requested sector
                using (var sectorImage =
                    Utilities.Treatment.ImageManipulation.CreateSectorBiofields(
                        Bitmap.FromStream(new MemoryStream(((FileContentResult)flattenedResult).FileContents)),
                        treatment.AnalysisResults.First(
                            x => x.FingerDesc == fingerDesc)))
                {

                    using (var stream = new MemoryStream())
                    {
                        sectorImage.Save(stream, ImageFormat.Png);
                        return File(stream.ToArray(), "image/png");
                    }
                }
            }
            return flattenedResult;
        }

        /// <summary>
        /// Joins and generates the data for the full report page.
        /// </summary>
        /// <param name="Debug"></param>
        /// <param name="Severities"></param>
        /// <param name="License"></param>
        /// <returns></returns>
        private IQueryable<RawReportFull> GetDebugData(IQueryable<CalculationDebugDataEntity> Debug, IEnumerable<SeverityEntity> Severities, LicenseMode License)
        {
            var organs = new LinqMetaData().Organ;

            var fu = Debug.ToArray()
                .Where(x => x.IsFiltered)
                .Join(Debug.ToArray()
                          .Where(y => !y.IsFiltered), x => x.FingerSector, y => y.FingerSector,
                      (x, y) => new FilteredUnfiltered
                      {
                          OrganComponent = x.OrganComponent,
                          FingerSector = x.FingerSector,

                          FilteredLRRank = x.LRRank,
                          FilteredLRScaledScore = (int)Math.Round(x.LRScaledScore),
                          FilteredEPICRank = x.EPICRank,
                          FilteredEPICScaledScore = (int)Math.Round(x.EPICScaledScore),

                          // fill in report score below

                          FilteredEPICBaseScore = x.EPICBaseScore,
                          FilteredEPICBonusScore = x.EPICBonusScore,
                          FilteredEPICScore = x.EPICScore,

                          UnfilteredLRRank = y.LRRank,
                          UnfilteredLRScaledScore = (int)Math.Round(y.LRScaledScore),
                          UnfilteredEPICRank = y.EPICRank,
                          UnfilteredEPICScaledScore = (int)Math.Round(y.EPICScaledScore),

                          // fill in report score below

                          UnfilteredEPICBaseScore = y.EPICBaseScore,
                          UnfilteredEPICBonusScore = y.EPICBonusScore,
                          UnfilteredEPICScore = y.EPICScore,
                      });

            var joined = organs
                .LeftOuterJoin(fu.Where(y => y.FingerSector.Contains("L")),
                               x => x.LComp,
                               y => y.FingerSector,
                               (y, x) => new RawReportFull
                               {
                                   LComp = x != null ? x.FingerSector : "",
                                   RComp = y.RComp,
                                   OrganId = y.OrganId,
                                   Organ = y.Description.Replace(" - Left", "").Replace(" - Right", ""),
                                   OrganSystemOrgan = y.OrganSystemOrgans.First(z => z.LicenseOrganSystem.LicenseMode == License),

                                   FingerSector = (x != null ? x.FingerSector : ""),

                                   LFilteredLRRank = x != null ? x.FilteredLRRank.ToString(CultureInfo.InvariantCulture) : "",
                                   LFilteredLRScaledScore = x != null ? x.FilteredLRScaledScore.ToString(CultureInfo.InvariantCulture) : "",
                                   LFilteredEPICRank = x != null ? x.FilteredEPICRank.ToString(CultureInfo.InvariantCulture) : "",
                                   LFilteredEPICScaledScore = x != null ? x.FilteredEPICScaledScore.ToString(CultureInfo.InvariantCulture) : "",

                                   // fill in report score below

                                   LFilteredEPICBaseScore = x != null ? x.FilteredEPICBaseScore.ToString(CultureInfo.InvariantCulture) : "",
                                   LFilteredEPICBonusScore = x != null ? x.FilteredEPICBonusScore.ToString(CultureInfo.InvariantCulture) : "",
                                   LFilteredEPICScore = x != null ? x.FilteredEPICScore.ToString(CultureInfo.InvariantCulture) : "",

                                   LUnfilteredLRRank = x != null ? x.UnfilteredLRRank.ToString(CultureInfo.InvariantCulture) : "",
                                   LUnfilteredLRScaledScore = x != null ? x.UnfilteredLRScaledScore.ToString(CultureInfo.InvariantCulture) : "",
                                   LUnfilteredEPICRank = x != null ? x.UnfilteredEPICRank.ToString(CultureInfo.InvariantCulture) : "",
                                   LUnfilteredEPICScaledScore = x != null ? x.UnfilteredEPICScaledScore.ToString(CultureInfo.InvariantCulture) : "",

                                   // fill in report score below

                                   LUnfilteredEPICBaseScore = x != null ? x.UnfilteredEPICBaseScore.ToString(CultureInfo.InvariantCulture) : "",
                                   LUnfilteredEPICBonusScore = x != null ? x.UnfilteredEPICBonusScore.ToString(CultureInfo.InvariantCulture) : "",
                                   LUnfilteredEPICScore = x != null ? x.UnfilteredEPICScore.ToString(CultureInfo.InvariantCulture) : "",
                               })
                // join right sides
                .LeftOuterJoin(fu.Where(y => y.FingerSector.Contains("R")),
                               x => x.RComp,
                               y => y.FingerSector,
                               (y, x) =>
                               {
                                   y.FingerSector = y.FingerSector + (!String.IsNullOrEmpty(y.FingerSector) && x != null ? "/" : "") + (x != null ? x.FingerSector : "");

                                   y.RFilteredLRRank = x != null ? x.FilteredLRRank.ToString(CultureInfo.InvariantCulture) : "";
                                   y.RFilteredLRScaledScore = x != null ? x.FilteredLRScaledScore.ToString(CultureInfo.InvariantCulture) : "";
                                   y.RFilteredEPICRank = x != null ? x.FilteredEPICRank.ToString(CultureInfo.InvariantCulture) : "";
                                   y.RFilteredEPICScaledScore = x != null ? x.FilteredEPICScaledScore.ToString(CultureInfo.InvariantCulture) : "";

                                   // fill in report score below

                                   y.RFilteredEPICBaseScore = x != null ? x.FilteredEPICBaseScore.ToString(CultureInfo.InvariantCulture) : "";
                                   y.RFilteredEPICBonusScore = x != null ? x.FilteredEPICBonusScore.ToString(CultureInfo.InvariantCulture) : "";
                                   y.RFilteredEPICScore = x != null ? x.FilteredEPICScore.ToString(CultureInfo.InvariantCulture) : "";

                                   y.RUnfilteredLRRank = x != null ? x.UnfilteredLRRank.ToString(CultureInfo.InvariantCulture) : "";
                                   y.RUnfilteredLRScaledScore = x != null ? x.UnfilteredLRScaledScore.ToString(CultureInfo.InvariantCulture) : "";
                                   y.RUnfilteredEPICRank = x != null ? x.UnfilteredEPICRank.ToString(CultureInfo.InvariantCulture) : "";
                                   y.RUnfilteredEPICScaledScore = x != null ? x.UnfilteredEPICScaledScore.ToString(CultureInfo.InvariantCulture) : "";

                                   // fill in report score below

                                   y.RUnfilteredEPICBaseScore = x != null ? x.UnfilteredEPICBaseScore.ToString(CultureInfo.InvariantCulture) : "";
                                   y.RUnfilteredEPICBonusScore = x != null ? x.UnfilteredEPICBonusScore.ToString(CultureInfo.InvariantCulture) : "";
                                   y.RUnfilteredEPICScore = x != null ? x.UnfilteredEPICScore.ToString(CultureInfo.InvariantCulture) : "";

                                   return y;
                               });

            var report = joined
                .Join(Severities, x => x.OrganId, y => y.OrganId,
                      (x, y) =>
                      {
                          x.PhysicalLeft = y != null && y.PhysicalLeft.HasValue ? y.PhysicalLeft.Value.ToString(CultureInfo.InvariantCulture) : "";
                          x.PhysicalRight = y != null && y.PhysicalRight.HasValue ? y.PhysicalRight.Value.ToString(CultureInfo.InvariantCulture) : "";

                          x.MentalLeft = y != null && y.MentalLeft.HasValue ? y.MentalLeft.Value.ToString(CultureInfo.InvariantCulture) : "";
                          x.MentalRight = y != null && y.MentalRight.HasValue ? y.MentalRight.Value.ToString(CultureInfo.InvariantCulture) : "";

                          return x;
                      });

            return report.AsQueryable();
        }

    }
}
