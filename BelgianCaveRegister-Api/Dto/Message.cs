namespace BelgianCaveRegister_Api.Dto
{
    public class Message
    {
        public string? Sender { get; set; }
        public string? Content { get; set; }
        public DateTime SendingDate { get; set; }
        public bool IsPrivate { get; set; }
    }
}
