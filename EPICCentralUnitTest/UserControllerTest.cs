using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Security.Principal;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Security;
using AE.Net.Mail;
using EPICCentral;
using EPICCentral.Controllers;
using EPICCentral.Utilities.DataLayer;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;
using EPICCentralUnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class UserControllerTest : ControllerTest<UserController>
    {
        protected readonly NameValueCollection TestValues = new NameValueCollection
                                                                 {
                                                                     {"This value", "Will be cleaned"}
                                                                 };

        /// <summary>
        /// Satisfies requirement 4.1.4.2.1
        /// Satisfies requirement 4.1.4.2.2
        /// Satisfies requirement 4.1.5.3.2
        /// Satisfies requirement 4.1.5.4.6
        /// </summary>
        [TestMethod]
        public void Administrator_Can_Create_Edit_Users()
        {
            Create_Edit_User(TestData.ServiceAdminUsername);
        }

        protected void Create_Edit_User(string username, bool dontDelete = false)
        {
            var user = new LinqMetaData().User.Single(x => x.Username == username);

            // get the location for the input username
            var organization = new LinqMetaData().Organization.First(x => x.Users.Any(y => y.Username == username));
            
            // make sure the user inbox is accessible
            var profile = new UserSettingEntity(user.UserId, "SupportUser") { UserId = user.UserId, Name = "SupportUser" };
            Assert.IsFalse(profile.IsNew);

            // set up a new user account with the email address set to the same as the passed in user
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(username));
            var request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");

            // fill in the missing user values
            TestValues["OrganizationId"] = organization.OrganizationId.ToString(CultureInfo.InvariantCulture);
            TestValues["Role"] = OrganizationUtils.GetAllowedRoles(organization.OrganizationId)
                .First().RoleId.ToString(CultureInfo.InvariantCulture);
            // set the e-mail address equal to the passed in user support center e-mail
            TestValues["EmailAddress"] = profile.Value + '@' + SupportController.DOMAIN;

            // submit test values
            request.SetupGet(x => x.Form).Returns(() => TestValues);
            controller.Invoke("Add");
            var testUser = new LinqMetaData().User.FirstOrDefault(x => x.FirstName == TestValues["FirstName"]);
            Assert.IsNotNull(testUser);
                
            // try to edit the user
            controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(username));
            request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");

            // set the userId
            controller.RouteData.Values.Add("userId", testUser.UserId);

            // username cannot be changed because registration is still pending at this point
            // just edit the first name
            TestValues["FirstName"] = "UserTest1";
            TestValues["IsActive"] = "true";
            TestValues["UserName"] = "UserTest1";
            request.SetupGet(x => x.Form).Returns(() => TestValues);
            controller.Invoke("Edit");
            testUser = new LinqMetaData().User.FirstOrDefault(x => x.FirstName == TestValues["FirstName"]);
            Assert.IsNotNull(testUser);

            // don't delete for further testing by the caller, which is responsible for cleanup
            if (!dontDelete)
            {
                var ars = testUser.UserAccountRestrictions.Select(y => y.AccountRestriction).ToList();
                testUser.UserAccountRestrictions.DeleteMulti();
                ars.ForEach(y => y.Delete());
                // finally delete the test user
                testUser.Delete();
            }
        }

        /// <summary>
        /// Satisfies requirement 4.1.4.2.3
        /// Satisfies requirement 4.1.5.3.3
        /// </summary>
        [TestMethod]
        public void Organization_Administrator_Can_Create_Edit_Users()
        {
            Create_Edit_User(TestData.OrgAdminUsername);
        }

        /// <summary>
        /// Satisfies requirement 4.1.4.2.4
        /// Satisfies requirement 4.1.4.2.5
        /// Satisfies requirement 4.1.4.4.1
        /// Satisfies requirement 4.1.5.4.1
        /// Satisfies requirement 4.1.5.4.5
        /// </summary>
        [TestMethod]
        public void User_Creation_Requires_Fields()
        {
            // set up a new user account with the email address set to the same as the passed in user
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            var request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");

            // create a new user with no values
            request.SetupGet(x => x.Form).Returns(() => new NameValueCollection
                                                            {
                                                                {"OrganizationId", TestData.ServiceHostOrgId.ToString(CultureInfo.InvariantCulture)}
                                                            });

            // submit test values
            controller.Invoke("Add");
            Assert.AreEqual(417, controller.Response.StatusCode);
            Assert.IsTrue(controller.ModelState["FirstName"].Errors.Any());
            Assert.IsTrue(controller.ModelState["LastName"].Errors.Any());
            Assert.IsTrue(controller.ModelState["EmailAddress"].Errors.Any());
            Assert.IsTrue(controller.ModelState["Role"].Errors.Any());
        }

        /// <summary>
        /// Satisfies requirement 4.1.4.2.6
        /// Satisfies requirement 4.1.4.2.7
        /// </summary>
        [TestMethod]
        public void User_Creation_Requires_Valid_Email()
        {
            // set up a new user account with the email address set to the same as the passed in user
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            var request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");

            // create a new user with no values
            request.SetupGet(x => x.Form).Returns(() => new NameValueCollection
                                                            {
                                                                {"OrganizationId", TestData.ServiceHostOrgId.ToString(CultureInfo.InvariantCulture)},
                                                                // provide an invalid e-mail address
                                                                {"EmailAddress", "this.is.not.valid"}
                                                            });

            // submit test values
            controller.Invoke("Add");
            Assert.AreEqual(417, controller.Response.StatusCode);
            Assert.IsTrue(controller.ModelState["EmailAddress"].Errors.Any());

            // set up a new user account with the email address set to the same as the passed in user
            controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");

            // create a new user with no values
            request.SetupGet(x => x.Form).Returns(() => new NameValueCollection
                                                            {
                                                                {"OrganizationId", TestData.ServiceHostOrgId.ToString(CultureInfo.InvariantCulture)},
                                                                // provide a valid e-mail address
                                                                {"EmailAddress", "valid@email.com"}
                                                            });

            // submit test values
            controller.Invoke("Add");
            Assert.AreEqual(417, controller.Response.StatusCode);
            Assert.IsTrue(!controller.ModelState["EmailAddress"].Errors.Any());
        }

        /// <summary>
        /// Satisfies requirement 4.1.4.2.8
        /// </summary>
        [TestMethod]
        public void User_Creation_Sends_Email()
        {
            // create a user to use during the test
            Create_Edit_User(TestData.ServiceAdminUsername, true);

        	var user = TestData.ServiceAdminUser;
            var testUser = new LinqMetaData().User.FirstOrDefault(x => x.FirstName == TestValues["FirstName"]);
            Assert.IsNotNull(testUser);
            Thread.Sleep(5000); // wait for exchange to deliver the e-mail

            // check the inbox for the e-mail
            var imap = SupportController.EnsureConnection(user);
            var msgCount = imap.SelectMailbox("INBOX").NumMsg;
            Assert.IsTrue(msgCount > 0);

            var msgs =
                imap.Search(SearchCondition.Deleted().Not()).Select(
                    x =>
                    imap.GetMessage(x, true, true,
                                    new[] {"date", "subject", "from", "content-type", "to", "cc", "message-id"}));
            var message =
                msgs.Where(x => x.Subject.Contains(ControllerRes.Account.Email_SubjectUserRegistration)).
                    OrderByDescending(x => x.Date).FirstOrDefault();
            Assert.IsNotNull(message);

            message = imap.GetMessage(message.Uid, false, false);
            // make sure the link matches the current test user in the database
            var match = Regex.Match(message.Body, "RegistrationKey=(([a-zA-Z0-9]{2})+)");
            Assert.IsTrue(match.Success);

            var restriction =
                testUser.UserAccountRestrictions.Select(x => x.AccountRestriction).SingleOrDefault(
                    x => x.RestrictionKey == match.Groups[1].Value);
            Assert.IsNotNull(restriction);

            // make sure key is unique
            restriction = new LinqMetaData().AccountRestriction.Single(x => x.RestrictionKey == match.Groups[1].Value);
            Assert.IsNotNull(restriction);

            var ars = testUser.UserAccountRestrictions.Select(y => y.AccountRestriction).ToList();
            testUser.UserAccountRestrictions.DeleteMulti();
            ars.ForEach(y => y.Delete());
            // finally delete the test user
            testUser.Delete();
        }

    	protected override void TestInitialize()
        {
            // some of the tests require a clean database to reference
            //  clean ahead of time just incase the last test was aborted
            if(TestValues.Count > 0)
                TestCleanup();
            TestValues["FirstName"] = "UserTest";
            TestValues["LastName"] = "UserTest";
            TestValues["Pin"] = "1234";
        }

    	protected override void TestCleanup()
        {
            TestValues.Clear();
            new LinqMetaData().User
                .Where(x => x.FirstName == "UserTest" || x.FirstName == "UserTest1")
                .ToList().ForEach(x =>
                                      {
                                          var ars = x.UserAccountRestrictions.Select(y => y.AccountRestriction).ToList();
                                          x.UserAccountRestrictions.DeleteMulti();
                                          ars.ForEach(y => y.Delete());
                                          x.Delete();
                                      });
        }
    }
}
