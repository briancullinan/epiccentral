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
    public class ExceptionControllerTest : ControllerTest<ExceptionController>
    {
        /// <summary>
        /// Satisfies requirement 4.5.1.1
        /// </summary>
        [TestMethod]
        public void Only_Service_Administrator_Can_View_Exceptions()
        {
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.OrgAdminUsername));
            controller.Invoke(x => x.List(null));
            Assert.AreEqual(401, controller.Response.StatusCode);
            controller = Mock();
            controller.Invoke(x => x.List(null));
        }

        /// <summary>
        /// Satisfies requirement 5.4.1.2
        /// </summary>
        [TestMethod]
        public void Exception_View_Fields()
        {
            var exception = new LinqMetaData().ExceptionLog.FirstOrDefault();
            Assert.IsNotNull(exception);

            var controller = Mock();
            controller.Invoke(x => x.View(exception.ExceptionLogId));
            Assert.IsTrue(controller.Response.Output.ToString().Contains(ViewRes.Exception.View_Serial));
            Assert.IsTrue(controller.Response.Output.ToString().Contains(ViewRes.Exception.View_Message));
            Assert.IsTrue(controller.Response.Output.ToString().Contains(ViewRes.Exception.View_StackTrace));
            Assert.IsTrue(controller.Response.Output.ToString().Contains(ViewRes.Exception.View_MachingName));
            Assert.IsTrue(controller.Response.Output.ToString().Contains(ViewRes.Exception.View_User));
            Assert.IsTrue(controller.Response.Output.ToString().Contains(ViewRes.Exception.View_MachineOS));
            Assert.IsTrue(controller.Response.Output.ToString().Contains(ViewRes.Exception.View_Version));
            Assert.IsTrue(controller.Response.Output.ToString().Contains(ViewRes.Exception.View_LogTime));
        }

        /// <summary>
        /// Satisfies requirement 5.4.1.3
        /// </summary>
        [TestMethod]
        public void Exception_Search_Fields()
        {
            var exception = new LinqMetaData().ExceptionLog.FirstOrDefault();
            Assert.IsNotNull(exception);

            var controller = Mock();
            controller.Invoke(x => x.List(null));

            // make sure the data table information was added to view data properly
            Assert.IsNotNull(controller.ViewData["DataTablesModels"] as Dictionary<string, object>);
            Assert.IsNotNull(((Dictionary<string, object>)
                              controller.ViewData["DataTablesModels"]).FirstOrDefault());

            var id = ((IDataTablesInitializationModel)
                      ((Dictionary<string, object>)
                       controller.ViewData["DataTablesModels"]).First().Value).ID;
            // do a search for each exception field
            controller = Mock();
            controller.Invoke(x => x.List(new DataTablesRequestModel
                                              {
                                                  sEcho = 1,
                                                  epicTableId = id,
                                                  sSearch = exception.Device.SerialNumber
                                              }));
            Assert.IsTrue(controller.Response.Output.ToString().Contains("\"DT_RowId\":\"" + exception.ExceptionLogId + "\""));
            controller = Mock();
            controller.Invoke(x => x.List(new DataTablesRequestModel
                                              {
                                                  sEcho = 1,
                                                  epicTableId = id,
                                                  sSearch = exception.Device.Location.Name
                                              }));
            Assert.IsTrue(controller.Response.Output.ToString().Contains("\"DT_RowId\":\"" + exception.ExceptionLogId + "\""));
            controller = Mock();
            controller.Invoke(x => x.List(new DataTablesRequestModel
                                              {
                                                  sEcho = 1,
                                                  epicTableId = id,
                                                  sSearch = exception.Title
                                              }));
            Assert.IsTrue(controller.Response.Output.ToString().Contains("\"DT_RowId\":\"" + exception.ExceptionLogId + "\""));
            controller = Mock();
            controller.Invoke(x => x.List(new DataTablesRequestModel
                                              {
                                                  sEcho = 1,
                                                  epicTableId = id,
                                                  sSearch = exception.LogTime.ToShortDateString()
                                              }));
            Assert.IsTrue(controller.Response.Output.ToString().Contains("\"DT_RowId\":\"" + exception.ExceptionLogId + "\""));
        }

        protected override void TestInitialize()
        {
        }

        protected override void TestCleanup()
        {
        }
    }
}
