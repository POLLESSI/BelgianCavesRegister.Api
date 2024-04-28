using BelgianCavesRegister.Dal.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.NOwner;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface INOwnerRepository
    {
        bool Create(NOwner nOwner);
        void CreateNOwner(NOwner nOwner);
        IEnumerable<NOwner?> GetAll();
        NOwner? GetById(int nOwner_Id);
        NOwner? Delete(int nOwner_Id);
        NOwner? Update(int nOwner_Id, string status, string agreement);
    }
}

