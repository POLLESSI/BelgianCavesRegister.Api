using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class BibliographyRegisterForm
    {
        [Required(ErrorMessage = "Title is required")]
        [MinLength(3)]
        [MaxLength(64)]
        [DisplayName("Title")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Author is required")]
        [MinLength(3)]
        [MaxLength(32)]
        [DisplayName("Author")]
        public string? Author { get; set; }
        [Required(ErrorMessage = "ISBN is required")]
        [MinLength(12)]
        [MaxLength(16)]
        [DisplayName("ISBN")]
        public string? ISBN { get; set; }
        [Required(ErrorMessage = "Type of datas is required")]
        [MinLength(1)]
        [MaxLength(32)]
        [DisplayName("Type of data")]
        public string? DataType { get; set; }
        [Required(ErrorMessage = "the details of this bibliography is required")]
        [MinLength(3)]
        [MaxLength(512)]
        [DisplayName("Details")]
        public string? Detail { get; set; }
        [Required]
        [DisplayName("Site Id : ")]
        public int Site_Id { get; set; }
    }
}
