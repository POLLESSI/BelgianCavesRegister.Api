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
    public class SiteController : ControllerBase
    {
        private readonly ISiteRepository _siteRepository;
        private readonly SiteHub _siteHub;
        private readonly Dictionary<string, string> _currentSite = new Dictionary<string, string>();

        public SiteController(ISiteRepository siteRepository, SiteHub siteHub)
        {
            _siteRepository = siteRepository;
            _siteHub = siteHub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_siteRepository.GetAll());
        }

        [HttpGet("{site_id}")]
        public IActionResult GetById(int site_Id)
        {
            return Ok(_siteRepository.GetById(site_Id));
        }

        //[HttpPost("register")]
        //public IActionResult Register(Site newSite)
        //{
        //    _siteRepository.RegisterSite( newSite );
        //    return Ok();
        //}

        [HttpPost("create")]
        public async Task<IActionResult> Create(SiteRegisterForm site)
        {
            if (!ModelState.IsValid) 
                return BadRequest();
            if (_siteRepository.Create(site.SiteToDal()))
            {
                await _siteHub.RefreshSite();
                return Ok(site);
            }
            return BadRequest("Registration Error");
        }


        [HttpDelete("{site_id}")]
        //[ValidationAntiForgeryToken]
        public IActionResult Delete(int site_Id)
        {
            _siteRepository.Delete(site_Id);
            return Ok(); 
        }



        [HttpPut("{site_id}")]
        public IActionResult Ûpdate(int site_Id, string? site_Name, string? site_Description, string? latitude, string? longitude, string? length, string? depth, string? accessRequirement, string? pratcicalInformation, int donneesLambda_Id, int nOwner_Id, int scientificData_Id, int bibliography_Id)
        {
            _siteRepository.Update(site_Id, site_Name, site_Description, latitude, longitude, length, depth, accessRequirement, pratcicalInformation, donneesLambda_Id, nOwner_Id, scientificData_Id, bibliography_Id);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult ReceiveSiteUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                _currentSite[item.Key] = item.Value;
            }
            return Ok(_currentSite);
        }

        [HttpPatch("update")]
        public IActionResult Update(UpdateSiteForm si)
        {
            _siteRepository.Update(si.Site_Id,si.Site_Name, si.Site_Description, si.Latitude, si.Longitude, si.Length, si.Depth, si.AccessRequirement, si.PracticalInformation, si.DonneesLambda_Id, si.NOwner_Id, si.ScientificData_Id, si.Bibliography_Id);
            return Ok();
        }

        [HttpOptions("{site_id}")]

        IActionResult PrefligthRoute(int site_Id)
        {
            return NoContent();
        }
        // OPTIONS: api/Site
        [HttpOptions]
        IActionResult PrefligthRoute()
        {
            return NoContent();
        }
        [HttpPut("site_id")]
        IActionResult PutTodoItem(int site_Id)
        {
            if (site_Id < 1)
            {
                return BadRequest();
            }
            return Ok(site_Id);
        }
    }
}

