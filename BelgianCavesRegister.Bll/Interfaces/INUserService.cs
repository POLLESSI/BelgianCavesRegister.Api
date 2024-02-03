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
        //void AddNUser(string pseudo, byte passwordHash, string email, int? nPerson_Id, int? role_Id);
        bool Create(NUser nUser);
        //void CreateNUser(NUser nUser);
        IEnumerable<NUser> GetAll();
        NUser? GetById(Guid nUser_Id);
        NUser? Delete(Guid nUser_Id);
        NUser? Update(Guid nUser_Id, string pseudo, byte passwordHash, string email, int? nPerson_Id, int? role_Id);
        void UnregisterNUser(Guid nUser_Id);
        NUser? LoginNUser(string email, byte password);
        void SetRole(Guid nUser_Id, int role_Id);
    }
}
