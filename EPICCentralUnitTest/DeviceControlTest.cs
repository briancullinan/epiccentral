using System;
using System.Net;
using System.Security.Principal;
using System.ServiceModel.Web;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using EPICCentral;
using EPICCentral.Models;
using EPICCentral.REST.v0100.Registration;
using EPICCentral.REST.v0100.Scanning;
using EPICCentral.Utilities.DataLayer;
using EPICCentralDL.Customization;
using EPICCentralDL.Linq;
using EPICCentralServiceAPI.REST;
using EPICCentralServiceAPI.REST.Core;
using EPICCentralServiceAPI.REST.Objects;
using EPICCentralUnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class DeviceControlTest : DeviceControllerTest
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
        /// Satisfies requirement 4.3.2.2
        /// Satisfies requirement 4.3.2.3
        /// Satisfies requirement 4.3.2.4
        /// Satisfies requirement 4.3.2.6
        /// Satisfies requirement 4.3.2.7
        /// Satisfies requirement 4.6.1.4
        /// Satisfies requirement 4.3.1.7
        /// </summary>
        [TestMethod]
        public void Service_Administrator_Can_Set_State()
        {
            // find a device to modify
            Create_Edit_Device(TestData.ServiceAdminUsername, true);
            var device = new LinqMetaData().Device.FirstOrDefault(x => x.SerialNumber == "DeviceTest1");
            Assert.IsNotNull(device);

            // change the state
            var controller = Mock();
            controller.Invoke(x => x.Edit(device.DeviceId, new DeviceModel(device.DeviceId)
                                                               {
                                                                   DeviceState = DeviceState.Locked
                                                               }));

            // TODO: get validation information from wcf service
            var authToken = DeviceUtils.GetAuthenticationToken(device);
            HttpContext.Current.User = new RolePrincipal(new GenericIdentity(device.UniqueIdentifier));
            Thread.CurrentPrincipal = HttpContext.Current.User;
            if (Membership.ValidateUser(device.UniqueIdentifier, authToken))
            {
                try
                {
                    new ScanService().Validate(new ValidationKeys
                                                   {
                                                       LocationGuid = device.Location.UniqueIdentifier,
                                                       OrganizationGuid = device.Location.Organization.UniqueIdentifier
                                                   });
                    Assert.Fail("Validate should fail because device is not active.");
                }
                catch(WebFaultException<string> ex)
                {
                    Assert.AreEqual(Constants.StatusSubcode.DEVICE_STATE_INVALID, ex.Detail);
                    Assert.AreEqual(HttpStatusCode.NotAcceptable, ex.StatusCode);
                }
            }
            else
                Assert.Fail("Device should be authenticated.");

            // change the state
            controller = Mock();
            controller.Invoke(x => x.Edit(device.DeviceId, new DeviceModel(device.DeviceId)
                                                               {
                                                                   DeviceState = DeviceState.Active
                                                               }));
        }

        /// <summary>
        /// Satisfies requirement 4.3.2.5
        /// Satisfies requirement 4.3.2.8
        /// </summary>
        [TestMethod]
        public void Device_Can_Be_Taken_Out_Of_Service()
        {
            // find a device to modify
            Create_Edit_Device(TestData.ServiceAdminUsername, true);
            var device = new LinqMetaData().Device.FirstOrDefault(x => x.SerialNumber == "DeviceTest1");
            Assert.IsNotNull(device);

            // change the state
            var controller = Mock();
            controller.Invoke(x => x.Edit(device.DeviceId, new DeviceModel(device.DeviceId)
            {
                DeviceState = DeviceState.Retired
            }));

            // try to get the validate information
            var authToken = DeviceUtils.GetAuthenticationToken(device);
            HttpContext.Current.User = new RolePrincipal(new GenericIdentity(device.UniqueIdentifier));
            Thread.CurrentPrincipal = HttpContext.Current.User;
            if (Membership.ValidateUser(device.UniqueIdentifier, authToken))
            {
                try
                {
                    new ScanService().Validate(new ValidationKeys
                    {
                        LocationGuid = device.Location.UniqueIdentifier,
                        OrganizationGuid = device.Location.Organization.UniqueIdentifier
                    });
                    Assert.Fail("Validate should fail because device is not active.");
                }
                catch (WebFaultException<string> ex)
                {
                    Assert.AreEqual(Constants.StatusSubcode.DEVICE_STATE_INVALID, ex.Detail);
                    Assert.AreEqual(HttpStatusCode.NotAcceptable, ex.StatusCode);
                }
            }
            else
                Assert.Fail("Device should be authenticated.");
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
