using BelgianCavesRegister.Bll;
using BelgianCavesRegister.Bll.Entities;
using BelgianCavesRegister.Api.Tools;
using Microsoft.AspNetCore.Mvc;
using BelgianCavesRegister.Api.Dto.Forms;

namespace BelgianCavesRegister.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NUserController : ControllerBase
    {
        private readonly INUserService _nUserService;
        private readonly TokenGenerator _tokenGenerator;
        //private readonly NUserHub _nUserHub;

        public NUserController(INUserService userService, TokenGenerator tokenGenerator)
        {
            _nUserService = userService;
            _tokenGenerator = tokenGenerator;
            
        }

        //[Authorize("ModelPolicy")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_nUserService.GetAll());
        }

        //[Authorize("ModelPolicy")]
        [HttpGet("{NUser_Id}")]
        public IActionResult GetById(Guid nUser_Id)
        {
            return Ok(_nUserService.GetById(nUser_Id));
        }

        [HttpPost("Login")]
        public IActionResult Login(NUserLoginForm nUser)
        {
            try
            {
                NUserPOCO connectedNUser = _nUserService.LoginNUser(nUser.PasswordHash, nUser.Email);
                string MdpNUser = nUser.PasswordHash;
                string hashpwd = connectedNUser.PasswordHash;
                bool motDePassValide = BCrypt.Net.BCrypt.Verify(MdpNUser, hashpwd);

                if (motDePassValide)
                {
                    return Ok(_tokenGenerator.GenerateToken(connectedNUser));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpPost("create")]
        //public IActionResult Create(NUserRegisterForm nu)
        //{
        //    _nUserService.Create(nu.Pseudo, nu.PasswordHash, nu.Email, nu.PasswordHash, nu.SecondPassword, nu.NPerson_Id, nu.Role_Id);
        //    return Ok();
        //}

        [HttpPost("register")]
        public IActionResult Register(NUserRegisterForm nu)
        {
            _nUserService.RegisterNUser(nu.Pseudo, nu.Email, nu.PasswordHash, nu.NPerson_Id, nu.Role_Id);
            return Ok();
        }
        //[HttpPost]
        //[ValidationAntiForgeryToken]
        //public ActionResult Validation(NUserRegisterForm form)
        //{
        //    ValidatePassword(form, ModelState);
        //    if (!ModelState.IsValid) { return BadRequest(); }
        //    else
        //        return RedirectToAction("Details", new { Id = 1 });
        //}

        //private static void ValidatePassword(NUserRegisterForm form, ModelStateDictionary modelState)
        //{
        //    if (form.PasswordHash is null)
        //    {
        //        modelState.AddModelError(nameof(NUserRegisterForm.PasswordHash), "Password cannot be null...");
        //        return;
        //    }
        //    if (!Regex.IsMatch(form.PasswordHash, "[0-9]"))
        //        modelState.AddModelError(nameof(NUserRegisterForm.PasswordHash), "You need at least one number.");
        //    if (!Regex.IsMatch(form.PasswordHash, "[a-z]"))
        //        modelState.AddModelError(nameof(NUserRegisterForm.PasswordHash), "You need at least a tiny letter.");
        //    if (!Regex.IsMatch(form.PasswordHash, "[A-Z]"))
        //        modelState.AddModelError(nameof(NUserRegisterForm.PasswordHash), "You need at least a capital letter.");
        //    if (!Regex.IsMatch(form.PasswordHash, @"[\\-\\.=+*@?]"))
        //        modelState.AddModelError(nameof(NUserRegisterForm.PasswordHash), "You need at least one special character.");
        //}
        //[Authorize("ModelPolicy")]
        [HttpPatch("setRole")]
        public IActionResult ChangeRole(ChangeRole r)
        {
            _nUserService.SetRole(r.NUser_Id, r.Role_Id);
            return Ok();
        }

        //[HttpPatch("update")]
        //public IActionResult Update(UpdateNUserForm nu)
        //{
        //    _nUserService.Update(nu.Pseudo, nu.Email, nu.Role_Id);
        //    return Ok();
        //}



        //[HttpDelete("{NUser_Id}")]
        //[ValidationAntiForgeryToken]




        //[HttpPut("{NUser_Id}")]




    }
}
