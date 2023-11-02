using Microsoft.AspNetCore.Mvc;
using BelgianCaveRegister_Api.Hubs;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Entities;

namespace BelgianCaveRegister_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScientificDataController : ControllerBase
    {
        private readonly IScientificDataRepository _scientificDataRepository;
        //private readonly ScientificDataHub _scientificDataHub;

        public ScientificDataController(IScientificDataRepository scientificDataRepository)
        {
            _scientificDataRepository = scientificDataRepository;
            //_scientificDataHub = scientificDataHub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_scientificDataRepository.GetAll());
        }

        [HttpGet("{ScientificData_Id}")]
        public IActionResult GetById(int scientificData_Id)
        {
            return Ok(_scientificDataRepository.GetById(scientificData_Id));
        }

        //[HttpPost("create")]
        //public IActionResult Create(ScientificDataRegisterForm sc)
        //{
        //    _scientificDataRepository.Create(sc.DataType, sc.DetailData, sc.ReferenceData);
        //    return Ok();
        //}

        [HttpPost("register")]
        public IActionResult Post(ScientificDataDTO newScien)
        {
            _scientificDataRepository.RegisterScientificData(newScien);
            return Ok();
        }

        [HttpDelete("{ScientificData_Id}")]
        //[ValidationAntiForgeryToken]
        public IActionResult Delete(int scientificData_Id)
        {
            _scientificDataRepository.Delete(scientificData_Id);
            return Ok();
        }



        //[HttpPut("{ScientificData_Id}")]
        //public IActionResult Update(ScientificDataRegisterForm sc)
        //{
        //    _scientificDataService.Update(sc.DataType, sc.DetailData, sc.ReferenceData);
        //    return Ok();
        //}



        //[HttpPatch("update")]
        //public IActionResult Update(ScientificDataRegisterForm sc)
        //{
        //    _scientificDataService.Update(sc.DataType, sc.DetailData, sc.ReferenceData);
        //    return Ok();
        //}




    }
}

