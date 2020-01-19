// Type: ActiveUp.Net.Mail.MailboxCollection
// Assembly: ActiveUp.Net.Imap4, Version=5.0.3454.364, Culture=neutral, PublicKeyToken=9d424b1770e92b68
// Assembly location: C:\EPICSource\developer1_ARIZONA21\EPIC Website\EPICCentral\3rdPartyLibraries\ActiveUp.Net.Imap4.dll

using System;
using System.Collections;

namespace ActiveUp.Net.Mail
{
  /// <summary>
  /// Represents a collection of Mailboxes.
  /// 
  /// </summary>
  [Serializable]
  public class MailboxCollection : CollectionBase
  {
    /// <summary>
    /// Returns the mailbox at index [index] in the collection.
    /// 
    /// </summary>
    public Mailbox this[int index]
    {
      get
      {
        return (Mailbox) this.List[index];
      }
    }

    /// <summary>
    /// Returns the mailbox with the specified name in the collection.
    /// 
    /// </summary>
    public Mailbox this[string mailboxName]
    {
      get
      {
        for (int index = 0; index < this.List.Count; ++index)
        {
          if (((Mailbox) this.List[index]).Name == mailboxName)
            return this[index];
        }
        return (Mailbox) null;
      }
    }

    /// <summary>
    /// Adds the provided mailbox to the collection.
    /// 
    /// </summary>
    /// <param name="mailbox">The mailbox to be added.</param>
    public void Add(Mailbox mailbox)
    {
      this.List.Add((object) mailbox);
    }
  }
}
