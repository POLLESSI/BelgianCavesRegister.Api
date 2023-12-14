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
        void CreateBibliography(string title, string author, int iSBN, string dataType, string detail);
        void Create(Bibliography bibliography);
        IEnumerable<Bibliography?> GetAll();
        Bibliography? GetById(int bibliography_Id);
        Bibliography? Delete(int bibliography_Id);
        Bibliography? Update(int bibliography_Id, string title, string author, int iSBN, string dataType, string detail);
    }
}

