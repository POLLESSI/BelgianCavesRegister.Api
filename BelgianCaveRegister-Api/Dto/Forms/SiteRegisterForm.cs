using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class SiteRegisterForm
    {
        [Required(ErrorMessage = "The name of the site is required")]
        [MinLength(2)]
        [MaxLength(32)]
        [DisplayName("Site name")]
        public string? Site_Name { get; set; }
        [Required(ErrorMessage = "The description of the site is required")]
        [MinLength(4)]
        [MaxLength(256)]
        [DisplayName("Site description")]
        public string? Site_Description { get; set; }
        [Required(ErrorMessage = " The latitude of the site is required")]
        [DisplayName("Latitude")]
        public string? Latitude { get; set; }
        [Required(ErrorMessage = "The longitude of the site is required")]
        [DisplayName("Longitude")]
        public string? Longitude { get; set; }
        [Required(ErrorMessage = "The Length is required")]
        [MinLength(1)]
        [MaxLength(8)]
        [DisplayName("Length")]
        public string? Length { get; set; }
        [Required(ErrorMessage = "The depth is required")]
        [MaxLength(8)]
        [DisplayName("Depth")]
        public string? Depth { get; set; }
        [Required(ErrorMessage = "The access requirement is required")]
        [MinLength(4)]
        [MaxLength(256)]
        [DisplayName("Access requirement")]
        public string? AccessRequirement { get; set; }
        [Required(ErrorMessage = "The parcticals Informations is required")]
        [MinLength(4)]
        [MaxLength(512)]
        [DisplayName("Parcticals Informations")]
        public string? PracticalInformation { get; set; }
    }
}

