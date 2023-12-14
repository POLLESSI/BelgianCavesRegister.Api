using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class NewNUser
    {
        [Required(ErrorMessage = "Nick name is required")]
        [MinLength(3)]
        [MaxLength(64)]
        [DisplayName("Nick name : ")]
        public string? Pseudo { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        [MinLength(3)]
        [MaxLength(64)]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(3)]
        [MaxLength(64)]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string? PasswordHash { get; set; }
    }
}

