using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class UpdateBibliographyForm
    {
        [Required(ErrorMessage = "Id is required")]
        [DisplayName("Bibliography Id")]
        public int Bibliography_Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [MinLength(3)]
        [MaxLength(32)]
        [DisplayName("Title")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Author is required")]
        [MinLength(3)]
        [MaxLength(32)]
        [DisplayName("Author")]
        public string? Author { get; set; }
        [Required(ErrorMessage = "ISBN is required")]
        [MinLength(13)]
        [DisplayName("ISBN")]
        public string? ISBN { get; set; }
        [Required(ErrorMessage = "Type of data is required")]
        [MinLength(3)]
        [MaxLength(64)]
        [DisplayName("Type of data")]
        public string? DataType { get; set; }
        [Required(ErrorMessage = "The details of this bibliography is required")]
        [MinLength(3)]
        [MaxLength(512)]
        [DisplayName("Details")]
        public string? Detail { get; set; }
    }
}

