using System;
using System.Security.Principal;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using EPICCentral.Controllers;
using EPICCentral.Models;
using EPICCentralDL.Linq;
using EPICCentralUnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class InternationalizationTest : ControllerTest<UserController>
    {
        /// <summary>
        /// Satisfies requirement 4.8.3.1
        /// Satisfies requirement 4.8.3.2
        /// Satisfies requirement 4.8.3.3
        /// Satisfies requirement 4.8.3.4
        /// </summary>
        [TestMethod]
        public void User_Can_Change_Languages()
        {
            // request the page in English and compare it
            var controller = Mock();
            controller.Invoke(x => x.EditMe());
            Assert.IsTrue(controller.Response.Output.ToString().Contains("User Settings"));

            // change the users language
            var user = new LinqMetaData().User.FirstOrDefault(x => x.Username == controller.HttpContext.User.Identity.Name);
            Assert.IsNotNull(user);
            controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(user.Username));
            controller.Invoke(x => x.EditMe(new EditMeModel(user){Language = "de"}));

            Assert.AreEqual("/User/View", controller.Response.RedirectLocation);
            //var session = controller.Session;
            controller = Mock();
            //var httpContext = controller.Mock(x => x.ControllerContext.HttpContext);
            //httpContext.SetupGet(x => x.Session).Returns(session);
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(user.Username));
            controller.Invoke(x => x.EditMe());
            Assert.IsTrue(controller.Response.Output.ToString().Contains("Benutzer-Information"));
        }

        protected override void TestInitialize()
        {
        }

        protected override void TestCleanup()
        {
        }
    }
}
