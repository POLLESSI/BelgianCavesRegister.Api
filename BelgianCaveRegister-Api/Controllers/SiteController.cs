using Microsoft.AspNetCore.Mvc;
using BelgianCaveRegister_Api.Hubs;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Entities;
using BelgianCaveRegister_Api.Dto.Forms;
using BelgianCaveRegister_Api.Tools;

namespace BelgianCaveRegister_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController : ControllerBase
    {
        private readonly ISiteRepository _siteRepository;
        private readonly SiteHub _siteHub;

        public SiteController(ISiteRepository siteRepository, SiteHub siteHub )
        {
            _siteRepository = siteRepository;
            _siteHub = siteHub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_siteRepository.GetAll());
        }

        [HttpGet("{Site_Id}")]
        public IActionResult GetById(int site_Id)
        {
            return Ok(_siteRepository.GetById(site_Id));
        }

        //[HttpPost("register")]
        //public IActionResult Register(SiteRegisterForm si)
        //{
        //    _siteRepository.RegisterSite( si.Site_Name, si.Site_Description, si.Latitude, si.Longitude, si.Length, si.Depth, si.AccessRequirement, si.PracticalInformation, si.DonneesLambda_Id, si.NOwner_Id, si.ScientificData_Id, si.Bibliography_Id );
        //    return Ok();

        [HttpPost("Create")]
        public async Task<IActionResult> Create(SiteRegisterForm site)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (_siteRepository.Create(site.SiteToDal()))
            {
                await _siteHub.RefreshSite();
                return Ok();
            }
            return BadRequest("Registration Error");
        }


        [HttpDelete("{Site_Id}")]
        //[ValidationAntiForgeryToken]
        public IActionResult Delete(int site_Id)
        {
            _siteRepository.Delete(site_Id);
            return Ok(); 
        }



        [HttpPut("{Site_Id}")]
        public IActionResult Ûpdate(UpdateSiteForm si)
        {
            _siteRepository.Update(si.Site_Id, si.Site_Name, si.Site_Description, si.Latitude, si.Longitude, si.Length, si.Depth, si.AccessRequirement, si.PracticalInformation, si.DonneesLambda_Id, si.NOwner_Id, si.ScientificData_Id, si.Bibliography_Id);
            return Ok();
        }



        //[HttPatch("update")]
        //public IActionResult Update(UpdateSiteForm si)
        //{
        //    _siteService.Update(si.Site_Name, si.Site_Description, si.Latitude, si.Length, si.Depth, si.AccessRequirement, si.PracticalInformation, si.DonneesLambda_Id, si.NOwner_Id, si.ScientificData_Id, si.Bibliography_Id);
        //    return Ok();
        //}





    }
}

