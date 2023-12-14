using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Dal.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using BelgianCavesRegister.Dal.Interfaces;

namespace BelgianCavesRegister.Bll.Services
{
    public class BibliographyService : IBibliographyService
    {
        private readonly IBibliographyRepository _bibliographyRepository;

        public BibliographyService(IBibliographyRepository bibliographyRepository)
        {
            _bibliographyRepository = bibliographyRepository;
        }

        public void CreateBibliography(string title, string author, int iSBN, string dataType, string detail)
        {
            _bibliographyRepository.CreateBibliography(title, author, iSBN, dataType, detail);
        }
        public void Create(Bibliography bibliography)
        {
            _bibliographyRepository.Create(bibliography);
        }
        public IEnumerable<Bibliography> GetAll()
        {
            return _bibliographyRepository.GetAll();
        }
        public Bibliography? GetById(int bibliography_Id)
        {
            return _bibliographyRepository.GetById(bibliography_Id);
        }
        public Bibliography? Delete(int bibliography_Id)
        {
            return _bibliographyRepository.Delete(bibliography_Id);
        }

        public Bibliography? Update(int bibliography_Id, string title, string author, int iSBN, string dataType, string detail)
        {
            return _bibliographyRepository.Update(bibliography_Id, title, author, iSBN, dataType, detail);
        }
        public Bibliography? Update(string title, string author, int iSBN, string dataType, string detail, int bibliography_Id)
        {
            return _bibliographyRepository.Update(bibliography_Id, title, author, iSBN, dataType, detail);
        }
    }
}
