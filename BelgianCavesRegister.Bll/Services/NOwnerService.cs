using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Bll.Mappers;
using BelgianCavesRegister.Bll.Entities;

namespace BelgianCavesRegister.Bll.Services
{
    public class NOwnerService : INOwnerService
    {
        private readonly INOwnerRepository _nOwnerRepository;
        public NOwnerService(INOwnerRepository nOwnerRepository)
        {
            _nOwnerRepository = nOwnerRepository;
        }
        public void RegisterNOwner(string status, string agreement)
        {
            _nOwnerRepository.RegisterNOwner(status, agreement);
        }
        public void Create(string status, string agreement)
        {
            _nOwnerRepository.Create(status, agreement);
        }
        public IEnumerable<NOwnerPOCO> GetAll()
        {
            return _nOwnerRepository.GetAll().Select(x => x.NoDalToBll());
        }
        public NOwnerPOCO? GetById(int nOwner_Id)
        {
            return _nOwnerRepository.GetById(nOwner_Id).NoDalToBll();
        }
        public NOwnerPOCO? Delete(int nOwner_Id)
        {
            return _nOwnerRepository.Delete(nOwner_Id).NoDalToBll();
        }
        public NOwnerPOCO? Update(int nOwner_Id)
        {
            return _nOwnerRepository.Update(nOwner_Id).NoDalToBll();
        }
    }
}
