using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using EPICCentral;
using EPICCentral.Controllers;
using EPICCentral.Providers;
using EPICCentralUnitTest;
using EPICCentralUnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using EPICCentral.Models;
using Moq;

namespace EPICCentralTest
{


    /// <summary>
    ///This is a test class for AccountControllerTest and is intended
    ///to contain all AccountControllerTest Unit Tests
    ///</summary>
    [TestClass]
    public class AccountControllerTest : ControllerTest<AccountController>
    {
        public override AccountController Mock()
        {
            var mockformsAuthenticationService = new Mock<Global.FormsAuthenticationService>();
            mockformsAuthenticationService.Setup(
                service => service.SetAuthCookie(It.IsAny<string>(), It.IsAny<bool>())).Callback<string, bool>(
                    (s, b) => new RolePrincipal(new GenericIdentity(s)));
            mockformsAuthenticationService.Setup(x => x.SignOut()).Callback(() => { });
            Global.FormsAuthentication = mockformsAuthenticationService.Object;
            return base.Mock();
        }

        /// <summary>
        /// Satisfies requirement 4.1.4.1
        /// Satisfies requirement 4.2.1.1
        /// Test if authentication works properly.
        /// </summary>
        [TestMethod]
        public void User_Is_Not_Authenticated()
        {
            // test that index is not accessible
            var controller = Mock<HomeController>();
            controller.Invoke("Index");

            Assert.AreEqual(401, controller.Response.StatusCode);
        }

        /// <summary>
        /// Satisfies requirement 4.1.4.1
        /// Satisfies requirement 4.2.1.2
        /// Test if authentication works properly.
        /// </summary>
        [TestMethod]
        public void Credentials_Not_Persisted_By_Browser()
        {
            // test that index is not accessible
            var controller = Mock();
            controller.Invoke("LogOn");
            Assert.IsTrue(Regex.Match(controller.Response.Output.ToString(), "autocomplete\\s*=\\s*[\'\"]off", RegexOptions.IgnoreCase).Success);
        }

        /// <summary>
        /// Satisfies requirement 4.1.4.1
        /// Satisfies requirement 4.2.1.1
        /// </summary>
        [TestMethod]
        public void User_Can_Log_In()
        {
            // test log on works
            var controller = Mock();
            var request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.SetupGet(x => x.HttpMethod).Returns("POST");
            controller.ControllerContext.RouteData.Values.Add("model", new LogOnModel
                                                                            {
                                                                                UserName = TestData.OrgAdminUsername,
                                                                                Password = TestData.OrgAdminPassword
                                                                            });
            controller.Invoke("LogOn");
            Assert.AreEqual("/", controller.Response.RedirectLocation);
        }

        /// <summary>
        /// Satisfies requirement 4.2.1.1
        /// </summary>
        [TestMethod]
        public void User_Is_Authenticated()
        {
            var controller = Mock<HomeController>();
			controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.OrgAdminUsername));
            controller.ControllerContext.RouteData.Values.Add("model", new HomeModel());
            controller.Invoke("Index");
            Assert.IsTrue(!String.IsNullOrEmpty(controller.Response.Output.ToString()));
        }

        /// <summary>
        /// Satisfies requirement 4.2.1.3
        /// Satisfies requirement 4.2.1.4
        /// </summary>
        [TestMethod]
        public void LogOff_Disposes_Of_Session()
        {
            var controller = Mock();
            var session = controller.Mock(x => x.Session);
            controller.Mock(x => x.ControllerContext.HttpContext).Setup(x => x.Session).Returns(session.Object);
            var abandonCalled = false;
            session.Setup(x => x.Abandon()).Callback(() =>
                                                            {
                                                                abandonCalled = true;
                                                            });
            // test log off method
            controller.Invoke("LogOff");
            Assert.IsTrue(abandonCalled);
            Assert.AreEqual("/Account/LogOn", controller.Response.RedirectLocation);
        }

    	protected override void TestInitialize()
        {
        }

    	protected override void TestCleanup()
        {
        }
    }
}
