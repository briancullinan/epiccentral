using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using AE.Net.Mail;
using EPICCentral.Controllers;
using EPICCentral.Models;
using EPICCentral.Providers;
using EPICCentralDL.HelperClasses;
using EPICCentralDL.Linq;
using EPICCentralTest;
using EPICCentralUnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class PasswordResetTest : AccountControllerTest
    {
        /// <summary>
        /// Satisfies requirement 4.2.6.2.1
        /// Satisfies requirement 4.2.6.2.3
        /// </summary>
        [TestMethod]
        public void User_Can_Reset_Password()
        {
            var user = new LinqMetaData().User.SingleOrDefault(x => x.Username == TestData.OrgAdminUsername);
            Assert.IsNotNull(user);
            var setting = user.Settings.SingleOrDefault(x => x.Name == "SupportUser");
            Assert.IsNotNull(setting);
            var controller = Mock();
            controller.Invoke(x => x.Reset(new ResetModel
                                               {
                                                   UserName = TestData.OrgAdminUsername,
                                                   Email = setting.Value + '@' + SupportController.DOMAIN
                                               }));
            Assert.AreEqual("/Account/ResetSuccess", controller.Response.RedirectLocation);
        }

        /// <summary>
        /// Satisfies requirement 4.2.6.2.2
        /// </summary>
        [TestMethod]
        public void Password_Reset_Required_Fields()
        {
            var controller = Mock();
            controller.Invoke(x => x.Reset(new ResetModel()));
            Assert.IsTrue(controller.ModelState["Email"].Errors.Any());
        }

        /// <summary>
        /// Satisfies requirement 4.2.6.2.4
        /// </summary>
        [TestMethod]
        public void Password_Reset_Email_Sent()
        {
            User_Can_Reset_Password();
			// must requery here to get UserEntity with associate restriction.
			var user = new LinqMetaData().User.FirstOrDefault(x => x.Username == TestData.OrgAdminUsername);
			Assert.IsNotNull(user);
            Thread.Sleep(5000); // wait for exchange to deliver the e-mail

            // check the inbox for the e-mail
            var imap = SupportController.EnsureConnection(user);
            var msgCount = imap.SelectMailbox("INBOX").NumMsg;
            Assert.IsTrue(msgCount > 0);

            var msgs =
                imap.Search(SearchCondition.Deleted().Not()).Select(
                    x =>
                    imap.GetMessage(x, true, true,
                                    new[] { "date", "subject", "from", "content-type", "to", "cc", "message-id" }));
            var message =
                msgs.Where(x => x.Subject.Contains(ControllerRes.Account.Email_SubjectPasswordReset)).
                    OrderByDescending(x => x.Date).FirstOrDefault();
            Assert.IsNotNull(message);

            message = imap.GetMessage(message.Uid, false, false);
            // make sure the link matches the current test user in the database
            var match = Regex.Match(message.Body, "ResetKey=(([a-zA-Z0-9]{2})+)", RegexOptions.IgnoreCase);
            Assert.IsTrue(match.Success);

            var restriction =
                user.UserAccountRestrictions.Select(x => x.AccountRestriction).SingleOrDefault(
                    x => x.RestrictionKey == match.Groups[1].Value);
            Assert.IsNotNull(restriction);

            // make sure key is unique
            restriction = new LinqMetaData().AccountRestriction.SingleOrDefault(x => x.RestrictionKey == match.Groups[1].Value);
            Assert.IsNotNull(restriction);
        }

        /// <summary>
        /// Satisfies requirement 4.2.6.2.5
        /// Satisfies requirement 4.2.6.2.7
        /// </summary>
        [TestMethod]
        public void Account_Restricted_Until_Reset_Complete()
        {
            // do password reset
            User_Can_Reset_Password();

            // try to log in
            var controller = Mock();
            controller.Invoke(x => x.LogOn(new LogOnModel
                                               {
                                                   UserName = TestData.OrgAdminUsername,
                                                   Password = TestData.OrgAdminPassword
                                               }, ""));
            Assert.IsTrue(controller.ModelState[""].Errors.Any());
        }

        /// <summary>
        /// Satisfies requirement 4.2.6.2.6
        /// </summary>
        [TestMethod]
        public void All_Accounts_Restricted_When_Email_Provided()
        {
            
        }

        /// <summary>
        /// Satisfies requirement 4.2.6.2.7
        /// Satisfies requirement 4.2.6.2.8
        /// </summary>
        [TestMethod]
        public void User_Can_Enter_New_Password()
        {
            User_Can_Reset_Password();
			// must requery here to get UserEntity with associate restriction.
        	var user = new LinqMetaData().User.FirstOrDefault(x => x.Username == TestData.OrgAdminUsername);
            Assert.IsNotNull(user);
            Thread.Sleep(5000); // wait for exchange to deliver the e-mail

            // check the inbox for the e-mail
            var imap = SupportController.EnsureConnection(user);
            var msgCount = imap.SelectMailbox("INBOX").NumMsg;
            Assert.IsTrue(msgCount > 0);

            var msgs =
                imap.Search(SearchCondition.Deleted().Not()).Select(
                    x =>
                    imap.GetMessage(x, true, true,
                                    new[] { "date", "subject", "from", "content-type", "to", "cc", "message-id" }));
            var message =
                msgs.Where(x => x.Subject.Contains(ControllerRes.Account.Email_SubjectPasswordReset)).
                    OrderByDescending(x => x.Date).FirstOrDefault();
            Assert.IsNotNull(message);

            message = imap.GetMessage(message.Uid, false, false);
            // make sure the link matches the current test user in the database
            var match = Regex.Match(message.Body, "ResetKey=(([a-zA-Z0-9]{2})+)", RegexOptions.IgnoreCase);
            Assert.IsTrue(match.Success);

            var restriction =
                user.UserAccountRestrictions.Select(x => x.AccountRestriction).SingleOrDefault(
                    x => x.RestrictionKey == match.Groups[1].Value);
            Assert.IsNotNull(restriction);

            // make sure key is unique
            restriction = new LinqMetaData().AccountRestriction.SingleOrDefault(x => x.RestrictionKey == match.Groups[1].Value);
            Assert.IsNotNull(restriction);

            // submit a new password
            var controller = Mock();
            controller.Invoke(x => x.ResetCompletion(new ResetCompletionModel
                                                         {
                                                             UserName = user.Username,
                                                             OriginalEmail = user.EmailAddress,
                                                             Password = "TH15Is4Va!1dPas5w0rd",
                                                             ConfirmPassword = "TH15Is4Va!1dPas5w0rd",
                                                             ResetKey = match.Groups[1].Value,
                                                             Step = 2
                                                         }));
            Assert.AreEqual("/Account/ResetCompletionSuccess", controller.Response.RedirectLocation);
        }

        /// <summary>
        /// Satisfies requirement 4.2.6.2.9
        /// </summary>
        [TestMethod]
        public void New_Password_Effective_Immediately()
        {
            // reset password
            User_Can_Enter_New_Password();

            // try to log in
            var controller = Mock();
            controller.Invoke(x => x.LogOn(new LogOnModel
                                               {
                                                   UserName = TestData.OrgAdminUsername,
                                                   Password = "TH15Is4Va!1dPas5w0rd"
                                               }, ""));
            Assert.AreEqual("/", controller.Response.RedirectLocation);
        }

        [ClassInitialize]
        public new static void ClassInitialize(TestContext context)
        {
            ASPTest.ClassInitialize(context);
            Cleanup();
        	var user = TestData.OrgAdminUser;
            Assert.IsNotNull(user);
            var setting = user.Settings.SingleOrDefault(x => x.Name == "SupportUser");
            Assert.IsNotNull(setting);
            user.EmailAddress = setting.Value + '@' + SupportController.DOMAIN;
            user.Save();
        }

        private static void Cleanup()
        {
			var user = new LinqMetaData().User.FirstOrDefault(x => x.Username == TestData.OrgAdminUsername);
			var transaction = new Transaction(IsolationLevel.ReadCommitted, "reset");
            EpicMembershipProvider.SetPassword(user, TestData.OrgAdminPassword, transaction);
            transaction.Add(user);
            user.Save();
            transaction.Commit();
        }

        [ClassCleanup]
        public new static void ClassCleanup()
        {
            Cleanup();
            ASPTest.ClassCleanup();
        }

        protected override void TestInitialize()
        {
            base.TestInitialize();
            TestCleanup();
        }

        protected override void TestCleanup()
        {
            new LinqMetaData().User
                .Where(x => x.FirstName == "UserTest" || x.FirstName == "UserTest1")
                .ToList().ForEach(x =>
                {
                    var ars = x.UserAccountRestrictions.Select(y => y.AccountRestriction).ToList();
                    x.UserAccountRestrictions.DeleteMulti();
                    ars.ForEach(y => y.Delete());
                    x.Delete();
                });
            // delete restrictions on epic admin
			var user = TestData.OrgAdminUser;
			Assert.IsNotNull(user);
            var adminArs = user.UserAccountRestrictions.Select(y => y.AccountRestriction).ToList();
            user.UserAccountRestrictions.DeleteMulti();
            adminArs.ForEach(y => y.Delete());
            var transaction = new Transaction(IsolationLevel.ReadCommitted, "reset");
            EpicMembershipProvider.SetPassword(user, TestData.OrgAdminPassword, transaction);
            transaction.Add(user);
            user.Save();
            transaction.Commit();

            base.TestCleanup();
        }
    }
}
