using Microsoft.AspNetCore.Mvc;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Api.Hubs;
using BelgianCavesRegister.Api.Dto.Forms;

namespace BelgianCavesRegister.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LambdaDataController : ControllerBase
    {
        private readonly ILambdaDataService _LambdaDataService;
        private readonly LambdaDataHub _lambdaDataHub;
        public LambdaDataController(ILambdaDataService lambdaDataService, LambdaDataHub lambdaDataHub)
        {
            _LambdaDataService = lambdaDataService;
            _lambdaDataHub = lambdaDataHub;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_LambdaDataService.GetAll());
        }
        [HttpGet("{LambdaData_Id}")]
        public IActionResult GetById(int donneesLambda_Id)
        {
            return Ok(_LambdaDataService.GetById(donneesLambda_Id));
        }

        [HttpPost("create")]
        public IActionResult Create(LambdaDataRegisterForm la)
        {
            _LambdaDataService.Create(la.Localisation, la.Topo, la.Acces, la.EquipementSheet, la.PracticalInformation, la.Description);
            return Ok();
        }

        [HttpPost("register")]
        public IActionResult Register(LambdaDataRegisterForm la)
        {
            _LambdaDataService.RegisterLambdaData(la.Localisation, la.Topo, la.Acces, la.EquipementSheet, la.PracticalInformation, la.Description);
            return Ok();
        }


        //[HttpDelete("{LambdaData_Id}")]
        //[ValidationAntiForgeryToken]




        //[HttpPut("{LambdaData_Id}")]




        //[HttpPatch("update")]
        //public IActionResult Update(LambdaDataRegisterForm la)
        //{
        //    _LambdaDataService.Update(la.Localisation, la.Topo, la.Acces, la.EquipementSheet, la.PracticalInformation, la.Description);
        //    return Ok();
        //}




    }
}

