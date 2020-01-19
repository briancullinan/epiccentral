using System;

namespace EPICCentralLibrary.Email
{
    public class EmailParameters
    {
        #region Constructors
        public EmailParameters()
        {
            // Perform init work here
            SetDefaultSender();
            SetCurrentDate();
            IsHTMLBody = false;
            ImportantFlag = true;
        }
        #endregion

        private void SetCurrentDate()
        {
            CurrentDate = DateTime.Now.ToLongDateString();
        }

        private void SetDefaultSender()
        {
            Sender = GlobalSettings.Emails.DEFAULT_FROM_ADDRESS;
        }

        public string friendlyToLine()
        {
            if (!String.IsNullOrEmpty(ReceiverFirstName) && !String.IsNullOrEmpty(ReceiverLastName))
                return (Receiver + ", " + ReceiverFirstName + " " + ReceiverLastName);
            return (Receiver);
        }

        #region Public Settings

        public string Sender { get; set; }

        public string Receiver { get; set; }

        public string ReceiverFirstName { get; set; }

        public string ReceiverLastName { get; set; }

        public string ReceiverName { get; set; }

        public string LinkBack { get; set; }

        public decimal UserId { get; set; }

        public string CurrentDate { get; set; }

        public string SubjectLine { get; set; }

        public string BodyContent { get; set; }

        public bool IsHTMLBody { get; set; }

        public bool ImportantFlag { get; set; }

        #endregion
    }
}
