using BelgianCavesRegister.Bll.Entities;
using BelgianCavesRegister.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelgianCavesRegister.Bll
{
    public interface IScientificDataService
    {
        void RegisterScientificData(string dataType, string detailData, string referenceData);
        void Create(string dataType, string detailData, string referenceData);
        IEnumerable<ScientificDataPOCO> GetAll();
        ScientificDataPOCO? GetById(int scientificData_Id);
        ScientificDataPOCO? Delete(int scientificData_Id);
        ScientificDataPOCO? Update(int scientificData_Id);
    }
}

