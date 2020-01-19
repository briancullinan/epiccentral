using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using log4net;

namespace EPICCentral.Utilities.Membership
{
    /// <summary>
    /// Primary email sending functions.
    /// </summary>
	public static class EmailUtils
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(EmailUtils));

		public static void Send(string message, string toAddress, string toFirstName = null, string toLastName = null, string fromAddress = null, string subject = null, bool? isHighPriority = null)
		{
			if (isHighPriority == null)
				isHighPriority = false;

			if (fromAddress == null)
				fromAddress = ConfigurationManager.AppSettings["DefaultEmail"];

			if (subject == null)
				subject = "EPIC Central Notice";

			var receiver = !string.IsNullOrWhiteSpace(toFirstName) && !string.IsNullOrWhiteSpace(toLastName) ? string.Format("{0}, {1} {2}", toAddress, toFirstName, toLastName) : toAddress;

			var email = new MailMessage
			            	{
			            			Sender = new MailAddress(fromAddress),
			            			From = new MailAddress(fromAddress),
			            			Subject = subject,
			            			Body = message,
			            			IsBodyHtml = true,
			            			Priority = isHighPriority.Value ? MailPriority.High : MailPriority.Normal
			            	};
			email.To.Add(new MailAddress(toAddress, receiver));

			try
			{
				new SmtpClient().Send(email);
			}
			catch (Exception e)
			{
				Log.Error(String.Format("There was an error sending the email {0}.", toAddress), e);
			}
		}

        public static void Send(AE.Net.Mail.MailMessage message, bool? isHighPriority = null)
        {
            if (isHighPriority == null)
                isHighPriority = false;

            var email = new MailMessage
            {
                Sender = new MailAddress(message.From.Address, message.From.DisplayName),
                From = new MailAddress(message.From.Address, message.From.DisplayName),
                Subject = message.Subject,
                Body = message.Body,
                IsBodyHtml = true,
                Priority = isHighPriority.Value ? MailPriority.High : MailPriority.Normal
            };
            foreach(var add in message.To)
                email.To.Add(new MailAddress(add.Address, add.DisplayName));

            try
            {
                new SmtpClient().Send(email);
            }
            catch (Exception e)
            {
                Log.Error(String.Format("There was an error sending the email {0}.", message.To.First().Address), e);
                throw;
            }
        }

	}
}