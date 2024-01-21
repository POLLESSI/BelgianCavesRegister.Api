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
        [DisplayName("Site name : ")]
        public string? Site_Name { get; set; }
        [Required(ErrorMessage = "The situation of the site is required")]
        [MinLength(3)]
        [MaxLength(256)]
        [DisplayName("Site's situation : ")]
        public string? Site_Description { get; set; }
        [Required(ErrorMessage = " The latitude of the site is required")]
        [DisplayName("Latitude : ")]
        public double Latitude { get; set; }
        [Required(ErrorMessage = "The longitude of the site is required. A double please")]
        [DisplayName("Longitude : ")]
        public double Longitude { get; set; }
        [Required(ErrorMessage = "The Length is required. A double please")]
        [MinLength(1)]
        [MaxLength(25000)]
        [DisplayName("Length : ")]
        public decimal Length { get; set; }
        [Required(ErrorMessage = "The Depth is required. A decimal please")]
        [MinLength(0)]
        [MaxLength(150)]
        [DisplayName("Depth : ")]
        public decimal Depth { get; set; }
        [Required(ErrorMessage = "The access requirements are required ! ")]
        [MinLength(3)]
        [MaxLength(256)]
        [DisplayName("Access Requirement : ")]
        public string? AccessRequirement { get; set; }
        [Required(ErrorMessage = "The practicals Informations are required : ")]
        [MinLength(3)]
        [MaxLength(512)]
        [DisplayName("Practicals Informations")]
        public string? PracticalInformation { get; set; }
        [Required(ErrorMessage = "The Lambda Datas Id is required")]
        [DisplayName("Lambda Datas id : ")]
        public int DonneesLambda_Id { get; set; }
        [Required(ErrorMessage = "The id of the owner is required")]
        [DisplayName("Owner's Id : ")]
        public int NOwner_Id { get; set; }
        [Required(ErrorMessage = "The Id of the scientific datas is required")]
        [DisplayName("Scientific Datas Id : ")]
        public int ScientificData_Id { get; set; }
        [Required(ErrorMessage = "The bibliography's Id is required")]
        [DisplayName("Bibliography's Id : ")]
        public int Bibliography_Id { get; set; }

    }
}

