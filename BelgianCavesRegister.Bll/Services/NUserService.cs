using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Dal.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using BelgianCavesRegister.Dal.Interfaces;

namespace BelgianCavesRegister.Models.Services
{
    public class NUserService : INUserService
    {
        private readonly INUserRepository _nUserRepository;
        public NUserService(INUserRepository nUserRepository)
        {
            _nUserRepository = nUserRepository;
        }
        public void CreateNUser(string pseudo, string passwordHash, string email, int? nPerson_Id, int? role_Id)
        {
            _nUserRepository.CreateNUser(pseudo, passwordHash, email, nPerson_Id, role_Id);
        }
        public void Create(NUser nUser)
        {
            _nUserRepository.Create(nUser);
        }

        public NUser? LoginNUser(string email, string password)
        {
            return _nUserRepository.LoginNUser(email, password);
        }

        public void SetRole(Guid nUser_Id, int role_Id)
        {
            _nUserRepository.SetRole(nUser_Id, role_Id);
        }
        public void UnregisterNUser(Guid nUser_Id)
        {
            _nUserRepository.Delete(nUser_Id);
        }

        public IEnumerable<NUser> GetAll()
        {
            return _nUserRepository.GetAll();
        }

        public NUser? GetById(Guid nUser_Id)
        {
            return _nUserRepository.GetById(nUser_Id);
        }
        public NUser? Delete(Guid nUser_Id)
        {
            return _nUserRepository.Delete(nUser_Id);
        }
        public NUser? Update(Guid nUser_Id, string pseudo, string passwordHash, string email, int? nPerson_Id, int? role_Id)
        {
            return _nUserRepository.Update(nUser_Id, pseudo, passwordHash, email, nPerson_Id, role_Id);
        }
    }
}
