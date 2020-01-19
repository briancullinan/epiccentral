using System;
using System.Globalization;
using System.Security.Principal;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using EPICCentral.Controllers;
using EPICCentral.Models;
using EPICCentral.REST.v0100.Messaging;
using EPICCentral.Utilities.DataLayer;
using EPICCentralDL.Customization;
using EPICCentralDL.Linq;
using EPICCentralUnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class MessageControllerTest : ControllerTest<MessageController>
    {
        /// <summary>
        /// Satisfies requirement 4.4.2.1
        /// Satisfies requirement 4.4.2.2
        /// Satisfies requirement 4.4.2.3
        /// </summary>
        [TestMethod]
        public void Messages_Can_Be_Sent()
        {
            var organization = new LinqMetaData().Organization.FirstOrDefault(x => x.Locations.Any(y => y.Devices.Any()));
            Assert.IsNotNull(organization);

            var controller = Mock();
            controller.Invoke(x => x.Add(new ComposeMessage
                                             {
                                                 Body = "Test message.",
                                                 StartTime = DateTime.UtcNow.AddSeconds(5),
                                                 Title = "Test Message",
                                                 Type = MessageType.Marketing,
                                                 To =
                                                     "o:" +
                                                     organization.OrganizationId.ToString(CultureInfo.InvariantCulture)
                                             }));

            // make sure message is created for each device in the organization
            Assert.IsTrue(organization.Locations.All(x => x.Devices.All(y => y.DeviceMessages.Any(z => z.Message.Title == "Test Message"))));
        }

        /// <summary>
        /// Satisfies requirement 4.4.2.4
        /// Satisfies requirement 4.6.1.11
        /// Satisfies requirement 4.6.7
        /// </summary>
        [TestMethod]
        public void Message_Delivered_Only_Once()
        {
            // send some messages
            Messages_Can_Be_Sent();
            // wait for message to become active
            Thread.Sleep(5000);

            // get authentication for first device
            var organization = new LinqMetaData().Organization.First(x => x.Locations.Any(y => y.Devices.Any()));
            var device = organization.Locations.First(x => x.Devices.Any()).Devices.First();

            // deliver the messages
            HttpContext.Current.User = new RolePrincipal(new GenericIdentity(device.UniqueIdentifier));
            Thread.CurrentPrincipal = HttpContext.Current.User;
            var messages = new MessageService().GetCollection();
            Assert.IsTrue(messages.Any());
            messages = new MessageService().GetCollection();
            Assert.IsFalse(messages.Any());
        }

        /// <summary>
        /// Satisfies requirement 4.4.2.5
        /// </summary>
        [TestMethod]
        public void Message_Can_Be_Changed()
        {
            // create some messages
            Messages_Can_Be_Sent();

            // change the message
            var organization = new LinqMetaData().Organization.First(x => x.Locations.Any(y => y.Devices.Any()));
            var device = organization.Locations.First(x => x.Devices.Any()).Devices.First();
            var message = device.DeviceMessages.Last(x => x.Message.Title == "Test Message");

            var controller = Mock();
            controller.Invoke(x => x.Edit(message.MessageId, new ComposeMessage(message.Message)
                                                                 {
                                                                     Body = "Changed Test Message",
                                                                     StartTime = DateTime.UtcNow.AddSeconds(5),
                                                                 }));
            // wait for message to become active
            Thread.Sleep(5000);

            // make sure the device receives the changed message
            HttpContext.Current.User = new RolePrincipal(new GenericIdentity(device.UniqueIdentifier));
            Thread.CurrentPrincipal = HttpContext.Current.User;
            var messages = new MessageService().GetCollection();
            Assert.IsTrue(messages.Any(x => x.Body.Contains("Changed Test Message")));

        }

        /// <summary>
        /// Satisfies requirement 4.4.2.6
        /// </summary>
        [TestMethod]
        public void Message_Can_Be_Removed()
        {
            // create some messages
            Messages_Can_Be_Sent();

            // remove the message
            var organization = new LinqMetaData().Organization.First(x => x.Locations.Any(y => y.Devices.Any()));
            var device = organization.Locations.First(x => x.Devices.Any()).Devices.First();
            var message = device.DeviceMessages.Last(x => x.Message.Title == "Test Message");

            var controller = Mock();
            controller.Invoke(x => x.Remove(message.MessageId));
            device = new LinqMetaData().Device.Single(x => x.DeviceId == device.DeviceId);
            Assert.IsFalse(device.DeviceMessages.Any(x =>  x.Message.IsActive && x.MessageId == message.MessageId));
        }

        /// <summary>
        /// Satisfies requirement 4.4.2.7
        /// </summary>
        [TestMethod]
        public void Users_Cannot_Create_Messages()
        {
            var organization = new LinqMetaData().Organization.FirstOrDefault(x => x.Locations.Any(y => y.Devices.Any()));
            Assert.IsNotNull(organization);

            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.OrgAdminUsername));
            controller.Invoke(x => x.Add(new ComposeMessage
                                             {
                                                 Body = "Test message.",
                                                 StartTime = DateTime.UtcNow.AddSeconds(5),
                                                 Title = "Test Message",
                                                 Type = MessageType.Marketing,
                                                 To =
                                                     "o:" +
                                                     organization.OrganizationId.ToString(CultureInfo.InvariantCulture)
                                             }));
            Assert.AreEqual(401, controller.Response.StatusCode);
        }

        protected override void TestInitialize()
        {
        }

        protected override void TestCleanup()
        {
        }
    }
}
