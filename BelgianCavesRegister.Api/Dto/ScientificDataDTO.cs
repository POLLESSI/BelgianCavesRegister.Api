namespace BelgianCavesRegister.Api.Models
{
    public class ScientificDataDTO
    {
        public int ScientificData_Id { get; set; }
        public string DataType { get; set; }
        public string DetailData { get; set; }
        public string ReferenceData { get; set; }
        public bool Active { get; set; }
    }
}

