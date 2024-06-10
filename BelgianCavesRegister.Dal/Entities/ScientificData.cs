
namespace BelgianCavesRegister.Dal.Entities
{
    public class ScientificData
    {
        public int ScientificData_Id { get; set; }
        public string? DataType { get; set; }
        public string? DetailsData { get; set; }
        public string? ReferenceData { get; set; }
        public int Site_Id { get; set; }
        public bool Active { get; set; }
    }
}



