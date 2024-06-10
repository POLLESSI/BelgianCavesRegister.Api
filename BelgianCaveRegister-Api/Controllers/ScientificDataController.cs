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
        private readonly Dictionary<string, string> _currentScientificData = new Dictionary<string, string>();

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

        [HttpGet("{scientificData_Id}")]
        public IActionResult GetById(int scientificData_Id)
        {
            return Ok (_scientificDataRepository.GetById(scientificData_Id));
        }

        //[HttpPost("create")]
        //public IActionResult Create(ScientificDataRegisterForm sc)
        //{
        //    _scientificDataRepository.Create(sc.DataType, sc.DetailData, sc.ReferenceData);
        //    return Ok();
        //}

        //[HttpPost("register")]
        //public IActionResult Post(ScientificData newScien)
        //{
        //    _scientificDataRepository.RegisterScientificData(newScien);
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

        [HttpDelete("{scientificData_Id}")]
        //[ValidationAntiForgeryToken]
        public IActionResult Delete(int scientificData_Id)
        {
            _scientificDataRepository.Delete(scientificData_Id);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update(string? dataType, string? detailsdata, string? referenceData, int site_Id, int scientificData_Id)
        {
            _scientificDataRepository.Update(dataType, detailsdata, referenceData, site_Id, scientificData_Id);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult ReceiveScientificDataUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                _currentScientificData[item.Key] = item.Value;
            }
            return Ok(_currentScientificData);
        }


        //[HttpPut("{ScientificData_Id}")]
        //public IActionResult Update(ScientificDataRegisterForm sc)
        //{
        //    _scientificDataService.Update(sc.DataType, sc.DetailData, sc.ReferenceData);
        //    return Ok();
        //}



        [HttpPatch("update")]
        public IActionResult Update(UpdateScientificDataForm sc)
        {
            _scientificDataRepository.Update(sc.DataType, sc.DetailsData, sc.ReferenceData, sc.Site_Id, sc.ScientificData_Id);
            return Ok();
        }

        //[HttpOptions("{scientificData_Id}")]
        //IActionResult PrefligthRoute(int scientificData_Id)
        //{
        //    return NoContent();
        //}
        //// OPTIONS: api/ScientifiData
        //[HttpOptions]
        //IActionResult PrefligthRoute()
        //{
        //    return NoContent();
        //}
        //[HttpPut("scientificData_Id")]
        //IActionResult PutTodoItem(int scientificData_Id)
        //{
        //    if (scientificData_Id < 1)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(scientificData_Id);
        //}
    }
}

