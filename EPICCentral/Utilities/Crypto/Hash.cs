using System.Security.Cryptography;
using System.Text;

namespace EPICCentral.Utilities.Crypto
{
	public class Hash
	{
		public static byte[] GetHash(string data)
		{
			return new SHA512Cng().ComputeHash(Encoding.ASCII.GetBytes(data));
		}

		public static string GetHashString(string data)
		{
			StringBuilder sb = new StringBuilder(128);		// SHA-512 hashes are 512 bits = 64 binary bytes = 128 hex (nibble) chars
			foreach (byte b in GetHash(data))
				sb.AppendFormat("{0:x2}", b);
			return sb.ToString();
		}
	}
}