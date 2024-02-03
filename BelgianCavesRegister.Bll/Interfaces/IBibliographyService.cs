using BelgianCavesRegister.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.Bibliography;

namespace BelgianCavesRegister.Bll
{
    public interface IBibliographyService
    {
        bool Create(Bibliography bibliography);
        //void CreateBibliography(Bibliography bibliography);
        IEnumerable<Bibliography?> GetAll();
        Bibliography? GetById(int bibliography_Id);
        Bibliography? Delete(int bibliography_Id);
        Bibliography? Update(int bibliography_Id, string title, string author, string iSBN, string dataType, string detail);
    }
}

