
namespace BelgianCavesRegister.Dal.Entities
{
    public class Chat
    {
        public int Chat_Id { get; set; }
        public string? NewMessage { get; set; }
        public string? Author { get; set; }
        public bool Active { get; set; }
    }
}
