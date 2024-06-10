using BelgianCavesRegister.Dal.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.NUser;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface INUserRepository
    {
    #nullable disable
        bool Create(NUser nUser);
        void CreateNUser(NUser nUser);
        IEnumerable<NUser> GetAll();
        NUser? GetById(int nUser_Id);
        NUser? Delete(int nUser_Id);
        NUser Update(string pseudo, string passwordHash, string email, int nPerson_Id, string role_Id, int nUser_Id);
        void RegisterNUser(string pseudo, string email, string passwordHash);
        NUser LoginNUser(string email, string passwordHash);
        void SetRole(string role_Id, int nUser_Id);
        //Task AddAsync(NUser user);
        //Task<NUser> GetByEmailAsync(string email);
        //Task RegisterNUserAsync(string pseudo, string passwordHash, string email);
    }
}

