namespace BelgianCavesRegister.Api.Dto.Forms
{
    public class UpdateBibliographyForm
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int ISBN { get; set; }
        public string DataType { get; set; }
        public string Detail { get; set; }
    }
}

