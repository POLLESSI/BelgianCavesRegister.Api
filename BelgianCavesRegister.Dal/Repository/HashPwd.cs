using System.Security.Cryptography;
using System.Text;

namespace BelgianCaveRegister_Api.Tools
{
    public class HashPwd
    {
        static string HashPassword(string passwordHash, byte[] salt)
        {
            using (var sha512 = new SHA512Managed())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(passwordHash);
                byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];

                // Concatene password et salt
                Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
                Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

                // Hash la concatination du password et salt
                byte[] hashedBytes = sha512.ComputeHash(saltedPassword);

                // Concate le salt et hache le password pour le stockage
                byte[] hashedPasswordWithSalt = new byte[hashedBytes.Length + salt.Length];
                Buffer.BlockCopy(salt, 0, hashedPasswordWithSalt, 0, salt.Length);
                Buffer.BlockCopy(hashedBytes, 0, hashedPasswordWithSalt, salt.Length, hashedBytes.Length);

                return Convert.ToBase64String(hashedPasswordWithSalt);
            }
        }
        static byte[] GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[32]; // Adjust the size based on your security requirements
                rng.GetBytes(salt);
                return salt;
            }
        }
    }
}
