using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class NUserRegisterForm
    {
        [Required(ErrorMessage = "Nick name is required.")]
        [MinLength(3)]
        [MaxLength(64)]
        [DisplayName("Nick name : ")]
        public string Pseudo { get; set; }
        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress]
        [MinLength(3)]
        [MaxLength(64)]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email Address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(3)]
        [MaxLength(64)]
        [DisplayName("Password : ")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\-\.=+*@?]).*$", ErrorMessage = "The format is too simple for security.")]
        public string PasswordHash { get; set; }
        [DisplayName("Please confirm your password !")]
        [DataType(DataType.Password)]
        [Compare(nameof(PasswordHash))]
        public string SecondPassword { get; set; }

        public int? NPerson_Id { get; set; }
        public int? Role_Id { get; set; }
    }
}

