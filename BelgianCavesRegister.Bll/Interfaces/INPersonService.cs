using BelgianCavesRegister.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.NPerson;

namespace BelgianCavesRegister.Bll
{
    public interface INPersonService
    {
        bool Create(NPerson nPerson);
        void CreateNPerson(NPerson nPerson);
        IEnumerable<NPerson> GetAll();
        NPerson? GetById(int nPerson_Id);
        NPerson? Delete(int nPerson_Id);
        NPerson? Update(int nPerson_Id, string lastname, string firstname, DateTime birthDate, string email, string address_Street, int address_Nbr, int postalCode, string address_City, string address_Country, int telephone, int gsm);
    }
}
