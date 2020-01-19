using System;
using System.Security.Principal;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using EPICCentral.Controllers;
using EPICCentralUnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class MenuTest : ControllerTest<MenuController>
    {
        /// <summary>
        /// Satisfies requirement 4.8.5.2
        /// </summary>
        [TestMethod]
        public void Link_To_Corporate_Site()
        {
            var menuController = Mock<MenuController>();
            menuController.RouteData.DataTokens.Add("ParentActionViewContext", MockExtensions.Mock<ControllerContext>());
            menuController.Invoke("ListMenu");
            var originalMenu = menuController.Response.Output.ToString();
            Assert.IsTrue(originalMenu.Contains("<a href=\"http://www.epicdiagnostics.com/\""));
        }

        protected override void TestInitialize()
        {
        }

        protected override void TestCleanup()
        {
        }
    }
}
