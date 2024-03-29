﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class UpdateNUserForm
    {
        public Guid NUser_Id { get; set; }
        [Required(ErrorMessage = "Nick Name is required")]
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Nick Name : ")]
        public string? Pseudo { get; set; }
        [Required(ErrorMessage = " The password is required")]
        [MinLength(8)]
        [MaxLength(64)]
        [DisplayName("Password : ")]
        [DataType(DataType.Password)]
        //[RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\-\.=+*@?]).*$", ErrorMessage = "The format is too simple for security.")]
        public string? PasswordHash { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [MinLength(8)]
        [MaxLength(64)]
        [DisplayName("Email : ")]
        public string? Email { get; set; }
        public int NPerson_Id { get; set; }
        [Required(ErrorMessage = "The rôle's Id is required")]
        [MaxLength(1)]
        [DisplayName("Rôle : ")]
        public string? Role_Id { get; set; }
    }
}

