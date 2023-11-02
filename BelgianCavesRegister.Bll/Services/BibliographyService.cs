using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Repository;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using BelgianCavesRegister.Bll.Mappers;
using BelgianCavesRegister.Bll.Entities;

namespace BelgianCavesRegister.Bll.Services
{
    public class BibliographyService : IBibliographyService
    {
        private readonly IBibliographyRepository _bibliographyRepository;

        public BibliographyService(IBibliographyRepository bibliographyRepository)
        {
            _bibliographyRepository = bibliographyRepository;
        }

        public void RegisterBibliography(string title, string author, int iSBN, string dataType, string detail)
        {
            _bibliographyRepository.RegisterBibliography(title, author, iSBN, dataType, detail);
        }
        public void Create(string title, string author, int iSBN, string dataType, string detail)
        {
            _bibliographyRepository.Create(title, author, iSBN, dataType, detail);
        }
        public IEnumerable<BibliographyPOCO> GetAll()
        {
            //string sql = "SELECT * FROM Bibliography";
            return _bibliographyRepository.GetAll().Select(x => x.BiDalToBll());
        }
        public BibliographyPOCO? GetById(int bibliography_Id)
        {
            return _bibliographyRepository.GetById(bibliography_Id).BiDalToBll();
        }
        public BibliographyPOCO? Delete(int bibliography_Id)
        {
            return _bibliographyRepository.Delete(bibliography_Id).BiDalToBll();
        }

        public BibliographyPOCO? Update(string title, string author, int bibliography_Id)
        {
            return _bibliographyRepository.Update(bibliography_Id).BiDalToBll();
        }
    }
}
