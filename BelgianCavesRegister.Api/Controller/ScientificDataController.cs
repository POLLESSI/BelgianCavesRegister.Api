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
    public class ScientificDataController : ControllerBase
    {
        private readonly IScientificDataService _scientificDataService;
        private readonly ScientificDataHub _scientificDataHub;

        public ScientificDataController(IScientificDataService scientificDataService, ScientificDataHub scientificDataHub)
        {
            _scientificDataService = scientificDataService;
            _scientificDataHub = scientificDataHub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_scientificDataService.GetAll());
        }

        [HttpGet("{ScientificData_Id}")]
        public IActionResult GetById(int scientificData_Id)
        {
            return Ok(_scientificDataService.GetById(scientificData_Id));
        }

        [HttpPost("create")]
        public IActionResult Create(ScientificDataRegisterForm sc)
        {
            _scientificDataService.Create(sc.DataType, sc.DetailData, sc.ReferenceData);
            return Ok();
        }

        //[HttpDelete("{ScientificData_Id}")]
        //[ValidationAntiForgeryToken]




        //[HttpPut("{ScientificData_Id}")]



        //[HttpPatch("update")]
        //public IActionResult Update(ScientificDataRegisterForm sc)
        //{
        //    _scientificDataService.Update(sc.DataType, sc.DetailData, sc.ReferenceData);
        //    return Ok();
        //}




    }
}

