using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class NUserForm
    {
    #nullable disable
        [Required(ErrorMessage = "Nick name is required")]
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Nick Name : ")]
        public string Pseudo { get; set; }
        [Required(ErrorMessage = "The Password is required")]
        [MinLength(8)]
        [MaxLength(4000)]
        [DataType(DataType.Password)]
        [DisplayName("Password : ")]
        //[RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\-\.=+*@?]).*$", ErrorMessage = "The format is too simple for security.")]
        public string PasswordHash { get; set; }
        //[DisplayName("Security Stamp : ")]
        //public Guid SecurityStamp { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [MinLength(8)]
        [MaxLength(64)]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email : ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "The Person's Id is required")]
        [DisplayName("Person's Id : ")]
        public int NPerson_Id { get; set; }
        [Required(ErrorMessage = "The rôle's Id is required")]
        [MaxLength(1)]
        public string Role_Id { get; set;}
    }
}
