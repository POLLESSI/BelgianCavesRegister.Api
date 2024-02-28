using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelgianCavesRegister.Bll.Models
{
    public class NUserModel
    {
        public Guid NUser_Id { get; set; }
        public string? Pseudo { get; set; }
        public string? PasswordHash { get; set;}
        public Guid SecurityStamp { get; set; }
        public string? Email { get; set; }
        public int? NPerson_Id { get; set; }
        public string? Role_Id { get; set; }
    }
}
