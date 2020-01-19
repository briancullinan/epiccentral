// Type: ActiveUp.Net.Mail.Mailbox
// Assembly: ActiveUp.Net.Imap4, Version=5.0.3454.364, Culture=neutral, PublicKeyToken=9d424b1770e92b68
// Assembly location: C:\EPICSource\developer1_ARIZONA21\EPIC Website\EPICCentral\3rdPartyLibraries\ActiveUp.Net.Imap4.dll

using System;
using System.Net.Sockets;
using System.Text;

namespace ActiveUp.Net.Mail
{
  /// <summary>
  /// Represents a mailbox.
  /// 
  /// </summary>
  [Serializable]
  public class Mailbox : IMailbox
  {
    private FlagCollection _applicableFlags = new FlagCollection();
    private FlagCollection _permanentFlags = new FlagCollection();
    private MailboxPermission _permission = MailboxPermission.Unknown;
    private MailboxCollection _subMailboxes = new MailboxCollection();
    private Fetch _fetcher = new Fetch();
    private string _name;
    private Imap4Client _imap;
    private int _recent;
    private int _messageCount;
    private int _unseen;
    private int _uidvalidity;
    private Mailbox.DelegateCreateChild _delegateCreateChild;
    private Mailbox.DelegateSubscribe _delegateSubscribe;
    private Mailbox.DelegateUnsubscribe _delegateUnsubscribe;
    private Mailbox.DelegateDelete _delegateDelete;
    private Mailbox.DelegateRename _delegateRename;
    private Mailbox.DelegateSearch _delegateSearch;
    private Mailbox.DelegateSearchParse _delegateSearchParse;
    private Mailbox.DelegateSearchStringString _delegateSearchStringString;
    private Mailbox.DelegateSearchParseStringString _delegateSearchParseStringString;
    private Mailbox.DelegateAddFlags _delegateAddFlags;
    private Mailbox.DelegateUidAddFlags _delegateUidAddFlags;
    private Mailbox.DelegateRemoveFlags _delegateRemoveFlags;
    private Mailbox.DelegateUidRemoveFlags _delegateUidRemoveFlags;
    private Mailbox.DelegateSetFlags _delegateSetFlags;
    private Mailbox.DelegateUidSetFlags _delegateUidSetFlags;
    private Mailbox.DelegateAddFlagsSilent _delegateAddFlagsSilent;
    private Mailbox.DelegateUidAddFlagsSilent _delegateUidAddFlagsSilent;
    private Mailbox.DelegateRemoveFlagsSilent _delegateRemoveFlagsSilent;
    private Mailbox.DelegateUidRemoveFlagsSilent _delegateUidRemoveFlagsSilent;
    private Mailbox.DelegateSetFlagsSilent _delegateSetFlagsSilent;
    private Mailbox.DelegateUidSetFlagsSilent _delegateUidSetFlagsSilent;
    private Mailbox.DelegateCopyMessage _delegateCopyMessage;
    private Mailbox.DelegateUidCopyMessage _delegateUidCopyMessage;
    private Mailbox.DelegateMoveMessage _delegateMoveMessage;
    private Mailbox.DelegateUidMoveMessage _delegateUidMoveMessage;
    private Mailbox.DelegateAppend _delegateAppend;
    private Mailbox.DelegateAppendFlags _delegateAppendFlags;
    private Mailbox.DelegateAppendFlagsDateTime _delegateAppendFlagsDateTime;
    private Mailbox.DelegateAppendMessage _delegateAppendMessage;
    private Mailbox.DelegateAppendMessageFlags _delegateAppendMessageFlags;
    private Mailbox.DelegateAppendMessageFlagsDateTime _delegateAppendMessageFlagsDateTime;
    private Mailbox.DelegateAppendByte _delegateAppendByte;
    private Mailbox.DelegateAppendByteFlags _delegateAppendByteFlags;
    private Mailbox.DelegateAppendByteFlagsDateTime _delegateAppendByteFlagsDateTime;
    private Mailbox.DelegateEmpty _delegateEmpty;
    private Mailbox.DelegateDeleteMessage _delegateDeleteMessage;
    private Mailbox.DelegateUidDeleteMessage _delegateUidDeleteMessage;

    /// <summary>
    /// The Imap4Client object that will be used to perform commands on the server.
    /// 
    /// </summary>
    public Imap4Client SourceClient
    {
      get
      {
        return this._imap;
      }
      set
      {
        this._imap = value;
      }
    }

    /// <summary>
    /// The full (hierarchical) name of the mailbox.
    /// 
    /// </summary>
    public string Name
    {
      get
      {
        return this._name;
      }
      set
      {
        this._name = value;
      }
    }

    /// <summary>
    /// The name of the mailbox, without hierarchy.
    /// 
    /// </summary>
    public string ShortName
    {
      get
      {
        return this._name.Substring(this._name.LastIndexOf("/") + 1);
      }
    }

    /// <summary>
    /// The amount of recent messages (messages that have been added since this mailbox was last checked).
    /// 
    /// </summary>
    public int Recent
    {
      get
      {
        return this._recent;
      }
      set
      {
        this._recent = value;
      }
    }

    /// <summary>
    /// The amount of messages in the mailbox.
    /// 
    /// </summary>
    public int MessageCount
    {
      get
      {
        return this._messageCount;
      }
      set
      {
        this._messageCount = value;
      }
    }

    /// <summary>
    /// The ordinal position of the first unseen message in the mailbox.
    /// 
    /// </summary>
    public int FirstUnseen
    {
      get
      {
        return this._unseen;
      }
      set
      {
        this._unseen = value;
      }
    }

    /// <summary>
    /// The Uid Validity number. This number allows to check if Unique Identifiers have changed since the mailbox was last checked.
    /// 
    /// </summary>
    public int UidValidity
    {
      get
      {
        return this._uidvalidity;
      }
      set
      {
        this._uidvalidity = value;
      }
    }

    /// <summary>
    /// Flags that are applicable in this mailbox.
    /// 
    /// </summary>
    public FlagCollection ApplicableFlags
    {
      get
      {
        return this._applicableFlags;
      }
      set
      {
        this._applicableFlags = value;
      }
    }

    /// <summary>
    /// Flags that the client can permanently set in this mailbox.
    /// 
    /// </summary>
    public FlagCollection PermanentFlags
    {
      get
      {
        return this._permanentFlags;
      }
      set
      {
        this._permanentFlags = value;
      }
    }

    /// <summary>
    /// The mailbox's permission (ReadWrite or ReadOnly)
    /// 
    /// </summary>
    public MailboxPermission Permission
    {
      get
      {
        return this._permission;
      }
      set
      {
        this._permission = value;
      }
    }

    /// <summary>
    /// The mailbox's child mailboxes.
    /// 
    /// </summary>
    public MailboxCollection SubMailboxes
    {
      get
      {
        return this._subMailboxes;
      }
      set
      {
        this._subMailboxes = value;
      }
    }

    /// <summary>
    /// The mailbox's fetching utility.
    /// 
    /// </summary>
    public Fetch Fetch
    {
      get
      {
        return this._fetcher;
      }
      set
      {
        this._fetcher = value;
      }
    }

    /// <summary>
    /// Default constructor.
    /// 
    /// </summary>
    public Mailbox()
    {
      this.Fetch.ParentMailbox = this;
    }

    /// <summary>
    /// Creates a child mailbox.
    /// 
    /// </summary>
    /// <param name="mailboxName">The name of the child mailbox to be created.</param>
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
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             Mailbox inbox = imap.SelectInbox("inbox");
    ///             Mailbox staff = inbox.CreateChild("Staff");
    ///             int zero = staff.MessageCount
    ///             //Returns 0.
    ///             inbox.Close();
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("jdoe1234","tanstaaf")
    ///             Dim inbox As Mailbox = imap.SelectInbox("inbox")
    ///             Dim staff As Mailbox = inbox.CreateChild("Staff")
    ///             Dim zero As Integer = staff.MessageCount
    ///             'Returns 0.
    ///             inbox.Close()
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             var inbox:Mailbox = imap.SelectInbox("inbox");
    ///             var staff:Mailbox = inbox.CreateChild("Staff");
    ///             var zero:int = staff.MessageCount
    ///             //Returns 0.
    ///             inbox.Close();
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public IMailbox CreateChild(string mailboxName)
    {
      try
      {
        return (IMailbox) this.SourceClient.CreateMailbox(this.Name + this.SourceClient.Command("list \"\" \"\"").Split(new char[1]
        {
          '"'
        })[1].Split(new char[1]
        {
          '"'
        })[0] + mailboxName);
      }
      catch (SocketException ex)
      {
        throw new Imap4Exception("CreateChild failed.\nThe mailbox' source client wasn't connected anymore.");
      }
    }

    public IAsyncResult BeginCreateChild(string mailboxName, AsyncCallback callback)
    {
      this._delegateCreateChild = new Mailbox.DelegateCreateChild(this.CreateChild);
      return this._delegateCreateChild.BeginInvoke(mailboxName, callback, (object) this._delegateCreateChild);
    }

    public IMailbox EndCreateChild(IAsyncResult result)
    {
      return this._delegateCreateChild.EndInvoke(result);
    }

    /// <summary>
    /// Subscribes to the mailbox.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The server's response.
    /// </returns>
    public string Subscribe()
    {
      try
      {
        return this.SourceClient.SubscribeMailbox(this.Name);
      }
      catch (SocketException ex)
      {
        throw new Imap4Exception("Subscribe failed.\nThe mailbox' source client wasn't connected anymore.");
      }
    }

    public IAsyncResult BeginSubscribe(AsyncCallback callback)
    {
      this._delegateSubscribe = new Mailbox.DelegateSubscribe(this.Subscribe);
      return this._delegateSubscribe.BeginInvoke(callback, (object) this._delegateSubscribe);
    }

    public string EndSubscribe(IAsyncResult result)
    {
      return this._delegateSubscribe.EndInvoke(result);
    }

    /// <summary>
    /// Unsubscribes from the mailbox.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The server's response.
    /// </returns>
    public string Unsubscribe()
    {
      try
      {
        return this.SourceClient.UnsubscribeMailbox(this.Name);
      }
      catch (SocketException ex)
      {
        throw new Imap4Exception("Unsubscribe failed.\nThe mailbox' source client wasn't connected anymore.");
      }
    }

    public IAsyncResult BeginUnsubscribe(AsyncCallback callback)
    {
      this._delegateUnsubscribe = new Mailbox.DelegateUnsubscribe(this.Unsubscribe);
      return this._delegateUnsubscribe.BeginInvoke(callback, (object) this._delegateUnsubscribe);
    }

    public string EndUnsubscribe(IAsyncResult result)
    {
      return this._delegateUnsubscribe.EndInvoke(result);
    }

    /// <summary>
    /// Deletes the mailbox.
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
    ///             inbox.Delete();
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("jdoe1234","tanstaaf")
    ///             Dim inbox As Mailbox = imap.SelectInbox("inbox")
    ///             inbox.Delete()
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             var inbox:Mailbox = imap.SelectInbox("inbox");
    ///             inbox.Delete();
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public string Delete()
    {
      try
      {
        return this.SourceClient.DeleteMailbox(this.Name);
      }
      catch (SocketException ex)
      {
        throw new Imap4Exception("Delete failed.\nThe mailbox' source client wasn't connected anymore.");
      }
    }

    public IAsyncResult BeginDelete(AsyncCallback callback)
    {
      this._delegateDelete = new Mailbox.DelegateDelete(this.Delete);
      return this._delegateDelete.BeginInvoke(callback, (object) this._delegateDelete);
    }

    public string EndDelete(IAsyncResult result)
    {
      return this._delegateDelete.EndInvoke(result);
    }

    /// <summary>
    /// Renames the mailbox.
    /// 
    /// </summary>
    /// <param name="newMailboxName">The new name of the mailbox.</param>
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
    ///             Mailbox inbox = imap.SelectInbox("invox");
    ///             inbox.Rename("inbox");
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("jdoe1234","tanstaaf")
    ///             Dim inbox As Mailbox = imap.SelectInbox("invox")
    ///             inbox.Rename("inbox")
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             var inbox:Mailbox = imap.SelectInbox("invox");
    ///             inbox.Rename("inbox");
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public string Rename(string newMailboxName)
    {
      try
      {
        string str = this.SourceClient.RenameMailbox(this.Name, newMailboxName);
        this.Name = newMailboxName;
        return str;
      }
      catch (SocketException ex)
      {
        throw new Imap4Exception("Rename failed.\nThe mailbox' source client wasn't connected anymore.");
      }
    }

    public IAsyncResult BeginRename(string newMailboxName, AsyncCallback callback)
    {
      this._delegateRename = new Mailbox.DelegateRename(this.Rename);
      return this._delegateRename.BeginInvoke(newMailboxName, callback, (object) this._delegateRename);
    }

    public string EndRename(IAsyncResult result)
    {
      return this._delegateRename.EndInvoke(result);
    }

    /// <summary>
    /// Searches the mailbox for messages corresponding to the query.
    /// 
    /// </summary>
    /// <param name="query">Query to use.</param>
    /// <returns>
    /// An array of integers containing ordinal positions of messages matching the query.
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
    ///             int[] ids = inbox.Search("SEARCH FLAGGED SINCE 1-Feb-1994 NOT FROM "Smith");
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("jdoe1234","tanstaaf")
    ///             Dim inbox As Mailbox = imap.SelectInbox("inbox")
    ///             Dim ids() As Integer = inbox.Search("SEARCH FLAGGED SINCE 1-Feb-1994 NOT FROM "Smith")
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             var inbox:Mailbox = imap.SelectInbox("inbox");
    ///             var ids:int[] = inbox.Search("SEARCH FLAGGED SINCE 1-Feb-1994 NOT FROM "Smith");
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public int[] Search(string query)
    {
      string str = this.SourceClient.Command("search " + query);
      string[] strArray = str.Substring(0, str.IndexOf("\r\n")).Split(new char[1]
      {
        ' '
      });
      int[] numArray = new int[strArray.Length - 2];
      for (int index = 2; index < strArray.Length; ++index)
        numArray[index - 2] = Convert.ToInt32(strArray[index]);
      return numArray;
    }

    public IAsyncResult BeginSearch(string query, AsyncCallback callback)
    {
      this._delegateSearch = new Mailbox.DelegateSearch(this.Search);
      return this._delegateSearch.BeginInvoke(query, callback, (object) this._delegateSearch);
    }

    /// <summary>
    /// Search for messages accoridng to the given query.
    /// 
    /// </summary>
    /// <param name="query">Query to use.</param>
    /// <returns>
    /// A collection of messages matching the query.
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
    ///             MessageCollection messages = inbox.SearchParse("SEARCH FLAGGED SINCE 1-Feb-1994 NOT FROM "Smith");
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("jdoe1234","tanstaaf")
    ///             Dim inbox As Mailbox = imap.SelectInbox("inbox")
    ///             Dim messages As MessageCollection = inbox.SearchParse("SEARCH FLAGGED SINCE 1-Feb-1994 NOT FROM "Smith")
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             var inbox:Mailbox = imap.SelectInbox("inbox");
    ///             var messages:MessageCollection = inbox.SearchParse("SEARCH FLAGGED SINCE 1-Feb-1994 NOT FROM "Smith");
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public MessageCollection SearchParse(string query)
    {
      MessageCollection messageCollection = new MessageCollection();
      foreach (int messageOrdinal in this.Search(query))
        messageCollection.Add(this.Fetch.MessageObject(messageOrdinal));
      return messageCollection;
    }

    public IAsyncResult BeginSearchParse(string query, AsyncCallback callback)
    {
      this._delegateSearchParse = new Mailbox.DelegateSearchParse(this.SearchParse);
      return this._delegateSearchParse.BeginInvoke(query, callback, (object) this._delegateSearchParse);
    }

    /// <summary>
    /// Searches the mailbox for messages corresponding to the query.
    /// 
    /// </summary>
    /// <param name="query">The search query.</param><param name="charset">The charset the query has to be performed for.</param>
    /// <returns>
    /// An array of integers containing ordinal positions of messages matching the query.
    /// </returns>
    /// 
    /// <example>
    /// <see cref="M:ActiveUp.Net.Mail.Mailbox.Search(System.String)"/>
    /// </example>
    public int[] Search(string charset, string query)
    {
      string str = this.SourceClient.Command("search charset " + charset + " " + query);
      string[] strArray = str.Substring(0, str.IndexOf("\r\n")).Split(new char[1]
      {
        ' '
      });
      int[] numArray = new int[strArray.Length - 2];
      for (int index = 2; index < strArray.Length; ++index)
        numArray[index - 2] = Convert.ToInt32(strArray[index]);
      return numArray;
    }

    public IAsyncResult BeginSearch(string charset, string query, AsyncCallback callback)
    {
      this._delegateSearchStringString = new Mailbox.DelegateSearchStringString(this.Search);
      return this._delegateSearchStringString.BeginInvoke(charset, query, callback, (object) this._delegateSearchStringString);
    }

    public string EndSearch(IAsyncResult result)
    {
      return (string) result.AsyncState.GetType().GetMethod("EndInvoke").Invoke(result.AsyncState, new object[1]
      {
        (object) result
      });
    }

    /// <summary>
    /// Search for messages accoridng to the given query.
    /// 
    /// </summary>
    /// <param name="query">Query to use.</param><param name="charset">The charset to apply the query for.</param>
    /// <returns>
    /// A collection of messages matching the query.
    /// </returns>
    /// 
    /// <example>
    /// <see cref="M:ActiveUp.Net.Mail.Mailbox.SearchParse(System.String)"/>
    /// </example>
    public MessageCollection SearchParse(string charset, string query)
    {
      MessageCollection messageCollection = new MessageCollection();
      foreach (int messageOrdinal in this.Search(charset, query))
        messageCollection.Add(this.Fetch.MessageObject(messageOrdinal));
      return messageCollection;
    }

    public IAsyncResult BeginSearchParse(string charset, string query, AsyncCallback callback)
    {
      this._delegateSearchParseStringString = new Mailbox.DelegateSearchParseStringString(this.SearchParse);
      return this._delegateSearchParseStringString.BeginInvoke(charset, query, callback, (object) this._delegateSearchParseStringString);
    }

    public string EndSearchParse(IAsyncResult result)
    {
      return (string) result.AsyncState.GetType().GetMethod("EndInvoke").Invoke(result.AsyncState, new object[1]
      {
        (object) result
      });
    }

    /// <summary>
    /// Adds the specified flags to the message.
    /// 
    /// </summary>
    /// <param name="messageOrdinal">The message's ordinal position.</param><param name="flags">Flags to be added to the message.</param>
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
    ///             FlagCollection flags = new FlagCollection();
    ///             flags.Add("Draft");
    ///             inbox.AddFlags(1,flags);
    ///             //Message 1 is marked as draft.
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("jdoe1234","tanstaaf")
    ///             Dim inbox As Mailbox = imap.SelectInbox("inbox")
    ///             Dim flags As New FlagCollection
    ///             flags.Add("Draft")
    ///             inbox.AddFlags(1,flags)
    ///             'Message 1 is marked as draft.
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             var inbox:Mailbox = imap.SelectInbox("inbox");
    ///             var flags:FlagCollection = new FlagCollection();
    ///             flags.Add("Draft");
    ///             inbox.AddFlags(1,flags);
    ///             //Message is marked as draft.
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public string AddFlags(int messageOrdinal, IFlagCollection flags)
    {
      return this.SourceClient.Command("store " + messageOrdinal.ToString() + " +flags " + ((FlagCollection) flags).Merged);
    }

    public IAsyncResult BeginAddFlags(int messageOrdinal, IFlagCollection flags, AsyncCallback callback)
    {
      this._delegateAddFlags = new Mailbox.DelegateAddFlags(this.AddFlags);
      return this._delegateAddFlags.BeginInvoke(messageOrdinal, flags, callback, (object) this._delegateAddFlags);
    }

    public string EndAddFlags(IAsyncResult result)
    {
      return this._delegateAddFlags.EndInvoke(result);
    }

    public string UidAddFlags(int uid, IFlagCollection flags)
    {
      return this.SourceClient.Command("uid store " + uid.ToString() + " +flags " + ((FlagCollection) flags).Merged);
    }

    public IAsyncResult BeginUidAddFlags(int uid, IFlagCollection flags, AsyncCallback callback)
    {
      this._delegateUidAddFlags = new Mailbox.DelegateUidAddFlags(this.UidAddFlags);
      return this._delegateUidAddFlags.BeginInvoke(uid, flags, callback, (object) this._delegateUidAddFlags);
    }

    public string EndUidAddFlags(IAsyncResult result)
    {
      return this._delegateUidAddFlags.EndInvoke(result);
    }

    /// <summary>
    /// Removes the specified flags from the message.
    /// 
    /// </summary>
    /// <param name="messageOrdinal">The message's ordinal position.</param><param name="flags">Flags to be removed from the message.</param>
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
    ///             FlagCollection flags = new FlagCollection();
    ///             flags.Add("Read");
    ///             inbox.RemoveFlags(1,flags);
    ///             //Message 1 is marked as unread.
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("jdoe1234","tanstaaf")
    ///             Dim inbox As Mailbox = imap.SelectInbox("inbox")
    ///             Dim flags As New FlagCollection
    ///             flags.Add("Read")
    ///             inbox.RemoveFlags(1,flags)
    ///             'Message 1 is marked as unread.
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             var inbox:Mailbox = imap.SelectInbox("inbox");
    ///             var flags:FlagCollection = new FlagCollection();
    ///             flags.Add("Read");
    ///             inbox.RemoveFlags(1,flags);
    ///             //Message 1 is marked as unread.
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public string RemoveFlags(int messageOrdinal, IFlagCollection flags)
    {
      return this.SourceClient.Command("store " + messageOrdinal.ToString() + " -flags " + ((FlagCollection) flags).Merged);
    }

    public IAsyncResult BeginRemoveFlags(int messageOrdinal, IFlagCollection flags, AsyncCallback callback)
    {
      this._delegateRemoveFlags = new Mailbox.DelegateRemoveFlags(this.RemoveFlags);
      return this._delegateRemoveFlags.BeginInvoke(messageOrdinal, flags, callback, (object) this._delegateRemoveFlags);
    }

    public string EndRemoveFlags(IAsyncResult result)
    {
      return this._delegateRemoveFlags.EndInvoke(result);
    }

    public string UidRemoveFlags(int uid, IFlagCollection flags)
    {
      return this.SourceClient.Command("uid store " + uid.ToString() + " -flags " + ((FlagCollection) flags).Merged);
    }

    public IAsyncResult BeginUidRemoveFlags(int uid, IFlagCollection flags, AsyncCallback callback)
    {
      this._delegateUidRemoveFlags = new Mailbox.DelegateUidRemoveFlags(this.UidRemoveFlags);
      return this._delegateUidRemoveFlags.BeginInvoke(uid, flags, callback, (object) this._delegateUidRemoveFlags);
    }

    public string EndUidRemoveFlags(IAsyncResult result)
    {
      return this._delegateUidRemoveFlags.EndInvoke(result);
    }

    /// <summary>
    /// Sets the specified flags for the message.
    /// 
    /// </summary>
    /// <param name="messageOrdinal">The message's ordinal position.</param><param name="flags">Flags to be stored for the message.</param>
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
    ///             FlagCollection flags = new FlagCollection();
    ///             flags.Add("Read");
    ///             flags.Add("Answered");
    ///             inbox.AddFlags(1,flags);
    ///             //Message is marked as read and answered. All prior flags are unset.
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("jdoe1234","tanstaaf")
    ///             Dim inbox As Mailbox = imap.SelectInbox("inbox")
    ///             Dim flags As New FlagCollection
    ///             flags.Add("Read")
    ///             flags.Add("Answered")
    ///             inbox.AddFlags(1,flags)
    ///             'Message is marked as read and answered. All prior flags are unset.
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             var inbox:Mailbox = imap.SelectInbox("inbox");
    ///             var flags:FlagCollection = new FlagCollection();
    ///             flags.Add("Read");
    ///             flags.Add("Answered");
    ///             inbox.AddFlags(1,flags);
    ///             //Message is marked as read and answered. All prior flags are unset.
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public string SetFlags(int messageOrdinal, IFlagCollection flags)
    {
      return this.SourceClient.Command("store " + messageOrdinal.ToString() + " flags " + ((FlagCollection) flags).Merged);
    }

    public IAsyncResult BeginSetFlags(int messageOrdinal, IFlagCollection flags, AsyncCallback callback)
    {
      this._delegateSetFlags = new Mailbox.DelegateSetFlags(this.SetFlags);
      return this._delegateSetFlags.BeginInvoke(messageOrdinal, flags, callback, (object) this._delegateSetFlags);
    }

    public string EndSetFlags(IAsyncResult result)
    {
      return this._delegateSetFlags.EndInvoke(result);
    }

    public string UidSetFlags(int uid, IFlagCollection flags)
    {
      return this.SourceClient.Command("uid store " + uid.ToString() + " flags " + ((FlagCollection) flags).Merged);
    }

    public IAsyncResult BeginUidSetFlags(int uid, IFlagCollection flags, AsyncCallback callback)
    {
      this._delegateUidSetFlags = new Mailbox.DelegateUidSetFlags(this.UidSetFlags);
      return this._delegateUidSetFlags.BeginInvoke(uid, flags, callback, (object) this._delegateUidSetFlags);
    }

    public string EndUidSetFlags(IAsyncResult result)
    {
      return this._delegateUidSetFlags.EndInvoke(result);
    }

    /// <summary>
    /// Same as AddFlags() except no response is requested.
    /// 
    /// </summary>
    /// <param name="messageOrdinal">The message's ordinal position.</param><param name="flags">Flags to be added to the message.</param>
    /// <example>
    /// <see cref="M:ActiveUp.Net.Mail.Mailbox.AddFlags(System.Int32,ActiveUp.Net.Mail.IFlagCollection)"/>
    /// </example>
    public void AddFlagsSilent(int messageOrdinal, IFlagCollection flags)
    {
      this.SourceClient.Command("store " + messageOrdinal.ToString() + " +flags.silent " + ((FlagCollection) flags).Merged);
    }

    public IAsyncResult BeginAddFlagsSilent(int messageOrdinal, IFlagCollection flags, AsyncCallback callback)
    {
      this._delegateAddFlagsSilent = new Mailbox.DelegateAddFlagsSilent(this.AddFlagsSilent);
      return this._delegateAddFlagsSilent.BeginInvoke(messageOrdinal, flags, callback, (object) this._delegateAddFlagsSilent);
    }

    public void EndAddFlagsSilent(IAsyncResult result)
    {
      this._delegateAddFlagsSilent.EndInvoke(result);
    }

    public void UidAddFlagsSilent(int uid, IFlagCollection flags)
    {
      this.SourceClient.Command("uid store " + uid.ToString() + " +flags.silent " + ((FlagCollection) flags).Merged);
    }

    public IAsyncResult BeginUidAddFlagsSilent(int uid, IFlagCollection flags, AsyncCallback callback)
    {
      this._delegateUidAddFlagsSilent = new Mailbox.DelegateUidAddFlagsSilent(this.UidAddFlagsSilent);
      return this._delegateUidAddFlagsSilent.BeginInvoke(uid, flags, callback, (object) this._delegateUidAddFlagsSilent);
    }

    public void EndUidAddFlagsSilent(IAsyncResult result)
    {
      this._delegateUidAddFlagsSilent.EndInvoke(result);
    }

    /// <summary>
    /// Same as RemoveFlags() except no response is requested.
    /// 
    /// </summary>
    /// <param name="messageOrdinal">The message's ordinal position.</param><param name="flags">Flags to be removed from the message.</param>
    /// <example>
    /// <see cref="M:ActiveUp.Net.Mail.Mailbox.RemoveFlags(System.Int32,ActiveUp.Net.Mail.IFlagCollection)"/>
    /// </example>
    public void RemoveFlagsSilent(int messageOrdinal, IFlagCollection flags)
    {
      this.SourceClient.Command("store " + messageOrdinal.ToString() + " -flags.silent " + ((FlagCollection) flags).Merged);
    }

    public IAsyncResult BeginRemoveFlagsSilent(int messageOrdinal, IFlagCollection flags, AsyncCallback callback)
    {
      this._delegateRemoveFlagsSilent = new Mailbox.DelegateRemoveFlagsSilent(this.RemoveFlagsSilent);
      return this._delegateRemoveFlagsSilent.BeginInvoke(messageOrdinal, flags, callback, (object) this._delegateRemoveFlagsSilent);
    }

    public void EndRemoveFlagsSilent(IAsyncResult result)
    {
      this._delegateRemoveFlagsSilent.EndInvoke(result);
    }

    public void UidRemoveFlagsSilent(int uid, IFlagCollection flags)
    {
      this.SourceClient.Command("uid store " + uid.ToString() + " -flags.silent " + ((FlagCollection) flags).Merged);
    }

    public IAsyncResult BeginUidRemoveFlagsSilent(int uid, IFlagCollection flags, AsyncCallback callback)
    {
      this._delegateUidRemoveFlagsSilent = new Mailbox.DelegateUidRemoveFlagsSilent(this.UidRemoveFlagsSilent);
      return this._delegateUidRemoveFlagsSilent.BeginInvoke(uid, flags, callback, (object) this._delegateUidRemoveFlagsSilent);
    }

    public void EndUidRemoveFlagsSilent(IAsyncResult result)
    {
      this._delegateUidRemoveFlagsSilent.EndInvoke(result);
    }

    /// <summary>
    /// Same as SetFlags() except no response is requested.
    /// 
    /// </summary>
    /// <param name="messageOrdinal">The message's ordinal position.</param><param name="flags">Flags to be set for the message.</param>
    /// <example>
    /// <see cref="M:ActiveUp.Net.Mail.Mailbox.SetFlags(System.Int32,ActiveUp.Net.Mail.IFlagCollection)"/>
    /// </example>
    public void SetFlagsSilent(int messageOrdinal, IFlagCollection flags)
    {
      this.SourceClient.Command("store " + messageOrdinal.ToString() + " flags.silent " + ((FlagCollection) flags).Merged);
    }

    public IAsyncResult BeginSetFlagsSilent(int messageOrdinal, IFlagCollection flags, AsyncCallback callback)
    {
      this._delegateSetFlagsSilent = new Mailbox.DelegateSetFlagsSilent(this.SetFlagsSilent);
      return this._delegateSetFlagsSilent.BeginInvoke(messageOrdinal, flags, callback, (object) this._delegateSetFlagsSilent);
    }

    public void EndSetFlagsSilent(IAsyncResult result)
    {
      this._delegateSetFlagsSilent.EndInvoke(result);
    }

    public void UidSetFlagsSilent(int uid, IFlagCollection flags)
    {
      this.SourceClient.Command("uid store " + uid.ToString() + " flags.silent " + ((FlagCollection) flags).Merged);
    }

    public IAsyncResult BeginUidSetFlagsSilent(int uid, IFlagCollection flags, AsyncCallback callback)
    {
      this._delegateUidSetFlagsSilent = new Mailbox.DelegateUidSetFlagsSilent(this.UidSetFlagsSilent);
      return this._delegateUidSetFlagsSilent.BeginInvoke(uid, flags, callback, (object) this._delegateUidSetFlagsSilent);
    }

    public void EndUidSetFlagsSilent(IAsyncResult result)
    {
      this._delegateUidSetFlagsSilent.EndInvoke(result);
    }

    /// <summary>
    /// Copies the specified message to the specified mailbox.
    /// 
    /// </summary>
    /// <param name="messageOrdinal">The ordinal of the message to be copied.</param><param name="destinationMailboxName">The name of the destination mailbox.</param>
    /// <returns>
    /// The destination mailbox.
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
    ///             inbox.CopyMessage(1,"Read Messages");
    ///             //Copies message 1 to Read Messages mailbox.
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("jdoe1234","tanstaaf")
    ///             Dim inbox As Mailbox = imap.SelectInbox("inbox")
    ///             inbox.CopyMessage(1,"Read Messages")
    ///             'Copies message 1 to Read Messages mailbox.
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             var inbox:Mailbox = imap.SelectInbox("inbox");
    ///             inbox.CopyMessage(1,"Read Messages");
    ///             //Copies message 1 to Read Messages mailbox.
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public void CopyMessage(int messageOrdinal, string destinationMailboxName)
    {
      this.SourceClient.Command("copy " + messageOrdinal.ToString() + " \"" + destinationMailboxName + "\"");
    }

    public IAsyncResult BeginCopyMessage(int messageOrdinal, string destinationMailboxName, AsyncCallback callback)
    {
      this._delegateCopyMessage = new Mailbox.DelegateCopyMessage(this.CopyMessage);
      return this._delegateCopyMessage.BeginInvoke(messageOrdinal, destinationMailboxName, callback, (object) this._delegateCopyMessage);
    }

    public void EndCopyMessage(IAsyncResult result)
    {
      this._delegateCopyMessage.EndInvoke(result);
    }

    public void UidCopyMessage(int uid, string destinationMailboxName)
    {
      this.SourceClient.Command("uid copy " + uid.ToString() + " \"" + destinationMailboxName + "\"");
    }

    public IAsyncResult BeginUidCopyMessage(int uid, string destinationMailboxName, AsyncCallback callback)
    {
      this._delegateUidCopyMessage = new Mailbox.DelegateUidCopyMessage(this.UidCopyMessage);
      return this._delegateUidCopyMessage.BeginInvoke(uid, destinationMailboxName, callback, (object) this._delegateUidCopyMessage);
    }

    public void EndUidCopyMessage(IAsyncResult result)
    {
      this._delegateUidCopyMessage.EndInvoke(result);
    }

    public void MoveMessage(int messageOrdinal, string destinationMailboxName)
    {
      this.CopyMessage(messageOrdinal, destinationMailboxName);
      this.DeleteMessage(messageOrdinal, true);
    }

    public IAsyncResult BeginMoveMessage(int messageOrdinal, string destinationMailboxName, AsyncCallback callback)
    {
      this._delegateMoveMessage = new Mailbox.DelegateMoveMessage(this.MoveMessage);
      return this._delegateMoveMessage.BeginInvoke(messageOrdinal, destinationMailboxName, callback, (object) this._delegateMoveMessage);
    }

    public void EndMoveMessage(IAsyncResult result)
    {
      this._delegateMoveMessage.EndInvoke(result);
    }

    public void UidMoveMessage(int uid, string destinationMailboxName)
    {
      this.UidCopyMessage(uid, destinationMailboxName);
      this.UidDeleteMessage(uid, true);
    }

    public IAsyncResult BeginUidMoveMessage(int uid, string destinationMailboxName, AsyncCallback callback)
    {
      this._delegateUidMoveMessage = new Mailbox.DelegateUidMoveMessage(this.UidMoveMessage);
      return this._delegateUidMoveMessage.BeginInvoke(uid, destinationMailboxName, callback, (object) this._delegateUidMoveMessage);
    }

    public void EndUidMoveMessage(IAsyncResult result)
    {
      this._delegateUidMoveMessage.EndInvoke(result);
    }

    /// <summary>
    /// Appends the provided message to the mailbox.
    /// 
    /// </summary>
    /// <param name="messageLiteral">The message in a Rfc822 compliant format.</param>
    public string Append(string messageLiteral)
    {
      string str = DateTime.Now.ToString("yyMMddhhmmss" + DateTime.Now.Millisecond.ToString());
      this.SourceClient.Command("APPEND \"" + (object) this.Name + "\" {" + (string) (object) messageLiteral.Length + "}", str);
      return this.SourceClient.Command(messageLiteral, "", str);
    }

    public IAsyncResult BeginAppend(string messageLiteral, AsyncCallback callback)
    {
      this._delegateAppend = new Mailbox.DelegateAppend(this.Append);
      return this._delegateAppend.BeginInvoke(messageLiteral, callback, (object) this._delegateAppend);
    }

    /// <summary>
    /// Appends the provided message to the mailbox.
    /// 
    /// </summary>
    /// <param name="messageLiteral">The message in a Rfc822 compliant format.</param><param name="flags">Flags to be set for the message.</param>
    public string Append(string messageLiteral, IFlagCollection flags)
    {
      string str = DateTime.Now.ToString("yyMMddhhmmss" + DateTime.Now.Millisecond.ToString());
      this.SourceClient.Command("APPEND \"" + (object) this.Name + "\" " + ((FlagCollection) flags).Merged + " {" + (string) (object) messageLiteral.Length + "}", str);
      return this.SourceClient.Command(messageLiteral, "", str);
    }

    public IAsyncResult BeginAppend(string messageLiteral, IFlagCollection flags, AsyncCallback callback)
    {
      this._delegateAppendFlags = new Mailbox.DelegateAppendFlags(this.Append);
      return this._delegateAppendFlags.BeginInvoke(messageLiteral, flags, callback, (object) this._delegateAppendFlags);
    }

    /// <summary>
    /// Appends the provided message to the mailbox.
    /// 
    /// </summary>
    /// <param name="messageLiteral">The message in a Rfc822 compliant format.</param><param name="flags">Flags to be set for the message.</param><param name="dateTime">The internal date to be set for the message.</param>
    public string Append(string messageLiteral, IFlagCollection flags, DateTime dateTime)
    {
      string str = DateTime.Now.ToString("yyMMddhhmmss" + DateTime.Now.Millisecond.ToString());
      this.SourceClient.Command("APPEND \"" + (object) this.Name + "\" " + ((FlagCollection) flags).Merged + " " + dateTime.ToString("r") + " {" + (string) (object) messageLiteral.Length + "}", str);
      return this.SourceClient.Command(messageLiteral, "", str);
    }

    public IAsyncResult BeginAppend(string messageLiteral, IFlagCollection flags, DateTime dateTime, AsyncCallback callback)
    {
      this._delegateAppendFlagsDateTime = new Mailbox.DelegateAppendFlagsDateTime(this.Append);
      return this._delegateAppendFlagsDateTime.BeginInvoke(messageLiteral, flags, dateTime, callback, (object) this._delegateAppendFlagsDateTime);
    }

    /// <summary>
    /// Appends the provided message to the mailbox.
    /// 
    /// </summary>
    /// <param name="message">The message to be appended.</param>
    /// <example>
    /// 
    /// <code>
    /// C#
    /// 
    ///             Message message = new Message();
    ///             message.From = new Address("jdoe@myhost.com","John Doe");
    ///             message.To.Add("mjohns@otherhost.com","Mike Johns");
    ///             message.Subject = "hey!";
    ///             message.Attachments.Add("C:\\myfile.doc");
    ///             message.HtmlBody.Text = "As promised, the requested document.&lt;br /&gt;&lt;br /&gt;Regards,&lt;br&gt;John.";
    /// 
    ///             Imap4Client imap = new Imap4Client();
    ///             Mailbox inbox = imap.SelectMailbox("inbox");
    ///             inbox.Append(message);
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim message As New Message
    ///             message.From = new Address("jdoe@myhost.com","John Doe")
    ///             message.To.Add("mjohns@otherhost.com","Mike Johns")
    ///             message.Subject = "hey!"
    ///             message.Attachments.Add("C:\myfile.doc")
    ///             message.HtmlBody.Text = "As promised, the requested document.&lt;br /&gt;&lt;br /&gt;Regards,&lt;br&gt;John."
    /// 
    ///             Dim imap As New Imap4Client
    ///             Dim inbox As Mailbox = imap.SelectMailbox("inbox")
    ///             inbox.Append(message)
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var message:Message = new Message();
    ///             message.From = new Address("jdoe@myhost.com","John Doe")
    ///             message.To.Add("mjohns@otherhost.com","Mike Johns");
    ///             message.Subject = "hey!";
    ///             message.Attachments.Add("C:\\myfile.doc");
    ///             message.HtmlBody.Text = "As promised, the requested document.&lt;br /&gt;&lt;br /&gt;Regards,&lt;br&gt;John."
    /// 
    ///             var imap:Imap4Client = new Imap4Client();
    ///             var inbox:Mailbox = imap.SelectMailbox("inbox");
    ///             inbox.Append(message);
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public string Append(Message message)
    {
      return this.Append(message.ToMimeString());
    }

    public IAsyncResult BeginAppend(Message message, AsyncCallback callback)
    {
      this._delegateAppendMessage = new Mailbox.DelegateAppendMessage(this.Append);
      return this._delegateAppendMessage.BeginInvoke(message, callback, (object) this._delegateAppendMessage);
    }

    /// <summary>
    /// Appends the provided message to the mailbox.
    /// 
    /// </summary>
    /// <param name="message">The message to be appended.</param><param name="flags">Flags to be set for the message.</param>
    /// <example>
    /// 
    /// <code>
    /// C#
    /// 
    ///             Message message = new Message();
    ///             message.From = new Address("jdoe@myhost.com","John Doe");
    ///             message.To.Add("mjohns@otherhost.com","Mike Johns");
    ///             message.Subject = "hey!";
    ///             message.Attachments.Add("C:\\myfile.doc");
    ///             message.HtmlBody.Text = "As promised, the requested document.&lt;br /&gt;&lt;br /&gt;Regards,&lt;br&gt;John.";
    /// 
    ///             FlagCollection flags = new FlagCollection();
    ///             flags.Add("Read");
    /// 
    ///             Imap4Client imap = new Imap4Client();
    ///             Mailbox inbox = imap.SelectMailbox("Read Messages");
    ///             inbox.Append(message,flags);
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim message As New Message
    ///             message.From = new Address("jdoe@myhost.com","John Doe")
    ///             message.To.Add("mjohns@otherhost.com","Mike Johns")
    ///             message.Subject = "hey!"
    ///             message.Attachments.Add("C:\myfile.doc")
    ///             message.HtmlBody.Text = "As promised, the requested document.&lt;br /&gt;&lt;br /&gt;Regards,&lt;br&gt;John."
    /// 
    ///             Dim flags As New FlagCollection
    ///             flags.Add("Read")
    /// 
    ///             Dim imap As New Imap4Client
    ///             Dim inbox As Mailbox = imap.SelectMailbox("Read Messages")
    ///             inbox.Append(message,flags)
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var message:Message = new Message();
    ///             message.From = new Address("jdoe@myhost.com","John Doe")
    ///             message.To.Add("mjohns@otherhost.com","Mike Johns");
    ///             message.Subject = "hey!";
    ///             message.Attachments.Add("C:\\myfile.doc");
    ///             message.HtmlBody.Text = "As promised, the requested document.&lt;br /&gt;&lt;br /&gt;Regards,&lt;br&gt;John."
    /// 
    ///             var flags:FlagCollection = new FlagCollection();
    ///             flags.Add("Read");
    /// 
    ///             var imap:Imap4Client = new Imap4Client();
    ///             var inbox:Mailbox = imap.SelectMailbox("Read Messages");
    ///             inbox.Append(message,flags);
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public string Append(Message message, IFlagCollection flags)
    {
      return this.Append(message.ToMimeString(), flags);
    }

    public IAsyncResult BeginAppend(Message message, IFlagCollection flags, AsyncCallback callback)
    {
      this._delegateAppendMessageFlags = new Mailbox.DelegateAppendMessageFlags(this.Append);
      return this._delegateAppendMessageFlags.BeginInvoke(message, flags, callback, (object) this._delegateAppendMessageFlags);
    }

    /// <summary>
    /// Appends the provided message to the mailbox.
    /// 
    /// </summary>
    /// <param name="message">The message to be appended.</param><param name="flags">Flags to be set for the message.</param><param name="dateTime">The internal date to be set for the message.</param>
    /// <example>
    /// 
    /// <code>
    /// C#
    /// 
    ///             Message message = new Message();
    ///             message.From = new Address("jdoe@myhost.com","John Doe");
    ///             message.To.Add("mjohns@otherhost.com","Mike Johns");
    ///             message.Subject = "hey!";
    ///             message.Attachments.Add("C:\\myfile.doc");
    ///             message.HtmlBody.Text = "As promised, the requested document.&lt;br /&gt;&lt;br /&gt;Regards,&lt;br&gt;John.";
    /// 
    ///             FlagCollection flags = new FlagCollection();
    ///             flags.Add("Read");
    /// 
    ///             Imap4Client imap = new Imap4Client();
    ///             Mailbox inbox = imap.SelectMailbox("Read Messages");
    ///             inbox.Append(message,flags,System.DateTime.Now);
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim message As New Message
    ///             message.From = new Address("jdoe@myhost.com","John Doe")
    ///             message.To.Add("mjohns@otherhost.com","Mike Johns")
    ///             message.Subject = "hey!"
    ///             message.Attachments.Add("C:\myfile.doc")
    ///             message.HtmlBody.Text = "As promised, the requested document.&lt;br /&gt;&lt;br /&gt;Regards,&lt;br&gt;John."
    /// 
    ///             Dim flags As New FlagCollection
    ///             flags.Add("Read")
    /// 
    ///             Dim imap As New Imap4Client
    ///             Dim inbox As Mailbox = imap.SelectMailbox("Read Messages")
    ///             inbox.Append(message,flags,System.DateTime.Now)
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var message:Message = new Message();
    ///             message.From = new Address("jdoe@myhost.com","John Doe")
    ///             message.To.Add("mjohns@otherhost.com","Mike Johns");
    ///             message.Subject = "hey!";
    ///             message.Attachments.Add("C:\\myfile.doc");
    ///             message.HtmlBody.Text = "As promised, the requested document.&lt;br /&gt;&lt;br /&gt;Regards,&lt;br&gt;John."
    /// 
    ///             var flags:FlagCollection = new FlagCollection();
    ///             flags.Add("Read");
    /// 
    ///             var imap:Imap4Client = new Imap4Client();
    ///             var inbox:Mailbox = imap.SelectMailbox("Read Messages");
    ///             inbox.Append(message,flags,System.DateTime.Now);
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public string Append(Message message, IFlagCollection flags, DateTime dateTime)
    {
      return this.Append(message.ToMimeString(), flags, dateTime);
    }

    public IAsyncResult BeginAppend(Message message, IFlagCollection flags, DateTime dateTime, AsyncCallback callback)
    {
      this._delegateAppendMessageFlagsDateTime = new Mailbox.DelegateAppendMessageFlagsDateTime(this.Append);
      return this._delegateAppendMessageFlagsDateTime.BeginInvoke(message, flags, dateTime, callback, (object) this._delegateAppendMessageFlagsDateTime);
    }

    /// <summary>
    /// Appends the provided message to the mailbox.
    /// 
    /// </summary>
    /// <param name="messageData">The message in a Rfc822 compliant format.</param>
    /// <example>
    /// <see cref="M:ActiveUp.Net.Mail.Mailbox.Append(System.String)"/>
    /// </example>
    public string Append(byte[] messageData)
    {
      return this.Append(Encoding.ASCII.GetString(messageData, 0, messageData.Length));
    }

    public IAsyncResult BeginAppend(byte[] messageData, AsyncCallback callback)
    {
      this._delegateAppendByte = new Mailbox.DelegateAppendByte(this.Append);
      return this._delegateAppendByte.BeginInvoke(messageData, callback, (object) this._delegateAppendByte);
    }

    /// <summary>
    /// Appends the provided message to the mailbox.
    /// 
    /// </summary>
    /// <param name="messageData">The message in a Rfc822 compliant format.</param><param name="flags">Flags to be set for the message.</param>
    /// <example>
    /// <see cref="M:ActiveUp.Net.Mail.Mailbox.Append(System.String)"/>
    /// </example>
    public string Append(byte[] messageData, IFlagCollection flags)
    {
      return this.Append(Encoding.ASCII.GetString(messageData, 0, messageData.Length), flags);
    }

    public IAsyncResult BeginAppend(byte[] messageData, IFlagCollection flags, AsyncCallback callback)
    {
      this._delegateAppendByteFlags = new Mailbox.DelegateAppendByteFlags(this.Append);
      return this._delegateAppendByteFlags.BeginInvoke(messageData, flags, callback, (object) this._delegateAppendByteFlags);
    }

    /// <summary>
    /// Appends the provided message to the mailbox.
    /// 
    /// </summary>
    /// <param name="messageData">The message in a Rfc822 compliant format.</param><param name="flags">Flags to be set for the message.</param><param name="dateTime">The internal date to be set for the message.</param>
    /// <example>
    /// <see cref="M:ActiveUp.Net.Mail.Mailbox.Append(System.String)"/>
    /// </example>
    public string Append(byte[] messageData, IFlagCollection flags, DateTime dateTime)
    {
      return this.Append(Encoding.ASCII.GetString(messageData, 0, messageData.Length), flags, dateTime);
    }

    public IAsyncResult BeginAppend(byte[] messageData, IFlagCollection flags, DateTime dateTime, AsyncCallback callback)
    {
      this._delegateAppendByteFlagsDateTime = new Mailbox.DelegateAppendByteFlagsDateTime(this.Append);
      return this._delegateAppendByteFlagsDateTime.BeginInvoke(messageData, flags, dateTime, callback, (object) this._delegateAppendByteFlagsDateTime);
    }

    public string EndAppend(IAsyncResult result)
    {
      return (string) result.AsyncState.GetType().GetMethod("EndInvoke").Invoke(result.AsyncState, new object[1]
      {
        (object) result
      });
    }

    /// <summary>
    /// Empties the mailbox.
    /// 
    /// </summary>
    /// <param name="expunge">If true, all messages are permanently removed. Otherwise they are all marked with the Deleted flag.</param>
    /// <example>
    /// 
    /// <code>
    /// C#
    /// 
    ///             Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             Mailbox inbox = imap.SelectInbox("inbox");
    ///             inbox.Empty(true);
    ///             //Messages from inbox are permanently removed.
    ///             imap.Disconnect();
    /// 
    ///             VB.NET
    /// 
    ///             Dim imap As New Imap4Client
    ///             imap.Connect("mail.myhost.com")
    ///             imap.Login("jdoe1234","tanstaaf")
    ///             Dim inbox As Mailbox = imap.SelectInbox("inbox")
    ///             inbox.Empty(True)
    ///             'Messages from inbox are permanently removed.
    ///             imap.Disconnect()
    /// 
    ///             JScript.NET
    /// 
    ///             var imap:Imap4Client imap = new Imap4Client();
    ///             imap.Connect("mail.myhost.com");
    ///             imap.Login("jdoe1234","tanstaaf");
    ///             var inbox:Mailbox = imap.SelectInbox("inbox");
    ///             inbox.Empty(true);
    ///             //Messages from inbox are permanently removed.
    ///             imap.Disconnect();
    /// 
    /// </code>
    /// 
    /// </example>
    public void Empty(bool expunge)
    {
      FlagCollection flagCollection = new FlagCollection();
      flagCollection.Add("Deleted");
      for (int messageOrdinal = 1; messageOrdinal <= this.MessageCount; ++messageOrdinal)
        this.AddFlagsSilent(messageOrdinal, (IFlagCollection) flagCollection);
      if (!expunge)
        return;
      this.SourceClient.Expunge();
    }

    public IAsyncResult BeginEmpty(bool expunge, AsyncCallback callback)
    {
      this._delegateEmpty = new Mailbox.DelegateEmpty(this.Empty);
      return this._delegateEmpty.BeginInvoke(expunge, callback, (object) this._delegateEmpty);
    }

    public void EndEmpty(IAsyncResult result)
    {
      this._delegateEmpty.EndInvoke(result);
    }

    public void DeleteMessage(int messageOrdinal, bool expunge)
    {
      this.AddFlagsSilent(messageOrdinal, (IFlagCollection) new FlagCollection()
      {
        "Deleted"
      });
      if (!expunge)
        return;
      this.SourceClient.Expunge();
    }

    public IAsyncResult BeginDeleteMessage(int messageOrdinal, bool expunge, AsyncCallback callback)
    {
      this._delegateDeleteMessage = new Mailbox.DelegateDeleteMessage(this.DeleteMessage);
      return this._delegateDeleteMessage.BeginInvoke(messageOrdinal, expunge, callback, (object) this._delegateDeleteMessage);
    }

    public void EndDeleteMessage(IAsyncResult result)
    {
      this._delegateDeleteMessage.EndInvoke(result);
    }

    public void UidDeleteMessage(int uid, bool expunge)
    {
      this.UidAddFlagsSilent(uid, (IFlagCollection) new FlagCollection()
      {
        "Deleted"
      });
      if (!expunge)
        return;
      this.SourceClient.Expunge();
    }

    public IAsyncResult BeginUidDeleteMessage(int uid, bool expunge, AsyncCallback callback)
    {
      this._delegateUidDeleteMessage = new Mailbox.DelegateUidDeleteMessage(this.UidDeleteMessage);
      return this._delegateUidDeleteMessage.BeginInvoke(uid, expunge, callback, (object) this._delegateUidDeleteMessage);
    }

    public void EndUidDeleteMessage(IAsyncResult result)
    {
      this._delegateUidDeleteMessage.EndInvoke(result);
    }

    private delegate IMailbox DelegateCreateChild(string mailboxName);

    private delegate string DelegateSubscribe();

    private delegate string DelegateUnsubscribe();

    private delegate string DelegateDelete();

    private delegate string DelegateRename(string newMailboxName);

    private delegate int[] DelegateSearch(string query);

    private delegate MessageCollection DelegateSearchParse(string query);

    private delegate int[] DelegateSearchStringString(string charset, string query);

    private delegate MessageCollection DelegateSearchParseStringString(string charset, string query);

    private delegate string DelegateAddFlags(int messageOrdinal, IFlagCollection flags);

    private delegate string DelegateUidAddFlags(int uid, IFlagCollection flags);

    private delegate string DelegateRemoveFlags(int messageOrdinal, IFlagCollection flags);

    private delegate string DelegateUidRemoveFlags(int uid, IFlagCollection flags);

    private delegate string DelegateSetFlags(int messageOrdinal, IFlagCollection flags);

    private delegate string DelegateUidSetFlags(int uid, IFlagCollection flags);

    private delegate void DelegateAddFlagsSilent(int messageOrdinal, IFlagCollection flags);

    private delegate void DelegateUidAddFlagsSilent(int uid, IFlagCollection flags);

    private delegate void DelegateRemoveFlagsSilent(int messageOrdinal, IFlagCollection flags);

    private delegate void DelegateUidRemoveFlagsSilent(int uid, IFlagCollection flags);

    private delegate void DelegateSetFlagsSilent(int messageOrdinal, IFlagCollection flags);

    private delegate void DelegateUidSetFlagsSilent(int uid, IFlagCollection flags);

    private delegate void DelegateCopyMessage(int messageOrdinal, string destinationMailboxName);

    private delegate void DelegateUidCopyMessage(int uid, string destinationMailboxName);

    private delegate void DelegateMoveMessage(int messageOrdinal, string destinationMailboxName);

    private delegate void DelegateUidMoveMessage(int uid, string destinationMailboxName);

    private delegate string DelegateAppend(string messageLiteral);

    private delegate string DelegateAppendFlags(string messageLiteral, IFlagCollection flags);

    private delegate string DelegateAppendFlagsDateTime(string messageLiteral, IFlagCollection flags, DateTime dateTime);

    private delegate string DelegateAppendMessage(Message message);

    private delegate string DelegateAppendMessageFlags(Message message, IFlagCollection flags);

    private delegate string DelegateAppendMessageFlagsDateTime(Message message, IFlagCollection flags, DateTime dateTime);

    private delegate string DelegateAppendByte(byte[] messageData);

    private delegate string DelegateAppendByteFlags(byte[] messageData, IFlagCollection flags);

    private delegate string DelegateAppendByteFlagsDateTime(byte[] messageData, IFlagCollection flags, DateTime dateTime);

    private delegate void DelegateEmpty(bool expunge);

    private delegate void DelegateDeleteMessage(int messageOrdinal, bool expunge);

    private delegate void DelegateUidDeleteMessage(int uid, bool expunge);
  }
}
