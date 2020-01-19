using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Security.Principal;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using EPICCentral.Controllers;
using EPICCentralDL.Linq;
using EPICCentralUnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class DeviceControllerTest : ControllerTest<DeviceController>
    {
        private readonly NameValueCollection _testValues = new NameValueCollection();

        /// <summary>
        /// Satisfies requirement 4.1.3.1
        /// Satisfies requirement 4.1.3.2
        /// Satisfies requirement 4.1.3.3
        /// Satisfies requirement 4.3.2.1
        /// </summary>
        [TestMethod]
        public void Service_Administrator_Can_Create_Devices()
        {
            Create_Edit_Device(TestData.ServiceAdminUsername);
        }

        protected void Create_Edit_Device(string username, bool dontDelete = false)
        {
        	var location = TestData.EndUserLoc;

            // create a new device
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(username));
            var request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");

            // fill in missing test values
            _testValues["OrganizationId"] = location.OrganizationId.ToString(CultureInfo.InvariantCulture);
            _testValues["LocationId"] = location.LocationId.ToString(CultureInfo.InvariantCulture);

            // submit test values
            request.SetupGet(x => x.Form).Returns(() => _testValues);
            controller.Invoke("Edit");
            var device = new LinqMetaData().Device.FirstOrDefault(x => x.SerialNumber == _testValues["SerialNumber"]);
            Assert.IsNotNull(device);

            // edit the device
            controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(username));
            request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");

            // set the locationId
            controller.RouteData.Values.Add("deviceId", device.DeviceId);

            // change the serial number of the device
            _testValues["SerialNumber"] = "DeviceTest1";
            request.SetupGet(x => x.Form).Returns(() => _testValues);
            controller.Invoke("Edit");
            device = new LinqMetaData().Device.FirstOrDefault(x => x.SerialNumber == _testValues["SerialNumber"]);
            Assert.IsNotNull(device);

            if (dontDelete) return;
            // finally delete the testing data
            device.PurchaseHistories.DeleteMulti();
            device.Delete();
        }

        /// <summary>
        /// Satisfies requirement 4.1.3.2
        /// </summary>
        [TestMethod]
        public void Organization_Administrator_Cannot_Create_Devices()
        {
            // run this test too just in case this test is run alone
			Create_Edit_Device(TestData.ServiceAdminUsername);
            try
            {
                Create_Edit_Device(TestData.OrgAdminUsername);
                Assert.Fail("User should not be able to edit devices.");
            }
            catch(AssertFailedException)
            {
                // create edit device failed which is what we want
            }
        }

        /// <summary>
        /// Satisfies requirement 4.1.3.2
        /// </summary>
        [TestMethod]
        public void Users_Cannot_Create_Devices()
        {
            // run this test too just in case this test is run alone
			Create_Edit_Device(TestData.ServiceAdminUsername);
            try
            {
                Create_Edit_Device(TestData.SimpleUserUsername);
                Assert.Fail("User should not be able to edit devices.");
            }
            catch (AssertFailedException)
            {
                // create edit device failed which is what we want
            }
        }

        /// <summary>
        /// Satisfies requirement 4.1.3.3
        /// </summary>
        [TestMethod]
        public void Device_Requires_Location()
        {
            // submit a new location without a name and get back an error
            var controller = Mock();
			controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            var request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");

            // submit an empty collection to get the errors
            request.SetupGet(x => x.Form).Returns(new NameValueCollection
                                                      {
                                                          {"LocationId", null}
                                                      });
            controller.Invoke("Edit");
            Assert.AreEqual(417, controller.Response.StatusCode);
            Assert.IsTrue(controller.ModelState["LocationId"].Errors.Any());
        }

        /// <summary>
        /// Satisfies requirement 4.1.3.4
        /// </summary>
        [TestMethod]
        public void Device_Requires_SerialNumber()
        {
            // submit a new location without a name and get back an error
            var controller = Mock();
			controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            var request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");

            // submit an empty collection to get the errors
            request.SetupGet(x => x.Form).Returns(new NameValueCollection
                                                      {
                                                          {"SerialNumber", null}
                                                      });
            controller.Invoke("Edit");
            Assert.AreEqual(417, controller.Response.StatusCode);
            Assert.IsTrue(controller.ModelState["SerialNumber"].Errors.Any());
        }

        /// <summary>
        /// Satisfies requirement 4.1.3.5
        /// </summary>
        [TestMethod]
        public void Device_Requires_RevisionLevel()
        {
            // submit a new location without a name and get back an error
            var controller = Mock();
			controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            var request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");

            // submit an empty collection to get the errors
            request.SetupGet(x => x.Form).Returns(new NameValueCollection
                                                      {
                                                          {"RevisionLevel", null}
                                                      });
            controller.Invoke("Edit");
            Assert.AreEqual(417, controller.Response.StatusCode);
            Assert.IsTrue(controller.ModelState["RevisionLevel"].Errors.Any());
        }

        /// <summary>
        /// Satisfies requirement 4.1.3.6
        /// Satisfies requirement 4.1.3.7
        /// Satisfies requirement 4.1.3.8
        /// </summary>
        [TestMethod]
        public void Service_Administrator_Can_Modify_Available_Scans()
        {
			var location = TestData.EndUserLoc;

            var controller = Mock();
			controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            var request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");

            // fill in missing test values
            _testValues["OrganizationId"] = location.OrganizationId.ToString(CultureInfo.InvariantCulture);
            _testValues["LocationId"] = location.LocationId.ToString(CultureInfo.InvariantCulture);

            // submit test values
            request.SetupGet(x => x.Form).Returns(() => _testValues);
            controller.Invoke("Edit");
            var device = new LinqMetaData().Device.FirstOrDefault(x => x.SerialNumber == _testValues["SerialNumber"]);
            Assert.IsNotNull(device);
            Assert.AreEqual(1, device.PurchaseHistories.Count);

            // edit the device
            controller = Mock();
			controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");

            // change the number of scans
            controller.RouteData.Values.Add("deviceId", device.DeviceId);

            // change the number of scans without the scan notes
            _testValues["ScansAvailable"] = "20";
            _testValues["PurchaseNotes"] = null;

            request.SetupGet(x => x.Form).Returns(() => _testValues);
            controller.Invoke("Edit");
            device = new LinqMetaData().Device.FirstOrDefault(x => x.SerialNumber == _testValues["SerialNumber"]);
            Assert.IsNotNull(device);
            Assert.AreEqual(417, controller.Response.StatusCode);

            // change the number of scans with the purchase notes
            controller = Mock();
			controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");
            controller.RouteData.Values.Add("deviceId", device.DeviceId);
            _testValues["ScansAvailable"] = "20";
            _testValues["PurchaseNotes"] = "This is an available scans changed test.";
            request.SetupGet(x => x.Form).Returns(() => _testValues);
            controller.Invoke("Edit");
            
            device = new LinqMetaData().Device.FirstOrDefault(x => x.SerialNumber == _testValues["SerialNumber"]);
            Assert.IsNotNull(device);
            Assert.AreEqual(20, device.ScansAvailable);
            Assert.AreEqual(2, device.PurchaseHistories.Count);

            // finally delete the testing data
            device.PurchaseHistories.DeleteMulti();
            device.Delete();
        }

    	protected override void TestInitialize()
        {
            _testValues["DeviceState"] = "1";
            _testValues["SerialNumber"] = "DeviceTest";
            _testValues["RevisionLevel"] = "000";
            _testValues["ScansAvailable"] = "10";
            _testValues["PurchaseNotes"] = "This is a test.";
        }

    	protected override void TestCleanup()
        {
            _testValues.Clear();
            new LinqMetaData().Device.Where(x => x.SerialNumber == "DeviceTest" || x.SerialNumber == "DeviceTest1")
                .ToList().ForEach(x =>
                                      {
                                          x.PurchaseHistories.DeleteMulti();
                                          x.Delete();
                                      });
        }
    }
}
