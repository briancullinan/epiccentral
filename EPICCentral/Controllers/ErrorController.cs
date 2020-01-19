using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using EPICCentral.Utilities.Membership;
using MvcApi;
using SharedRes;

namespace EPICCentral.Controllers
{
    /// <summary>
    /// Primary controller for what happens when an error occurs.  This is invoked by Global.asax when an error goes unhandled.
    /// </summary>
    public class ErrorController : Controller
    {
        /// <summary>
        /// Returns a couple types of errors based on the type of request, such as JSON, HTML, and images for errors that occur while generating an image.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (RouteData.Values.ContainsKey("error"))
            {
                var error = (HandleErrorInfo) RouteData.Values["error"];
                if (error.Exception is HttpException)
                {
                    var httpException = (HttpException) error.Exception;
                    Response.StatusCode = httpException.GetHttpCode();
                }
                else
                    Response.StatusCode = 500;
            }
            else
                Response.StatusCode = 500;

            // return just the exception page
            if (ControllerContext.IsChildAction)
            {
                if (RouteData.Values.ContainsKey("error"))
                    return PartialView(RouteData.Values["error"]);
                return PartialView();
            }

            // return a json result
            if (Request.IsAjaxRequest())
            {
                return JsonException();
            }


            // determine if we should return an image
            var imageType = "";
            if (Request.AcceptTypes != null)
            {
                imageType =
                    Request.AcceptTypes.OrderBy(x => x.Contains("*")).FirstOrDefault(
                        x => x.IndexOf("image/", StringComparison.OrdinalIgnoreCase) > -1);
            }
            if (string.IsNullOrEmpty(imageType))
                imageType =
                    typeof (ImageFormat).GetProperties().Select(x => x.Name).FirstOrDefault(
                        x => Request.FilePath.EndsWith("." + x, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(imageType))
            {
                return ImageException();
            }

            // return the full html exception view
            if (RouteData.Values.ContainsKey("error"))
                return View(RouteData.Values["error"]);
            return View();
        }

        private JsonResult JsonException()
        {
            if (RouteData.Values.ContainsKey("error"))
            {
                var error = (HandleErrorInfo)RouteData.Values["error"];
                // send different amount of information based on who is logged in
                if (RoleUtils.IsUserServiceAdmin())
                    return
                        Json(
                            new
                            {
                                error.ActionName,
                                error.ControllerName,
                                Data = error.Exception.Data.ToString(),
                                error.Exception.Message,
                                InnerException = error.Exception.InnerException != null ? error.Exception.InnerException.ToString() : "",
                                StackTrace = error.Exception.StackTrace.ToString(),
                                TargetSite = error.Exception.TargetSite.ToString(),
                                Source = error.Exception.Source.ToString(),
                                error.Exception.HelpLink,
                            }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new
                    {
                        error.Exception.Message
                    });
            }
            return Json(Error.Error_Unspecified, JsonRequestBehavior.AllowGet);
        }

        private FileContentResult ImageException()
        {
            using (var image = new Bitmap(300, 200))
            {
                var g = Graphics.FromImage(image);
                g.InterpolationMode = InterpolationMode.High;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TextRenderingHint = TextRenderingHint.AntiAlias;
                g.FillRectangle(new SolidBrush(Color.Black), 0, 0, image.Width, image.Height);
                var fontSize = 15;
                Font f;
                var message = Error.Error_Unspecified;
                if (RouteData.Values.ContainsKey("error"))
                {
                    var error = (HandleErrorInfo)RouteData.Values["error"];
                    message = error.Exception.Message;
                    // only show stack trace if service administrator is logged in
                    if (RoleUtils.IsUserServiceAdmin())
                    {
                        message += Environment.NewLine + Environment.NewLine + "Controller: " + error.ControllerName +
                                   Environment.NewLine + Environment.NewLine + "Action: " + error.ActionName +
                                   Environment.NewLine + Environment.NewLine + "Stack Trace: " +
                                   error.Exception.StackTrace;
                    }
                }

                float height;
                do
                {
                    f = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
                    height = g.MeasureString(message, f, 300).Height;
                    fontSize--;
                } while (height > image.Height && fontSize > 4);
                g.DrawString(message, f, new SolidBrush(Color.White),
                             new RectangleF(0, 0, image.Width, image.Height));

                using (var mem = new MemoryStream())
                {
                    image.Save(mem, ImageFormat.Png);
                    return File(mem.ToArray(), "image/png");
                }
            }
        }
    }
}