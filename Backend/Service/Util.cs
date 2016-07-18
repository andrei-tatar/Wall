using System;
using System.Security.Cryptography;
using System.Text;

namespace Service
{
    public class Util
    {
        private static readonly SHA256 Sha256 = SHA256.Create();

        public static string GetPasswordHash(string password)
        {
            return Convert.ToBase64String(Sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        public static string UserToToken(string user)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(user));
        }

        public static string TokenToUser(string token)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(token));
        }
    }
}