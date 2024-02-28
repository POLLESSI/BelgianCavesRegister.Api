using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Repository;
using BelgianCavesRegister.Bll;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

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
            try
            {
                return _siteRepository.Create(site);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating site: {ex.ToString}");
            }
            return false;
        }

        public void CreateSite(Site site)
        {
            try
            {
                _siteRepository.CreateSite(site);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error Creation Site: {ex.ToString}");
            }
        }

        public Site? Delete(int site_Id)
        {
            try
            {
                return _siteRepository.Delete(site_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting site: {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<Site?> GetAll()
        {
            return _siteRepository.GetAll();
        }

        public Site? GetById(int site_Id)
        {
            try
            {
                return _siteRepository.GetById(site_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting site: {ex.ToString}");
            }
            return null;
        }

        public Site? Update(int site_Id, string site_Name, string site_Description, string latitude, string longitude, string length, string depth, string accessRequirement, string practicalInformation, int donneesLambda_Id, int nOwner_Id, int scientificData_id, int bibliography_Id)
        {
            try
            {
                var updateSite = _siteRepository.Update(site_Id, site_Name, site_Description, latitude, longitude, length, depth, accessRequirement, practicalInformation, donneesLambda_Id, nOwner_Id, scientificData_id, bibliography_Id);
                return updateSite;
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Database update error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating site: {ex}");
            }
            return new Site();
        }
    }
}

