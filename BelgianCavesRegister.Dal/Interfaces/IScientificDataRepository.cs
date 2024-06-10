﻿using BelgianCavesRegister.Dal.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.ScientificData;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface IScientificDataRepository
    {
        bool Create(ScientificData scientificData);
        void CreateScientificData(ScientificData scientificData);
        IEnumerable<ScientificData?> GetAll();
        ScientificData? GetById(int scientificData_Id);
        ScientificData? Delete(int scientificData_Id);
        ScientificData? Update(string? dataType, string? detailsData, string? referenceData, int site_Id, int scientificData_Id);
        
    }
}

