using BelgianCavesRegister.Dal.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.Site;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface ISiteRepository
    {
        bool Create(Site site);
        void CreateSite(Site site);
        IEnumerable<Site> GetAll();
        Site GetById(int site_Id);
        Site Delete(int site_Id);
        Site Update(int site_Id, string site_Name, string site_Decription, string latitude, string longitude, string length, string depth, string accessRequirement, string practicalInformation, int donneesLambda_Id, int nOwner_Id, int scientificData_Id, int bibliography_Id);
    }
}
