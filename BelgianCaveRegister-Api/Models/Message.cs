using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BelgianCaveRegister_Api.Models
{
    public class Message
    {
        [Required(ErrorMessage = "The message is required")]
        [MinLength(2)]
        [MaxLength(512)]
        [DisplayName("Message : ")]
        public string? NewMessage { get; set; }
        [Required(ErrorMessage = "The name of the author is required")]
        [MinLength(2)]
        [MaxLength(64)]
        [DisplayName("Author : ")]
        public string? Author { get; set; }
    }
}
