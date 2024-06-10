using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BelgianCaveRegister_Api.Hubs;
using BelgianCaveRegister_Api.Dto.Forms;
using BelgianCaveRegister_Api.Tools;
using BelgianCavesRegister.Dal.Interfaces;
using System.Security.Cryptography;

namespace BelgianCaveRegister_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliographyController : ControllerBase
    {
        private readonly IBibliographyRepository _bibliographyRepository;
        private readonly BibliographyHub _bibliographyHub;
        private readonly Dictionary<string, string> _currentBibliography = new Dictionary<string, string>();
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


        [HttpGet("{bibliography_Id}")]
        public IActionResult GetById(int bibliography_Id)
        {
            return Ok (_bibliographyRepository.GetById(bibliography_Id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(BibliographyRegisterForm newBibliography)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (_bibliographyRepository.Create(newBibliography.BibliographyToDal()))
            {
                await _bibliographyHub.RefreshBibliography(); // Provoque un TypeError: Networkerror when attempting to fetch resource 
                return Ok(newBibliography);
            }
            return BadRequest("Registration error");
        }

        //[HttpPost("register")]
        //public IActionResult Post(Bibliography newBiblio)
        //{
        //    _bibliographyRepository.RegisterBibliography( newBiblio );
        //    return Ok();
        //}


        [HttpDelete("{bibliography_Id}")]
        //[ValidationAntiForgeryToken]
        public IActionResult Delete(int Bibliography_id) 
        {
            _bibliographyRepository.Delete(Bibliography_id); 
            return Ok();        
        }

        [HttpPut("{bibliography_Id}")]
        public IActionResult Update(string title, string author, string iSBN, string dataType, string detail, int site_Id, int bibliography_Id)
        {
            _bibliographyRepository.Update(title, author, iSBN, dataType, detail, site_Id, bibliography_Id);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult ReceiveBibliographyUpdate(Dictionary<string, string> newUpdate) 
        {
            foreach (var item in newUpdate)
            {
                _currentBibliography[item.Key] = item.Value;
            }
            return Ok();
        }

        //[HttpPatch("update")]
        //public IActionResult Update(UpdateBibliographyForm b)
        //{
        //    _bibliographyService.Update(b.Title, b.Author, b.ISBN, b.DataType, b.Detail);
        //    return Ok();
        //}

        //[HttpOptions("{bibliography_Id}")]
        //IActionResult PrefligthRoute(int bibliography_id)
        //{
        //    return NoContent();
        //}

        //// OPTIONS: api/Bibliography
        //[HttpOptions]
        //IActionResult PrefligthRoute()
        //{
        //    return NoContent();
        //}
        //[HttpPut("bibliography_Id")]
        //IActionResult PutTodoItem(int bibliography_Id)
        //{
        //    if (bibliography_Id < 1)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(bibliography_Id);
        //}

    }
}

