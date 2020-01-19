using System;
using System.Security.Principal;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Security;
using AE.Net.Mail;
using EPICCentral.Controllers;
using EPICCentral.Models;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;
using EPICCentralUnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class SupportControllerTest : ControllerTest<SupportController>
    {
        /// <summary>
        /// Satisfies requirement 4.4.1.1
        /// Satisfies requirement 4.4.1.2
        /// Satisfies requirement 4.4.1.4
        /// </summary>
        [TestMethod]
        public void User_Can_Create_Message()
        {
            // pick two users to send to
            var users = new LinqMetaData().Organization.First(x => x.Users.Count(y => y.Settings.Any(z => z.Name == "SupportUser")) > 1).Users;
            Assert.IsTrue(users.Count() > 1);
            var fromUser = users.First(x => x.Settings.Any(y => y.Name == "SupportUser"));
            var toUser = users.Last(x => x.Settings.Any(y => y.Name == "SupportUser"));

            var controller = Mock();
            var request = controller.Mock(x => x.HttpContext.Request);
            request.SetupGet(x => x["Send"]).Returns("true");
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(fromUser.Username));
            controller.Invoke(x => x.Compose(new ComposeMail
                                                 {
                                                     Body = "This is a test.",
                                                     Subject = "Test Subject",
                                                     To =
                                                         toUser.Settings.First(y => y.Name == "SupportUser").Value + '@' +
                                                         SupportController.DOMAIN
                                                 }));
            Thread.Sleep(5000); // give exchange time to deliver it

            // check the inbox of the receiver
            using(var imap = SupportController.EnsureConnection(toUser))
            {
                var msgCount = imap.SelectMailbox("INBOX").NumMsg;
                Assert.IsTrue(msgCount > 0);

                var msgs =
                    imap.Search(SearchCondition.Deleted().Not()).Select(
                        x =>
                        imap.GetMessage(x, true, true,
                                        new[] { "date", "subject", "from", "content-type", "to", "cc", "message-id" }));
                var message =
                    msgs.Where(x => x.Subject.Contains("Test Subject")).
                        OrderByDescending(x => x.Date).FirstOrDefault();
                Assert.IsNotNull(message);

                message = imap.GetMessage(message.Uid, false, false);
                Assert.IsTrue(message.Body.Contains("This is a test."));
            }

        }

        /// <summary>
        /// Satisfies requirement 4.4.1.3
        /// </summary>
        [TestMethod]
        public void Message_Required_Fields()
        {
            var controller = Mock();
            var request = controller.Mock(x => x.HttpContext.Request);
            request.SetupGet(x => x["Send"]).Returns("true");
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            controller.Invoke(x => x.Compose(new ComposeMail()));
            Assert.IsTrue(controller.ModelState["Subject"].Errors.Any());
            Assert.IsTrue(controller.ModelState["To"].Errors.Any());
            Assert.IsTrue(controller.ModelState["Body"].Errors.Any());
        }

        /// <summary>
        /// Satisfies requirement 4.4.1.5
        /// </summary>
        [TestMethod]
        public void User_Can_View_Messages()
        {
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            controller.Invoke(x => x.Messages("INBOX", null));
            Assert.AreEqual(200, controller.Response.StatusCode);
        }

        /// <summary>
        /// Satisfies requirement 4.4.1.6
        /// </summary>
        [TestMethod]
        public void User_Can_Delete_Message()
        {
            // pick two users to send to
            var users = new LinqMetaData().Organization.First(x => x.Users.Count(y => y.Settings.Any(z => z.Name == "SupportUser")) > 1).Users;
            Assert.IsTrue(users.Count() > 1);
            var fromUser = users.First(x => x.Settings.Any(y => y.Name == "SupportUser"));
            var toUser = users.Last(x => x.Settings.Any(y => y.Name == "SupportUser"));

            var controller = Mock();
            var request = controller.Mock(x => x.HttpContext.Request);
            request.SetupGet(x => x["Send"]).Returns("true");
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(fromUser.Username));
            controller.Invoke(x => x.Compose(new ComposeMail
            {
                Body = "This is a test.",
                Subject = "Test Subject",
                To =
                    toUser.Settings.First(y => y.Name == "SupportUser").Value + '@' +
                    SupportController.DOMAIN
            }));
            Thread.Sleep(5000); // give exchange time to deliver it

            // check the inbox of the receiver
            using (var imap = SupportController.EnsureConnection(toUser))
            {
                var msgCount = imap.SelectMailbox("INBOX").NumMsg;
                Assert.IsTrue(msgCount > 0);

                var msgs =
                    imap.Search(SearchCondition.Deleted().Not()).Select(
                        x =>
                        imap.GetMessage(x, true, true,
                                        new[] { "date", "subject", "from", "content-type", "to", "cc", "message-id" }));
                var message =
                    msgs.Where(x => x.Subject.Contains("Test Subject")).
                        OrderByDescending(x => x.Date).FirstOrDefault();
                Assert.IsNotNull(message);

                message = imap.GetMessage(message.Uid, false, false);
                Assert.IsTrue(message.Body.Contains("This is a test."));

                controller = Mock();
                controller.Invoke(x => x.Delete("INBOX", message.Uid));
            }

        }

        protected override void TestInitialize()
        {
        }

        protected override void TestCleanup()
        {
        }
    }
}
