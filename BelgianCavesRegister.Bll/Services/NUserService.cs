using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Repository;
using BelgianCavesRegister.Bll;
using BelgianCaveRegister_Api.Tools;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text;

namespace BelgianCavesRegister.Models.Services
{
    public class NUserService : INUserService
    {
        private readonly INUserRepository _nUserRepository;
        //private readonly TokenGenerator _tokenGenerator;
        public NUserService(INUserRepository nUserRepository)
        {
            _nUserRepository = nUserRepository;
            //_tokenGenerator = tokenGenerator;
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

        public NUser? Delete(int nUser_Id)
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

        public IEnumerable<NUser?> GetAll()
        {
            return _nUserRepository.GetAll();
        }

        public NUser? GetById(int nUser_Id)
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

        public NUser? LoginNUser(string? email, string? passwordHash)
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

        public void RegisterNUser(string? pseudo, string? email, string? passwordHash)
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
        //async Task<NUser> INUserService.RegisterNUser(string pseudo, string email, string passwordHash)
        //{
        //    var securityStamp = Guid.NewGuid();
        //    passwordHash = Hash.HashPassword(passwordHash);

        //    var user = new NUser
        //    {
        //        //Email = email.Trim(),
        //        //Pseudo = pseudo.Trim(),
        //        //PasswordHash = Encoding.UTF8.GetBytes(passwordHash),
        //        //SecurityStamp = securityStamp,
        //        //NPerson_Id = 0, // Set appropriately
        //        //Role_Id = "3", //Default role
        //        //Active = true
        //    };
        //    await _nUserRepository.AddAsync(user);
        //    return user;
        //}
        //public async Task<NUser> RegisterNUserAsync(string email, string pseudo, string password)
        //{
        //    var securityStamp = Guid.NewGuid() ;
        //    var passwordHash = Hash.HashPassword(password) ;

        //    var user = new NUser
        //    {
        //        //Email = email.Trim(),
        //        //Pseudo = pseudo.Trim(),
        //        //PasswordHash = Encoding.UTF8.GetBytes(passwordHash),
        //        //SecurityStamp = securityStamp,
        //        //NPerson_Id = 0,
        //        //Role_Id = "3",
        //        //Active = true
        //    };
        //    await _nUserRepository.AddAsync(user);
        //    return user ;
        //}
        public void SetRole(string? role_Id, int nUser_Id)
        {
            try
            {
                _nUserRepository.SetRole( role_Id, nUser_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error changing rôle: {ex.ToString}");
            }
        }

        public NUser? Update(string? pseudo, string? passwordHash, string? email, int nPerson_Id, string? role_Id, int nUser_Id)
        {
            try
            {
                var updateNUser = _nUserRepository.Update(pseudo, passwordHash, email, nPerson_Id, role_Id, nUser_Id);
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
