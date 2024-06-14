﻿using BelgianCavesRegister.Dal.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.Bibliography;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface IBibliographyRepository
    {
    #nullable disable
        bool Create(Bibliography bibliography);
        void CreateBibliography(Bibliography bibliography);
        IEnumerable<Bibliography?> GetAll();
        Bibliography? GetById(int bibliography_Id);
        Bibliography? Delete(int bibliography_Id);
        Bibliography Update(string title, string author, string iSBN, string dataType, string detail, int site_Id, int bibliography_Id);
        Bibliography Update(Bibliography bibliography);
        
    }
}

