using System;
using System.Security.Principal;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using EPICCentral.Controllers;
using EPICCentralDL.Customization;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;
using EPICCentralUnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class OrganizationControllerTest : ControllerTest<OrganizationController>
    {
        /// <summary>
        /// Satisfies requirement 4.1.1.1
        /// </summary>
        [TestMethod]
        public void Organizations_Have_Two_Types()
        {
            // add 1 more because [Not Selected] is included in the list
            Assert.AreEqual(3, OrganizationType.Host.ToSelectList().Count());
        }

        /// <summary>
        /// Satisfies requirement 4.1.1.3
        /// </summary>
        [TestMethod]
        public void One_And_Only_One_Host_Organization()
        {
            Assert.AreEqual(1, new LinqMetaData().Organization.Count(x => x.OrganizationType == OrganizationType.Host));
        }

        /// <summary>
        /// Satisfies requirement 4.1.1.4
        /// </summary>
        [TestMethod]
        public void User_Cannot_Create_Organization()
        {
            try
            {
                var controller = Mock();
                controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.OrgAdminUsername));
                var request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
                request.Setup(x => x.HttpMethod).Returns("POST");
                controller.Invoke("Edit");
                Assert.Fail("Security check should happen first.");
            }
            catch(HttpException ex)
            {
                Assert.AreEqual(401, ex.GetHttpCode());
            }
        }

        /// <summary>
        /// Satisfies requirement 4.1.1.4
        /// </summary>
        [TestMethod]
        public void Administrator_Can_Create_Organization()
        {
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.ServiceAdminUsername));
            var request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");
            controller.RouteData.Values.Add("organizationModel", new OrganizationEntity
                                                                     {
                                                                         Name = "EPICCentralTest",
                                                                         OrganizationType = OrganizationType.EndUser,
                                                                         IsActive = true
                                                                     });
            controller.Invoke("Edit");
            new LinqMetaData().Organization.First(x => x.Name == "EPICCentralTest").Delete();
            Assert.AreEqual("/Organization/View", controller.Response.RedirectLocation);
        }

        /// <summary>
        /// Satisfies requirement 4.1.1.5
        /// Satisfies requirement 4.1.1.6
        /// </summary>
        [TestMethod]
        public void An_Organization_Administrator_Can_Change_Name()
        {
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.OrgAdminUsername));
            var request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
            request.Setup(x => x.HttpMethod).Returns("POST");
            var organization = new LinqMetaData().Organization.First(x => x.Users.Any(y => y.Username == controller.HttpContext.User.Identity.Name));
            var oldName = organization.Name;
            controller.RouteData.Values.Add("organizationId", organization.OrganizationId);
            controller.RouteData.Values.Add("organizationModel", new OrganizationEntity
                                                                     {
                                                                         Name = "EPICCentralTest",
                                                                         OrganizationType = OrganizationType.EndUser,
                                                                         IsActive = true
                                                                     });
            controller.Invoke("Edit");
            organization = new LinqMetaData().Organization.First(x => x.OrganizationId == organization.OrganizationId);
            // test the rename was successful
            Assert.AreEqual("EPICCentralTest", organization.Name);
            
            // change it back
            organization.Name = oldName;
            organization.Save();
        }

        /// <summary>
        /// Satisfies requirement 4.1.1.6
        /// </summary>
        [TestMethod]
        public void Organization_Administrator_Can_Only_Edit_Their_Own()
        {
            try
            {
                var controller = Mock();
                controller.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.OrgAdminUsername));
                var request = controller.Mock(x => x.ControllerContext.HttpContext.Request);
                request.Setup(x => x.HttpMethod).Returns("POST");
                controller.RouteData.Values.Add("organizationId", TestData.ServiceHostOrgId);
                controller.RouteData.Values.Add("organizationModel", new OrganizationEntity
                                                                         {
                                                                             Name = "EPICCentralTest",
                                                                             OrganizationType = OrganizationType.EndUser,
                                                                             IsActive = true
                                                                         });
                controller.Invoke("Edit");
                Assert.Fail("Organization administrator should not be allowed to edit organization:0");
            }
            catch(HttpException ex)
            {
                Assert.AreEqual(401, ex.GetHttpCode());
            }
        }

    	protected override void TestInitialize()
        {
        }

    	protected override void TestCleanup()
        {
            new LinqMetaData().Organization.Where(x => x.Name == "EPICCentralTest").ToList().ForEach(x => x.Delete());
        }
    }
}
