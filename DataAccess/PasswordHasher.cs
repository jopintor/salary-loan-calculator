using System;
using System.Security.Cryptography;

namespace DataHelper
{
    /// <summary>
    /// Salted PBKDF2-SHA256 password hashing.
    /// Stored format: "h1$" + base64(salt) + "$" + base64(hash), 40 characters in total,
    /// so it fits in an NVARCHAR(50) Password column.
    /// </summary>
    public static class PasswordHasher
    {
        private const string Prefix = "h1$";
        private const int SaltSize = 9;      // 9 bytes  -> 12 base64 chars, no padding
        private const int HashSize = 18;     // 18 bytes -> 24 base64 chars, no padding
        private const int Iterations = 100000;

        public static string Hash(string password)
        {
            byte[] salt = new byte[SaltSize];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] hash = Derive(password, salt);
            return Prefix + Convert.ToBase64String(salt) + "$" + Convert.ToBase64String(hash);
        }

        public static bool Verify(string password, string stored)
        {
            if (string.IsNullOrEmpty(stored) || password == null) return false;

            if (!IsHashed(stored))
            {
                // Legacy account still holding a plain-text password.
                return stored == password;
            }

            string[] parts = stored.Substring(Prefix.Length).Split('$');
            if (parts.Length != 2) return false;

            byte[] salt;
            byte[] expected;
            try
            {
                salt = Convert.FromBase64String(parts[0]);
                expected = Convert.FromBase64String(parts[1]);
            }
            catch (FormatException)
            {
                return false;
            }

            byte[] actual = Derive(password, salt);
            return FixedTimeEquals(actual, expected);
        }

        public static bool IsHashed(string stored)
        {
            return stored != null && stored.StartsWith(Prefix, StringComparison.Ordinal);
        }

        private static byte[] Derive(string password, byte[] salt)
        {
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(HashSize);
            }
        }

        private static bool FixedTimeEquals(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;
            int diff = 0;
            for (int i = 0; i < a.Length; i++) diff |= a[i] ^ b[i];
            return diff == 0;
        }
    }
}

