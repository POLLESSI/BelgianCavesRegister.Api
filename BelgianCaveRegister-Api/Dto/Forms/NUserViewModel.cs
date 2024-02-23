using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class NUserViewModel
    {
        public Guid NUser_Id { get; set; }
        [Required(ErrorMessage = "The nick name is required")]
        [MinLength(3)]
        [MaxLength(64)]
        [DisplayName("Nick name : ")]
        public string? Pseudo { get; set; }
        [Required(ErrorMessage = " The password is required")]
        [MinLength(3)]
        [MaxLength(64)]
        [DisplayName("Password : ")]
        [DataType(DataType.Password)]
        //[RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\-\.=+*@?]).*$", ErrorMessage = "The format is too simple for security.")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        [MinLength(3)]
        [MaxLength(64)]
        [DisplayName("Email address : ")]
        public string? Email { get; set; }
        public bool Role_Id { get; set; }

    }
}

