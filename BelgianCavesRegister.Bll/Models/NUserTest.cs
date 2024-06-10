
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;

namespace BelgianCavesRegister.Bll.Models
{
    public class NUserTest
    {
    #nullable disable
        public int NUser_Id { get; set; }
        public string Pseudo { get; set; }
        public string PasswordHash { get; set; }
        public string SecondPassword { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
        public DateTime LastActiondatetime { get; set; }
        
        
        
    }
}
