using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using EPICCentralDL.EntityClasses;
using EPICCentralDL.HelperClasses;
using log4net.Appender;
using log4net.Core;
using log4net.Util;

namespace EPICCentral.Utilities.Filters
{
    /// <summary>
    /// Converts Log.Error() calls to ExceptionLog entities to be displayed and viewed on the Exceptions page.
    /// </summary>
    public class EpicSqlAppender : AdoNetAppender
    {
        public new string ConnectionStringName
        {
            set { ConnectionString = ConfigurationManager.ConnectionStrings[value].ToString(); }
        }

        protected override void SendBuffer(LoggingEvent[] events)
        {
            foreach(var evt in events)
            {
                try
                {
                    var assembly = String.Join(",", Assembly.GetExecutingAssembly().FullName.Split(',').Take(2));
                    var log = new ExceptionLogEntity
                                  {
                                      DeviceId = 1,
                                      RemoteExceptionLogId = 0,
                                      Title = evt.RenderedMessage.Substring(0, Math.Min(evt.RenderedMessage.Length, ExceptionLogFields.Title.MaxLength)),
                                      Message = evt.ExceptionObject != null ? evt.ExceptionObject.Message.Substring(0, Math.Min(evt.ExceptionObject.Message.Length, ExceptionLogFields.Message.MaxLength)) : "",
                                      StackTrace = evt.ExceptionObject != null ? evt.ExceptionObject.StackTrace.Substring(0, Math.Min(evt.ExceptionObject.StackTrace.Length, ExceptionLogFields.StackTrace.MaxLength)) : "",
                                      LogTime = evt.TimeStamp,
                                      User = evt.Identity,
                                      FormName = evt.LoggerName,
                                      MachineName = Environment.MachineName,
                                      MachineOS = Environment.OSVersion.VersionString,
                                      ApplicationVersion = assembly,
                                      CLRVersion = Environment.Version.ToString(),
                                      MemoryUsage = Environment.WorkingSet.ToString(CultureInfo.InvariantCulture),
                                      ReceivedTime = DateTime.UtcNow
                                  };
                    log.Save();
                }
                catch
                {
                    // eat it
                }
            }
        }
    }
}