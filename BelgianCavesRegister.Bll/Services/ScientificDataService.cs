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
            return true;
        }
        public void CreateScientificData(ScientificData scientificData)
        {
            try
            {
                _scientificDataRepository.CreateScientificData(scientificData);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error Creation Scientific data : {ex.ToString}");
            }
            
        }

        public IEnumerable<ScientificData> GetAll()
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

