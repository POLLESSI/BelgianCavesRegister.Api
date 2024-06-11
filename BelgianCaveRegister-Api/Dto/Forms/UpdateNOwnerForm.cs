using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class UpdateNOwnerForm
    {
        [Required(ErrorMessage = "The status is required")]
        [MinLength(4)]
        [MaxLength(256)]
        [DisplayName("Status : ")]
        public string? Status { get; set; }
        [Required(ErrorMessage = "The agreements is required")]
        [MinLength(4)]
        [MaxLength(256)]
        [DisplayName("Agreements : ")]
        public string? Agreement { get; set; }
        [Required(ErrorMessage ="Person Id is required")]
        [DisplayName("Person Id : ")]
        public int Person_Id { get; set; }
        [Required(ErrorMessage = "Site Id is required")]
        [DisplayName("Site Id : ")]
        public int Site_Id { get; set; }
        [Required(ErrorMessage = "The Owner Id is required")]
        [DisplayName("Owner Id : ")]
        public int NOwner_Id { get; set; }
    }
}

