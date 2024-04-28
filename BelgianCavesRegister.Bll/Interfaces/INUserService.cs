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
        bool Create(NUser nUser);
        void CreateNUser(NUser nUser);
        IEnumerable<NUser?> GetAll();
        NUser? GetById(Guid nUser_Id);
        NUser? Delete(Guid nUser_Id);
        NUser? Update(Guid nUser_Id, string? pseudo, string? passwordHash, string? email, int nPerson_Id, string? role_Id);
        void RegisterNUser(string? pseudo, string? email, string? passwordHash);
        NUser? LoginNUser(string? email, string? passwordHash);
        void SetRole(Guid nUser_Id, string? role_Id);
    }
}
