using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelgianCaveRegister_Api.Dto.Forms
{
    public class ChangeRole
    {
        [Required(ErrorMessage = "Id of user is required")]
        [DisplayName("User Guid")]
        public Guid NUser_Id { get; set; }
        [Required(ErrorMessage = "Id of de new role is required")]
        [DisplayName("Id role")]
        public int Role_Id { get; set; }
    }
}

