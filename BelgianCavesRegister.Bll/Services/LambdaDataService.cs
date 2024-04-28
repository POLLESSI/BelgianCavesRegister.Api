using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using BelgianCavesRegister.Bll;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BelgianCavesRegister.Bll.Services
{
    public class LambdaDataService : ILambdaDataService
    {
        private readonly ILambdaDataRepository _lambdaDataRepository;
        public LambdaDataService(ILambdaDataRepository lambdaDataRepository)
        {
            _lambdaDataRepository = lambdaDataRepository;
        }

        public bool Create(LambdaData lambdaData)
        {
            try
            {
                return _lambdaDataRepository.Create(lambdaData);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating lambda data: {ex.ToString}");
            }
            return false;
        }

        public void CreateLambdaData(LambdaData lambdaData)
        {
            try
            {
                _lambdaDataRepository.Create(lambdaData);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating lambda data: {ex.ToString}");
            }
            
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

        public IEnumerable<LambdaData?> GetAll()
        {
            return _lambdaDataRepository.GetAll();
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
            return null;
        }

        public LambdaData? Update(int donneesLambda_Id, string localisation, string topo, string acces, string equipementSheet, string practicalInformation, string description)
        {
            throw new NotImplementedException();
        }
    }
}
