using System;
using System.Net.Mail;
using EPICCentralLibrary.Utilities;

namespace EPICCentralLibrary.Email
{
    public class EmailProcessor
    {
        public static void SendEmail(EmailParameters emailParameters, Decimal LocationId, Decimal UserId)
        {
            try
            {
                // Create the mail object
                MailMessage myMailMessage = new MailMessage();
                myMailMessage.Sender = new MailAddress(emailParameters.Sender);
                myMailMessage.From = new MailAddress(emailParameters.Sender);
                myMailMessage.Subject = emailParameters.SubjectLine;
                // Construct a friendly to line
                myMailMessage.To.Add(new MailAddress(emailParameters.Receiver, emailParameters.friendlyToLine()));
                myMailMessage.Body = emailParameters.BodyContent;
                myMailMessage.IsBodyHtml = emailParameters.IsHTMLBody;
                if (emailParameters.ImportantFlag)
                    myMailMessage.Priority = MailPriority.High;
                // Send the email
                SmtpClient client = new SmtpClient();
                client.Send(myMailMessage);
            }
            catch (Exception ex)
            {
                Loggers.LogException(UserId, ex, true);
            }
        }
    }
}
