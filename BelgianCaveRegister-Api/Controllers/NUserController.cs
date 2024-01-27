using BelgianCaveRegister_Api.Tools;
using Microsoft.AspNetCore.Mvc;
using BelgianCaveRegister_Api.Dto.Forms;
using BelgianCavesRegister.Dal.Interfaces;
using Microsoft.AspNetCore.Http;
//using BelgianCaveRegister_Api.Hubs;
using System.Security.Cryptography;

namespace BelgianCaveRegister_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NUserController : ControllerBase
    {
        private readonly BelgianCavesRegister.Dal.Interfaces.INUserRepository _userRepository;
        private readonly TokenGenerator _tokenGenerator;
        //private readonly NUserHub _nUserHub;
        private readonly Dictionary<string, string> currentNUser = new Dictionary<string, string>();

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

        //[HttpPost("Login")]
        //public IActionResult Login(NUser nUser)
        //{
        //    try
        //    {
        //        NUser? connectedNUser = _userRepository.LoginNUser(nUser.PasswordHash, nUser.Email);
        //        byte MdpNUser = nUser.PasswordHash;
        //        byte hashpwd = connectedNUser.PasswordHash;
        //        bool motDePassValide = BCrypt.Net.BCrypt.Verify(MdpNUser, hashpwd);

        //        if (motDePassValide)
        //        {
        //            return Ok(_tokenGenerator.GenerateToken(connectedNUser));
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}


        //[HttpPost("register")]
        //public IActionResult Register(NUser nu)
        //{
        //    _userRepository.RegisterNUser(nu);
        //    return Ok();
        //}
        //[HttpPost]
        //[ValidationAntiForgeryToken]
        //public ActionResult Validation(NUserRegisterForm form)
        //{
        //    ValidatePassword(form, ModelState);
        //    if (!ModelState.IsValid) { return BadRequest(); }
        //    else
        //        return RedirectToAction("Details", new { Id = 1 });
        //}

        [HttpPost]
        public async Task<IActionResult> Create(NUserForm nUser)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            if (_userRepository.Create(nUser.NUserToDal()))
            {
                //await _nUserHub.RefreshNUser();
                return Ok(nUser);
            }
            return BadRequest("Registration Error");
        }

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
        [HttpPut("{NUser_Id}")]
        public IActionResult Update(Guid nUser_Id, string pseudo, byte passwordHash, string email, int nPerson_Id, int role_Id) 
        {
            _userRepository.Update(nUser_Id, pseudo, passwordHash, email, nPerson_Id, role_Id);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult ReceiveNUserUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate) 
            {
                currentNUser[item.Key] = item.Value;
            }
            return Ok(currentNUser);
        }

        [HttpPatch("setRole")]
        public IActionResult ChangeRole(ChangeRole r)
        {
            _userRepository.SetRole(r.NUser_Id, r.Role_Id);
            return Ok();
        }
    }
}
