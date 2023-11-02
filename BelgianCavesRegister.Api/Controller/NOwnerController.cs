using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BelgianCavesRegister.Dal;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Api.Hubs;
using BelgianCavesRegister.Api.Mappers;
using BelgianCavesRegister.Api.Tools;
using BelgianCavesRegister.Api.Dto.Forms;

namespace BelgianCavesRegister.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NOwnerController : ControllerBase
    {
        private readonly INOwnerService _nOwnerService;
        private readonly NOwnerHub _nOwnerHub;

        public NOwnerController(INOwnerService nOwnerService, NOwnerHub nOwnerHub)
        {
            _nOwnerService = nOwnerService;
            _nOwnerHub = nOwnerHub;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_nOwnerService.GetAll());
        }
        [HttpGet("{nOwner_Id}")]
        public IActionResult GetById(int nOwner_Id)
        {
            return Ok(_nOwnerService.GetById(nOwner_Id));
        }

        [HttpPost("create")]
        public IActionResult Create(NOwnerRegisterForm no)
        {
            _nOwnerService.Create(no.Status, no.Agreement);
            return Ok();
        }

        [HttpPost("register")]

        public IActionResult Register(NOwnerRegisterForm no)
        {
            _nOwnerService.RegisterNOwner(no.Status, no.Agreement);
            return Ok();
        }


        //[HttpDelete("{nOwner_Id}")]
        //[ValidationAntiForgeryToken]




        //[HttpPut("{NOwner_Id}")]
        //[HttpPatch("Update")]
        //public IActionResult Update(UpdateNOwnerForm no)
        //{
        //    _nOwnerService.Update(no.Status, no.Agreement);
        //    return Ok();
        //} 

    }
}
