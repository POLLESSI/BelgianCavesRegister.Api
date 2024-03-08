using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class NUserLoginForm
    {
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress]
        [MinLength(8)]
        [MaxLength(64)]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email Address.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [MinLength(8)]
        [MaxLength(64)]
        [DisplayName("Password : ")]
        [DataType(DataType.Password)]
        public string? PasswordHash { get; set; }
    }
}

