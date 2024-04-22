using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelgianCavesRegister.Bll.Models
{
    public class NUserLogin
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [MaxLength(64)]
        [DisplayName("Email : ")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(8)]
        [MaxLength(64)]
        [DisplayName("Password : ")]
        public string? PasswordHash { get; set; }
    }
}
