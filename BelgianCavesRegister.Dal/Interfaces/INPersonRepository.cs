using BelgianCavesRegister.Dal.Entities;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface INPersonRepository
    {
        void RegisterNPerson(NPersonDTO newDto);
        IEnumerable<NPersonDTO> GetAll();
        NPersonDTO? GetById(int nPerson_Id);
        NPersonDTO? Delete(int nPerson_Id);
        NPersonDTO? Update(int nPerson_Id);
        //bool Create(string lastname, string firstname, DateTime birthDate, string address_Street, int address_Nbr, int postalCode, string address_City, string address_Country, int telephone, int gsm);
    }
}

