using BelgianCavesRegister.Dal.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.NUser;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface INUserRepository
    {
        bool Create(NUser nUser);
        //void CreateNUser(NUser nUser);
        IEnumerable<NUser> GetAll();
        NUser? GetById(Guid nUser_Id);
        NUser? Delete(Guid nUser_Id);
        NUser? Update(Guid nUser_Id, string pseudo, byte passwordHash, string email, int? nPerson_Id, int? role_Id);
        NUser? UnregisterNUser(Guid nUser_Id);
        NUser? LoginNUser(string email, byte passwordHash);
        void SetRole(Guid nUser_Id, int role_id);
    }
}

