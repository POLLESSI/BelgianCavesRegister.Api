using BelgianCavesRegister.Dal.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.NUser;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface INUserRepository
    {
        bool Create(NUser nUser);
        void CreateNUser(NUser nUser);
        IEnumerable<NUser> GetAll();
        NUser? GetById(Guid nUser_Id);
        NUser? Delete(Guid nUser_Id);
        NUser? Update(Guid nUser_Id, string? pseudo, string? passwordHash, string? email, int? nPerson_Id, int? role_Id);
        void RegisterNUser(string? pseudo, string? email, string? passwordHash);
        NUser? LoginNUser(string? email, string? passwordHash);
        void SetRole(Guid nUser_Id, int role_id);
    }
}

