using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelgianCavesRegister.Dal
{
    public static class Hash
    {
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public static bool VerifyPassword(string enteredpassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredpassword, hashedPassword);
        }
    }
}
