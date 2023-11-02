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
    public class NPersonController : ControllerBase
    {
        private readonly INPersonService _nPersonService;
        private readonly NPersonHub _nPersonHub;

        public NPersonController(INPersonService nPersonService, NPersonHub nPersonHub)
        {
            _nPersonService = nPersonService;
            _nPersonHub = nPersonHub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_nPersonService.GetAll());
        }


        [HttpGet("{NPerson_Id}")]
        public IActionResult GetById(int nPerson_Id)
        {
            return Ok(_nPersonService.GetById(nPerson_Id));
        }

        //[Authorize("AdminPolicy")]
        [HttpPost]
        public IActionResult Create(NPersonForm np)
        {
            _nPersonService.Create(np.Lastname, np.Firstname, np.BirthDate, np.Address_Street, np.Address_Nbr, np.PostalCode, np.Address_City, np.Address_Country, np.Telephone, np.Gsm);
            return Ok();
        }

        [HttpPost("register")]
        public IActionResult Register(NPersonForm np)
        {
            _nPersonService.RegisterNPerson(np.Lastname, np.Firstname, np.BirthDate, np.Address_Street, np.Address_Nbr, np.PostalCode, np.Address_City, np.Address_Country, np.Telephone, np.Gsm);
            return Ok();
        }


        //[HttpDelete("{NPerson_Id}")]
        //[ValidationAntiForgeryToken]




        //[HttpPut("{NPerson_Id}")]




        //[HttpPatch("update")]
        //public IActionResult Update(NPersonForm np)
        //{
        //    _nPersonService.Update(np.Lastname, np.Firstname, np.BirthDate, np.Address_Street, np.Address_Nbr, np.PostalCode, np.Address_City, np.Address_Country, np.Telephone, np.Gsm);
        //    return Ok();
        //}



    }
}

