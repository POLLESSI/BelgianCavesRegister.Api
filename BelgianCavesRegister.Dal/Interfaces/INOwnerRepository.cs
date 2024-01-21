using BelgianCavesRegister.Dal.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using static BelgianCavesRegister.Dal.Entities.NOwner;


namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface INOwnerRepository
    {
        bool Create(NOwner nowner);
        void AddNOwner(string status, string agreement);
        IEnumerable<NOwner> GetAll();
        NOwner? GetById(int nOwner_Id);
        NOwner? Delete(int nOwner_Id);
        NOwner? Update(int nOwner_Id, string status, string agreement);
    }
}

