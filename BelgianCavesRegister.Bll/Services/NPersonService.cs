using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Dal.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using BelgianCavesRegister.Dal.Interfaces;

namespace BelgianCavesRegister.Bll.Services
{
    public class NPersonService : INPersonService
    {
        private readonly INPersonRepository _nPersonRepository;

        public NPersonService(INPersonRepository nPersonRepository)
        {
            _nPersonRepository = nPersonRepository;
        }
        public void Create(NPerson nPerson)
        {
            _nPersonRepository.Create(nPerson);
        }
        public void CreateNPerson(string lastname, string firstname, DateTime birthDate, string email, string address_Street, int address_Nbr, int postalCode, string address_City, string address_Country, int telephone, int gsm)
        {
            _nPersonRepository.CreateNPerson(lastname, firstname, birthDate, email , address_Street, address_Nbr, postalCode, address_City, address_Country, telephone, gsm);
        }
        public IEnumerable<NPerson> GetAll()
        {
            return _nPersonRepository.GetAll();
        }
        public NPerson? GetById(int nPerson_Id)
        {
            return _nPersonRepository.GetById(nPerson_Id);
        }
        public NPerson? Delete(int nPerson_Id)
        {
            return _nPersonRepository.Delete(nPerson_Id);
        }
        public NPerson? Update(int nPerson_Id, string lastname, string firstname, DateTime birthDate, string email, string address_Street, int address_Nbr, int postalCode, string address_City, string address_Country, int telephone, int gsm)
        {
            return _nPersonRepository.Update(nPerson_Id, lastname, firstname, birthDate, email, address_Street, address_Nbr, postalCode, address_City, address_Country, telephone, gsm);
        }
    }
}
