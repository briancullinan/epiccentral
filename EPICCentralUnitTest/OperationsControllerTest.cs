using System;
using System.Security.Principal;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Security;
using ControllerRes;
using EPICCentral.Controllers;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;
using EPICCentralUnitTest.MockObjects;
using Microsoft.CSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class OperationsControllerTest : ControllerTest<OperationController>
    {
        /// <summary>
        /// Satifies requirement 4.2.2.1
        /// </summary>
        [TestMethod]
        public void Operations_Not_Accessible_By_Normal_User()
        {
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.OrgAdminUsername));
            controller.Invoke("Index");

            Assert.AreEqual(401, controller.HttpContext.Response.StatusCode);
        }

        /// <summary>
        /// Satisfies requirement 4.2.2.1
        /// </summary>
        [TestMethod]
        public void Operations_Is_Accessible_By_Administrator()
        {
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            controller.Invoke("Index");
        }

        /// <summary>
        /// Satisfies requirement 4.2.2.2
        /// </summary>
        [TestMethod]
        public void Operations_Shows_Daily_Counts()
        {
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            controller.Invoke("GetData");
            Assert.IsTrue(controller.Response.Output.ToString().Contains("\"daily\":"));
        }

        /// <summary>
        /// Satisfies requirement 4.2.2.2
        /// Satisfies requirement 4.2.2.3
        /// </summary>
        [TestMethod]
        public void Operations_Increments_Scans_Performed_Properly()
        {
            var countMatcher = new Regex("daily\":.*?Text\":\"Scans Performed\",\"Count\":\"([0-9]*)");
            var aggrCountMatcher = new Regex("system\":.*?Text\":\"Total Scans\",.*?\"Count\":\"([0-9]*)");
            // check the count from the GetData() before the device event is added
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            controller.Invoke(x => x.GetData());
            var match = countMatcher.Match(controller.Response.Output.ToString());
            var aggrMatch = aggrCountMatcher.Match(controller.Response.Output.ToString());
            Assert.IsTrue(match.Success);
            Assert.IsTrue(aggrMatch.Success);
            var count = int.Parse(match.Groups[1].Value);
            var aggrCount = int.Parse(aggrMatch.Groups[1].Value);

            // add a new device event
            var deviceEvent = new DeviceEventEntity
                                    {
                                        DeviceId = new LinqMetaData().Device.First().DeviceId,
                                        EventType = EventType.ScanBegin,
                                        EventTime = DateTime.UtcNow,
                                        ReceivedTime = DateTime.UtcNow
                                    };
            deviceEvent.Save();

            // check the count after the device event is added
            controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            controller.Invoke(x => x.GetData());
            var afterMatch = countMatcher.Match(controller.Response.Output.ToString());
            var afterAggrMatch = aggrCountMatcher.Match(controller.Response.Output.ToString());
            Assert.IsTrue(afterMatch.Success);
            Assert.IsTrue(afterAggrMatch.Success);
            var afterCount = int.Parse(afterMatch.Groups[1].Value);
            var afterAggrCount = int.Parse(afterAggrMatch.Groups[1].Value);

            // compare the two values
            Assert.AreEqual(count + 1, afterCount);
            Assert.AreEqual(aggrCount + 1, afterAggrCount);

            deviceEvent.Delete();
        }

        /// <summary>
        /// Satisfies requirement 4.2.2.3
        /// </summary>
        [TestMethod]
        public void Operations_Shows_Aggragate_Counts()
        {
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            controller.Invoke("GetData");
            Assert.IsTrue(controller.Response.Output.ToString().Contains("\"system\":"));
        }

    	protected override void TestInitialize()
        {
        }

    	protected override void TestCleanup()
        {
        }
    }
}
