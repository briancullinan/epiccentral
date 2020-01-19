using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using EPICCentral.Controllers;
using EPICCentralUnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class CompatibilityTest : ControllerTest<HomeController>
    {
        /// <summary>
        /// Satisfies requirement 4.8.2.1
        /// Satisfies requirement 4.8.2.2
        /// Satisfies requirement 4.8.2.3
        /// Satisfies requirement 4.8.2.4
        /// </summary>
        [TestMethod]
        public void Valid_Html()
        {
            var controller = Mock();
            controller.Invoke(x => x.Index(null));

            var client = (HttpWebRequest)WebRequest.Create("http://validator.w3.org/check");
            client.Method = "POST";
            client.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:12.0) Gecko/20100101 Firefox/12.0";
            client.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            client.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-us,en;q=0.5");
            client.ServicePoint.Expect100Continue = false;
            client.Expect = null;
            client.KeepAlive = true;

            var boundary = "-----" + Guid.NewGuid().ToString().Replace("-", "");
            client.ContentType = "multipart/form-data; boundary=" + boundary;
            var stream = client.GetRequestStream();
            using (var requestWriter = new StreamWriter(stream))
            {
                requestWriter.WriteLine("--" + boundary);
                requestWriter.WriteLine("Content-Disposition: form-data; name=\"fragment\"");
                requestWriter.WriteLine();
                requestWriter.WriteLine(controller.Response.Output.ToString());
                requestWriter.WriteLine();
                requestWriter.WriteLine("--" + boundary);
                requestWriter.WriteLine("Content-Disposition: form-data; name=\"charset\"");
                requestWriter.WriteLine();
                requestWriter.WriteLine("(detect automatically)");
                requestWriter.WriteLine("--" + boundary);
                requestWriter.WriteLine("Content-Disposition: form-data; name=\"doctype\"");
                requestWriter.WriteLine();
                requestWriter.WriteLine("Inline");
                requestWriter.WriteLine("--" + boundary);
                requestWriter.WriteLine("Content-Disposition: form-data; name=\"group\"");
                requestWriter.WriteLine();
                requestWriter.WriteLine("0");
                requestWriter.WriteLine("--" + boundary);
                requestWriter.WriteLine("Content-Disposition: form-data; name=\"user-agent\"");
                requestWriter.WriteLine();
                requestWriter.WriteLine("W3C_Validator/1.3");
                requestWriter.WriteLine("--" + boundary + "--");

            }

            var response = client.GetResponse();
            var responseStream = response.GetResponseStream();
            using(var streamReader = new StreamReader(responseStream))
            {
                var responsStr = streamReader.ReadToEnd();
                Assert.IsTrue(responsStr.Contains("<td colspan=\"2\" class=\"valid\">"));
            }
        }

        /// <summary>
        /// Satisfies requirement 4.8.2.1
        /// Satisfies requirement 4.8.2.2
        /// Satisfies requirement 4.8.2.3
        /// Satisfies requirement 4.8.2.4
        /// </summary>
        [TestMethod]
        public void Valid_Css()
        {
            var cssPath = MockVirtualPathFactory.NormalizePath("~/Content/Site.css");
            var cssReader = new StreamReader(File.OpenRead(cssPath));

            var client = (HttpWebRequest)WebRequest.Create("http://jigsaw.w3.org/css-validator/validator");
            client.Method = "POST";
            client.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:12.0) Gecko/20100101 Firefox/12.0";
            client.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            client.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-us,en;q=0.5");
            client.ServicePoint.Expect100Continue = false;
            client.Expect = null;
            client.KeepAlive = true;

            var boundary = "-----" + Guid.NewGuid().ToString().Replace("-", "");
            client.ContentType = "multipart/form-data; boundary=" + boundary;
            var stream = client.GetRequestStream();
            using (var requestWriter = new StreamWriter(stream))
            {
                requestWriter.WriteLine("--" + boundary);
                requestWriter.WriteLine("Content-Disposition: form-data; name=\"text\"");
                requestWriter.WriteLine();
                requestWriter.WriteLine(cssReader.ReadToEnd());
                requestWriter.WriteLine();
                requestWriter.WriteLine("--" + boundary);
                requestWriter.WriteLine("Content-Disposition: form-data; name=\"profile\"");
                requestWriter.WriteLine();
                requestWriter.WriteLine("css3");
                requestWriter.WriteLine("--" + boundary);
                requestWriter.WriteLine("Content-Disposition: form-data; name=\"usermedium\"");
                requestWriter.WriteLine();
                requestWriter.WriteLine("all");
                requestWriter.WriteLine("--" + boundary);
                requestWriter.WriteLine("Content-Disposition: form-data; name=\"type\"");
                requestWriter.WriteLine();
                requestWriter.WriteLine("none");
                requestWriter.WriteLine("--" + boundary);
                requestWriter.WriteLine("Content-Disposition: form-data; name=\"warning\"");
                requestWriter.WriteLine();
                requestWriter.WriteLine("1");
                requestWriter.WriteLine("Content-Disposition: form-data; name=\"vextwarning\"");
                requestWriter.WriteLine();
                requestWriter.WriteLine("");
                requestWriter.WriteLine("Content-Disposition: form-data; name=\"lang\"");
                requestWriter.WriteLine();
                requestWriter.WriteLine("en");
                requestWriter.WriteLine("--" + boundary + "--");

            }

            var response = client.GetResponse();
            var responseStream = response.GetResponseStream();
            using (var streamReader = new StreamReader(responseStream))
            {
                var responsStr = streamReader.ReadToEnd();
                Assert.IsTrue(responsStr.Contains("<h3>Congratulations!"));
            }
        }

        /// <summary>
        /// Satisfies requirement 4.8.1.1
        /// </summary>
        [TestMethod]
        public void Only_Available_Over_Https()
        {
            // verify http is inaccessible
            var http = new WebClient().DownloadString("http://ec.epicdiagnostics.com");
            Assert.IsTrue(http.Contains("Log On"));

            // verify https is accessible
            var https = new WebClient().DownloadString("https://ec.epicdiagnostics.com");
            Assert.IsTrue(https.Contains("Log On"));
        }

        protected override void TestInitialize()
        {
        }

        protected override void TestCleanup()
        {
        }
    }
}
