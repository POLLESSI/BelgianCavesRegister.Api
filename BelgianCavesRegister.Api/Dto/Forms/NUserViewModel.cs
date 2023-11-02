using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCavesRegister.Api.Dto.Forms
{
    public class NUserViewModel
    {
        public Guid NUser_Id { get; set; }
        [Required(ErrorMessage = "The nick name is required")]
        [MinLength(3)]
        [MaxLength(64)]
        [DisplayName("Nick name : ")]
        public string Pseudo { get; set; }
        [Required(ErrorMessage = " The password is required")]
        [MinLength(3)]
        [MaxLength(64)]
        [DisplayName("Password : ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        [MinLength(3)]
        [MaxLength(64)]
        [DisplayName("Email address ; ")]
        public string Email { get; set; }
        public bool Role_Id { get; set; }

    }
}

