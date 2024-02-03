using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Dal.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using BelgianCavesRegister.Dal.Interfaces;
using System.Data.Entity.Infrastructure;

namespace BelgianCavesRegister.Models.Services
{
    public class SiteService : ISiteService
    {
        private readonly ISiteRepository _siteRepository;

        public SiteService(ISiteRepository siteRepository)
        {
            _siteRepository = siteRepository;
        }
        

        public bool Create(Site site)
        {
            return _siteRepository.Create(site);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error creating site : {ex.ToString}");
            //}
            //return true;
        }
        //public void CreateSite(Site site)
        //{
        //    _siteRepository.CreateSite(site);
        //}

        public IEnumerable<Site> GetAll()
        {
            return _siteRepository.GetAll();
        }
        public Site? GetById(int site_Id)
        {
            return _siteRepository.GetById(site_Id);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error geting site : {ex.ToString}");
            //}
            //return new Site();
        }
        public Site? Delete(int site_Id)
        {
            return _siteRepository.Delete(site_Id);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error deleting site : {ex.ToString}");
            //}
            //return null;
        }
        public Site? Update(int site_Id, string site_Name, string site_Description, double latitude, double longitude, decimal length, decimal depth, string accessRequirement, string practicalInformation, int donneesLambda_Id, int nOwner_Id, int scientificData_Id, int bibliography_Id)
        {
            var updateSite = _siteRepository.Update(site_Id, site_Name, site_Description, latitude, longitude, length, depth, accessRequirement, practicalInformation, donneesLambda_Id, nOwner_Id, scientificData_Id, bibliography_Id);

            return updateSite;
            //try
            //{
                
            //}
            //catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            //{

            //    Console.WriteLine($"Validation error : {ex.Message}");

            //}
            //catch (DbUpdateException ex)
            //{
            //    Console.WriteLine($"Database uodate error : {ex.Message}");

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error updating site : {ex}");

            //}
            //return new Site();
            //return _siteRepository.Update(site_Id, site_Name, site_Description, latitude, longitude, length, depth, accessRequirement, practicalInformation, donneesLambda_Id, nOwner_Id, scientificData_Id, bibliography_Id) ;
        }
    }
}

