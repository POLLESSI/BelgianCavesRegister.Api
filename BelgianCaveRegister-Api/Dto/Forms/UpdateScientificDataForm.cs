using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class UpdateScientificDataForm
    {
        [Required(ErrorMessage = "The type of datas is required")]
        [MinLength(2)]
        [MaxLength(128)]
        [DisplayName("Type of datas : ")]
        public string? DataType { get; set; }
        [Required(ErrorMessage = "The details of the datas is required")]
        [MinLength(2)]
        [MaxLength(512)]
        [DisplayName("Datas Details : ")]
        public string? DetailsData { get; set; }
        [Required(ErrorMessage = "The references of the datas is required")]
        [MinLength(2)]
        [MaxLength(256)]
        [DisplayName("References of the datas : ")]
        public string? ReferenceData { get; set; }
        [Required(ErrorMessage = "Site Id is required")]
        [DisplayName("Site Id : ")]
        public int Site_Id { get; set; }
        [Required(ErrorMessage = "The Id of Scientific Datas is required")]
        [DisplayName("Id Scientific Data : ")]
        public int ScientificData_Id { get; set; }
    }
}

