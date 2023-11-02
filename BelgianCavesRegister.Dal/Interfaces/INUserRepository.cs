using BelgianCavesRegister.Dal.Entities;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface INUserRepository
    {
        void RegisterNUser(NUserDTO newDto);
        IEnumerable<NUserDTO> GetAll();
        NUserDTO? GetById(Guid nUser_Id);
        NUserDTO? Delete(Guid nUser_Id);
        NUserDTO? Update(Guid nUser_Id);
        NUserDTO? LoginNUser(string email, string passwordHash);
        void SetRole(Guid nUser_Id, int role_id);
    }
}

