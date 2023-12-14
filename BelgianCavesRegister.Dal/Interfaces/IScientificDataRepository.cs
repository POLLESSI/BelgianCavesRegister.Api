﻿using BelgianCavesRegister.Dal.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Documents;
using static BelgianCavesRegister.Dal.Entities.ScientificData;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface IScientificDataRepository
    {
        bool Create(ScientificData scientificData);
        void CreateScientificData(string dataType, string detailsData, string referenceData);
        IEnumerable<ScientificData> GetAll();
        ScientificData? GetById(int scientificData_Id);
        ScientificData? Delete(int scientificData_Id);
        ScientificData? Update(int scientificData_Id, string dataType, string detailData, string referenceData);
    }
}

