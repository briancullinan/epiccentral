using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Security.Principal;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EPICCentral.Controllers;
using EPICCentral.Models;
using EPICCentralDL.Linq;
using EPICCentralUnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class LocationControllerTest : ControllerTest<LocationController>
    {
        private readonly NameValueCollection _testValues = new NameValueCollection();

        /// <summary>
        /// Satisfies requirement 4.1.2.1
        /// </summary>
        [TestMethod]
        public void Location_Must_Have_A_Name()
        {
            // submit a new location without a name and get back an error
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.OrgAdminUsername));
            var request =
                controller.Mock<LocationController, HttpRequestBase>(
                    x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");

            // fill in everything but the name
            request.SetupGet(x => x.Form).Returns(() =>
                                                      {
                                                          return new NameValueCollection
                                                                     {

                                                                     };
                                                      });
            controller.Invoke("Edit");
            Assert.AreEqual(417, controller.Response.StatusCode);
            Assert.IsTrue(controller.ModelState["Name"].Errors.Any());
        }

        /// <summary>
        /// Satisfies requirement 4.1.2.2
        /// </summary>
        [TestMethod]
        public void Location_Must_Have_Address_And_PhoneNumber()
        {
            // submit a new location without a name and get back an error
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.OrgAdminUsername));
            var request =
                controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");

            // submit an empty collection to get the errors
            request.SetupGet(x => x.Form).Returns(() => new NameValueCollection());
            controller.Invoke("Edit");
            Assert.AreEqual(417, controller.Response.StatusCode);
            Assert.IsTrue(controller.ModelState["AddressLine1"].Errors.Any());
            Assert.IsTrue(controller.ModelState["PhoneNumber"].Errors.Any());
        }

        /// <summary>
        /// Satisfies requirement 4.1.2.3
        /// </summary>
        [TestMethod]
        public void Service_Administrator_Can_Create_Edit_Locations()
        {
            Create_Edit_Location(TestData.ServiceAdminUsername);
        }

        private void Create_Edit_Location(string username)
        {
            // create a new location
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(username));
            var request =
                controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");

            // submit test values
            request.SetupGet(x => x.Form).Returns(() => _testValues);
            controller.Invoke("Edit");
            var location = new LinqMetaData().Location.FirstOrDefault(x => x.Name == _testValues["Name"]);
            Assert.IsNotNull(location);

            // edit the location
            controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(username));
            request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");

            // set the locationId
            controller.RouteData.Values.Add("locationId", location.LocationId);

            // change the name of the location
            _testValues["Name"] = "EPICLocationTest1";
            request.SetupGet(x => x.Form).Returns(() => _testValues);

            controller.Invoke("Edit");
            location = new LinqMetaData().Location.FirstOrDefault(x => x.Name == _testValues["Name"]);
            Assert.IsNotNull(location);

            // finally delete
            location.Delete();
        }

        /// <summary>
        /// Satisfies requirement 4.1.2.4
        /// </summary>
        [TestMethod]
        public void Organization_Administrator_Can_Create_Edit_Locations()
        {
            Create_Edit_Location(TestData.OrgAdminUsername);
        }

        /// <summary>
        /// Satisfies requirement 4.1.2.4
        /// </summary>
        [TestMethod]
        public void Organization_Administrator_Cannot_Edit_Outside_Organization()
        {
            try
            {
                var controller = Mock();
                controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.OrgAdminUsername));
                var request =
                    controller.Mock<LocationController, HttpRequestBase>(
                        x => x.ControllerContext.HttpContext.Request);
                request.Setup(x => x.HttpMethod).Returns("POST");

                // fill in everything but the name
                var location =
                    new LinqMetaData().Location.First(x => x.Organization.Users.All(y => y.Username != TestData.OrgAdminUsername));
                controller.RouteData.Values.Add("locationId", location.LocationId);
                request.SetupGet(x => x.Form).Returns(() =>
                                                          {
                                                              return new NameValueCollection
                                                                         {
                                                                             {"Name", "EPICLocationTest"},
                                                                         };
                                                          });
                controller.Invoke("Edit");
                Assert.Fail("Organization administrator should not be allowed to edit outside organization");
            }
            catch (HttpException ex)
            {
                Assert.AreEqual(401, ex.GetHttpCode());
            }
        }

        /// <summary>
        /// Satisfies requirement 4.1.2.5
        /// Satisfies requirement 4.1.2.6
        /// </summary>
        [TestMethod]
        public void Service_Administrator_Can_Set_Geocode()
        {
            // submit a new location without a name and get back an error
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            var request =
                controller.Mock<LocationController, HttpRequestBase>(
                    x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");

            // fill in everything but the name
            request.SetupGet(x => x.Form).Returns(() => _testValues);
            controller.Invoke("Edit");
            var location = new LinqMetaData().Location.FirstOrDefault(x => x.Name == _testValues["Name"]);
            Assert.IsNotNull(location);

            // test that geocode was automatically filled by our valid address above
            Assert.IsTrue(location.Latitude.HasValue);
            Assert.IsTrue(location.Longitude.HasValue);

            // test administrator can change values
            controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            request = controller.Mock<LocationController, HttpRequestBase>(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");
            controller.RouteData.Values.Add("locationId", location.LocationId);

            // modify the geocode
            const decimal newGeocode = (decimal)55.2039;
            _testValues["Latitude"] = newGeocode.ToString(CultureInfo.InvariantCulture);
            request.SetupGet(x => x.Form).Returns(() => _testValues);
            controller.Invoke("Edit");

            location = new LinqMetaData().Location.FirstOrDefault(x => x.Name == _testValues["Name"]);
            Assert.IsNotNull(location);
            Assert.AreEqual(newGeocode, location.Latitude);
            location.Delete();
        }


    	protected override void TestInitialize()
        {
            _testValues["Name"] = "EPICLocationTest";
            _testValues["AddressLine1"] = "8501 E Princess Dr";
            _testValues["City"] = "Scottsdale";
            _testValues["State"] = "AZ";
            _testValues["Country"] = "US";
            _testValues["PhoneNumber"] = "480-477-5242";
        }

    	protected override void TestCleanup()
        {
            _testValues.Clear();
            new LinqMetaData().Location.Where(x => x.Name == "EPICLocationTest" || x.Name == "EPICLocationTest1")
                .ToList().ForEach(x => x.Delete());
        }
    }
}
