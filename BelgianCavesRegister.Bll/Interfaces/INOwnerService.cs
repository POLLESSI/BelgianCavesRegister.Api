using BelgianCavesRegister.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BelgianCavesRegister.Dal;
using BelgianCavesRegister.Bll.Entities;

namespace BelgianCavesRegister.Bll
{
    public interface INOwnerService
    {
        void RegisterNOwner(string status, string agreement);
        void Create(string status, string agreement);
        IEnumerable<NOwnerPOCO> GetAll();
        NOwnerPOCO? GetById(int nOwner_Id);
        NOwnerPOCO? Delete(int nOwner_Id);
        NOwnerPOCO? Update(int nOwner_Id);
    }
}
