using System;
using System.Net;
using System.Security.Principal;
using System.ServiceModel.Web;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using EPICCentral.Models;
using EPICCentral.REST.v0100.Registration;
using EPICCentralDL.Customization;
using EPICCentralDL.Linq;
using EPICCentralServiceAPI.REST;
using EPICCentralUnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class DeviceRegistrationTest : DeviceControllerTest
    {

        [ClassInitialize]
        public new static void ClassInitialize(TestContext context)
        {
            ASPTest.ClassInitialize(context);
        }

        [ClassCleanup]
        public new static void ClassCleanup()
        {
            ASPTest.ClassCleanup();
        }

        /// <summary>
        /// Satisfies requirement 4.3.1.3
        /// Satisfies requirement 4.3.1.4
        /// Satisfies requirement 4.3.1.5
        /// Satisfies requirement 4.3.1.6
        /// Satisfies requirement 4.3.1.7
        /// Satisfies requirement 4.6.1.1
        /// Satisfies requirement 4.6.1.2
        /// Satisfies requirement 4.6.3
        /// Satisfies requirement 4.6.4
        /// </summary>
        [TestMethod]
        public void Device_Registration_Requires_User_Account()
        {
            Create_Edit_Device(TestData.ServiceAdminUsername, true);
            var device = new LinqMetaData().Device.FirstOrDefault(x => x.SerialNumber == "DeviceTest1");
            Assert.IsNotNull(device);
            // invoke to setup http and everything
            // TODO: do this for Webs services directly
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            controller.Invoke(x => x.Edit(device.DeviceId, new DeviceModel(device.DeviceId)
                                                               {
                                                                   DeviceState = DeviceState.Transitioning
                                                               }));

            var registration = new RegistrationService();
            registration.GetLocations();

            // test that all devices have a location
            var invalid = new LinqMetaData().Device.Where(x => x.Location == null);
            Assert.IsFalse(invalid.Any());

            // test that a device cannot be registered by a user outside of the organization
            var outsideUser =
                new LinqMetaData().User.FirstOrDefault(x => x.OrganizationId != device.Location.OrganizationId);
            Assert.IsNotNull(outsideUser);
            HttpContext.Current.User = new RolePrincipal(new GenericIdentity(outsideUser.Username));
            Thread.CurrentPrincipal = HttpContext.Current.User;
            try
            {
                registration = new RegistrationService();
                registration.RegisterDevice(device.Location.UniqueIdentifier, device.SerialNumber);
                Assert.Fail("User outside organization cannot register device.");
            }
            catch (WebFaultException<string> ex)
            {
                Assert.AreEqual(HttpStatusCode.PreconditionFailed, ex.StatusCode);
                Assert.AreEqual(Constants.StatusSubcode.LOCATION_INVALID, ex.Detail);
            }
        }

        protected override void TestCleanup()
        {
            var device = new LinqMetaData().Device.FirstOrDefault();
            Assert.IsNotNull(device);
            device.DeviceState = DeviceState.Active;
            device.Save();

            base.TestCleanup();
        }
    }
}
