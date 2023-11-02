using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BelgianCavesRegister.Dal;
using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Api.Hubs;
using BelgianCavesRegister.Api.Mappers;
using BelgianCavesRegister.Api.Tools;
using BelgianCavesRegister.Api.Dto;
using BelgianCavesRegister.Api.Dto.Forms;

namespace BelgianCavesRegister.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliographyController : ControllerBase
    {
        private readonly IBibliographyService _bibliographyService;
        private readonly BibliographyHub _bibliographyHub;
        public BibliographyController(IBibliographyService bibliographyService, BibliographyHub bibliographyHub)
        {
            _bibliographyService = bibliographyService;
            _bibliographyHub = bibliographyHub;

        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_bibliographyService.GetAll());
        }


        [HttpGet("{Bibliography_Id}")]
        public IActionResult GetById(int bibliography_Id)
        {
            return Ok(_bibliographyService.GetById(bibliography_Id));
        }

        [HttpPost("create")]
        public IActionResult Create(BibliographyRegisterForm bibliographyForm)
        {
            _bibliographyService.Create(bibliographyForm.Title, bibliographyForm.Author, bibliographyForm.ISBN, bibliographyForm.DataType, bibliographyForm.Detail);
            return Ok();
        }

        [HttpPost("register")]
        public IActionResult Register(BibliographyRegisterForm bibliographyRegisterForm)
        {
            _bibliographyService.RegisterBibliography(bibliographyRegisterForm.Title, bibliographyRegisterForm.Author, bibliographyRegisterForm.ISBN, bibliographyRegisterForm.DataType, bibliographyRegisterForm.Detail);
            return Ok();
        }


        //[HttpDelete("{Bibliography_Id}")]
        //[ValidationAntiForgeryToken]




        //[HttpPut("{Bibliography_Id}")]




        //[HttpPatch("update")]
        //public IActionResult Update(UpdateBibliographyForm b)
        //{
        //    _bibliographyService.Update(b.Title, b.Author, b.ISBN, b.DataType, b.Detail);
        //    return Ok();
        //}


    }
}

