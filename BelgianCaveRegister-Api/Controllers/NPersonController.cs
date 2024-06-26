﻿using Microsoft.AspNetCore.Mvc;
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
    public class NPersonController : ControllerBase
    {
        private readonly INPersonRepository _nPersonRepository;
        private readonly NPersonHub _nPersonHub;
        private readonly Dictionary<string, string> _currentNPerson = new Dictionary<string, string>();

        public NPersonController(INPersonRepository nPersonRepository, NPersonHub nPersonHub)
        {
            _nPersonRepository = nPersonRepository;
            _nPersonHub = nPersonHub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_nPersonRepository.GetAll());
        }


        [HttpGet("{nperson_id}")]
        public IActionResult GetById(int nPerson_Id)
        {
            return Ok(_nPersonRepository.GetById(nPerson_Id));
        }

        //[HttpPost("register")]
        //public IActionResult Post(NPerson newNPerson)
        //{
        //    _nPersonRepository.RegisterNPerson( newNPerson);
        //    return Ok();
        //}
        [HttpPost("create")]
        public async Task<IActionResult> Create(NPersonForm newPerson)
        {
            if (!ModelState.IsValid) 
                return BadRequest();
            if (_nPersonRepository.Create(newPerson.NPersonToDal()))
            {
                await _nPersonHub.RefreshPerson();
                return Ok(newPerson);
            }
            return BadRequest("Registration Error");
        }


        [HttpDelete("{nperson_id}")]
        //[ValidationAntiForgeryToken]
        public IActionResult Delete(int nPerson_Id)
        {
            _nPersonRepository.Delete(nPerson_Id);
            return Ok();
        }



        [HttpPut("{nperson_id}")]
        public IActionResult Update(int nPerson_Id, string lastname, string firstname, DateTime birthDate, string email, string address_Street, string address_Nbr, string postalCode, string address_City, string address_Country, string telephone, string gsm)
        {
            _nPersonRepository.Update(nPerson_Id, lastname, firstname, birthDate, email, address_Street, address_Nbr, postalCode, address_City, address_Country, telephone, gsm);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult ReceiveNPersonUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                _currentNPerson[item.Key] = item.Value;
            }
            return Ok(_currentNPerson);
        }

        //[HttpPatch("update")]
        //public IActionResult Update(NPersonForm np)
        //{
        //    _nPersonService.Update(np.Lastname, np.Firstname, np.BirthDate, np.Address_Street, np.Address_Nbr, np.PostalCode, np.Address_City, np.Address_Country, np.Telephone, np.Gsm);
        //    return Ok();
        //}

        [HttpOptions("{nperson_id}")]
        IActionResult PrefligthRoute(int nPerson_Id)
        {
            return NoContent();
        }
        // OPTIONS: api/Scientificdata
        [HttpOptions]
        IActionResult PrefligthRoute()
        {
            return NoContent();
        }
        [HttpPut("scientificdata_id")]
        IActionResult PutTodoItem(int nPerson_Id)
        {
            if (nPerson_Id < 1)
            {
                return BadRequest();
            }
            return Ok(nPerson_Id);
        }
    }
}

