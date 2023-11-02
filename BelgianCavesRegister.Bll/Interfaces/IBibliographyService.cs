using BelgianCavesRegister.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelgianCavesRegister.Dal;
using BelgianCavesRegister.Bll.Entities;

namespace BelgianCavesRegister.Bll
{
    public interface IBibliographyService
    {
        void RegisterBibliography(string title, string author, int iSBN, string dataType, string detail);
        void Create(string title, string author, int iSBN, string dataType, string detail);
        IEnumerable<BibliographyPOCO?> GetAll();
        BibliographyPOCO? GetById(int bibliography_Id);
        BibliographyPOCO? Delete(int bibliography_Id);
        BibliographyPOCO? Update(string title, string author, int bibliography_Id);
    }
}

