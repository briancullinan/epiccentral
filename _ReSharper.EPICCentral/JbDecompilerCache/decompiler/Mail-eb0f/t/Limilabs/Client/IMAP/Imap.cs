// Type: Limilabs.Client.IMAP.Imap
// Assembly: Mail, Version=3.0.12207.2035, Culture=neutral, PublicKeyToken=6dc438ab78a525b3
// Assembly location: C:\EPICSource\developer1_ARIZONA21\EPIC Website\EPICCentral\3rdPartyLibraries\Mail.dll

using Limilabs.Client;
using Limilabs.Mail;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Limilabs.Client.IMAP
{
  /// <summary>
  /// IMAP client implementation.
  ///             It allows listing, moving, copying, downloading, uploading and deleting emails from IMAP servers.
  /// 
  /// </summary>
  public class Imap : TcpTextClient
  {
    /// <summary>
    /// Default IMAP protocol port (143).
    ///             If you need to use different port please use port parameter in <see cref="M:Limilabs.Client.TcpTextClient.Connect(System.String,System.Int32)"/> or <see cref="M:Limilabs.Client.TcpTextClient.Connect(System.String,System.Int32,System.Boolean)"/> method.
    /// 
    /// </summary>
    public const int DefaultPort = 143;
    /// <summary>
    /// Default IMAP protocol over SSL port (993).
    ///             If you need to use different port please use port parameter in <see cref="M:Limilabs.Client.TcpTextClient.ConnectSSL(System.String,System.Int32)"/> or <see cref="M:Limilabs.Client.TcpTextClient.Connect(System.String,System.Int32,System.Boolean)"/> method.
    /// 
    /// </summary>
    public const int DefaultSSLPort = 993;
    private readonly \u0002\u2003\u2000 \u0002;
    internal FolderStatus \u0003;
    private readonly \u000E\u2006\u2000 \u0005;
    internal readonly \u0006\u2004\u2000 \u0008;
    private IDInformation \u0006;
    private int \u000E;

    /// <summary>
    /// Represents client information send to the server on connection using ID command (<see cref="F:Limilabs.Client.IMAP.ImapExtension.ID"/>).
    /// 
    /// </summary>
    public IDInformation IDInformation
    {
      get
      {
        return this.\u0006;
      }
    }

    /// <summary>
    /// Gets or set the length of the generated unique command identifier.
    /// 
    /// </summary>
    public int CommandTagLength
    {
      get
      {
        return this.\u000E;
      }
      set
      {
        this.\u000E = value;
      }
    }

    /// <summary>
    /// Gets the status of the currently selected folder.
    /// 
    /// </summary>
    public FolderStatus CurrentFolder
    {
      get
      {
        return this.\u0003;
      }
    }

    /// <summary>
    /// Initializes new instance of the Imap class.
    /// 
    /// </summary>
    public Imap()
      : this(AddressFamily.InterNetwork)
    {
      this.\u0002(new IDInformation());
    }

    /// <summary>
    /// Initializes new instance of the Imap class.
    /// 
    /// </summary>
    /// <param name="addressFamily">Address family.</param>
    public Imap(AddressFamily addressFamily)
      : base(addressFamily)
    {
      this.\u0002 = new \u0002\u2003\u2000(this);
      this.CommandTagLength = 16;
    }

    private void \u0002(IDInformation \u0002)
    {
      this.\u0006 = param0;
    }

    /// <summary>
    /// Override this function to get server's greeting.
    /// 
    /// </summary>
    protected override void GetServerGreeting()
    {
      ImapResponse imapResponse = new ImapResponse(\u0006\u2001\u2004.\u0002(-195387792));
      imapResponse.\u0002(this.Stream);
      this.\u0008.\u0002(imapResponse.Message);
      if (this.\u0008.\u0002() == \u0008\u2004\u2000.Yahoo)
        this.SendYahooIDCommand();
      if (((\u000E\u2005) this.\u0005).\u0003())
        this.\u0002(false);
      if (!this.\u0005.\u0002(ImapExtension.ID))
        return;
      this.\u0002();
    }

    private void \u0002()
    {
      this.SendCommand(string.Format(\u0006\u2001\u2004.\u0002(-195389670) + this.IDInformation.\u0002(), new object[0]), false);
    }

    /// <summary>
    /// Connects to IMAP server on port 143. Use <see cref="M:Limilabs.Client.IMAP.Imap.ConnectSSL(System.String)"/> when SSL connection is needed.
    /// 
    /// </summary>
    /// <param name="host">Target host name or IP address.</param><exception cref="T:Limilabs.Client.ServerException">Error response,
    ///             DNS resolving error,
    ///             Connecting error.
    ///              </exception>
    public void Connect(string host)
    {
      base.Connect(host, 143);
    }

    /// <summary>
    /// Connects to IMAP server using SSL on port 993.
    /// 
    /// </summary>
    /// <param name="host">Target host name or IP address.</param><seealso cref="M:Limilabs.Client.TcpTextClient.Connect(System.String,System.Int32,System.Boolean)"/><exception cref="T:Limilabs.Client.ServerException">Error response,
    ///             DNS resolving error,
    ///             Connecting error.
    ///              </exception>
    public void ConnectSSL(string host)
    {
      base.Connect(host, 993, true);
    }

    /// <summary>
    /// Begins an asynchronous request for a remote server connection using <see cref="F:Limilabs.Client.IMAP.Imap.DefaultPort"/>.
    /// 
    /// </summary>
    /// <param name="host">The name or IP address of the remote server.</param>
    /// <returns>
    /// An IAsyncResult that references the asynchronous connection.
    /// </returns>
    public IAsyncResult BeginConnect(string host)
    {
      return this.BeginConnect(host, (AsyncCallback) null);
    }

    /// <summary>
    /// Begins an asynchronous request for a remote server connection using <see cref="F:Limilabs.Client.IMAP.Imap.DefaultPort"/>.
    /// 
    /// </summary>
    /// <param name="host">The name or IP address of the remote server.</param><param name="asyncCallback">The AsyncCallback delegate.</param>
    /// <returns>
    /// An IAsyncResult that references the asynchronous connection.
    /// </returns>
    public IAsyncResult BeginConnect(string host, AsyncCallback asyncCallback)
    {
      return base.BeginConnect(host, 143, false, asyncCallback);
    }

    /// <summary>
    /// Begins an asynchronous request for a remote server secure connection using <see cref="F:Limilabs.Client.IMAP.Imap.DefaultSSLPort"/> and SSL.
    /// 
    /// </summary>
    /// <param name="host">The name or IP address of the remote server.</param>
    /// <returns>
    /// An IAsyncResult that references the asynchronous connection.
    /// </returns>
    public IAsyncResult BeginConnectSSL(string host)
    {
      return this.BeginConnectSSL(host, (AsyncCallback) null);
    }

    /// <summary>
    /// Begins an asynchronous request for a remote server secure connection using <see cref="F:Limilabs.Client.IMAP.Imap.DefaultSSLPort"/> and SSL.
    /// 
    /// </summary>
    /// <param name="host">The name or IP address of the remote server.</param><param name="asyncCallback">The AsyncCallback delegate.</param>
    /// <returns>
    /// An IAsyncResult that references the asynchronous connection.
    /// </returns>
    public IAsyncResult BeginConnectSSL(string host, AsyncCallback asyncCallback)
    {
      return base.BeginConnect(host, 993, true, asyncCallback);
    }

    /// <summary>
    /// Sends 'STARTTLS' command and initializes SSL connection.
    ///             Not all servers support <see cref="F:Limilabs.Client.IMAP.ImapExtension.StartTLS"/>. You can check which extensions remote server supports using <see cref="M:Limilabs.Client.IMAP.Imap.SupportedExtensions"/> method.
    /// 
    /// </summary>
    public void StartTLS()
    {
      ((\u000E\u2005) this.\u0005).\u0002();
      this.SendCommand(\u0006\u2001\u2004.\u0002(-195389588));
      base.\u0003();
      if (!((\u000E\u2005) this.\u0005).\u0003())
        return;
      this.\u0002(false);
    }

    /// <summary>
    /// Logs user in using best available method.
    ///             When no AUTH capability is found, this method switches to SSL (<see cref="M:Limilabs.Client.IMAP.Imap.StartTLS"/>) and tries again.
    /// 
    /// </summary>
    /// <param name="user">User's login.</param><param name="password">User's password.</param><seealso cref="M:Limilabs.Client.IMAP.Imap.Login(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginPLAIN(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginPLAIN(System.String,System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginCRAM(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginOAUTH(System.String)"/><exception cref="T:Limilabs.Client.ServerException">Throws <see cref="T:Limilabs.Client.ServerException"/> on negative response.</exception>
    public void UseBestLogin(string user, string password)
    {
      switch (this.\u0005.\u000F())
      {
        case (\u0008\u2003\u2000) 0:
          if (this.\u0006())
          {
            this.UseBestLogin(user, password);
            break;
          }
          else
          {
            this.\u0002(user, password);
            break;
          }
        case (\u0008\u2003\u2000) 1:
          this.\u0002(user, password);
          break;
        case (\u0008\u2003\u2000) 2:
          this.LoginPLAIN(user, password);
          break;
        case (\u0008\u2003\u2000) 3:
          this.LoginCRAM(user, password);
          break;
        case (\u0008\u2003\u2000) 4:
          this.LoginDIGEST(user, password);
          break;
        case (\u0008\u2003\u2000) 5:
          this.\u0005(user, password);
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private bool \u0006()
    {
      if (this.IsEncrypted || !this.\u0005.\u000E())
        return false;
      this.StartTLS();
      return true;
    }

    /// <summary>
    /// Logs user in using LOGIN command.
    ///             When LOGIN command is disabled by including the LOGINDISABLED capability this method tries to log-in using <see cref="M:Limilabs.Client.IMAP.Imap.UseBestLogin(System.String,System.String)"/>.
    ///             Unless SSL connection is used this method sends the password in clear text.
    ///             You can check which methods remote server supports using <see cref="M:Limilabs.Client.IMAP.Imap.SupportedAuthenticationMethods"/> method.
    /// 
    /// </summary>
    /// <param name="user">User's login.</param><param name="password">User's password.</param><seealso cref="M:Limilabs.Client.IMAP.Imap.Login(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginPLAIN(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginPLAIN(System.String,System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginCRAM(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginDIGEST(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginOAUTH(System.String)"/><exception cref="T:Limilabs.Client.ServerException">Throws <see cref="T:Limilabs.Client.ServerException"/> on negative response.</exception>
    public void Login(string user, string password)
    {
      if (this.\u0005.\u0008())
        this.UseBestLogin(user, password);
      else
        this.\u0002(user, password);
    }

    private void \u0002(string \u0002, string \u0003)
    {
      TcpTextClient.\u0002(param0, param1);
      ImapCommand imapCommand = new ImapCommand(Encoding.Default);
      imapCommand.\u0002(\u0006\u2001\u2004.\u0002(-195389597));
      imapCommand.\u0002(\u0006\u2001\u2004.\u0002(-195393923));
      imapCommand.\u0003(param0);
      imapCommand.\u0002(\u0006\u2001\u2004.\u0002(-195393923));
      imapCommand.\u0003(param1);
      this.\u0002(imapCommand);
    }

    /// <summary>
    /// Logs user in using AUTHENTICATE PLAIN command. This method sends the password in clear text (BASE64), unless SSL connection is used.
    /// 
    /// </summary>
    /// <param name="user">User's login.</param><param name="password">User's password.</param><seealso cref="M:Limilabs.Client.IMAP.Imap.ConnectSSL(System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.Login(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginPLAIN(System.String,System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginCRAM(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginDIGEST(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginOAUTH(System.String)"/><exception cref="T:Limilabs.Client.ServerException">Throws <see cref="T:Limilabs.Client.ServerException"/> on negative response.</exception>
    public void LoginPLAIN(string user, string password)
    {
      this.LoginPLAIN(string.Empty, user, password);
    }

    /// <summary>
    /// Logs user in using AUTHENTICATE PLAIN command. This method sends the password in clear text (BASE64), unless SSL connection is used.
    /// 
    /// </summary>
    /// <param name="user">User's login.</param><param name="adminUser">Administrator's user.</param><param name="adminPassword">Administrator's password.</param><seealso cref="M:Limilabs.Client.IMAP.Imap.ConnectSSL(System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.Login(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginPLAIN(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginCRAM(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginDIGEST(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginOAUTH(System.String)"/><exception cref="T:Limilabs.Client.ServerException">Throws <see cref="T:Limilabs.Client.ServerException"/> on negative response.</exception>
    public void LoginPLAIN(string user, string adminUser, string adminPassword)
    {
      TcpTextClient.\u0002(adminUser, adminPassword);
      ImapResponse imapResponse1 = this.\u0002(\u0006\u2001\u2004.\u0002(-195389577));
      this.Send(new \u0006\u2005(user, adminUser, adminPassword).\u0002());
      ImapResponse imapResponse2 = this.ReceiveResponse(imapResponse1.Tag);
      if (imapResponse2.ImapResponseStatus != ImapResponseStatus.Positive)
        throw new ServerException(imapResponse2.Message);
    }

    /// <summary>
    /// Logs user in using AUTHENTICATE CRAM-MD5 command. This method does NOT send the password in clear text.
    ///             You can check which methods remote server supports using <see cref="M:Limilabs.Client.IMAP.Imap.SupportedAuthenticationMethods"/> method.
    /// 
    /// </summary>
    /// <param name="user">User's login.</param><param name="password">User's password.</param>
    /// <remarks>
    /// This command is unnecessary if you are using SSL, use <see cref="M:Limilabs.Client.IMAP.Imap.Login(System.String,System.String)"/> method instead.
    /// 
    /// </remarks>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.ConnectSSL(System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.Login(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginPLAIN(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginPLAIN(System.String,System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginDIGEST(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginOAUTH(System.String)"/><exception cref="T:Limilabs.Client.ServerException">Throws <see cref="T:Limilabs.Client.ServerException"/> on negative response.</exception>
    public void LoginCRAM(string user, string password)
    {
      TcpTextClient.\u0002(user, password);
      ImapResponse imapResponse1 = this.\u0002(\u0006\u2001\u2004.\u0002(-195389608));
      this.Send(new \u0006\u2003(user, password, imapResponse1.Message).\u0002());
      ImapResponse imapResponse2 = this.ReceiveResponse(imapResponse1.Tag);
      if (imapResponse2.ImapResponseStatus != ImapResponseStatus.Positive)
        throw new ServerException(imapResponse2.Message);
    }

    /// <summary>
    /// Logs user in using AUTHENTICATE DIGEST-MD5 command. This method does NOT send the password in clear text.
    ///             You can check which methods remote server supports using <see cref="M:Limilabs.Client.IMAP.Imap.SupportedAuthenticationMethods"/> method.
    /// 
    /// </summary>
    /// <param name="user">User's login.</param><param name="password">User's password.</param>
    /// <remarks>
    /// This command is unnecessary if you are using SSL, use <see cref="M:Limilabs.Client.IMAP.Imap.Login(System.String,System.String)"/> method instead.
    /// 
    /// </remarks>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.ConnectSSL(System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.Login(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginPLAIN(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginPLAIN(System.String,System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginCRAM(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginOAUTH(System.String)"/><exception cref="T:Limilabs.Client.ServerException">Throws <see cref="T:Limilabs.Client.ServerException"/> on negative response.</exception>
    public void LoginDIGEST(string user, string password)
    {
      TcpTextClient.\u0002(user, password);
      ImapResponse imapResponse1 = this.\u0002(\u0006\u2001\u2004.\u0002(-195389508));
      this.Send(new \u000F\u2003(user, password, \u0006\u2001\u2004.\u0002(-195389566), imapResponse1.Message).\u0003());
      ImapResponse imapResponse2 = this.ReceiveResponse(imapResponse1.Tag);
      if (imapResponse2.ImapResponseStatus != ImapResponseStatus.SendMoreData)
        throw new ServerException(imapResponse2.StatusLine);
      this.Send(string.Empty);
      ImapResponse imapResponse3 = this.ReceiveResponse(imapResponse1.Tag);
      if (imapResponse3.ImapResponseStatus != ImapResponseStatus.Positive)
        throw new ServerException(imapResponse3.Message);
    }

    internal void \u0002(string \u0002, string \u0003, string \u0005, string \u0008)
    {
      this.\u0002(param0, param1, param2, param3, false);
    }

    internal void \u0003(string \u0002, string \u0003, string \u0005, string \u0008)
    {
      this.\u0002(param0, param1, param2, param3, true);
    }

    internal void \u0003(string \u0002, string \u0003)
    {
      this.\u0003(Environment.UserDomainName, Environment.MachineName, param0, param1);
    }

    internal void \u0005(string \u0002, string \u0003)
    {
      this.\u0002(Environment.UserDomainName, Environment.MachineName, param0, param1);
    }

    internal void \u0002(string \u0002, string \u0003, string \u0005, string \u0008, bool \u0006)
    {
      Log.\u0002(\u0006\u2001\u2004.\u0002(-195389546));
      Log.\u0002(\u0006\u2001\u2004.\u0002(-195389471) + param0);
      Log.\u0002(\u0006\u2001\u2004.\u0002(-195389456) + param1);
      Log.\u0002(\u0006\u2001\u2004.\u0002(-195389476) + param2);
      Log.\u0002(\u0006\u2001\u2004.\u0002(-195389487));
      Log.\u0002(\u0006\u2001\u2004.\u0002(-195389917) + (object) (bool) (param4 ? 1 : 0));
      TcpTextClient.\u0002(param2, param3);
      ImapResponse imapResponse1 = this.\u0002(\u0006\u2001\u2004.\u0002(-195389940));
      this.Send(new \u0003\u2005(param0, param1).\u0008());
      ImapResponse imapResponse2 = this.ReceiveResponse(imapResponse1.Tag);
      if (imapResponse2.ImapResponseStatus != ImapResponseStatus.SendMoreData)
        throw new ServerException(imapResponse2.StatusLine);
      \u0005\u2005 obj1 = \u0005\u2005.\u0005(Convert.FromBase64String(imapResponse2.Message));
      Log.\u0002(\u0006\u2001\u2004.\u0002(-195389932) + (object) ((\u0002\u2004) obj1).\u0002());
      Log.\u0002(\u0006\u2001\u2004.\u0002(-195389853) + \u000E\u2006\u2001.\u0002(obj1.\u0002()));
      Log.\u0002(\u0006\u2001\u2004.\u0002(-195389882) + \u000E\u2006\u2001.\u0002(obj1.\u0003()));
      foreach (\u000F\u2004 obj2 in obj1.\u0005())
        Log.\u0002(string.Concat(new object[4]
        {
          (object) \u0006\u2001\u2004.\u0002(-195389762),
          (object) obj2.\u0002(),
          (object) \u0006\u2001\u2004.\u0002(-195389716),
          (object) obj2.\u0005()
        }));
      \u0008\u2005 obj3 = new \u0008\u2005(param0, param2, param1);
      if (param4)
        obj3.\u0002(param3, obj1.\u0002(), obj1.\u0003());
      else
        obj3.\u0002(param3, obj1.\u0002());
      this.Send(obj3.\u0008());
      ImapResponse imapResponse3 = this.ReceiveResponse(imapResponse1.Tag);
      if (imapResponse3.ImapResponseStatus != ImapResponseStatus.Positive)
        throw new ServerException(imapResponse3.Message);
    }

    /// <summary>
    /// Logs user in using AUTHENTICATE XOAUTH command. This method does NOT send the password.
    ///             You can use <see cref="T:Limilabs.Client.Authentication.OAuth"/> class to create the key.
    ///             You can check which methods remote server supports using <see cref="M:Limilabs.Client.IMAP.Imap.SupportedAuthenticationMethods"/> method.
    /// 
    /// </summary>
    /// <param name="key">XOAuth key. The key will be encoded using BASE64. You can use <see cref="M:Limilabs.Client.Authentication.ISignedOAuth.GetXOAuthKey"/> method to create this key.</param><seealso cref="M:Limilabs.Client.IMAP.Imap.Login(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginPLAIN(System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginPLAIN(System.String,System.String,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.LoginCRAM(System.String,System.String)"/>
    public void LoginOAUTH(string key)
    {
      this.SendCommand(\u0006\u2001\u2004.\u0002(-195389728) + \u0005\u2005\u2001.\u0003(key));
    }

    internal ImapResponse \u0002(string \u0002, object[] \u0003)
    {
      return this.SendCommand(string.Format(param0, param1), true);
    }

    /// <summary>
    /// Sends command and waits for the server response.
    /// 
    /// </summary>
    /// <exception cref="T:Limilabs.Client.ServerException">BAD -or- NO response.
    ///             </exception>
    /// <remarks>
    /// Most commands have their own specialized methods in this class, you should probably use them instead.
    ///             This is equivalent to calling 'SendCommand(command, <c>true</c>);'.
    /// 
    /// </remarks>
    /// <param name="command">Command e.g. "NOOP".</param>
    /// <returns>
    /// IMAP response object.
    /// </returns>
    public ImapResponse SendCommand(string command)
    {
      return this.SendCommand(command, true);
    }

    /// <summary>
    /// Sends command and waits for the server response.
    /// 
    /// </summary>
    /// <exception cref="T:Limilabs.Client.ServerException">Throws <see cref="T:Limilabs.Client.ServerException"/> on BAD -or- NO response (if '<paramref name="throwException"/>' is set to <c>true</c>).
    ///             </exception>
    /// <remarks>
    /// Most commands have their own specialized methods in this class, you should probably use them instead.
    /// 
    /// </remarks>
    /// <param name="command">Command e.g. "NOOP".</param><param name="throwException">If <c>true</c> throws <see cref="T:Limilabs.Client.ServerException"/> on response other then OK</param>
    /// <returns>
    /// IMAP response object.
    /// </returns>
    public ImapResponse SendCommand(string command, bool throwException)
    {
      ImapCommand imapCommand = new ImapCommand(\u0002\u2003\u2001.\u0002());
      imapCommand.\u0002(command);
      return this.\u0002(imapCommand, throwException);
    }

    internal string \u000E()
    {
      return Guid.NewGuid().ToString(\u0006\u2001\u2004.\u0002(-195389749)).Substring(0, this.CommandTagLength);
    }

    internal ImapResponse \u0002(string \u0002)
    {
      ImapResponse imapResponse = this.SendCommand(param0, false);
      if (imapResponse.ImapResponseStatus != ImapResponseStatus.SendMoreData)
        throw new ServerException(\u0006\u2001\u2004.\u0002(-195389757) + imapResponse.StatusLine);
      else
        return imapResponse;
    }

    /// <summary>
    /// Sends the LOGOUT command.
    /// 
    /// </summary>
    /// <param name="throwException">If <c>true</c> throws <see cref="T:Limilabs.Client.ServerException"/> on response other then OK</param><exception cref="T:Limilabs.Client.ServerException">Throws <see cref="T:Limilabs.Client.ServerException"/> on response other then OK to LOGOUT command.
    ///             </exception>
    protected override void CloseCommand(bool throwException)
    {
      this.SendCommand(\u0006\u2001\u2004.\u0002(-195390196), throwException);
      base.CloseCommand(throwException);
    }

    /// <summary>
    /// Receives the response ending with specified request tag.
    /// 
    /// </summary>
    /// <param name="tag">Request tag</param>
    /// <returns>
    /// IMAP response object.
    /// </returns>
    public ImapResponse ReceiveResponse(string tag)
    {
      ImapResponse imapResponse = new ImapResponse(tag);
      imapResponse.\u0002(this.Stream);
      this.\u0002(imapResponse);
      return imapResponse;
    }

    private void \u0002(ImapResponse \u0002)
    {
      if (this.\u0003 != null)
        new \u0003\u2006\u2000(param0).\u0002(this.\u0003);
      new \u0008\u2005\u2000(param0).\u0002(this.\u0005);
    }

    /// <summary>
    /// Sends CAPABILITY command.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// Server's capability list.
    /// </returns>
    public List<string> Capability()
    {
      this.\u0002(true);
      return ((\u000E\u2005) this.\u0005).\u0005();
    }

    private void \u0002(bool \u0002)
    {
      this.SendCommand(\u0006\u2001\u2004.\u0002(-195390207), param0);
    }

    /// <summary>
    /// Lists extensions supported by the remote server (e.g. SORT, XLIST, UIDPLUS)
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// Extensions supported by remote server.
    /// </returns>
    public List<ImapExtension> SupportedExtensions()
    {
      return this.\u0005.\u0002();
    }

    /// <summary>
    /// Lists authentication methods supported by the remote server.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// Authentication methods supported by remote server.
    /// </returns>
    public List<ImapAuthenticationMethod> SupportedAuthenticationMethods()
    {
      return this.\u0005.\u0005();
    }

    /// <summary>
    /// Lists threading methods supported by the remote server.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// Authentication methods supported by remote server.
    /// </returns>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.Thread(Limilabs.Client.IMAP.ThreadMethod,Limilabs.Client.IMAP.ICriterion)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.Thread(Limilabs.Client.IMAP.ThreadMethod)"/>
    public List<ThreadMethod> SupportedThreadMethods()
    {
      return this.\u0005.\u0003();
    }

    /// <summary>
    /// Gets quotas for specified folder.
    ///             Not all servers support <see cref="F:Limilabs.Client.IMAP.ImapExtension.Quota"/>, you can check which extensions remote server supports using <see cref="M:Limilabs.Client.IMAP.Imap.SupportedExtensions"/> method.
    /// 
    /// </summary>
    /// <param name="folder">Folder name.</param>
    /// <returns>
    /// Quotas for specified folder.
    /// </returns>
    public List<Quota> GetQuotaRoot(string folder)
    {
      folder = Imap.\u0003(folder);
      return new \u0005\u2008\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195390190), new object[1]
      {
        (object) folder
      })).\u0003();
    }

    /// <summary>
    /// Gets quota with specified name.
    ///             Not all servers support <see cref="F:Limilabs.Client.IMAP.ImapExtension.Quota"/>, you can check which extensions remote server supports using <see cref="M:Limilabs.Client.IMAP.Imap.SupportedExtensions"/> method.
    /// 
    /// </summary>
    /// <param name="name">Name of the quota.</param>
    /// <returns>
    /// Quota with specified name.
    /// </returns>
    public Quota GetQuota(string name)
    {
      return new \u0005\u2008\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195390085), new object[1]
      {
        (object) name
      })).\u0002();
    }

    /// <summary>
    /// Issues CLOSE command to the server.
    ///             Unless Examine was used to open folder, CLOSE command permanently removes all messages that have the <see cref="F:Limilabs.Client.IMAP.Flag.Deleted"/> flag set from the currently selected folder,
    ///             and returns to the authenticated state from the selected state (no folder is selected).
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.Select(System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.Select(Limilabs.Client.IMAP.FolderInfo)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.SelectInbox"/><seealso cref="M:Limilabs.Client.IMAP.Imap.Examine(System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.Examine(Limilabs.Client.IMAP.FolderInfo)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.ExamineInbox"/>
    public void CloseCurrentFolder()
    {
      this.SendCommand(\u0006\u2001\u2004.\u0002(-195390144));
      this.\u0003 = (FolderStatus) null;
    }

    private static string \u0003(string \u0002)
    {
      return new \u0002\u2004\u2001().\u0003(\u000F​\u2003.\u0002(param0));
    }

    /// <summary>
    /// The STATUS command requests the status of the indicated mailbox.
    ///             It does not change the currently selected mailbox, nor does it affect the state of any messages in the queried mailbox (messages don't lose the <see cref="F:Limilabs.Client.IMAP.Flag.Recent"/>) flag.
    ///             This command MUST NOT be used as a "check for new messages in the selected mailbox" operation
    ///             (You should rather use <see cref="T:Limilabs.Client.IMAP.FolderStatus"/> and <see cref="M:Limilabs.Client.IMAP.Imap.Noop"/> or <see cref="P:Limilabs.Client.IMAP.FolderStatus.UIDNext"/>) or <see cref="M:Limilabs.Client.IMAP.Imap.SearchFlag(Limilabs.Client.IMAP.Flag)"/>).
    ///             STATUS command is not guaranteed to be fast in its response.
    /// 
    /// </summary>
    /// <param name="folder">Folder name.</param>
    /// <returns>
    /// Status information of the specified folder.
    /// </returns>
    public Status Status(string folder)
    {
      folder = Imap.\u0003(folder);
      return new \u000E\u2008\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195390124), new object[2]
      {
        (object) folder,
        (object) \u0006\u2001\u2004.\u0002(-195390019)
      })).\u0002();
    }

    /// <summary>
    /// The STATUS command requests the status of the indicated mailbox.
    ///             It does not change the currently selected mailbox, nor does it affect the state of any messages in the queried mailbox (messages don't lose the <see cref="F:Limilabs.Client.IMAP.Flag.Recent"/>) flag.
    ///             This command MUST NOT be used as a "check for new messages in the selected mailbox" operation
    ///             (You should rather use <see cref="T:Limilabs.Client.IMAP.FolderStatus"/> and <see cref="M:Limilabs.Client.IMAP.Imap.Noop"/> or <see cref="P:Limilabs.Client.IMAP.FolderStatus.UIDNext"/>) or <see cref="M:Limilabs.Client.IMAP.Imap.SearchFlag(Limilabs.Client.IMAP.Flag)"/>).
    ///             STATUS command is not guaranteed to be fast in its response.
    /// 
    /// </summary>
    /// <param name="folder">Folder name.</param>
    /// <returns>
    /// Status information of the specified folder.
    /// </returns>
    public Status Status(FolderInfo folder)
    {
      return this.Status(folder.Name);
    }

    /// <summary>
    /// Selects 'INBOX' as a current folder (mailbox) so that messages inside can be accessed.
    ///             Select command will remove the <see cref="F:Limilabs.Client.IMAP.Flag.Recent"/> flag since the folder has now been viewed
    ///             (This is not the same as the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> IMAP flag).
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// Status of the folder (mailbox). It can be updated by subsequent <see cref="M:Limilabs.Client.IMAP.Imap.Noop"/> commands or other commands.
    /// </returns>
    public FolderStatus SelectInbox()
    {
      return this.Select(\u0006\u2001\u2004.\u0002(-195387992));
    }

    /// <summary>
    /// Selects specified folder (mailbox) as the current folder so that messages inside can be accessed.
    ///             Select command will remove the <see cref="F:Limilabs.Client.IMAP.Flag.Recent"/> flag since the folder has now been viewed
    ///             (This is not the same as the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> IMAP flag).
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// If folder.Flags contain <see cref="F:Limilabs.Client.IMAP.FolderFlag.XInbox"/> this method invokes <see cref="M:Limilabs.Client.IMAP.Imap.SelectInbox"/> method.
    /// 
    /// </remarks>
    /// <param name="folder">Folder to select.</param>
    /// <returns>
    /// Status of the folder (mailbox). It can be updated by subsequent <see cref="M:Limilabs.Client.IMAP.Imap.Noop"/> or other commands.
    /// </returns>
    public FolderStatus Select(FolderInfo folder)
    {
      if (folder.Flags.Contains(FolderFlag.XInbox))
        return this.SelectInbox();
      else
        return this.Select(folder.Name);
    }

    /// <summary>
    /// Selects specified folder (mailbox) as the current folder so that messages inside can be accessed.
    ///             Select command will remove the <see cref="F:Limilabs.Client.IMAP.Flag.Recent"/> flag since the folder has now been viewed
    ///             (This is not the same as the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> IMAP flag).
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// <param name="folder">Folder name.</param>
    /// <returns>
    /// Status of the folder (mailbox). It can be updated by subsequent <see cref="M:Limilabs.Client.IMAP.Imap.Noop"/> or other commands.
    /// </returns>
    public FolderStatus Select(string folder)
    {
      this.\u0003 = new FolderStatus(folder);
      this.\u0002(\u0006\u2001\u2004.\u0002(-195389970), new object[1]
      {
        (object) Imap.\u0003(folder)
      });
      return this.\u0003;
    }

    /// <summary>
    /// Selects 'INBOX' as a current read-only folder (mailbox) so that messages inside can be accessed.
    ///             Examine command will not reset the <see cref="F:Limilabs.Client.IMAP.Flag.Recent"/> flag
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// Status of the folder (mailbox).
    /// </returns>
    public FolderStatus ExamineInbox()
    {
      return this.Examine(\u0006\u2001\u2004.\u0002(-195387992));
    }

    /// <summary>
    /// Selects specified folder (mailbox) as the current read-only folder so that messages inside can be accessed.
    ///             Examine command will not reset the <see cref="F:Limilabs.Client.IMAP.Flag.Recent"/> flag
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// <param name="folder">Folder name.</param>
    /// <returns>
    /// Status of the folder (mailbox).
    /// </returns>
    public FolderStatus Examine(string folder)
    {
      this.\u0003 = new FolderStatus(folder);
      this.\u0002(\u0006\u2001\u2004.\u0002(-195389959), new object[1]
      {
        (object) Imap.\u0003(folder)
      });
      return this.\u0003;
    }

    /// <summary>
    /// Selects specified folder (mailbox) as the current read-only folder so that messages inside can be accessed.
    ///             Examine command will not reset the <see cref="F:Limilabs.Client.IMAP.Flag.Recent"/> flag.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// If folder.Flags contain <see cref="F:Limilabs.Client.IMAP.FolderFlag.XInbox"/> this method invokes <see cref="M:Limilabs.Client.IMAP.Imap.ExamineInbox"/>.
    /// 
    /// </remarks>
    /// I
    ///             <param name="folder">Folder name.</param>
    /// <returns>
    /// Status of the folder (mailbox).
    /// </returns>
    public FolderStatus Examine(FolderInfo folder)
    {
      if (folder.Flags.Contains(FolderFlag.XInbox))
        return this.ExamineInbox();
      else
        return this.Examine(folder.Name);
    }

    /// <summary>
    /// Always succeeds. It does nothing.
    ///             Can be used as a periodic poll for new messages - updates <see cref="T:Limilabs.Client.IMAP.FolderStatus"/> returned by last <see cref="M:Limilabs.Client.IMAP.Imap.Select(System.String)"/>, <see cref="M:Limilabs.Client.IMAP.Imap.Select(Limilabs.Client.IMAP.FolderInfo)"/> command.
    ///             Can also be used to reset any inactivity auto-logout timer on the server.
    /// 
    /// </summary>
    public void Noop()
    {
      this.SendCommand(\u0006\u2001\u2004.\u0002(-195390011));
    }

    /// <summary>
    /// Creates new threading query.
    /// 
    /// </summary>
    /// 
    /// <example>
    /// List&lt;<see cref="T:Limilabs.Client.IMAP.FluentThread"/>&gt; threads = imap.Thread(ThreadMethod.OrderedSubject).Where(Expression.Text("text"));
    /// 
    /// </example>
    /// 
    /// <example>
    /// List&lt;<see cref="T:Limilabs.Client.IMAP.FluentThread"/>&gt; threads = imap.Thread(ThreadMethod.OrderedSubject).Where(Expression.Text("text")).ResultAs(<see cref="F:Limilabs.Client.IMAP.ResultType.Numbers"/>);
    /// 
    /// </example>
    /// 
    /// <returns>
    /// New threading query.
    /// </returns>
    public FluentThread Thread(ThreadMethod method)
    {
      this.\u0005();
      FluentThread fluentThread = new FluentThread(new \u0005\u2004\u2000(this.\u0003), this.\u0005.\u0003());
      fluentThread.SetThreadMethod(method);
      return fluentThread;
    }

    /// <summary>
    /// Gets threaded messages, that match specified search criteria, using server-side threading.
    ///             Use <see cref="M:Limilabs.Client.IMAP.Expression.And(Limilabs.Client.IMAP.ICriterion[])"/>, <see cref="M:Limilabs.Client.IMAP.Expression.Or(Limilabs.Client.IMAP.ICriterion,Limilabs.Client.IMAP.ICriterion)"/> and other <see cref="T:Limilabs.Client.IMAP.Expression"/> methods to create a valid search query.
    /// 
    /// </summary>
    /// <param name="method">Threading method that should be used.</param><param name="criterion">Search criteria. Use <see cref="M:Limilabs.Client.IMAP.Expression.And(Limilabs.Client.IMAP.ICriterion[])"/> to join several criterions.</param>
    /// <returns>
    /// List of message threads.
    /// </returns>
    public List<MessageThread> Thread(ThreadMethod method, ICriterion criterion)
    {
      return (List<MessageThread>) this.Thread(method).Where(criterion);
    }

    /// <summary>
    /// Gets threaded messages, that match specified search criteria, using server-side threading. Uses <see cref="F:Limilabs.Client.IMAP.ResultType.Numbers"/> as <see cref="M:Limilabs.Client.IMAP.FluentThread.ResultsAs(Limilabs.Client.IMAP.ResultType)"/> method parameter.
    ///             Use <see cref="M:Limilabs.Client.IMAP.Expression.And(Limilabs.Client.IMAP.ICriterion[])"/>, <see cref="M:Limilabs.Client.IMAP.Expression.Or(Limilabs.Client.IMAP.ICriterion,Limilabs.Client.IMAP.ICriterion)"/> and other <see cref="T:Limilabs.Client.IMAP.Expression"/> methods to create a valid search query.
    /// 
    /// </summary>
    /// <param name="method">Threading method that should be used.</param><param name="criterion">Search criteria. Use <see cref="M:Limilabs.Client.IMAP.Expression.And(Limilabs.Client.IMAP.ICriterion[])"/> to join several criterions.</param>
    /// <returns>
    /// List of message threads.
    /// </returns>
    public List<MessageThread> ThreadNumbers(ThreadMethod method, ICriterion criterion)
    {
      return (List<MessageThread>) this.Thread(method).ResultsAs(ResultType.Numbers).Where(criterion);
    }

    /// <summary>
    /// Gets UIDs of all messages in the current folder (mailbox) sorted from oldest to newest. Equivalent to Search(Expression.All()).
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.GetMessageByUID(System.Int64)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.GetHeadersByUID(System.Int64)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.PeekMessageByUID(System.Int64)"/>
    /// <returns>
    /// UID list sorted from oldest to newest.
    /// </returns>
    public List<long> GetAll()
    {
      return (List<long>) this.Search().Where(Expression.All());
    }

    /// <summary>
    /// Creates new search query.
    /// 
    /// </summary>
    /// 
    /// <example>
    /// List&lt;long&gt; uids = imap.Search().Where(Expression.Subject("report")).Sort(SortBy.Date());
    /// 
    /// </example>
    /// 
    /// <example>
    /// List&lt;long&gt; numbers = imap.Search().Where(Expression.Header("Message-ID", "id")).ResultAs(<see cref="F:Limilabs.Client.IMAP.ResultType.Numbers"/>);
    /// 
    /// </example>
    /// 
    /// <returns>
    /// New search query.
    /// </returns>
    public FluentSearch Search()
    {
      this.\u0005();
      return new FluentSearch(new \u0005\u2004\u2000(this.\u0005), this.\u0005.\u0006());
    }

    /// <summary>
    /// Gets UIDS of all messages in the current folder (mailbox) with specified flag sorted from oldest to newest. Equivalent to Search(Expression.HasFlag(flag))
    /// 
    /// </summary>
    /// <param name="flag">Flag to search for.</param>
    /// <returns>
    /// UID list sorted from oldest to newest.
    /// </returns>
    [Obsolete("Please use Imap.Search(Flag) method instead.")]
    public List<long> SearchFlag(Flag flag)
    {
      return this.Search(flag);
    }

    /// <summary>
    /// Gets UIDS of all messages in the current folder (mailbox) with specified flag sorted from oldest to newest. Equivalent to Search(Expression.HasFlag(flag))
    /// 
    /// </summary>
    /// <param name="flag">Flag to search for.</param>
    /// <returns>
    /// UID list sorted from oldest to newest.
    /// </returns>
    public List<long> Search(Flag flag)
    {
      return (List<long>) this.Search().Where(Expression.HasFlag(flag));
    }

    /// <summary>
    /// Gets UIDS of all messages that match specified search criteria using server-side searching sorted from oldest to newest.
    ///             Use <see cref="M:Limilabs.Client.IMAP.Expression.And(Limilabs.Client.IMAP.ICriterion[])"/>, <see cref="M:Limilabs.Client.IMAP.Expression.Or(Limilabs.Client.IMAP.ICriterion,Limilabs.Client.IMAP.ICriterion)"/> and other <see cref="T:Limilabs.Client.IMAP.Expression"/> methods to create a valid search query.
    ///             You can also pass <see cref="T:Limilabs.Client.IMAP.SimpleImapQuery"/> to this method.
    /// 
    /// </summary>
    /// 
    /// <example>
    /// List&lt;long&gt; uids = imap.Search(Expression.And(Expression.Subject("report"), Expression.HasFlag(Flag.Unseen)));
    /// 
    /// </example>
    /// <param name="criterion">Search criteria. Use <see cref="M:Limilabs.Client.IMAP.Expression.And(Limilabs.Client.IMAP.ICriterion[])"/> to join several criterions.</param>
    /// <returns>
    /// UID list sorted from oldest to newest.
    /// </returns>
    public List<long> Search(ICriterion criterion)
    {
      return (List<long>) this.Search().Where(criterion);
    }

    /// <summary>
    /// Gets numbers of all messages in the current folder (mailbox) with specified flag sorted from oldest to newest.
    ///             Equivalent to Search().Where(Expression.HasFlag(flag)).ResultsAs(ResultType.Numbers)
    /// 
    /// </summary>
    /// <param name="flag">Flag to search for.</param>
    /// <returns>
    /// List of message numbers sorted from oldest to newest.
    /// </returns>
    public List<long> SearchNumbers(Flag flag)
    {
      return (List<long>) this.Search().ResultsAs(ResultType.Numbers).Where(Expression.HasFlag(flag));
    }

    /// <summary>
    /// Gets numbers of all messages that match specified criteria sorted from oldest to newest.
    ///             Use <see cref="M:Limilabs.Client.IMAP.Expression.And(Limilabs.Client.IMAP.ICriterion[])"/>, <see cref="M:Limilabs.Client.IMAP.Expression.Or(Limilabs.Client.IMAP.ICriterion,Limilabs.Client.IMAP.ICriterion)"/> and other <see cref="T:Limilabs.Client.IMAP.Expression"/> methods to create a valid search query.
    ///             You can also pass <see cref="T:Limilabs.Client.IMAP.SimpleImapQuery"/> to this method.
    /// 
    /// </summary>
    /// 
    /// <example>
    /// List&lt;long&gt; uids = imap.SearchNumber(Expression.And(Expression.Subject("report"), Expression.HasFlag(Flag.Unseen)));
    /// 
    /// </example>
    /// <param name="criterion">Search criteria. Use <see cref="M:Limilabs.Client.IMAP.Expression.And(Limilabs.Client.IMAP.ICriterion[])"/> to join several criterions</param>
    /// <returns>
    /// List of message numbers sorted from oldest to newest.
    /// </returns>
    public List<long> SearchNumbers(ICriterion criterion)
    {
      return (List<long>) this.Search().ResultsAs(ResultType.Numbers).Where(criterion);
    }

    /// <summary>
    /// Gets numbers of all messages in the current folder (mailbox) with specified flag sorted from oldest to newest.
    ///             Equivalent to Search().Where(Expression.HasFlag(flag)).ResultsAs(ResultType.Numbers)
    /// 
    /// </summary>
    /// <param name="flag">Flag to search for.</param>
    /// <returns>
    /// List of message numbers sorted from oldest to newest.
    /// </returns>
    [Obsolete("Please use Imap.SearchNumbers(Flag) method instead.")]
    public List<long> NumberSearchFlag(Flag flag)
    {
      return this.SearchNumbers(flag);
    }

    /// <summary>
    /// Gets numbers of all messages that match specified criteria sorted from oldest to newest.
    ///             Use <see cref="M:Limilabs.Client.IMAP.Expression.And(Limilabs.Client.IMAP.ICriterion[])"/>, <see cref="M:Limilabs.Client.IMAP.Expression.Or(Limilabs.Client.IMAP.ICriterion,Limilabs.Client.IMAP.ICriterion)"/> and other <see cref="T:Limilabs.Client.IMAP.Expression"/> methods to create a valid search query.
    ///             You can also pass <see cref="T:Limilabs.Client.IMAP.SimpleImapQuery"/> to this method.
    /// 
    /// </summary>
    /// 
    /// <example>
    /// List&lt;long&gt; uids = imap.SearchNumber(Expression.And(Expression.Subject("report"), Expression.HasFlag(Flag.Unseen)));
    /// 
    /// </example>
    /// <param name="criterion">Search criteria. Use <see cref="M:Limilabs.Client.IMAP.Expression.And(Limilabs.Client.IMAP.ICriterion[])"/> to join several criterions</param>
    /// <returns>
    /// List of message numbers sorted from oldest to newest.
    /// </returns>
    [Obsolete("Please use Imap.SearchNumber(ICriterion) method instead.")]
    public List<long> NumberSearch(ICriterion criterion)
    {
      return this.SearchNumbers(criterion);
    }

    /// <summary>
    /// Gets headers of the specified mail message from server. Use <see cref="T:Limilabs.Mail.MailBuilder"/> class to create <see cref="T:Limilabs.Mail.IMail"/> object. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    /// 
    /// </summary>
    /// <param name="uid">Unique-id of the message to get.</param>
    /// <returns>
    /// String containing mail message headers or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    public string PeekHeadersByUID(long uid)
    {
      this.\u0005();
      return new \u0008\u2007\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195389992), new object[1]
      {
        (object) uid
      })).\u0008();
    }

    /// <summary>
    /// Gets headers of the specified mail message from server. Use <see cref="T:Limilabs.Mail.MailBuilder"/> class to create <see cref="T:Limilabs.Mail.IMail"/> object. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// String containing mail message headers or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    public string PeekHeadersByNumber(long messageNumber)
    {
      this.\u0005();
      return new \u0008\u2007\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195390452), new object[1]
      {
        (object) messageNumber
      })).\u0008();
    }

    /// <summary>
    /// Gets headers of the specified mail message from server. Use <see cref="T:Limilabs.Mail.MailBuilder"/> class to create <see cref="T:Limilabs.Mail.IMail"/> object. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// String containing mail message headers or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    [Obsolete("Please use Imap.PeekHeadersByNumber method instead.")]
    public string PeekHeaders(long messageNumber)
    {
      return this.PeekHeadersByNumber(messageNumber);
    }

    /// <summary>
    /// Gets specified mail message from server. This method in contrast to <see cref="M:Limilabs.Client.IMAP.Imap.GetMessageByUID(System.Int64)"/> does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    ///             Use <see cref="T:Limilabs.Mail.MailBuilder"/> class to create <see cref="T:Limilabs.Mail.IMail"/> object.
    /// 
    /// </summary>
    /// <param name="uid">Unique-id of the message to get.</param>
    /// <returns>
    /// String containing mail message or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    public string PeekMessageByUID(long uid)
    {
      this.\u0005();
      return new \u0008\u2007\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195390364), new object[1]
      {
        (object) uid
      })).\u0005();
    }

    /// <summary>
    /// Gets specified mail message from server. This method in contrast to <see cref="M:Limilabs.Client.IMAP.Imap.GetMessage(System.Int64)"/> does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    ///             Use <see cref="T:Limilabs.Mail.MailBuilder"/> class to create <see cref="T:Limilabs.Mail.IMail"/> object.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// String containing mail message or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    public string PeekMessageByNumber(long messageNumber)
    {
      this.\u0005();
      return new \u0008\u2007\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195390398), new object[1]
      {
        (object) messageNumber
      })).\u0005();
    }

    /// <summary>
    /// Gets specified mail message from server. This method in contrast to <see cref="M:Limilabs.Client.IMAP.Imap.GetMessage(System.Int64)"/> does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    ///             Use <see cref="T:Limilabs.Mail.MailBuilder"/> class to create <see cref="T:Limilabs.Mail.IMail"/> object.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// String containing mail message or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    [Obsolete("Please use Imap.PeekHeadersByNumber method instead.")]
    public string PeekMessage(long messageNumber)
    {
      return this.PeekHeadersByNumber(messageNumber);
    }

    /// <summary>
    /// Gets specified mail message from server. Use <see cref="T:Limilabs.Mail.MailBuilder"/> class to create <see cref="T:Limilabs.Mail.IMail"/> object.
    ///             This method sets the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> unless folder is selected with <see cref="M:Limilabs.Client.IMAP.Imap.Examine(System.String)"/>, <see cref="M:Limilabs.Client.IMAP.Imap.Examine(Limilabs.Client.IMAP.FolderInfo)"/>  or <see cref="M:Limilabs.Client.IMAP.Imap.ExamineInbox"/>.
    /// 
    /// </summary>
    /// <param name="uid">Unique-id of the message to get.</param>
    /// <returns>
    /// String containing mail message or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    public string GetMessageByUID(long uid)
    {
      this.\u0005();
      return new \u0008\u2007\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195390276), new object[1]
      {
        (object) uid
      })).\u0005();
    }

    /// <summary>
    /// Gets specified mail message from server. Use <see cref="T:Limilabs.Mail.MailBuilder"/> class to create <see cref="T:Limilabs.Mail.IMail"/> object.
    ///             This method sets the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> unless folder is selected with <see cref="M:Limilabs.Client.IMAP.Imap.Examine(System.String)"/>, <see cref="M:Limilabs.Client.IMAP.Imap.Examine(Limilabs.Client.IMAP.FolderInfo)"/> or <see cref="M:Limilabs.Client.IMAP.Imap.ExamineInbox"/>.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// String containing mail message or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    public string GetMessageByNumber(long messageNumber)
    {
      this.\u0005();
      return new \u0008\u2007\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195390307), new object[1]
      {
        (object) messageNumber
      })).\u0005();
    }

    /// <summary>
    /// Gets specified mail message from server. Use <see cref="T:Limilabs.Mail.MailBuilder"/> class to create <see cref="T:Limilabs.Mail.IMail"/> object.
    ///             This method sets the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> unless folder is selected with <see cref="M:Limilabs.Client.IMAP.Imap.Examine(System.String)"/>, <see cref="M:Limilabs.Client.IMAP.Imap.Examine(Limilabs.Client.IMAP.FolderInfo)"/> or <see cref="M:Limilabs.Client.IMAP.Imap.ExamineInbox"/>.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// String containing mail message or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    [Obsolete("Please use Imap.GetMessageByNumber method instead.")]
    public string GetMessage(long messageNumber)
    {
      return this.GetMessageByNumber(messageNumber);
    }

    /// <summary>
    /// Gets all headers of the specified mail message from server. Use <see cref="T:Limilabs.Mail.MailBuilder"/> class to create <see cref="T:Limilabs.Mail.IMail"/> object.
    /// 
    /// </summary>
    /// <param name="uid">Unique-id of the message to get.</param>
    /// <returns>
    /// String containing mail message headers or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    public string GetHeadersByUID(long uid)
    {
      List<MessageData> headersByUid = this.GetHeadersByUID(new List<long>()
      {
        uid
      });
      if (headersByUid.Count != 0)
        return headersByUid[0].EmlData;
      else
        return (string) null;
    }

    /// <summary>
    /// Gets all headers of the specified mail message from server. Use <see cref="T:Limilabs.Mail.MailBuilder"/> class to create <see cref="T:Limilabs.Mail.IMail"/> object.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// String containing mail message headers or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    public string GetHeadersByNumber(long messageNumber)
    {
      List<MessageData> headersByNumber = this.GetHeadersByNumber(new List<long>()
      {
        messageNumber
      });
      if (headersByNumber.Count != 0)
        return headersByNumber[0].EmlData;
      else
        return (string) null;
    }

    /// <summary>
    /// Gets all headers of the specified mail message from server. Use <see cref="T:Limilabs.Mail.MailBuilder"/> class to create <see cref="T:Limilabs.Mail.IMail"/> object.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// String containing mail message headers or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    [Obsolete("Please use Imap.GetHeadersByNumber method instead.")]
    public string GetHeaders(long messageNumber)
    {
      return this.GetHeadersByNumber(messageNumber);
    }

    /// <summary>
    /// Gets all headers of the specified email messages from server. Use <see cref="T:Limilabs.Mail.MailBuilder"/> class to create <see cref="T:Limilabs.Mail.IMail"/> object.
    /// 
    /// </summary>
    /// <param name="uids">Unique-id of the messages to get information for.</param>
    /// <returns>
    /// List of message data objects containing message headers.
    /// </returns>
    public List<MessageData> GetHeadersByUID(List<long> uids)
    {
      this.\u0005();
      return new \u0008\u2007\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195390238), new object[1]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) uids).\u0003()
      })).\u0002();
    }

    /// <summary>
    /// Gets all headers of the specified email messages from server. Use <see cref="T:Limilabs.Mail.MailBuilder"/> class to create <see cref="T:Limilabs.Mail.IMail"/> object.
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param>
    /// <returns>
    /// List of message data objects containing message headers.
    /// </returns>
    public List<MessageData> GetHeadersByNumber(List<long> messageNumbers)
    {
      this.\u0005();
      return new \u0008\u2007\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195390247), new object[1]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) messageNumbers).\u0003()
      })).\u0002();
    }

    /// <summary>
    /// Gets all headers of the specified email messages from server. Use <see cref="T:Limilabs.Mail.MailBuilder"/> class to create <see cref="T:Limilabs.Mail.IMail"/> object.
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param>
    /// <returns>
    /// List of message data objects containing message headers.
    /// </returns>
    [Obsolete("Please use Imap.GetHeadersByNumber method instead.")]
    public List<MessageData> GetHeaders(List<long> messageNumbers)
    {
      return this.GetHeadersByNumber(messageNumbers);
    }

    /// <summary>
    /// Gets specific headers of the specified email message from server.
    /// 
    /// </summary>
    /// <param name="uid">Unique-id of the message to get information for.</param><param name="headers">Headers to get.</param>
    /// <returns>
    /// Message data object containing specific message headers or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    public MessageData GetSpecificHeadersByUID(long uid, string[] headers)
    {
      List<MessageData> specificHeadersByUid = this.GetSpecificHeadersByUID(new List<long>()
      {
        uid
      }, headers);
      if (specificHeadersByUid.Count != 0)
        return specificHeadersByUid[0];
      else
        return (MessageData) null;
    }

    /// <summary>
    /// Gets specific headers of the specified email message from server.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="headers">Headers to get.</param>
    /// <returns>
    /// Message data object containing message headers or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    public MessageData GetSpecificHeadersByNumber(long messageNumber, string[] headers)
    {
      List<MessageData> specificHeadersByNumber = this.GetSpecificHeadersByNumber(new List<long>()
      {
        messageNumber
      }, headers);
      if (specificHeadersByNumber.Count != 0)
        return specificHeadersByNumber[0];
      else
        return (MessageData) null;
    }

    /// <summary>
    /// Gets specific headers of the specified email message from server.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="headers">Headers to get.</param>
    /// <returns>
    /// Message data object containing message headers or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    [Obsolete("Please use Imap.GetSpecificHeadersByNumber method instead.")]
    public MessageData GetSpecificHeaders(long messageNumber, string[] headers)
    {
      return this.GetSpecificHeadersByNumber(messageNumber, headers);
    }

    /// <summary>
    /// Gets specific headers of the specified email messages from server.
    /// 
    /// </summary>
    /// <param name="uids">Unique-id of the messages to get information for.</param><param name="headers">Headers to get.</param>
    /// <returns>
    /// List of message data objects containing specific messages headers.
    /// </returns>
    public List<MessageData> GetSpecificHeadersByUID(List<long> uids, string[] headers)
    {
      this.\u0005();
      string str = string.Join(\u0006\u2001\u2004.\u0002(-195393923), headers).ToUpper();
      return new \u0008\u2007\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195384524), new object[2]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) uids).\u0003(),
        (object) str
      })).\u0003();
    }

    /// <summary>
    /// Gets specific headers of the specified email messages from server.
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param><param name="headers">Headers to get.</param>
    /// <returns>
    /// List of message data objects containing specific messages headers.
    /// </returns>
    public List<MessageData> GetSpecificHeadersByNumber(List<long> messageNumbers, string[] headers)
    {
      this.\u0005();
      string str = string.Join(\u0006\u2001\u2004.\u0002(-195393923), headers).ToUpper();
      return new \u0008\u2007\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195384480), new object[2]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) messageNumbers).\u0003(),
        (object) str
      })).\u0003();
    }

    /// <summary>
    /// Gets specific headers of the specified email messages from server.
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param><param name="headers">Headers to get.</param>
    /// <returns>
    /// List of message data objects containing specific messages headers.
    /// </returns>
    [Obsolete("Please use Imap.GetSpecificHeadersByNumber method instead.")]
    public List<MessageData> GetSpecificHeaders(List<long> messageNumbers, string[] headers)
    {
      return this.GetSpecificHeadersByNumber(messageNumbers, headers);
    }

    /// <summary>
    /// Gets specific headers of the specified email message from server. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    /// 
    /// </summary>
    /// <param name="uid">Unique-id of the message to get information for.</param><param name="headers">Headers to get.</param>
    /// <returns>
    /// Message data object containing specific message headers or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    public MessageData PeekSpecificHeadersByUID(long uid, string[] headers)
    {
      List<MessageData> list = this.PeekSpecificHeadersByUID(new List<long>()
      {
        uid
      }, headers);
      if (list.Count != 0)
        return list[0];
      else
        return (MessageData) null;
    }

    /// <summary>
    /// Gets specific headers of the specified email message from server. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="headers">Headers to get.</param>
    /// <returns>
    /// Message data object containing message headers or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    public MessageData PeekSpecificHeadersByNumber(long messageNumber, string[] headers)
    {
      List<MessageData> list = this.PeekSpecificHeadersByNumber(new List<long>()
      {
        messageNumber
      }, headers);
      if (list.Count != 0)
        return list[0];
      else
        return (MessageData) null;
    }

    /// <summary>
    /// Gets specific headers of the specified email message from server. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="headers">Headers to get.</param>
    /// <returns>
    /// Message data object containing message headers or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    [Obsolete("Please use Imap.PeekSpecificHeadersByNumber method instead.")]
    public MessageData PeekSpecificHeaders(long messageNumber, string[] headers)
    {
      return this.PeekSpecificHeadersByNumber(messageNumber, headers);
    }

    /// <summary>
    /// Gets specific headers of the specified email messages from server. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    /// 
    /// </summary>
    /// <param name="uids">Unique-id of the messages to get information for.</param><param name="headers">Headers to get.</param>
    /// <returns>
    /// List of message data objects containing specific messages headers.
    /// </returns>
    public List<MessageData> PeekSpecificHeadersByUID(List<long> uids, string[] headers)
    {
      this.\u0005();
      string str = string.Join(\u0006\u2001\u2004.\u0002(-195393923), headers).ToUpper();
      return new \u0008\u2007\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195384496), new object[2]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) uids).\u0003(),
        (object) str
      })).\u0003();
    }

    /// <summary>
    /// Gets specific headers of the specified email messages from server. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param><param name="headers">Headers to get.</param>
    /// <returns>
    /// List of message data objects containing specific messages headers.
    /// </returns>
    public List<MessageData> PeekSpecificHeadersByNumber(List<long> messageNumbers, string[] headers)
    {
      this.\u0005();
      string str = string.Join(\u0006\u2001\u2004.\u0002(-195393923), headers).ToUpper();
      return new \u0008\u2007\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195384423), new object[2]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) messageNumbers).\u0003(),
        (object) str
      })).\u0003();
    }

    /// <summary>
    /// Gets specific headers of the specified email messages from server. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param><param name="headers">Headers to get.</param>
    /// <returns>
    /// List of message data objects containing specific messages headers.
    /// </returns>
    [Obsolete("Please use Imap.PeekSpecificHeadersByNumber method instead.")]
    public List<MessageData> PeekSpecificHeaders(List<long> messageNumbers, string[] headers)
    {
      return this.PeekSpecificHeadersByNumber(messageNumbers, headers);
    }

    private string \u000F()
    {
      List<string> list = new List<string>()
      {
        \u0006\u2001\u2004.\u0002(-195388327),
        \u0006\u2001\u2004.\u0002(-195388308),
        \u0006\u2001\u2004.\u0002(-195388245)
      };
      if (this.\u0005.\u0002(ImapExtension.XGMailExtensions1))
      {
        list.Add(\u0006\u2001\u2004.\u0002(-195388289));
        list.Add(\u0006\u2001\u2004.\u0002(-195388344));
      }
      return string.Join(\u0006\u2001\u2004.\u0002(-195393923), list.ToArray());
    }

    private string \u0002\u2000()
    {
      List<string> list = new List<string>()
      {
        \u0006\u2001\u2004.\u0002(-195388327),
        \u0006\u2001\u2004.\u0002(-195388308),
        \u0006\u2001\u2004.\u0002(-195384378),
        \u0006\u2001\u2004.\u0002(-195388245),
        \u0006\u2001\u2004.\u0002(-195388115)
      };
      if (this.\u0005.\u0002(ImapExtension.XGMailExtensions1))
      {
        list.Add(\u0006\u2001\u2004.\u0002(-195388289));
        list.Add(\u0006\u2001\u2004.\u0002(-195388344));
        list.Add(\u0006\u2001\u2004.\u0002(-195390687));
      }
      return string.Join(\u0006\u2001\u2004.\u0002(-195393923), list.ToArray());
    }

    /// <summary>
    /// Gets message information for the specified message. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="uid">Unique-id of the message to get information for.</param>
    /// <returns>
    /// Message information (<see cref="P:Limilabs.Client.IMAP.MessageInfo.Envelope"/> and <see cref="P:Limilabs.Client.IMAP.MessageInfo.BodyStructure"/>) or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    public MessageInfo GetMessageInfoByUID(long uid)
    {
      List<MessageInfo> messageInfoByUid = this.GetMessageInfoByUID(new List<long>()
      {
        uid
      });
      if (messageInfoByUid.Count != 0)
        return messageInfoByUid[0];
      else
        return (MessageInfo) null;
    }

    /// <summary>
    /// Gets message information for the specified message. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// Message information (<see cref="P:Limilabs.Client.IMAP.MessageInfo.Envelope"/> and <see cref="P:Limilabs.Client.IMAP.MessageInfo.BodyStructure"/>) or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    public MessageInfo GetMessageInfoByNumber(long messageNumber)
    {
      List<MessageInfo> messageInfoByNumber = this.GetMessageInfoByNumber(new List<long>()
      {
        messageNumber
      });
      if (messageInfoByNumber.Count != 0)
        return messageInfoByNumber[0];
      else
        return (MessageInfo) null;
    }

    /// <summary>
    /// Gets message information for the specified message. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// Message information (<see cref="P:Limilabs.Client.IMAP.MessageInfo.Envelope"/> and <see cref="P:Limilabs.Client.IMAP.MessageInfo.BodyStructure"/>) or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    [Obsolete("Please use Imap.GetMessageInfoByNumber method instead.")]
    public MessageInfo GetMessageInfo(long messageNumber)
    {
      return this.GetMessageInfoByNumber(messageNumber);
    }

    /// <summary>
    /// Gets message information for the specified messages. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="uids">Unique-id of the messages to get information for.</param>
    /// <returns>
    /// Message information (<see cref="P:Limilabs.Client.IMAP.MessageInfo.Envelope"/> and <see cref="P:Limilabs.Client.IMAP.MessageInfo.BodyStructure"/>)
    /// </returns>
    public List<MessageInfo> GetMessageInfoByUID(List<long> uids)
    {
      this.\u0005();
      if (uids.Count == 0)
        return new List<MessageInfo>();
      return new \u0005\u2007\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195384358), new object[2]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) uids).\u0003(),
        (object) this.\u0002\u2000()
      })).\u0002(uids);
    }

    /// <summary>
    /// Gets message information for the specified messages. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param>
    /// <returns>
    /// Message information (<see cref="P:Limilabs.Client.IMAP.MessageInfo.Envelope"/> and <see cref="P:Limilabs.Client.IMAP.MessageInfo.BodyStructure"/>)
    /// </returns>
    public List<MessageInfo> GetMessageInfoByNumber(List<long> messageNumbers)
    {
      this.\u0005();
      if (messageNumbers.Count == 0)
        return new List<MessageInfo>();
      return new \u0005\u2007\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195384776), new object[2]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) messageNumbers).\u0003(),
        (object) this.\u0002\u2000()
      })).\u0003(messageNumbers);
    }

    /// <summary>
    /// Gets message information for the specified messages. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param>
    /// <returns>
    /// Message information (<see cref="P:Limilabs.Client.IMAP.MessageInfo.Envelope"/> and <see cref="P:Limilabs.Client.IMAP.MessageInfo.BodyStructure"/>)
    /// </returns>
    [Obsolete("Please use Imap.GetMessageInfoByNumber method instead.")]
    public List<MessageInfo> GetMessageInfo(List<long> messageNumbers)
    {
      return this.GetMessageInfoByNumber(messageNumbers);
    }

    /// <summary>
    /// Gets the envelope (<see cref="P:Limilabs.Client.IMAP.Envelope.Subject"/>, <see cref="P:Limilabs.Client.IMAP.Envelope.From"/>, <see cref="P:Limilabs.Client.IMAP.Envelope.To"/>...)
    ///             of the specified message. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="uid">Unique-id of the message to get envelope for.</param>
    /// <returns>
    /// Envelope information for specified message or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    public Envelope GetEnvelopeByUID(long uid)
    {
      List<Envelope> envelopeByUid = this.GetEnvelopeByUID(new List<long>()
      {
        uid
      });
      if (envelopeByUid.Count != 0)
        return envelopeByUid[0];
      else
        return (Envelope) null;
    }

    /// <summary>
    /// Gets the envelope (<see cref="P:Limilabs.Client.IMAP.Envelope.Subject"/>, <see cref="P:Limilabs.Client.IMAP.Envelope.From"/>, <see cref="P:Limilabs.Client.IMAP.Envelope.To"/>...)
    ///             of the specified message. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// Envelope information for specified message or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    public Envelope GetEnvelopeByNumber(long messageNumber)
    {
      List<Envelope> envelopeByNumber = this.GetEnvelopeByNumber(new List<long>()
      {
        messageNumber
      });
      if (envelopeByNumber.Count != 0)
        return envelopeByNumber[0];
      else
        return (Envelope) null;
    }

    /// <summary>
    /// Gets the envelope (<see cref="P:Limilabs.Client.IMAP.Envelope.Subject"/>, <see cref="P:Limilabs.Client.IMAP.Envelope.From"/>, <see cref="P:Limilabs.Client.IMAP.Envelope.To"/>...)
    ///             of the specified message. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// Envelope information for specified message or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    [Obsolete("Please use Imap.GetEnvelopeByNumber method instead.")]
    public Envelope GetEnvelope(long messageNumber)
    {
      return this.GetEnvelopeByNumber(messageNumber);
    }

    /// <summary>
    /// Gets the envelope (<see cref="P:Limilabs.Client.IMAP.Envelope.Subject"/>, <see cref="P:Limilabs.Client.IMAP.Envelope.From"/>, <see cref="P:Limilabs.Client.IMAP.Envelope.To"/>...)
    ///             of the specified messages. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="uids">Unique-id of the messages to get envelope for.</param>
    /// <returns>
    /// Envelope information for specified messages.
    /// </returns>
    public List<Envelope> GetEnvelopeByUID(List<long> uids)
    {
      this.\u0005();
      if (uids.Count == 0)
        return new List<Envelope>();
      return new \u000E\u2005\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195384358), new object[2]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) uids).\u0003(),
        (object) this.\u000F()
      })).\u0002();
    }

    /// <summary>
    /// Gets the envelope (<see cref="P:Limilabs.Client.IMAP.Envelope.Subject"/>, <see cref="P:Limilabs.Client.IMAP.Envelope.From"/>, <see cref="P:Limilabs.Client.IMAP.Envelope.To"/>...)
    ///             of the specified messages. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param>
    /// <returns>
    /// Envelope information for specified messages.
    /// </returns>
    public List<Envelope> GetEnvelopeByNumber(List<long> messageNumbers)
    {
      this.\u0005();
      if (messageNumbers.Count == 0)
        return new List<Envelope>();
      return new \u000E\u2005\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195384776), new object[2]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) messageNumbers).\u0003(),
        (object) this.\u000F()
      })).\u0002();
    }

    /// <summary>
    /// Gets the envelope (<see cref="P:Limilabs.Client.IMAP.Envelope.Subject"/>, <see cref="P:Limilabs.Client.IMAP.Envelope.From"/>, <see cref="P:Limilabs.Client.IMAP.Envelope.To"/>...)
    ///             of the specified messages. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param>
    /// <returns>
    /// Envelope information for specified messages.
    /// </returns>
    [Obsolete("Please use Imap.GetEnvelopeByNumber method instead.")]
    public List<Envelope> GetEnvelope(List<long> messageNumbers)
    {
      return this.GetEnvelopeByNumber(messageNumbers);
    }

    /// <summary>
    /// Gets the structure of the specified message.
    /// 
    /// </summary>
    /// <param name="uid">Unique-id of the message to get.</param>
    /// <returns>
    /// Structure of the specified message or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    public BodyStructure GetBodyStructureByUID(long uid)
    {
      List<BodyStructure> bodyStructureByUid = this.GetBodyStructureByUID(new List<long>()
      {
        uid
      });
      if (bodyStructureByUid.Count != 0)
        return bodyStructureByUid[0];
      else
        return (BodyStructure) null;
    }

    /// <summary>
    /// Gets the structure of the specified message. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// Structure of the specified message or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    public BodyStructure GetBodyStructureByNumber(long messageNumber)
    {
      List<BodyStructure> structureByNumber = this.GetBodyStructureByNumber(new List<long>()
      {
        messageNumber
      });
      if (structureByNumber.Count != 0)
        return structureByNumber[0];
      else
        return (BodyStructure) null;
    }

    /// <summary>
    /// Gets the structure of the specified message. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// Structure of the specified message or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    [Obsolete("Please use Imap.GetBodyStructureByNumber method instead.")]
    public BodyStructure GetBodyStructure(long messageNumber)
    {
      return this.GetBodyStructureByNumber(messageNumber);
    }

    /// <summary>
    /// Gets the structure of the specified message. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="uids">Unique-ids of the messages to get.</param>
    /// <returns>
    /// Structure of the specified messages.
    /// </returns>
    public List<BodyStructure> GetBodyStructureByUID(List<long> uids)
    {
      this.\u0005();
      if (uids.Count == 0)
        return new List<BodyStructure>();
      return new \u0003\u2005\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195384830), new object[1]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) uids).\u0003()
      })).\u0002();
    }

    /// <summary>
    /// Gets the structure of the specified message. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param>
    /// <returns>
    /// Structure of the specified messages.
    /// </returns>
    public List<BodyStructure> GetBodyStructureByNumber(List<long> messageNumbers)
    {
      this.\u0005();
      if (messageNumbers.Count == 0)
        return new List<BodyStructure>();
      return new \u0003\u2005\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195384710), new object[1]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) messageNumbers).\u0003()
      })).\u0002();
    }

    /// <summary>
    /// Gets the structure of the specified message. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param>
    /// <returns>
    /// Structure of the specified messages.
    /// </returns>
    [Obsolete("Please use Imap.GetBodyStructureByNumber method instead.")]
    public List<BodyStructure> GetBodyStructure(List<long> messageNumbers)
    {
      return this.GetBodyStructureByNumber(messageNumbers);
    }

    /// <summary>
    /// Gets the data for specified part.
    /// 
    /// </summary>
    /// <param name="uid">Unique-id of the message to get.</param><param name="part">Mime part to get.</param>
    /// <returns>
    /// Part's data or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    public byte[] GetMimePartByUID(long uid, MimeStructure part)
    {
      \u0002\u2005\u2001.\u0002((object) part, \u0006\u2001\u2004.\u0002(-195384746));
      this.\u0005();
      return new \u0008\u2007\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195384663), new object[2]
      {
        (object) uid,
        (object) part.ID
      })).\u0002(part);
    }

    /// <summary>
    /// Gets the data for specified part.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="part">Mime part to get.</param>
    /// <returns>
    /// Part's data or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    public byte[] GetMimePartByNumber(long messageNumber, MimeStructure part)
    {
      \u0002\u2005\u2001.\u0002((object) part, \u0006\u2001\u2004.\u0002(-195384746));
      this.\u0005();
      return new \u0008\u2007\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195384699), new object[2]
      {
        (object) messageNumber,
        (object) part.ID
      })).\u0002(part);
    }

    /// <summary>
    /// Gets the data for specified part.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="part">Mime part to get.</param>
    /// <returns>
    /// Part's data or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    [Obsolete("Please use Imap.GetMimePartByNumber method instead.")]
    public byte[] GetMimePart(long messageNumber, MimeStructure part)
    {
      return this.GetMimePartByNumber(messageNumber, part);
    }

    /// <summary>
    /// Gets the text data for specified part.
    /// 
    /// </summary>
    /// <param name="uid">Unique-id of the message to get.</param><param name="part">Mime part to get.</param>
    /// <returns>
    /// Text body of the part or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    public string GetMimePartTextByUID(long uid, MimeStructure part)
    {
      byte[] mimePartByUid = this.GetMimePartByUID(uid, part);
      if (mimePartByUid != null)
        return part.Encoding.GetString(mimePartByUid);
      else
        return (string) null;
    }

    /// <summary>
    /// Gets the text data for specified part.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="part">Mime part to get.</param>
    /// <returns>
    /// Text body of the part or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    public string GetMimePartTextByNumber(long messageNumber, MimeStructure part)
    {
      byte[] mimePartByNumber = this.GetMimePartByNumber(messageNumber, part);
      if (mimePartByNumber != null)
        return part.Encoding.GetString(mimePartByNumber);
      else
        return (string) null;
    }

    /// <summary>
    /// Gets the text data for specified part.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="part">Mime part to get.</param>
    /// <returns>
    /// Text body of the part or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    [Obsolete("Please use Imap.GetMimePartTextByNumber method instead.")]
    public string GetMimePartText(long messageNumber, MimeStructure part)
    {
      return this.GetMimePartTextByNumber(messageNumber, part);
    }

    /// <summary>
    /// Peeks the data for specified part. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="uid">Unique-id of the message to get.</param><param name="part">Mime part to get.</param>
    /// <returns>
    /// Part's data or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    public byte[] PeekMimePartByUID(long uid, MimeStructure part)
    {
      \u0002\u2005\u2001.\u0002((object) part, \u0006\u2001\u2004.\u0002(-195384746));
      this.\u0005();
      return new \u0008\u2007\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195384603), new object[2]
      {
        (object) uid,
        (object) part.ID
      })).\u0002(part);
    }

    /// <summary>
    /// Peeks the data for specified part. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="part">Mime part to get.</param>
    /// <returns>
    /// Part's data or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    public byte[] PeekMimePartByNumber(long messageNumber, MimeStructure part)
    {
      \u0002\u2005\u2001.\u0002((object) part, \u0006\u2001\u2004.\u0002(-195384746));
      this.\u0005();
      return new \u0008\u2007\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195384610), new object[2]
      {
        (object) messageNumber,
        (object) part.ID
      })).\u0002(part);
    }

    /// <summary>
    /// Peeks the data for specified part. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="part">Mime part to get.</param>
    /// <returns>
    /// Part's data or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    [Obsolete("Please use Imap.PeekMimePartByNumber method instead.")]
    public byte[] PeekMimePart(long messageNumber, MimeStructure part)
    {
      return this.PeekMimePartByNumber(messageNumber, part);
    }

    /// <summary>
    /// Peeks the text data for specified part. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="uid">Unique-id of the message to get.</param><param name="part">Mime part to get.</param>
    /// <returns>
    /// Text body of the part or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    public string PeekMimePartTextByUID(long uid, MimeStructure part)
    {
      byte[] bytes = this.PeekMimePartByUID(uid, part);
      if (bytes != null)
        return part.Encoding.GetString(bytes);
      else
        return (string) null;
    }

    /// <summary>
    /// Peeks the text data for specified part. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="part">Mime part to get.</param>
    /// <returns>
    /// Text body of the part or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    public string PeekMimePartTextByNumber(long messageNumber, MimeStructure part)
    {
      byte[] bytes = this.PeekMimePartByNumber(messageNumber, part);
      if (bytes != null)
        return part.Encoding.GetString(bytes);
      else
        return (string) null;
    }

    /// <summary>
    /// Peeks the text data for specified part. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="part">Mime part to get.</param>
    /// <returns>
    /// Text body of the part or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    [Obsolete("Please use Imap.PeekMimePartTextByNumber method instead.")]
    public string PeekMimePartText(long messageNumber, MimeStructure part)
    {
      return this.PeekMimePartTextByNumber(messageNumber, part);
    }

    /// <summary>
    /// Gets flags for the specified email message from server. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.FlagMessageByUID(System.Int64,Limilabs.Client.IMAP.Flag)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.UnflagMessageByUID(System.Int64,Limilabs.Client.IMAP.Flag)"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageSeenByUID(System.Int64)"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageUnseenByUID(System.Int64)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.FlagMessageByUID(System.Collections.Generic.List{System.Int64},Limilabs.Client.IMAP.Flag)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.UnflagMessageByUID(System.Collections.Generic.List{System.Int64},Limilabs.Client.IMAP.Flag)"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageSeenByUID(System.Collections.Generic.List{System.Int64})"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageUnseenByUID(System.Collections.Generic.List{System.Int64})"/><param name="uid">Unique-id of the message to get flags for.</param>
    /// <returns>
    /// List containing flags of the specified message or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    public List<Flag> GetFlagsByUID(long uid)
    {
      List<MessageFlags> flagsByUid = this.GetFlagsByUID(new List<long>()
      {
        uid
      });
      if (flagsByUid.Count != 0)
        return flagsByUid[0].Flags;
      else
        return (List<Flag>) null;
    }

    /// <summary>
    /// Gets flags for the specified email message from server. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.FlagMessage(System.Int64,Limilabs.Client.IMAP.Flag)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.UnflagMessage(System.Int64,Limilabs.Client.IMAP.Flag)"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageSeen(System.Int64)"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageUnseen(System.Int64)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.FlagMessage(System.Collections.Generic.List{System.Int64},Limilabs.Client.IMAP.Flag)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.UnflagMessage(System.Collections.Generic.List{System.Int64},Limilabs.Client.IMAP.Flag)"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageSeen(System.Collections.Generic.List{System.Int64})"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageUnseen(System.Collections.Generic.List{System.Int64})"/><param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// List containing flags of the specified message or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    public List<Flag> GetFlagsByNumber(long messageNumber)
    {
      List<MessageFlags> flagsByNumber = this.GetFlagsByNumber(new List<long>()
      {
        messageNumber
      });
      if (flagsByNumber.Count != 0)
        return flagsByNumber[0].Flags;
      else
        return (List<Flag>) null;
    }

    /// <summary>
    /// Gets flags for the specified email message from server. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.FlagMessage(System.Int64,Limilabs.Client.IMAP.Flag)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.UnflagMessage(System.Int64,Limilabs.Client.IMAP.Flag)"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageSeen(System.Int64)"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageUnseen(System.Int64)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.FlagMessage(System.Collections.Generic.List{System.Int64},Limilabs.Client.IMAP.Flag)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.UnflagMessage(System.Collections.Generic.List{System.Int64},Limilabs.Client.IMAP.Flag)"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageSeen(System.Collections.Generic.List{System.Int64})"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageUnseen(System.Collections.Generic.List{System.Int64})"/><param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// List containing flags of the specified message or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    [Obsolete("Please use Imap.GetFlagsByNumber method instead.")]
    public List<Flag> GetFlags(long messageNumber)
    {
      return this.GetFlagsByNumber(messageNumber);
    }

    /// <summary>
    /// Gets flags for the specified email messages from server. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.FlagMessageByUID(System.Int64,Limilabs.Client.IMAP.Flag)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.UnflagMessageByUID(System.Int64,Limilabs.Client.IMAP.Flag)"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageSeenByUID(System.Int64)"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageUnseenByUID(System.Int64)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.FlagMessageByUID(System.Collections.Generic.List{System.Int64},Limilabs.Client.IMAP.Flag)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.UnflagMessageByUID(System.Collections.Generic.List{System.Int64},Limilabs.Client.IMAP.Flag)"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageSeenByUID(System.Collections.Generic.List{System.Int64})"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageUnseenByUID(System.Collections.Generic.List{System.Int64})"/><param name="uids">Unique-ids of the messages to get flags for.</param>
    /// <returns>
    /// List containing flags of the specified messages.
    /// </returns>
    public List<MessageFlags> GetFlagsByUID(List<long> uids)
    {
      this.\u0005();
      if (uids.Count == 0)
        return new List<MessageFlags>();
      return new \u000F\u2005\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195385029), new object[1]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) uids).\u0003()
      })).\u0002();
    }

    /// <summary>
    /// Gets flags for the specified email messages from server. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.FlagMessage(System.Int64,Limilabs.Client.IMAP.Flag)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.UnflagMessage(System.Int64,Limilabs.Client.IMAP.Flag)"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageSeen(System.Int64)"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageUnseen(System.Int64)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.FlagMessage(System.Collections.Generic.List{System.Int64},Limilabs.Client.IMAP.Flag)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.UnflagMessage(System.Collections.Generic.List{System.Int64},Limilabs.Client.IMAP.Flag)"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageSeen(System.Collections.Generic.List{System.Int64})"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageUnseen(System.Collections.Generic.List{System.Int64})"/><param name="messageNumbers">1 based message numbers.</param>
    /// <returns>
    /// List containing flags of the specified messages.
    /// </returns>
    public List<MessageFlags> GetFlagsByNumber(List<long> messageNumbers)
    {
      this.\u0005();
      if (messageNumbers.Count == 0)
        return new List<MessageFlags>();
      return new \u000F\u2005\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195385061), new object[1]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) messageNumbers).\u0003()
      })).\u0002();
    }

    /// <summary>
    /// Gets flags for the specified email messages from server. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.FlagMessage(System.Int64,Limilabs.Client.IMAP.Flag)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.UnflagMessage(System.Int64,Limilabs.Client.IMAP.Flag)"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageSeen(System.Int64)"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageUnseen(System.Int64)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.FlagMessage(System.Collections.Generic.List{System.Int64},Limilabs.Client.IMAP.Flag)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.UnflagMessage(System.Collections.Generic.List{System.Int64},Limilabs.Client.IMAP.Flag)"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageSeen(System.Collections.Generic.List{System.Int64})"/><see cref="M:Limilabs.Client.IMAP.Imap.MarkMessageUnseen(System.Collections.Generic.List{System.Int64})"/><param name="messageNumbers">1 based message numbers.</param>
    /// <returns>
    /// List containing flags of the specified messages.
    /// </returns>
    [Obsolete("Please use Imap.GetFlagsByNumber method instead.")]
    public List<MessageFlags> GetFlags(List<long> messageNumbers)
    {
      return this.GetFlagsByNumber(messageNumbers);
    }

    /// <summary>
    /// Flags the message with specified flag.
    /// 
    /// </summary>
    /// <param name="uid">Unique-id of the message to flag.</param><param name="flag">Flag to be added. For specifying system flags you can use static fields e.g. <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.</param>
    /// <returns>
    /// List containing flags of the specified message after the change or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    /// 
    /// <remarks>
    /// You can use <see cref="P:Limilabs.Client.IMAP.FolderStatus.SupportsCustomFlags"/> to check, if selected folder supports custom flags.
    ///             Exchange 2007 and 2010 do not support custom flags (keywords).
    /// 
    /// </remarks>
    public List<Flag> FlagMessageByUID(long uid, Flag flag)
    {
      List<MessageFlags> list = this.FlagMessageByUID(new List<long>()
      {
        uid
      }, flag);
      if (list.Count != 0)
        return list[0].Flags;
      else
        return (List<Flag>) null;
    }

    /// <summary>
    /// Flags the message with specified flag.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="flag">Flag to be added. For specifying system flags you can use static fields e.g. <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.</param>
    /// <returns>
    /// List containing flags of the specified message after the change or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    /// 
    /// <remarks>
    /// You can use <see cref="P:Limilabs.Client.IMAP.FolderStatus.SupportsCustomFlags"/> to check, if selected folder supports custom flags.
    ///             Exchange 2007 and 2010 do not support custom flags (keywords).
    /// 
    /// </remarks>
    public List<Flag> FlagMessageByNumber(long messageNumber, Flag flag)
    {
      List<MessageFlags> list = this.FlagMessageByNumber(new List<long>()
      {
        messageNumber
      }, flag);
      if (list.Count != 0)
        return list[0].Flags;
      else
        return (List<Flag>) null;
    }

    /// <summary>
    /// Flags the message with specified flag.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="flag">Flag to be added. For specifying system flags you can use static fields e.g. <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.</param>
    /// <returns>
    /// List containing flags of the specified message after the change or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    /// 
    /// <remarks>
    /// You can use <see cref="P:Limilabs.Client.IMAP.FolderStatus.SupportsCustomFlags"/> to check, if selected folder supports custom flags.
    ///             Exchange 2007 and 2010 do not support custom flags (keywords).
    /// 
    /// </remarks>
    [Obsolete("Please use Imap.FlagMessageByNumber method instead.")]
    public List<Flag> FlagMessage(long messageNumber, Flag flag)
    {
      return this.FlagMessageByNumber(messageNumber, flag);
    }

    /// <summary>
    /// Flags the messages with specified flag.
    /// 
    /// </summary>
    /// <param name="uids">Unique-id of the messages to flag.</param><param name="flag">Flag to be added. For specifying system flags you can use static fields e.g. <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.</param>
    /// <returns>
    /// List containing flags of the specified messages after the change.
    /// </returns>
    /// 
    /// <remarks>
    /// You can use <see cref="P:Limilabs.Client.IMAP.FolderStatus.SupportsCustomFlags"/> to check, if selected folder supports custom flags.
    ///             Exchange 2007 and 2010 do not support custom flags (keywords).
    /// 
    /// </remarks>
    public List<MessageFlags> FlagMessageByUID(List<long> uids, Flag flag)
    {
      this.\u0005();
      this.\u0002(flag);
      if (uids.Count == 0)
        return new List<MessageFlags>();
      return new \u000F\u2005\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195384961), new object[2]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) uids).\u0003(),
        (object) flag.FullName
      })).\u0002();
    }

    /// <summary>
    /// Flags the messages with specified flag.
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param><param name="flag">Flag to be added. For specifying system flags you can use static fields e.g. <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.</param>
    /// <returns>
    /// List containing flags of the specified messages after the change.
    /// </returns>
    /// 
    /// <remarks>
    /// You can use <see cref="P:Limilabs.Client.IMAP.FolderStatus.SupportsCustomFlags"/> to check, if selected folder supports custom flags.
    ///             Exchange 2007 and 2010 do not support custom flags (keywords).
    /// 
    /// </remarks>
    public List<MessageFlags> FlagMessageByNumber(List<long> messageNumbers, Flag flag)
    {
      this.\u0005();
      this.\u0002(flag);
      if (messageNumbers.Count == 0)
        return new List<MessageFlags>();
      return new \u000F\u2005\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195385000), new object[2]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) messageNumbers).\u0003(),
        (object) flag.FullName
      })).\u0002();
    }

    /// <summary>
    /// Flags the messages with specified flag.
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param><param name="flag">Flag to be added. For specifying system flags you can use static fields e.g. <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.</param>
    /// <returns>
    /// List containing flags of the specified messages after the change.
    /// </returns>
    /// 
    /// <remarks>
    /// You can use <see cref="P:Limilabs.Client.IMAP.FolderStatus.SupportsCustomFlags"/> to check, if selected folder supports custom flags.
    ///             Exchange 2007 and 2010 do not support custom flags (keywords).
    /// 
    /// </remarks>
    [Obsolete("Please use Imap.FlagMessageByNumber method instead.")]
    public List<MessageFlags> FlagMessage(List<long> messageNumbers, Flag flag)
    {
      return this.FlagMessageByNumber(messageNumbers, flag);
    }

    /// <summary>
    /// Removes specified flag from the message.
    /// 
    /// </summary>
    /// <param name="uid">Unique-id of the message to remove flag from.</param><param name="flag">Flag to be removed. For specifying system flags you can use static fields e.g. <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.</param>
    /// <returns>
    /// List containing flags of the specified message after the change or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    public List<Flag> UnflagMessageByUID(long uid, Flag flag)
    {
      List<MessageFlags> list = this.UnflagMessageByUID(new List<long>()
      {
        uid
      }, flag);
      if (list.Count != 0)
        return list[0].Flags;
      else
        return (List<Flag>) null;
    }

    /// <summary>
    /// Removes specified flag from the message.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="flag">Flag to be removed. For specifying system flags you can use static fields e.g. <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.</param>
    /// <returns>
    /// List containing flags of the specified message after the change or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    public List<Flag> UnflagMessageByNumber(long messageNumber, Flag flag)
    {
      List<MessageFlags> list = this.UnflagMessageByNumber(new List<long>()
      {
        messageNumber
      }, flag);
      if (list.Count != 0)
        return list[0].Flags;
      else
        return (List<Flag>) null;
    }

    /// <summary>
    /// Removes specified flag from the message.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="flag">Flag to be removed. For specifying system flags you can use static fields e.g. <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.</param>
    /// <returns>
    /// List containing flags of the specified message after the change or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    [Obsolete("Please use Imap.UnflagMessageByNumber method instead.")]
    public List<Flag> UnflagMessage(long messageNumber, Flag flag)
    {
      return this.UnflagMessageByNumber(messageNumber, flag);
    }

    /// <summary>
    /// Removes specified flag from messages.
    /// 
    /// </summary>
    /// <param name="uids">Unique-id of the message to remove flag from.</param><param name="flag">Flag to be removed. For specifying system flags you can use static fields e.g. <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.</param>
    /// <returns>
    /// List containing flags of the specified messages after the change.
    /// </returns>
    public List<MessageFlags> UnflagMessageByUID(List<long> uids, Flag flag)
    {
      this.\u0005();
      this.\u0002(flag);
      if (uids.Count == 0)
        return new List<MessageFlags>();
      return new \u000F\u2005\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195384899), new object[2]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) uids).\u0003(),
        (object) flag.FullName
      })).\u0002();
    }

    /// <summary>
    /// Removes specified flag from messages.
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message number.</param><param name="flag">Flag to be removed. For specifying system flags you can use static fields e.g. <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.</param>
    /// <returns>
    /// List containing flags of the specified messages after the change.
    /// </returns>
    public List<MessageFlags> UnflagMessageByNumber(List<long> messageNumbers, Flag flag)
    {
      this.\u0005();
      this.\u0002(flag);
      if (messageNumbers.Count == 0)
        return new List<MessageFlags>();
      return new \u000F\u2005\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195384930), new object[2]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) messageNumbers).\u0003(),
        (object) flag.FullName
      })).\u0002();
    }

    /// <summary>
    /// Removes specified flag from messages.
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message number.</param><param name="flag">Flag to be removed. For specifying system flags you can use static fields e.g. <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.</param>
    /// <returns>
    /// List containing flags of the specified messages after the change.
    /// </returns>
    [Obsolete("Please use Imap.UnflagMessageByNumber method instead.")]
    public List<MessageFlags> UnflagMessage(List<long> messageNumbers, Flag flag)
    {
      return this.UnflagMessageByNumber(messageNumbers, flag);
    }

    /// <summary>
    /// Flags message with <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.MarkMessageUnseenByUID(System.Int64)"/><param name="uid">Unique-id of the message.</param>
    /// <returns>
    /// List containing flags of the specified message after the change or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    public List<Flag> MarkMessageSeenByUID(long uid)
    {
      return this.FlagMessageByUID(uid, Flag.Seen);
    }

    /// <summary>
    /// Flags message with <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.MarkMessageUnseen(System.Int64)"/><param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// List containing flags of the specified message after the change or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    public List<Flag> MarkMessageSeenByNumber(long messageNumber)
    {
      return this.FlagMessageByNumber(messageNumber, Flag.Seen);
    }

    /// <summary>
    /// Flags message with <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.MarkMessageUnseen(System.Int64)"/><param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// List containing flags of the specified message after the change or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    [Obsolete("Please use Imap.MarkMessageSeenByNumber method instead.")]
    public List<Flag> MarkMessageSeen(long messageNumber)
    {
      return this.MarkMessageSeenByNumber(messageNumber);
    }

    /// <summary>
    /// Flags message with <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.MarkMessageUnseenByUID(System.Collections.Generic.List{System.Int64})"/><param name="uids">Unique-ids of the messages.</param>
    /// <returns>
    /// List containing flags of the specified messages after the change.
    /// </returns>
    public List<MessageFlags> MarkMessageSeenByUID(List<long> uids)
    {
      return this.FlagMessageByUID(uids, Flag.Seen);
    }

    /// <summary>
    /// Flags message with <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.MarkMessageUnseen(System.Collections.Generic.List{System.Int64})"/><param name="messageNumbers">1 based message numbers.</param>
    /// <returns>
    /// List containing flags of the specified messages after the change.
    /// </returns>
    public List<MessageFlags> MarkMessageSeenByNumber(List<long> messageNumbers)
    {
      return this.FlagMessageByNumber(messageNumbers, Flag.Seen);
    }

    /// <summary>
    /// Flags message with <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.MarkMessageUnseen(System.Collections.Generic.List{System.Int64})"/><param name="messageNumbers">1 based message numbers.</param>
    /// <returns>
    /// List containing flags of the specified messages after the change.
    /// </returns>
    [Obsolete("Please use Imap.MarkMessageSeenByNumber method instead.")]
    public List<MessageFlags> MarkMessageSeen(List<long> messageNumbers)
    {
      return this.MarkMessageSeenByNumber(messageNumbers);
    }

    /// <summary>
    /// Removes <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag from the message.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.MarkMessageSeenByUID(System.Int64)"/><param name="uid">Unique-id of the message.</param>
    /// <returns>
    /// List containing flags of the specified message after the change or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    public List<Flag> MarkMessageUnseenByUID(long uid)
    {
      return this.UnflagMessageByUID(uid, Flag.Seen);
    }

    /// <summary>
    /// Removes <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag from the message.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.MarkMessageSeen(System.Int64)"/><param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// List containing flags of the specified message after the change or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    public List<Flag> MarkMessageUnseenByNumber(long messageNumber)
    {
      return this.UnflagMessageByNumber(messageNumber, Flag.Seen);
    }

    /// <summary>
    /// Removes <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag from the message.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.MarkMessageSeen(System.Int64)"/><param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// List containing flags of the specified message after the change or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    [Obsolete("Please use Imap.MarkMessageUnseenByNumber method instead.")]
    public List<Flag> MarkMessageUnseen(long messageNumber)
    {
      return this.MarkMessageUnseenByNumber(messageNumber);
    }

    /// <summary>
    /// Removes <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag from the message.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.MarkMessageSeenByUID(System.Collections.Generic.List{System.Int64})"/><param name="uids">Unique-ids of the messages.</param>
    /// <returns>
    /// List containing flags of the specified messages after the change.
    /// </returns>
    public List<MessageFlags> MarkMessageUnseenByUID(List<long> uids)
    {
      return this.UnflagMessageByUID(uids, Flag.Seen);
    }

    /// <summary>
    /// Removes <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag from the message.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.MarkMessageSeen(System.Collections.Generic.List{System.Int64})"/><param name="messageNumbers">1 based message numbers.</param>
    /// <returns>
    /// List containing flags of the specified messages after the change.
    /// </returns>
    public List<MessageFlags> MarkMessageUnseenByNumber(List<long> messageNumbers)
    {
      return this.UnflagMessageByNumber(messageNumbers, Flag.Seen);
    }

    /// <summary>
    /// Removes <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> flag from the message.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.MarkMessageSeen(System.Collections.Generic.List{System.Int64})"/><param name="messageNumbers">1 based message numbers.</param>
    /// <returns>
    /// List containing flags of the specified messages after the change.
    /// </returns>
    [Obsolete("Please use Imap.MarkMessageUnseenByNumber method instead.")]
    public List<MessageFlags> MarkMessageUnseen(List<long> messageNumbers)
    {
      return this.MarkMessageUnseenByNumber(messageNumbers);
    }

    /// <summary>
    /// Gets Gmail labels for the specified email message from server. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    ///             You can label message using <seealso cref="M:Limilabs.Client.IMAP.Imap.GmailLabelMessageByUID(System.Int64,System.String)"/> method.
    /// 
    /// </summary>
    /// <param name="uid">Unique-id of the message to get Gmail labels for.</param>
    /// <returns>
    /// List containing Gmail labels of the specified message or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    public List<string> GmailGetLabelsByUID(long uid)
    {
      List<GmailMessageLabels> labelsByUid = this.GmailGetLabelsByUID(new List<long>()
      {
        uid
      });
      if (labelsByUid.Count != 0)
        return labelsByUid[0].Labels;
      else
        return (List<string>) null;
    }

    /// <summary>
    /// Gets Gmail labels for the specified email message from server. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.GmailLabelMessage(System.Int64,System.String)"/><param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// List containing Gmail labels of the specified message or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    public List<string> GmailGetLabelsByNumber(long messageNumber)
    {
      List<GmailMessageLabels> labelsByNumber = this.GmailGetLabelsByNumber(new List<long>()
      {
        messageNumber
      });
      if (labelsByNumber.Count != 0)
        return labelsByNumber[0].Labels;
      else
        return (List<string>) null;
    }

    /// <summary>
    /// Gets Gmail labels for the specified email message from server. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.GmailLabelMessage(System.Int64,System.String)"/><param name="messageNumber">1 based message number.</param>
    /// <returns>
    /// List containing Gmail labels of the specified message or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    [Obsolete("Please use Imap.GmailGetLabelsByNumber method instead.")]
    public List<string> GmailGetLabels(long messageNumber)
    {
      return this.GmailGetLabelsByNumber(messageNumber);
    }

    /// <summary>
    /// Gets Gmail labels for the specified email messages from server. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.GmailLabelMessageByUID(System.Collections.Generic.List{System.Int64},System.String)"/><param name="uids">Unique-ids of the messages to get Gmail labels for.</param>
    /// <returns>
    /// List containing Gmail labels of the specified messages.
    /// </returns>
    public List<GmailMessageLabels> GmailGetLabelsByUID(List<long> uids)
    {
      this.\u0005();
      if (uids.Count == 0)
        return new List<GmailMessageLabels>();
      return new \u0005\u2006\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195384861), new object[1]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) uids).\u0003()
      })).\u0002();
    }

    /// <summary>
    /// Gets Gmail labels for the specified email messages from server. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.GmailLabelMessage(System.Collections.Generic.List{System.Int64},System.String)"/><param name="messageNumbers">1 based message numbers.</param>
    /// <returns>
    /// List containing Gmail labels of the specified messages.
    /// </returns>
    public List<GmailMessageLabels> GmailGetLabelsByNumber(List<long> messageNumbers)
    {
      this.\u0005();
      if (messageNumbers.Count == 0)
        return new List<GmailMessageLabels>();
      return new \u0005\u2006\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195384871), new object[1]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) messageNumbers).\u0003()
      })).\u0002();
    }

    /// <summary>
    /// Gets Gmail labels for the specified email messages from server. Does not set the <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/>.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.GmailLabelMessage(System.Collections.Generic.List{System.Int64},System.String)"/><param name="messageNumbers">1 based message numbers.</param>
    /// <returns>
    /// List containing Gmail labels of the specified messages.
    /// </returns>
    [Obsolete("Please use Imap.GmailGetLabelsByNumber method instead.")]
    public List<GmailMessageLabels> GmailGetLabels(List<long> messageNumbers)
    {
      return this.GmailGetLabelsByNumber(messageNumbers);
    }

    /// <summary>
    /// Labels the messages with specified label.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.GmailUnlabelMessageByUID(System.Collections.Generic.List{System.Int64},System.String)"/><param name="uids">Unique-id of the messages to label.</param><param name="label">Label to be added.</param>
    /// <returns>
    /// List containing Gmail labels of the specified messages.
    /// </returns>
    public List<GmailMessageLabels> GmailLabelMessageByUID(List<long> uids, string label)
    {
      return this.GmailLabelMessageByUID(uids, new List<string>()
      {
        label
      });
    }

    /// <summary>
    /// Labels the messages with specified label.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.GmailUnlabelMessage(System.Collections.Generic.List{System.Int64},System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.GmailLabelMessageByUID(System.Collections.Generic.List{System.Int64},System.String)"/><param name="messageNumbers">1 based message numbers.</param><param name="label">Label to be added.</param>
    /// <returns>
    /// List containing Gmail labels of the specified messages.
    /// </returns>
    public List<GmailMessageLabels> GmailLabelMessageByNumber(List<long> messageNumbers, string label)
    {
      return this.GmailLabelMessageByNumber(messageNumbers, new List<string>()
      {
        label
      });
    }

    /// <summary>
    /// Labels the messages with specified label.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.GmailUnlabelMessage(System.Collections.Generic.List{System.Int64},System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.GmailLabelMessageByUID(System.Collections.Generic.List{System.Int64},System.String)"/><param name="messageNumbers">1 based message numbers.</param><param name="label">Label to be added.</param>
    /// <returns>
    /// List containing Gmail labels of the specified messages.
    /// </returns>
    [Obsolete("Please use Imap.GmailLabelMessageByNumber method instead.")]
    public List<GmailMessageLabels> GmailLabelMessage(List<long> messageNumbers, string label)
    {
      return this.GmailLabelMessageByNumber(messageNumbers, label);
    }

    /// <summary>
    /// Labels the messages with specified labels.
    /// 
    /// </summary>
    /// <param name="uids">Unique-id of the messages to label.</param><param name="labels">Labels to be added.</param>
    /// <returns>
    /// List containing Gmail labels of the specified messages.
    /// </returns>
    public List<GmailMessageLabels> GmailLabelMessageByUID(List<long> uids, List<string> labels)
    {
      this.\u0005();
      if (uids.Count == 0 || labels.Count == 0)
        return new List<GmailMessageLabels>();
      return new \u0005\u2006\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195385285), new object[2]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) uids).\u0003(),
        (object) new \u000E\u2004\u2000(labels).\u0002()
      })).\u0002();
    }

    /// <summary>
    /// Labels the messages with specified labels.
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param><param name="labels">Labels to be added.</param>
    /// <returns>
    /// List containing Gmail labels of the specified messages.
    /// </returns>
    public List<GmailMessageLabels> GmailLabelMessageByNumber(List<long> messageNumbers, List<string> labels)
    {
      this.\u0005();
      if (messageNumbers.Count == 0 || labels.Count == 0)
        return new List<GmailMessageLabels>();
      return new \u0005\u2006\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195385326), new object[2]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) messageNumbers).\u0003(),
        (object) new \u000E\u2004\u2000(labels).\u0002()
      })).\u0002();
    }

    /// <summary>
    /// Labels the messages with specified labels.
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param><param name="labels">Labels to be added.</param>
    /// <returns>
    /// List containing Gmail labels of the specified messages.
    /// </returns>
    [Obsolete("Please use Imap.GmailLabelMessageByNumber method instead.")]
    public List<GmailMessageLabels> GmailLabelMessage(List<long> messageNumbers, List<string> labels)
    {
      return this.GmailLabelMessageByNumber(messageNumbers, labels);
    }

    /// <summary>
    /// Labels the message with specified label.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.GmailUnlabelMessageByUID(System.Int64,System.String)"/><param name="uid">Unique-id of the message to label.</param><param name="label">Label to be added.</param>
    /// <returns>
    /// List containing Gmail labels of the specified message or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    public List<string> GmailLabelMessageByUID(long uid, string label)
    {
      return this.GmailLabelMessageByUID(uid, new List<string>()
      {
        label
      });
    }

    /// <summary>
    /// Labels the message with specified label.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.GmailUnlabelMessage(System.Int64,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.GmailLabelMessageByUID(System.Int64,System.String)"/><param name="messageNumber">1 based message number.</param><param name="label">Label to be added.</param>
    /// <returns>
    /// List containing Gmail labels of the specified message or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    public List<string> GmailLabelMessageByNumber(long messageNumber, string label)
    {
      return this.GmailLabelMessageByNumber(messageNumber, new List<string>()
      {
        label
      });
    }

    /// <summary>
    /// Labels the message with specified label.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.GmailUnlabelMessage(System.Int64,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.GmailLabelMessageByUID(System.Int64,System.String)"/><param name="messageNumber">1 based message number.</param><param name="label">Label to be added.</param>
    /// <returns>
    /// List containing Gmail labels of the specified message or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    [Obsolete("Please use Imap.GmailLabelMessageByNumber method instead.")]
    public List<string> GmailLabelMessage(long messageNumber, string label)
    {
      return this.GmailLabelMessageByNumber(messageNumber, label);
    }

    /// <summary>
    /// Labels the messages with specified labels.
    /// 
    /// </summary>
    /// <param name="uid">Unique-id of the message to label.</param><param name="labels">Labels to be added.</param>
    /// <returns>
    /// List containing Gmail labels of the specified message or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    public List<string> GmailLabelMessageByUID(long uid, List<string> labels)
    {
      List<GmailMessageLabels> list = this.GmailLabelMessageByUID(new List<long>()
      {
        uid
      }, labels);
      if (list.Count != 0)
        return list[0].Labels;
      else
        return (List<string>) null;
    }

    /// <summary>
    /// Labels the messages with specified labels.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="labels">Labels to be added.</param>
    /// <returns>
    /// List containing Gmail labels of the specified message or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    public List<string> GmailLabelMessageByNumber(long messageNumber, List<string> labels)
    {
      List<GmailMessageLabels> list = this.GmailLabelMessageByNumber(new List<long>()
      {
        messageNumber
      }, labels);
      if (list.Count != 0)
        return list[0].Labels;
      else
        return (List<string>) null;
    }

    /// <summary>
    /// Labels the messages with specified labels.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="labels">Labels to be added.</param>
    /// <returns>
    /// List containing Gmail labels of the specified message or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    [Obsolete("Please use Imap.GmailLabelMessageByNumber method instead.")]
    public List<string> GmailLabelMessage(long messageNumber, List<string> labels)
    {
      return this.GmailLabelMessageByNumber(messageNumber, labels);
    }

    /// <summary>
    /// Removes specified label from the message.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.GmailLabelMessageByUID(System.Int64,System.String)"/><param name="uid">Unique-id of the message to remove specified label from.</param><param name="label">Label to be removed.</param>
    /// <returns>
    /// List containing Gmail labels of the specified message or null when <paramref name="uid"/> is incorrect.
    /// </returns>
    public List<string> GmailUnlabelMessageByUID(long uid, string label)
    {
      List<GmailMessageLabels> list = this.GmailUnlabelMessageByUID(new List<long>()
      {
        uid
      }, label);
      if (list.Count != 0)
        return list[0].Labels;
      else
        return (List<string>) null;
    }

    /// <summary>
    /// Removes specified label from the message.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.GmailLabelMessage(System.Int64,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.GmailUnlabelMessageByUID(System.Int64,System.String)"/><param name="messageNumber">1 based message number.</param><param name="label">Label to be removed.</param>
    /// <returns>
    /// List containing Gmail labels of the specified message or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    public List<string> GmailUnlabelMessageByNumber(long messageNumber, string label)
    {
      List<GmailMessageLabels> list = this.GmailUnlabelMessageByNumber(new List<long>()
      {
        messageNumber
      }, label);
      if (list.Count != 0)
        return list[0].Labels;
      else
        return (List<string>) null;
    }

    /// <summary>
    /// Removes specified label from the message.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.GmailLabelMessage(System.Int64,System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.GmailUnlabelMessageByUID(System.Int64,System.String)"/><param name="messageNumber">1 based message number.</param><param name="label">Label to be removed.</param>
    /// <returns>
    /// List containing Gmail labels of the specified message or null when <paramref name="messageNumber"/> is incorrect.
    /// </returns>
    [Obsolete("Please use Imap.GmailUnlabelMessageByNumber method instead.")]
    public List<string> GmailUnlabelMessage(long messageNumber, string label)
    {
      return this.GmailUnlabelMessageByNumber(messageNumber, label);
    }

    /// <summary>
    /// Removes specified label from messages.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.GmailLabelMessageByUID(System.Collections.Generic.List{System.Int64},System.String)"/><param name="uids">Unique-id of the message to remove specified label from.</param><param name="label">Label to be removed.</param>
    /// <returns>
    /// List containing Gmail labels of the specified messages.
    /// </returns>
    public List<GmailMessageLabels> GmailUnlabelMessageByUID(List<long> uids, string label)
    {
      this.\u0005();
      if (uids.Count == 0)
        return new List<GmailMessageLabels>();
      return new \u0005\u2006\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195385267), new object[2]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) uids).\u0003(),
        (object) new \u000E\u2004\u2000(label).\u0002()
      })).\u0002();
    }

    /// <summary>
    /// Removes specified label from messages.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.GmailLabelMessage(System.Collections.Generic.List{System.Int64},System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.GmailUnlabelMessageByUID(System.Collections.Generic.List{System.Int64},System.String)"/><param name="messageNumbers">1 based message number.</param><param name="label">Label to be removed.</param>
    /// <returns>
    /// List containing Gmail labels of the specified messages.
    /// </returns>
    public List<GmailMessageLabels> GmailUnlabelMessageByNumber(List<long> messageNumbers, string label)
    {
      this.\u0005();
      if (messageNumbers.Count == 0)
        return new List<GmailMessageLabels>();
      return new \u0005\u2006\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195385180), new object[2]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) messageNumbers).\u0003(),
        (object) new \u000E\u2004\u2000(label).\u0002()
      })).\u0002();
    }

    /// <summary>
    /// Removes specified label from messages.
    /// 
    /// </summary>
    /// <seealso cref="M:Limilabs.Client.IMAP.Imap.GmailLabelMessage(System.Collections.Generic.List{System.Int64},System.String)"/><seealso cref="M:Limilabs.Client.IMAP.Imap.GmailUnlabelMessageByUID(System.Collections.Generic.List{System.Int64},System.String)"/><param name="messageNumbers">1 based message number.</param><param name="label">Label to be removed.</param>
    /// <returns>
    /// List containing Gmail labels of the specified messages.
    /// </returns>
    [Obsolete("Please use Imap.GmailUnlabelMessageByNumber method instead.")]
    public List<GmailMessageLabels> GmailUnlabelMessage(List<long> messageNumbers, string label)
    {
      return this.GmailUnlabelMessageByNumber(messageNumbers, label);
    }

    /// <summary>
    /// Deletes message specified by the <paramref name="uid"/>. Issues EXPUNGE command after.
    /// 
    /// </summary>
    /// <param name="uid">Unique-id of the message to flag.</param>
    public void DeleteMessageByUID(long uid)
    {
      this.DeleteMessageByUID(new List<long>()
      {
        uid
      });
    }

    /// <summary>
    /// Deletes message specified by the <paramref name="messageNumber"/>. Issues EXPUNGE command after.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param>
    public void DeleteMessageByNumber(long messageNumber)
    {
      this.DeleteMessageByNumber(new List<long>()
      {
        messageNumber
      });
    }

    /// <summary>
    /// Deletes message specified by the <paramref name="messageNumber"/>. Issues EXPUNGE command after.
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param>
    [Obsolete("Please use Imap.DeleteMessageByNumber method instead.")]
    public void DeleteMessage(long messageNumber)
    {
      this.DeleteMessageByNumber(messageNumber);
    }

    /// <summary>
    /// Deletes message specified by the <paramref name="uids"/>. Issues EXPUNGE command after.
    /// 
    /// </summary>
    /// <param name="uids">Unique-id of the messages to flag.</param>
    public void DeleteMessageByUID(List<long> uids)
    {
      this.\u0005();
      this.FlagMessageByUID(uids, Flag.Deleted);
      this.\u0003();
    }

    /// <summary>
    /// Deletes messages specified by the <paramref name="messageNumbers"/>. Issues EXPUNGE command after.
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param>
    public void DeleteMessageByNumber(List<long> messageNumbers)
    {
      this.\u0005();
      this.FlagMessageByNumber(messageNumbers, Flag.Deleted);
      this.\u0003();
    }

    /// <summary>
    /// Deletes messages specified by the <paramref name="messageNumbers"/>. Issues EXPUNGE command after.
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param>
    [Obsolete("Please use Imap.DeleteMessageByNumber method instead.")]
    public void DeleteMessage(List<long> messageNumbers)
    {
      this.DeleteMessageByNumber(messageNumbers);
    }

    private new void \u0003()
    {
      this.SendCommand(\u0006\u2001\u2004.\u0002(-195385209));
    }

    /// <summary>
    /// Copies the specified message to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// <param name="uid">Unique-id of the message.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-id of the copied message if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, null otherwise.
    /// </returns>
    public long? CopyByUID(long uid, string destinationFolder)
    {
      List<long> list = this.CopyByUID(new List<long>()
      {
        uid
      }, destinationFolder);
      if (list.Count != 0)
        return new long?(list[0]);
      else
        return new long?();
    }

    /// <summary>
    /// Copies the specified message to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// <param name="messageNumber">1 based message number.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-id of the copied message if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, null otherwise.
    /// </returns>
    public long? CopyByNumber(long messageNumber, string destinationFolder)
    {
      List<long> list = this.CopyByNumber(new List<long>()
      {
        messageNumber
      }, destinationFolder);
      if (list.Count != 0)
        return new long?(list[0]);
      else
        return new long?();
    }

    /// <summary>
    /// Copies the specified message to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// <param name="messageNumber">1 based message number.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-id of the copied message if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, null otherwise.
    /// </returns>
    [Obsolete("Please use Imap.CopyByNumber method instead.")]
    public long? Copy(long messageNumber, string destinationFolder)
    {
      return this.CopyByNumber(messageNumber, destinationFolder);
    }

    /// <summary>
    /// Copies the specified message to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// <param name="uid">Unique-id of the message.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-id of the copied message if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, null otherwise.
    /// </returns>
    public long? CopyByUID(long uid, FolderInfo destinationFolder)
    {
      return this.CopyByUID(uid, destinationFolder.Name);
    }

    /// <summary>
    /// Copies the specified message to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-id of the copied message if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, null otherwise.
    /// </returns>
    public long? CopyByNumber(long messageNumber, FolderInfo destinationFolder)
    {
      return this.CopyByNumber(messageNumber, destinationFolder.Name);
    }

    /// <summary>
    /// Copies the specified message to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-id of the copied message if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, null otherwise.
    /// </returns>
    [Obsolete("Please use Imap.CopyByNumber method instead.")]
    public long? Copy(long messageNumber, FolderInfo destinationFolder)
    {
      return this.CopyByNumber(messageNumber, destinationFolder);
    }

    /// <summary>
    /// Copies the specified messages to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// <param name="uids">Unique-ids of the messages.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-ids of the copied messages if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, empty otherwise.
    /// </returns>
    public List<long> CopyByUID(List<long> uids, FolderInfo destinationFolder)
    {
      return this.CopyByUID(uids, destinationFolder.Name);
    }

    /// <summary>
    /// Copies the specified messages to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-ids of the copied messages if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, empty otherwise.
    /// </returns>
    public List<long> CopyByNumber(List<long> messageNumbers, FolderInfo destinationFolder)
    {
      return this.CopyByNumber(messageNumbers, destinationFolder.Name);
    }

    /// <summary>
    /// Copies the specified messages to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-ids of the copied messages if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, empty otherwise.
    /// </returns>
    [Obsolete("Please use Imap.CopyByNumber method instead.")]
    public List<long> Copy(List<long> messageNumbers, FolderInfo destinationFolder)
    {
      return this.CopyByNumber(messageNumbers, destinationFolder.Name);
    }

    /// <summary>
    /// Copies the specified messages to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// <param name="uids">Unique-ids of the messages.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-ids of the copied messages if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, empty otherwise.
    /// </returns>
    public List<long> CopyByUID(List<long> uids, string destinationFolder)
    {
      this.\u0005();
      if (uids.Count == 0)
        return new List<long>();
      destinationFolder = Imap.\u0003(destinationFolder);
      return new \u0006\u2005\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195385195), new object[2]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) uids).\u0003(),
        (object) destinationFolder
      })).\u0003();
    }

    /// <summary>
    /// Copies the specified messages to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// <param name="messageNumbers">1 based message numbers.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-ids of the copied messages if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, empty otherwise.
    /// </returns>
    public List<long> CopyByNumber(List<long> messageNumbers, string destinationFolder)
    {
      this.\u0005();
      if (messageNumbers.Count == 0)
        return new List<long>();
      destinationFolder = Imap.\u0003(destinationFolder);
      return new \u0006\u2005\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195385090), new object[2]
      {
        (object) new \u0006\u2006\u2000((IEnumerable<long>) messageNumbers).\u0003(),
        (object) destinationFolder
      })).\u0003();
    }

    /// <summary>
    /// Copies the specified messages to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// <param name="messageNumbers">1 based message numbers.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-ids of the copied messages if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, empty otherwise.
    /// </returns>
    [Obsolete("Please use Imap.CopyByNumber method instead.")]
    public List<long> Copy(List<long> messageNumbers, string destinationFolder)
    {
      return this.CopyByNumber(messageNumbers, destinationFolder);
    }

    /// <summary>
    /// Moves the specified message to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// <param name="uid">Unique-id of the message.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-id of the copied message if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, null otherwise.
    /// </returns>
    public long? MoveByUID(long uid, FolderInfo destinationFolder)
    {
      return this.MoveByUID(uid, destinationFolder.Name);
    }

    /// <summary>
    /// Moves the specified message to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-id of the copied message if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, null otherwise.
    /// </returns>
    public long? MoveByNumber(long messageNumber, FolderInfo destinationFolder)
    {
      return this.MoveByNumber(messageNumber, destinationFolder.Name);
    }

    /// <summary>
    /// Moves the specified message to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// <param name="messageNumber">1 based message number.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-id of the copied message if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, null otherwise.
    /// </returns>
    [Obsolete("Please use Imap.MoveByNumber method instead.")]
    public long? Move(long messageNumber, FolderInfo destinationFolder)
    {
      return this.MoveByNumber(messageNumber, destinationFolder);
    }

    /// <summary>
    /// Moves the specified message to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in mailbox folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// <param name="uid">Unique-id of the message.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-id of the copied message if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, null otherwise.
    /// </returns>
    public long? MoveByUID(long uid, string destinationFolder)
    {
      List<long> list = this.MoveByUID(new List<long>()
      {
        uid
      }, destinationFolder);
      if (list.Count != 0)
        return new long?(list[0]);
      else
        return new long?();
    }

    /// <summary>
    /// Moves the specified message to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in mailbox folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// <param name="messageNumber">1 based message number.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-id of the copied message if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, null otherwise.
    /// </returns>
    public long? MoveByNumber(long messageNumber, string destinationFolder)
    {
      List<long> list = this.MoveByNumber(new List<long>()
      {
        messageNumber
      }, destinationFolder);
      if (list.Count != 0)
        return new long?(list[0]);
      else
        return new long?();
    }

    /// <summary>
    /// Moves the specified message to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in mailbox folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// <param name="messageNumber">1 based message number.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-id of the copied message if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, null otherwise.
    /// </returns>
    [Obsolete("Please use Imap.MoveByNumber method instead.")]
    public long? Move(long messageNumber, string destinationFolder)
    {
      return this.MoveByNumber(messageNumber, destinationFolder);
    }

    /// <summary>
    /// Moves the specified messages to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in mailbox folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// <param name="uids">Unique-ids of the messages.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-ids of the copied messages if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, empty otherwise.
    /// </returns>
    public List<long> MoveByUID(List<long> uids, string destinationFolder)
    {
      this.\u0005();
      if (uids.Count == 0)
        return new List<long>();
      List<long> list = this.CopyByUID(uids, destinationFolder);
      this.DeleteMessageByUID(uids);
      return list;
    }

    /// <summary>
    /// Moves the specified messages to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in mailbox folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// <param name="messageNumbers">1 based message numbers.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-ids of the copied messages if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, empty otherwise.
    /// </returns>
    public List<long> MoveByNumber(List<long> messageNumbers, string destinationFolder)
    {
      this.\u0005();
      if (messageNumbers.Count == 0)
        return new List<long>();
      List<long> list = this.CopyByNumber(messageNumbers, destinationFolder);
      this.DeleteMessageByNumber(messageNumbers);
      return list;
    }

    /// <summary>
    /// Moves the specified messages to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in mailbox folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// <param name="messageNumbers">1 based message numbers.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-ids of the copied messages if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, empty otherwise.
    /// </returns>
    [Obsolete("Please use Imap.MoveByNumber method instead.")]
    public List<long> Move(List<long> messageNumbers, string destinationFolder)
    {
      return this.MoveByNumber(messageNumbers, destinationFolder);
    }

    /// <summary>
    /// Moves the specified messages to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// <param name="uids">Unique-ids of the messages.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-ids of the copied messages if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, empty otherwise.
    /// </returns>
    public List<long> MoveByUID(List<long> uids, FolderInfo destinationFolder)
    {
      return this.MoveByUID(uids, destinationFolder.Name);
    }

    /// <summary>
    /// Moves the specified messages to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-ids of the copied messages if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, empty otherwise.
    /// </returns>
    public List<long> MoveByNumber(List<long> messageNumbers, FolderInfo destinationFolder)
    {
      return this.MoveByNumber(messageNumbers, destinationFolder.Name);
    }

    /// <summary>
    /// Moves the specified messages to the specified destination folder (mailbox).
    /// 
    /// </summary>
    /// <param name="messageNumbers">1 based message numbers.</param><param name="destinationFolder">Destination folder (mailbox).</param>
    /// <returns>
    /// Unique-ids of the copied messages if the server supports <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>, empty otherwise.
    /// </returns>
    [Obsolete("Please use Imap.MoveByNumber method instead.")]
    public List<long> Move(List<long> messageNumbers, FolderInfo destinationFolder)
    {
      return this.MoveByNumber(messageNumbers, destinationFolder);
    }

    /// <summary>
    /// Lists all namespaces available for this user.
    ///             Not all servers support <see cref="F:Limilabs.Client.IMAP.ImapExtension.Namespace"/>. You can check which extensions remote server supports using <see cref="M:Limilabs.Client.IMAP.Imap.SupportedExtensions"/> method.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// 
    /// <returns>
    /// Folder list.
    /// </returns>
    public Namespaces GetNamespaces()
    {
      return new \u0006\u2007\u2000(this.SendCommand(\u0006\u2001\u2004.\u0002(-195385141))).\u0002();
    }

    /// <summary>
    /// Subscribes user to specified folder.
    /// 
    /// </summary>
    /// <param name="folder">Folder name to subscribe to.</param>
    public void SubscribeFolder(FolderInfo folder)
    {
      this.SubscribeFolder(folder.Name);
    }

    /// <summary>
    /// Subscribes user to specified folder.
    /// 
    /// </summary>
    /// <param name="folder">Folder name to subscribe to.</param>
    public void SubscribeFolder(string folder)
    {
      this.\u0002(\u0006\u2001\u2004.\u0002(-195385125), new object[1]
      {
        (object) Imap.\u0003(folder)
      });
    }

    /// <summary>
    /// Unsubscribes user from specified folder.
    /// 
    /// </summary>
    /// <param name="folder">Folder name to unsubscribe from.</param>
    public void UnsubscribeFolder(FolderInfo folder)
    {
      this.UnsubscribeFolder(folder.Name);
    }

    /// <summary>
    /// Unsubscribes user from specified folder.
    /// 
    /// </summary>
    /// <param name="folder">Folder name to unsubscribe from.</param>
    public void UnsubscribeFolder(string folder)
    {
      this.\u0002(\u0006\u2001\u2004.\u0002(-195383519), new object[1]
      {
        (object) Imap.\u0003(folder)
      });
    }

    /// <summary>
    /// Lists all folders (mailboxes) user is subscribed to.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// 
    /// <returns>
    /// Folder list.
    /// </returns>
    public List<FolderInfo> GetSubscribedFolders()
    {
      return this.GetSubscribedFolders(string.Empty);
    }

    /// <summary>
    /// Lists all folders (mailboxes) user is subscribed to starting from specified folder.
    /// 
    /// </summary>
    /// <param name="folder">Parent folder (mailbox) to start search from.</param>
    /// <returns>
    /// Folder list.
    /// </returns>
    public List<FolderInfo> GetSubscribedFolders(FolderInfo folder)
    {
      return this.GetSubscribedFolders(folder.Name);
    }

    /// <summary>
    /// Lists all folders (mailboxes) user is subscribed to starting from specified folder.
    /// 
    /// </summary>
    /// <param name="folder">Parent folder (mailbox) to start search from.</param>
    /// <remarks>
    /// IMAP servers may differ in the separator character used in folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// 
    /// <returns>
    /// Folder list.
    /// </returns>
    public List<FolderInfo> GetSubscribedFolders(string folder)
    {
      return new \u0002\u2007\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195383543), new object[1]
      {
        (object) Imap.\u0003(folder)
      })).\u0002();
    }

    /// <summary>
    /// Lists all folders (mailboxes) starting from root.
    ///             Folders starting with '#' are usually shared between users. You can use <see cref="M:Limilabs.Client.IMAP.Imap.GetNamespaces"/> to obtain information about shared folders.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// 
    /// <returns>
    /// Folder list.
    /// </returns>
    /// <seealso cref="T:Limilabs.Client.IMAP.CommonFolders"/>
    public List<FolderInfo> GetFolders()
    {
      return this.GetFolders(string.Empty);
    }

    /// <summary>
    /// Lists all folders (mailboxes) under specified folder (mailbox).
    /// 
    /// </summary>
    /// <param name="folder">Parent folder (mailbox) to start search from.</param>
    /// <returns>
    /// Folder list.
    /// </returns>
    /// <seealso cref="T:Limilabs.Client.IMAP.CommonFolders"/>
    public List<FolderInfo> GetFolders(FolderInfo folder)
    {
      return this.GetFolders(folder.\u0002());
    }

    /// <summary>
    /// Lists all folders (mailboxes) under specified folder (mailbox).
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// <param name="folder">Parent folder (mailbox) to start search from. Most serves require trailing separator (e.g. "[Gmail]/").</param>
    /// <returns>
    /// Folder list.
    /// </returns>
    /// <seealso cref="T:Limilabs.Client.IMAP.CommonFolders"/>
    public List<FolderInfo> GetFolders(string folder)
    {
      return this.\u0008(folder, \u0006\u2001\u2004.\u0002(-195387792));
    }

    /// <summary>
    /// Lists folders (mailboxes) starting from root. Only direct children are returned.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// 
    /// <returns>
    /// Folder list.
    /// </returns>
    /// <seealso cref="T:Limilabs.Client.IMAP.CommonFolders"/>
    public List<FolderInfo> GetFoldersOneLevelDown()
    {
      return this.GetFoldersOneLevelDown(string.Empty);
    }

    /// <summary>
    /// Lists all folders (mailboxes) under specified folder (mailbox). Only direct children are returned.
    /// 
    /// </summary>
    /// <param name="folder">Parent folder (mailbox) to start search from.</param>
    /// <returns>
    /// Folder list.
    /// </returns>
    /// <seealso cref="T:Limilabs.Client.IMAP.CommonFolders"/>
    public List<FolderInfo> GetFoldersOneLevelDown(FolderInfo folder)
    {
      return this.GetFoldersOneLevelDown(folder.\u0002());
    }

    /// <summary>
    /// Lists all folders (mailboxes) under specified folder (mailbox). Only direct children are returned.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// <param name="folder">Parent folder (mailbox) to start search from. Most serves require trailing separator (e.g. "[Gmail]/").</param>
    /// <returns>
    /// Folder list.
    /// </returns>
    /// <seealso cref="T:Limilabs.Client.IMAP.CommonFolders"/>
    public List<FolderInfo> GetFoldersOneLevelDown(string folder)
    {
      return this.\u0008(folder, \u0006\u2001\u2004.\u0002(-195383532));
    }

    private List<FolderInfo> \u0008(string \u0002, string \u0003)
    {
      param0 = Imap.\u0003(param0);
      if (this.\u0005.\u0002(ImapExtension.XList))
        return new \u0002\u2009\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195383444), new object[2]
        {
          (object) param0,
          (object) param1
        })).\u0002();
      else if (this.\u0005.\u0002(ImapExtension.SpecialUse))
        return new \u000F\u2006\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195383436), new object[2]
        {
          (object) param0,
          (object) param1
        })).\u0002();
      else
        return new \u000F\u2006\u2000(this.\u0002(\u0006\u2001\u2004.\u0002(-195383384), new object[2]
        {
          (object) param0,
          (object) param1
        })).\u0002();
    }

    /// <summary>
    /// Creates a folder (mailbox) with the given name.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// <param name="folder">Folder name.</param>
    public void CreateFolder(string folder)
    {
      this.\u0002(\u0006\u2001\u2004.\u0002(-195383369), new object[1]
      {
        (object) Imap.\u0003(folder)
      });
    }

    /// <summary>
    /// Permanently removes a folder (mailbox) with the given name.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// <param name="folder">Folder name.</param>
    public void DeleteFolder(string folder)
    {
      this.\u0002(\u0006\u2001\u2004.\u0002(-195383422), new object[1]
      {
        (object) Imap.\u0003(folder)
      });
    }

    /// <summary>
    /// Changes the name of a folder (mailbox).
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// <param name="existingFolder">Existing folder name.</param><param name="newFolder">New folder name.</param>
    public void RenameFolder(string existingFolder, string newFolder)
    {
      this.\u0002(\u0006\u2001\u2004.\u0002(-195383315), new object[2]
      {
        (object) Imap.\u0003(existingFolder),
        (object) Imap.\u0003(newFolder)
      });
    }

    /// <summary>
    /// Uploads message to specified folder (mailbox).
    /// 
    /// </summary>
    /// <param name="folder">Folder to upload.</param><param name="eml">Message to upload.</param><param name="messageInfo">Additional message information (e.g. flags, internal date, Gmail labels).</param>
    /// <returns>
    /// Unique-id of the uploaded message (<c>Null</c> if server does not support <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>).
    /// </returns>
    public long? UploadMessage(string folder, string eml, UploadMessageInfo messageInfo)
    {
      folder = Imap.\u0003(folder);
      ImapCommand imapCommand = new ImapCommand(\u0002\u2003\u2001.\u0002());
      imapCommand.\u0002(\u0006\u2001\u2004.\u0002(-195383306));
      imapCommand.\u0002(\u0006\u2001\u2004.\u0002(-195393923));
      imapCommand.\u0003(folder);
      imapCommand.\u0002(\u0006\u2001\u2004.\u0002(-195393923));
      messageInfo.\u0002(imapCommand);
      imapCommand.\u0003(eml);
      return new \u000F\u2004\u2000(this.\u0002(imapCommand)).\u0003();
    }

    /// <summary>
    /// Uploads message to specified folder (mailbox). Uploaded message has <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> set.
    ///             Internal date of the resulting message is set to the current date and time.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// <param name="folder">Folder name to upload to.</param><param name="mail">Message to upload.</param>
    /// <returns>
    /// Unique-id of the uploaded message (<c>Null</c> if server does not support <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>).
    /// </returns>
    public long? UploadMessage(string folder, IMail mail)
    {
      return this.UploadMessage(folder, mail.RenderEml());
    }

    /// <summary>
    /// Uploads message to specified folder (mailbox). Uploaded message has <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> set.
    ///             Internal date of the resulting message is set to the current date and time.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// 
    /// <returns>
    /// Unique-id of the uploaded message (<c>Null</c> if server does not support <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>).
    /// </returns>
    /// <param name="folder">Folder name to upload to.</param><param name="eml">Message to upload.</param>
    public long? UploadMessage(string folder, string eml)
    {
      return this.UploadMessage(folder, eml, new UploadMessageInfo()
      {
        Flags = {
          Flag.Seen
        }
      });
    }

    /// <summary>
    /// Uploads message to specified folder (mailbox).
    /// 
    /// </summary>
    /// <param name="folder">Folder to upload.</param><param name="email">Message to upload.</param><param name="messageInfo">Additional message information (e.g. flags, internal date, Gmail labels).</param>
    /// <returns>
    /// Unique-id of the uploaded message (<c>Null</c> if server does not support <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>).
    /// </returns>
    public long? UploadMessage(string folder, IMail email, UploadMessageInfo messageInfo)
    {
      return this.UploadMessage(folder, email.RenderEml(), messageInfo);
    }

    /// <summary>
    /// Uploads message to specified folder (mailbox). Uploaded message has <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> set.
    ///             Internal date of the resulting message is set to the current date and time.
    /// 
    /// </summary>
    /// <param name="folder">Folder to upload  to.</param><param name="mail">Message to upload.</param>
    /// <returns>
    /// Unique-id of the uploaded message (<c>Null</c> if server does not support <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>).
    /// </returns>
    public long? UploadMessage(FolderInfo folder, IMail mail)
    {
      return this.UploadMessage(folder.Name, mail.RenderEml());
    }

    /// <summary>
    /// Uploads message to specified folder (mailbox). Uploaded message has <see cref="F:Limilabs.Client.IMAP.Flag.Seen"/> set.
    ///             Internal date of the resulting message is set to the current date and time.
    /// 
    /// </summary>
    /// 
    /// <remarks>
    /// IMAP servers may differ in the separator character used in folder hierarchy paths.
    ///             Common separator chars are '.' and '/'. For example: "Inbox/Folder" or "Inbox.Folder".
    /// 
    /// </remarks>
    /// 
    /// <returns>
    /// Unique-id of the uploaded message (<c>Null</c> if server does not support <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>).
    /// </returns>
    /// <param name="folder">Folder to upload  to.</param><param name="eml">Message to upload.</param>
    public long? UploadMessage(FolderInfo folder, string eml)
    {
      return this.UploadMessage(folder.Name, eml);
    }

    /// <summary>
    /// Uploads message to specified folder (mailbox).
    /// 
    /// </summary>
    /// <param name="folder">Folder to upload.</param><param name="eml">Message to upload.</param><param name="messageInfo">Additional message information (e.g. flags, internal date).</param>
    /// <returns>
    /// Unique-id of the uploaded message (<c>Null</c> if server does not support <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>).
    /// </returns>
    public long? UploadMessage(FolderInfo folder, string eml, UploadMessageInfo messageInfo)
    {
      return this.UploadMessage(folder.Name, eml, messageInfo);
    }

    /// <summary>
    /// Uploads message to specified folder (mailbox).
    /// 
    /// </summary>
    /// <param name="folder">Folder to upload.</param><param name="mail">Message to upload.</param><param name="messageInfo">Additional message information (e.g. flags, internal date).</param>
    /// <returns>
    /// Unique-id of the uploaded message (<c>Null</c> if server does not support <see cref="F:Limilabs.Client.IMAP.ImapExtension.UniqueIdPlus"/>).
    /// </returns>
    public long? UploadMessage(FolderInfo folder, IMail mail, UploadMessageInfo messageInfo)
    {
      return this.UploadMessage(folder.Name, mail.RenderEml(), messageInfo);
    }

    private ImapResponse \u0002(ImapCommand \u0002)
    {
      return this.\u0002(param0, true);
    }

    private ImapResponse \u0002(ImapCommand \u0002, bool \u0003)
    {
      StringBuilder stringBuilder = new StringBuilder();
      string tag = this.\u000E();
      stringBuilder.Append(tag + (object) ' ');
      foreach (\u0006\u2003\u2000 obj in param0.\u0003)
      {
        if (obj is \u0003\u2004\u2000)
          stringBuilder.Append(((\u0003\u2004\u2000) obj).\u0002());
        else if (obj is \u0002\u2004\u2000)
        {
          byte[] bytes = ((\u0002\u2004\u2000) obj).\u0002();
          stringBuilder.Append(\u0006\u2001\u2004.\u0002(-195383349) + (object) bytes.Length + \u0006\u2001\u2004.\u0002(-195383357));
          this.Send(((object) stringBuilder).ToString());
          stringBuilder.Length = 0;
          ImapResponse imapResponse = this.ReceiveResponse(tag);
          if (imapResponse.ImapResponseStatus != ImapResponseStatus.SendMoreData)
            throw new ServerException(\u0006\u2001\u2004.\u0002(-195389757) + imapResponse.StatusLine);
          this.Send(bytes);
        }
      }
      this.Send(((object) stringBuilder).ToString());
      ImapResponse imapResponse1 = this.ReceiveResponse(tag);
      if (param1 && imapResponse1.ImapResponseStatus != ImapResponseStatus.Positive)
        throw new ServerException(imapResponse1.Message);
      else
        return imapResponse1;
    }

    private new void \u0005()
    {
      if (this.\u0003 == null)
        throw new Exception(\u0006\u2001\u2004.\u0002(-195383333));
    }

    internal void \u0002(Flag \u0002)
    {
      if (param0 == Flag.All || param0 == Flag.Unanswered || (param0 == Flag.Undeleted || param0 == Flag.Undraft) || (param0 == Flag.Unflagged || param0 == Flag.Unseen))
        throw new ArgumentException(\u0006\u2001\u2004.\u0002(-195383734));
    }

    /// <summary>
    /// Sends IDLE command.
    ///             This method hangs until server announces new event in current folder or until <see cref="M:Limilabs.Client.IMAP.Imap.StopIdle"/> command is issued.
    ///             Not all servers support <see cref="F:Limilabs.Client.IMAP.ImapExtension.Idle"/>. You can check which extensions remote server supports using <see cref="M:Limilabs.Client.IMAP.Imap.SupportedExtensions"/> method.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// New folder status.
    /// </returns>
    public FolderStatus Idle()
    {
      return this.Idle(TimeSpan.FromMinutes(29.0));
    }

    /// <summary>
    /// Sends IDLE command.
    ///             This method hangs until server announces new event in current folder or until <see cref="M:Limilabs.Client.IMAP.Imap.StopIdle"/> command is issued.
    ///             Not all servers support <see cref="F:Limilabs.Client.IMAP.ImapExtension.Idle"/>. You can check which extensions remote server supports using <see cref="M:Limilabs.Client.IMAP.Imap.SupportedExtensions"/> method.
    /// 
    /// </summary>
    /// <param name="timeout">Specifies the timeout after which IDLE command is reissued (this prevents server from disconnecting).</param>
    /// <returns>
    /// New folder status.
    /// </returns>
    public FolderStatus Idle(TimeSpan timeout)
    {
      this.\u0005();
      this.\u0002.\u0002(timeout);
      return this.\u0003;
    }

    /// <summary>
    /// Stops IDLE command started by <see cref="M:Limilabs.Client.IMAP.Imap.Idle"/> or <see cref="M:Limilabs.Client.IMAP.Imap.Idle(System.TimeSpan)"/> method.
    ///             This method is thread-safe.
    /// 
    /// </summary>
    public void StopIdle()
    {
      this.\u0002.\u0008();
    }

    /// <summary>
    /// Sends Yahoo's specific ID command ('ID ("GUID" "1")').
    ///             This command is required to access yahoo.
    ///             This command is sent automatically on connection when the host address contains "yahoo" string.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// IMAP response object.
    /// </returns>
    public ImapResponse SendYahooIDCommand()
    {
      return this.SendCommand(\u0006\u2001\u2004.\u0002(-195383583));
    }

    internal void \u0008()
    {
      this.\u0002(\u0006\u2001\u2004.\u0002(-195383601), new object[1]
      {
        (object) new BasicConstant(\u0006\u2001\u2004.\u0002(-195383590)).Name
      });
      base.\u0005();
    }

    private ImapResponse \u0003(ImapCommand \u0002)
    {
      return this.\u0002(param0, false);
    }

    private ImapResponse \u0005(ImapCommand \u0002)
    {
      return this.\u0002(param0, false);
    }
  }
}
