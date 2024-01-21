
namespace BelgianCavesRegister.Dal.Entities
{
    public class ScientificData
    {
        public int ScientificData_Id { get; set; }
        public string? DataType { get; set; }
        public string? DetailsData { get; set; }
        public string? ReferenceData { get; set; }
        public bool Active { get; set; }

        //public List<ScientificDataDTO> ScientificDatas { get; set; }
        //public class Result
        //{
        //    public List<ScientificDataResult> results { get; set; }
        //}
        //public class ScientificDataResult
        //{
        //    public string DataType { get; set; }
        //    public string ReferenceData { get; set; }
        //    public string Url { get; set; }
        //    public bool Active { get; set; }
        //}
    }
}



