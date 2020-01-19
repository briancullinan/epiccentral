using System;
using System.Configuration;
using System.Security.Principal;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Security;
using EPICCentral.Controllers;
using EPICCentral.Models;
using EPICCentralDL.Linq;
using EPICCentralUnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class PurchaseControllerTest : ControllerTest<PurchaseController>
    {
        /// <summary>
        /// Satisfies requirement 4.2.5.2.1
        /// </summary>
        [TestMethod]
        public void Purchase_For_Organization_Devices()
        {
            // select a user the has access to some devices
        	var user = TestData.SimpleUser;
            // TODO: make a user with devices
            Assert.IsNotNull(user);

            // make sure devices are available on the new purchase screen
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(user.Username));
            controller.Invoke(x => x.Add(null, null));
            var devices = user.UserAssignedLocations.SelectMany(x => x.Location.Devices).ToList();
            devices.ForEach(entity => Assert.IsTrue(controller.Response.Output.ToString().Contains("<option value=\"" + entity.DeviceId)));
        }

        /// <summary>
        /// Satisfies requirement 4.2.5.2.2
        /// </summary>
        [TestMethod]
        public void Organization_Administrator_Purchase_For_Devices()
        {
            // select a user the has access to some devices
        	var user = TestData.OrgAdminUser;
            // TODO: make a user with devices
            Assert.IsNotNull(user);

            // make sure devices are available on the new purchase screen
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(user.Username));
            controller.Invoke(x => x.Add(null, null));
            var devices = user.Organization.Locations.SelectMany(x => x.Devices).ToList();
            devices.ForEach(entity => Assert.IsTrue(controller.Response.Output.ToString().Contains("<option value=\"" + entity.DeviceId)));
        }

        /// <summary>
        /// Satisfies requirement 4.2.5.2.3
        /// </summary>
        [TestMethod]
        public void Scans_Increment_When_Purchase_Complete()
        {
            // select a user with devices and credit cards already set up
        	var user = TestData.SimpleUser;
            // TODO: make a user with devices and credit cards
            Assert.IsNotNull(user);
            var device = new LinqMetaData().Device.First(x => x.Location.OrganizationId == user.OrganizationId);
            var scanRate = new LinqMetaData().ScanRate.WithPermissions().First();
            var countBefore = device.ScansAvailable;

            // make a purchase and confirm scans available is incremented
            var controller = Mock();
            var request = controller.Mock(x => x.HttpContext.Request);
            request.SetupGet(x => x.HttpMethod).Returns("POST");
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(user.Username));

            // set up session
			controller.HttpContext.Session["cart"] = new List<Purchase>
			                                             {
			                                                 new Purchase
			                                                     {
			                                                         DeviceId = device.DeviceId,
			                                                         ScanRateId = scanRate.ScanRateId,
			                                                         Quantity = scanRate.MinCountForRate
			                                                     }
			                                             };

            // make the purchase
            controller.Invoke(x => x.Checkout(new NewPurchaseModel
                                                  {
                                                      CreditCardId = user.UserCreditCards.First().CreditCardId
                                                  }, null));

            device = new LinqMetaData().Device.First(x => x.Location.OrganizationId == user.OrganizationId);
            Assert.AreEqual(countBefore + scanRate.MinCountForRate, device.ScansAvailable);
        }

        /// <summary>
        /// Satisfies requirement 4.2.5.2.4
        /// Satisfies requirement 4.2.5.2.5
        /// </summary>
        [TestMethod]
        public void Scans_Available_Are_Transferrable()
        {
            // find a device with available scans
            var fromDevice = new LinqMetaData().Device.FirstOrDefault(x => x.ScansAvailable > 0);
            Assert.IsNotNull(fromDevice);
            // find a device to transfer to
            var toDevice = new LinqMetaData().Device.FirstOrDefault(x => x.DeviceId != fromDevice.DeviceId);
            Assert.IsNotNull(toDevice);
            // TODO: make devices for transferring
            var fromQuantity = fromDevice.ScansAvailable;
            var toQuantity = toDevice.ScansAvailable;

            // wait at least 5 seconds incase of previous tests
            Thread.Sleep(5000);

            var controller = Mock();
            var request = controller.Mock(x => x.HttpContext.Request);
            request.SetupGet(x => x.HttpMethod).Returns("POST");
            controller.Invoke(x => x.List(null, null, new PurchaseHistoryModel
                                                          {
                                                              FromDeviceId = fromDevice.DeviceId,
                                                              ToDeviceId = toDevice.DeviceId,
                                                              Quantity = 1
                                                          }, null));
            fromDevice = new LinqMetaData().Device.Single(x => x.DeviceId == fromDevice.DeviceId);
            toDevice = new LinqMetaData().Device.Single(x => x.DeviceId == toDevice.DeviceId);
            Assert.AreEqual(fromQuantity - 1, fromDevice.ScansAvailable);
            Assert.AreEqual(toQuantity + 1, toDevice.ScansAvailable);
            Assert.AreEqual(1, fromDevice.PurchaseHistories.Count(x => x.PurchaseTime > DateTime.UtcNow.AddSeconds(-5)));
            Assert.AreEqual(1, toDevice.PurchaseHistories.Count(x => x.PurchaseTime > DateTime.UtcNow.AddSeconds(-5)));
        }

        /// <summary>
        /// Satisfies requirement 4.2.5.2.6
        /// </summary>
        [TestMethod]
        public void Purchase_Log_Search_Requirements()
        {
            var history = new LinqMetaData().PurchaseHistory.FirstOrDefault(x => x.Location.UserAssignedLocations.Any());
            Assert.IsNotNull(history);
            var user = history.Location.UserAssignedLocations.First().User;

            // make sure search is accessible
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(user.Username));
            controller.Invoke(x => x.List(null, null, null, null));

            // make sure the data table information was added to view data properly
            Assert.IsNotNull(controller.ViewData["DataTablesModels"] as Dictionary<string, object>);
            Assert.IsNotNull(((Dictionary<string, object>)
                              controller.ViewData["DataTablesModels"]).FirstOrDefault());

            var id = ((IDataTablesInitializationModel)
                      ((Dictionary<string, object>)
                       controller.ViewData["DataTablesModels"]).First().Value).ID;
            // do a search for that patient id
            controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(user.Username));
            controller.Invoke(x => x.List(null, null, null, new DataTablesRequestModel
                                                                {
                                                                    sEcho = 1,
                                                                    epicTableId = id,
                                                                    sSearch = history.PurchaseTime.ToShortDateString()
                                                                }));
            Assert.IsTrue(controller.Response.Output.ToString().Contains("\"DT_RowId\":\"" + history.PurchaseHistoryId + "\""));
            controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(user.Username));
            controller.Invoke(x => x.List(null, null, null, new DataTablesRequestModel
                                                          {
                                                              sEcho = 1,
                                                              epicTableId = id,
                                                              sSearch = history.Device.SerialNumber
                                                          }));
            Assert.IsTrue(controller.Response.Output.ToString().Contains("\"DT_RowId\":\"" + history.PurchaseHistoryId + "\""));
            controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(user.Username));
            controller.Invoke(x => x.List(null, null, null, new DataTablesRequestModel
                                                                 {
                                                                     sEcho = 1,
                                                                     epicTableId = id,
                                                                     sSearch = history.Location.Name
                                                                 }));
            Assert.IsTrue(controller.Response.Output.ToString().Contains("\"DT_RowId\":\"" + history.PurchaseHistoryId + "\""));
            controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(user.Username));
            controller.Invoke(x => x.List(null, null, null, new DataTablesRequestModel
                                                                {
                                                                    sEcho = 1,
                                                                    epicTableId = id,
                                                                    sSearch = history.ScansPurchased.ToString()
                                                                }));
            Assert.IsTrue(controller.Response.Output.ToString().Contains("\"DT_RowId\":\"" + history.PurchaseHistoryId + "\""));
        }

        protected override void TestInitialize()
        {
            // make sure we are in testing mode
            bool live;
            bool.TryParse(ConfigurationManager.AppSettings.Get("AuthorizeLive"), out live);
            Assert.IsFalse(live);
        }

        protected override void TestCleanup()
        {
        }
    }
}
