using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class ScientificDataRegisterForm
    {
        [Required(ErrorMessage = "The type of the datas is required")]
        [MinLength(4)]
        [MaxLength(128)]
        [DisplayName("Type of datas : ")]
        public string? DataType { get; set; }
        [Required(ErrorMessage = "The details of the datas is required")]
        [MinLength(4)]
        [MaxLength(512)]
        [DisplayName("Datas Details : ")]
        public string? DetailsData { get; set; }
        [Required(ErrorMessage = " The references of the datas is required")]
        [MinLength(4)]
        [MaxLength(256)]
        [DisplayName("References of the datas : ")]
        public string? ReferenceData { get; set; }

    }
}
