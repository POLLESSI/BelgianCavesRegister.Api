using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Dal.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using BelgianCavesRegister.Dal.Interfaces;
using System.Data.Entity.Infrastructure;

namespace BelgianCavesRegister.Bll.Services
{
    public class NPersonService : INPersonService
    {
        private readonly INPersonRepository _nPersonRepository;

        public NPersonService(INPersonRepository nPersonRepository)
        {
            _nPersonRepository = nPersonRepository;
        }
        public bool Create(NPerson nPerson)
        {
            try
            {
                _nPersonRepository.Create(nPerson);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error creating new person: {ex.ToString}");
            }
            return true;
        }
        public void AddNPerson(string lastname, string firstname, DateTime birthDate, string email, string address_Street, int address_Nbr, int postalCode, string address_City, string address_Country, int telephone, int gsm)
        {
            try
            {
                _nPersonRepository.AddNPerson(lastname, firstname, birthDate, email, address_Street, address_Nbr, postalCode, address_City, address_Country, telephone, gsm);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error adding new person: {ex.ToString}");
            }
            
        }
        public IEnumerable<NPerson> GetAll()
        {
            try
            {
                return _nPersonRepository.GetAll();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting all persons: {ex.ToString}");
            }
            return Enumerable.Empty<NPerson>();
        }
        public NPerson? GetById(int nPerson_Id)
        {
            try
            {
                return _nPersonRepository.GetById(nPerson_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error geting person: {ex.Message}");
            }
            return new NPerson();
        }
        public NPerson? Delete(int nPerson_Id)
        {
            try
            {
                return _nPersonRepository.Delete(nPerson_Id);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error deleting perso: {ex.Message}");
            }
            return null;
        }
        public NPerson? Update(int nPerson_Id, string lastname, string firstname, DateTime birthDate, string email, string address_Street, int address_Nbr, int postalCode, string address_City, string address_Country, int telephone, int gsm)
        {
            try
            {
                var updateNperson = _nPersonRepository.Update(nPerson_Id, lastname, firstname, birthDate, email, address_Street, address_Nbr, postalCode, address_City, address_Country, telephone, gsm);

                return updateNperson;
            }
            catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            {

                Console.WriteLine($"Validation error : {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"Database update error : {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating person : {ex.Message}");
            }
            return new NPerson();
            //return _nPersonRepository.Update(nPerson_Id, lastname, firstname, birthDate, email, address_Street, address_Nbr, postalCode, address_City, address_Country, telephone, gsm);
        }
    }
}
