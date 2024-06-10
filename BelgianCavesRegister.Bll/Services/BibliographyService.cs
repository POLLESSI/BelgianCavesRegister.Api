using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;

namespace BelgianCavesRegister.Bll.Services
{
    public class BibliographyService : IBibliographyService
    {
        private readonly IBibliographyRepository _bibliographyRepository;

        public BibliographyService(IBibliographyRepository bibliographyRepository)
        {
            _bibliographyRepository = bibliographyRepository;
        }

        public bool Create(Bibliography bibliography)
        {
            try
            {
                return _bibliographyRepository.Create(bibliography);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating bibliography: {ex.ToString}");
            }
            return false;
        }

        public void CreateBibliography(Bibliography bibliography)
        {
            try
            {
                _bibliographyRepository.CreateBibliography(bibliography);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error CreateBibliography: {ex.ToString}");
            }
            
        }

        public Bibliography? Delete(int bibliography_Id)
        {
            try
            {
                return _bibliographyRepository.Delete(bibliography_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting bibliography: {ex.ToString}");
            }
            return null;
        }

        public IEnumerable<Bibliography?> GetAll()
        {
            return _bibliographyRepository.GetAll();
        }

        public Bibliography? GetById(int bibliography_Id)
        {

            try
            {
                return _bibliographyRepository.GetById(bibliography_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting bibliography: {ex.ToString}");
            }
            return null;
        }

        public Bibliography? Update(string title, string author, string iSBN, string dataType, string detail, int site_Id, int bibliography_Id)
        {
            try
            {
                var updateBibliography = _bibliographyRepository.Update(title, author, iSBN, dataType, detail, site_Id, bibliography_Id);
                return updateBibliography;
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating bibliography : {ex}");
            }
            return new Bibliography();
        }
    }
}
