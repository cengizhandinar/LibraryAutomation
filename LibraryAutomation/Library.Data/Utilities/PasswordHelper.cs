using System;
using System.Security.Cryptography;
using System.Text;

namespace Library.Data.Utilities
{
    /// <summary>
    /// Projemiz EntityFramework Core tabanlı olmadığı için kullanıcı işlemlerinde Identity yapısını kullanamıyoruz.
    /// Bu nedenle Identity yapısının sağladığı password hash işlemini burada metot olarak gerçekleştiriyoruz.
    /// </summary>
    public static class PasswordHelper
    {
        private const string Hash = "#1$*@£&";

        /// <summary>
        /// Aldığı parametreyi Security.Cryptography kütüphanesi yardımı ile şifreleyerek geriye string bir değer döndürür
        /// </summary>
        public static string Encrypt(string password)
        {
            var data = Encoding.UTF8.GetBytes(password);
            using (var md5 = new MD5CryptoServiceProvider())
            {
                var keys = md5.ComputeHash(Encoding.UTF8.GetBytes(Hash));
                using (var tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    var transform = tripDes.CreateEncryptor();
                    var results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }

        /// <summary>
        /// Aldığı parametreyi Security.Cryptography kütüphanesi yardımı ile dönüştürerek verilen parametrenin dönüştürülmüş string karşılığını döner.
        /// </summary>
        public static string Decrypt(string createdPassword)
        {
            var data = Convert.FromBase64String(createdPassword);
            using (var md5 = new MD5CryptoServiceProvider())
            {
                var keys = md5.ComputeHash(Encoding.UTF8.GetBytes(Hash));
                using (var tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    var transform = tripDes.CreateDecryptor();
                    var results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Encoding.UTF8.GetString(results);
                }
            }
        }
    }
}