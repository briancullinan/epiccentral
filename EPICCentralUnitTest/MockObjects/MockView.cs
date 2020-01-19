using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Web.WebPages;

namespace EPICCentralUnitTest.MockObjects
{
    public class MockView : IView
    {
        private string _path;
        private string _virtualPath;
        private bool _runViewStartPage;
        private IEnumerable<string> _viewStartFileExtensions;

        public MockView(string path, string virtualPath, bool runViewStartPage, IEnumerable<string> viewStartFileExtensions)
        {
            _path = path;
            _virtualPath = virtualPath;
            _runViewStartPage = runViewStartPage;
            _viewStartFileExtensions = viewStartFileExtensions;
        }

        public void Render(ViewContext viewContext, TextWriter writer)
        {
            var template = (WebViewPage)MockVirtualPathFactory.InternalCreateInstance(_path);
            template.VirtualPath = _virtualPath;
            template.ViewContext = viewContext;
            template.ViewData = viewContext.ViewData;
            WebPageRenderingBase currentPage = template;
            var pageDirectory = Path.GetDirectoryName(_path);
            if (_runViewStartPage)
            {
                while (!String.IsNullOrEmpty(pageDirectory) && pageDirectory != "/" && MockVirtualPathFactory.ViewPathContains(pageDirectory))
                {
                    foreach (var extension in _viewStartFileExtensions)
                    {
                        var path = Path.Combine(pageDirectory, "_ViewStart" + "." + extension);
                        if (MockVirtualPathFactory.InternalExists(path))
                        {
                            var parentStartPage = (StartPage)MockVirtualPathFactory.InternalCreateInstance(path);

                            parentStartPage.VirtualPath = path;
                            parentStartPage.ChildPage = currentPage;
                            currentPage = parentStartPage;

                            break;
                        }
                    }
                    pageDirectory = Path.GetDirectoryName(pageDirectory);
                }
            }
            template.InitHelpers();
            template.ExecutePageHierarchy(new WebPageContext(viewContext.HttpContext, page: null, model: null), writer, currentPage); // , currentPage);
        }
    }
}