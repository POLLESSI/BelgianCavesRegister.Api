using Microsoft.AspNetCore.Mvc;
using BelgianCaveRegister_Api.Hubs;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCaveRegister_Api.Dto.Forms;
using BelgianCaveRegister_Api.Tools;

namespace BelgianCaveRegister_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliographyController : ControllerBase
    {
        private readonly IBibliographyRepository _bibliographyRepository;
        private readonly BibliographyHub _bibliographyHub;
        public BibliographyController(IBibliographyRepository bibliographyRepository, BibliographyHub bibliographyHub)
        {
            _bibliographyRepository = bibliographyRepository;
            _bibliographyHub = bibliographyHub;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_bibliographyRepository.GetAll());
        }


        [HttpGet("{Bibliography_Id}")]
        public IActionResult GetById(int bibliography_Id)
        {
            return Ok(_bibliographyRepository.GetById(bibliography_Id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(BibliographyRegisterForm? newBibliography)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (_bibliographyRepository.Create(newBibliography.BibliographyToDal()))
            {
                await _bibliographyHub.RefreshBibliography();
                return Ok();
            }
            return BadRequest("Registration error");
        }


        //[HttpPost("register")]
        //public IActionResult Post(BibliographyRegisterForm bl)
        //{
        //    _bibliographyRepository.RegisterBibliography( bl.Title, bl.Author, bl.ISBN, bl.DataType, bl.Detail);
        //    return Ok();
        //}


        [HttpDelete("{Bibliography_Id}")]
        //[ValidationAntiForgeryToken]
        public IActionResult Delete(int Bibliography_id) 
        {
            _bibliographyRepository.Delete(Bibliography_id); 
            return Ok();        
        }

        [HttpPut("{Bibliography_Id}")]
        public IActionResult Update(UpdateBibliographyForm bl)
        {
            _bibliographyRepository.Update(bl.Bibliography_Id, bl.Title, bl.Author, bl.ISBN, bl.DataType, bl.Detail);
            return Ok();
        }



        //[HttpPatch("update")]
        //public IActionResult Update(UpdateBibliographyForm b)
        //{
        //    _bibliographyService.Update(b.Title, b.Author, b.ISBN, b.DataType, b.Detail);
        //    return Ok();
        //}


    }
}

