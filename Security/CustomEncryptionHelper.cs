using System.Security.Cryptography;
using System.Text;

namespace CrudEFbyMigration.Security
{
    public static class CustomEncryptionHelper
    {
        private const string DefaultKey = "vN7KxB2uZ9LqJ1HT"; // Should be 16/24/32 bytes for AES
        private static readonly byte[] KeyBytes = Encoding.UTF8.GetBytes(DefaultKey);
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("1234567890abcdef"); // Also 16 bytes

        public static string Encrypt(string plainText)
        {
            using var aes = Aes.Create();
            aes.Key = KeyBytes;
            aes.IV = IV;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            var plainBytes = Encoding.UTF8.GetBytes(plainText);

            var encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            return Convert.ToBase64String(encryptedBytes);
        }

        public static string Decrypt(string encryptedText)
        {
            using var aes = Aes.Create();
            aes.Key = KeyBytes;
            aes.IV = IV;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            var encryptedBytes = Convert.FromBase64String(encryptedText);

            var decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }
}
