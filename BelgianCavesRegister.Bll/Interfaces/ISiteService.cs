using BelgianCavesRegister.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelgianCavesRegister.Bll.Entities;

namespace BelgianCavesRegister.Bll
{
    public interface ISiteService
    {
        void RegisterSite(string site_Name, string site_Description, double latitude, double longitude, decimal length, decimal depth, string accessRequirement, string practicalInformation, int donneesLambda_Id, int nOwner_Id, int scientificData_Id, int bibliography_Id);
        void Create(string site_Name, string site_Description, double latitude, double longitude, decimal length, decimal depth, string accessRequirement, string practicalInformation, int donneesLambda_Id, int nOwner_Id, int scientificData_Id, int bibliography_Id);
        IEnumerable<SitePOCO> GetAll();
        SitePOCO? GetById(int site_Id);
        SitePOCO? Delete(int site_Id);
        SitePOCO? Update(int site_Id);
    }
}

