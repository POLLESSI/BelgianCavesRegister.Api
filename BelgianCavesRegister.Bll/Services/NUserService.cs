﻿using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Dal.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using BelgianCavesRegister.Dal.Interfaces;
using System.Data.Entity.Infrastructure;

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
            return _nUserRepository.Create(nUser);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error creating new user: {ex.ToString}");
            //}
            //return true;
        }
        //public void CreateNUser(NUser nUser)
        //{
        //    _nUserRepository.CreateNUser(nUser);
        //}
         
        public NUser? LoginNUser(string email, byte password)
        {
            return _nUserRepository.LoginNUser(email, password);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error loging: {ex.ToString}");
            //}
            //return new NUser();
        }
        public void SetRole(Guid nUser_Id, int role_Id)
        {
            _nUserRepository.SetRole(nUser_Id, role_Id);
            //try
            //{
            //    _nUserRepository.SetRole(nUser_Id, role_Id);
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error changin role: {ex.ToString}");
            //}
            
        }
        public void UnregisterNUser(Guid nUser_Id)
        {
            _nUserRepository.Delete(nUser_Id);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error unregistring user: {ex.ToString}");
            //}
           
        }

        public IEnumerable<NUser> GetAll()
        {
            return _nUserRepository.GetAll();
        }
        public NUser? GetById(Guid nUser_Id)
        {
            return _nUserRepository.GetById(nUser_Id);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error getting user: {ex.ToString}");
            //}
            //return new NUser();
        }
        public NUser? Delete(Guid nUser_Id)
        {
            return _nUserRepository.Delete(nUser_Id);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error deleting user: {ex.ToString}");
            //}
            //return null;
        }
        public NUser? Update(Guid nUser_Id, string pseudo, byte passwordHash, string email, int? nPerson_Id, int? role_Id)
        {
            var updateNUser = _nUserRepository.Update(nUser_Id, pseudo, passwordHash, email, nPerson_Id, role_Id);

            return updateNUser;
            //try
            //{
                
            //}
            //catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            //{

            //    Console.WriteLine($"Validation error : {ex.Message}");

            //}
            //catch (DbUpdateException ex)
            //{
            //    Console.WriteLine($"Database update error: {ex.Message}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error updating user: {ex}");
            //}
            //return new NUser();
            ////return _nUserRepository.Update(nUser_Id, pseudo, passwordHash, email, nPerson_Id, role_Id);
        }
    }
}
