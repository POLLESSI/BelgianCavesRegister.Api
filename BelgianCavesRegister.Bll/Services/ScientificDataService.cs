using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Repository;
using BelgianCavesRegister.Bll.Mappers;
using System.Threading.Tasks;
using System.Collections.Generic;
//using Microsoft.Data.SqlClient;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Bll.Entities;
using System.Linq;

namespace BelgianCavesRegister.Models.Services
{
    public class ScientificDataService : IScientificDataService
    {
        private readonly IScientificDataRepository _scientificDataRepository;
        public ScientificDataService(IScientificDataRepository scientificDataRepository)
        {
            _scientificDataRepository = scientificDataRepository;
        }
        public void RegisterScientificData(string dataType, string detailData, string referenceData)
        {
            _scientificDataRepository.RegisterScientificData(dataType, detailData, referenceData);
        }
        public void Create(string dataType, string detailData, string referenceData)
        {
            _scientificDataRepository.Create(dataType, detailData, referenceData);
        }
        public IEnumerable<ScientificDataPOCO> GetAll()
        {
            return _scientificDataRepository.GetAll().Select(x => x.ScDalToBll());
        }
        public ScientificDataPOCO? GetById(int scientificData_Id)
        {
            return _scientificDataRepository.GetById(scientificData_Id).ScDalToBll();
        }
        public ScientificDataPOCO? Delete(int scientificData_Id)
        {
            return _scientificDataRepository.Delete(scientificData_Id).ScDalToBll();
        }
        public ScientificDataPOCO? Update(int scientificData_Id)
        {
            return _scientificDataRepository.Update(scientificData_Id).ScDalToBll();
        }
    }
}

