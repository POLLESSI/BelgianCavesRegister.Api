using BelgianCavesRegister.Dal.Entities;

namespace BelgianCavesRegister.Dal.Interfaces
{
    public interface INOwnerRepository
    {
        void RegisterNOwner(NOwnerDTO newDto);
        IEnumerable<NOwnerDTO> GetAll();
        NOwnerDTO? GetById(int nOwner_Id);
        NOwnerDTO? Delete(int nOwner_Id);
        NOwnerDTO? Update(int nOwner_Id);
        //bool Create(string status, string agreement);
    }
}

