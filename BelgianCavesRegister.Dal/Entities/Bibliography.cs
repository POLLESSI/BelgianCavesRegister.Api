
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

        
    }
}
