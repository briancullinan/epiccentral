using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace EPICCentral.Utilities.Crypto
{
    public static class Rijndael
    {
        private static readonly string Key = ConfigurationManager.AppSettings["UrlKey"] ?? "";
        private static readonly string IV = ConfigurationManager.AppSettings["UrlIV"] ?? "";

        public static string Encrypt(string requestParams)
        {
            // then encrypt and return
            if (Key == "" || IV == "")
                return String.Join("", requestParams.ToCharArray().Select(x => String.Format("{0:X}", Convert.ToByte(x))));

            var encrypted = EncryptStringToBytes(requestParams,
                                                 Key.ToCharArray().Select(x => Convert.ToByte(x)).ToArray(),
                                                 IV.ToCharArray().Select(x => Convert.ToByte(x)).ToArray());
            return String.Join("", encrypted.Select(x => String.Format("{0:X2}", x)));
        }

        public static string Decrypt(string requestParams)
        {
            if (Key == "" || IV == "")
                return String.Join("", Enumerable.Range(0, requestParams.Length / 2)
                                           .Select(x => Char.ConvertFromUtf32(Convert.ToInt32(requestParams.Substring(x * 2, 2), 16))));

            return DecryptStringFromBytes(Enumerable.Range(0, requestParams.Length / 2)
                                              .Select(x => Convert.ToByte(requestParams.Substring(x * 2, 2), 16)).ToArray(),
                                          Key.ToCharArray().Select(Convert.ToByte).ToArray(),
                                          IV.ToCharArray().Select(Convert.ToByte).ToArray());
        }

        private static IEnumerable<byte> EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("key");
            byte[] encrypted;
            // Create an RijndaelManaged object
            // with the specified key and iv.
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {

                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }


            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        private static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("key");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext;

            // Create an RijndaelManaged object
            // with the specified key and iv.
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }

    }
}
