using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Security;
using System.Web.SessionState;
using AE.Net.Mail;
using ControllerRes;
using EPICCentral.Models;
using EPICCentral.Utilities.Attributes;
using EPICCentral.Utilities.Membership;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using EPICCentralDL.Linq;
using MailMessage = AE.Net.Mail.MailMessage;
using Mailbox = AE.Net.Mail.Imap.Mailbox;

namespace EPICCentral.Controllers
{
    public class SupportController : DataTablesController
    {
        /// <summary>
        /// This is the domain that is appended to all e-mail addresses.
        /// TODO: Maybe this should be put in the web.config?
        /// </summary>
        public const string DOMAIN = "epicdiagnostics.com";

        /// <summary>
        /// These are the folders that show up, this filters out from a longer list of exchange folders.
        /// If the e-mail provider changes, this may need to be modified or removed.
        /// TODO: Put this in web.config?
        /// </summary>
        public string[] FOLDERS = new [] {"Deleted Items", "Drafts", "INBOX", "Sent Items"};

        /// <summary>
        /// This is the time it takes the Powershell script to run on the Exchange server to read Active Directory users and create mailboxes for them.
        /// </summary>
        public const int MINUTES_TO_CREATE = 2;

        /// <summary>
        /// This ensures that the user's mailbox has been created.
        /// </summary>
        /// <returns></returns>
        public static bool? EnsureUserAccount()
        {
            var user = Membership.GetUser().GetUserEntity();
            return EnsureUserAccount(user);
        }

        public static bool? EnsureUserAccount(UserEntity user)
        {
            var profile = new UserSettingEntity(user.UserId, "SupportUser") { UserId = user.UserId, Name = "SupportUser" };
            var password = new UserSettingEntity(user.UserId, "SupportPass") { UserId = user.UserId, Name = "SupportPass" };
            // set up user profile
            if (profile.IsNew)
            {
                var transaction = new Transaction(IsolationLevel.ReadCommitted, "user add");
                try
                {

                    profile.Value = user.Username + new Random().Next(1000, 20000);
                    transaction.Add(profile);
                    profile.Save();

                    var pass = Utilities.Membership.Mailbox.CreateUser(profile.Value);

                    password.Value = Utilities.Crypto.Rijndael.Encrypt(pass);
                    transaction.Add(password);
                    password.Save();
                    transaction.Commit();

                }
                catch
                {
                    transaction.Rollback();
                    return null;
                }
                finally
                {
                    transaction.Dispose();
                }
            }

            // check if mailbox exists
            try
            {
                var aduser = Utilities.Membership.Mailbox.GetDomainUser(profile.Value);

                // if the user was created more than 2 minutes ago and there is no exchange property, something has failed
                if (user.CreateTime < DateTime.Now.AddMinutes(-MINUTES_TO_CREATE) && !aduser.Properties.Contains("msExchMailboxGuid"))
                    return null;
                // if there is no exchange property but they were created in the last 2 minutes, they should just wait
                else if (!aduser.Properties.Contains("msExchMailboxGuid"))
                    return false;
            }
            catch
            {
                return null;
            }

            return true;
        }

        /// <summary>
        /// This ensures that a connection to the mail server is valid and properly connected.
        /// </summary>
        /// <returns>The client to access e-mail through.</returns>
        public static ImapClient EnsureConnection()
        {
            var user = Membership.GetUser().GetUserEntity();
            return EnsureConnection(user);
        }

        public static ImapClient EnsureConnection(UserEntity user)
        {
            EnsureUserAccount(user);

            var profile = new UserSettingEntity(user.UserId, "SupportUser") { UserId = user.UserId, Name = "SupportUser" };
            var password = new UserSettingEntity(user.UserId, "SupportPass") { UserId = user.UserId, Name = "SupportPass" };

            return new ImapClient(DOMAIN, profile.Value, Utilities.Crypto.Rijndael.Decrypt(password.Value),
                                  ImapClient.AuthMethods.Login, 993, true);
        }

        /// <summary>
        /// This is called to force any action listeners to update when the cached Mailbox count is updated.  This is called by the MailboxChecker service.
        /// </summary>
        public static void Update()
        {
            new UpdateStatusEntity("Support", "Change") { Controller = "Support", Action = "Change", Method = "POST", UpdateTime = DateTime.UtcNow }.Save();
        }

        /// <summary>
        /// This is the container method for the Update function and will force any action listeners to update.
        /// </summary>
        /// <returns></returns>
        public ActionResult Change()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            // force clients to update the operations view
            return new EmptyResult();
        }

        #region "Index"

        /// <summary>
        /// The primary Index display.
        /// </summary>
        /// <returns></returns>
        [SupportMenu(Rank = 1400)]
        public ActionResult Index()
        {
            var user = EnsureUserAccount();

            return View(new SupportModel
            {
                Mailboxes = new List<Mailbox>().AsQueryable(),
                Messages = new List<MailMessage>().AsQueryable(),
                CurrentFolder = "INBOX",
                AccountSetup = user
            });
        }

        #endregion

        #region "Folders"

        /// <summary>
        /// Lists folders from the Imap connection.
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="dtRequestModel"></param>
        /// <returns></returns>
        public ActionResult Folders(string folderPath = "",
                                 [ModelBinder(typeof(DataTablesRequestModelBinder))] DataTablesRequestModel
                                     dtRequestModel = null)
        {
            using (var imap = EnsureConnection())
            {
                List<Mailbox> folders;

                folders = imap.ListMailboxes(folderPath, "*").Where(x => FOLDERS.Contains(x.Name)).Select(x => imap.Examine(x.Name)).ToList();
                var subscribes = imap.ListSuscribesMailboxes("", "*");

                var result = View("Index", new SupportModel
                                               {
                                                   Mailboxes = folders.AsQueryable(),
                                                   Messages = new List<MailMessage>().AsQueryable(),
                                                   AccountSetup = true
                                               });

                if (dtRequestModel != null)
                    return Query(result, dtRequestModel, ControllerContext);

                return result;
            }
        }

        #endregion

        #region "Messages"

        /// <summary>
        /// Lists a used mailbox messages.
        /// </summary>
        /// <param name="count"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static Transaction UpdateInboxCount(int count, UserEntity user)
        {
            var transaction = new Transaction(IsolationLevel.ReadCommitted, "mailbox update");
            try
            {
                var countSetting = new UserSettingEntity(user.UserId, "SupportInboxCount")
                                       {
                                           UserId = user.UserId,
                                           Name = "SupportInboxCount",
                                           Value = count.ToString(CultureInfo.InvariantCulture)
                                       };
                transaction.Add(countSetting);
                countSetting.Save();

                var timeSetting = new UserSettingEntity(user.UserId, "SupportInboxUpdated")
                                      {
                                          UserId = user.UserId,
                                          Name = "SupportInboxUpdated",
                                          Value = DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)
                                      };
                transaction.Add(timeSetting);
                timeSetting.Save();

                return transaction;
            }
            catch
            {
                transaction.Rollback();
                transaction.Dispose();
            }
            return null;
        }

        public static void UpdateInboxCount(ImapClient imap, UserEntity user)
        {
            var msgs =
                imap.Search(SearchCondition.Deleted().Not()).Select(
                    x => imap.GetMessage(x, true, true)).ToList();
            var count = msgs.Count(
                x => (x.Flags & Flags.Recent) == Flags.Recent || (x.Flags & Flags.Seen) == 0);
            var transaction = UpdateInboxCount(count, user);
            if (transaction != null)
            {
                try
                {
                    // service admins get an extra daily count used on the operations page
                    if (user.Roles.Any(x => x.Role.Name == "Service Administrator"))
                    {
                        // get the number of messages received today
                        var daily = msgs.Count(x => x.Date >= DateTime.UtcNow.Date);

                        var todaySetting = new UserSettingEntity(user.UserId, "SupportInboxToday")
                        {
                            UserId = user.UserId,
                            Name = "SupportInboxToday",
                            Value = daily.ToString(CultureInfo.InvariantCulture)
                        };
                        transaction.Add(todaySetting);
                        todaySetting.Save();
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
                finally
                {
                    transaction.Dispose();
                }
                
            }
        }

        public ActionResult Messages(string folderPath = "INBOX",
                                 [ModelBinder(typeof(DataTablesRequestModelBinder))] DataTablesRequestModel
                                     dtRequestModel = null)
        {
            using (var imap = EnsureConnection())
            {
                var messages = new List<MailMessage>();
                var msgCount = imap.SelectMailbox(folderPath).NumMsg;
                if (msgCount > 0)
                {
                    var msgs =
                        imap.Search(SearchCondition.Deleted().Not()).Select(
                            x =>
                            imap.GetMessage(x, true, true,
                                            new[] {"date", "subject", "from", "content-type", "to", "cc", "message-id"}));
                    if(folderPath == "INBOX")
                    {
                        UpdateInboxCount(
                            msgs.Count(x => (x.Flags & Flags.Recent) == Flags.Recent || (x.Flags & Flags.Seen) == 0),
                            Membership.GetUser().GetUserEntity());
                    }

                    messages.AddRange(msgs);
                }

                var result = View("Index", new SupportModel
                                               {
                                                   Mailboxes = new List<Mailbox>().AsQueryable(),
                                                   Messages = messages.AsQueryable(),
                                                   CurrentFolder = folderPath,
                                                   AccountSetup = true
                                               });

                if (dtRequestModel != null)
                    return Query(result, dtRequestModel, ControllerContext);

                return result;
            }
        }

        public ActionResult Delete(string currentFolder, string uid)
        {
            using (var imap = EnsureConnection())
            {
                imap.SelectMailbox(currentFolder);
                if (!currentFolder.Equals("Deleted Items", StringComparison.InvariantCultureIgnoreCase))
                    imap.Copy("UID " + uid, "Deleted Items");
                imap.DeleteMessage(uid);
                return new EmptyResult();
            }
        }

        public ActionResult Message(string currentFolder, string uid)
        {
            using (var imap = EnsureConnection())
            {
                imap.SelectMailbox(currentFolder);

                var message = imap.GetMessage(uid, false, false);
                return PartialView(new KeyValuePair<string, MailMessage>(currentFolder, message));
            }
        }

        #endregion

        #region "Compose"

        /// <summary>
        /// Allows users to compose new messages and drafts them.
        /// </summary>
        /// <param name="newMessage"></param>
        /// <returns></returns>
        [HttpPost, ValidateInput(false)]
        public ActionResult Compose(ComposeMail newMessage)
        {
            if (Request["Send"] != null)
            {
                if (ModelState.IsValid)
                {
                    // actually send it this time
                    try
                    {
                        EmailUtils.Send(newMessage.MailMessage);
                    }
                    catch
                    {
                        // there was an error sending the message
                        throw new HttpException(500, Support.Error_Sending);
                    }

                    try
                    {
                        if (!string.IsNullOrEmpty(newMessage.Uid))
                            using (var imap = EnsureConnection())
                            {
                                imap.SelectMailbox("Sent Items");
                                imap.AppendMail(newMessage.MailMessage);
                                imap.SelectMailbox("Drafts");
                                imap.DeleteMessage(newMessage.Uid);
                            }
                    }
                    catch
                    {
                        throw new HttpException(417, Support.Error_Copying);
                    }
                    return new EmptyResult();
                }
                else
                {
                    Response.StatusCode = 417;
                    Response.TrySkipIisCustomErrors = true;

                    return PartialView(newMessage);
                }
            }
            else
            {
                newMessage.Uid = Draft(newMessage.MailMessage, newMessage.Uid).Uid;
                return Json(newMessage);
            }
        }

        public ActionResult Compose(string uid)
        {
            if (string.IsNullOrEmpty(uid))
            {
                var msg = new ComposeMail();
                              
                msg.To = SharedRes.Formats.MailAddress.FormatWith(new MailAddress("support@epicdiagnostics.com", "Support"));

                return PartialView(msg);
            }
            else
            {
                using (var imap = EnsureConnection())
                {
                    imap.SelectMailbox("Drafts");
                    var newMessage = imap.GetMessage(uid, false, true);
                    return PartialView(new ComposeMail(newMessage));
                }
            }
        }

        private MailMessage Draft(MailMessage msg, string uid = null)
        {
            try
            {
                using (var imap = EnsureConnection())
                {
                    imap.SelectMailbox("Drafts");
                    var messageid = Guid.NewGuid() + "@" + DOMAIN;
                    msg.MessageID = messageid;
                    imap.AppendMail(msg);
                    // delete the old message and upload the new one to drafts
                    if (!String.IsNullOrEmpty(uid))
                    {
                        imap.DeleteMessage(uid);
                    }
                    var messages = imap
                        .Search(SearchCondition.Deleted().Not().And(SearchCondition.Header("Message-ID", msg.MessageID)))
                        .Select(x => imap.GetMessage(x, true, true));

                    return messages.FirstOrDefault() ?? msg;
                }
            }
            catch
            {
                throw new HttpException(500, Support.Error_Drafting);
            }
        }

        private IEnumerable<dynamic> GetTosInternal(string term)
        {
            var result = new LinqMetaData().User
                .Where(x => x.Roles.Any(y => y.Role.Name == "Service Administrator")).ToList()
                .Concat(ComposeMail.Users.Where(x =>
                                                x.EmailAddress.IndexOf(term, StringComparison.OrdinalIgnoreCase) > -1 ||
                                                x.FirstName.IndexOf(term, StringComparison.OrdinalIgnoreCase) > -1 ||
                                                x.LastName.IndexOf(term, StringComparison.OrdinalIgnoreCase) > -1 ||
                                                x.Settings.Any(y => y.Name == "SupportUser" && (y.Value + "@" + DOMAIN).IndexOf(term, StringComparison.OrdinalIgnoreCase) > -1))
                            .ToList()).Distinct();

            foreach(var user in result)
            {
                var profile = user.Settings.FirstOrDefault(x => x.Name == "SupportUser");
                if (profile != null)
                    yield return new
                                     {
                                         value = profile.Value + "@" + DOMAIN,
                                         label = SharedRes.Formats.User.FormatWith(user) + " (" + profile.Value + "@" + DOMAIN + ")"
                                     };
                else
                    yield return new
                    {
                        value = user.EmailAddress,
                        label = SharedRes.Formats.User.FormatWith(user) + " (" + user.EmailAddress + ")"
                    };
            }
        }

        public ActionResult GetTos(string term)
        {
            return Json(GetTosInternal(term), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region "Reply"

        public ActionResult Reply(string replyUid, bool? all, string folder)
        {
            using (var imap = EnsureConnection())
            {
                imap.SelectMailbox(folder);
                var newMessage = imap.GetMessage(replyUid, false, true);
                return PartialView("Compose",
                                    new ComposeMail(all, newMessage)
                                    {
                                        Uid = "",
                                        ReplyUid = replyUid
                                    });
            }
        }

        #endregion
    }

    /// <summary>
    /// Displays the count of messages in the Support menu item.
    /// </summary>
    public class SupportMenuAttribute : ActionMenuAttribute
    {
        public override Func<string> ResourceSelector
        {
            get
            {
                UserSettingEntity countSetting = null;
                try
                {
                    countSetting = Membership.GetUser().GetUserEntity().Settings.FirstOrDefault(x => x.Name == "SupportInboxCount");
                } catch {}

                var text = countSetting != null && countSetting.Value != "0"
                               ? String.Format(Menu.SupportIndex_SupportCenterMessages, countSetting.Value)
                               : Menu.SupportIndex_SupportCenter;
                return () => text;
            }
            set
            {
                base.ResourceSelector = value;
            }
        }
    }
}
