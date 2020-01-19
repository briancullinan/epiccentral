// Type: ICSharpCode.SharpZipLib.Zip.ZipEntry
// Assembly: ICSharpCode.SharpZipLib, Version=0.85.5.452, Culture=neutral, PublicKeyToken=1b03e6acf1164f73
// Assembly location: C:\EPICSource\developer1_ARIZONA21\EPIC Website\EPICCentral\3rdPartyLibraries\ICSharpCode.SharpZipLib.dll

using System;
using System.IO;

namespace ICSharpCode.SharpZipLib.Zip
{
  public class ZipEntry : ICloneable
  {
    private ZipEntry.Known known;
    private int externalFileAttributes;
    private ushort versionMadeBy;
    private string name;
    private ulong size;
    private ulong compressedSize;
    private ushort versionToExtract;
    private uint crc;
    private uint dosTime;
    private CompressionMethod method;
    private byte[] extra;
    private string comment;
    private int flags;
    private long zipFileIndex;
    private long offset;
    private bool forceZip64_;
    private byte cryptoCheckValue_;

    public bool HasCrc
    {
      get
      {
        return (this.known & ZipEntry.Known.Crc) != ZipEntry.Known.None;
      }
    }

    public bool IsCrypted
    {
      get
      {
        return (this.flags & 1) != 0;
      }
      set
      {
        if (value)
          this.flags |= 1;
        else
          this.flags &= -2;
      }
    }

    public bool IsUnicodeText
    {
      get
      {
        return (this.flags & 2048) != 0;
      }
      set
      {
        if (value)
          this.flags |= 2048;
        else
          this.flags &= -2049;
      }
    }

    internal byte CryptoCheckValue
    {
      get
      {
        return this.cryptoCheckValue_;
      }
      set
      {
        this.cryptoCheckValue_ = value;
      }
    }

    public int Flags
    {
      get
      {
        return this.flags;
      }
      set
      {
        this.flags = value;
      }
    }

    public long ZipFileIndex
    {
      get
      {
        return this.zipFileIndex;
      }
      set
      {
        this.zipFileIndex = value;
      }
    }

    public long Offset
    {
      get
      {
        return this.offset;
      }
      set
      {
        this.offset = value;
      }
    }

    public int ExternalFileAttributes
    {
      get
      {
        if ((this.known & ZipEntry.Known.ExternalAttributes) == ZipEntry.Known.None)
          return -1;
        else
          return this.externalFileAttributes;
      }
      set
      {
        this.externalFileAttributes = value;
        this.known |= ZipEntry.Known.ExternalAttributes;
      }
    }

    public int VersionMadeBy
    {
      get
      {
        return (int) this.versionMadeBy & (int) byte.MaxValue;
      }
    }

    public bool IsDOSEntry
    {
      get
      {
        if (this.HostSystem != 0)
          return this.HostSystem == 10;
        else
          return true;
      }
    }

    public int HostSystem
    {
      get
      {
        return (int) this.versionMadeBy >> 8 & (int) byte.MaxValue;
      }
      set
      {
        this.versionMadeBy &= (ushort) byte.MaxValue;
        this.versionMadeBy |= (ushort) ((value & (int) byte.MaxValue) << 8);
      }
    }

    public int Version
    {
      get
      {
        if ((int) this.versionToExtract != 0)
          return (int) this.versionToExtract;
        int num = 10;
        if (this.CentralHeaderRequiresZip64)
          num = 45;
        else if (CompressionMethod.Deflated == this.method)
          num = 20;
        else if (this.IsDirectory)
          num = 20;
        else if (this.IsCrypted)
          num = 20;
        else if (this.HasDosAttributes(8))
          num = 11;
        return num;
      }
    }

    public bool CanDecompress
    {
      get
      {
        if (this.Version <= 45 && (this.Version == 10 || this.Version == 11 || (this.Version == 20 || this.Version == 45)))
          return this.IsCompressionMethodSupported();
        else
          return false;
      }
    }

    public bool LocalHeaderRequiresZip64
    {
      get
      {
        bool flag = this.forceZip64_;
        if (!flag)
        {
          ulong num = this.compressedSize;
          if ((int) this.versionToExtract == 0 && this.IsCrypted)
            num += 12UL;
          flag = (this.size >= (ulong) uint.MaxValue || num >= (ulong) uint.MaxValue) && ((int) this.versionToExtract == 0 || (int) this.versionToExtract >= 45);
        }
        return flag;
      }
    }

    public bool CentralHeaderRequiresZip64
    {
      get
      {
        if (!this.LocalHeaderRequiresZip64)
          return this.offset >= (long) uint.MaxValue;
        else
          return true;
      }
    }

    public long DosTime
    {
      get
      {
        if ((this.known & ZipEntry.Known.Time) == ZipEntry.Known.None)
          return 0L;
        else
          return (long) this.dosTime;
      }
      set
      {
        this.dosTime = (uint) value;
        this.known |= ZipEntry.Known.Time;
      }
    }

    public DateTime DateTime
    {
      get
      {
        uint num1 = Math.Min(59U, (uint) (2 * ((int) this.dosTime & 31)));
        uint num2 = Math.Min(59U, this.dosTime >> 5 & 63U);
        uint num3 = Math.Min(23U, this.dosTime >> 11 & 31U);
        uint num4 = Math.Max(1U, Math.Min(12U, this.dosTime >> 21 & 15U));
        uint num5 = (uint) (((int) (this.dosTime >> 25) & (int) sbyte.MaxValue) + 1980);
        int day = Math.Max(1, Math.Min(DateTime.DaysInMonth((int) num5, (int) num4), (int) (this.dosTime >> 16) & 31));
        return new DateTime((int) num5, (int) num4, day, (int) num3, (int) num2, (int) num1);
      }
      set
      {
        uint num1 = (uint) value.Year;
        uint num2 = (uint) value.Month;
        uint num3 = (uint) value.Day;
        uint num4 = (uint) value.Hour;
        uint num5 = (uint) value.Minute;
        uint num6 = (uint) value.Second;
        if (num1 < 1980U)
        {
          num1 = 1980U;
          num2 = 1U;
          num3 = 1U;
          num4 = 0U;
          num5 = 0U;
          num6 = 0U;
        }
        else if (num1 > 2107U)
        {
          num1 = 2107U;
          num2 = 12U;
          num3 = 31U;
          num4 = 23U;
          num5 = 59U;
          num6 = 59U;
        }
        this.DosTime = (long) ((uint) (((int) num1 - 1980 & (int) sbyte.MaxValue) << 25 | (int) num2 << 21 | (int) num3 << 16 | (int) num4 << 11 | (int) num5 << 5) | num6 >> 1);
      }
    }

    public string Name
    {
      get
      {
        return this.name;
      }
    }

    public long Size
    {
      get
      {
        if ((this.known & ZipEntry.Known.Size) == ZipEntry.Known.None)
          return -1L;
        else
          return (long) this.size;
      }
      set
      {
        this.size = (ulong) value;
        this.known |= ZipEntry.Known.Size;
      }
    }

    public long CompressedSize
    {
      get
      {
        if ((this.known & ZipEntry.Known.CompressedSize) == ZipEntry.Known.None)
          return -1L;
        else
          return (long) this.compressedSize;
      }
      set
      {
        this.compressedSize = (ulong) value;
        this.known |= ZipEntry.Known.CompressedSize;
      }
    }

    public long Crc
    {
      get
      {
        if ((this.known & ZipEntry.Known.Crc) == ZipEntry.Known.None)
          return -1L;
        else
          return (long) this.crc & (long) uint.MaxValue;
      }
      set
      {
        if (((long) this.crc & -4294967296L) != 0L)
          throw new ArgumentOutOfRangeException("value");
        this.crc = (uint) value;
        this.known |= ZipEntry.Known.Crc;
      }
    }

    public CompressionMethod CompressionMethod
    {
      get
      {
        return this.method;
      }
      set
      {
        if (!ZipEntry.IsCompressionMethodSupported(value))
          throw new NotSupportedException("Compression method not supported");
        this.method = value;
      }
    }

    public byte[] ExtraData
    {
      get
      {
        return this.extra;
      }
      set
      {
        if (value == null)
        {
          this.extra = (byte[]) null;
        }
        else
        {
          if (value.Length > (int) ushort.MaxValue)
            throw new ArgumentOutOfRangeException("value");
          this.extra = new byte[value.Length];
          Array.Copy((Array) value, 0, (Array) this.extra, 0, value.Length);
        }
      }
    }

    public string Comment
    {
      get
      {
        return this.comment;
      }
      set
      {
        if (value != null && value.Length > (int) ushort.MaxValue)
          throw new ArgumentOutOfRangeException("value", "cannot exceed 65535");
        this.comment = value;
      }
    }

    public bool IsDirectory
    {
      get
      {
        int length = this.name.Length;
        return length > 0 && ((int) this.name[length - 1] == 47 || (int) this.name[length - 1] == 92) || this.HasDosAttributes(16);
      }
    }

    public bool IsFile
    {
      get
      {
        if (!this.IsDirectory)
          return !this.HasDosAttributes(8);
        else
          return false;
      }
    }

    public ZipEntry(string name)
      : this(name, 0, 45, CompressionMethod.Deflated)
    {
    }

    internal ZipEntry(string name, int versionRequiredToExtract)
      : this(name, versionRequiredToExtract, 45, CompressionMethod.Deflated)
    {
    }

    internal ZipEntry(string name, int versionRequiredToExtract, int madeByInfo, CompressionMethod method)
    {
      if (name == null)
        throw new ArgumentNullException("name");
      if (name.Length > (int) ushort.MaxValue)
        throw new ArgumentException("Name is too long", "name");
      if (versionRequiredToExtract != 0 && versionRequiredToExtract < 10)
        throw new ArgumentOutOfRangeException("versionRequiredToExtract");
      this.DateTime = DateTime.Now;
      this.name = name;
      this.versionMadeBy = (ushort) madeByInfo;
      this.versionToExtract = (ushort) versionRequiredToExtract;
      this.method = method;
    }

    [Obsolete("Use Clone instead")]
    public ZipEntry(ZipEntry entry)
    {
      if (entry == null)
        throw new ArgumentNullException("entry");
      this.known = entry.known;
      this.name = entry.name;
      this.size = entry.size;
      this.compressedSize = entry.compressedSize;
      this.crc = entry.crc;
      this.dosTime = entry.dosTime;
      this.method = entry.method;
      this.comment = entry.comment;
      this.versionToExtract = entry.versionToExtract;
      this.versionMadeBy = entry.versionMadeBy;
      this.externalFileAttributes = entry.externalFileAttributes;
      this.flags = entry.flags;
      this.zipFileIndex = entry.zipFileIndex;
      this.offset = entry.offset;
      this.forceZip64_ = entry.forceZip64_;
      if (entry.extra == null)
        return;
      this.extra = new byte[entry.extra.Length];
      Array.Copy((Array) entry.extra, 0, (Array) this.extra, 0, entry.extra.Length);
    }

    private bool HasDosAttributes(int attributes)
    {
      bool flag = false;
      if ((this.known & ZipEntry.Known.ExternalAttributes) != ZipEntry.Known.None && (this.HostSystem == 0 || this.HostSystem == 10) && (this.ExternalFileAttributes & attributes) == attributes)
        flag = true;
      return flag;
    }

    public void ForceZip64()
    {
      this.forceZip64_ = true;
    }

    public bool IsZip64Forced()
    {
      return this.forceZip64_;
    }

    internal void ProcessExtraData(bool localHeader)
    {
      ZipExtraData zipExtraData = new ZipExtraData(this.extra);
      if (zipExtraData.Find(1))
      {
        if (((int) this.versionToExtract & (int) byte.MaxValue) < 45)
          throw new ZipException("Zip64 Extended information found but version is not valid");
        this.forceZip64_ = true;
        if (zipExtraData.ValueLength < 4)
          throw new ZipException("Extra data extended Zip64 information length is invalid");
        if (localHeader || (long) this.size == (long) uint.MaxValue)
          this.size = (ulong) zipExtraData.ReadLong();
        if (localHeader || (long) this.compressedSize == (long) uint.MaxValue)
          this.compressedSize = (ulong) zipExtraData.ReadLong();
        if (!localHeader && this.offset == (long) uint.MaxValue)
          this.offset = zipExtraData.ReadLong();
      }
      else if (((int) this.versionToExtract & (int) byte.MaxValue) >= 45 && ((long) this.size == (long) uint.MaxValue || (long) this.compressedSize == (long) uint.MaxValue))
        throw new ZipException("Zip64 Extended information required but is missing.");
      if (zipExtraData.Find(10))
      {
        if (zipExtraData.ValueLength < 8)
          throw new ZipException("NTFS Extra data invalid");
        zipExtraData.ReadInt();
        while (zipExtraData.UnreadCount >= 4)
        {
          int num = zipExtraData.ReadShort();
          int amount = zipExtraData.ReadShort();
          if (num == 1)
          {
            if (amount < 24)
              break;
            long fileTime = zipExtraData.ReadLong();
            zipExtraData.ReadLong();
            zipExtraData.ReadLong();
            this.DateTime = DateTime.FromFileTime(fileTime);
            break;
          }
          else
            zipExtraData.Skip(amount);
        }
      }
      else
      {
        if (!zipExtraData.Find(21589))
          return;
        int valueLength = zipExtraData.ValueLength;
        if ((zipExtraData.ReadByte() & 1) == 0 || valueLength < 5)
          return;
        this.DateTime = (new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime() + new TimeSpan(0, 0, 0, zipExtraData.ReadInt(), 0)).ToLocalTime();
      }
    }

    public bool IsCompressionMethodSupported()
    {
      return ZipEntry.IsCompressionMethodSupported(this.CompressionMethod);
    }

    public object Clone()
    {
      ZipEntry zipEntry = (ZipEntry) this.MemberwiseClone();
      if (this.extra != null)
      {
        zipEntry.extra = new byte[this.extra.Length];
        Array.Copy((Array) this.extra, 0, (Array) zipEntry.extra, 0, this.extra.Length);
      }
      return (object) zipEntry;
    }

    public override string ToString()
    {
      return this.name;
    }

    public static bool IsCompressionMethodSupported(CompressionMethod method)
    {
      if (method != CompressionMethod.Deflated)
        return method == CompressionMethod.Stored;
      else
        return true;
    }

    public static string CleanName(string name)
    {
      if (name == null)
        return string.Empty;
      if (Path.IsPathRooted(name))
        name = name.Substring(Path.GetPathRoot(name).Length);
      name = name.Replace("\\", "/");
      while (name.Length > 0 && (int) name[0] == 47)
        name = name.Remove(0, 1);
      return name;
    }

    [System.Flags]
    private enum Known : byte
    {
      None = (byte) 0,
      Size = (byte) 1,
      CompressedSize = (byte) 2,
      Crc = (byte) 4,
      Time = (byte) 8,
      ExternalAttributes = (byte) 16,
    }
  }
}
