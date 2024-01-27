
namespace BelgianCavesRegister.Dal.Entities
{
    public class Bibliography
    {
        public int Bibliography_Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public string? DataType { get; set; }
        public string? Detail { get; set; }
        public bool Active { get; set; }

        //public List<BibliographyDTO?> bibliographies { get; set; }

        //public class Result
        //{
        //    public List<BibliographyResult?> results { get; set; }
        //}
        //public class BibliographyResult
        //{
        //    public string Title { get; set; }
        //    public string Author { get; set; }
        //    public string Url { get; set; }
        //}
    }
}
