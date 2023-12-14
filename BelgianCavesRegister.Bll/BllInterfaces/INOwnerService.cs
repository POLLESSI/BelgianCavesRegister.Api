using BelgianCavesRegister.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.NOwner;

namespace BelgianCavesRegister.Bll
{
    public interface INOwnerService
    {
        void CreateNOwner(string status, string agreement);
        void Create(NOwner nOwner);
        IEnumerable<NOwner> GetAll();
        NOwner? GetById(int nOwner_Id);
        NOwner Delete(int nOwner_Id);
        NOwner Update(int nOwner_Id, string status, string agreement);
    }
}
