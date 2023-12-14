using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Dal.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using BelgianCavesRegister.Dal.Interfaces;

namespace BelgianCavesRegister.Models.Services
{
    public class ScientificDataService : IScientificDataService
    {
        private readonly IScientificDataRepository _scientificDataRepository;
        public ScientificDataService(IScientificDataRepository scientificDataRepository)
        {
            _scientificDataRepository = scientificDataRepository;
        }
        public void CreateScientificData(string dataType, string detailData, string referenceData)
        {
            _scientificDataRepository.CreateScientificData(dataType, detailData, referenceData);
        }
        public void Create(ScientificData scientificData)
        {
            _scientificDataRepository.Create(scientificData);
        }
        public IEnumerable<ScientificData> GetAll()
        {
            return _scientificDataRepository.GetAll();
        }
        public ScientificData? GetById(int scientificData_Id)
        {
            return _scientificDataRepository.GetById(scientificData_Id);
        }
        public ScientificData? Delete(int scientificData_Id)
        {
            return _scientificDataRepository.Delete(scientificData_Id);
        }
        public ScientificData? Update(int scientificData_Id, string dataType, string detailData, string referenceData)
        {
            return _scientificDataRepository.Update(scientificData_Id, dataType, detailData, referenceData);
        }
    }
}

