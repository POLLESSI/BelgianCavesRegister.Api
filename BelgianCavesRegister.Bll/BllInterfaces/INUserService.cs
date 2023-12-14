using BelgianCavesRegister.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.NUser;

namespace BelgianCavesRegister.Bll
{
    public interface INUserService
    {
        void CreateNUser(string pseudo, string passwordHash, string email, int? nPerson_Id, int? role_Id);
        void Create(NUser nUser);
        IEnumerable<NUser> GetAll();
        NUser? GetById(Guid nUser_Id);
        NUser? Delete(Guid nUser_Id);
        NUser? Update(Guid nUser_Id, string pseudo, string passwordHash, string email, int? nPerson_Id, int? role_Id);
        void UnregisterNUser(Guid nUser_Id);
        NUser? LoginNUser(string email, string password);
        void SetRole(Guid nUser_Id, int role_Id);
    }
}
