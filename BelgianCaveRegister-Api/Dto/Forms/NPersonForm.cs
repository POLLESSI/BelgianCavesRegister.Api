using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class NPersonForm
    {
        [Required(ErrorMessage = "The last name is required")]
        [MinLength(3)]
        [MaxLength(32)]
        [DisplayName("Last name : ")]
        public string? Lastname { get; set; }
        [Required(ErrorMessage = "The first name is required")]
        [MinLength(3)]
        [MaxLength(32)]
        [DisplayName("First name : ")]
        public string? Firstname { get; set; }
        [Required(ErrorMessage = "The Birth Date is required")]
        [DisplayName("Birthdate : ")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [MinLength(3)]
        [MaxLength(64)]
        [DisplayName("Email : ")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Street is required")]
        [MinLength(3)]
        [MaxLength(64)]
        [DisplayName("Street : ")]
        public string? Address_Street { get; set; }
        [Required(ErrorMessage = "Numero is required")]
        [MaxLength(6)]
        [DisplayName("Numero : ")]
        public string? Address_Nbr { get; set; }
        [Required(ErrorMessage = "Postal Code is required")]
        [MinLength(3)]
        [MaxLength(6)]
        [DisplayName("Postal Code")]
        public string? PostalCode { get; set; }
        [Required(ErrorMessage = "The name of the city is required")]
        [MinLength(3)]
        [MaxLength(64)]
        [DisplayName("City")]
        public string? Address_City { get; set; }
        [Required(ErrorMessage = "The name of the country is required")]
        [MinLength(3)]
        [MaxLength(64)]
        [DisplayName("Country")]
        public string? Address_Country { get; set; }
        [MaxLength(16)]
        [DisplayName("Telephone")]
        public string? Telephone { get; set; }
        [MaxLength(16)]
        [DisplayName("Gsm")]
        public string? Gsm { get; set; }
    }
}

