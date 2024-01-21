using Microsoft.AspNetCore.Mvc;
using BelgianCaveRegister_Api.Hubs;
using BelgianCavesRegister.Dal.Interfaces;
//using BelgianCavesRegister.Dal.Repository;
//using BelgianCavesRegister.Dal.Entities;
using Microsoft.AspNetCore.Http;
using BelgianCaveRegister_Api.Dto.Forms;
using BelgianCaveRegister_Api.Tools;
using System.Security.Cryptography;

namespace BelgianCaveRegister_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LambdaDataController : ControllerBase
    {
        private readonly ILambdaDataRepository _LambdaDataRepository;
        private readonly LambdaDataHub _lambdaDataHub;
        public LambdaDataController(ILambdaDataRepository lambdaDataRepository, LambdaDataHub lambdaDataHub)
        {
            _LambdaDataRepository = lambdaDataRepository;
            _lambdaDataHub = lambdaDataHub;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_LambdaDataRepository.GetAll());
        }
        [HttpGet("{DonneesLambda_Id}")]
        public IActionResult GetById(int donneesLambda_Id)
        {
            return Ok(_LambdaDataRepository.GetById(donneesLambda_Id));
        }

        //[HttpPost("register")]
        //public IActionResult Post(LambdaDataRegisterForm la)
        //{
        //    _LambdaDataRepository.RegisterLambdaData( la.Localisation, la.Topo, la.Acces, la.EquipementSheet, la.PracticalInformation, la.Description);
        //    return Ok();
        //}
        [HttpPost("Create")]
        public async Task<IActionResult> Create(LambdaDataRegisterForm lambdaDataRegister)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            if (_LambdaDataRepository.Create(lambdaDataRegister.LambdaDataToDal()))
            {
                await _lambdaDataHub.RefreshLambdaData();
                return Ok();
            }
            return BadRequest("Registration error");
        }

        [HttpDelete("{LambdaData_Id}")]
        //[ValidationAntiForgeryToken]
        public IActionResult Delete(int donneesLambda_Id)
        {
            _LambdaDataRepository.Delete(donneesLambda_Id);
            return Ok();
        }



        [HttpPut("{LambdaData_Id}")]
        public IActionResult Update(int donneesLambda_Id, string localisation, string topo, string acces, string equipementSheet, string practicalInformation, string description)
        {
            _LambdaDataRepository.Update(donneesLambda_Id,localisation, topo, acces, equipementSheet, practicalInformation, description);
            return Ok();
        }




        //[HttpPatch("update")]
        //public IActionResult Update(UpdateLambdaDataForm la)
        //{
        //    _LambdaDataRepository.Update(la.DonneesLambda_Id,la.Localisation, la.Topo, la.Acces, la.EquipementSheet, la.PracticalInformation, la.Description);
        //    return Ok();
        //}




    }
}

