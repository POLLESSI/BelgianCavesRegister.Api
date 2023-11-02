using BelgianCavesRegister.Bll.Entities;
using BelgianCavesRegister.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelgianCavesRegister.Bll
{
    public interface INUserService
    {
        void RegisterNUser(string pseudo, string passwordHash, string email, int? nPerson_Id, int? role_Id);
        void Create(string pseudo, string passwordHash, string email, int? nPerson_Id, int? role_Id);
        IEnumerable<NUserPOCO> GetAll();
        NUserPOCO? GetById(Guid nUser_Id);
        NUserPOCO? Delete(Guid nUser_Id);
        NUserPOCO? Update(Guid nUser_Id);
        void UnregisterNUser(Guid nUser_Id);
        NUserPOCO? LoginNUser(string email, string password);
        void SetRole(Guid nUser_Id, int role_Id);
    }
}
