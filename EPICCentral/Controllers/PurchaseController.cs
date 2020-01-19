using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using AuthorizeNet;
using ControllerRes;
using EPICCentral.Models;
using EPICCentral.Utilities.Attributes;
using EPICCentral.Utilities.Membership;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;
using log4net;
using Purchase = ControllerRes.Purchase;
using Transaction = EPICCentralDL.HelperClasses.Transaction;

namespace EPICCentral.Controllers
{
    /// <summary>
    /// Controls all Purchase related interactions from listing the purchase history to completing new purchases of scans.
    /// </summary>
    public class PurchaseController : DataTablesController
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(PurchaseController));

        /// <summary>
        /// Gets the list of devices available to make purchases for.
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        public IQueryable<DeviceEntity> GetDevices(int? locationId, int? organizationId)
        {
            if (!organizationId.HasValue)
            {
                if (!locationId.HasValue)
                {
                    // show default list of purchases
                    return new LinqMetaData().Device.WithPermissions();
                }
                else
                {
                    var location = new LocationEntity(locationId.Value);
                    if (location.IsNew)
                        throw new HttpException(404, SharedRes.Error.NotFound_Location);

                    if (!Permissions.UserHasPermission("View", location))
                        throw new HttpException(401, SharedRes.Error.Unauthorized_Location);

                    return new LinqMetaData().Device.Where(x => x.LocationId == locationId.Value);
                }
            }
            else
            {
                var organization = new OrganizationEntity(organizationId.Value);
                if (organization.IsNew)
                    throw new HttpException(404, SharedRes.Error.NotFound_Organization);

                if (!locationId.HasValue)
                {
                    if (!Permissions.UserHasPermission("View", organization))
                        throw new HttpException(401, SharedRes.Error.Unauthorized_Organization);

                    return new LinqMetaData().Device.Where(x => x.Location.OrganizationId == organizationId.Value);
                }
                else
                {
                    // do the same thing as above but check if the location is assigned to the organization
                    var orgLocation = new LocationEntity(locationId.Value);
                    if (orgLocation.IsNew && orgLocation.OrganizationId == organizationId)
                        throw new HttpException(404, SharedRes.Error.NotFound_Location);

                    if (!Permissions.UserHasPermission("View", orgLocation))
                        throw new HttpException(401, SharedRes.Error.Unauthorized_Location);

                   return new LinqMetaData().Device.Where(x => x.LocationId == locationId.Value);
                }
            }
        }

        /// <summary>
        /// Primary function of Purchases is to list purchase history.
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="organizationId"></param>
        /// <param name="model"></param>
        /// <param name="dtRequestModel"></param>
        /// <returns></returns>
        [ActionMenu(Rank = 600, ResourceName = "PurchasesList_Purchases")]
        public ActionResult List(int? locationId, int? organizationId, PurchaseHistoryModel model, [ModelBinder(typeof(DataTablesRequestModelBinder))] DataTablesRequestModel dtRequestModel)
        {

            if(Request.HttpMethod == "POST" && ModelState.IsValid)
            {
                var user = Membership.GetUser().GetUserEntity();

                var transaction = new Transaction(IsolationLevel.ReadCommitted, "purchase transfer");
                try
                {
                    var fromDevice = model.FromDevice;
                    var toDevice = model.ToDevice;

                    var from = new PurchaseHistoryEntity
                    {
                        DeviceId = model.FromDeviceId,
                        LocationId = fromDevice.LocationId,
                        UserId = user.UserId,
                        PurchaseTime = DateTime.UtcNow,
                        ScansPurchased = -model.Quantity,
                        AmountPaid = 0,
                        TransactionId = string.Empty,
                        PurchaseNotes = String.Format(Purchase.TransferFrom, SharedRes.Formats.Device.FormatWith(fromDevice), SharedRes.Formats.Device.FormatWith(toDevice))
                    };
                    transaction.Add(from);
                    from.Save();

                    var to = new PurchaseHistoryEntity
                    {
                        DeviceId = model.ToDeviceId,
                        LocationId = toDevice.LocationId,
                        UserId = user.UserId,
                        PurchaseTime = DateTime.UtcNow,
                        ScansPurchased = model.Quantity,
                        AmountPaid = 0,
                        TransactionId = string.Empty,
                        PurchaseNotes = String.Format(Purchase.TransferFrom, SharedRes.Formats.Device.FormatWith(fromDevice), SharedRes.Formats.Device.FormatWith(toDevice))
                    };
                    transaction.Add(to);
                    to.Save();

                    transaction.Add(fromDevice);
                    fromDevice.ScansAvailable -= model.Quantity;
                    fromDevice.Save();

                    transaction.Add(toDevice);
                    toDevice.ScansAvailable += model.Quantity;
                    toDevice.Save();

                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    ModelState.AddModelError("", Purchase.TransferFailed);
                    Log.Error(Purchase.TransferFailed, ex);
                }
                finally
                {
                    transaction.Dispose();
                }
            }

            if (!organizationId.HasValue)
            {
                if (!locationId.HasValue)
                {
                    model.Puchases = new LinqMetaData().PurchaseHistory.WithPermissions();
                }
                else
                {
                    var location = new LocationEntity(locationId.Value);
                    if (location.IsNew)
                        throw new HttpException(404, SharedRes.Error.NotFound_Location);

                    if (!Permissions.UserHasPermission("View", location))
                        throw new HttpException(401, SharedRes.Error.Unauthorized_Location);

                    model.Puchases = new LinqMetaData().PurchaseHistory.Where(x => x.LocationId == locationId.Value);
                }

            }
            else
            {
                var organization = new OrganizationEntity(organizationId.Value);
                if (organization.IsNew)
                    throw new HttpException(404, SharedRes.Error.NotFound_Organization);

                if (!locationId.HasValue)
                {
                    if (!Permissions.UserHasPermission("View", organization))
                        throw new HttpException(401, SharedRes.Error.Unauthorized_Organization);

                    model.Puchases =
                        new LinqMetaData().PurchaseHistory.Where(x => x.Location.OrganizationId == organizationId);
                }
                else
                {
                    // do the same thing as above but check if the location is assigned to the organization
                    var location = new LocationEntity(locationId.Value);
                    if (location.IsNew && location.OrganizationId == organizationId)
                        throw new HttpException(404, SharedRes.Error.NotFound_Location);

                    if (!Permissions.UserHasPermission("View", location))
                        throw new HttpException(401, SharedRes.Error.Unauthorized_Location);

                    model.Puchases = new LinqMetaData().PurchaseHistory.Where(x => x.LocationId == locationId.Value);
                }
            }

            var result = View(model);

            if (dtRequestModel == null)
                return result;

            return Query(result, dtRequestModel);
        }

        /// <summary>
        /// Create a new purchase by setting up credit cards and adding purchases to the cart.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="dtRequestModel"></param>
        /// <returns></returns>
        [ActionMenu(SelectAction = "List", Visible = false)]
        public ActionResult New(NewPurchaseModel model, [ModelBinder(typeof(DataTablesRequestModelBinder))] DataTablesRequestModel dtRequestModel)
        {
            var user = Membership.GetUser().GetUserEntity();

            if (Session["cart"] as List<Models.Purchase> == null)
                Session["cart"] = new List<Models.Purchase>();

            model.Cart = ((List<Models.Purchase>)Session["cart"]);

            model.Cards = user.UserCreditCards.AsQueryable();

            var result = View(model);

            if (dtRequestModel == null)
                return result;

            return Query(result, dtRequestModel);
        }

        /// <summary>
        /// Add a credit card to the CIM and cache table for use on the checkout page.
        /// </summary>
        /// <returns></returns>
        public ActionResult AddCard()
        {
            return PartialView(new AddCard());
        }

        [HttpPost]
        public ActionResult AddCard(AddCard model)
        {
            if (ModelState.IsValid)
            {
                var transaction = new Transaction(IsolationLevel.ReadCommitted, "add card");
                try
                {
                    CustomerGateway cg;
                    var customer = EnsureProfile(out cg);

                    var addr = new AuthorizeNet.Address
                    {
                        First = model.FirstName,
                        Last = model.LastName,
                        Street = model.AddressLine1 + Environment.NewLine + model.AddressLine2,
                        State = model.State,
                        Country = model.Country,
                        City = model.City,
                        Zip = model.Zip
                    };

                    // save the customer profile for the currently logged on user
                    var creditCard = new CreditCardEntity()
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        AccountNumber = model.CardNumber.Substring(model.CardNumber.Length - 4, 4),
                        Address = model.AddressLine1
                    };

                    creditCard.AuthorizeId = cg.AddCreditCard(
                        customer.ProfileID,
                        model.CardNumber,
                        model.CardMonth,
                        model.CardYear,
                        model.SecurityCode,
                        addr);
                    transaction.Add(creditCard);
                    creditCard.Save();

                    var userCard = new UserCreditCardEntity
                                       {
                                           UserId = Membership.GetUser().GetUserEntity().UserId,
                                           CreditCardId = creditCard.CreditCardId
                                       };
                    transaction.Add(userCard);
                    userCard.Save();

                    transaction.Commit();

                    return new EmptyResult();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    // try to get all profiles from authorize.net
                    if(ex.Message.Contains("duplicate"))
                    {
                        ForceResync();
                    }
                    else
                        ModelState.AddModelError("", Purchase.AddCard_Error);
                    Log.Error(Purchase.AddCard_Error, ex);
                }
                finally
                {
                    transaction.Dispose();
                }
            }

            Response.StatusCode = 417;
            Response.TrySkipIisCustomErrors = true;

            return PartialView(model);
        }

        /// <summary>
        /// This is called in the special condition where a card is already added to Authorize.Net CIM but apparently not in the list of cards.
        /// This is not expected to happen usually, but could during testing or if we have to manually add cards.
        /// </summary>
        /// <returns></returns>
        public ActionResult ForceResync()
        {
            var transaction = new Transaction(IsolationLevel.ReadCommitted, "sync cards");
            try
            {
                CustomerGateway cg;
                var customer = EnsureProfile(out cg);
                foreach (var cardProfile in customer.PaymentProfiles)
                {
                    var creditCard = new CreditCardEntity
                    {
                        AuthorizeId = cardProfile.ProfileID,
                        FirstName = cardProfile.BillingAddress.First,
                        LastName = cardProfile.BillingAddress.Last,
                        AccountNumber = cardProfile.CardNumber.Replace("X", ""),
                        Address = cardProfile.BillingAddress.Street
                    };
                    transaction.Add(creditCard);
                    creditCard.Save();

                    var userCard = new UserCreditCardEntity
                    {
                        UserId = Membership.GetUser().GetUserEntity().UserId,
                        CreditCardId = creditCard.CreditCardId
                    };
                    transaction.Add(userCard);
                    userCard.Save();
                }

                transaction.Commit();
            }
            catch (Exception exc)
            {
                transaction.Rollback();
                ModelState.AddModelError("", Purchase.AddCard_Error);
                Log.Error(Purchase.SyncError, exc);
            }
            finally
            {
                transaction.Dispose();
            }
            return new EmptyResult();
        }

        /// <summary>
        /// This ensures that the user profile has been created on Authorize.Net CIM.
        /// This is only called when Adding or Editing a card or finalizing a purchase.  All other viewing using the card cache table.
        /// </summary>
        /// <param name="outGateway">The customer gateway created and used to verify the customer has been created.
        /// Just returned for efficiency, there is no consequence to creating another gateway in the calling function</param>
        /// <param name="user">The current user.</param>
        /// <returns>All the customer information from CIM.</returns>
        private Customer EnsureProfile(out CustomerGateway outGateway, UserEntity user = null)
        {
            if(user == null)
                user = Membership.GetUser().GetUserEntity();

            // create the authorize.net gateway
            bool live;
            bool.TryParse(ConfigurationManager.AppSettings.Get("AuthorizeLive"), out live);
            var cg = new CustomerGateway(ConfigurationManager.AppSettings.Get("API_LOGIN_ID"),
                                                      ConfigurationManager.AppSettings.Get("TRANSACTION_KEY"), live ? ServiceMode.Live : ServiceMode.Test);
            outGateway = cg;

            // get the users e-mail address
            var email = user.EmailAddress;
            var setting = user.Settings.FirstOrDefault(x => x.Name == "SupportUser");
            if (setting != null)
                email = setting.Value + "@" + SupportController.DOMAIN;

            // create a new customer profile for the currently logged in user
            var profile = new UserSettingEntity(user.UserId, "AuthorizeId");
            if (profile.IsNew)
            {
                try
                {
                    // set up new user
                    profile.UserId = user.UserId;
                    profile.Name = "AuthorizeId";
                    var customer = cg.CreateCustomer(email, user.Username);
                    profile.Value = customer.ProfileID;
                    profile.Save();

                    return customer;
                }
                catch(Exception ex)
                {
                    // user exists, so just get the ID
                    if (ex.Message.Contains("duplicate"))
                    {
                        profile.UserId = user.UserId;
                        profile.Name = "AuthorizeId";
                        var start = ex.Message.IndexOf("ID", StringComparison.InvariantCulture) + 3;
                        profile.Value = ex.Message.Substring(start,
                                                             ex.Message.IndexOf(" ", start,
                                                                                StringComparison.InvariantCulture) -
                                                             start);
                        profile.Save();
                    }
                    Log.Error(Purchase.AuthError, ex);
                }
            }

            var existingCustomer = cg.GetCustomer(profile.Value);
            if (existingCustomer.Email != email)
            {
                existingCustomer.Email = email;
                cg.UpdateCustomer(existingCustomer);
            }
                

            return existingCustomer;
        }

        /// <summary>
        /// Add a purchase to the shopping cart.
        /// </summary>
        /// <param name="locationId"></param>
        /// <param name="organizationId"></param>
        /// <returns></returns>
        public ActionResult Add(int? locationId, int? organizationId)
        {
            var model = new Models.Purchase {Devices = GetDevices(locationId, organizationId)};

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult Add(int? locationId, int? organizationId, Models.Purchase model)
        {
            if (ModelState.IsValid)
            {
                // add purchase to cart and save in session
                if (Session["cart"] as List<Models.Purchase> == null)
                {
                    Session["cart"] = new List<Models.Purchase>();
                }

                ((List<Models.Purchase>)Session["cart"]).Add(model);

                return new EmptyResult();
            }

            model.Devices = GetDevices(locationId, organizationId);

            Response.StatusCode = 417;
            Response.TrySkipIisCustomErrors = true;

            return PartialView(model);
        }

        public ActionResult RemoveFromCart(int index)
        {
            if (Session["cart"] as List<Models.Purchase> != null &&
                index >= 0 && index < ((List<Models.Purchase>)Session["cart"]).Count)
                ((List<Models.Purchase>)Session["cart"]).RemoveAt(index);

            return new EmptyResult();
        }

        /// <summary>
        /// Final step in making a purchase, must select a card and review the shopping cart.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="dtRequestModel"></param>
        /// <returns></returns>
        [ActionMenu(SelectAction = "List", Visible = false)]
        public ActionResult Checkout(NewPurchaseModel model, [ModelBinder(typeof(DataTablesRequestModelBinder))] DataTablesRequestModel dtRequestModel)
        {
            var user = Membership.GetUser().GetUserEntity();

            if (Session["cart"] as List<Models.Purchase> == null)
                Session["cart"] = new List<Models.Purchase>();

            model.Cart = ((List<Models.Purchase>)Session["cart"]);

            if (Request.HttpMethod == "POST")
            {
                if (ModelState.IsValid)
                {
                    if (model.Cart.Count > 0)
                    {
                        var transaction = new Transaction(IsolationLevel.ReadCommitted, "purchase transfer");
                        try
                        {
                            // authorize and capture purchase
                            CustomerGateway cg;
                            var customer = EnsureProfile(out cg);

                            var order = new Order(customer.ProfileID, model.CreditCard.AuthorizeId, "")
                                            {
                                                Amount = model.Cart.Sum(x => x.Price),
                                                Description = model.PurchaseNotes,
                                                InvoiceNumber =
                                                    DateTime.UtcNow.Ticks.ToString(CultureInfo.InvariantCulture)
                                            };

                            var response = (GatewayResponse) cg.AuthorizeAndCapture(order);
                            if (!response.Approved)
                                throw new Exception(response.Message);

                            // set up all the transactions
                            foreach (var purchase in model.Cart)
                            {
                                var toDevice = purchase.Device;
                                var newPurchase = new PurchaseHistoryEntity
                                                      {
                                                          DeviceId = purchase.DeviceId,
                                                          LocationId = toDevice.LocationId,
                                                          UserId = user.UserId,
                                                          PurchaseTime = DateTime.UtcNow,
                                                          ScansPurchased = purchase.Quantity,
                                                          AmountPaid = purchase.Price,
                                                          PurchaseNotes = model.PurchaseNotes,
                                                          TransactionId = response.TransactionID
                                                      };
                                transaction.Add(newPurchase);
                                newPurchase.Save();

                                toDevice.ScansAvailable += purchase.Quantity;
                                transaction.Add(toDevice);
                                toDevice.Save();
                            }

                            transaction.Commit();

                            model.Cart.Clear();

                            OperationController.Update();

                            return RedirectToAction("List");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            ModelState.AddModelError("", Purchase.CheckoutError);
                            Log.Error(Purchase.CheckoutError, ex);
                        }
                        finally
                        {
                            transaction.Dispose();
                        }
                    }
                }
                else
                    ModelState.AddModelError("", Purchase.NoItems);

                Response.StatusCode = 417;
                Response.TrySkipIisCustomErrors = true;
            }

            model.Cards = user.UserCreditCards.AsQueryable();

            var result = View(model);

            if (dtRequestModel == null)
                return result;

            return Query(result, dtRequestModel);
        }

        /// <summary>
        /// Edit and existing credit card and update CIM.
        /// </summary>
        /// <param name="creditcardid"></param>
        /// <returns></returns>
        public ActionResult EditCard(int creditcardid)
        {
            var card = new CreditCardEntity(creditcardid);
            if(card.IsNew)
                throw new HttpException(404, SharedRes.Error.NotFound_CreditCard);

            if(!Permissions.UserHasPermission("Edit", card))
                throw new HttpException(401, SharedRes.Error.Unauthorized_CreditCard);

            // populate the model with the card data loaded from authorize.net
            try
            {
                CustomerGateway cg;
                var customer = RoleUtils.IsUserServiceAdmin()
                                   ? EnsureProfile(out cg, card.UserCreditCards.First().User)
                                   : EnsureProfile(out cg);

                var profile = customer.PaymentProfiles.First(x => x.ProfileID == card.AuthorizeId);
                var addressLines = profile.BillingAddress.Street.Split('\n');
                var model = new EditCard
                                {
                                    AddressLine1 = addressLines[0],
                                    AddressLine2 = addressLines.Length > 1 ? addressLines[1] : "",
                                    City = profile.BillingAddress.City,
                                    Country = profile.BillingAddress.Country,
                                    FirstName = profile.BillingAddress.First,
                                    LastName = profile.BillingAddress.Last,
                                    State = profile.BillingAddress.State,
                                    Zip = profile.BillingAddress.Zip,
                                };

                return PartialView(model);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", Purchase.EditCard_Error);
                Log.Error(Purchase.EditCard_Error, ex);
            }

            return PartialView();
        }

        [HttpPost]
        public ActionResult EditCard(int creditcardid, EditCard model)
        {
            var card = new CreditCardEntity(creditcardid);
            if (card.IsNew)
                throw new HttpException(404, SharedRes.Error.NotFound_CreditCard);

            if (!Permissions.UserHasPermission("Edit", card))
                throw new HttpException(401, SharedRes.Error.Unauthorized_CreditCard);

            if (ModelState.IsValid)
            {
                var transaction = new Transaction(IsolationLevel.ReadCommitted, "add card");
                try
                {
                    CustomerGateway cg;
                    var customer = RoleUtils.IsUserServiceAdmin()
                                       ? EnsureProfile(out cg, card.UserCreditCards.First().User)
                                       : EnsureProfile(out cg);

                    var profile = customer.PaymentProfiles.First(x => x.ProfileID == card.AuthorizeId);

                    // update the card info
                    if(!string.IsNullOrEmpty(model.CardNumber))
                    {
                        profile.CardNumber = model.CardNumber;
                        profile.CardCode = model.SecurityCode;
                        profile.CardExpiration = model.CardMonth + "/" + model.CardYear;
                        card.AccountNumber = model.CardNumber.Substring(model.CardNumber.Length - 4, 4);
                    }

                    // update the billing address
                    profile.BillingAddress = new AuthorizeNet.Address
                    {
                        First = model.FirstName,
                        Last = model.LastName,
                        Street = model.AddressLine1 + Environment.NewLine + model.AddressLine2,
                        State = model.State,
                        Country = model.Country,
                        City = model.City,
                        Zip = model.Zip
                    };
                    card.FirstName = model.FirstName;
                    card.LastName = model.LastName;
                    card.Address = model.AddressLine1;
                    transaction.Add(card);
                    card.Save();

                    cg.UpdatePaymentProfile(customer.ProfileID, profile);

                    transaction.Commit();
                    return new EmptyResult();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ModelState.AddModelError("", Purchase.EditCard_Error);
                    Log.Error(Purchase.EditCard_Error, ex);
                }
                finally
                {
                    transaction.Dispose();
                }
            }

            Response.StatusCode = 417;
            Response.TrySkipIisCustomErrors = true;

            return PartialView(model);
        }
    }
}
