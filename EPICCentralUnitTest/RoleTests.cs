using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Security.Principal;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Mvc;
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
    public class RoleTests : UserControllerTest
    {
        /// <summary>
        /// Satisfies requirement 4.1.5.1
        /// </summary>
        [TestMethod]
        public void Access_To_Functions_Depends_On_Role()
        {
            // get menu from one role

            // make sure menu changes under a different role
        }

        /// <summary>
        /// satisfies method 4.1.5.2
        /// </summary>
        [TestMethod]
        public void Users_Must_Have_One_Role()
        {
            // check all the users in the database for one role
            var multiRoles = new LinqMetaData().User.Where(x => x.Roles.Count() != 1);
            Assert.IsTrue(!multiRoles.Any());

            // there is no other tests we can do because there is no way to put multiple roles in to the system
        }

        /// <summary>
        /// Satisfies requirement 4.1.5.3.1
        /// </summary>
        [TestMethod]
        public void Minimum_Of_Three_Roles()
        {
            var roles = new LinqMetaData().Role;
            Assert.IsTrue(roles.Count() >= 3);
        }

        /// <summary>
        /// Satisfies requirement 4.1.5.3.4
        /// Satisfies requirement 4.1.5.4.4
        /// </summary>
        [TestMethod]
        public void Simple_User_Cannot_Edit_Other_Users()
        {
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.SimpleUserUsername));

            // set the userId
            controller.RouteData.Values.Add("userId", TestData.OrgAdminUserId);
            controller.Invoke("Edit");

            Assert.AreEqual(401, controller.Response.StatusCode);
            // no interface for assigning roles other than the access denied above
            // make sure we can access EditMe just in case
            controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.SimpleUserUsername));

            // set the userId
            controller.Invoke("EditMe");

            Assert.AreNotEqual(401, controller.Response.StatusCode);
        }

        /// <summary>
        /// Satisfies requirement 4.1.5.4.2
        /// Satisfies requirement 4.1.5.4.6
        /// </summary>
        [TestMethod]
        public void Service_Administrator_Can_Assign_Any_Role()
        {
            // create a test user
            Create_Edit_User(TestData.ServiceAdminUsername, true);

        	var user = TestData.ServiceAdminUser;
            var testUser = new LinqMetaData().User.FirstOrDefault(x => x.FirstName == TestValues["FirstName"]);
            var profile = new UserSettingEntity(user.UserId, "SupportUser") { UserId = user.UserId, Name = "SupportUser" };
            Assert.IsFalse(profile.IsNew);
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
                                    new[] { "date", "subject", "from", "content-type", "to", "cc", "message-id" }));
            var message =
                msgs.Where(x => x.Subject.Contains(ControllerRes.Account.Email_SubjectUserRegistration)).
                    OrderByDescending(x => x.Date).FirstOrDefault();
            Assert.IsNotNull(message);

            message = imap.GetMessage(message.Uid, false, false);
            // make sure the link matches the current test user in the database
            var match = Regex.Match(message.Body, "RegistrationKey=([a-zA-Z0-9]*)");
            Assert.IsTrue(match.Success);

            // register the test user
            var controller = Mock<AccountController>();
            var request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");

            // mock global forms authentication
            var mockformsAuthenticationService = new Mock<Global.FormsAuthenticationService>();
            mockformsAuthenticationService.Setup(
                service => service.SetAuthCookie(It.IsAny<string>(), It.IsAny<bool>())).Callback<string, bool>(
                    (s, b) => new RolePrincipal(new GenericIdentity(s)));
            mockformsAuthenticationService.Setup(x => x.SignOut()).Callback(() => { });
            Global.FormsAuthentication = mockformsAuthenticationService.Object;

            // submit test values
            request.SetupGet(x => x.Form).Returns(() => new NameValueCollection
                                                            {
                                                                {"UserName", TestValues["FirstName"]},
                                                                {"Email", profile.Value + '@' + SupportController.DOMAIN},
                                                                {"Password", "Th1s|sAV4lidPa$$w0rd"},
                                                                {"ConfirmPassword", "Th1s|sAV4lidPa$$w0rd"},
                                                                {"Pin", "1234"},
                                                                {"OriginalEmail", profile.Value + '@' + SupportController.DOMAIN},
                                                                {"RegistrationKey", match.Groups[1].Value}
                                                            });
            controller.Invoke("Register");
            testUser = new LinqMetaData().User.FirstOrDefault(x => x.Username == TestValues["FirstName"]);
            Assert.IsNotNull(testUser);

            // change the role
            var userController = Mock();
            userController.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            request = userController.Mock(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");

            // set the userId
            userController.RouteData.Values.Add("userId", testUser.UserId);
            TestValues["Role"] = OrganizationUtils.GetAllowedRoles(testUser.OrganizationId)
                .First(x => !testUser.Roles.Any(y => y.RoleId == x.RoleId)).RoleId.ToString(CultureInfo.InvariantCulture);
            request.SetupGet(x => x.Form).Returns(() => TestValues);
            userController.Invoke("Edit");
            testUser = new LinqMetaData().User.FirstOrDefault(x => x.FirstName == TestValues["FirstName"]);
            Assert.IsNotNull(testUser);
            Assert.AreEqual(TestValues["Role"], testUser.Roles.Single().RoleId.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Satisfies requirement 4.1.5.4.3
        /// </summary>
        [TestMethod]
        public void Organization_Administrator_Can_Assign_Roles()
        {
            try
            {
                // assigns a role
                Create_Edit_User(TestData.OrgAdminUsername, true);

                var testUser = new LinqMetaData().User.FirstOrDefault(x => x.FirstName == TestValues["FirstName"]);
                Assert.IsNotNull(testUser);

                // try to elevate to service administrator
                var controller = Mock();
                controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.OrgAdminUsername));
                var request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
                request.Setup(x => x.HttpMethod).Returns("POST");

                // set the userId
                controller.RouteData.Values.Add("userId", testUser.UserId);

                // set the role to service administrator
                TestValues["Role"] = TestData.ServiceAdminRoleId.ToString(CultureInfo.InvariantCulture);
                request.SetupGet(x => x.Form).Returns(() => TestValues);
                controller.Invoke("Edit");
                Assert.Fail("Changing the role to Service Administrator should not be allowed by organization administrators.");
            }
            catch(HttpException ex)
            {
                Assert.AreEqual(417, ex.GetHttpCode());
            }
        }

        /// <summary>
        /// Satisfies requirement 4.1.5.4.7
        /// </summary>
        [TestMethod]
        public void Role_Change_Takes_Effect_Immediately()
        {
            // create the test user
            Create_Edit_User(TestData.ServiceAdminUsername, true);
            var testUser = new LinqMetaData().User.FirstOrDefault(x => x.FirstName == TestValues["FirstName"]);
            Assert.IsNotNull(testUser);

            // remove the restriction on the user account, this is faster than going through the registration process
            testUser.Username = "TestUser1";
            testUser.UserAccountRestrictions.DeleteMulti();
            testUser.Save();

            // check the menu
            var menuController = Mock<MenuController>();
            menuController.RouteData.DataTokens.Add("ParentActionViewContext", MockObjects.MockExtensions.Mock<ControllerContext>());
            menuController.HttpContext.User = new RolePrincipal(new GenericIdentity("TestUser1"));
            menuController.Invoke("ListMenu");
            var originalMenu = menuController.Response.Output.ToString();

            // change the role
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            var request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");

            // set the userId
            controller.RouteData.Values.Add("userId", testUser.UserId);

            // set the role to something else
            TestValues["Role"] = OrganizationUtils.GetAllowedRoles(testUser.OrganizationId)
                .First(x => !testUser.Roles.Any(y => y.RoleId == x.RoleId)).RoleId.ToString(CultureInfo.InvariantCulture);
            request.SetupGet(x => x.Form).Returns(() => TestValues);
            controller.Invoke("Edit");
            testUser = new LinqMetaData().User.FirstOrDefault(x => x.FirstName == TestValues["FirstName"]);
            Assert.IsNotNull(testUser);

            // make sure the role has changed
            Assert.AreEqual(testUser.Roles.First().RoleId.ToString(CultureInfo.InvariantCulture), TestValues["Role"]);

            // make sure menu items have changed
            menuController = Mock<MenuController>();
            menuController.RouteData.DataTokens.Add("ParentActionViewContext", MockObjects.MockExtensions.Mock<ControllerContext>());
            menuController.HttpContext.User = new RolePrincipal(new GenericIdentity("TestUser1"));
            menuController.Invoke("ListMenu");
            var newMenu = menuController.Response.Output.ToString();
            Assert.AreNotEqual(originalMenu, newMenu);
        }
    }
}
