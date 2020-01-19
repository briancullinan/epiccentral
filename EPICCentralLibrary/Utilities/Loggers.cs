using System;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using EPICCentralLibrary.Email;
using EPICCentralDL.EntityClasses;

namespace EPICCentralLibrary.Utilities
{
	public class TypedException : Exception
	{
		Loggers.MessageType type { get; set; }
		public TypedException(string message, Loggers.MessageType type)
			: base(message)
		{
			this.type = type;
		}
	}

	// A series of loggers that log data to different sources
	public static class Loggers
	{
		public enum MessageType
		{
			ErrorMessage,
			WarningMessage,
			InfomationalMessage
		}

		public static void ClearDisplayMessage()
		{
			HttpContext.Current.Session.Add(GlobalSettings.MESSAGE_DISPLAY_SESSION_TAG, "");
		}

		public static void AddDisplayMessage(string MessageVar, MessageType TypeOfMessage)
		{
			HttpContext.Current.Session.Add(GlobalSettings.MESSAGE_DISPLAY_SESSION_TAG, MessageVar);
			HttpContext.Current.Session.Add(GlobalSettings.MESSAGE_DISPLAY_TYPE, TypeOfMessage);
		}

		public static void WriteDebugInfo(string lineToLog)
		{
			Debug.WriteLine(DateTime.Now.ToLongTimeString() + " - " + lineToLog);
		}

		// This method will log exceptions that are thrown in the application to the
		// exception table.

		public static void LogException(decimal userId, Exception ex)
		{
			LogException(userId, ex, false);
		}

		public static bool LogException(decimal userId, Exception ex, bool dontSendEmail)
		{
			return LogException(userId, new [] {ex}, dontSendEmail);
		}

		public static bool LogException(decimal userId, Exception[] exs, bool dontSendEmail)
		{
			try
			{
				// add all exceptions to the database
				foreach(Exception ex in exs)
				{
					WriteDebugInfo(ex.Message);
					//EcUserEntity user = new EcUserEntity(userId);
					//EcExceptionLogEntity logEntry = new EcExceptionLogEntity();
					//logEntry.organizationId = userId;
					//logEntry.CustomerLocationId = 
					//logEntry.CustomerExceptionLogId = 
					//MemoryStream stream = new MemoryStream();
					//new XmlSerializer(typeof(Exception)).Serialize(stream, ex);
					//stream.Position = 0;
					//logEntry.CustomerExceptionObject = stream.ToArray();
					//logEntry.CustomerExceptionTitle;
					//logEntry.CustomerExceptionMessage = ex.Message;
					//logEntry.CustomerExceptionStackTrace = ex.StackTrace;
					//if (ex.InnerException != null)
					//	logEntry.CustomerExceptionInnerStackTrace = ex.InnerException.StackTrace;
					//else
					//	logEntry.CustomerExceptionInnerStackTrace = "";
					//logEntry.CustomerExceptionDateTime = DateTime.Now;
					//logEntry.CustomerExceptionUser = userId.ToString();
					//logEntry.CustomerExceptionFormName
					//logEntry.CustomerExceptionMachineName = 
					//logEntrylogEntry.CustomerExceptionMachineOs = 
					//logEntry.CustomerExceptionApplicationVersion = 
					//logEntry.CustomerExceptionClrversion = 
					//logEntry.CustomerExceptionMemoryUsage = 
					//logEntry.ReceivedDate = DateTime.Now;

					//logEntry.Save();
				}

				// check whether or not to send the email
				if ((!dontSendEmail) && (ConfigurationManager.AppSettings.Get("EmailExceptions") == "Y"))
				{
					EmailParameters myEmailParameters = new EmailParameters();
					myEmailParameters.Receiver = "bcullinan@epicdiagnostics.com";
					myEmailParameters.ReceiverFirstName = "Brian";
					myEmailParameters.ReceiverLastName = "Cullinan";
					myEmailParameters.Sender = GlobalSettings.Emails.DEFAULT_FROM_ADDRESS;
					myEmailParameters.SubjectLine = "";
					foreach (Exception ex in exs)
					{
						myEmailParameters.SubjectLine += (myEmailParameters.SubjectLine == "" ? "Exception: " : "; ") + ex.Source;
						myEmailParameters.BodyContent += "Exception Message: " + ex.Message + Environment.NewLine + Environment.NewLine + ex.StackTrace + Environment.NewLine + Environment.NewLine;
						int stop = 10;
						Exception inner = ex.InnerException;
						while (inner != null && stop > 0)
						{
							myEmailParameters.BodyContent += "InnerException Message: " + inner.Message + Environment.NewLine + Environment.NewLine + inner.StackTrace + Environment.NewLine + Environment.NewLine;
							inner = inner.InnerException;
							stop--;
						}
					}
					myEmailParameters.IsHTMLBody = false;
					EmailProcessor.SendEmail(myEmailParameters, GlobalSettings.LOCATION_ID, GlobalSettings.SYSTEM_DAEMON_USER_ID);
				}

				return true;
			}
			catch (Exception tmp_ex)
			{
				//Hosed here if a exception occurs so eat it.
				return false;
			}
		}

	}
}
