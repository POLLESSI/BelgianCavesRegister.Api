namespace BelgianCaveRegister_Api.Dto
{
    public class ChatDTO
    {
        public string? NewMessage { get; set; }
        public string? Author { get; set; }
        public int Site_Id { get; set; }
        public bool Active { get; set; }
    }
}
