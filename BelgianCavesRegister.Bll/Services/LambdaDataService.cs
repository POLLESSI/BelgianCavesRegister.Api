using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Dal.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using BelgianCavesRegister.Dal.Interfaces;
using System.Data.Entity.Infrastructure;

namespace BelgianCavesRegister.Bll.Services
{
    public class LambdaDataService : ILambdaDataService
    {
        private readonly ILambdaDataRepository _lambdaDataRepository;
        public LambdaDataService(ILambdaDataRepository lambdaDataRepository)
        {
            _lambdaDataRepository = lambdaDataRepository;
        }
        public void AddLambdaData(string localisation, string topo, string acces, string equipementSheet, string practicalInformation, string description)
        {
            try
            {
                _lambdaDataRepository.AddLambdaData(localisation, topo, acces, equipementSheet, practicalInformation, description);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error adding lambda data: {ex.ToString}");
            }
            
        }
        public bool Create(LambdaData lambdaData)
        {
            try
            {
                _lambdaDataRepository.Create(lambdaData);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating lambda data: {ex.ToString}");
            }
            return true;
        }
        public IEnumerable<LambdaData> GetAll()
        {
            try
            {
                return (IEnumerable<LambdaData>)_lambdaDataRepository.GetAll();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting all lambda data: {ex.ToString}");
            }
            return Enumerable.Empty<LambdaData>();
        }

        public LambdaData? GetById(int donneesLambda_Id)
        {
            try
            {
                return _lambdaDataRepository.GetById(donneesLambda_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting lambda data: {ex.ToString}");
            }
            return new LambdaData();
        }
        public LambdaData? Delete(int donneesLambda_Id)
        {
            try
            {
                return _lambdaDataRepository.Delete(donneesLambda_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting lambda data: {ex.ToString}");
            }
            return null;
        }
        public LambdaData? Update(int donneesLambda_Id, string localisation, string topo, string acces, string equipementSheet, string practicalInformation, string description)
        {
            try
            {
                var updateLambdaData = _lambdaDataRepository.Update(donneesLambda_Id,localisation, topo, acces, equipementSheet, practicalInformation, description);
                return updateLambdaData;
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Database update error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating bibliography: {ex}");
            }
            return new LambdaData();
            //return _lambdaDataRepository.Update(donneesLambda_Id, localisation, topo, acces, equipementSheet, practicalInformation, description);
        }

        
    }
}
