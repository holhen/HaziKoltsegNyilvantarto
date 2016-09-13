using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HáziKöltségNyilvántartó
{
    class PasswordHelper
    {
        private static string EncryptPassword(byte[] password, byte[] salt)
        {
            PasswordDeriveBytes passwordGenerator = new PasswordDeriveBytes(password, salt);
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            var hashedPassword = passwordGenerator.CryptDeriveKey("TripleDES", "SHA1", 192, tdes.IV);
            return Convert.ToBase64String(hashedPassword.Concat(salt).ToArray());
        }
        public static string EncryptPassword(string password)
        {
            RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
            var salt = new byte[6];
            randomNumberGenerator.GetBytes(salt);
            return EncryptPassword(Encoding.UTF8.GetBytes(password), salt);
        }

        public static bool CheckPassword(string password, string hash)
        {
            var pwdBytes = Convert.FromBase64String(hash);
            var pwdHashBytes = pwdBytes.Take(pwdBytes.Length - 6).ToArray();
            var salt = pwdBytes.Skip(pwdHashBytes.Length).ToArray();
            var hashToCheck = EncryptPassword(Encoding.UTF8.GetBytes(password), salt);
            return hash == hashToCheck;
        }

        public static bool StringChecker(string password)
        {
            bool lowercase = false;
            bool uppercase = false;
            bool number = false;

            if (password.Length < 8)
                return false;

            foreach (char c in password)
            {
                if (char.IsLower(c))
                    lowercase = true;
                if (char.IsUpper(c))
                    uppercase = true;
                if (char.IsDigit(c))
                    number = true;
            }

            if (lowercase == true && uppercase == true && number == true)
                return true;
            else return false;
        }
    }
}
