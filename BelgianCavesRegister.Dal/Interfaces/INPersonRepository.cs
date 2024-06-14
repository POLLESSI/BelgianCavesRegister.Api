using BelgianCavesRegister.Dal.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.NPerson;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface INPersonRepository
    {
    #nullable disable
        bool Create(NPerson person);
        void CreateNPerson(NPerson person);
        IEnumerable<NPerson> GetAll();
        NPerson? GetById(int nPerson_Id);
        NPerson? Delete(int nPerson_Id);
        NPerson Update(string lastname, string firstname, DateTime birthDate, string email, string address_Street, string address_Nbr, string postalCode, string address_City, string address_Country, string telephone, string gsm, int nPerson_Id);
    }
}

