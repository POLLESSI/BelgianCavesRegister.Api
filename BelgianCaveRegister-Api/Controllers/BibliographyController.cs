using Microsoft.AspNetCore.Mvc;
using BelgianCaveRegister_Api.Hubs;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Entities;

namespace BelgianCaveRegister_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliographyController : ControllerBase
    {
        private readonly IBibliographyRepository _bibliographyRepository;
        //private readonly BibliographyHub _bibliographyHub;
        public BibliographyController(IBibliographyRepository bibliographyRepository)
        {
            _bibliographyRepository = bibliographyRepository;
            //_bibliographyHub = bibliographyHub;
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


        [HttpPost("register")]
        public IActionResult Post(BibliographyDTO newBiblio)
        {
            _bibliographyRepository.RegisterBibliography( newBiblio );
            return Ok();
        }


        [HttpDelete("{Bibliography_Id}")]
        //[ValidationAntiForgeryToken]
        public IActionResult Delete(int Bibliography_id) 
        {
            _bibliographyRepository.Delete(Bibliography_id); 
            return Ok();        
        }

        //[HttpPut("{Bibliography_Id}")]
        //public IActionResult Update( UpdateBibliographyForm b) 
        //{ 
        //    _bibliographyService.Update(b.Title, b.Author, b.ISBN, b.DataType, b.Detail);
        //    return Ok();
        //}



        //[HttpPatch("update")]
        //public IActionResult Update(UpdateBibliographyForm b)
        //{
        //    _bibliographyService.Update(b.Title, b.Author, b.ISBN, b.DataType, b.Detail);
        //    return Ok();
        //}


    }
}

