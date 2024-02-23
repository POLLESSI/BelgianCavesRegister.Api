using BelgianCavesRegister.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.ScientificData;

namespace BelgianCavesRegister.Bll
{
    public interface IScientificDataService
    {
        bool Create(ScientificData scientificData);
        void CreateScientificData(ScientificData scientificData);
        IEnumerable<ScientificData> GetAll();
        ScientificData? GetById(int scientificData_Id);
        ScientificData? Delete(int scientificData_Id);
        ScientificData? Update(int scientificData_Id, string dataType, string detailData, string referenceData);
    }
}

