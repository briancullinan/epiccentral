using System;

namespace EPICCentral.Utilities.Crypto
{
	public static class KeyGen
	{
		private static readonly char[] Characters;

		static KeyGen()
		{
			const string digits = "0123456789";
			const string alphaLower = "abcdefghijklmnopqrstuvwxyz";
			const string alphaUpper = "ABCDEFGHIJKLMONPQRSTUVWZYZ";
			const string specials = ".,/?;[]{}|()-_+=*&^%$#@~";			// No colon! Should be okay in basic auth password, but it isn't.
			const string all = digits + alphaLower + alphaUpper + specials;
			Characters = all.ToCharArray();
		}

		public static string NextKey(int length)
		{
			return NextKey(length, length);
		}

		public static string NextKey(int minLength, int maxLength)
		{
			if (minLength <= 0)
				throw new ArgumentOutOfRangeException("minLength");
			if (maxLength <= 0 || maxLength > 1024)
				throw new ArgumentOutOfRangeException("maxLength");
			if (maxLength < minLength)
				throw new ArgumentException("Minimum length must be less than or equal to maximum length", "minLength");

			int length = minLength == maxLength ? minLength : CryptoRand.Next(minLength, maxLength + 1);

			char[] key = new char[length];
			for (int i = 0; i < length; i++)
				key[i] = Characters[CryptoRand.Next(Characters.Length)];

			return new string(key);
		}
	}
}
