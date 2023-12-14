using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class UpdateNPersonForm
    {
        [Required(ErrorMessage = "The Person Id is required")]
        [DisplayName("Person Id")]
        public int NPerson_Id { get; set; }
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
        [DisplayName("Birth Date : ")]
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
        [MinLength(1)]
        [MaxLength(64)]
        [DisplayName("Numero : ")]
        public int Address_Nbr { get; set; }
        [Required(ErrorMessage = "Postal Code is required")]
        [MinLength(3)]
        [MaxLength(6)]
        [DisplayName("Numero : ")]
        public int PostalCode { get; set; }
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
        [MinLength(9)]
        [MaxLength(16)]
        [DisplayName("Telephone")]
        public int Telephone { get; set; }
        [MinLength(9)]
        [MaxLength(16)]
        [DisplayName("Gsm")]
        public int Gsm { get; set; }
    }
}

