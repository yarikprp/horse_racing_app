using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace horse_racing_app.Validation
{
    internal class Verification
    {
        public static string GetSHA512Hash(string input)
        {
            SHA512CryptoServiceProvider cryptoServiceProvider = new SHA512CryptoServiceProvider();

            byte[] data = cryptoServiceProvider.ComputeHash(Encoding.Default.GetBytes(input));

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }

            return sb.ToString();
        }

        public static bool VerifySHA512Hash(string input, string hash)
        {
            string hashOfInput = GetSHA512Hash(input);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (comparer.Compare(hashOfInput, hash) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
