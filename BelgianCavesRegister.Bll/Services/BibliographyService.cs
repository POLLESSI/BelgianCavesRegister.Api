using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Dal.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using BelgianCavesRegister.Dal.Interfaces;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Http.Connections.Client;
using System.Data.Entity.Infrastructure;

namespace BelgianCavesRegister.Bll.Services
{
    public class BibliographyService : IBibliographyService
    {
        private readonly IBibliographyRepository _bibliographyRepository;
        
        public BibliographyService(IBibliographyRepository bibliographyRepository)
        {
            _bibliographyRepository = bibliographyRepository;
            
        }

        //public async Task ConnectAsync()
        //{
        //    try
        //    {
        //        await _hubConnection.StartAsync();
        //        Console.WriteLine("Connected to SignalR Hub");

        //        // Ecoute des événements
        //        _hubConnection.On("ReceiveBibliographyUpdate", (List<BibliographyService> updates) =>
        //        {
        //            try
        //            {
        //                foreach (var update in updates)
        //                {
                            
        //                }
        //                // Traitment des mises à jour recues depuis le hub
        //                Console.WriteLine("Received Bibliography Update");
        //                // Réaliser des opérations supplémentaires, par exemple :
        //                // - Mettre à jour une liste ou un état dans votre application.
        //                // - Actualiser l'interface utilisateur pour reflèter les changements
        //                // - Exécuter des opérations spécifiques basées sur les données reçues
        //            }
        //            catch (Exception ex)
        //            {

        //                Console.WriteLine($"Error processing Bibliography Update: {ex.Message}");
        //            }
                    
        //        });
        //    }
        //    catch (Exception ex) 
        //    {
        //        Console.WriteLine($"Error connecting to SignalR Hub: {ex.Message} + {ex.ToString}");
        //    }
        //}
        //public void AddBibliography(Bibliography bibliography)
        //{
        //    try
        //    {
        //        _bibliographyRepository.AddBibliography(bibliography);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error adding bibliography: {ex.ToString}");
        //        // Gère les erreurs en conséquence
        //    }
            
        //}
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
            return true;
        }
        public void CreateBibliography(Bibliography bibliography)
        {
            _bibliographyRepository.CreateBibliography(bibliography);
        }
        public IEnumerable<Bibliography> GetAll()
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
            return new Bibliography();
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

        public Bibliography? Update(int bibliography_Id, string title, string author, string iSBN, string dataType, string detail)
        {
            try
            {
                var updateBibliography = _bibliographyRepository.Update(bibliography_Id, title, author, iSBN, dataType, detail);
                // Mettre à jour l'interface utilisateur ou les données locales avec updatedBibliography si nécessaire
                return updateBibliography;
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {
                Console.WriteLine($"Validation error : {ex.Message}");
                // Afficher un message à l'utilisateur indiquant une erreur lors d'un erreur de validation
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Database update error: {ex.Message}");
                //Journaliser l'erreur pour le suivi ultérieur
                //Afficher un message à l'utilisateur indiquant une erreur lors de la mise à jour des données
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating bibliography: {ex}");
            }
            return new Bibliography();
            //return _bibliographyrepository.update(bibliography_id, title, author, isbn, datatype, detail);
        }


    }
}
