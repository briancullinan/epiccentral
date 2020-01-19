// Type: ActiveUp.Net.Mail.Imap4Client
// Assembly: ActiveUp.Net.Imap4, Version=5.0.3454.364, Culture=neutral, PublicKeyToken=9d424b1770e92b68
// Assembly location: C:\EPICSource\developer1_ARIZONA21\EPIC Website\EPICCentral\3rdPartyLibraries\ActiveUp.Net.Imap4.dll

using ActiveUp.Net.Security;
using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace ActiveUp.Net.Mail
{
  /// <summary>
  /// This class allows communication with an IMAP4 or IMAP4rev1 compatible server.
  /// 
  /// </summary>
  [Serializable]
  public class Imap4Client : TcpClient
  {
    private MailboxCollection _allMailboxes = new MailboxCollection();
    private MailboxCollection _mailboxes;
    private string host;
    private string _capabilities;
    private SslStream _sslStream;
    private bool _idleInProgress;
    private Imap4Client.DelegateConnect _delegateConnect;
    private Imap4Client.DelegateConnectAuth _delegateConnectAuth;
    private Imap4Client.DelegateConnectIPAddress _delegateConnectIPAddress;
    private Imap4Client.DelegateConnectIPAddresses _delegateConnectIPAddresses;
    private Imap4Client.DelegateConnectSsl _delegateConnectSsl;
    private Imap4Client.DelegateConnectSslIPAddress _delegateConnectSslIPAddress;
    private Imap4Client.DelegateConnectSslIPAddresses _delegateConnectSslIPAddresses;
    private Imap4Client.DelegateDisconnect _delegateDisconnect;
    private Imap4Client.DelegateAuthenticate _delegateAuthenticate;
    private Imap4Client.DelegateLogin _delegateLogin;
    private Imap4Client.DelegateCommand _delegateCommand;
    private Imap4Client.DelegateCommandStringStringString _delegateCommandStringStringString;
    private Imap4Client.DelegateNoop _delegateNoop;
    private Imap4Client.DelegateCheck _delegateCheck;
    private Imap4Client.DelegateClose _delegateClose;
    private Imap4Client.DelegateExpunge _delegateExpunge;
    private Imap4Client.DelegateLoadMailboxes _delegateLoadMailboxes;
    private Imap4Client.DelegateMailboxOperation _delegateMailboxOperation;
    private Imap4Client.DelegateRenameMailbox _delegateRenameMailbox;
    private Imap4Client.DelegateMailboxOperationReturnsString _delegateMailboxOperationReturnsString;
    private Imap4Client.DelegateGetMailboxes _delegateGetMailboxes;
    private AuthenticatingEventHandler Authenticating;
    private AuthenticatedEventHandler Authenticated;
    private NoopingEventHandler Nooping;
    private NoopedEventHandler Nooped;
    private TcpWritingEventHandler TcpWriting;
    private TcpWrittenEventHandler TcpWritten;
    private TcpReadingEventHandler TcpReading;
    private TcpReadEventHandler TcpRead;
    private MessageRetrievingEventHandler MessageRetrieving;
    private MessageRetrievedEventHandler MessageRetrieved;
    private HeaderRetrievingEventHandler HeaderRetrieving;
    private HeaderRetrievedEventHandler HeaderRetrieved;
    private ConnectingEventHandler Connecting;
    private ConnectedEventHandler Connected;
    private DisconnectingEventHandler Disconnecting;
    private DisconnectedEventHandler Disconnected;
    private MessageSendingEventHandler MessageSending;
    private MessageSentEventHandler MessageSent;
    private NewMessageReceivedEventHandler NewMessageReceived;

    /// <summary>
    /// Mailboxes on the account.
    /// 
    /// </summary>
    /// 
    /// <example>
    /// 
    /// <code>
    /// C#
    /// 
    ///             Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             int mailboxCount = imap.Mailboxes.Count;
    ///             //User jdoe1234 has mailboxCount mailboxes.
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("jdoe1234","tanstaaf")
    ///             Dim mailboxCount As Integer = imap.Mailboxes.Count
    ///             //User jdoe1234 has mailboxCount mailboxes.
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             var mailboxCount:int = imap.Mailboxes.Count;
    ///             //User jdoe1234 has mailboxCount mailboxes.
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public MailboxCollection Mailboxes
    {
      get
      {
        return this._mailboxes;
      }
      set
      {
        this._mailboxes = value;
      }
    }

    /// <summary>
    /// Same as the Mailboxes property, except that all mailboxes on the account are presented at the same level of hierarchy.
    ///             In example, a child mailbox of the "INBOX" mailbox could be accessed directly with this collection.
    /// 
    /// </summary>
    public MailboxCollection AllMailboxes
    {
      get
      {
        return this._allMailboxes;
      }
      set
      {
        this._allMailboxes = value;
      }
    }

    /// <summary>
    /// Server capabilities.
    /// 
    /// </summary>
    public string ServerCapabilities
    {
      get
      {
        return this._capabilities;
      }
      set
      {
        this._capabilities = value;
      }
    }

    /// <summary>
    /// Gets a value indicating whether this instance is connected.
    /// 
    /// </summary>
    /// 
    /// <value>
    /// <c>true</c> if this instance is connected; otherwise, <c>false</c>.
    /// 
    /// </value>
    public bool IsConnected
    {
      get
      {
        if (this.Client != null)
          return this.Client.Connected;
        else
          return false;
      }
    }

    /// <summary>
    /// Event fired when authentication starts.
    /// 
    /// </summary>
    public event AuthenticatingEventHandler Authenticating
    {
      [MethodImpl(MethodImplOptions.Synchronized)] add
      {
        this.Authenticating = this.Authenticating + value;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] remove
      {
        this.Authenticating = this.Authenticating - value;
      }
    }

    /// <summary>
    /// Event fired when authentication completed.
    /// 
    /// </summary>
    public event AuthenticatedEventHandler Authenticated
    {
      [MethodImpl(MethodImplOptions.Synchronized)] add
      {
        this.Authenticated = this.Authenticated + value;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] remove
      {
        this.Authenticated = this.Authenticated - value;
      }
    }

    /// <summary>
    /// Event fired when NOOP command is issued.
    /// 
    /// </summary>
    public event NoopingEventHandler Nooping
    {
      [MethodImpl(MethodImplOptions.Synchronized)] add
      {
        this.Nooping = this.Nooping + value;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] remove
      {
        this.Nooping = this.Nooping - value;
      }
    }

    /// <summary>
    /// Event fired when NOOP command completed.
    /// 
    /// </summary>
    public event NoopedEventHandler Nooped
    {
      [MethodImpl(MethodImplOptions.Synchronized)] add
      {
        this.Nooped = this.Nooped + value;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] remove
      {
        this.Nooped = this.Nooped - value;
      }
    }

    /// <summary>
    /// Event fired when a command is being written to the server.
    /// 
    /// </summary>
    public event TcpWritingEventHandler TcpWriting
    {
      [MethodImpl(MethodImplOptions.Synchronized)] add
      {
        this.TcpWriting = this.TcpWriting + value;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] remove
      {
        this.TcpWriting = this.TcpWriting - value;
      }
    }

    /// <summary>
    /// Event fired when a command has been written to the server.
    /// 
    /// </summary>
    public event TcpWrittenEventHandler TcpWritten
    {
      [MethodImpl(MethodImplOptions.Synchronized)] add
      {
        this.TcpWritten = this.TcpWritten + value;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] remove
      {
        this.TcpWritten = this.TcpWritten - value;
      }
    }

    /// <summary>
    /// Event fired when a response is being read from the server.
    /// 
    /// </summary>
    public event TcpReadingEventHandler TcpReading
    {
      [MethodImpl(MethodImplOptions.Synchronized)] add
      {
        this.TcpReading = this.TcpReading + value;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] remove
      {
        this.TcpReading = this.TcpReading - value;
      }
    }

    /// <summary>
    /// Event fired when a response has been read from the server.
    /// 
    /// </summary>
    public event TcpReadEventHandler TcpRead
    {
      [MethodImpl(MethodImplOptions.Synchronized)] add
      {
        this.TcpRead = this.TcpRead + value;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] remove
      {
        this.TcpRead = this.TcpRead - value;
      }
    }

    /// <summary>
    /// Event fired when a message is being requested using the RetrieveMessage() method.
    /// 
    /// </summary>
    public event MessageRetrievingEventHandler MessageRetrieving
    {
      [MethodImpl(MethodImplOptions.Synchronized)] add
      {
        this.MessageRetrieving = this.MessageRetrieving + value;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] remove
      {
        this.MessageRetrieving = this.MessageRetrieving - value;
      }
    }

    /// <summary>
    /// Event fired when a message is being retrieved using the RetrieveMessage() method.
    /// 
    /// </summary>
    public event MessageRetrievedEventHandler MessageRetrieved
    {
      [MethodImpl(MethodImplOptions.Synchronized)] add
      {
        this.MessageRetrieved = this.MessageRetrieved + value;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] remove
      {
        this.MessageRetrieved = this.MessageRetrieved - value;
      }
    }

    /// <summary>
    /// Event fired when a message Header is being requested using the RetrieveHeader() method.
    /// 
    /// </summary>
    public event HeaderRetrievingEventHandler HeaderRetrieving
    {
      [MethodImpl(MethodImplOptions.Synchronized)] add
      {
        this.HeaderRetrieving = this.HeaderRetrieving + value;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] remove
      {
        this.HeaderRetrieving = this.HeaderRetrieving - value;
      }
    }

    /// <summary>
    /// Event fired when a message Header has been retrieved using the RetrieveHeader() method.
    /// 
    /// </summary>
    public event HeaderRetrievedEventHandler HeaderRetrieved
    {
      [MethodImpl(MethodImplOptions.Synchronized)] add
      {
        this.HeaderRetrieved = this.HeaderRetrieved + value;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] remove
      {
        this.HeaderRetrieved = this.HeaderRetrieved - value;
      }
    }

    /// <summary>
    /// Event fired when attempting to connect to the remote server using the specified host.
    /// 
    /// </summary>
    public event ConnectingEventHandler Connecting
    {
      [MethodImpl(MethodImplOptions.Synchronized)] add
      {
        this.Connecting = this.Connecting + value;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] remove
      {
        this.Connecting = this.Connecting - value;
      }
    }

    /// <summary>
    /// Event fired when the object is connected to the remote server or when connection failed.
    /// 
    /// </summary>
    public event ConnectedEventHandler Connected
    {
      [MethodImpl(MethodImplOptions.Synchronized)] add
      {
        this.Connected = this.Connected + value;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] remove
      {
        this.Connected = this.Connected - value;
      }
    }

    /// <summary>
    /// Event fired when attempting to disconnect from the remote server.
    /// 
    /// </summary>
    public event DisconnectingEventHandler Disconnecting
    {
      [MethodImpl(MethodImplOptions.Synchronized)] add
      {
        this.Disconnecting = this.Disconnecting + value;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] remove
      {
        this.Disconnecting = this.Disconnecting - value;
      }
    }

    /// <summary>
    /// Event fired when the object disconnected from the remote server.
    /// 
    /// </summary>
    public event DisconnectedEventHandler Disconnected
    {
      [MethodImpl(MethodImplOptions.Synchronized)] add
      {
        this.Disconnected = this.Disconnected + value;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] remove
      {
        this.Disconnected = this.Disconnected - value;
      }
    }

    /// <summary>
    /// Event fired when a message is being sent.
    /// 
    /// </summary>
    public event MessageSendingEventHandler MessageSending
    {
      [MethodImpl(MethodImplOptions.Synchronized)] add
      {
        this.MessageSending = this.MessageSending + value;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] remove
      {
        this.MessageSending = this.MessageSending - value;
      }
    }

    /// <summary>
    /// Event fired when a message has been sent.
    /// 
    /// </summary>
    public event MessageSentEventHandler MessageSent
    {
      [MethodImpl(MethodImplOptions.Synchronized)] add
      {
        this.MessageSent = this.MessageSent + value;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] remove
      {
        this.MessageSent = this.MessageSent - value;
      }
    }

    /// <summary>
    /// Event fired when a new message received.
    /// 
    /// </summary>
    public event NewMessageReceivedEventHandler NewMessageReceived
    {
      [MethodImpl(MethodImplOptions.Synchronized)] add
      {
        this.NewMessageReceived = this.NewMessageReceived + value;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] remove
      {
        this.NewMessageReceived = this.NewMessageReceived - value;
      }
    }

    internal void OnAuthenticating(AuthenticatingEventArgs e)
    {
      if (this.Authenticating != null)
        this.Authenticating((object) this, e);
      Logger.AddEntry("Authenticating as " + e.Username + " on " + e.Host + "...", 2);
    }

    internal void OnAuthenticated(AuthenticatedEventArgs e)
    {
      if (this.Authenticated != null)
        this.Authenticated((object) this, e);
      Logger.AddEntry("Authenticated as " + e.Username + " on " + e.Host + ".", 2);
    }

    internal void OnNooping()
    {
      if (this.Nooping != null)
        this.Nooping((object) this);
      Logger.AddEntry("Nooping...", 1);
    }

    internal void OnNooped()
    {
      if (this.Nooped != null)
        this.Nooped((object) this);
      Logger.AddEntry("Nooped.", 1);
    }

    internal void OnTcpWriting(TcpWritingEventArgs e)
    {
      if (this.TcpWriting != null)
        this.TcpWriting((object) this, e);
      Logger.AddEntry("Sending " + e.Command + "...", 1);
    }

    internal void OnTcpWritten(TcpWrittenEventArgs e)
    {
      if (this.TcpWritten != null)
        this.TcpWritten((object) this, e);
      Logger.AddEntry("Sent " + e.Command + ".", 1);
    }

    internal void OnTcpReading()
    {
      if (this.TcpReading != null)
        this.TcpReading((object) this);
      Logger.AddEntry("Reading...", 1);
    }

    internal void OnTcpRead(TcpReadEventArgs e)
    {
      if (this.TcpRead != null)
        this.TcpRead((object) this, e);
      Logger.AddEntry("Read " + e.Response + ".", 1);
    }

    internal void OnMessageRetrieving(MessageRetrievingEventArgs e)
    {
      if (this.MessageRetrieving != null)
        this.MessageRetrieving((object) this, e);
      Logger.AddEntry("Retrieving message at index " + (object) e.MessageIndex + "...", 2);
    }

    internal void OnMessageRetrieved(MessageRetrievedEventArgs e)
    {
      if (this.MessageRetrieved != null)
        this.MessageRetrieved((object) this, e);
      Logger.AddEntry("Retrieved message at index " + (object) e.MessageIndex + ".", 2);
    }

    internal void OnHeaderRetrieving(HeaderRetrievingEventArgs e)
    {
      if (this.HeaderRetrieving != null)
        this.HeaderRetrieving((object) this, e);
      Logger.AddEntry("Retrieving Header at index " + (object) e.MessageIndex + "...", 2);
    }

    internal void OnHeaderRetrieved(HeaderRetrievedEventArgs e)
    {
      if (this.HeaderRetrieved != null)
        this.HeaderRetrieved((object) this, e);
      Logger.AddEntry("Retrieved Header at index " + (object) e.MessageIndex + ".", 2);
    }

    internal void OnDisconnecting()
    {
      if (this.Disconnecting != null)
        this.Disconnecting((object) this);
      Logger.AddEntry("Disconnecting...", 2);
    }

    internal void OnDisconnected(DisconnectedEventArgs e)
    {
      if (this.Disconnected != null)
        this.Disconnected((object) this, e);
      Logger.AddEntry("Disconnected.", 2);
    }

    internal void OnConnecting()
    {
      if (this.Connecting != null)
        this.Connecting((object) this);
      Logger.AddEntry("Connecting...", 2);
    }

    internal void OnConnected(ConnectedEventArgs e)
    {
      if (this.Connected != null)
        this.Connected((object) this, e);
      Logger.AddEntry("Connected. Server replied : " + e.ServerResponse + ".", 2);
    }

    internal void OnMessageSending(MessageSendingEventArgs e)
    {
      if (this.MessageSending != null)
        this.MessageSending((object) this, e);
      Logger.AddEntry("Sending message with subject : " + e.Message.Subject + "...", 2);
    }

    internal void OnMessageSent(MessageSentEventArgs e)
    {
      if (this.MessageSent != null)
        this.MessageSent((object) this, e);
      Logger.AddEntry("Sent message with subject : " + e.Message.Subject + "...", 2);
    }

    internal void OnNewMessageReceived(NewMessageReceivedEventArgs e)
    {
      if (this.NewMessageReceived != null)
        this.NewMessageReceived((object) this, e);
      Logger.AddEntry("New message received : " + (object) e.MessageCount + "...", 2);
    }

    private string _CramMd5(string username, string password)
    {
      this.OnAuthenticating(new AuthenticatingEventArgs(username, password));
      string stamp = DateTime.Now.ToString("yyMMddhhmmss" + DateTime.Now.Millisecond.ToString());
      byte[] bytes = Convert.FromBase64String(this.Command(stamp + " authenticate cram-md5", stamp).Split(new char[1]
      {
        ' '
      })[1].Trim('\r', '\n'));
      string @string = Encoding.ASCII.GetString(bytes, 0, bytes.Length);
      string serverResponse = this.Command(Convert.ToBase64String(Encoding.ASCII.GetBytes(username + " " + Crypto.HMACMD5Digest(password, @string))), stamp);
      this.OnAuthenticated(new AuthenticatedEventArgs(username, password, serverResponse));
      this.Mailboxes = this.GetMailboxes("", "%");
      this.AllMailboxes = this.GetMailboxes("", "*");
      return serverResponse;
    }

    private string _Login(string username, string password)
    {
      this.OnAuthenticating(new AuthenticatingEventArgs(username, password));
      string stamp = DateTime.Now.ToString("yyMMddhhmmss" + DateTime.Now.Millisecond.ToString());
      this.Command("authenticate login");
      this.Command(Convert.ToBase64String(Encoding.ASCII.GetBytes(username)), stamp);
      string serverResponse = this.Command(Convert.ToBase64String(Encoding.ASCII.GetBytes(password)), stamp);
      this.OnAuthenticated(new AuthenticatedEventArgs(username, password, serverResponse));
      this.Mailboxes = this.GetMailboxes("", "%");
      this.AllMailboxes = this.GetMailboxes("", "*");
      return serverResponse;
    }

    private static string FindLine(string[] input, string pattern)
    {
      foreach (string str in input)
      {
        if (str.IndexOf(pattern) != -1)
          return str;
      }
      return "";
    }

    private void DoSslHandShake(SslHandShake sslHandShake)
    {
      this._sslStream = new SslStream((Stream) base.GetStream(), false, sslHandShake.ServerCertificateValidationCallback, sslHandShake.ClientCertificateSelectionCallback);
      bool flag = false;
      try
      {
        this._sslStream.AuthenticateAsClient(sslHandShake.HostName, sslHandShake.ClientCertificates, sslHandShake.SslProtocol, sslHandShake.CheckRevocation);
      }
      catch (Exception ex)
      {
        flag = true;
      }
      if (!flag)
        return;
      ServicePointManager.CertificatePolicy = (ICertificatePolicy) new TrustAllCertificatePolicy();
      this._sslStream.AuthenticateAsClient(sslHandShake.HostName, sslHandShake.ClientCertificates, sslHandShake.SslProtocol, sslHandShake.CheckRevocation);
    }

    private string ReadLine()
    {
      this.OnTcpReading();
      string data = new StreamReader(this.GetStream(), Encoding.ASCII).ReadLine();
      this.OnTcpRead(new TcpReadEventArgs(data));
      return data;
    }

    /// <summary>
    /// Connects to the server.
    /// 
    /// </summary>
    /// <param name="host">Server address.</param>
    /// <returns>
    /// The server's response greeting.
    /// </returns>
    /// 
    /// <example>
    /// 
    /// <code>
    /// C#
    /// 
    ///             Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             ...
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             ...
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             ...
    /// 
    /// </code>
    /// 
    /// </example>
    public string Connect(string host)
    {
      return this.Connect(host, 143);
    }

    /// <summary>
    /// Begins the connect.
    /// 
    /// </summary>
    /// <param name="host">The host.</param><param name="callback">The callback.</param>
    /// <returns/>
    public IAsyncResult BeginConnect(string host, AsyncCallback callback)
    {
      this._delegateConnect = new Imap4Client.DelegateConnect(this.Connect);
      return this._delegateConnect.BeginInvoke(host, 143, callback, (object) this._delegateConnect);
    }

    /// <summary>
    /// Connects to the server.
    /// 
    /// </summary>
    /// <param name="host">Server address.</param><param name="port">Server port.</param>
    /// <returns>
    /// The server's response greeting.
    /// </returns>
    /// 
    /// <example>
    /// 
    /// <code>
    /// C#
    /// 
    ///             Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com",8505);
    ///             ...
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com",8505)
    ///             ...
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com",8505);
    ///             ...
    /// 
    /// </code>
    /// 
    /// </example>
    public string Connect(string host, int port)
    {
      this.host = host;
      this.OnConnecting();
      base.Connect(host, port);
      string serverresponse = new StreamReader((Stream) base.GetStream(), Encoding.ASCII).ReadLine();
      this.ServerCapabilities = this.Command("capability");
      this.OnConnected(new ConnectedEventArgs(serverresponse));
      return serverresponse;
    }

    /// <summary>
    /// Begins the connect.
    /// 
    /// </summary>
    /// <param name="host">The host.</param><param name="port">The port.</param><param name="callback">The callback.</param>
    /// <returns/>
    public IAsyncResult BeginConnect(string host, int port, AsyncCallback callback)
    {
      this._delegateConnect = new Imap4Client.DelegateConnect(this.Connect);
      return this._delegateConnect.BeginInvoke(host, port, callback, (object) this._delegateConnect);
    }

    /// <summary>
    /// Connects the specified addr.
    /// 
    /// </summary>
    /// <param name="addr">The addr.</param><param name="port">The port.</param>
    /// <returns/>
    public string Connect(IPAddress addr, int port)
    {
      this.OnConnecting();
      base.Connect(addr, port);
      string serverresponse = this.ReadLine();
      this.OnConnected(new ConnectedEventArgs(serverresponse));
      return serverresponse;
    }

    /// <summary>
    /// Begins the connect.
    /// 
    /// </summary>
    /// <param name="addr">The addr.</param><param name="port">The port.</param><param name="callback">The callback.</param>
    /// <returns/>
    public IAsyncResult BeginConnect(IPAddress addr, int port, AsyncCallback callback)
    {
      this._delegateConnectIPAddress = new Imap4Client.DelegateConnectIPAddress(this.Connect);
      return this._delegateConnectIPAddress.BeginInvoke(addr, port, callback, (object) this._delegateConnectIPAddress);
    }

    /// <summary>
    /// Connects the specified addresses.
    /// 
    /// </summary>
    /// <param name="addresses">The addresses.</param><param name="port">The port.</param>
    /// <returns/>
    public string Connect(IPAddress[] addresses, int port)
    {
      this.OnConnecting();
      base.Connect(addresses, port);
      string serverresponse = this.ReadLine();
      this.OnConnected(new ConnectedEventArgs(serverresponse));
      return serverresponse;
    }

    public IAsyncResult BeginConnect(IPAddress[] addresses, int port, AsyncCallback callback)
    {
      this._delegateConnectIPAddresses = new Imap4Client.DelegateConnectIPAddresses(this.Connect);
      return this._delegateConnectIPAddresses.BeginInvoke(addresses, port, callback, (object) this._delegateConnectIPAddresses);
    }

    public string Connect(string host, string username, string password)
    {
      return this.Connect(host, 143, username, password);
    }

    /// <summary>
    /// Begins the connect.
    /// 
    /// </summary>
    /// <param name="host">The host.</param><param name="username">The username.</param><param name="password">The password.</param><param name="callback">The callback.</param>
    /// <returns/>
    public IAsyncResult BeginConnect(string host, string username, string password, AsyncCallback callback)
    {
      return this.BeginConnect(host, 143, username, password, callback);
    }

    /// <summary>
    /// Connects the specified host.
    /// 
    /// </summary>
    /// <param name="host">The host.</param><param name="port">The port.</param><param name="username">The username.</param><param name="password">The password.</param>
    /// <returns/>
    public string Connect(string host, int port, string username, string password)
    {
      this.Connect(host, port);
      return this.LoginFast(username, password);
    }

    /// <summary>
    /// Begins the connect.
    /// 
    /// </summary>
    /// <param name="host">The host.</param><param name="port">The port.</param><param name="username">The username.</param><param name="password">The password.</param><param name="callback">The callback.</param>
    /// <returns/>
    public IAsyncResult BeginConnect(string host, int port, string username, string password, AsyncCallback callback)
    {
      this._delegateConnectAuth = new Imap4Client.DelegateConnectAuth(this.Connect);
      return this._delegateConnectAuth.BeginInvoke(host, port, username, password, callback, (object) this._delegateConnectAuth);
    }

    /// <summary>
    /// Ends the connect.
    /// 
    /// </summary>
    /// <param name="result">The result.</param>
    /// <returns/>
    public string EndConnect(IAsyncResult result)
    {
      return (string) result.AsyncState.GetType().GetMethod("EndInvoke").Invoke(result.AsyncState, new object[1]
      {
        (object) result
      });
    }

    public string ConnectSsl(string host)
    {
      return this.ConnectSsl(host, 465, new SslHandShake(host));
    }

    public IAsyncResult BeginConnectSsl(string host, AsyncCallback callback)
    {
      return this.BeginConnectSsl(host, 465, new SslHandShake(host), callback);
    }

    public string ConnectSsl(string host, SslHandShake sslHandShake)
    {
      return this.ConnectSsl(host, 465, sslHandShake);
    }

    public IAsyncResult BeginConnectSsl(string host, SslHandShake sslHandShake, AsyncCallback callback)
    {
      return this.BeginConnectSsl(host, 465, sslHandShake, callback);
    }

    public string ConnectSsl(string host, int port)
    {
      return this.ConnectSsl(host, port, new SslHandShake(host));
    }

    public IAsyncResult BeginConnectSsl(string host, int port, AsyncCallback callback)
    {
      return this.BeginConnectSsl(host, port, new SslHandShake(host), callback);
    }

    public string ConnectSsl(string host, int port, SslHandShake sslHandShake)
    {
      this.OnConnecting();
      base.Connect(host, port);
      this.DoSslHandShake(sslHandShake);
      string serverresponse = this.ReadLine();
      this.OnConnected(new ConnectedEventArgs(serverresponse));
      return serverresponse;
    }

    public IAsyncResult BeginConnectSsl(string host, int port, SslHandShake sslHandShake, AsyncCallback callback)
    {
      this._delegateConnectSsl = new Imap4Client.DelegateConnectSsl(this.ConnectSsl);
      return this._delegateConnectSsl.BeginInvoke(host, port, sslHandShake, callback, (object) this._delegateConnectSsl);
    }

    public string ConnectSsl(IPAddress addr, int port, SslHandShake sslHandShake)
    {
      this.OnConnecting();
      base.Connect(addr, port);
      this.DoSslHandShake(sslHandShake);
      string serverresponse = this.ReadLine();
      this.OnConnected(new ConnectedEventArgs(serverresponse));
      return serverresponse;
    }

    public IAsyncResult BeginConnectSsl(IPAddress addr, int port, SslHandShake sslHandShake, AsyncCallback callback)
    {
      this._delegateConnectSslIPAddress = new Imap4Client.DelegateConnectSslIPAddress(this.ConnectSsl);
      return this._delegateConnectSslIPAddress.BeginInvoke(addr, port, sslHandShake, callback, (object) this._delegateConnectSslIPAddress);
    }

    public string ConnectSsl(IPAddress[] addresses, int port, SslHandShake sslHandShake)
    {
      this.OnConnecting();
      base.Connect(addresses, port);
      this.DoSslHandShake(sslHandShake);
      string serverresponse = this.ReadLine();
      this.OnConnected(new ConnectedEventArgs(serverresponse));
      return serverresponse;
    }

    public IAsyncResult BeginConnectSsl(IPAddress[] addresses, int port, SslHandShake sslHandShake, AsyncCallback callback)
    {
      this._delegateConnectSslIPAddresses = new Imap4Client.DelegateConnectSslIPAddresses(this.ConnectSsl);
      return this._delegateConnectSslIPAddresses.BeginInvoke(addresses, port, sslHandShake, callback, (object) this._delegateConnectSslIPAddresses);
    }

    public string EndConnectSsl(IAsyncResult result)
    {
      return (string) result.AsyncState.GetType().GetMethod("EndInvoke").Invoke(result.AsyncState, new object[1]
      {
        (object) result
      });
    }

    /// <summary>
    /// Logs out and closes the connection with the server.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The server's googbye greeting.
    /// </returns>
    /// 
    /// <example>
    /// 
    /// <code>
    /// C#
    /// 
    ///             Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             //Do some work...
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("jdoe1234","tanstaaf")
    ///             'Do some work...
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             //Do some work...
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public string Disconnect()
    {
      string str = this.Command("logout");
      base.Close();
      return str;
    }

    public IAsyncResult BeginDisconnect(AsyncCallback callback)
    {
      this._delegateDisconnect = new Imap4Client.DelegateDisconnect(this.Disconnect);
      return this._delegateDisconnect.BeginInvoke(callback, (object) null);
    }

    public string EndDisconnect(IAsyncResult result)
    {
      return this._delegateDisconnect.EndInvoke(result);
    }

    /// <summary>
    /// Logs in to the specified account.
    /// 
    /// </summary>
    /// <param name="username">Username of the account.</param><param name="password">Password of the account.</param>
    /// <returns>
    /// The server's response.
    /// </returns>
    /// 
    /// <example>
    /// 
    /// <code>
    /// C#
    /// 
    ///             Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             //Do some work...
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("jdoe1234","tanstaaf")
    ///             'Do some work...
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             //Do some work...
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public string Login(string username, string password)
    {
      this.OnAuthenticating(new AuthenticatingEventArgs(username, password, this.host));
      string serverResponse = this.Command("login " + username + " " + password);
      this.OnAuthenticated(new AuthenticatedEventArgs(username, password, this.host, serverResponse));
      this.Mailboxes = this.GetMailboxes("", "%");
      this.AllMailboxes = this.GetMailboxes("", "*");
      return serverResponse;
    }

    public IAsyncResult BeginLogin(string username, string password, AsyncCallback callback)
    {
      this._delegateLogin = new Imap4Client.DelegateLogin(this.Login);
      return this._delegateLogin.BeginInvoke(username, password, callback, (object) this._delegateLogin);
    }

    /// <summary>
    /// Same as Login but doesn't load the AllMailboxes and Mailboxes properties of the Imap4Client object, ensuring faster operation.
    /// 
    /// </summary>
    /// <param name="username">Username of the account.</param><param name="password">Password of the account.</param>
    /// <returns>
    /// The server's response.
    /// </returns>
    public string LoginFast(string username, string password)
    {
      this.OnAuthenticating(new AuthenticatingEventArgs(username, password, this.host));
      string serverResponse = this.Command("login " + username + " " + password);
      this.OnAuthenticated(new AuthenticatedEventArgs(username, password, this.host, serverResponse));
      return serverResponse;
    }

    public IAsyncResult BeginLoginFast(string username, string password, AsyncCallback callback)
    {
      this._delegateLogin = new Imap4Client.DelegateLogin(this.LoginFast);
      return this._delegateLogin.BeginInvoke(username, password, callback, (object) this._delegateLogin);
    }

    /// <summary>
    /// Authenticates using the given SASL mechanism.
    /// 
    /// </summary>
    /// <param name="username">Username to authenticate as.</param><param name="password">Password.</param><param name="mechanism">SASL mechanism to be used.</param>
    /// <returns>
    /// The server's response.
    /// </returns>
    /// 
    /// <example>
    /// 
    /// <code>
    /// C#
    /// 
    ///             Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Authenticate("user","pass",SASLMechanism.CramMd5);
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Authenticate("user","pass",SASLMechanism.CramMd5)
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Authenticate("user","pass",SASLMechanism.CramMd5);
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public string Authenticate(string username, string password, SaslMechanism mechanism)
    {
      switch (mechanism)
      {
        case SaslMechanism.Login:
          return this._Login(username, password);
        case SaslMechanism.CramMd5:
          return this._CramMd5(username, password);
        default:
          return string.Empty;
      }
    }

    public IAsyncResult BeginAuthenticate(string username, string password, SaslMechanism mechanism, AsyncCallback callback)
    {
      this._delegateAuthenticate = new Imap4Client.DelegateAuthenticate(this.Authenticate);
      return this._delegateAuthenticate.BeginInvoke(username, password, mechanism, callback, (object) null);
    }

    public string EndAuthenticate(IAsyncResult result)
    {
      return this._delegateAuthenticate.EndInvoke(result);
    }

    /// <summary>
    /// Start the idle on the mail server.
    /// 
    /// </summary>
    public void StartIdle()
    {
      this.Command("IDLE");
      StreamReader streamReader = new StreamReader(this.GetStream(), Encoding.ASCII);
      StringBuilder stringBuilder = new StringBuilder();
      string str = string.Empty;
      this._idleInProgress = true;
      while (this._idleInProgress)
      {
        this.OnTcpReading();
        string data = streamReader.ReadLine();
        this.OnTcpRead(new TcpReadEventArgs(data));
        if (data.ToUpper().IndexOf("RECENT") > 0)
          this.OnNewMessageReceived(new NewMessageReceivedEventArgs(int.Parse(data.Split(new char[1]
          {
            ' '
          })[1])));
      }
      this.Command("DONE", string.Empty);
    }

    /// <summary>
    /// Stop the idle on the imap4 server.
    /// 
    /// </summary>
    public void StopIdle()
    {
      this._idleInProgress = false;
    }

    /// <summary>
    /// Sends the command to the server.
    ///             The command tag is automatically added.
    /// 
    /// </summary>
    /// <param name="command">The command (with arguments if necesary) to be sent.</param>
    /// <returns>
    /// The server's response.
    /// </returns>
    /// 
    /// <example>
    /// 
    /// <code>
    /// C#
    /// 
    ///             Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("user","pass");
    ///             imap.Command("select inbox");
    ///             //Selected mailbox is inbox.
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("user","pass")
    ///             imap.Command("select inbox")
    ///             'Selected mailbox is inbox.
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("user","pass");
    ///             imap.Command("select inbox");
    ///             //Selected mailbox is inbox.
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public string Command(string command)
    {
      return this.Command(command, DateTime.Now.ToString("yyMMddhhmmss" + DateTime.Now.Millisecond.ToString()));
    }

    public IAsyncResult BeginCommand(string command, AsyncCallback callback)
    {
      return this.BeginCommand(command, DateTime.Now.ToString("yyMMddhhmmss" + DateTime.Now.Millisecond.ToString()), callback);
    }

    public string Command(string command, string stamp)
    {
      if (command.Length < 200)
        this.OnTcpWriting(new TcpWritingEventArgs(stamp + (stamp.Length > 0 ? " " : "") + command + "\r\n"));
      else
        this.OnTcpWriting(new TcpWritingEventArgs("long command data"));
      if (this._sslStream != null)
        ((Stream) this._sslStream).Write(Encoding.ASCII.GetBytes(stamp + (stamp.Length > 0 ? " " : "") + command + "\r\n\r\n"), 0, stamp.Length + (stamp.Length > 0 ? 1 : 0) + command.Length + 2);
      else
        base.GetStream().Write(Encoding.ASCII.GetBytes(stamp + (stamp.Length > 0 ? " " : "") + command + "\r\n\r\n"), 0, stamp.Length + (stamp.Length > 0 ? 1 : 0) + command.Length + 2);
      if (command.Length < 200)
        this.OnTcpWritten(new TcpWrittenEventArgs(stamp + (stamp.Length > 0 ? " " : "") + command + "\r\n"));
      else
        this.OnTcpWritten(new TcpWrittenEventArgs("long command data"));
      this.OnTcpReading();
      StreamReader streamReader = new StreamReader(this.GetStream(), Encoding.ASCII);
      StringBuilder stringBuilder = new StringBuilder();
      string str1;
      string str2;
      string str3;
      string str4;
      do
      {
        str1 = streamReader.ReadLine();
        Logger.AddEntry("bordel : " + str1);
        stringBuilder.Append(str1 + "\r\n");
        if (command.ToUpper().StartsWith("LIST"))
        {
          if (str1.StartsWith(stamp) || str1.StartsWith("+ "))
          {
            str2 = str1;
            goto label_18;
          }
        }
        else if (command.ToUpper().StartsWith("DONE"))
        {
          str2 = str1;
          stamp = str2.Split(new char[1]
          {
            ' '
          })[0];
          goto label_18;
        }
        else if (!str1.StartsWith(stamp))
        {
          str3 = str1.ToLower();
          str4 = "* " + command.Split(new char[1]
          {
            ' '
          })[0].ToLower();
        }
        else
          break;
      }
      while (!str3.StartsWith(str4) && !str1.StartsWith("+ "));
      str2 = str1;
label_18:
      if (stringBuilder.Length < 200)
        this.OnTcpRead(new TcpReadEventArgs(((object) stringBuilder).ToString()));
      else
        this.OnTcpRead(new TcpReadEventArgs("long data"));
      if (!str2.StartsWith(stamp + " OK"))
      {
        if (!str1.ToLower().StartsWith("* " + command.Split(new char[1]
        {
          ' '
        })[0].ToLower()) && !str1.StartsWith("+ "))
          throw new Imap4Exception("Command \"" + command + "\" failed : " + ((object) stringBuilder).ToString());
      }
      return ((object) stringBuilder).ToString();
    }

    public IAsyncResult BeginCommand(string command, string stamp, AsyncCallback callback)
    {
      this._delegateCommand = new Imap4Client.DelegateCommand(this.Command);
      return this._delegateCommand.BeginInvoke(command, stamp, callback, (object) this._delegateCommand);
    }

    public string Command(string command, string stamp, string checkStamp)
    {
      if (command.Length < 200)
        this.OnTcpWriting(new TcpWritingEventArgs(stamp + (stamp.Length > 0 ? " " : "") + command + "\r\n"));
      else
        this.OnTcpWriting(new TcpWritingEventArgs("long command data"));
      base.GetStream().Write(Encoding.ASCII.GetBytes(stamp + (stamp.Length > 0 ? " " : "") + command + "\r\n"), 0, stamp.Length + (stamp.Length > 0 ? 1 : 0) + command.Length + 2);
      if (command.Length < 200)
        this.OnTcpWritten(new TcpWrittenEventArgs(stamp + (stamp.Length > 0 ? " " : "") + command + "\r\n"));
      else
        this.OnTcpWritten(new TcpWrittenEventArgs("long command data"));
      this.OnTcpReading();
      StreamReader streamReader = new StreamReader((Stream) base.GetStream(), Encoding.ASCII);
      StringBuilder stringBuilder = new StringBuilder();
      string str1;
      string str2;
      string str3;
      do
      {
        str1 = streamReader.ReadLine();
        stringBuilder.Append(str1 + "\r\n");
        if (!str1.StartsWith(checkStamp))
        {
          str2 = str1.ToLower();
          str3 = "* " + command.Split(new char[1]
          {
            ' '
          })[0].ToLower();
        }
        else
          break;
      }
      while (!str2.StartsWith(str3) && !str1.StartsWith("+ "));
      string str4 = str1;
      if (stringBuilder.Length < 200)
        this.OnTcpRead(new TcpReadEventArgs(((object) stringBuilder).ToString()));
      else
        this.OnTcpRead(new TcpReadEventArgs("long data"));
      if (!str4.StartsWith(checkStamp + " OK"))
      {
        if (!str1.ToLower().StartsWith("* " + command.Split(new char[1]
        {
          ' '
        })[0].ToLower()) && !str1.StartsWith("+ "))
          throw new Imap4Exception("Command \"" + command + "\" failed : " + ((object) stringBuilder).ToString());
      }
      return ((object) stringBuilder).ToString();
    }

    public IAsyncResult BeginCommand(string command, string stamp, string checkStamp, AsyncCallback callback)
    {
      this._delegateCommandStringStringString = new Imap4Client.DelegateCommandStringStringString(this.Command);
      return this._delegateCommandStringStringString.BeginInvoke(command, stamp, checkStamp, callback, (object) this._delegateCommandStringStringString);
    }

    public string EndCommand(IAsyncResult result)
    {
      return (string) result.AsyncState.GetType().GetMethod("EndInvoke").Invoke(result.AsyncState, new object[1]
      {
        (object) result
      });
    }

    /// <summary>
    /// Gets the communacation stream of this object.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// A Stream object, either of type NetworkStream or SslStream if the channel is secured.
    /// </returns>
    public Stream GetStream()
    {
      if (this._sslStream != null)
        return (Stream) this._sslStream;
      else
        return (Stream) base.GetStream();
    }

    /// <summary>
    /// Performs a NOOP command which is used to maintain the connection alive.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The server response.
    /// </returns>
    /// 
    /// <remarks>
    /// Some servers include mailbox update informations in the response.
    /// </remarks>
    /// 
    /// <example>
    /// 
    /// <code>
    /// C#
    /// 
    ///             Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             try
    ///             {
    ///             	imap.Noop();
    ///             	imap.Disconnect();
    ///             }
    ///             catch
    ///             {
    ///             	throw new Exception("Connection lost.");
    ///             }
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             Try
    ///             	imap.Noop()
    ///             	imap.Disconnect()
    ///             Catch
    ///             	Throw New Exception("Connection lost.");
    ///             End Try
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             try
    ///             {
    ///             	imap.Noop();
    ///             	imap.Disconnect();
    ///             }
    ///             catch
    ///             {
    ///             	throw new Exception("Connection lost.");
    ///             }
    /// 
    /// </code>
    /// 
    /// </example>
    public string Noop()
    {
      this.OnNooping();
      string str = this.Command("noop");
      this.OnNooped();
      return str;
    }

    public IAsyncResult BeginNoop(AsyncCallback callback)
    {
      this._delegateNoop = new Imap4Client.DelegateNoop(this.Noop);
      return this._delegateNoop.BeginInvoke(callback, (object) this._delegateNoop);
    }

    public string EndNoop(IAsyncResult result)
    {
      return this._delegateNoop.EndInvoke(result);
    }

    /// <summary>
    /// Equivalent to Noop().
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The server's response.
    /// </returns>
    public string Check()
    {
      return this.Command("check");
    }

    public IAsyncResult BeginCheck(AsyncCallback callback)
    {
      this._delegateCheck = new Imap4Client.DelegateCheck(this.Check);
      return this._delegateCheck.BeginInvoke(callback, (object) this._delegateCheck);
    }

    public string EndCheck(IAsyncResult result)
    {
      return this._delegateCheck.EndInvoke(result);
    }

    /// <summary>
    /// Closes the mailbox and removes messages marked with the Deleted flag.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The server's response.
    /// </returns>
    /// 
    /// <example>
    /// 
    /// <code>
    /// C#
    /// 
    ///             Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             Mailbox inbox = imap.SelectInbox("inbox");
    ///             //Get the amount of messages in the inbox.
    ///             int messageCount = inbox.MessageCount;
    ///             inbox.Close();
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("jdoe1234","tanstaaf")
    ///             Dim inbox As Mailbox = imap.SelectInbox("inbox")
    ///             //Get the amount of messages in the inbox.
    ///             Dim messageCount As Integer = inbox.MessageCount
    ///             inbox.Close()
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             var inbox:Mailbox = imap.SelectInbox("inbox");
    ///             //Get the amount of messages in the inbox.
    ///             var messageCount:int = inbox.MessageCount;
    ///             inbox.Close();
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public string Close()
    {
      return this.Command("close");
    }

    public IAsyncResult BeginClose(AsyncCallback callback)
    {
      this._delegateClose = new Imap4Client.DelegateClose(this.Close);
      return this._delegateClose.BeginInvoke(callback, (object) this._delegateClose);
    }

    public string EndClose(IAsyncResult result)
    {
      return this._delegateClose.EndInvoke(result);
    }

    /// <summary>
    /// Removes all messages marked with the Deleted flag.
    /// 
    /// </summary>
    /// 
    /// <example>
    /// 
    /// <code>
    /// C#
    /// 
    ///             Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             Mailbox inbox = imap.SelectInbox("inbox");
    ///             //Mark message 1 for deletion.
    ///             inbox.DeleteMessage(1);
    ///             //Effectively remove all message marked with Deleted flag.
    ///             imap.Expunge();
    ///             //Message 1 is permanently removed.
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("jdoe1234","tanstaaf")
    ///             Dim inbox As Mailbox = imap.SelectInbox("inbox")
    ///             'Mark message 1 for deletion.
    ///             inbox.DeleteMessage(1)
    ///             'Effectively remove all message marked with Deleted flag.
    ///             imap.Expunge()
    ///             'Message 1 is permanently removed.
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             var inbox:Mailbox = imap.SelectInbox("inbox");
    ///             //Mark message 1 for deletion.
    ///             inbox.DeleteMessage(1);
    ///             //Effectively remove all message marked with Deleted flag.
    ///             imap.Expunge();
    ///             //Message 1 is permanently removed.
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public void Expunge()
    {
      this.Command("expunge");
    }

    public IAsyncResult BeginExpunge(AsyncCallback callback)
    {
      this._delegateExpunge = new Imap4Client.DelegateExpunge(this.Expunge);
      return this._delegateExpunge.BeginInvoke(callback, (object) this._delegateExpunge);
    }

    public void EndExpunge(IAsyncResult result)
    {
      this._delegateExpunge.EndInvoke(result);
    }

    /// <summary>
    /// Retrieves a list of mailboxes.
    /// 
    /// </summary>
    /// <param name="reference">The base path.</param><param name="mailboxName">Mailbox name.</param>
    /// <returns>
    /// A MailboxCollection object containing the requested mailboxes.
    /// </returns>
    /// 
    /// <example>
    /// 
    /// <code>
    /// C#
    /// 
    ///             Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("user","pass");
    ///             //Return all children mailboxes of "inbox".
    ///             MailboxCollection mailboxes = imap.GetMailboxes("inbox","*");
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("user","pass")
    ///             'Return all children mailboxes of "inbox".
    ///             Dim mailboxes As MailboxCollection = imap.GetMailboxes("inbox","*")
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("user","pass");
    ///             //Return all children mailboxes of "inbox".
    ///             var mailboxes:MailboxCollection  = imap.GetMailboxes("inbox","*");
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public MailboxCollection GetMailboxes(string reference, string mailboxName)
    {
      MailboxCollection mailboxCollection = new MailboxCollection();
      string[] strArray = Regex.Split(this.Command("list \"" + reference + "\" \"" + mailboxName + "\""), "\r\n");
      for (int index = 0; index < strArray.Length - 2; ++index)
      {
        try
        {
          string mailboxName1 = strArray[index].Substring(strArray[index].IndexOf("\" ") + 1).Trim(' ', '"');
          if (mailboxName1 != reference)
            mailboxCollection.Add(this.ExamineMailbox(mailboxName1));
        }
        catch
        {
        }
      }
      return mailboxCollection;
    }

    public IAsyncResult BeginGetMailboxes(string reference, string mailboxName, AsyncCallback callback)
    {
      this._delegateGetMailboxes = new Imap4Client.DelegateGetMailboxes(this.GetMailboxes);
      return this._delegateGetMailboxes.BeginInvoke(reference, mailboxName, callback, (object) this._delegateGetMailboxes);
    }

    public MailboxCollection EndGetMailboxes(IAsyncResult result)
    {
      return this._delegateGetMailboxes.EndInvoke(result);
    }

    /// <summary>
    /// Fills in or refreshes the Imap4Client.AllMailboxes and Imap4Client.Mailboxes properties.
    /// 
    /// </summary>
    public void LoadMailboxes()
    {
      this.Mailboxes = this.GetMailboxes("", "%");
      this.AllMailboxes = this.GetMailboxes("", "*");
    }

    public IAsyncResult BeginLoadMailboxes(AsyncCallback callback)
    {
      this._delegateLoadMailboxes = new Imap4Client.DelegateLoadMailboxes(this.LoadMailboxes);
      return this._delegateLoadMailboxes.BeginInvoke(callback, (object) this._delegateLoadMailboxes);
    }

    public void EndLoadMailboxes(IAsyncResult result)
    {
      this._delegateLoadMailboxes.EndInvoke(result);
    }

    /// <summary>
    /// Creates a mailbox with the specified name.
    /// 
    /// </summary>
    /// <param name="mailboxName">The name of the new mailbox.</param>
    /// <returns>
    /// The newly created mailbox.
    /// </returns>
    /// 
    /// <example>
    /// 
    /// <code>
    /// C#
    /// 
    ///             Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("user","pass");
    ///             imap.CreateMailbox("inbox.Staff");
    ///             //Child mailbox of inbox named Staff has been created.
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("user","pass")
    ///             imap.CreateMailbox("inbox.Staff");
    ///             'Child mailbox of inbox named Staff has been created.
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("user","pass");
    ///             imap.CreateMailbox("inbox.Staff");
    ///             //Child mailbox of inbox named Staff has been created.
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public Mailbox CreateMailbox(string mailboxName)
    {
      this.Command("create \"" + mailboxName + "\"");
      return this.SelectMailbox(mailboxName);
    }

    public IAsyncResult BeginCreateMailbox(string mailboxName, AsyncCallback callback)
    {
      this._delegateMailboxOperation = new Imap4Client.DelegateMailboxOperation(this.CreateMailbox);
      return this._delegateMailboxOperation.BeginInvoke(mailboxName, callback, (object) this._delegateMailboxOperation);
    }

    public Mailbox EndCreateMailbox(IAsyncResult result)
    {
      return this._delegateMailboxOperation.EndInvoke(result);
    }

    /// <summary>
    /// Renames a mailbox.
    /// 
    /// </summary>
    /// <param name="oldMailboxName">The mailbox to be renamed.</param><param name="newMailboxName">The new name of the mailbox.</param>
    /// <returns>
    /// The server's response.
    /// </returns>
    /// 
    /// <example>
    /// 
    /// <code>
    /// C#
    /// 
    ///             Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("user","pass");
    ///             imap.RenameMailbox("inbox.Staff","Staff");
    ///             //The Staff mailbox is now a top-level mailbox.
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("user","pass")
    ///             imap.RenameMailbox("inbox.Staff","Staff");
    ///             'The Staff mailbox is now a top-level mailbox.
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("user","pass");
    ///             imap.RenameMailbox("inbox.Staff","Staff");
    ///             //The Staff mailbox is now a top-level mailbox.
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public string RenameMailbox(string oldMailboxName, string newMailboxName)
    {
      return this.Command("rename \"" + oldMailboxName + "\" \"" + newMailboxName + "\"");
    }

    public IAsyncResult BeginRenameMailbox(string oldMailboxName, string newMailboxName, AsyncCallback callback)
    {
      this._delegateRenameMailbox = new Imap4Client.DelegateRenameMailbox(this.RenameMailbox);
      return this._delegateRenameMailbox.BeginInvoke(oldMailboxName, newMailboxName, callback, (object) this._delegateRenameMailbox);
    }

    public void EndRenameMailbox(IAsyncResult result)
    {
      this._delegateRenameMailbox.EndInvoke(result);
    }

    /// <summary>
    /// Deletes a mailbox.
    /// 
    /// </summary>
    /// <param name="mailboxName">The mailbox to be deleted.</param>
    /// <returns>
    /// The server's response.
    /// </returns>
    /// 
    /// <example>
    /// 
    /// <code>
    /// C#
    /// 
    ///             Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("user","pass");
    ///             imap.DeleteMailbox("inbox.Staff");
    ///             //The inbox.Staff mailbox is now deleted.
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("user","pass")
    ///             imap.DeleteMailbox("inbox.Staff");
    ///             //The inbox.Staff mailbox is now deleted.
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("user","pass");
    ///             imap.DeleteMailbox("inbox.Staff");
    ///             //The inbox.Staff mailbox is now deleted.
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public string DeleteMailbox(string mailboxName)
    {
      return this.Command("delete \"" + mailboxName + "\"");
    }

    public IAsyncResult BeginDeleteMailbox(string mailboxName, AsyncCallback callback)
    {
      this._delegateMailboxOperationReturnsString = new Imap4Client.DelegateMailboxOperationReturnsString(this.DeleteMailbox);
      return this._delegateMailboxOperationReturnsString.BeginInvoke(mailboxName, callback, (object) this._delegateMailboxOperationReturnsString);
    }

    public string EndDeleteMailbox(IAsyncResult result)
    {
      return this._delegateMailboxOperationReturnsString.EndInvoke(result);
    }

    /// <summary>
    /// Subscribes to a mailbox.
    /// 
    /// </summary>
    /// <param name="mailboxName">The mailbox to be subscribed to.</param>
    /// <returns>
    /// The server's response.
    /// </returns>
    public string SubscribeMailbox(string mailboxName)
    {
      return this.Command("subscribe \"" + mailboxName + "\"");
    }

    public IAsyncResult BeginSubscribeMailbox(string mailboxName, AsyncCallback callback)
    {
      this._delegateMailboxOperationReturnsString = new Imap4Client.DelegateMailboxOperationReturnsString(this.SubscribeMailbox);
      return this._delegateMailboxOperationReturnsString.BeginInvoke(mailboxName, callback, (object) this._delegateMailboxOperationReturnsString);
    }

    public void EndSubscribeMailbox(IAsyncResult result)
    {
      this._delegateMailboxOperationReturnsString.EndInvoke(result);
    }

    /// <summary>
    /// Unsubscribes from a mailbox.
    /// 
    /// </summary>
    /// <param name="mailboxName">The mailbox to be unsubscribed from.</param>
    /// <returns>
    /// The server's response.
    /// </returns>
    public string UnsubscribeMailbox(string mailboxName)
    {
      return this.Command("unsubscribe \"" + mailboxName + "\"");
    }

    public IAsyncResult BeginUnsubscribeMailbox(string mailboxName, AsyncCallback callback)
    {
      this._delegateMailboxOperationReturnsString = new Imap4Client.DelegateMailboxOperationReturnsString(this.UnsubscribeMailbox);
      return this._delegateMailboxOperationReturnsString.BeginInvoke(mailboxName, callback, (object) this._delegateMailboxOperationReturnsString);
    }

    public void EndUnsubscribeMailbox(IAsyncResult result)
    {
      this._delegateMailboxOperationReturnsString.EndInvoke(result);
    }

    /// <summary>
    /// Selects a mailbox on the server.
    /// 
    /// </summary>
    /// <param name="mailboxName">The mailbox to be selected.</param>
    /// <returns>
    /// The selected mailbox.
    /// </returns>
    /// 
    /// <example>
    /// 
    /// <code>
    /// C#
    /// 
    ///             Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("user","pass");
    ///             Mailbox mbox = imap.SelectMailbox("inbox.Staff");
    ///             //The inbox.Staff mailbox is now selected.
    ///             mbox.Empty(true);
    ///             //Mailbox inbox.Staff is now empty.
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("user","pass")
    ///             Dim mbox As Mailbox = imap.SelectMailbox("inbox.Staff")
    ///             'The inbox.Staff mailbox is now selected.
    ///             mbox.Empty(true)
    ///             'Mailbox inbox.Staff is now empty.
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("user","pass");
    ///             var mbox:Mailbox = imap.SelectMailbox("inbox.Staff");
    ///             //The inbox.Staff mailbox is now selected.
    ///             mbox.Empty(true);
    ///             //Mailbox inbox.Staff is now empty.
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public Mailbox SelectMailbox(string mailboxName)
    {
      Mailbox mailbox = new Mailbox();
      mailbox.SubMailboxes = this.GetMailboxes(mailboxName, "*");
      string input1 = this.Command("select \"" + mailboxName + "\"");
      string[] input2 = Regex.Split(input1, "\r\n");
      int num1 = 0;
      try
      {
        num1 = Convert.ToInt32(Imap4Client.FindLine(input2, "EXISTS").Split(new char[1]
        {
          ' '
        })[1]);
      }
      catch (Exception ex)
      {
      }
      mailbox.MessageCount = num1;
      int num2 = 0;
      try
      {
        num2 = Convert.ToInt32(Imap4Client.FindLine(input2, "RECENT").Split(new char[1]
        {
          ' '
        })[1]);
      }
      catch (Exception ex)
      {
      }
      mailbox.Recent = num2;
      int num3 = 0;
      try
      {
        num3 = Convert.ToInt32(Imap4Client.FindLine(input2, "[UNSEEN ").Split(new char[1]
        {
          ' '
        })[3].TrimEnd(new char[1]
        {
          ']'
        }));
      }
      catch (Exception ex)
      {
      }
      mailbox.FirstUnseen = input1.ToLower().IndexOf("[unseen") != -1 ? num3 : 0;
      int num4 = 0;
      try
      {
        num4 = Convert.ToInt32(Imap4Client.FindLine(input2, "[UIDVALIDITY ").Split(new char[1]
        {
          ' '
        })[3].TrimEnd(new char[1]
        {
          ']'
        }));
      }
      catch (Exception ex)
      {
      }
      mailbox.UidValidity = num4;
      string line1 = Imap4Client.FindLine(input2, " FLAGS");
      char[] chArray1 = new char[1]
      {
        ' '
      };
      foreach (string str in line1.Split(chArray1))
      {
        if (str.StartsWith("(\\") || str.StartsWith("\\"))
          mailbox.ApplicableFlags.Add(str.Trim(' ', '\\', ')', '('));
      }
      if (input1.ToLower().IndexOf("[permanentflags") != -1)
      {
        string line2 = Imap4Client.FindLine(input2, "[PERMANENTFLAGS");
        char[] chArray2 = new char[1]
        {
          ' '
        };
        foreach (string str in line2.Split(chArray2))
        {
          if (str.StartsWith("(\\") || str.StartsWith("\\"))
            mailbox.PermanentFlags.Add(str.Trim(' ', '\\', ')', '('));
        }
      }
      if (input1.ToLower().IndexOf("[read-write]") != -1)
        mailbox.Permission = MailboxPermission.ReadWrite;
      else if (input1.ToLower().IndexOf("[read-only]") != -1)
        mailbox.Permission = MailboxPermission.ReadOnly;
      mailbox.Name = mailboxName;
      mailbox.SourceClient = this;
      return mailbox;
    }

    public IAsyncResult BeginSelectMailbox(string mailboxName, AsyncCallback callback)
    {
      this._delegateMailboxOperation = new Imap4Client.DelegateMailboxOperation(this.SelectMailbox);
      return this._delegateMailboxOperation.BeginInvoke(mailboxName, callback, (object) this._delegateMailboxOperation);
    }

    public Mailbox EndSelectMailbox(IAsyncResult result)
    {
      return this._delegateMailboxOperation.EndInvoke(result);
    }

    /// <summary>
    /// Same as SelectMailbox() except that the mailbox is opened with read-only permission.
    /// 
    /// </summary>
    /// <param name="mailboxName">The mailbox to be examined.</param>
    /// <returns>
    /// The examined mailbox.
    /// </returns>
    /// 
    /// <example>
    /// 
    /// <code>
    /// C#
    /// 
    ///             Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("user","pass");
    ///             Mailbox mbox = imap.ExamineMailbox("inbox.Staff");
    ///             //The inbox.Staff mailbox is now selected (read-only).
    ///             int recentMessageCount = mbox.Recent;
    ///             //There are recentMessageCount messages that haven't been read in inbox.Staff.
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("user","pass")
    ///             Dim mbox As Mailbox = imap.ExamineMailbox("inbox.Staff")
    ///             'The inbox.Staff mailbox is now selected (read-only).
    ///             Dim recentMessageCount As Integer = mbox.Recent
    ///             'There are recentMessageCount messages that haven't been read in inbox.Staff.
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("user","pass");
    ///             var mbox:Mailbox = imap.ExamineMailbox("inbox.Staff");
    ///             //The inbox.Staff mailbox is now selected (read-only).
    ///             int recentMessageCount = mbox.Recent;
    ///             //There are recentMessageCount messages that haven't been read in inbox.Staff.
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public Mailbox ExamineMailbox(string mailboxName)
    {
      Mailbox mailbox1 = new Mailbox();
      mailbox1.SubMailboxes = this.GetMailboxes(mailboxName, "*");
      string input1 = this.Command("examine \"" + mailboxName + "\"");
      string[] input2 = Regex.Split(input1, "\r\n");
      mailbox1.MessageCount = Convert.ToInt32(Imap4Client.FindLine(input2, "EXISTS").Split(new char[1]
      {
        ' '
      })[1]);
      mailbox1.Recent = Convert.ToInt32(Imap4Client.FindLine(input2, "RECENT").Split(new char[1]
      {
        ' '
      })[1]);
      Mailbox mailbox2 = mailbox1;
      int num;
      if (input1.ToLower().IndexOf("[unseen") == -1)
        num = 0;
      else
        num = Convert.ToInt32(Imap4Client.FindLine(input2, "[UNSEEN ").Split(new char[1]
        {
          ' '
        })[3].TrimEnd(new char[1]
        {
          ']'
        }));
      mailbox2.FirstUnseen = num;
      mailbox1.UidValidity = Convert.ToInt32(Imap4Client.FindLine(input2, "[UIDVALIDITY ").Split(new char[1]
      {
        ' '
      })[3].TrimEnd(new char[1]
      {
        ']'
      }));
      string line1 = Imap4Client.FindLine(input2, " FLAGS");
      char[] chArray1 = new char[1]
      {
        ' '
      };
      foreach (string str in line1.Split(chArray1))
      {
        if (str.StartsWith("(\\") || str.StartsWith("\\"))
          mailbox1.ApplicableFlags.Add(str.Trim(' ', '\\', ')', '('));
      }
      if (input1.ToLower().IndexOf("[permanentflags") != -1)
      {
        string line2 = Imap4Client.FindLine(input2, "[PERMANENTFLAGS");
        char[] chArray2 = new char[1]
        {
          ' '
        };
        foreach (string str in line2.Split(chArray2))
        {
          if (str.StartsWith("(\\") || str.StartsWith("\\"))
            mailbox1.PermanentFlags.Add(str.Trim(' ', '\\', ')', '('));
        }
      }
      mailbox1.Permission = MailboxPermission.ReadOnly;
      mailbox1.Name = mailboxName;
      mailbox1.SourceClient = this;
      return mailbox1;
    }

    public IAsyncResult BeginExamineMailbox(string mailboxName, AsyncCallback callback)
    {
      this._delegateMailboxOperation = new Imap4Client.DelegateMailboxOperation(this.ExamineMailbox);
      return this._delegateMailboxOperation.BeginInvoke(mailboxName, callback, (object) this._delegateMailboxOperation);
    }

    public Mailbox EndExamineMailbox(IAsyncResult result)
    {
      return this._delegateMailboxOperation.EndInvoke(result);
    }

    private delegate string DelegateConnect(string host, int port);

    private delegate string DelegateConnectAuth(string host, int port, string username, string password);

    private delegate string DelegateConnectIPAddress(IPAddress addr, int port);

    private delegate string DelegateConnectIPAddresses(IPAddress[] addresses, int port);

    private delegate string DelegateConnectSsl(string host, int port, SslHandShake sslHandShake);

    private delegate string DelegateConnectSslIPAddress(IPAddress addr, int port, SslHandShake sslHandShake);

    private delegate string DelegateConnectSslIPAddresses(IPAddress[] addresses, int port, SslHandShake sslHandShake);

    private delegate string DelegateDisconnect();

    private delegate string DelegateAuthenticate(string username, string password, SaslMechanism mechanism);

    private delegate string DelegateLogin(string username, string password);

    private delegate string DelegateCommand(string command, string stamp);

    private delegate string DelegateCommandStringStringString(string command, string stamp, string checkStamp);

    private delegate string DelegateNoop();

    private delegate string DelegateCheck();

    private delegate string DelegateClose();

    private delegate void DelegateExpunge();

    private delegate void DelegateLoadMailboxes();

    private delegate Mailbox DelegateMailboxOperation(string mailboxName);

    private delegate string DelegateRenameMailbox(string oldMailboxName, string newMailboxName);

    private delegate string DelegateMailboxOperationReturnsString(string mailboxName);

    private delegate MailboxCollection DelegateGetMailboxes(string reference, string mailboxName);
  }
}
