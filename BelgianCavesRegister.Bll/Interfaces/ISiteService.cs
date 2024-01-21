using BelgianCavesRegister.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.Site;

namespace BelgianCavesRegister.Bll
{
    public interface ISiteService
    {
        void AddSite(string site_Name, string site_Description, double latitude, double longitude, decimal length, decimal depth, string accessRequirement, string practicalInformation, int donneesLambda_Id, int nOwner_Id, int scientificData_Id, int bibliography_Id);
        bool Create(Site site);
        IEnumerable<Site> GetAll();
        Site? GetById(int site_Id);
        Site? Delete(int site_Id);
        Site? Update(int site_Id, string site_Name, string site_Description, double latitude, double longitude, decimal length, decimal depth, string accessRequirement, string practicalInformation, int donneesLambda_Id, int nOwner_Id, int scientificData_Id, int bibliography_Id);
    }
}

