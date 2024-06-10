using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class LambdaDataRegisterForm
    {
        [Required(ErrorMessage = "The localisation is required")]
        [MinLength(2)]
        [MaxLength(128)]
        [DisplayName("Localisation : ")]
        public string? Localisation { get; set; }
        [DisplayName("Topography : ")]
        public string? Topo { get; set; }
        [Required(ErrorMessage = "Acces condition is required")]
        [MinLength(2)]
        [MaxLength(256)]
        [DisplayName("Acces : ")]
        public string? Acces { get; set; }
        [DisplayName("Equipement sheet : ")]
        public string? EquipementSheet { get; set; }
        [MinLength(2)]
        [MaxLength(512)]
        [DisplayName("Practical Information : ")]
        public string? PracticalInformation { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [MinLength(2)]
        [MaxLength(128)]
        [DisplayName("Description : ")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Id Site is required")]
        [DisplayName("Id Site : ")]
        public int Site_Id { get; set; }
    }
}

