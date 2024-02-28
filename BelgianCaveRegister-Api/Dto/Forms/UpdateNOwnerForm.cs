using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class UpdateNOwnerForm
    {
        [Required(ErrorMessage = "The Owner Id is required")]
        [DisplayName("Owner Id")]
        public int NOwner_Id { get; set; }
        [Required(ErrorMessage = "The status is required")]
        [MinLength(4)]
        [MaxLength(256)]
        public string? Status { get; set; }
        [Required(ErrorMessage = "Rhe agreements is required")]
        [MinLength(4)]
        [MaxLength(256)]
        [DisplayName("Agreements")]
        public string? Agreement { get; set; }
    }
}

