using BelgianCavesRegister.Dal.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.Bibliography;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface IBibliographyRepository
    {
        bool Create(Bibliography bibliography);
        void AddBibliography(string title, string author, int iSBN, string dataType, string detail);
        IEnumerable<Bibliography> GetAll();
        Bibliography? GetById(int bibliography_Id);
        Bibliography? Delete(int bibliography_Id);
        Bibliography? Update(int bibliography_Id, string title, string author, int iSBN, string dataType, string detail);
        Bibliography? Update(Bibliography bibliography);
    }
}

