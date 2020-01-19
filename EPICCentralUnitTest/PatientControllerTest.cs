using System;
using System.Security.Principal;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using EPICCentral.Controllers;
using EPICCentral.Models;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;
using EPICCentralUnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class PatientControllerTest : ControllerTest<PatientController>
    {
        /// <summary>
        /// Satisfies requirement 4.2.3.1
        /// Satisfies requirement 4.2.3.3
        /// </summary>
        [TestMethod]
        public void Users_Can_View_Patients_In_Organization()
        {
            // find a patient inside the organization
            var patient = new LinqMetaData().Patient.FirstOrDefault(x => x.Location.Organization.Users.Any());
            Assert.IsNotNull(patient);

            // make sure search is accessible
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(patient.Location.Organization.Users.First().Username));
            controller.Invoke(x => x.Index(null));

            // get user from controller
            var user = new LinqMetaData().User.SingleOrDefault(x => x.Username == controller.HttpContext.User.Identity.Name);
            Assert.IsNotNull(user);
            Assert.IsFalse(user.Username == "");

            // make sure the data table information was added to view data properly
            Assert.IsNotNull(controller.ViewData["DataTablesModels"] as Dictionary<string, object>);
            Assert.IsNotNull(((Dictionary<string, object>)
                              controller.ViewData["DataTablesModels"]).FirstOrDefault());

            var id = ((IDataTablesInitializationModel)
                      ((Dictionary<string, object>)
                       controller.ViewData["DataTablesModels"]).First().Value).ID;
            // do a search for that patient id
            controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(patient.Location.Organization.Users.First().Username));
            controller.Invoke(x => x.Index(new DataTablesRequestModel
                                               {
                                                   sEcho = 1,
                                                   epicTableId = id,
                                                   sSearch = "PatientId:" + patient.PatientId
                                               }));
            Assert.IsTrue(controller.Response.Output.ToString().Contains("\"iTotalDisplayRecords\":1"));
            Assert.IsTrue(controller.Response.Output.ToString().Contains("\"DT_RowId\":\"" + patient.PatientId + "\""));
        }

        /// <summary>
        /// Satisfies requirement 4.2.3.1
        /// </summary>
        [TestMethod]
        public void Users_Cannot_View_Patients_Outside_Organization()
        {
            var patient = new LinqMetaData().Patient.FirstOrDefault(x => x.Location.Organization.Users.Any(y => !y.Roles.Any(z => z.Role.RoleId == TestData.ServiceAdminRoleId)));
            Assert.IsNotNull(patient);
            var user = patient.Location.Organization.Users.FirstOrDefault(x => !x.Roles.Any(y => y.Role.RoleId == TestData.ServiceAdminRoleId));
            Assert.IsNotNull(user);

            // switch the patient to one outside of the organization
            patient = new LinqMetaData().Patient.FirstOrDefault(x => x.Location.OrganizationId != user.OrganizationId);
            Assert.IsNotNull(patient);

            // make sure search is accessible
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(user.Username));
            controller.Invoke(x => x.Index(null));

            // make sure the data table information was added to view data properly
            Assert.IsNotNull(controller.ViewData["DataTablesModels"] as Dictionary<string, object>);
            Assert.IsNotNull(((Dictionary<string, object>)
                              controller.ViewData["DataTablesModels"]).FirstOrDefault());

            var id = ((IDataTablesInitializationModel)
                      ((Dictionary<string, object>)
                       controller.ViewData["DataTablesModels"]).First().Value).ID;
            // do a search for that patient id
            controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(user.Username));
            controller.Invoke(x => x.Index(new DataTablesRequestModel
            {
                sEcho = 1,
                epicTableId = id,
                sSearch = "PatientId:" + patient.PatientId
            }));
            Assert.IsTrue(!controller.Response.Output.ToString().Contains("\"DT_RowId\":\"" + patient.PatientId + "\""));
        }

        [TestMethod]
        public void Users_Can_Search_Columns()
        {
            var patient = new LinqMetaData().Patient.FirstOrDefault(x => x.Location.Organization.Users.Any(y => !y.Roles.Any(z => z.Role.RoleId == TestData.ServiceAdminRoleId)));
            Assert.IsNotNull(patient);
            var user = patient.Location.Organization.Users.FirstOrDefault(x => !x.Roles.Any(y => y.Role.RoleId == TestData.ServiceAdminRoleId));
            Assert.IsNotNull(user);

            // make sure search is accessible
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(user.Username));
            controller.Invoke(x => x.Index(null));

            // make sure the data table information was added to view data properly
            Assert.IsNotNull(controller.ViewData["DataTablesModels"] as Dictionary<string, object>);
            Assert.IsNotNull(((Dictionary<string, object>)
                              controller.ViewData["DataTablesModels"]).FirstOrDefault());

            var id = ((IDataTablesInitializationModel)
                      ((Dictionary<string, object>)
                       controller.ViewData["DataTablesModels"]).First().Value).ID;
            // do a search for that patient id
            controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(user.Username));
            controller.Invoke(x => x.Index(new DataTablesRequestModel
            {
                sEcho = 1,
                epicTableId = id,
                sSearch = patient.FirstName
            }));
            Assert.IsTrue(controller.Response.Output.ToString().Contains("\"DT_RowId\":\"" + patient.PatientId + "\""));
            controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(user.Username));
            controller.Invoke(x => x.Index(new DataTablesRequestModel
            {
                sEcho = 1,
                epicTableId = id,
                sSearch = patient.BirthDate.ToShortDateString()
            }));
            Assert.IsTrue(controller.Response.Output.ToString().Contains("\"DT_RowId\":\"" + patient.PatientId + "\""));
            controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(user.Username));
            controller.Invoke(x => x.Index(new DataTablesRequestModel
            {
                sEcho = 1,
                epicTableId = id,
                sSearch = patient.Gender.ToString()
            }));
            Assert.IsTrue(controller.Response.Output.ToString().Contains("\"DT_RowId\":\"" + patient.PatientId + "\""));
        }

        /// <summary>
        /// Satisfies requirement 4.2.3.3
        /// </summary>
        [TestMethod]
        public void Service_Administrator_Can_View_All_Patients()
        {
            // make sure search is accessible
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            controller.Invoke(x => x.Index(null));

            // make sure the data table information was added to view data properly
            Assert.IsNotNull(controller.ViewData["DataTablesModels"] as Dictionary<string, object>);
            Assert.IsNotNull(((Dictionary<string, object>)
                              controller.ViewData["DataTablesModels"]).FirstOrDefault());

            var id = ((IDataTablesInitializationModel)
                      ((Dictionary<string, object>)
                       controller.ViewData["DataTablesModels"]).First().Value).ID;
            // do a search for that patient id
            controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            controller.Invoke(x => x.Index(new DataTablesRequestModel
            {
                sEcho = 1,
                epicTableId = id
            }));
            Assert.IsTrue(controller.Response.Output.ToString().Contains("\"iTotalRecords\":" + new LinqMetaData().Patient.Count()));
        }

        protected override void TestInitialize()
        {
        }

        protected override void TestCleanup()
        {
        }
    }
}
