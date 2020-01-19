using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AE.Net.Mail;
using EPICCentral.Controllers;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using EPICCentralDL.Linq;
using EPICCentral;

namespace MailboxChecker
{
    public partial class MailboxChecker : ServiceBase
    {
        private readonly TimeSpan _maxWorkerExecutionTime = new TimeSpan(0, 30, 0); // 30 minutes
        private DateTime _workerThreadStart;
        private Thread _workerThread = null;

        public MailboxChecker()
        {
            InitializeComponent();
        }

        [STAThread]
        private static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                var service = new MailboxChecker();
                service.OnStart(new string[] { });

                Application.Run();
                Application.Exit();
            }
            else
            {
                var service = new MailboxChecker();
                Run(service);
            }
        }

        protected override void OnStart(string[] args)
        {
            worker.Interval = SupportController.MINUTES_TO_CREATE*60*1000;
            worker.Enabled = true;
        }

        protected override void OnStop()
        {
            try
            {
                worker.Enabled = false;
                if (_workerThread != null && _workerThread.IsAlive)
                {
                    _workerThread.Abort();
                }
            } catch
            {
                
            }
        }

        private void worker_Tick(object sender, EventArgs e)
        {
            if (_workerThread != null && _workerThread.IsAlive &&
                DateTime.UtcNow - _workerThreadStart > _maxWorkerExecutionTime)
            {
                _workerThread.Abort();
            }

            if (_workerThread == null || !_workerThread.IsAlive)
            {
                //Look to see if there is work to be done (Synchronize baby)
                _workerThreadStart = DateTime.UtcNow;
                _workerThread = new Thread(CheckMailboxes) {Priority = ThreadPriority.BelowNormal};
                _workerThread.Start();
            }
        }

        private void CheckMailboxes()
        {
            foreach (
                var user in
                    new LinqMetaData().User.Where(x => x.IsActive && x.Settings.Any(y => y.Name == "SupportUser")))
            {
                using (var imap = SupportController.EnsureConnection(user))
                {
                    var msgCount = imap.SelectMailbox("INBOX").NumMsg;
                    if (msgCount > 0)
                    {
                        SupportController.UpdateInboxCount(imap, user);
                    }
                }
            }

            SupportController.Update();
        }
    }
}
