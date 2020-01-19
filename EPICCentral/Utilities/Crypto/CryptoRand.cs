using System;
using System.Security.Cryptography;

namespace EPICCentral.Utilities.Crypto
{
	public static class CryptoRand
	{
		private static readonly RNGCryptoServiceProvider Provider;

		static CryptoRand()
		{
			Provider = new RNGCryptoServiceProvider();
		}

		public static int Next(int max)
		{
			return Next(0, max);
		}

		public static int Next(int min, int max)
		{
			return (int)Next((long)min, (long)max);
		}

		public static long Next(long max)
		{
			return Next(0, max);
		}

		public static long Next(long min, long max)
		{
			if (max < 0)
				throw new ArgumentOutOfRangeException("max");
			if (min < 0)
				throw new ArgumentOutOfRangeException("min");

			return (long)Next((ulong)min, (ulong)max);
		}

		public static ulong Next(ulong max)
		{
			return Next(0, max);
		}

		public static ulong Next(ulong min, ulong max)
		{
			if (max < min)
				throw new ArgumentException("Min value must be less than max value", "min");

			if (min == max)
				return min;

			max = max - min;

			ulong value;
			do
			{
				byte[] random = GetRandom();
				value = BitConverter.ToUInt64(random, 0);
			} while (!Pass(value, max));

			value = value % max;

			return value + min;
		}

		/// <summary>
		/// Is the value in the range of 0 to N * max, where N * max is less than int.MaxValue
		/// and (N + 1) * max is greater than int.MaxValue?
		/// </summary>
		/// <param name="value">potential random value</param>
		/// <param name="max">maximum acceptable value</param>
		/// <returns>true if the value passes the check, false if not</returns>
		private static bool Pass(ulong value, ulong max)
		{
			ulong fullSets = ulong.MaxValue / max;
			return value < fullSets * max;
		}

		private static byte[] GetRandom()
		{
			byte[] random = new byte[8];
			Provider.GetBytes(random);
			return random;
		}
	}
}
