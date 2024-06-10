﻿using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Dal.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BelgianCavesRegister.Bll.Services
{
    public class NOwnerService : INOwnerService
    {
        private readonly INOwnerRepository _nOwnerRepository;
        public NOwnerService(INOwnerRepository nOwnerRepository)
        {
            _nOwnerRepository = nOwnerRepository;
        }

        public bool Create(NOwner nOwner)
        {
            try
            {
                return _nOwnerRepository.Create(nOwner);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating new owner: {ex.ToString}");
            }
            return false;
        }

        public void CreateNOwner(NOwner nOwner)
        {
            try
            {
                _nOwnerRepository.CreateNOwner(nOwner);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error CreateOwner : {ex.ToString}");
            }
        }

        public NOwner? Delete(int nOwner_Id)
        {
            try
            {
                return _nOwnerRepository.Delete(nOwner_Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting owner: {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<NOwner?> GetAll()
        {
            return _nOwnerRepository.GetAll();
        }

        public NOwner? GetById(int nOwner_Id)
        {

            try
            {
                return _nOwnerRepository.GetById(nOwner_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting owner: {ex.ToString}");
            }
            return null;
        }

        public NOwner? Update(string status, string agreement, int site_Id, int nOwner_Id)
        {
            try
            {
                var updateNOwner = _nOwnerRepository.Update(status, agreement, site_Id, nOwner_Id);
                return updateNOwner;
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating bibliography: {ex}");
            }
            return new NOwner();
        }
    }
}
