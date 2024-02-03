using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Dal.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace BelgianCavesRegister.Bll.Services
{
    public class NOwnerService : INOwnerService
    {
        private readonly INOwnerRepository _nOwnerRepository;
        public NOwnerService(INOwnerRepository nOwnerRepository)
        {
            _nOwnerRepository = nOwnerRepository;
        }
        //public void AddNOwner(string status, string agreement)
        //{
        //    _nOwnerRepository.AddNOwner(status, agreement);
        //    //try
        //    //{
               

        //    //}
        //    //catch (Exception ex)
        //    //{

        //    //    Console.WriteLine($"Error adding new owner: {ex.ToString}");
        //    //}
        //}
        public bool Create(NOwner nOwner)
        {
            return _nOwnerRepository.Create(nOwner);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error creating new owner: {ex.ToString}");
            //}
            //return true;
        }
        //public void CreateNOwner(NOwner nOwner)
        //{
        //    _nOwnerRepository.CreateNOwner(nOwner);
        //}
        public IEnumerable<NOwner> GetAll()
        {
            return _nOwnerRepository.GetAll();
        }
        public NOwner? GetById(int nOwner_Id)
        {
            return _nOwnerRepository.GetById(nOwner_Id);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error geting owner: {ex.ToString}");
            //}
            //return new NOwner();
        }
        public NOwner? Delete(int nOwner_Id)
        {
            return _nOwnerRepository.Delete(nOwner_Id);
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    Console.WriteLine($"Error deleting owner: {ex.ToString}");
            //}
            //return null;
            
        }
        public NOwner? Update(int nOwner_Id, string status, string agreement)
        {
            var updateNOwner = _nOwnerRepository.Update(nOwner_Id, status, agreement);

            return updateNOwner;
            //try
            //{
                
            //}
            //catch (System.ComponentModel.DataAnnotations.ValidationException ex)
            //{
            //    Console.WriteLine($"Validation error : {ex.Message}");

            //}
            //catch (DbUpdateException ex)
            //{
            //    Console.WriteLine($"Database update error : {ex.Message}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error updating bibliography : {ex}");
            //}
            //return new NOwner();
            //return _nOwnerRepository.Update(nOwner_Id, status, agreement);
        }
    }
}
