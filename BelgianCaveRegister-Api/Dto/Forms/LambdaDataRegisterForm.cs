using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class LambdaDataRegisterForm
    {
        [Required(ErrorMessage = "The localisation is required")]
        [MinLength(3)]
        [MaxLength(128)]
        [DisplayName("Localisation")]
        public string? Localisation { get; set; }
        [DisplayName("Topography")]
        public string? Topo { get; set; }
        [Required(ErrorMessage = "Acces condition is required")]
        [MinLength(3)]
        [MaxLength(256)]
        [DisplayName("Acces")]
        public string? Acces { get; set; }
        [Required(ErrorMessage = "Equipement sheet is required")]
        [MinLength(3)]
        [DisplayName("Equipement sheet")]
        public string? EquipementSheet { get; set; }
        [Required(ErrorMessage = "Practical Informations is required")]
        [MinLength(3)]
        [MaxLength(512)]
        [DisplayName("Practical Informations")]
        public string? PracticalInformation { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [MinLength(3)]
        [MaxLength(128)]
        [DisplayName("Description")]
        public string? Description { get; set; }
    }
}

