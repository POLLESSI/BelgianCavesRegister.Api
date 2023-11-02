using BelgianCavesRegister.Dal.Entities;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface ISiteRepository
    {
        void RegisterSite(SiteDTO newDto);
        IEnumerable<SiteDTO> GetAll();
        SiteDTO? GetById(int site_Id);
        SiteDTO? Delete(int site_Id);
        SiteDTO? Update(int site_Id);
        //bool Create(string site_Name, string site_Description, double latitude, double longitude, decimal length, decimal depth, string accessRequirement, string practicalInformation, int donneesLambda_Id, int nOwner_Id, int scientificData_Id, int bibliography_Id);
    }
}
