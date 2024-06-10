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
        bool Create(NOwner nOwner);
        void CreateNOwner(NOwner nOwner);
        IEnumerable<NOwner?> GetAll();
        NOwner? GetById(int nOwner_Id);
        NOwner? Delete(int nOwner_Id);
        NOwner? Update(string status, string agreement, int site_Id, int nOwner_Id);
    }
}
