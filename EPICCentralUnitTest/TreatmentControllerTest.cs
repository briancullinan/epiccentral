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
    public class TreatmentControllerTest : ControllerTest<TreatmentController>
    {
        /// <summary>
        /// Satisfies requirement 4.2.3.4
        /// Satisfies requirement 4.2.4.1
        /// </summary>
        [TestMethod]
        public void User_Can_View_Patient_Treatments()
        {
            // find a unique count of treatments
            var counts =
                new LinqMetaData().Patient
                    .Where(x => x.Location.Organization.Users.Any())
                    .Select(x => new {Patient = x, Count = x.Treatments.Count()}).ToList();
            var patientCount = counts.FirstOrDefault(x => counts.Count(y => y.Count == x.Count) == 1);
            Assert.IsNotNull(patientCount);
            var patient = patientCount.Patient;

            // make sure search is accessible
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(patient.Location.Organization.Users.First().Username));
            controller.Invoke(x => x.Index(null, patient.PatientId, null));

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
            controller.Invoke(x => x.Index(null, patient.PatientId, new DataTablesRequestModel
                                                                        {
                                                                            sEcho = 1,
                                                                            epicTableId = id
                                                                        }));

            // look for count of records
            Assert.IsTrue(controller.Response.Output.ToString().Contains("\"iTotalRecords\":" + patient.Treatments.Count()));
        }

        /// <summary>
        /// Satisfies requirement 4.2.4.2
        /// </summary>
        [TestMethod]
        public void User_Can_Search_Treatments()
        {
            var treatment = new LinqMetaData().Treatment.FirstOrDefault(x => x.Patient.Location.Organization.Users.Any(y => !y.Roles.Any(z => z.Role.RoleId == TestData.ServiceAdminRoleId)));
            Assert.IsNotNull(treatment);
            var user = treatment.Patient.Location.Organization.Users.FirstOrDefault(x => !x.Roles.Any(y => y.Role.RoleId == TestData.ServiceAdminRoleId));
            Assert.IsNotNull(user);

            // make sure search is accessible
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(user.Username));
            controller.Invoke(x => x.Index(null, null, null));

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
            controller.Invoke(x => x.Index(null, null, new DataTablesRequestModel
                                                           {
                                                               sEcho = 1,
                                                               epicTableId = id,
                                                               sSearch = treatment.Patient.FirstName
                                                           }));
            Assert.IsTrue(controller.Response.Output.ToString().Contains("\"DT_RowId\":\"" + treatment.TreatmentId + "\""));
            controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(user.Username));
            controller.Invoke(x => x.Index(null, null, new DataTablesRequestModel
                                                           {
                                                               sEcho = 1,
                                                               epicTableId = id,
                                                               sSearch = treatment.TreatmentTime.ToShortDateString()
                                                           }));
            Assert.IsTrue(controller.Response.Output.ToString().Contains("\"DT_RowId\":\"" + treatment.TreatmentId + "\""));
            controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(user.Username));
            controller.Invoke(x => x.Index(null, null, new DataTablesRequestModel
                                                           {
                                                               sEcho = 1,
                                                               epicTableId = id,
                                                               sSearch = treatment.Patient.Location.Name
                                                           }));
            Assert.IsTrue(controller.Response.Output.ToString().Contains("\"DT_RowId\":\"" + treatment.TreatmentId + "\""));
        }

        /// <summary>
        /// Satisfies requirement 4.2.4.3
        /// </summary>
        [TestMethod]
        public void Service_Administrator_Can_View_All_Treatments()
        {
            // make sure search is accessible
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            controller.Invoke(x => x.Index(null, null, null));

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
            controller.Invoke(x => x.Index(null, null, new DataTablesRequestModel
                                                           {
                                                               sEcho = 1,
                                                               epicTableId = id
                                                           }));
            Assert.IsTrue(controller.Response.Output.ToString().Contains("\"iTotalRecords\":" + new LinqMetaData().Treatment.Count()));
        }

        protected override void TestInitialize()
        {
        }

        protected override void TestCleanup()
        {
        }
    }
}
