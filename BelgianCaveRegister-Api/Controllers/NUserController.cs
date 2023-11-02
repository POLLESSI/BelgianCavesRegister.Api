using BelgianCaveRegister_Api.Tools;
using Microsoft.AspNetCore.Mvc;
using BelgianCaveRegister_Api.Dto.Forms;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Entities;
using BelgianCaveRegister_Api.Hubs;

namespace BelgianCaveRegister_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NUserController : ControllerBase
    {
        private readonly BelgianCavesRegister.Dal.Interfaces.INUserRepository _userRepository;
        private readonly TokenGenerator _tokenGenerator;
       //private readonly NUserHub _nUserHub;

        public NUserController(BelgianCavesRegister.Dal.Interfaces.INUserRepository userRepository, TokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
            //_nUserHub = nUserHub;
        }

        //[Authorize("ModelPolicy")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetAll());
        }

        //[Authorize("ModelPolicy")]
        [HttpGet("{NUser_Id}")]
        public IActionResult GetById(Guid nUser_Id)
        {
            return Ok(_userRepository.GetById(nUser_Id));
        }

        [HttpPost("Login")]
        public IActionResult Login(NUserDTO nUser)
        {
            try
            {
                NUserDTO? connectedNUser = _userRepository.LoginNUser(nUser.PasswordHash, nUser.Email);
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
        

        [HttpPost("register")]
        public IActionResult Register(NUserDTO nu)
        {
            _userRepository.RegisterNUser( nu);
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
        [HttpDelete("{NUser_Id}")]
        public IActionResult Delete(Guid nUser_Id)
        {
            _userRepository.Delete(nUser_Id);
            return Ok();
        }

        [HttpPatch("setRole")]
        public IActionResult ChangeRole(ChangeRole r)
        {
            _userRepository.SetRole(r.NUser_Id, r.Role_Id);
            return Ok();
        }
        
        //[HttpPatch("update")]
        //public IActionResult Update(UpdateNUserForm nu)
        //{
        //    _nUserService.Update(nu.Pseudo, nu.Email, nu.Role_Id);
        //    return Ok();
        //}

        //[HttpPut("{NUser_Id}")]
        //public IActionResult Update(UpdateNUserForm nu)
        //{
        //    _nUserService.Update(nu.Pseudo, nu.Email, nu.Role_Id);
        //    return Ok();
        //}




    }
}
