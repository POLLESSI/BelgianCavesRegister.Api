﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly Dictionary<string, string> currentSite = new Dictionary<string, string>();

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
                return Ok(site);
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
        public IActionResult Update(int site_Id, string site_Name, string site_Description, string latitude, string longitude, string length, string depth, string accessRequirement, string practicalInformation, int donneesLambda_Id, int nOwner_Id,int scientificData_Id, int bibliography_Id)
        {
            _siteRepository.Update(site_Id, site_Name, site_Description, latitude, longitude, length, depth, accessRequirement, practicalInformation, donneesLambda_Id, nOwner_Id, scientificData_Id, bibliography_Id);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult ReceiveSiteUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                currentSite[item.Key] = item.Value;
            }
            return Ok(currentSite);
        }

        //[HttPatch("update")]
        //public IActionResult Update(UpdateSiteForm si)
        //{
        //    _siteService.Update(si.Site_Name, si.Site_Description, si.Latitude, si.Length, si.Depth, si.AccessRequirement, si.PracticalInformation, si.DonneesLambda_Id, si.NOwner_Id, si.ScientificData_Id, si.Bibliography_Id);
        //    return Ok();
        //}





    }
}

