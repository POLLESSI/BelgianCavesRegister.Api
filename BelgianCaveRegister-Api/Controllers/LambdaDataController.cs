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
    public class LambdaDataController : ControllerBase
    {
        private readonly ILambdaDataRepository _LambdaDataRepository;
        private readonly LambdaDataHub _lambdaDataHub;
        private readonly Dictionary<string, string> _currentLambdaData = new Dictionary<string, string>();
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
        //public IActionResult Post(LambdaData newLambda)
        //{
        //    _LambdaDataRepository.RegisterLambdaData( newLambda );
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
                return Ok(lambdaDataRegister);
            }
            return BadRequest("Registration error");
        }

        [HttpDelete("{DonneesLambda_Id}")]
        //[ValidationAntiForgeryToken]
        public IActionResult Delete(int donneesLambda_Id)
        {
            _LambdaDataRepository.Delete(donneesLambda_Id);
            return Ok();
        }



        [HttpPut("{DonneesLambda_Id}")]
        public IActionResult Update(int donneesLambda_Id, string localisation, string topo, string acces, string equipementSheet, string practicalInformation, string description)
        {
            _LambdaDataRepository.Update(donneesLambda_Id, localisation, topo, acces, equipementSheet, practicalInformation, description);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult ReceiveLambdaDataUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                _currentLambdaData[item.Key] = item.Value;

            }
            return Ok();
        }


        //[HttpPatch("update")]
        //public IActionResult Update(LambdaDataRegisterForm la)
        //{
        //    _LambdaDataService.Update(la.Localisation, la.Topo, la.Acces, la.EquipementSheet, la.PracticalInformation, la.Description);
        //    return Ok();
        //}




    }
}

