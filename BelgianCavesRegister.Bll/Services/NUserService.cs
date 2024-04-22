using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Repository;
using BelgianCavesRegister.Bll;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BelgianCavesRegister.Models.Services
{
    public class NUserService : INUserService
    {
        private readonly INUserRepository _nUserRepository;
        public NUserService(INUserRepository nUserRepository)
        {
            _nUserRepository = nUserRepository;
        }

        public bool Create(NUser nUser)
        {
            try
            {
                return _nUserRepository.Create(nUser);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating new user : {ex.ToString}");
            }
            return false;
        }

        public void CreateNUser(NUser nUser)
        {
            try
            {
                _nUserRepository.CreateNUser(nUser);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error CreateNUser : {ex.ToString}");
            }
            
        }

        public NUser Delete(Guid nUser_Id)
        {
            try
            {
                return _nUserRepository.Delete(nUser_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting user: {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<NUser> GetAll()
        {
            return _nUserRepository.GetAll();
        }

        public NUser GetById(Guid nUser_Id)
        {

            try
            {
                return _nUserRepository.GetById(nUser_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting user: {ex.ToString}");
            }
            return null;
        }

        public NUser LoginNUser(string email, string passwordHash)
        {
            try
            {
                return _nUserRepository.LoginNUser(email, passwordHash);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error loging: {ex.ToString}");
            }
            return null;
        }

        public void RegisterNUser(string pseudo, string email, string passwordHash)
        {
            try
            {
                _nUserRepository.RegisterNUser(pseudo, email, passwordHash);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error registring new user: {ex.ToString}");
            }
        }

        public void SetRole(Guid nUser_Id, string role_Id)
        {
            try
            {
                _nUserRepository.SetRole(nUser_Id, role_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error changing rôle: {ex.ToString}");
            }
        }

        public NUser Update(Guid nUser_Id, string pseudo, string passwordHash, string email, int nPerson_Id, string role_Id)
        {
            try
            {
                var updateNUser = _nUserRepository.Update(nUser_Id, pseudo, passwordHash, email, nPerson_Id, role_Id);
                return updateNUser;
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user: {ex}");
            }
            return new NUser();
        }
    }
}
