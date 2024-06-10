using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class ScientificDataRegisterForm
    {
        [Required(ErrorMessage = "The type of the datas is required")]
        [MinLength(2)]
        [MaxLength(128)]
        [DisplayName("Type of datas")]
        public string? DataType { get; set; }
        [Required(ErrorMessage = "The details of the datas is required")]
        [MinLength(2)]
        [MaxLength(512)]
        [DisplayName("Datas details")]
        public string? DetailsData { get; set; }
        [Required(ErrorMessage = " the reference of the datas is required")]
        [MinLength(2)]
        [MaxLength(256)]
        [DisplayName("references of the datas")]
        public string? ReferenceData { get; set; }
        [Required]
        [DisplayName("Site Id : ")]
        public int Site_Id { get; set; }
    }
}
