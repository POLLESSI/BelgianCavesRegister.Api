using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Repository;
using BelgianCavesRegister.Bll.Mappers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
//using Microsoft.Data.SqlClient;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Bll.Entities;
using System.Linq;

namespace BelgianCavesRegister.Models.Services
{
    public class NUserService : INUserService
    {
        private readonly INUserRepository _nUserRepository;
        public NUserService(INUserRepository nUserRepository)
        {
            _nUserRepository = nUserRepository;
        }
        public void RegisterNUser(string pseudo, string passwordHash, string email, int? nPerson_Id, int? role_Id)
        {
            _nUserRepository.RegisterNUser(pseudo, passwordHash, email, nPerson_Id, role_Id);
        }
        public void Create(string pseudo, string passwordHash, string email, int? nPerson_Id, int? role_Id)
        {
            _nUserRepository.Create(pseudo, passwordHash, email, nPerson_Id, role_Id);
        }

        public NUserPOCO? LoginNUser(string email, string password)
        {
            return _nUserRepository.LoginNUser(email, password).NuDalTaBll();
        }

        public void SetRole(Guid nUser_Id, int role_Id)
        {
            _nUserRepository.SetRole(nUser_Id, role_Id);
        }
        public void UnregisterNUser(Guid nUser_Id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<NUserPOCO> GetAll()
        {
            return _nUserRepository.GetAll().Select(x => x.NuDalTaBll());
        }

        public NUserPOCO? GetById(Guid nUser_Id)
        {
            return _nUserRepository.GetById(nUser_Id).NuDalTaBll();
        }
        public NUserPOCO? Delete(Guid nUser_Id)
        {
            return _nUserRepository.Delete(nUser_Id).NuDalTaBll();
        }
        public NUserPOCO? Update(Guid nUser_Id)
        {
            return _nUserRepository.Update(nUser_Id).NuDalTaBll();
        }
    }
}
