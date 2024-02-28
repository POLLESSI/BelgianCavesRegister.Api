namespace BelgianCaveRegister_Api.Dto;

public class NPersonDTO
{
    public string? Lastname { get; set; }
    public string? Firstname { get; set; }
    public DateTime BirthDate { get; set; }
    public string? Address_Street { get; set; }
    public string? Address_Nbr { get; set; }
    public string? PostalCode { get; set; }
    public string? Address_City { get; set; }
    public string? Address_Country { get; set; }
    public string? Telephone { get; set; }
    public string? Gsm { get; set; }
    public bool Active { get; set; }
}

