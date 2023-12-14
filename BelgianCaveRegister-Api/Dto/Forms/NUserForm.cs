﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class NUserForm
    {
        
        public Guid NUser_Id { get; set; }
        [Required(ErrorMessage = "Nick Name is required")]
        [MinLength(3)]
        [MaxLength(64)]
        [DisplayName("Nick Name : ")]
        public String? Pseudo {  get; set; }
        [Required(ErrorMessage = "The Password is required")]
        [MinLength(6)]
        [MaxLength(64)]
        [DisplayName("Password : ")]
        public Byte PasswordHash { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [MinLength(3)]
        [MaxLength(64)]
        [DisplayName("Email : ")]
        //public Guid SecurityStamp { get; set; }
        //[Required]
        public string? Email { get; set; }
        [Required(ErrorMessage = "The Person's Id is required")]
        [DisplayName("Person's Id : ")]
        public int NPerson_Id { get; set; }
        [Required(ErrorMessage = "The rôle's Id is required")]
        [DisplayName("Rôle : ")]
        public int Role_Id { get; set; }
    }
}
