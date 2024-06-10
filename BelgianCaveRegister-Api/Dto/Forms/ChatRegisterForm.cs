using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class ChatRegisterForm
    {
        [Required(ErrorMessage = "Message is required")]
        [MinLength(2)]
        [MaxLength(128)]
        [DisplayName("Message : ")]
        public string? NewMessage { get; set; }
        [Required(ErrorMessage = "Author's name is required")]
        [MinLength(2)]
        [MaxLength(32)]
        [DisplayName("Author : ")]
        public string? Author { get; set; }
        [Required]
        [DisplayName("Site Id : ")]
        public int Site_Id { get; set; }
    }
}
