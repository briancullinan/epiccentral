using System;
using System.IO;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using EPICCentral.REST.Core;
using EPICCentral.REST.v0100.Scanning;
using EPICCentralDL.Linq;
using EPICCentralServiceAPI.REST.Objects;
using EPICCentralUnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class WSDeviceTest : ControllerTest
    {
        /// <summary>
        /// Satisfies requirement 4.6.1.5
        /// </summary>
        [TestMethod]
        public void Web_Service_For_Scans_Available()
        {
            // pick a device to test
            var device = new LinqMetaData().Device.FirstOrDefault(x => x.ScansAvailable > 0);
            Assert.IsNotNull(device);

            // setup service call
            var output = new StringWriter();
            var service = new ScanService();
            var url = new Uri("http://localhost/" + service.GetProperties().Url + "/getcount", UriKind.Absolute);
            HttpContext.Current = new HttpContext(
                new HttpRequest(url.AbsolutePath, url.AbsoluteUri, url.Query),
                new HttpResponse(output));
            HttpContext.Current.User = new RolePrincipal(new GenericIdentity(device.UniqueIdentifier));
            Thread.CurrentPrincipal = HttpContext.Current.User;

            // get count reported by service
            var count = service.GetCount();

            // compare service count to device from database
            Assert.AreEqual(device.ScansAvailable, count.ScansAvailable);
        }

        /// <summary>
        /// Satisfies requirement 4.6.1.6
        /// Satisfies requirement 4.6.6
        /// </summary>
        [TestMethod]
        public void Web_Service_For_Scan_Completion()
        {
            // pick a device to test
            var device = new LinqMetaData().Device.FirstOrDefault(x => x.ScansAvailable > 0);
            Assert.IsNotNull(device);

            // setup service call
            var output = new StringWriter();
            var service = new ScanService();
            var url = new Uri("http://localhost/" + service.GetProperties().Url + "/scancomplete", UriKind.Absolute);
            HttpContext.Current = new HttpContext(
                new HttpRequest(url.AbsolutePath, url.AbsoluteUri, url.Query),
                new HttpResponse(output));
            HttpContext.Current.User = new RolePrincipal(new GenericIdentity(device.UniqueIdentifier));
            Thread.CurrentPrincipal = HttpContext.Current.User;

            // report the completed scan
            var count = service.ScanComplete(new ScanRecord
                                     {
                                         ScanStartTime = DateTime.UtcNow,
                                         ScanType = ScanType.ClearViewScan
                                     });

            // compare the completed count before and after
            Assert.AreEqual(device.ScansUsed + 1, count.ScansCompleted);
        }

        /// <summary>
        /// Satisfies requirement 6.7.2.3
        /// </summary>
        [TestMethod]
        public void Web_Service_For_Resetting_Authentication()
        {
            throw new NotImplementedException();
        }

        protected override void TestInitialize()
        {
        }

        protected override void TestCleanup()
        {
        }
    }

}
