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
    public class ScientificDataController : ControllerBase
    {
        private readonly IScientificDataRepository _scientificDataRepository;
        private readonly ScientificDataHub _scientificDataHub;
        private readonly Dictionary<string, string> currentScientificData = new Dictionary<string, string>();

        public ScientificDataController(IScientificDataRepository scientificDataRepository, ScientificDataHub scientificDataHub)
        {
            _scientificDataRepository = scientificDataRepository;
            _scientificDataHub = scientificDataHub;
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

        //[HttpPost("register")]
        //public IActionResult Post(ScientificDataRegisterForm sc)
        //{
        //    _scientificDataRepository.RegisterScientificData(sc.DataType, sc.DetailsData, sc.ReferenceData);
        //    return Ok();
        //}

        [HttpPost]
        public async Task<IActionResult> Create(ScientificDataRegisterForm scientificData)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (_scientificDataRepository.Create(scientificData.ScientificDataToDal()))
            {
                await _scientificDataHub.RefreshScientificData();
                return Ok(scientificData);
            }
            return BadRequest("Registration Error");
        }


        [HttpDelete("{ScientificData_Id}")]
        //[ValidationAntiForgeryToken]
        public IActionResult Delete(int scientificData_Id)
        {
            _scientificDataRepository.Delete(scientificData_Id);
            return Ok();
        }



        [HttpPut("update")]
        public IActionResult Update(int scientificData_Id, string dataType, string detailsData, string referenceData)
        {
            _scientificDataRepository.Update(scientificData_Id, dataType, detailsData, referenceData);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult ReceiveScientificDataUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                currentScientificData[item.Key] = item.Value;
            }
            return Ok(currentScientificData);
        }

        //[HttpPatch("update")]
        //public IActionResult Update(ScientificDataRegisterForm sc)
        //{
        //    _scientificDataService.Update(sc.DataType, sc.DetailData, sc.ReferenceData);
        //    return Ok();
        //}




    }
}

