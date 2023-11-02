using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelgianCavesRegister.Bll.Entities
{
    public class NUserPOCO
    {
        public Guid NUser_Id { get; set; }
        public string Pseudo { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public int? NPerson_Id { get; set; }
        public int? Role_Id { get; set; }
        public bool Active { get; set; }

        //public List<NUserPOCO> NUsers { get; set; }

        //public class Result
        //{
        //    public List<NUserPOCO> Results { get; set; }
        //}
        //public class NUserResult
        //{
        //    public string Pseudo { get; set; }
        //    public string Email { get; set; }
        //}
    }
}
