using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCavesRegister.Api.Dto.Forms
{
    public class NPersonForm
    {
        [Required(ErrorMessage = "The last name is required")]
        [MinLength(3)]
        [MaxLength(32)]
        [DisplayName("Last name : ")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "The first name is required")]
        [MinLength(3)]
        [MaxLength(32)]
        [DisplayName("First name : ")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "BirthDate is required")]
        [DisplayName("Birthdate")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Street is required")]
        [MinLength(3)]
        [MaxLength(64)]
        [DisplayName("Street")]
        public string Address_Street { get; set; }
        [Required(ErrorMessage = "Numero is required")]
        [MaxLength(5)]
        [DisplayName("Numero")]
        public int Address_Nbr { get; set; }
        [Required(ErrorMessage = "Postal Code is required")]
        [MaxLength(5)]
        [DisplayName("Postal Code")]
        public int PostalCode { get; set; }
        [Required(ErrorMessage = "The name of the city is required")]
        [MinLength(9)]
        [MaxLength(64)]
        [DisplayName("City")]
        public string Address_City { get; set; }
        [Required(ErrorMessage = "The name of the country is required")]
        [MinLength(9)]
        [MaxLength(64)]
        [DisplayName("Country")]
        public string Address_Country { get; set; }
        [MinLength(9)]
        [MaxLength(14)]
        [DisplayName("Telephone")]
        public int Telephone { get; set; }
        [DisplayName("Gsm")]
        [MinLength(9)]
        [MaxLength(14)]
        public int Gsm { get; set; }

    }
}

