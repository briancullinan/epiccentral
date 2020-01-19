using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using AE.Net.Mail;
using AE.Net.Mail.Imap;
using EPICCentral.Controllers;
using EPICCentral.Utilities.Attributes;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.Linq;
using MailMessage = AE.Net.Mail.MailMessage;

namespace EPICCentral.Models
{
    public class SupportModel
    {
        public IQueryable<Mailbox> Mailboxes { get; set; }

        public IQueryable<MailMessage> Messages { get; set; }

        public string CurrentFolder { get; set; }

        public bool? AccountSetup { get; set; }
    }

    public class ComposeMail
    {
        private readonly UserSettingEntity _profile;
        private readonly UserEntity _user;

        public ComposeMail()
        {
            _user = Membership.GetUser().GetUserEntity();
            _profile = new UserSettingEntity(_user.UserId, "SupportUser") { UserId = _user.UserId, Name = "SupportUser" };
        }

        public ComposeMail(MailMessage msg = null) : this()
        {
            if(msg != null)
            {
                Uid = msg.Uid;
                To = String.Join("; ", msg.To.Select(x => SharedRes.Formats.MailAddress.FormatWith(x)));
                Subject = msg.Subject;
                Body = msg.Body.Replace("\r", "");
            }
        }

        public ComposeMail(bool? all, MailMessage msg = null) : this()
        {
            if (msg != null)
            {
                Uid = msg.Uid;
                // forward the message
                if (!all.HasValue)
                    To = "";
                // reply all
                else if (all.Value)
                    To = String.Join("; ", msg.To.Concat(new[] {msg.From})
                                               .Where(x => x.Address.Contains(_profile.Value))
                                               .Select(x => SharedRes.Formats.MailAddress.FormatWith(x)));
                // reply one
                else
                    To = SharedRes.Formats.MailAddress.FormatWith(msg.From);
                Subject = msg.Subject;
                Body = "\r\n\r\n--\r\n" + msg.Body;
            }
        }

        public string Uid { get; set; }
        public string ReplyUid { get; set; }

        [Display(ResourceType = typeof(ModelRes.Support), Name = "Compose_From")]
        public string From { get { return SharedRes.Formats.MailAddress.FormatWith(new MailAddress(_profile.Value + "@" + SupportController.DOMAIN, SharedRes.Formats.User.FormatWith(_user))); } }

        [Display(ResourceType = typeof(ModelRes.Support), Name = "Compose_To")]
        [Required(ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        [EmailValidation(ErrorMessageResourceType = typeof(ModelRes.Support), ErrorMessageResourceName = "InvalidEmails")]
        public string To { get; set; }

        [Display(ResourceType = typeof(ModelRes.Support), Name = "Compose_Subject")]
        [Required(AllowEmptyStrings = true, ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        public string Subject { get; set; }

        [Display(ResourceType = typeof(ModelRes.Support), Name = "Compose_Message")]
        [Required(AllowEmptyStrings = true, ErrorMessageResourceType = typeof(SharedRes.Error), ErrorMessageResourceName = "Error_Required")]
        public string Body { get; set; }

        public MailMessage MailMessage
        {
            get
            {
                var msg = new MailMessage
                           {
                               Subject = Subject,
                               Body = Body,
                               From = new MailAddress(_profile.Value + "@" + SupportController.DOMAIN, SharedRes.Formats.User.FormatWith(_user))
                           };
                if(!string.IsNullOrEmpty(ReplyUid))
                    msg.Headers.Add("In-Reply-To", new HeaderValue(ReplyUid));

                var tos =
                    To.Split(new[] { "\n", ";", "," }, StringSplitOptions.RemoveEmptyEntries).Select(
                        x => x.Trim());
                foreach(var address in tos)
                {
                    if (string.IsNullOrEmpty(address.Trim()))
                        continue;

                    var selectedUser = EmailValidationAttribute.FindUser(address, Users);
                    if(selectedUser != null)
                        msg.To.Add(selectedUser);
                }

                return msg;
            }
        }

        public static IEnumerable<UserEntity> Users
        {
            get
            {
                // list of users the login user has access to send mail to
                return new LinqMetaData().User
                    .Where(x => x.Roles.Any(y => y.Role.Name == "Service Administrator")).ToList()
                    .Concat(new LinqMetaData().User.WithPermissions().ToList());

            }
        }  
    }
}