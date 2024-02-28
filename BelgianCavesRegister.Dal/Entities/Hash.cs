using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelgianCavesRegister.Dal.Entities
{
    public static class Hash
    {
        public static string HashPassword(string passwordHash)
        {
            return BCrypt.Net.BCrypt.HashPassword(passwordHash);
        }
        public static bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
        }
    }
}
