using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Dal.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using BelgianCavesRegister.Dal.Interfaces;

namespace BelgianCavesRegister.Bll.Services
{
    public class NOwnerService : INOwnerService
    {
        private readonly INOwnerRepository _nOwnerRepository;
        public NOwnerService(INOwnerRepository nOwnerRepository)
        {
            _nOwnerRepository = nOwnerRepository;
        }
        public void CreateNOwner(string status, string agreement)
        {
            _nOwnerRepository.CreateNOwner(status, agreement);
        }
        public void Create(NOwner nOwner)
        {
            _nOwnerRepository.Create(nOwner);
        }
        public IEnumerable<NOwner> GetAll()
        {
            return _nOwnerRepository.GetAll();
        }
        public NOwner? GetById(int nOwner_Id)
        {
            return _nOwnerRepository.GetById(nOwner_Id);
        }
        public NOwner? Delete(int nOwner_Id)
        {
            return _nOwnerRepository.Delete(nOwner_Id);
        }
        public NOwner? Update(int nOwner_Id, string status, string agreement)
        {
            return _nOwnerRepository.Update(nOwner_Id, status, agreement);
        }
    }
}
