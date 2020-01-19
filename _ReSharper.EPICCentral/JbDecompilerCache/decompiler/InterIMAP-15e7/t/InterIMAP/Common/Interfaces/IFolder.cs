// Type: InterIMAP.Common.Interfaces.IFolder
// Assembly: InterIMAP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// Assembly location: C:\EPICSource\developer1_ARIZONA21\EPIC Website\EPICCentral\packages\interimap-43840\InterIMAP-Async\InterIMAP\bin\Debug\InterIMAP.dll

namespace InterIMAP.Common.Interfaces
{
  /// <summary>
  /// Public properties of the Folder object
  /// 
  /// </summary>
  public interface IFolder : IBaseObject
  {
    /// <summary>
    /// The name of this folder
    /// 
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// The ID of this folders parent
    /// 
    /// </summary>
    int ParentID { get; set; }

    /// <summary>
    /// The full path of this folder
    /// 
    /// </summary>
    string FullPath { get; set; }

    /// <summary>
    /// The list of this folders children
    /// 
    /// </summary>
    IFolder[] SubFolders { get; }

    /// <summary>
    /// Number of messages in this folder
    /// 
    /// </summary>
    int Exists { get; set; }

    /// <summary>
    /// Number of recently added messages in this folder
    /// 
    /// </summary>
    int Recent { get; set; }

    /// <summary>
    /// Number of new messages in this folder
    /// 
    /// </summary>
    int Unseen { get; set; }

    /// <summary>
    /// List of messages in this folder
    /// 
    /// </summary>
    IMessage[] Messages { get; }

    /// <summary>
    /// A reference to this folders parent folder
    /// 
    /// </summary>
    IFolder Parent { get; }
  }
}
