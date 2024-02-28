namespace BelgianCaveRegister_Api.Dto;

public class NUserDTO
{
    public string? Pseudo { get; set; }
    public string? PasswordHash { get; set; }
    public string? Email { get; set; }
    public string? Role_Id { get; set; }
    public int NPerson_Id { get; set; }
    public bool Active { get; set; }
}

