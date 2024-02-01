using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HiredFirst.Domain.Helpers
{
    public static class TokenGenerator
    {
        public static string GenerateUniqueToken(int length = 32)
        {
            const string allowedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[length];

                rng.GetBytes(randomBytes);

                char[] chars = new char[length];

                for (int i = 0; i < length; i++)
                {
                    int index = randomBytes[i] % allowedChars.Length;
                    chars[i] = allowedChars[index];
                }

                return new string(chars);
            }
        }
    }
}
