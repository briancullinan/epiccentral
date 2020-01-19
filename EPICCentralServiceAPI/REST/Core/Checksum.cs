using System.IO;
using System.Security.Cryptography;

namespace EPICCentralServiceAPI.REST.Core
{
	/// <summary>
	/// Simple static utility class for computing and validating checksums for a
	/// set of data.
	/// </summary>
	public static class Checksum
	{
		private static readonly char[] HexDigitChars = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };

		/// <summary>
		/// Compute a checksum (MD5 hash) for all the data in the specified
		/// <see cref="Stream"/>.
		/// Be sure the current position of the <code>Stream</code> is correct prior
		/// to invocation.
		/// The checksum is returned as a string of hex digits that represent the
		/// value of the computed binary checksum.
		/// </summary>
		/// <param name="stream">a <code>Stream</code> to read for the data</param>
		/// <returns>string of ASCII hex digits representing the checksum</returns>
		public static string Compute(Stream stream)
		{
			// Compute the checksum and then convert it to a string of hex characters.
			return ConvertToHexString(MD5.Create().ComputeHash(stream));
		}

		/// <summary>
		/// Compute a checksum (MD5 hash) for all the data in the specified byte array.
		/// The checksum is returned as a string of hex digits that represent the
		/// value of the computed binary checksum.
		/// </summary>
		/// <param name="data">the data on which the checksum is computed</param>
		/// <returns>string of ASCII hex digits representing the checksum</returns>
		public static string Compute(byte[] data)
		{
			// Compute the checksum and then convert it to a string of hex characters.
			return ConvertToHexString(MD5.Create().ComputeHash(data));
		}

		/// <summary>
		/// Validate the recomputed checksum (MD5 hash) over the data in the specified
		/// <see cref="Stream"/> matches the specified checksum.
		/// </summary>
		/// <param name="stream">a <code>Stream</code> to read for the data</param>
		/// <param name="checksum">the expected checksum for the data</param>
		/// <returns><code>true</code> if the recomputed checksum matches the specified
		///		checksum; <code>false</code> if it does not match</returns>
		public static bool Validate(Stream stream, string checksum)
		{
			// Compute the checksum and then compare it to the input checksum.
			return checksum == Compute(stream);
		}

		/// <summary>
		/// Validate the recomputed checksum (MD5 hash) over the data in the specified
		/// byte array matches the specified checksum.
		/// </summary>
		/// <param name="data">the data on which the checksum is computed</param>
		/// <param name="checksum">the expected checksum for the data</param>
		/// <returns><code>true</code> if the recomputed checksum matches the specified
		///		checksum; <code>false</code> if it does not match</returns>
		public static bool Validate(byte[] data, string checksum)
		{
			// Compute the checksum and then compare it to the input checksum.
			return checksum == Compute(data);
		}

		/// <summary>
		/// Convert the specified set of hashed bytes to an ASCII string.
		/// Each byte of the hash is converted to two hex digit characters (0-9, a-f).
		/// </summary>
		/// <param name="hash">byte array containing the hash value</param>
		/// <returns>string representation of the byte array</returns>
		private static string ConvertToHexString(byte[] hash)
		{
			char[] hexChars = new char[hash.Length * 2];
			int i = 0;
			foreach (byte b in hash)
			{
				hexChars[i++] = HexDigitChars[b & 0xf];
				hexChars[i++] = HexDigitChars[(b >> 4) & 0xf];
			}
			return new string(hexChars);
		}
	}
}
