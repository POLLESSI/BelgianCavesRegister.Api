using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BelgianCavesRegister.Dal;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Api.Hubs;
using BelgianCavesRegister.Api.Mappers;
using BelgianCavesRegister.Api.Tools;
using BelgianCavesRegister.Api.Dto.Forms;
using BelgianCavesRegister.Dal.Interfaces;

namespace BelgianCavesRegister.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteController : ControllerBase
    {
        private readonly ISiteRepository _siteService;
        private readonly SiteHub _siteHub;

        public SiteController(ISiteRepository siteRepository, SiteHub siteHub)
        {
            _siteService = siteRepository;
            _siteHub = siteHub;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_siteService.GetAll());
        }

        [HttpGet("{Site_Id}")]
        public IActionResult GetById(int site_Id)
        {
            return Ok(_siteService.GetById(site_Id));
        }


        [HttpPost("create")]
        public IActionResult Create(SiteRegisterForm si)
        {
            _siteService.Create(si.Site_name, si.Site_Description, si.Latitude, si.Longitude, si.Length, si.Depth, si.AccessRequirement, si.PracticalInformation, si.DonneesLambda_Id, si.NOwner_Id, si.ScientificData_Id, si.Bibliography_Id);
            return Ok();
        }

        [HttpPost("register")]
        public IActionResult Register(SiteRegisterForm si)
        {
            _siteService.RegisterSite(si.Site_name, si.Site_Description, si.Latitude, si.Longitude, si.Length, si.Depth, si.AccessRequirement, si.PracticalInformation, si.DonneesLambda_Id, si.NOwner_Id, si.ScientificData_Id, si.Bibliography_Id);
            return Ok();
        }


        //[HttpDelete("{Site_Id}")]
        //[ValidationAntiForgeryToken]




        //[HttpPut("{Site_Id}")]



        //[HttPatch("update")]
        //public IActionResult Update(UpdateSiteForm si)
        //{
        //    _siteService.Update(si.Site_Name, si.Site_Description, si.Latitude, si.Length, si.Depth, si.AccessRequirement, si.PracticalInformation, si.DonneesLambda_Id, si.NOwner_Id, si.ScientificData_Id, si.Bibliography_Id);
        //    return Ok();
        //}





    }
}

