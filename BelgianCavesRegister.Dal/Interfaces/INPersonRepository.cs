using BelgianCavesRegister.Dal.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.NPerson;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface INPersonRepository
    {
        bool Create(NPerson nPerson);
        //void CreateNPerson(NPerson person);
        IEnumerable<NPerson> GetAll();
        NPerson? GetById(int nPerson_Id);
        NPerson? Delete(int nPerson_Id);
        NPerson? Update(int nPerson_Id, string lastname, string firstname, DateTime birthDate, string email, string address_Street, int address_Nbr, int postalCode, string address_City, string address_Country, int telephone, int gsm);
        
        
    }
}

