
namespace BelgianCavesRegister.Dal.Entities
{
    public class NUserDTO
    {
        public string? Pseudo { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecondPassword { get; set; }
        public string? Email { get; set; }
    }
}
