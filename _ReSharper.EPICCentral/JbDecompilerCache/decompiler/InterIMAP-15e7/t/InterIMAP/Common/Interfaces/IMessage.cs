// Type: InterIMAP.Common.Interfaces.IMessage
// Assembly: InterIMAP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\EPICSource\developer1_ARIZONA21\EPIC Website\EPICCentral\packages\interimap-43840\InterIMAP-Async\InterIMAP\bin\Debug\InterIMAP.dll

using System;

namespace InterIMAP.Common.Interfaces
{
  /// <summary>
  /// Public properties of the Message object
  /// 
  /// </summary>
  public interface IMessage : IBaseObject
  {
    /// <summary>
    /// The message UID
    /// 
    /// </summary>
    int UID { get; set; }

    /// <summary>
    /// The message Subject
    /// 
    /// </summary>
    string Subject { get; set; }

    /// <summary>
    /// The Date the message was sent
    /// 
    /// </summary>
    DateTime DateSent { get; set; }

    /// <summary>
    /// The Date the message was received
    /// 
    /// </summary>
    DateTime DateReceived { get; set; }

    /// <summary/>
    string ReceivedSPF { get; set; }

    /// <summary/>
    string ContentTransferEncoding { get; set; }

    /// <summary/>
    string DeliveredTo { get; set; }

    /// <summary/>
    string XGMailReceived { get; set; }

    /// <summary/>
    string Organization { get; set; }

    /// <summary/>
    string InReplyTo { get; set; }

    /// <summary/>
    string XOriginatingIP { get; set; }

    /// <summary/>
    string Received { get; set; }

    /// <summary/>
    string MimeVersion { get; set; }

    /// <summary/>
    string ContentType { get; set; }

    /// <summary/>
    string ContentClass { get; set; }

    /// <summary/>
    string ReturnPath { get; set; }

    /// <summary/>
    string XMailer { get; set; }

    /// <summary/>
    string XMimeOLE { get; set; }

    /// <summary/>
    string XOriginalArrivalTime { get; set; }

    /// <summary/>
    string MessageID { get; set; }

    /// <summary/>
    string XMSTNEFCorrelator { get; set; }

    /// <summary/>
    string ThreadTopic { get; set; }

    /// <summary/>
    string ThreadIndex { get; set; }

    /// <summary/>
    int FolderID { get; set; }

    /// <summary/>
    IContact[] FromContacts { get; }

    /// <summary/>
    IContact[] ToContacts { get; }

    /// <summary/>
    IContact[] CcContacts { get; }

    /// <summary/>
    IContact[] BccContacts { get; }

    /// <summary/>
    IMessageContent[] MessageContent { get; }

    /// <summary/>
    IFolder Folder { get; }

    /// <summary>
    /// Returns the content of the first part that contains text only data
    /// 
    /// </summary>
    string TextData { get; }

    /// <summary>
    /// Returns the content of the first part that contains HTML data
    /// 
    /// </summary>
    string HTMLData { get; }

    /// <summary>
    /// Flag indicating in this message has been seen
    /// 
    /// </summary>
    bool Seen { get; set; }

    /// <summary>
    /// Flag indicating if this is a recent message
    /// 
    /// </summary>
    bool Recent { get; }

    /// <summary>
    /// Flag indicating if this message is marked for deletion
    /// 
    /// </summary>
    bool Deleted { get; set; }

    /// <summary>
    /// Flag indicating if this message is flagged... (that sounds rather redundant)
    /// 
    /// </summary>
    bool Flagged { get; set; }

    /// <summary>
    /// Flag indicating if this message has been answered
    /// 
    /// </summary>
    bool Answered { get; set; }

    /// <summary>
    /// Flag indicating if this message is a draft
    /// 
    /// </summary>
    bool Draft { get; set; }

    /// <summary>
    /// Flag indicating if this message is new (opposite logic of Seen)
    /// 
    /// </summary>
    bool New { get; set; }

    /// <summary>
    /// Flag indicating if the headers for this message have already been downloaded
    /// 
    /// </summary>
    bool HeaderLoaded { get; }

    /// <summary>
    /// Flag indicating if the content for this message has already been downloaded
    /// 
    /// </summary>
    bool ContentLoaded { get; }
  }
}
