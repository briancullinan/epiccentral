using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;
using log4net;

namespace EPICCentral.Utilities.Treatment
{
    public sealed class ImageCompressionUtility
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ImageCompressionUtility));

        //use for thread safe locking
        private static readonly object _lock = new object();
        private const int BUFFER_SIZE = 4096;
        /// <summary>
        /// Creates a zipped file containing multiple entries.
        /// </summary>
        /// <param name="list">A list of object to place in the zip</param>
        /// <returns>A byte array repreenting the zip file</returns>
        public static byte[] CreateZipFile(System.Collections.ArrayList list)
        {
            lock (_lock)
            {
                // 'using' statements gaurantee the stream is closed properly its exception safe.
                MemoryStream memoryStream = new MemoryStream();
                using (ZipOutputStream s = new ZipOutputStream(memoryStream))
                {
                    s.SetLevel(9); //  compression level
                    byte[] buffer = new byte[BUFFER_SIZE];
                    foreach (ImageObjectData data in list)
                    {
                        // Using GetFileName makes the result compatible with XP
                        // as the resulting path is not absolute.
                        ZipEntry entry = new ZipEntry(data.FileName);
                        Log.Debug("Zip file entry: " + data.FileName);
                        // Setup the entry data as required.
                        // Crc and size are handled by the library for seakable streams
                        // so no need to do them here.
                        // Could also use the last write time or similar for the file.
                        entry.DateTime = DateTime.UtcNow;
                        s.PutNextEntry(entry);

                        using (MemoryStream fs = new MemoryStream(data._ImageData))
                        {
                            // Using a fixed size buffer here makes no noticeable difference for output
                            // but keeps a lid on memory usage.
                            int sourceBytes;
                            do
                            {
                                sourceBytes = fs.Read(buffer, 0, buffer.Length);
                                s.Write(buffer, 0, sourceBytes);
                            } while (sourceBytes > 0);
                        }
                    }
                    // Finish/Close arent needed strictly as the using statement does this automatically
                    // Finish is important to ensure trailing information for a Zip file is appended.  Without this
                    // the created file would be invalid.
                    s.Finish();
                    s.Close();
                    byte[] arr = memoryStream.ToArray();
                    memoryStream.Close();
                    return arr;
                    // Close is important to wrap things up and unlock the file.
                }
            }
        }

        /// <summary>
        /// Uses Zip compression accepting byte array stored in the DB usually.
        /// </summary>
        /// <param name="ZipedBytes">Zipped data byte array</param>
        /// <param name="DirectoryName">Directory location for zipped files</param>
        /// <returns>A list of ImageObjectData objects</returns>
        public static List<ImageObjectData> UnzipByteArray(byte[] ZipedBytes)
        {

            lock (_lock)
            {
                List<ImageObjectData> imageList = new List<ImageObjectData>();
                ImageObjectData tempHolder;
                MemoryStream memStream = new MemoryStream(ZipedBytes);
                using (ZipInputStream s = new ZipInputStream(memStream))
                {

                    ZipEntry theEntry;
                    while ((theEntry = s.GetNextEntry()) != null)
                    {

                        Console.WriteLine(theEntry.Name);

                        string fileName = Path.GetFileName(theEntry.Name);

                        if (fileName != String.Empty)
                        {
                            MemoryStream streamWriter = new MemoryStream();
                            int size;
                            byte[] data = new byte[BUFFER_SIZE];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }
                            Image img = null;
                            try
                            {
                                if (streamWriter.Length > 0)
                                    img = Image.FromStream(streamWriter);
                            }
                            catch (Exception ex)
                            {
                                Log.Debug(ex.Message);
                            }
                            tempHolder = new ImageObjectData(theEntry.Name, img, ImageFormat.Bmp);
                            imageList.Add(tempHolder);
                        }
                    }
                }
                memStream.Close();
                return imageList;
            }
        }


        #region ZIP HELPER CLASS

        public class ImageObjectData
        {
            private readonly int fileLen;
            private readonly byte[] _imageData;
            private readonly Bitmap image;
            private readonly string fileName;
            private readonly ImageFormat containsImageFormat;

            public ImageObjectData(string FileName, Image Image, ImageFormat IsOfFormat)
            {
                fileName = FileName;
                containsImageFormat = IsOfFormat;
                image = (Bitmap)Image;
                _imageData = ImageToByteArray(image, containsImageFormat);
                fileLen = _imageData.Length;
            }
            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="FileName">Name of the file contained</param>
            /// <param name="ImageDataContent">byte array with image information</param>
            /// <param name="IsOfFormat">Image format .bmp .jpg and other </param>
            public ImageObjectData(string FileName, byte[] ImageDataContent, ImageFormat IsOfFormat)
            {
                fileName = FileName;
                containsImageFormat = IsOfFormat;
                _imageData = ImageDataContent;
                fileLen = _imageData.Length;
                image = (Bitmap)CreateImage(_imageData);
            }
            public virtual Bitmap Image
            {
                get
                {
                    return image;
                }
            }

            public virtual int ImageDataLen
            {
                get
                {
                    return fileLen;
                }
            }
            public virtual byte[] _ImageData
            {
                get
                {
                    return _imageData;
                }
            }
            public virtual string FileName
            {
                get
                {
                    return fileName;
                }
            }
            public virtual ImageFormat ContainsImageFormat
            {
                get
                {
                    return ContainsImageFormat;
                }
            }

            public static byte[] ImageToByteArray(Image img, ImageFormat format)
            {
                byte[] returnValue = null;
                System.Threading.Monitor.Enter(img);

                MemoryStream memoryStream = null;
                try
                {
                    memoryStream = new MemoryStream();
                    Bitmap bitmap = new Bitmap(img);
                    bitmap.Save(memoryStream, format);
                    bitmap.Dispose();
                    memoryStream.Dispose();
                    returnValue = memoryStream.ToArray();
                }
                catch (Exception ex)
                {
                    Log.Debug(ex.Message);
                }
                finally
                {
                    System.Threading.Monitor.Exit(img);
                    if (memoryStream != null)
                        memoryStream.Close();
                }
                return returnValue;
            }

            public static Image CreateImage(byte[] ImageData)
            {
                using (MemoryStream memoryStrem = new MemoryStream(ImageData))
                {
                    return System.Drawing.Image.FromStream(memoryStrem);
                }
            }

        }
        #endregion

        public static string GetPathName(string FileName)
        {
            if (FileName.StartsWith("_"))
                return @"\withfilter\" + FileName.Remove(0, 1);
            return @"\withoutfilter\" + FileName;
        }

        /// <summary>
        /// Recursive method to delete a folder and all of 
        /// its contents.
        /// </summary>
        /// <param name="target_dir">The folder to delete</param>
        /// <returns>Boolean indicating success or failure</returns>
        public static bool DeleteDirectory(string target_dir)
        {
            const bool result = true;
            string[] files;
            string[] dirs;

            try
            {
                Log.Debug("[DeleteDirectory] Directory to process-> " + target_dir);
                if (Directory.Exists(target_dir))
                {
                    files = Directory.GetFiles(target_dir);
                    dirs = Directory.GetDirectories(target_dir);
                    foreach (string file in files)
                    {
                        File.SetAttributes(file, FileAttributes.Normal);
                        File.Delete(file);
                    }
                    foreach (string dir in dirs)
                    {
                        DeleteDirectory(dir);
                    }
                    Directory.Delete(target_dir, true);
                }
            }
            catch
            {
                // Exception is irrelvant, can eat it.
                Log.Debug("[DeleteDirectory] Could not delete-> " + target_dir);
            }
            return result;
        }
    }

}
