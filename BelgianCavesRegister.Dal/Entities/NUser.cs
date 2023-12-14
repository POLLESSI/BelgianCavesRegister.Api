
namespace BelgianCavesRegister.Dal.Entities
{
    public class NUser
    {
        public Guid NUser_Id { get; set; }
        public string Pseudo { get; set; }
        public byte PasswordHash { get; set; }
        public string Email { get; set; }
        public int? NPerson_Id { get; set; }
        public int? Role_Id { get; set; }
        public bool Active { get; set; }
        //public NPersonDTO NPerson { get; set; }

        //public List<NUserDTO> NUsers { get; set; }

        //public class Result
        //{
        //    public List<NUserResult> Results { get; set; }
        //}
        //public class NUserResult
        //{
        //    public string Pseudo { get; set; }
        //    public string Password { get; set; }
        //    public string Email { get; set; }
        //}
    }
}
