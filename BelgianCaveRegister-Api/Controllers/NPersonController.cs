﻿using Microsoft.AspNetCore.Mvc;
using BelgianCaveRegister_Api.Hubs;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Entities;

namespace BelgianCaveRegister_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NPersonController : ControllerBase
    {
        private readonly INPersonRepository _nPersonRepository;
        //private readonly NPersonHub _nPersonHub;

        public NPersonController(INPersonRepository nPersonRepository )
        {
            _nPersonRepository = nPersonRepository;
            //_nPersonHub = nPersonHub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_nPersonRepository.GetAll());
        }


        [HttpGet("{NPerson_Id}")]
        public IActionResult GetById(int nPerson_Id)
        {
            return Ok(_nPersonRepository.GetById(nPerson_Id));
        }

        [HttpPost("register")]
        public IActionResult Post(NPersonDTO newNPerson)
        {
            _nPersonRepository.RegisterNPerson( newNPerson);
            return Ok();
        }


        [HttpDelete("{NPerson_Id}")]
        //[ValidationAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _nPersonRepository.Delete(id);
            return Ok();
        }



        //[HttpPut("{NPerson_Id}")]
        //public IActionResult Update(UpdateNPersonForm np)
        //{
        //    _nPersonService.Update(np.Lastname, np.Firstname, np.BirthDate, np.Address_Street, np.Address_Nbr, np.PostalCode, np.Address_City, np.Address_Country, np.Telephone, np.Gsm); 
        //    return Ok();
        //}



        //[HttpPatch("update")]
        //public IActionResult Update(NPersonForm np)
        //{
        //    _nPersonService.Update(np.Lastname, np.Firstname, np.BirthDate, np.Address_Street, np.Address_Nbr, np.PostalCode, np.Address_City, np.Address_Country, np.Telephone, np.Gsm);
        //    return Ok();
        //}



    }
}

