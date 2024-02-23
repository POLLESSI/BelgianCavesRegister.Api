using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class NOwnerRegisterForm
    {
        [Required(ErrorMessage = "The status is required")]
        [MinLength(3)]
        [MaxLength(256)]
        [DisplayName("Status")]
        public string? Status { get; set; }
        [Required(ErrorMessage = "The agreements is required")]
        [MinLength(3)]
        [MaxLength(256)]
        [DisplayName("Agreements")]
        public string? Agreement { get; set; }

    }
}
