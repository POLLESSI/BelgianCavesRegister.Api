using Microsoft.AspNetCore.Mvc;
using BelgianCaveRegister_Api.Hubs;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Entities;

namespace BelgianCaveRegister_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LambdaDataController : ControllerBase
    {
        private readonly ILambdaDataRepository _LambdaDataRepository;
        //private readonly LambdaDataHub _lambdaDataHub;
        public LambdaDataController(ILambdaDataRepository lambdaDataRepository)
        {
            _LambdaDataRepository = lambdaDataRepository;
            //_lambdaDataHub = lambdaDataHub;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_LambdaDataRepository.GetAll());
        }
        [HttpGet("{LambdaData_Id}")]
        public IActionResult GetById(int donneesLambda_Id)
        {
            return Ok(_LambdaDataRepository.GetById(donneesLambda_Id));
        }

        [HttpPost("register")]
        public IActionResult Post(LambdaDataDTO newLambda)
        {
            _LambdaDataRepository.RegisterLambdaData( newLambda );
            return Ok();
        }


        [HttpDelete("{LambdaData_Id}")]
        //[ValidationAntiForgeryToken]
        public IActionResult Delete(int donneesLambda_Id)
        {
            _LambdaDataRepository.Delete(donneesLambda_Id);
            return Ok();
        }



        //[HttpPut("{LambdaData_Id}")]
        //public IActionResult Update(LambdaDataRegisterForm la)
        //{
        //    _LambdaDataService.Update(la.Localisation, la.Topo, la.Acces, la.EquipementSheet, la.PracticalInformation, la.Description);
        //    return Ok();
        //}




        //[HttpPatch("update")]
        //public IActionResult Update(LambdaDataRegisterForm la)
        //{
        //    _LambdaDataService.Update(la.Localisation, la.Topo, la.Acces, la.EquipementSheet, la.PracticalInformation, la.Description);
        //    return Ok();
        //}




    }
}

