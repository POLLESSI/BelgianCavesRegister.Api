using BelgianCavesRegister.Dal.Entities;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface IBibliographyRepository
    {
        void RegisterBibliography(BibliographyDTO newDto);
        IEnumerable<BibliographyDTO> GetAll();
        BibliographyDTO? GetById(int bibliography_Id);
        BibliographyDTO? Delete(int bibliography_Id);
        BibliographyDTO? Update(int bibliography_Id);
        //bool Create(string title, string author, int iSBN, string dataType, string detail);
    }
}

