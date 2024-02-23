using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BelgianCaveRegister_Api.Models
{
    public class Message
    {
        [Required(ErrorMessage = "The message is required")]
        [MinLength(3)]
        [MaxLength(512)]
        [DisplayName("Message")]
        public string? newMessage { get; set; }
        [Required(ErrorMessage = "The name of author is required")]
        [MinLength(3)]
        [MaxLength(64)]
        [DisplayName("Author")]
        public string? Author { get; set; }
    }
}
