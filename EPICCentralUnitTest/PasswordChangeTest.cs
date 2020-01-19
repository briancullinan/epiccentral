using System;
using System.Data;
using System.Security.Principal;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
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
    public class PasswordChangeTest : AccountControllerTest
    {
        /// <summary>
        /// Satisfies requirement 4.2.6.1.1
        /// Satisfies requirement 4.2.6.1.3
        /// Satisfies requirement 4.2.6.1.4
        /// </summary>
        [TestMethod]
        public void User_Can_Change_Password()
        {
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.OrgAdminUsername));
            controller.Invoke(x => x.ChangePassword(new ChangePasswordModel
                                                        {
                                                            OldPassword = TestData.OrgAdminPassword,
                                                            NewPassword = "TH15Is4Va!1dPas5w0rd",
                                                            ConfirmPassword = "TH15Is4Va!1dPas5w0rd"
                                                        }));

            Assert.AreEqual("/Account/ChangePasswordSuccess", controller.Response.RedirectLocation);
            // try to log in with the new credentials
            controller = Mock();
            var request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.SetupGet(x => x.HttpMethod).Returns("POST");
            controller.Invoke(x => x.LogOn(new LogOnModel
                                               {
                                                   UserName = TestData.OrgAdminUsername,
                                                   Password = "TH15Is4Va!1dPas5w0rd"
                                               }, null));
            Assert.AreEqual("/", controller.Response.RedirectLocation);
        }

        /// <summary>
        /// Satisfies requirement 4.2.6.1.2
        /// Satisfies requirement 4.2.6.1.3
        /// </summary>
        [TestMethod]
        public void Change_Password_Required_Fields()
        {
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.OrgAdminUsername));
            controller.Invoke(x => x.ChangePassword(new ChangePasswordModel
                                                        {
                                                            NewPassword = "Bad",
                                                            OldPassword = "",
                                                            ConfirmPassword = "NotTHeSame"
                                                        }));
            Assert.IsTrue(controller.ModelState["OldPassword"].Errors.Any());
            Assert.IsTrue(controller.ModelState["NewPassword"].Errors.Any());
            Assert.IsTrue(controller.ModelState["ConfirmPassword"].Errors.Any());
        }

        [ClassInitialize]
        public new static void ClassInitialize(TestContext context)
        {
            ASPTest.ClassInitialize(context);
            Cleanup();
        }

        private static void Cleanup()
        {
			var user = TestData.OrgAdminUser;
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
    }
}
