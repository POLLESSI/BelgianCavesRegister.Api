namespace BelgianCaveRegister_Api.Dto;

public class SiteDTO
{
    public string? Site_Name { get; set; }
    public string? Site_Description { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public string? Length { get; set; }
    public string? Depth { get; set; }
    public string? AccessRequirement { get; set; }
    public string? PracticalInformation { get; set; }
    public bool Active { get; set; }
}

