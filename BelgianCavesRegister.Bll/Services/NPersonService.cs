using BelgianCavesRegister.Bll.Entities;
using BelgianCavesRegister.Bll.Mappers;
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
        public void RegisterNPerson(NPersonDTO newPoco)
        {
            _nPersonRepository.RegisterNPerson(newPoco.NpBllToDal());
        }
        //public void Create(string lastname, string firstname, DateTime birthDate, string address_Street, int address_Nbr, int postalCode, string address_City, string address_Country, int telephone, int gsm)
        //{
        //    _nPersonRepository.Create(lastname, firstname, birthDate, address_Street, address_Nbr, postalCode, address_City, address_Country, telephone, gsm);
        //}
        public IEnumerable<NPersonPOCO> GetAll()
        {
            return _nPersonRepository.GetAll().Select(x => x.NpDalToBll());
        }
        public NPersonPOCO? GetById(int nPerson_Id)
        {
            return _nPersonRepository.GetById(nPerson_Id).NpDalToBll();
        }
        public NPersonPOCO? Delete(int nPerson_Id)
        {
            return _nPersonRepository.Delete(nPerson_Id).NpDalToBll();
        }
        public NPersonPOCO? Update(int nPerson_Id)
        {
            return _nPersonRepository.Update(nPerson_Id).NpDalToBll();
        }
    }
}
