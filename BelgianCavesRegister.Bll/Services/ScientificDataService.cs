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
    public class ScientificDataService : IScientificDataService
    {
        private readonly IScientificDataRepository _scientificDataRepository;
        public ScientificDataService(IScientificDataRepository scientificDataRepository)
        {
            _scientificDataRepository = scientificDataRepository;
        }

        public bool Create(ScientificData scientificData)
        {
            try
            {
                return _scientificDataRepository.Create(scientificData);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating scientific data: {ex.ToString}");
            }
            return false;
        }

        public void CreateScientificData(ScientificData scientificData)
        {
            try
            {
                _scientificDataRepository.CreateScientificData(scientificData);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error Creation Scientific data: {ex.ToString}");
            }
        }

        public ScientificData? Delete(int scientificData_Id)
        {
            try
            {
                return _scientificDataRepository.Delete(scientificData_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting scientific data: {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<ScientificData?> GetAll()
        {
            return _scientificDataRepository.GetAll();
        }

        public ScientificData? GetById(int scientificData_Id)
        {

            try
            {
                return _scientificDataRepository.GetById(scientificData_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting scientific data: {ex.ToString}");
            }
            return null;
        }

        public ScientificData? Update(int scientificData_Id, string dataType, string detailsData, string referenceData)
        {
            try
            {
                var updateScientificData = _scientificDataRepository.Update(scientificData_Id, dataType, detailsData, referenceData);
                return updateScientificData;
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating scientific data: {ex}");
            }
            return new ScientificData();
        }
    }
}

