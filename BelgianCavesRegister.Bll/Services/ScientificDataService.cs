using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Dal.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using BelgianCavesRegister.Dal.Interfaces;
using System.Data.Entity.Infrastructure;

namespace BelgianCavesRegister.Models.Services
{
    public class ScientificDataService : IScientificDataService
    {
        private readonly IScientificDataRepository _scientificDataRepository;
        public ScientificDataService(IScientificDataRepository scientificDataRepository)
        {
            _scientificDataRepository = scientificDataRepository;
        }
        public void AddScientificData(string dataType, string detailData, string referenceData)
        {
            try
            {
                _scientificDataRepository.AddScientificData(dataType, detailData, referenceData);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error adding scientific data: {ex.ToString}");

            }
            
        }
        public bool Create(ScientificData scientificData)
        {
            try
            {
                _scientificDataRepository.Create(scientificData);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating scientific data: {ex.ToString}");
            }
            return true;
        }
        public IEnumerable<ScientificData> GetAll()
        {
            try
            {
                return _scientificDataRepository.GetAll();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting all scientific data: {ex.ToString}");
            }
            return null;
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
            return new ScientificData();
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
        public ScientificData? Update(int scientificData_Id, string dataType, string detailData, string referenceData)
        {
            try
            {
                var updateScientificData = _scientificDataRepository.Update(scientificData_Id, dataType, detailData, referenceData);

                return updateScientificData;
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");

            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Database update error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating scientific data : {ex}");
            }
            return new ScientificData();
            //return _scientificDataRepository.Update(scientificData_Id, dataType, detailData, referenceData);
        }
    }
}

