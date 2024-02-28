using Microsoft.AspNetCore.Mvc;
using BelgianCaveRegister_Api.Hubs;
using BelgianCavesRegister.Dal.Interfaces;
using Microsoft.AspNetCore.Http;
using BelgianCaveRegister_Api.Dto.Forms;
using BelgianCaveRegister_Api.Tools;
using System.Security.Cryptography;

namespace BelgianCaveRegister_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NOwnerController : ControllerBase
    {
        private readonly INOwnerRepository _nOwnerRepository;
        private readonly NOwnerHub _nOwnerHub;
        private readonly Dictionary<string, string> _currentNOwner = new Dictionary<string, string>();

        public NOwnerController(INOwnerRepository nOwnerRepository, NOwnerHub nOwnerHub)
        {
            _nOwnerRepository = nOwnerRepository;
            _nOwnerHub = nOwnerHub;
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


        //[HttpPost("register")]
        //public IActionResult Post(NOwner newNOwner)
        //{
        //    _nOwnerRepository.RegisterNOwner( newNOwner );
        //    return Ok();
        //}

        [HttpPost("Create")]
        public async Task<IActionResult> Create(NOwnerRegisterForm nOwnerRegister)
        {
            if (!ModelState.IsValid) 
                return BadRequest();
            if (_nOwnerRepository.Create(nOwnerRegister.NOwnerToDal()))
            {
                await _nOwnerHub.RefreshNOwner();
                return Ok(nOwnerRegister);
            }
            return BadRequest("Registration error");
        }

        [HttpDelete("{nOwner_Id}")]
        //[ValidationAntiForgeryToken]
        public IActionResult Delete(int nOwner_Id)
        {
            _nOwnerRepository.Delete(nOwner_Id);
            return Ok();
        }



        [HttpPut("{NOwner_Id}")]

        public IActionResult Update(int nOwner_Id, string status, string agreement)
        {
            _nOwnerRepository.Update(nOwner_Id, status, agreement);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult ReceiveNOwnerUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                _currentNOwner[item.Key] = item.Value;
            }
            return Ok(_currentNOwner);
        }

        //[HttpPatch("Update")]
        //public IActionResult Update(UpdateNOwnerForm no)
        //{
        //    _nOwnerService.Update(no.Status, no.Agreement);
        //    return Ok();
        //} 

    }
}
