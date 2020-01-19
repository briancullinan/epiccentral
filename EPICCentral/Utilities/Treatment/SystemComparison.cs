using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Web;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace EPICCentral.Utilities.Treatment
{
    public static class SystemComparison
    {
        public static Color FilteredColor = Color.Navy;  //Physical
        public static Color UnFilteredColor = Color.DarkGreen;  // Autonomic

        private static readonly Point LeftCenterPoint = new Point(403, 338);
        private static readonly Point RightCenterPoint = new Point(1188, 338);

        private static readonly List<string> LeftSectors = new List<string>
                                                               {
                                                                   "3L-7",
                                                                   "4L-1",
                                                                   "4L-8",
                                                                   "4L-9",
                                                                   "4L-2",
                                                                   "2L-8",
                                                                   "2L-7",
                                                                   "2L-6",
                                                                   "2L-5",
                                                                   "3L-5",
                                                                   "4L-4",
                                                                   "3L-2",
                                                                   "3L-3",
                                                                   "4L-3",
                                                                   "2L-3",
                                                                   "2L-2",
                                                                   "1L-1",
                                                                   "2L-9",
                                                                   "5L-6",
                                                                   "3L-1",
                                                                   "5L-3",
                                                                   "1L-4",
                                                                   "4L-7",
                                                                   "1L-5",
                                                               };

        private static readonly List<string> RightSectors = new List<string>
                                                                {
                                                                    "1R-3",
                                                                    "4R-2",
                                                                    "1R-4",
                                                                    "5R-3",
                                                                    "3R-6",
                                                                    "2R-9",
                                                                    "2R-8",
                                                                    "2R-7",
                                                                    "2R-6",
                                                                    "5R-1",
                                                                    "4R-6",
                                                                    "3R-4",
                                                                    "3R-5",
                                                                    "4R-5",
                                                                    "5R-6",
                                                                    "3R-2",
                                                                    "2R-4",
                                                                    "2R-3",
                                                                    "2R-2",
                                                                    "2R-1",
                                                                    "4R-7",
                                                                    "4R-9",
                                                                    "4R-1",
                                                                    "4R-8",
                                                                    "3R-7"
                                                                };

        private const int BASE_RADIUS = 220;
        private const int TEXT_RADIUS = BASE_RADIUS + 75;
        const int HALF_BAR_HEIGHT = 21;
        const int SQUARE_SIZE = 7; // Should always be odd

        public struct PlotPoint
        {
            public Point Point;
            public Point TextPoint;
            public string OrganText;
            public double Value;
            public Point StartPoint;
            public SolidBrush Brush;
        }

        private static Point CalcDisplayPoint(Point StartingPoint, Int32 RadiusToUse, Double AngleToUse)
        {
            AngleToUse = (Math.PI * AngleToUse / 180.0) - 90;
            Int32 X = Convert.ToInt32(Math.Round(StartingPoint.X + ((RadiusToUse) * Math.Cos(AngleToUse)), 0));
            Int32 Y = Convert.ToInt32(Math.Round(StartingPoint.Y + ((RadiusToUse) * Math.Sin(AngleToUse)), 0));
            return new Point(X, Y);
        }


        /// <summary>
        /// This method is used to get the data that is to be 
        /// plotted and to mark the point on the screen. A 
        /// routine at the end will connect all of the points with
        /// a line.
        /// </summary>
        public static Image PlotNSData(IEnumerable<AnalysisResultEntity> results, Gender gender)
        {
            // get unflitered standard deviation
            var filtered = results.Where(x => x.IsFiltered).Select(x => x.JsInteger);
            var filteredMean = filtered.Average();
            var filteredSumOfSquaresOfDifferences =
                filtered.Select(val => (val - filteredMean) * (val - filteredMean)).Sum();
            var filteredDeviation = Math.Sqrt(filteredSumOfSquaresOfDifferences / filtered.Count());

            var unfiltered = results.Where(x => !x.IsFiltered).Select(x => x.JsInteger);
            var unfilteredMean = unfiltered.Average();
            var unfilteredSumOfSquaresOfDifferences =
                unfiltered.Select(val => (val - unfilteredMean)*(val - unfilteredMean)).Sum();
            var unfilteredDeviation = Math.Sqrt(unfilteredSumOfSquaresOfDifferences/unfiltered.Count());

            // get filtered standard deviation

            // create NS image
            using (var image = Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/treatment/NS_1600x660.gif")))
            {
                var tmpImage = new Bitmap(image.Width, image.Height);
                var g = Graphics.FromImage(tmpImage);
                g.InterpolationMode = InterpolationMode.High;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                g.DrawImage(image, 0, 0);
                DrawLegend(g, 710, 30);

                // select the finger sectors to display values for
                var groups = results
                    .Where(x => LeftSectors.Contains(x.FingerDesc) || RightSectors.Contains(x.FingerDesc))
                    .GroupBy(x => new {x.IsFiltered, IsLeft = x.FingerDesc.Contains("L")});

                foreach (var group in groups)
                {
                    // order the group
                    var orderedGroup = @group.First().FingerDesc.Contains("L")
                                           ? @group.OrderBy(x => LeftSectors.FindIndex(s => s == x.FingerDesc))
                                           : @group.OrderBy(x => RightSectors.FindIndex(s => s == x.FingerDesc));
                    var mean = @group.First().IsFiltered ? filteredMean : unfilteredMean;
                    var deviation = @group.First().IsFiltered ? filteredDeviation : unfilteredDeviation;
                    var points = GetValue(orderedGroup, g, mean, deviation, 360.0/@group.Count()).ToList();
                    AttachPoints(g, new Pen(@group.First().IsFiltered ? FilteredColor : UnFilteredColor), points);
                }

                // draw the bodies
                Image left, right;
                if (gender == Gender.Female)
                {
                    left = Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/treatment/female-left.gif"));
                    right = Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/treatment/female-right.gif"));
                }
                else
                {
                    left = Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/treatment/male-left.gif"));
                    right = Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/treatment/male-right.gif"));
                }

                const float scaleBody = 0.5f;

                // draw the bodies for left and right side
                g.DrawImage(left, LeftCenterPoint.X - (left.Width*scaleBody)/2,
                            LeftCenterPoint.Y - (left.Height*scaleBody)/2,
                            left.Width*scaleBody,
                            left.Height*scaleBody);
                g.DrawImage(right, RightCenterPoint.X - (right.Width*scaleBody)/2,
                            RightCenterPoint.Y - (right.Height*scaleBody)/2,
                            right.Width*scaleBody,
                            right.Height*scaleBody);


                // draw the labels for Left and Right side
                var sideLabelFont = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                var leftLabel = g.MeasureString("Left Side", sideLabelFont);
                g.DrawString("Left Side", sideLabelFont, Brushes.Black,
                             LeftCenterPoint.X - (left.Width*scaleBody/2) + (leftLabel.Width/2),
                             LeftCenterPoint.Y - (left.Height*scaleBody/2) - (leftLabel.Height/2));

                var rightLabel = g.MeasureString("Right Side", sideLabelFont);
                g.DrawString("Right Side", sideLabelFont, Brushes.Black,
                             RightCenterPoint.X - (right.Width*scaleBody/2) + (rightLabel.Width/2),
                             RightCenterPoint.Y - (right.Height*scaleBody/2) - (rightLabel.Height/2));


                g.Dispose();
                return tmpImage;
            }
        }

        private static IEnumerable<Point> GetValue(IEnumerable<AnalysisResultEntity> orderedGroup, Graphics g, double mean, double deviation, double increment)
        {
            var organs = new LinqMetaData().Organ;
            var sliceCount = 0;

            // add group to image
            foreach (var result in orderedGroup)
            {
                ++sliceCount;
                // Calculate the radius of the point
                var pointValue = (result.JsInteger - mean)/deviation;
                var deltaValue = Convert.ToInt32(Math.Round((pointValue*HALF_BAR_HEIGHT), 0));
                var centerPoint = result.FingerDesc.Contains("L") ? LeftCenterPoint : RightCenterPoint;
                var plotPoint = new PlotPoint
                                    {
                                        Point =
                                            CalcDisplayPoint(centerPoint, BASE_RADIUS + deltaValue, sliceCount*increment),
                                        TextPoint = CalcDisplayPoint(centerPoint, TEXT_RADIUS, sliceCount*increment),
                                        Value = pointValue,
                                        StartPoint = centerPoint,
                                        Brush = result.IsFiltered
                                                    ? new SolidBrush(FilteredColor)
                                                    : new SolidBrush(UnFilteredColor)
                                    };
                if (!result.IsFiltered)
                {
                    var isLeft = result.FingerDesc.Contains("L");
                    var organ = isLeft
                                    ? organs.First(x => x.LComp == result.FingerDesc)
                                    : organs.First(x => x.RComp == result.FingerDesc);

                    plotPoint.OrganText = organ.Description.Replace(" - Right", "").Replace(" - Left", "");
                }

                MarkPoint(g, plotPoint);
                yield return plotPoint.Point;
            }
        }

        /// <summary>
        /// This method will draw the line that connects the points
        /// that were plotted
        /// </summary>
        /// <param name="g">Graphics context used for drawing</param>
        /// <param name="penToUse">Definition of the pen to draw with </param>
        /// <param name="arrayToUse">An array of points to plot</param>
        private static void AttachPoints(Graphics g, Pen penToUse, IEnumerable<Point> arrayToUse)
        {
            // This routine will connect all the points in the set with a line
            Point startingPoint = Point.Empty;
            Point currentPoint = Point.Empty;
            foreach (var point in arrayToUse)
            {
                if (startingPoint.Equals(Point.Empty))
                {
                    startingPoint = point;
                    currentPoint = point;
                }
                else
                {
                    g.DrawLine(penToUse, currentPoint, point);
                    g.FillRectangle(Brushes.Black, currentPoint.X, currentPoint.Y, 1, 1);
                    g.FillRectangle(Brushes.Black, point.X, point.Y, 1, 1);
                    currentPoint = point;
                }
            }
            g.DrawLine(penToUse, currentPoint, startingPoint);
            g.FillRectangle(Brushes.Black, currentPoint.X, currentPoint.Y, 1, 1);
            g.FillRectangle(Brushes.Black, startingPoint.X, startingPoint.Y, 1, 1);
        }

        /// <summary>
        /// This method marks the point specified in the parameters
        /// </summary>
        /// <param name="g">Graphics context to use</param>
        /// <param name="typeVar">The type of point to plot</param>
        /// <param name="startPoint">The start point of the value to plot</param>
        /// <param name="valueToPlot">The offset of the value to plot</param>
        /// <param name="sliceCount"></param>
        /// <param name="organToPlot"></param>
        private static void MarkPoint(Graphics g, PlotPoint plotPoint)
        {
            // Create the rectangle that marks the point
            g.FillRectangle(plotPoint.Brush,
                            new Rectangle(plotPoint.Point.X - (SQUARE_SIZE/2),
                                          plotPoint.Point.Y - (SQUARE_SIZE/2), SQUARE_SIZE, SQUARE_SIZE));

            var organSystemFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
            if (plotPoint.OrganText != null)
            {
                g.DrawLine(Pens.LightGray, plotPoint.StartPoint, plotPoint.TextPoint);
                var sizeContainer = g.MeasureString(plotPoint.OrganText, organSystemFont);
                g.DrawString(plotPoint.OrganText, organSystemFont, Brushes.Black,
                             plotPoint.TextPoint.X - (sizeContainer.Width/2),
                             plotPoint.TextPoint.Y - (sizeContainer.Height/2));
            }
            var plotValueSizeContainer = g.MeasureString(plotPoint.Value.ToString("F2"), organSystemFont);
            if (plotPoint.Brush.Color == UnFilteredColor)
            {
                g.DrawString(plotPoint.Value.ToString("F2"), organSystemFont, plotPoint.Brush,
                             plotPoint.TextPoint.X - (plotValueSizeContainer.Width/2),
                             plotPoint.TextPoint.Y - (plotValueSizeContainer.Height/2) - plotValueSizeContainer.Height);
            }
            else
            {
                g.DrawString(plotPoint.Value.ToString("F2"), organSystemFont, plotPoint.Brush,
                             plotPoint.TextPoint.X - (plotValueSizeContainer.Width/2),
                             plotPoint.TextPoint.Y + (plotValueSizeContainer.Height/2));
            }
            organSystemFont.Dispose();
        }


        /// <summary>
        /// Private method to draw a legend at the top of the page.
        /// </summary>
        /// <param name="g">Graphics instance to use for drawing</param>
        /// <param name="TopLeftX"></param>
        /// <param name="TopLeftY"></param>
        private static void DrawLegend(Graphics g, Int32 TopLeftX, Int32 TopLeftY)
        {
            g.DrawRectangle(Pens.Gray, TopLeftX, TopLeftY, 198, 50);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            Font drawFont = new Font("Arial", 10);
            g.DrawString("Autonomic", drawFont, drawBrush, TopLeftX + 3, TopLeftY + 7);
            g.DrawLine(new Pen(UnFilteredColor), new Point(TopLeftX + 100, TopLeftY + 15), new Point(TopLeftX + 170, TopLeftY + 15));
            g.DrawString("Physical", drawFont, drawBrush, TopLeftX + 3, TopLeftY + 25);
            g.DrawLine(new Pen(FilteredColor), new Point(TopLeftX + 100, TopLeftY + 33), new Point(TopLeftX + 170, TopLeftY + 33));
        }

    }
}