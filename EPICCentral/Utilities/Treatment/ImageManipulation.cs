using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using EPICCentralDL.CollectionClasses;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using EPICCentralDL.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using log4net;
using MathWorks.MATLAB.NET.Arrays;
using mlformC;

namespace EPICCentral.Utilities.Treatment
{
    public class ImageManipulation
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ImageManipulation));
        public const Int32 BRIGHTNESS_CUTOFF_THRESHHOLD = 35;

        /// <summary>
        /// This method will unwrap an energized image along the inner 
        /// edge and place it along a straight line. The target image will be 
        /// read from disk and the resulting unwrapped image will be written
        /// back to the disk.
        /// </summary>
        /// <param name="fingerShortName">The short name of the finger (ex. 3L)</param>
        /// <param name="filtered">0 = Unfiltered 1 = Filtered</param>
        /// <param name="image">Image to flatten</param>
        /// <param name="patientTreatmentId">The PatientTreatmentId to pull data from</param>
        public static Bitmap ProcessFullBiofieldInnerEllipse(string fingerShortName, bool filtered, Image image, long patientTreatmentId)
        {
            // Flatten biofield ellipse along X axis (0-540 degrees)
            int centerX = 0;
            int centerY = 0;
            double transAngle = 0.0;
            int radiusMin = 0;
            int radiusMax = 0;
            const int outerRadius = 60; // oversize outer ellipse to ensure outer edge points are not cut off

            // Get necessary data for performing calculations
            GetBiofieldValue(fingerShortName, ref centerX, ref centerY, ref transAngle, ref radiusMin, ref radiusMax, filtered, patientTreatmentId);
            // Load the original colored finger image and create the other necessary bitmaps
            Bitmap bmpImageFile = new Bitmap(image);
            ConvertLowIntensityToTransparent(ref bmpImageFile);
            bmpImageFile.MakeTransparent();
            Bitmap bmpInputColor = new Bitmap(320, 240);
            Graphics graphInputColor = Graphics.FromImage(bmpInputColor);
            graphInputColor.DrawImage(bmpImageFile, 0, 0);
            Bitmap bmpOutput = new Bitmap(540, 200);
            Graphics graphOutput = Graphics.FromImage(bmpOutput);
            // Calculate inner ellipse points using parametric formula (minR and maxR)
            int angle = 90 - Convert.ToInt32(transAngle);
            const int steps = 360;
            double a = radiusMax - 10;
            double b = radiusMin - 10;
            double beta = -angle * (Math.PI / 180); // convert degrees to radians
            double sinbeta = Math.Sin(beta);
            double cosbeta = Math.Cos(beta);

            Point[] inner = new Point[500];

            for (int i = 0; i < 360; i += 360 / steps)
            {
                double alpha = i * (Math.PI / 180);
                double sinalpha = Math.Sin(alpha);
                double cosalpha = Math.Cos(alpha);
                double X = 0 + (a * cosalpha * cosbeta - b * sinalpha * sinbeta);
                double Y = 0 + (a * cosalpha * sinbeta + b * sinalpha * cosbeta);
                inner[i] = new Point(Convert.ToInt32(X), Convert.ToInt32(Y));
            }
            // Set new (0,0) coordinates as center of biofield ellipse
            graphInputColor.TranslateTransform(centerX, centerY);
            // Draw outer ellipse points using parametric formula to defining outer edge points
            angle = Convert.ToInt32(90.0 - transAngle); // orient elipse to biofield image

            a = radiusMax + outerRadius;
            b = radiusMin + outerRadius;
            beta = -angle * (Math.PI / 180); // convert degrees to radians
            sinbeta = Math.Sin(beta);
            cosbeta = Math.Cos(beta);
            for (int i = 0; i < 360; i += 1) // one degree increments
            {
                double alpha = i * (Math.PI / 180);
                double sinalpha = Math.Sin(alpha);
                double cosalpha = Math.Cos(alpha);
                double X = 0 + (a * cosalpha * cosbeta - b * sinalpha * sinbeta);
                double Y = 0 + (a * cosalpha * sinbeta + b * sinalpha * cosbeta);

                PointF A = new Point(0, 0); // center
                PointF C = new Point(Convert.ToInt32(X), Convert.ToInt32(Y)); // outer edge
                PointF B = GetEdgePoint(inner, A, C); // inner edge
                int k = 0;
                IEnumerable<Point> colorPoints = GetPoints(B, C, 1);
                foreach (Point t in colorPoints)
                {
                    int pX = t.X + centerX;
                    int pY = t.Y + centerY;

                    if (pX > 0 && pX < 320 && pY > 0 && pY < 240)
                    {
                        Color pixelColor = bmpInputColor.GetPixel(pX, pY);
                        if (pixelColor.ToString() != "Color [A=0, R=0, G=0, B=0]")
                        {
                            graphOutput.DrawRectangle(new Pen(pixelColor), i, 98 - k, 1, 1);
                            if (i <= 180)
                                graphOutput.DrawRectangle(new Pen(pixelColor), 360 + i, 98 - k, 1, 1);
                            k = k + 1;
                        }
                    }
                }
            }

            // Dispose working graphics
            graphInputColor.Dispose();
            graphOutput.Dispose();
            bmpInputColor.Dispose();
            bmpImageFile.Dispose();

            return bmpOutput;
        }

        /// <summary>
        /// This method will call the Matlab routine that will be responsible for 
        /// creating the colorized version of the images.
        /// </summary>
        /// <param name="imageToUse">The image to colorize</param>
        /// <param name="fingerDesc">Filename to use for the colorized image</param>
        /// <param name="noiseValue">The noise level determined for the image</param>
        public static Image CreateColorizedImages(Bitmap imageToUse, string fingerDesc, int noiseValue)
        {
            // TODO: make this pass images rather than writing to file
            var filePath = Path.GetTempPath() + "workingImage\\" + fingerDesc + ".bmp";

            // This uses the matlab stuff
            int width = imageToUse.Width;
            int height = imageToUse.Height;
            double[,] bma = new double[height, width];
            int i, j;
            for (i = 0; i < width; i++)
            {
                for (j = 0; j < height; j++)
                {
                    Color pixelColor = imageToUse.GetPixel(i, j);
                    double b = pixelColor.GetBrightness();
                    // remove noise here rather than in matlab
                    if ((b * 255) <= noiseValue)
                        bma.SetValue(0, j, i);
                    else
                        bma.SetValue(b, j, i);
                }
            }
            MWCharArray fpath = new MWCharArray(filePath.Replace("\\\\", "\\").Replace("\\\\\\", "\\"));
            try
            {
                formCalc fcalc = new formCalc();
                fcalc.ImagetoColorMap((MWNumericArray)bma, fpath);
                return Image.FromFile(filePath.Replace(".bmp", ".gif"));
            }
            catch (Exception ex)
            {
                Log.Debug("Exception:" + ex.Message + @"\n\n" + ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// This function retrieves necessary geometric information about the 
        /// image that was generated in a previous process.
        /// </summary>
        /// <param name="FingerShortName">The short name of the finger (ex. 3L)</param>
        /// <param name="CenterXVar">The X coordinate of the center of the image</param>
        /// <param name="CenterYVar">The Y coordinate of the center of the image</param>
        /// <param name="TransAngleVar">The rotation angle of the image</param>
        /// <param name="RadiusMinVar">The shortest radius from the middle to the inner edge</param>
        /// <param name="RadiusMaxVar">The longest radius from the middle to the inner edge</param>
        /// <param name="Filtered">0 = Unfiltered 1 = Filtered</param>
        /// <param name="PatientTreatmentId">The PatientTreatmentId to pull data from</param>
        public static void GetBiofieldValue(string FingerShortName, ref int CenterXVar, ref int CenterYVar,
                                            ref double TransAngleVar, ref int RadiusMinVar, ref int RadiusMaxVar,
                                            bool Filtered, long PatientTreatmentId)
        {

            try
            {
                var analysisResult =
                    new LinqMetaData().AnalysisResult.First(
                        x => x.TreatmentId == PatientTreatmentId && x.IsFiltered == Filtered &&
                             x.FingerDesc.Contains(FingerShortName.Substring(0, 2)));
                if (!analysisResult.IsNew)
                {
                    CenterXVar = Convert.ToInt32(analysisResult.CenterX);
                    CenterYVar = Convert.ToInt32(analysisResult.CenterY);
                    TransAngleVar = Convert.ToInt32(analysisResult.AngleOfRotation);
                    RadiusMaxVar = Convert.ToInt32(analysisResult.RadiusMax);
                    RadiusMinVar = Convert.ToInt32(analysisResult.RadiusMin);
                }
                Log.Debug("FingerId->" + FingerShortName + "  Filtered->" + Filtered + "  CenterX->" + CenterXVar +
                          "  CenterY->" + CenterYVar +
                          "  Angle->" + TransAngleVar + "  Radius Min->" + RadiusMinVar + "  Radius Max->" +
                          RadiusMaxVar);
            }
            catch (Exception ex)
            {
                Log.Debug(ex);
            }
        }

        /// <summary>
        /// Returns the point on the inner/outer edge with slope closest to param m.
        /// </summary>
        /// <param name="p">Inner/outer point array.</param>
        /// <param name="a">Starting point.</param>
        /// <param name="b">Ending point.</param>
        /// <returns>Point on inner/outer edge.</returns>
        /// 
        private static PointF GetEdgePoint(IEnumerable<Point> p, PointF a, PointF b)
        {
            PointF U;
            PointF V = PointF.Empty;

            if (b.X != a.X) // line is not vertical
            {
                double m = (b.Y - a.Y) / (b.X - a.X);
                double minM = double.PositiveInfinity;
                foreach (Point t in p)
                {
                    U = t;
                    double maU = (U.Y - a.Y) / (U.X - a.X); // slope of line from image center to inner/outer edge point                  
                    if (GetDistance(U, b) < GetDistance(a, b))
                    {
                        if (Math.Abs(m - maU) == 0) // find point with exact slope (not always possible)
                        {
                            V = U;
                            break;
                        }
                        if (Math.Abs(m - maU) < minM)
                        {
                            V = U; // find point with slope closest to slope value m
                            minM = Math.Abs(m - maU);
                        }
                    }
                }
                return V;
            }
            foreach (Point t in p)
            {
                U = t;
                if (U.X == 0 && U.Y == 0)
                {
                    // do nothing
                }
                else
                {
                    if (U.X == a.X)
                    {
                        if (U.Y > 0)
                        {
                            if (b.Y > 0 && U.Y < b.Y)
                                V = U;
                        }
                        else
                        {
                            if (b.Y < 0 && U.Y > b.Y)
                                V = U;
                        }
                    }
                }
            }
            return V;
        }

        /// <summary>
        /// Calculates the distance between two points.
        /// </summary>
        /// <param name="A">First point.</param>
        /// <param name="B">Last point.</param>
        /// <returns>Distance measure.</returns>
        private static double GetDistance(PointF A, PointF B)
        {
            return Math.Sqrt(Math.Pow(A.X - B.X, 2D) + Math.Pow(A.Y - B.Y, 2D));
        }

        /// <summary>
        /// Returns all points along line segment from start param to end param
        /// </summary>
        /// <param name="start">Starting point.</param>
        /// <param name="end">Ending point.</param>
        /// <param name="minDistance">Minimum distance between points.</param>
        /// <returns>Points along line.</returns>
        /// 
        private static IEnumerable<Point> GetPoints(PointF start, PointF end, int minDistance)
        {
            double dx = end.X - start.X;
            double dy = end.Y - start.Y;
            int numPoints = Convert.ToInt32(Math.Floor(Math.Sqrt(dx * dx + dy * dy) / minDistance) - 1);
            Point[] result = new Point[500];
            double stepx = dx / numPoints;
            double stepy = dy / numPoints;
            double px = start.X + stepx;
            double py = start.Y + stepy;
            for (int ix = 0; ix < numPoints; ix++)
            {
                result[ix] = new Point(Convert.ToInt32(px), Convert.ToInt32(py));
                px += stepx;
                py += stepy;
            }

            return result;
        }

        /// <summary>
        /// Method to set bits to transparent that are below a specified
        /// brightness threshold.
        /// </summary>
        /// <param name="originalImage">Image to modify</param>
        private static void ConvertLowIntensityToTransparent(ref Bitmap originalImage)
        {
            Bitmap tempBMP = new Bitmap(originalImage);
            for (int i = 0; i < tempBMP.Width; i++)
            {
                for (int j = 0; j < tempBMP.Height; j++)
                {
                    Color pixelColor = tempBMP.GetPixel(i, j);
                    if ((255 * pixelColor.GetBrightness()) < BRIGHTNESS_CUTOFF_THRESHHOLD)
                        tempBMP.SetPixel(i, j, Color.Transparent);
                }
            }
            originalImage = (Bitmap)tempBMP.Clone();
            tempBMP.Dispose();
        }

        /// <summary>
        /// This method is called to cut the flattened biofield images 
        /// into specific size sections that reflect the sector sizes.
        /// </summary>
        public static Image CreateSectorBiofields(Image image, AnalysisResultEntity sector)
        {
            var endPosition = sector.EndAngle;
            if (sector.EndAngle < sector.StartAngle)
                endPosition += 360;
            Bitmap cutBitmap = new Bitmap(endPosition - sector.StartAngle, 75, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(cutBitmap);
            Rectangle section = new Rectangle(sector.StartAngle, 25, endPosition, 75);
            g.DrawImage(image, 1, 1, section, GraphicsUnit.Pixel);
            g.Dispose();
            return cutBitmap;
        }
    }
}