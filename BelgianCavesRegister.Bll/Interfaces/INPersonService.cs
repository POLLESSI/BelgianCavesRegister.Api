using BelgianCavesRegister.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Bll.Entities;

namespace BelgianCavesRegister.Bll
{
    public interface INPersonService
    {
        void RegisterNPerson(NPersonDTO newPoco);
        //void Create(string lastname, string firstname, DateTime birthDate, string address_Street, int address_Nbr, int postalCode, string address_City, string address_Country, int telephone, int gsm);
        IEnumerable<NPersonDTO> GetAll();
        NPersonDTO? GetById(int nPerson_Id);
        NPersonDTO? Delete(int nPerson_Id);
        NPersonDTO? Update(int nPerson_Id);
    }
}
