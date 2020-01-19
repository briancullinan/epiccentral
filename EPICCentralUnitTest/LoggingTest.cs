#define LOGTEST
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using EPICCentral;
using EPICCentral.Controllers;
using EPICCentralUnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using log4net.Appender;

namespace EPICCentralUnitTest
{
    [TestClass]
    public class LoggingTest : ControllerTest
    {
        /// <summary>
        /// Satisfies requirement 4.5.2.2
        /// </summary>
        [TestMethod]
        public void Actions_Logged()
        {
            // invoke an action
            var controller = Mock<HomeController>();
            controller.Invoke(x => x.Index(null));

            // check if action was logged
            var fileAppender = log4net.LogManager.GetRepository().GetAppenders().FirstOrDefault(x => x is FileAppender) as FileAppender;
            Assert.IsNotNull(fileAppender);
            using(var fileReader = new StreamReader(File.OpenRead(fileAppender.File)))
            {
                fileReader.BaseStream.Seek(-4098, SeekOrigin.End);
                var log = fileReader.ReadToEnd();
                Assert.IsTrue(log.Contains(String.Format("{0}", controller.HttpContext.Timestamp)));
            }
        }

        /// <summary>
        /// Satisfies requirement 4.5.2.1
        /// </summary>
        [TestMethod]
        public void Exceptions_Logged()
        {
            var controller = Mock<HomeController>();
            var random = new Random(DateTime.Now.Millisecond);
            var exceptionRand = random.Next();
            try
            {
                controller.Invoke(x => x.GenerateException(exceptionRand));
            }
            catch (Exception ex)
            {
                // TODO: figure out why this throws ArgumentNullException in VirtualPath.Create()
                //  It is the only place that does it, executes the same code as all the other tests but for some reason the Url.Content() calls don't work
                try
                {
                    Global.ErrorOut(ex);
                }
                catch {}
            }

            // check if action was logged
            var fileAppender = log4net.LogManager.GetRepository().GetAppenders().FirstOrDefault(x => x is FileAppender) as FileAppender;
            Assert.IsNotNull(fileAppender);
            using (var fileReader = new StreamReader(File.OpenRead(fileAppender.File)))
            {
                fileReader.BaseStream.Seek(-4098, SeekOrigin.End);
                var log = fileReader.ReadToEnd();
                Assert.IsTrue(log.Contains(exceptionRand.ToString(CultureInfo.InvariantCulture)));
            }
        }

        protected override void TestInitialize()
        {
        }

        protected override void TestCleanup()
        {
        }
    }
}
