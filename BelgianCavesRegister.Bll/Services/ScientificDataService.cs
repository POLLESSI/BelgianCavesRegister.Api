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
            return _scientificDataRepository.Create(scientificData);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error creating scientific data: {ex.ToString}");
            //}
            //return true;
        }
        //public void CreateScientificData(ScientificData scientificData)
        //{
        //    _scientificDataRepository.CreateScientificData(scientificData);
        //}

        public IEnumerable<ScientificData> GetAll()
        {
            return _scientificDataRepository.GetAll();
        }
        public ScientificData? GetById(int scientificData_Id)
        {
            return _scientificDataRepository.GetById(scientificData_Id);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error geting scientific data: {ex.ToString}");
            //}
            //return new ScientificData();
        }
        public ScientificData? Delete(int scientificData_Id)
        {
            return _scientificDataRepository.Delete(scientificData_Id);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error deleting scientific data: {ex.ToString}");
            //}
            //return null;
        }
        public ScientificData? Update(int scientificData_Id, string dataType, string detailData, string referenceData)
        {
            var updateScientificData = _scientificDataRepository.Update(scientificData_Id, dataType, detailData, referenceData);

            return updateScientificData;
            //try
            //{
                
            //}
            //catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            //{

            //    Console.WriteLine($"Validation error : {ex.Message}");

            //}
            //catch (DbUpdateException ex)
            //{
            //    Console.WriteLine($"Database update error : {ex.Message}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error updating scientific data : {ex}");
            //}
            //return new ScientificData();
            //return _scientificDataRepository.Update(scientificData_Id, dataType, detailData, referenceData);
        }
    }
}

