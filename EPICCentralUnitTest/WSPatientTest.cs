using System;
using System.IO;
using System.Security.Principal;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Security;
using EPICCentral.REST.v0100.Scanning;
using EPICCentralDL.Linq;
using EPICCentralServiceAPI.REST.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class WSPatientTest
    {
        /// <summary>
        /// Satisfies requirement 4.6.1.7
        /// Satisfies requirement 4.6.1.8
        /// </summary>
        [TestMethod]
        public void Web_Service_For_Adding_Patient()
        {
            // pick a device to test
            var device = new LinqMetaData().Device.FirstOrDefault(x => x.ScansAvailable > 0);
            Assert.IsNotNull(device);

            // setup service call
            var output = new StringWriter();
            var service = new PatientService();
            var url = new Uri("http://localhost/" + service.GetProperties().Url + "/add", UriKind.Absolute);
            HttpContext.Current = new HttpContext(
                new HttpRequest(url.AbsolutePath, url.AbsoluteUri, url.Query),
                new HttpResponse(output));
            HttpContext.Current.User = new RolePrincipal(new GenericIdentity(device.UniqueIdentifier));
            Thread.CurrentPrincipal = HttpContext.Current.User;

            // report the completed scan
            var patient = service.Add(new Patient
                                        {
                                            BirthDate = DateTime.UtcNow.AddYears(-18),
                                            EmailAddress = "test@email.com",
                                            FirstName = "TestFirst",
                                            LastName = "TestLast",
                                            Gender = Gender.Male,
                                            Guid = Guid.NewGuid().ToString(),
                                            MiddleInitial = "T",
                                            PhoneNumber = "555-555-5555"
                                        });

            // make sure patient was added
            var testPatient = new LinqMetaData().Patient.FirstOrDefault(x => x.BirthDate == patient.BirthDate);
            Assert.IsNotNull(testPatient);

            // update the patient information
            patient.BirthDate = DateTime.UtcNow.AddYears(-18);
            service.Update(patient);
            testPatient = new LinqMetaData().Patient.FirstOrDefault(x => x.BirthDate == patient.BirthDate);
            Assert.IsNotNull(testPatient);
        }


    }
}
