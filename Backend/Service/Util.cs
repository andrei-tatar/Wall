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
    }
}