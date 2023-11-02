using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class SiteRegisterForm
    {
        [Required(ErrorMessage = "The name of the site is required")]
        [MinLength(3)]
        [MaxLength(32)]
        [DisplayName("Site name")]
        public string Site_name { get; set; }
        [Required(ErrorMessage = "The situation of the site is required")]
        [MinLength(3)]
        [MaxLength(256)]
        [DisplayName("Site situation")]
        public string Site_Description { get; set; }
        [Required(ErrorMessage = " The latitude of the site is required")]
        [DisplayName("Latitude")]
        public double Latitude { get; set; }
        [Required(ErrorMessage = "Yhe longitude of the site is required")]
        [DisplayName("Longitude")]
        public double Longitude { get; set; }
        [Required(ErrorMessage = "The Length is required")]
        [MinLength(1)]
        [MaxLength(15000)]
        [DisplayName("Length")]
        public decimal Length { get; set; }
        [Required(ErrorMessage = "The depth is required")]
        [MinLength(0)]
        [MaxLength(150)]
        [DisplayName("Depth")]
        public decimal Depth { get; set; }
        [Required(ErrorMessage = "The access requirement is required")]
        [MinLength(3)]
        [MaxLength(256)]
        [DisplayName("Access requirement")]
        public string AccessRequirement { get; set; }
        [Required(ErrorMessage = "The parcticals Informations is required")]
        [MinLength(3)]
        [MaxLength(512)]
        [DisplayName("Parcticals Infoemations")]
        public string PracticalInformation { get; set; }
        [Required(ErrorMessage = "The Lambdas Datas Id is required")]
        [DisplayName("Lambdas Datas id")]
        public int DonneesLambda_Id { get; set; }
        [Required(ErrorMessage = "The id of the owner is required")]
        public int NOwner_Id { get; set; }
        public int ScientificData_Id { get; set; }
        public int Bibliography_Id { get; set; }

    }
}

