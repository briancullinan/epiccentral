using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.Compilation;
using System.Web.Helpers;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Razor.Parser;
using System.Web.Routing;
using EPICCentral;
using EPICCentral.Controllers;
using EPICCentral.Utilities.Virtual;
using EPICCentralUnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using Encoding = System.Text.Encoding;
using MockExtensions = EPICCentralUnitTest.MockObjects.MockExtensions;

namespace EPICCentralUnitTest
{
    [TestClass]
    public abstract class ASPTest
    {
        internal static DateTime StartTime;
    	private static TestContext testContext;

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            // take a timestamp to rollback to
            StartTime = DateTime.UtcNow;

			// Initialize database.
        	testContext = context;
			Database.Initialize(context);
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            // Revert all database changes.
			Database.Revert(testContext);
        }

        /// <summary>
        /// Force overriding classes to clean up their test
        /// </summary>
        protected abstract void TestInitialize();

        /// <summary>
        /// Force overriding classes to clean up their test
        /// </summary>
        protected abstract void TestCleanup();

        [TestInitialize]
        public void BaseTestInitialize()
        {
            RegisterRoutes();
            TestInitialize();
        }

        [TestCleanup]
        public void BaseTestCleanup()
        {
            TestCleanup();
        }

        /// <summary>
        /// Registers the routes for RouteTable
        /// </summary>
        [ClassInitialize]
        protected static void ClassInitialize(TestContext context)
        {
			RegisterRoutes();
		}

        /// <summary>
        /// Clear the routes
        /// </summary>
        [ClassCleanup]
        protected static void ClassCleanup()
        {
			RouteTable.Routes.Clear();
        }

		private static void RegisterRoutes()
		{
            if (RouteTable.Routes.Count == 0)
            {
                Global.RegisterRoutes(RouteTable.Routes);
                Global.RegisterGlobalFilters(GlobalFilters.Filters);
                /*Global.RegisterServiceRoutes(
                     RouteTable.Routes,
                     (s, @base, arg3) =>
                         {
                             var mockHandler = MockExtensions.Mock<IRouteHandler>();
                             mockHandler.Setup(x => x.GetHttpHandler(It.IsAny<RequestContext>())).Returns<RequestContext>
                                 (context => MockExtensions.Mock<IHttpHandler>().Object);
                             return new Route(s, mockHandler.Object);
                         });*/
            }
		}
    }

    public abstract class ControllerTest : ASPTest
    {
        public static C Mock<C>(params object[] args) where C : Controller, new()
        {
            var controller = Activator.CreateInstance(typeof(C), args) as Controller;
            var controllerContext = controller.Mock(x => x.ControllerContext);

            // setup view engines
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new MockRazorViewEngine());

            return controller as C;
        }
    }

    public abstract class ControllerTest<T> : ControllerTest where T : Controller, new()
    {
        public virtual T Mock()
        {
            return Mock<T>();
        }
    }
}
