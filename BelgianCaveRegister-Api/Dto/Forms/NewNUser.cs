using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class NewNUser
    {
        [Required(ErrorMessage = "Nick name is required")]
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Nick name : ")]
        public string? Pseudo { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        [MinLength(8)]
        [MaxLength(64)]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email Address : ")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(8)]
        [MaxLength(64)]
        [DataType(DataType.Password)]
        [DisplayName("Password : ")]
        public string? PasswordHash { get; set; }
        [Required(ErrorMessage = "Please confirm your password !!! ")]
        [DisplayName("Second password : ")]
        [DataType(DataType.Password)]
        [Compare(nameof(PasswordHash))]
        public string? SecondPassword { get; set; }
        [Required(ErrorMessage = "Person's Id is required ! ")]
        [DisplayName("Person's Id : ")]
        public int NPerson_Id { get; set; }
        [Required(ErrorMessage = "Rôle's Id is required ! ")]
        [MaxLength(1)]
        [DisplayName("Rôle's Id : ")]
        public string? Role_Id { get; set; }
    }
}
