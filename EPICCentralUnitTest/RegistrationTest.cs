using System;
using System.Security.Principal;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using EPICCentral;
using EPICCentral.Controllers;
using EPICCentral.Models;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;
using EPICCentralUnitTest;
using EPICCentralUnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace EPICCentralTest
{
	[TestClass]
	public class RegistrationTest : ControllerTest<AccountController>
	{
		private const string FIRST_NAME = "Unit_0123";
		private const string LAST_NAME = "Test_4567";
		private const string PIN = "test0987";
		private const string PASSWORD = "$Secret0";		// good password that will pass checks
		private const string USERNAME = "testuser99";	// valid username

		private static AccountRestrictionEntity testRestriction;

		[ClassInitialize]
		public new static void ClassInitialize(TestContext context)
		{
			ASPTest.ClassInitialize(context);
			Initialize();
		}

		[ClassCleanup]
		public new static void ClassCleanup()
		{
			ASPTest.ClassCleanup();
		}

		protected override void TestInitialize()
		{
		}

		protected override void TestCleanup()
		{
		}

		public override AccountController Mock()
		{
			var mockformsAuthenticationService = new Mock<Global.FormsAuthenticationService>();
			mockformsAuthenticationService.Setup(
				service => service.SetAuthCookie(It.IsAny<string>(), It.IsAny<bool>())).Callback<string, bool>(
					(s, b) => new RolePrincipal(new GenericIdentity(s)));
			mockformsAuthenticationService.Setup(x => x.SignOut()).Callback(() => { });
			Global.FormsAuthentication = mockformsAuthenticationService.Object;
			return Mock<AccountController>();
		}

		/// <summary>
		/// Satisfies requirement 4.1.4.3.3
		/// Satisfies requirement 4.1.4.3.4
		/// Satisfies requirement 4.1.4.3.9
		/// </summary>
		[TestMethod]
		public void Registration_Required_Fields()
		{
			var accountController = Mock();
			accountController.Invoke(x => x.Register(new RegisterModel()));
			Assert.IsTrue(accountController.ModelState["UserName"].Errors.Any());
			Assert.IsTrue(accountController.ModelState["Email"].Errors.Any());
			Assert.IsTrue(accountController.ModelState["Password"].Errors.Any());
			Assert.IsTrue(accountController.ModelState["Pin"].Errors.Any());
		}

		/// <summary>
		/// Satisfies requirement 4.1.4.3.3
		/// Satisfies requirement 4.1.4.3.6
		/// Satisfies requirement 4.1.4.3.9
		/// Satisfies requirement 4.7.1.1
		/// </summary>
		[TestMethod]
		public void Registration_Requires_Valid_Username()
		{
			// shorty1 is too short
			RunRegistration("UserName", username: "shorty1");
		}

		/// <summary>
		/// Satisfies requirement 4.1.4.3.3
		/// Satisfies requirement 4.1.4.3.9
		/// Satisfies requirement 4.7.1.2
		/// </summary>
		[TestMethod]
		public void Registration_Username_Contains_No_Space()
		{
			// "unit test" contains a space
			RunRegistration("", ControllerRes.Account.Invalid_UsernameBad, "unit test");
		}

		/// <summary>
		/// Satisfies requirement 4.1.4.3.3
		/// Satisfies requirement 4.1.4.3.9
		/// </summary>
		[TestMethod]
		public void Registration_Requires_Unique_Username()
		{
			// epicadmin is not unique
			RunRegistration("", ControllerRes.Account.Invalid_DuplicateUsername, "epicadmin");
		}

		/// <summary>
		/// Satisfies requirement 4.1.4.3.4
		/// Satisfies requirement 4.1.4.3.7
		/// Satisfies requirement 4.1.4.3.9
		/// Satisfies requirement 4.7.1.3
		/// </summary>
		[TestMethod]
		public void Registration_Password_Minimum_Length()
		{
			// password is less than 8 characters
			RunRegistration("Password", password: "$Secre0", confirmPassword: "$Secre0");
		}

		/// <summary>
		/// Satisfies requirement 4.1.4.3.4
		/// Satisfies requirement 4.1.4.3.7
		/// Satisfies requirement 4.7.1.3
		/// </summary>
		[TestMethod]
		public void Registration_Password_Maximum_Length()
		{
			// password is more than 24 characters
			RunRegistration("Password", password: "12345678901234567890$Zzyx", confirmPassword: "12345678901234567890$Zzyx");
		}

		/// <summary>
		/// Satisfies requirement 4.1.4.3.4
		/// Satisfies requirement 4.1.4.3.7
		/// Satisfies requirement 4.1.4.3.9
		/// Satisfies requirement 4.7.1.3
		/// </summary>
		[TestMethod]
		public void Registration_Password_Contains_No_Space()
		{
			// password cannot contain space
			RunRegistration("Password", password: "$Sec re0", confirmPassword: "$Sec re0");
		}

		/// <summary>
		/// Satisfies requirement 4.1.4.3.4
		/// Satisfies requirement 4.1.4.3.7
		/// Satisfies requirement 4.1.4.3.9
		/// Satisfies requirement 4.7.1.4
		/// </summary>
		[TestMethod]
		public void Registration_Password_Contains_Lowercase()
		{
			// password must contain lowercase character
			RunRegistration("Password", password: "$SECRET0", confirmPassword: "$SECRET0");
		}

		/// <summary>
		/// Satisfies requirement 4.1.4.3.4
		/// Satisfies requirement 4.1.4.3.7
		/// Satisfies requirement 4.1.4.3.9
		/// Satisfies requirement 4.7.1.4
		/// </summary>
		[TestMethod]
		public void Registration_Password_Contains_Uppercase()
		{
			// password must contain uppercase character
			RunRegistration("Password", password: "$secret0", confirmPassword: "$secret0");
		}

		/// <summary>
		/// Satisfies requirement 4.1.4.3.4
		/// Satisfies requirement 4.1.4.3.7
		/// Satisfies requirement 4.1.4.3.9
		/// Satisfies requirement 4.7.1.4
		/// </summary>
		[TestMethod]
		public void Registration_Password_Contains_Digit()
		{
			// password must contain uppercase character
			RunRegistration("Password", password: "$Secret$", confirmPassword: "$Secret$");
		}

		/// <summary>
		/// Satisfies requirement 4.1.4.3.4
		/// Satisfies requirement 4.1.4.3.7
		/// Satisfies requirement 4.1.4.3.9
		/// Satisfies requirement 4.7.1.4
		/// </summary>
		[TestMethod]
		public void Registration_Password_Contains_Symbol()
		{
			// password must contain a symbol character
			RunRegistration("Password", password: "Secret01", confirmPassword: "Secret01");
		}

		/// <summary>
		/// Satisfies requirement 4.1.4.3.5
		/// Satisfies requirement 4.1.4.3.8
		/// Satisfies requirement 4.1.4.3.9
		/// </summary>
		[TestMethod]
		public void Registration_ConfirmPassword_Password_Match()
		{
			// confirmed password must match password
			RunRegistration("ConfirmPassword", password: "$Secret0", confirmPassword: "$Secret1");
		}

		/// <summary>
		/// Satisfies requirement 4.1.4.3.1
		/// Satisfies requirement 4.1.4.3.2
		/// Satisfies requirement 4.1.4.3.3 (may use email for username)
		/// Satisfies requirement 4.1.4.3.10
		/// </summary>
		// All entries valid, account initialized, user logged in
		[TestMethod]
		public void Registration_Completes_Successfully()
		{
			var accountController = Mock();
			var model = GetGoodModel();
			// use email as username for req 4.1.4.3.3
			model.UserName = TestData.ServiceAdminSupportEmail;
			accountController.Invoke(x => x.Register(model));
			Assert.IsTrue(accountController.ModelState.IsValid);
			Assert.AreEqual("/", accountController.Response.RedirectLocation);
		}

		private void RunRegistration(string property, string expectedError = null, string username = null, string password = null, string confirmPassword = null)
		{
			var accountController = Mock();
			var model = GetGoodModel();
			if (username != null)
				model.UserName = username;
			if (password != null)
				model.Password = password;
			if (confirmPassword != null)
				model.ConfirmPassword = confirmPassword;
			accountController.Invoke(x => x.Register(model));
			Assert.IsNotNull(accountController.ModelState[property], "Register method produced no error.");
			Assert.IsTrue(accountController.ModelState[property].Errors.Any());
			if (expectedError != null)
				Assert.IsTrue(accountController.ModelState[property].Errors[0].ErrorMessage == expectedError);
		}

		private static RegisterModel GetGoodModel()
		{
			return new RegisterModel
			       	{
						Email = TestData.ServiceAdminSupportEmail,
						RegistrationKey = testRestriction.RestrictionKey,
						Pin = PIN,
						OriginalEmail = TestData.ServiceAdminSupportEmail,
						Password = PASSWORD,
						ConfirmPassword = PASSWORD,
						UserName = USERNAME
					};
		}

		private static void Initialize()
		{
			var mockUserController = Mock<UserController>();
			var request1 = mockUserController.Mock(x => x.ControllerContext.HttpContext.Request);
			request1.SetupGet(x => x.HttpMethod).Returns("POST");
			mockUserController.HttpContext.User = new RolePrincipal(new GenericIdentity(TestData.OrgAdminUsername));
			mockUserController.ControllerContext.RouteData.Values.Add("model",
																	  new AddUserModel
																	  {
																		  FirstName = FIRST_NAME,
																		  LastName = LAST_NAME,
																		  EmailAddress = TestData.ServiceAdminSupportEmail,
																		  Role = TestData.OrgAdminRoleId,
																		  OrganizationId = TestData.EndUserOrgId,
																		  Pin = PIN
																	  });
			mockUserController.ControllerContext.RouteData.Values.Add("organizationId", TestData.EndUserOrgId);
			mockUserController.Invoke("Add");
			Assert.AreEqual(200, mockUserController.Response.StatusCode);

			var testUser = new LinqMetaData().User.First(u => u.FirstName == FIRST_NAME && u.LastName == LAST_NAME && u.EmailAddress == TestData.ServiceAdminSupportEmail);
			testRestriction = testUser.UserAccountRestrictions[0].AccountRestriction;
		}
	}
}
