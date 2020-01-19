using System;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using EPICCentral.Controllers;
using EPICCentralDL.HelperClasses;
using EPICCentralDL.Linq;
using EPICCentralUnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class CreditCardTest : ControllerTest<PurchaseController>
    {
        /// <summary>
        /// Satisfies requirement 4.2.5.1.1
        /// </summary>
        [TestMethod]
        public void Uses_External_Payment_Gateway()
        {
            // make sure payment gateway is references in EPIC Central
            var references = Assembly.GetAssembly(typeof (EPICCentral.Global)).GetReferencedAssemblies().Select(x => x.Name);
            Assert.IsTrue(references.Contains(
                Assembly.GetAssembly(typeof (AuthorizeNet.CustomerGateway)).GetName().Name));
        }

        /// <summary>
        /// Satisfies requirement 4.2.5.1.2
        /// Satisfies requirement 4.2.5.1.3
        /// Satisfies requirement 4.2.5.1.4
        /// </summary>
        [TestMethod]
        public void Does_Not_Store_Credit_Card_Numbers()
        {
            // check database for credit card numbers or last 4 digits
            Assert.IsFalse(new LinqMetaData().CreditCard.Any(x => x.AccountNumber.Length > 4));

            // check that there is an address column
            Assert.IsTrue(typeof(CreditCardFields).GetProperties().Any(x => x.Name == "Address"));
        }

        /// <summary>
        /// Satisfies requirement 4.2.5.1.5
        /// </summary>
        [TestMethod]
        public void Credit_Card_Required_Fields()
        {
            var controller = Mock();
            controller.Invoke(x => x.AddCard(null));
            // check that security code is required
            Assert.IsTrue(controller.ModelState["SecurityCode"].Errors.Any());
        }

        /// <summary>
        /// Satisfies requirement 4.2.5.1.6
        /// </summary>
        [TestMethod]
        public void Credit_Card_Can_Be_Selected()
        {
            // find a user with a credit card
            var user = new LinqMetaData().User.FirstOrDefault(x => x.UserCreditCards.Any());
            // TODO: make a user with credit cards
            Assert.IsNotNull(user);
            var controller = Mock();
            controller.HttpContext.User = new RolePrincipal(new GenericIdentity(user.Username));
            controller.Invoke(x => x.Checkout(null, null));

            // make sure credit card is available on the checkout screen
            Assert.IsTrue(controller.Response.Output.ToString().Contains("<option value=\"" + user.UserCreditCards.First().CreditCardId));
        }

        protected override void TestInitialize()
        {
        }

        protected override void TestCleanup()
        {
        }
    }
}
