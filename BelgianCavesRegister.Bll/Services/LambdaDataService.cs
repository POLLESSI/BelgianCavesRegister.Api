using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Repository;
using BelgianCavesRegister.Bll.Mappers;
using System.Collections.Generic;
using System.Threading.Tasks;
//using Microsoft.Data.SqlClient;
using BelgianCavesRegister.Bll.Entities;
using System.Linq;

namespace BelgianCavesRegister.Bll.Services
{
    public class LambdaDataService : ILambdaDataService
    {
        private readonly ILambdaDataRepository _lambdaDataRepository;
        public LambdaDataService(ILambdaDataRepository lambdaDataRepository)
        {
            _lambdaDataRepository = lambdaDataRepository;
        }
        public void RegisterLambdaData(string localisation, string topo, string acces, string equipementSheet, string practicalInformation, string description)
        {
            _lambdaDataRepository.RegisterLambdaData(localisation, topo, acces, equipementSheet, practicalInformation, description);
        }
        public void Create(string localisation, string topo, string acces, string equipementSheet, string practicalInformation, string description)
        {
            _lambdaDataRepository.Create(localisation, topo, acces, equipementSheet, practicalInformation, description);
        }
        public IEnumerable<LambdaDataPOCO> GetAll()
        {
            return _lambdaDataRepository.GetAll().Select(x => x.LaDalToBll());
        }

        public LambdaDataPOCO? GetById(int donneesLambda_Id)
        {
            return _lambdaDataRepository.GetById(donneesLambda_Id).LaDalToBll();
        }
        public LambdaDataPOCO? Delete(int donneesLambda_Id)
        {
            return _lambdaDataRepository.Delete(donneesLambda_Id).LaDalToBll();
        }
        public LambdaDataPOCO? Update(int donneesLambda_Id)
        {
            return _lambdaDataRepository.Update(donneesLambda_Id).LaDalToBll();
        }
    }
}
