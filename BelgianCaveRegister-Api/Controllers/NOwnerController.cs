using Microsoft.AspNetCore.Mvc;
using BelgianCaveRegister_Api.Hubs;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Entities;

namespace BelgianCaveRegister_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NOwnerController : ControllerBase
    {
        private readonly INOwnerRepository _nOwnerRepository;
        //private readonly NOwnerHub _nOwnerHub;

        public NOwnerController(INOwnerRepository nOwnerRepository)
        {
            _nOwnerRepository = nOwnerRepository;
            //_nOwnerHub = nOwnerHub;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_nOwnerRepository.GetAll());
        }
        [HttpGet("{nOwner_Id}")]
        public IActionResult GetById(int nOwner_Id)
        {
            return Ok(_nOwnerRepository.GetById(nOwner_Id));
        }


        [HttpPost("register")]
        public IActionResult Post(NOwnerDTO newNOwner)
        {
            _nOwnerRepository.RegisterNOwner( newNOwner );
            return Ok();
        }


        [HttpDelete("{nOwner_Id}")]
        //[ValidationAntiForgeryToken]
        public IActionResult Delete(int nOwner_Id)
        {
            _nOwnerRepository.Delete(nOwner_Id);
            return Ok();
        }



        //[HttpPut("{NOwner_Id}")]

        //public IActionResult Update(NOwnerRegisterForm no)
        //{
        //    _nOwnerService.Update(no.Status, no.Agreement);
        //    return Ok();
        //}
            


        //[HttpPatch("Update")]
        //public IActionResult Update(UpdateNOwnerForm no)
        //{
        //    _nOwnerService.Update(no.Status, no.Agreement);
        //    return Ok();
        //} 

    }
}
