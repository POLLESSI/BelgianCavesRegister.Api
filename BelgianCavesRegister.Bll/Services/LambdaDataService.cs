using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Dal.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using BelgianCavesRegister.Dal.Interfaces;

namespace BelgianCavesRegister.Bll.Services
{
    public class LambdaDataService : ILambdaDataService
    {
        private readonly ILambdaDataRepository _lambdaDataRepository;
        public LambdaDataService(ILambdaDataRepository lambdaDataRepository)
        {
            _lambdaDataRepository = lambdaDataRepository;
        }
        public void CreateLambdaData(string localisation, string topo, string acces, string equipementSheet, string practicalInformation, string description)
        {
            _lambdaDataRepository.CreateLambdaData(localisation, topo, acces, equipementSheet, practicalInformation, description);
        }
        public void Create(LambdaData lambdaData)
        {
            _lambdaDataRepository.Create(lambdaData);
        }
        public IEnumerable<LambdaData> GetAll()
        {
            return (IEnumerable<LambdaData>)_lambdaDataRepository.GetAll();
        }

        public LambdaData? GetById(int donneesLambda_Id)
        {
            return _lambdaDataRepository.GetById(donneesLambda_Id);
        }
        public LambdaData? Delete(int donneesLambda_Id)
        {
            return _lambdaDataRepository.Delete(donneesLambda_Id);
        }
        public LambdaData? Update(int donneesLambda_Id, string localisation, string topo, string acces, string equipementSheet, string practicalInformation, string description)
        {
            return _lambdaDataRepository.Update(donneesLambda_Id, localisation, topo, acces, equipementSheet, practicalInformation, description);
        }

        
    }
}
