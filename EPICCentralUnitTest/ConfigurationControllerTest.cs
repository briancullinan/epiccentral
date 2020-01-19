using System;
using System.Globalization;
using System.Security.Principal;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Security;
using EPICCentral.Controllers;
using EPICCentral.Models;
using EPICCentral.Providers;
using EPICCentral.Utilities.DataLayer;
using EPICCentralDL.Customization;
using EPICCentralDL.Linq;
using EPICCentralUnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class ConfigurationControllerTest : ControllerTest<ConfigurationController>
    {
        /// <summary>
        /// Satisfies requirement 4.1.6.1
        /// </summary>
        [TestMethod]
        public void Administrator_Can_Disable_Reenable_Device_Access()
        {
            var location = TestData.EndUserLoc;

            // create a device to use during the test
            var deviceController = Mock<DeviceController>();
            deviceController.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            var newDevice = new DeviceModel
                                {
                                    OrganizationId = location.OrganizationId,
                                    LocationId = location.LocationId,
                                    DeviceState = DeviceState.New,
                                    SerialNumber = "DeviceTest",
                                    RevisionLevel = "000",
                                    ScansAvailable = 10,
                                    PurchaseNotes = "This is a test."
                                };
            deviceController.Invoke(x => x.Edit(null, newDevice));
            var device = new LinqMetaData().Device.FirstOrDefault(x => x.SerialNumber == newDevice.SerialNumber);
            Assert.IsNotNull(device);

            // register device so we keep track of the authentication code
            var authToken = DeviceUtils.GetAuthenticationToken(device);
            Assert.IsTrue(new DeviceMembershipProvider().ValidateUser(device.UniqueIdentifier, authToken));

            // set the configuration setting
            var controller = Mock();
            controller.Invoke(x => x.EditSetting("Enabled", new EditSetting
                                                                {
                                                                    Name = "Enabled",
                                                                    Value = "False"
                                                                }));

            // try to access using service API
            Assert.IsFalse(new DeviceMembershipProvider().ValidateUser(device.UniqueIdentifier, authToken));
        }

        /// <summary>
        /// Satisfies requirement 4.1.7.1
        /// Satisfies requirement 4.1.7.2
        /// </summary>
        [TestMethod]
        public void Configuration_Only_Available_To_Administrators()
        {
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.OrgAdminUsername));
            controller.Invoke(x => x.Index(null));
            Assert.AreEqual(401, controller.Response.StatusCode);
        }

        /// <summary>
        /// Satisfies requirement 4.1.7.1
        /// </summary>
        [TestMethod]
        public void Administrator_Can_Create_Rates()
        {
            // create a new rate
            var controller = Mock();
            controller.Invoke(x => x.EditRate(null, new ScanRate
                                                        {
                                                            ScanType = ScanType.ClearViewScan,
                                                            RatePerScan = (decimal) 12345.67,
                                                            MinCountForRate = 10,
                                                            MaxCountForRate = 20,
                                                            EffectiveDate = DateTime.UtcNow,
                                                            IsActive = true
                                                        }));
            // confirm the rate was added
            var rate = new LinqMetaData().ScanRate.FirstOrDefault(x => x.RatePerScan == (decimal) 12345.67);
            Assert.IsNotNull(rate);

            // check purchases output for use of the new rate
            var purchaseController = Mock<PurchaseController>();
            purchaseController.Invoke(x => x.Add(null, null));
            Assert.IsTrue(purchaseController.Response.Output.ToString().Contains("<option value=\"" + rate.ScanRateId + "\""));

            rate.Delete();
        }

        /// <summary>
        /// Satisfies requirement 4.1.7.2
        /// </summary>
        [TestMethod]
        public void Purchase_Rate_Required_Fields()
        {
            var controller = Mock();
            controller.Invoke(x => x.EditRate(null, null));
            Assert.IsTrue(controller.ModelState["MinCountForRate"].Errors.Any());
            Assert.IsTrue(controller.ModelState["MaxCountForRate"].Errors.Any());
            Assert.IsTrue(controller.ModelState["RatePerScan"].Errors.Any());
        }

        /// <summary>
        /// Satisfies requirement 4.1.7.3
        /// </summary>
        [TestMethod]
        public void Effective_Date_Displayed_Rate_Properly()
        {
            // Create a test rate
            var controller = Mock();
            controller.Invoke(x => x.EditRate(null, new ScanRate
            {
                ScanType = ScanType.ClearViewScan,
                RatePerScan = (decimal)12345.67,
                MinCountForRate = 10,
                MaxCountForRate = 20,
                EffectiveDate = DateTime.UtcNow.AddSeconds(10),
                IsActive = true
            }));

            // make sure the rate was added successfully
            var rate = new LinqMetaData().ScanRate.FirstOrDefault(x => x.RatePerScan == (decimal)12345.67);
            Assert.IsNotNull(rate);

            // make sure test rate does not show in new purchase
            var purchaseController = Mock<PurchaseController>();
            purchaseController.Invoke(x => x.Add(null, null));
            Assert.IsFalse(purchaseController.Response.Output.ToString().Contains("<option value=\"" + rate.ScanRateId + "\""));

            // wait 10 seconds
            Thread.Sleep(10000);

            // make sure test rate shows in new purchase
            purchaseController = Mock<PurchaseController>();
            purchaseController.Invoke(x => x.Add(null, null));
            Assert.IsTrue(purchaseController.Response.Output.ToString().Contains("<option value=\"" + rate.ScanRateId + "\""));

        }

        protected override void TestInitialize()
        {
            // test depends on there being only one DeviceTest
            TestCleanup();
        }

        protected override void TestCleanup()
        {
            // remove old devices
            new LinqMetaData().Device.Where(x => x.SerialNumber == "DeviceTest" || x.SerialNumber == "DeviceTest1")
                .ToList().ForEach(x =>
                {
                    x.PurchaseHistories.DeleteMulti();
                    x.Delete();
                });
            var setting = new LinqMetaData().SystemSetting.Single(x => x.Name == "Enabled");
            setting.Value = "True";
            setting.Save();

            // remove old rates
            new LinqMetaData().ScanRate.Where(x => x.RatePerScan == (decimal) 12345.67).ToList().ForEach(x => x.Delete());
        }
    }
}
