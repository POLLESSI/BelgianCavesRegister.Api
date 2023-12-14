using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class Message
    {
        [Required(ErrorMessage = "The message is required")]
        [MinLength(3)]
        [MaxLength(512)]
        [DisplayName("Message")]
        public string? Content { get; set; }
        [Required(ErrorMessage = "The name of author is required")]
        [MinLength(3)]
        [MaxLength(64)]
        [DisplayName("Author")]
        public string? Author { get; set; }
    }
}
