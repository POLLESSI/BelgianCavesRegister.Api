using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelgianCavesRegister.Bll.Entities
{
    public class NUserLogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public String PasswordHash { get; set; }
    }
}
