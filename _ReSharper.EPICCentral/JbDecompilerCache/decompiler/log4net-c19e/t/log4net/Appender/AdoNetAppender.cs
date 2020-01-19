// Type: log4net.Appender.AdoNetAppender
// Assembly: log4net, Version=1.2.11.0, Culture=neutral, PublicKeyToken=669e0ddf0bb1aa2a
// Assembly location: C:\EPICSource\developer1_ARIZONA21\EPIC Website\EPICCentral\3rdPartyLibraries\log4net.dll

using log4net.Core;
using log4net.Util;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;

namespace log4net.Appender
{
  public class AdoNetAppender : BufferingAppenderSkeleton
  {
    private static readonly Type declaringType = typeof (AdoNetAppender);
    protected bool m_usePreparedCommand;
    protected ArrayList m_parameters;
    private SecurityContext m_securityContext;
    private IDbConnection m_dbConnection;
    private IDbCommand m_dbCommand;
    private string m_connectionString;
    private string m_appSettingsKey;
    private string m_connectionStringName;
    private string m_connectionType;
    private string m_commandText;
    private CommandType m_commandType;
    private bool m_useTransactions;
    private bool m_reconnectOnError;

    public string ConnectionString
    {
      get
      {
        return this.m_connectionString;
      }
      set
      {
        this.m_connectionString = value;
      }
    }

    public string AppSettingsKey
    {
      get
      {
        return this.m_appSettingsKey;
      }
      set
      {
        this.m_appSettingsKey = value;
      }
    }

    public string ConnectionStringName
    {
      get
      {
        return this.m_connectionStringName;
      }
      set
      {
        this.m_connectionStringName = value;
      }
    }

    public string ConnectionType
    {
      get
      {
        return this.m_connectionType;
      }
      set
      {
        this.m_connectionType = value;
      }
    }

    public string CommandText
    {
      get
      {
        return this.m_commandText;
      }
      set
      {
        this.m_commandText = value;
      }
    }

    public CommandType CommandType
    {
      get
      {
        return this.m_commandType;
      }
      set
      {
        this.m_commandType = value;
      }
    }

    public bool UseTransactions
    {
      get
      {
        return this.m_useTransactions;
      }
      set
      {
        this.m_useTransactions = value;
      }
    }

    public SecurityContext SecurityContext
    {
      get
      {
        return this.m_securityContext;
      }
      set
      {
        this.m_securityContext = value;
      }
    }

    public bool ReconnectOnError
    {
      get
      {
        return this.m_reconnectOnError;
      }
      set
      {
        this.m_reconnectOnError = value;
      }
    }

    protected IDbConnection Connection
    {
      get
      {
        return this.m_dbConnection;
      }
      set
      {
        this.m_dbConnection = value;
      }
    }

    static AdoNetAppender()
    {
    }

    public AdoNetAppender()
    {
      this.m_connectionType = "System.Data.OleDb.OleDbConnection, System.Data, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
      this.m_useTransactions = true;
      this.m_commandType = CommandType.Text;
      this.m_parameters = new ArrayList();
      this.m_reconnectOnError = false;
    }

    public override void ActivateOptions()
    {
      base.ActivateOptions();
      this.m_usePreparedCommand = this.m_commandText != null && this.m_commandText.Length > 0;
      if (this.m_securityContext == null)
        this.m_securityContext = SecurityContextProvider.DefaultProvider.CreateSecurityContext((object) this);
      this.InitializeDatabaseConnection();
      this.InitializeDatabaseCommand();
    }

    protected override void OnClose()
    {
      base.OnClose();
      this.DisposeCommand(false);
      this.DiposeConnection();
    }

    protected override void SendBuffer(LoggingEvent[] events)
    {
      if (this.m_reconnectOnError && (this.m_dbConnection == null || this.m_dbConnection.State != ConnectionState.Open))
      {
        LogLog.Debug(AdoNetAppender.declaringType, "Attempting to reconnect to database. Current Connection State: " + (this.m_dbConnection == null ? SystemInfo.NullText : ((object) this.m_dbConnection.State).ToString()));
        this.InitializeDatabaseConnection();
        this.InitializeDatabaseCommand();
      }
      if (this.m_dbConnection == null || this.m_dbConnection.State != ConnectionState.Open)
        return;
      if (this.m_useTransactions)
      {
        IDbTransaction dbTran = (IDbTransaction) null;
        try
        {
          dbTran = this.m_dbConnection.BeginTransaction();
          this.SendBuffer(dbTran, events);
          dbTran.Commit();
        }
        catch (Exception ex1)
        {
          if (dbTran != null)
          {
            try
            {
              dbTran.Rollback();
            }
            catch (Exception ex2)
            {
            }
          }
          this.ErrorHandler.Error("Exception while writing to database", ex1);
        }
      }
      else
        this.SendBuffer((IDbTransaction) null, events);
    }

    public void AddParameter(AdoNetAppenderParameter parameter)
    {
      this.m_parameters.Add((object) parameter);
    }

    protected virtual void SendBuffer(IDbTransaction dbTran, LoggingEvent[] events)
    {
      if (this.m_usePreparedCommand)
      {
        if (this.m_dbCommand == null)
          return;
        if (dbTran != null)
          this.m_dbCommand.Transaction = dbTran;
        foreach (LoggingEvent loggingEvent in events)
        {
          foreach (AdoNetAppenderParameter appenderParameter in this.m_parameters)
            appenderParameter.FormatValue(this.m_dbCommand, loggingEvent);
          this.m_dbCommand.ExecuteNonQuery();
        }
      }
      else
      {
        using (IDbCommand command = this.m_dbConnection.CreateCommand())
        {
          if (dbTran != null)
            command.Transaction = dbTran;
          foreach (LoggingEvent logEvent in events)
          {
            string logStatement = this.GetLogStatement(logEvent);
            LogLog.Debug(AdoNetAppender.declaringType, "LogStatement [" + logStatement + "]");
            command.CommandText = logStatement;
            command.ExecuteNonQuery();
          }
        }
      }
    }

    protected virtual string GetLogStatement(LoggingEvent logEvent)
    {
      if (this.Layout == null)
      {
        this.ErrorHandler.Error("AdoNetAppender: No Layout specified.");
        return "";
      }
      else
      {
        StringWriter stringWriter = new StringWriter((IFormatProvider) CultureInfo.InvariantCulture);
        this.Layout.Format((TextWriter) stringWriter, logEvent);
        return stringWriter.ToString();
      }
    }

    protected virtual IDbConnection CreateConnection(Type connectionType, string connectionString)
    {
      IDbConnection dbConnection = (IDbConnection) Activator.CreateInstance(connectionType);
      dbConnection.ConnectionString = connectionString;
      return dbConnection;
    }

    protected virtual string ResolveConnectionString(out string connectionStringContext)
    {
      if (this.m_connectionString != null && this.m_connectionString.Length > 0)
      {
        connectionStringContext = "ConnectionString";
        return this.m_connectionString;
      }
      else if (!string.IsNullOrEmpty(this.m_connectionStringName))
      {
        ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings[this.m_connectionStringName];
        if (connectionStringSettings == null)
          throw new LogException("Unable to find [" + this.m_connectionStringName + "] ConfigurationManager.ConnectionStrings item");
        connectionStringContext = "ConnectionStringName";
        return connectionStringSettings.ConnectionString;
      }
      else if (this.m_appSettingsKey != null && this.m_appSettingsKey.Length > 0)
      {
        connectionStringContext = "AppSettingsKey";
        string appSetting = SystemInfo.GetAppSetting(this.m_appSettingsKey);
        if (appSetting == null || appSetting.Length == 0)
          throw new LogException("Unable to find [" + this.m_appSettingsKey + "] AppSettings key.");
        else
          return appSetting;
      }
      else
      {
        connectionStringContext = "Unable to resolve connection string from ConnectionString, ConnectionStrings, or AppSettings.";
        return string.Empty;
      }
    }

    protected virtual Type ResolveConnectionType()
    {
      try
      {
        return SystemInfo.GetTypeFromString(this.m_connectionType, true, false);
      }
      catch (Exception ex)
      {
        this.ErrorHandler.Error("Failed to load connection type [" + this.m_connectionType + "]", ex);
        throw;
      }
    }

    private void InitializeDatabaseCommand()
    {
      if (this.m_dbConnection == null || !this.m_usePreparedCommand)
        return;
      try
      {
        this.DisposeCommand(false);
        this.m_dbCommand = this.m_dbConnection.CreateCommand();
        this.m_dbCommand.CommandText = this.m_commandText;
        this.m_dbCommand.CommandType = this.m_commandType;
      }
      catch (Exception ex)
      {
        this.ErrorHandler.Error("Could not create database command [" + this.m_commandText + "]", ex);
        this.DisposeCommand(true);
      }
      if (this.m_dbCommand != null)
      {
        try
        {
          foreach (AdoNetAppenderParameter appenderParameter in this.m_parameters)
          {
            try
            {
              appenderParameter.Prepare(this.m_dbCommand);
            }
            catch (Exception ex)
            {
              this.ErrorHandler.Error("Could not add database command parameter [" + appenderParameter.ParameterName + "]", ex);
              throw;
            }
          }
        }
        catch
        {
          this.DisposeCommand(true);
        }
      }
      if (this.m_dbCommand != null)
      {
        try
        {
          this.m_dbCommand.Prepare();
        }
        catch (Exception ex)
        {
          this.ErrorHandler.Error("Could not prepare database command [" + this.m_commandText + "]", ex);
          this.DisposeCommand(true);
        }
      }
    }

    private void InitializeDatabaseConnection()
    {
      string connectionStringContext = "Unable to determine connection string context.";
      string connectionString = string.Empty;
      try
      {
        this.DisposeCommand(true);
        this.DiposeConnection();
        connectionString = this.ResolveConnectionString(out connectionStringContext);
        this.m_dbConnection = this.CreateConnection(this.ResolveConnectionType(), connectionString);
        using (this.SecurityContext.Impersonate((object) this))
          this.m_dbConnection.Open();
      }
      catch (Exception ex)
      {
        this.ErrorHandler.Error("Could not open database connection [" + connectionString + "]. Connection string context [" + connectionStringContext + "].", ex);
        this.m_dbConnection = (IDbConnection) null;
      }
    }

    private void DisposeCommand(bool ignoreException)
    {
      if (this.m_dbCommand == null)
        return;
      try
      {
        this.m_dbCommand.Dispose();
      }
      catch (Exception ex)
      {
        if (!ignoreException)
          LogLog.Warn(AdoNetAppender.declaringType, "Exception while disposing cached command object", ex);
      }
      this.m_dbCommand = (IDbCommand) null;
    }

    private void DiposeConnection()
    {
      if (this.m_dbConnection == null)
        return;
      try
      {
        this.m_dbConnection.Close();
      }
      catch (Exception ex)
      {
        LogLog.Warn(AdoNetAppender.declaringType, "Exception while disposing cached connection object", ex);
      }
      this.m_dbConnection = (IDbConnection) null;
    }
  }
}
