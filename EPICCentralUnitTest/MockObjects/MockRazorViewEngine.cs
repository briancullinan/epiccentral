using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace EPICCentralUnitTest.MockObjects
{
    public class MockRazorViewEngine : RazorViewEngine
    {
        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            string controllerName = controllerContext.RouteData.GetRequiredString("controller");
            object area;
            string viewArea = null;
            if (controllerContext.RouteData.DataTokens.TryGetValue("area", out area))
            {
                viewArea = area as string;
            }
            var loc = ViewLocationFormats
                .Select(x => String.Format(x, viewName, controllerName, viewArea))
                .FirstOrDefault(s => File.Exists(MockVirtualPathFactory.NormalizePath(s)));
            var masterLoc = MasterLocationFormats
                .Select(x => String.Format(x, viewName, masterName, viewArea))
                .FirstOrDefault(s => File.Exists(MockVirtualPathFactory.NormalizePath(s)));
            if (loc == null)
                return new ViewEngineResult(ViewLocationFormats);
            else
            {
                var view = new MockView(MockVirtualPathFactory.NormalizePath(loc), loc, true, FileExtensions);
                return new ViewEngineResult(view, this);
            }
        }

        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            string controllerName = controllerContext.RouteData.GetRequiredString("controller");
            object area;
            string viewArea = null;
            if (controllerContext.RouteData.DataTokens.TryGetValue("area", out area))
            {
                viewArea = area as string;
            }
            var loc = PartialViewLocationFormats
                .Select(x => String.Format(x, partialViewName, controllerName, viewArea))
				.FirstOrDefault(s => File.Exists(s.Replace("~/", MockVirtualPathFactory.BaseDirectory + "\\EPICCentral\\")));
            if (loc == null)
                return new ViewEngineResult(ViewLocationFormats);
            else
            {
                var view = new MockView(MockVirtualPathFactory.NormalizePath(loc), loc, false, FileExtensions);
                return new ViewEngineResult(view, this);
            }
        }
    }
}