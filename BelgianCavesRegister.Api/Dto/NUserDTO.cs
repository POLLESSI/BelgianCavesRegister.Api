﻿namespace BelgianCavesRegister.Api.Models
{
    public class NUserDTO
    {
        public Guid NUser_Id { get; set; }
        public string Pseudo { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public int Role_Id { get; set; }
        public int NPerson_Id { get; set; }
        public bool Active { get; set; }
    }
}

