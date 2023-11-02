using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Repository;
using BelgianCavesRegister.Bll.Mappers;
using System.Threading.Tasks;
using System.Collections.Generic;
//using Microsoft.Data.SqlClient;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Bll.Entities;
using System.Linq;
using System.Security.Policy;

namespace BelgianCavesRegister.Models.Services
{
    public class SiteService : ISiteService
    {
        private readonly ISiteRepository _siteRepository;

        public SiteService(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }
        public void RegisterSite(string site_Name, string site_Description, double latitude, double longitude, decimal length, decimal depth, string accessRequirement, string practicalInformation, int donneesLambda_Id, int nOwner_Id, int scientificData_Id, int bibliography_Id)
        {
            _siteRepository.RegisterSite(site_Name, site_Description, latitude, longitude, length, depth, accessRequirement, practicalInformation, donneesLambda_Id, nOwner_Id, scientificData_Id, bibliography_Id);
        }

        public void Create(string site_Name, string site_Description, double latitude, double longitude, decimal length, decimal depth, string accessRequirement, string practicalInformation, int donneesLambda_Id, int nOwner_Id, int scientificData_Id, int bibliography_Id)
        {
            _siteRepository.Create(site_Name, site_Description, latitude, longitude, length, depth, accessRequirement, practicalInformation, donneesLambda_Id, nOwner_Id, scientificData_Id, bibliography_Id);
        }
        public IEnumerable<SitePOCO> GetAll()
        {
            return _siteRepository.GetAll().Select(x => x.SiDalToBll());
        }
        public SitePOCO? GetById(int site_Id)
        {
            return _siteRepository.GetById(site_Id).SiDalToBll();
        }
        public SitePOCO? Delete(int site_Id)
        {
            return _siteRepository.Delete(site_Id).SiDalToBll();
        }
        public SitePOCO? Update(int site_Id)
        {
            return _siteRepository.Update(site_Id).SiDalToBll();
        }
    }
}

