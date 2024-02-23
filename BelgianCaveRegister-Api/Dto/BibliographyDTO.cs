namespace BelgianCaveRegister_Api.Dto;

public class BibliographyDTO
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? ISBN { get; set; }
    public string? DataType { get; set; }
    public string? Detail { get; set; }
    public bool Active { get; set; }
}

