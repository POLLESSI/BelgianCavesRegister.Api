namespace BelgianCaveRegister_Api.Models
{
    public class NUserDTO
    {
        public string? Pseudo { get; set; }
        public Byte? PasswordHash { get; set; }
        public string? Email { get; set; }
        public int Role_Id { get; set; }
        public int NPerson_Id { get; set; }
        public bool Active { get; set; }
    }
}

