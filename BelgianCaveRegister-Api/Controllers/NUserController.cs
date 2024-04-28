using BelgianCaveRegister_Api.Tools;
using Microsoft.AspNetCore.Mvc;
using BelgianCaveRegister_Api.Dto.Forms;
using BelgianCavesRegister.Dal.Interfaces;
using BelgianCavesRegister.Dal.Entities;
using BelgianCavesRegister.Bll.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using BelgianCaveRegister_Api.Hubs;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;

namespace BelgianCaveRegister_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NUserController : ControllerBase
    {
        private readonly BelgianCavesRegister.Dal.Interfaces.INUserRepository _userRepository;
        private readonly TokenGenerator _tokenGenerator;
        private readonly NUserHub _nUserHub;
        private readonly Dictionary<string, string> _currentNUser = new Dictionary<string, string>();

        public NUserController(BelgianCavesRegister.Dal.Interfaces.INUserRepository userRepository, TokenGenerator tokenGenerator, NUserHub nUserHub)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
            _nUserHub = nUserHub;
        }

        //[Authorize("ModelPolicy")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetAll());
        }

        //[Authorize("ModelPolicy")]
        [HttpGet("{nUser_Id}")]
        public IActionResult GetById(Guid nUser_Id)
        {
            return Ok (_userRepository.GetById(nUser_Id));
        }

        [HttpPost("login")]
        public IActionResult Login(NUserLoginForm nUser)
        {
            //try
            //{
            //    NUser? connectedNUser = _userRepository.LoginNUser(nUser.Email, nUser.PasswordHash);
            //    if (connectedNUser != null)
            //    {
            //        var token = _tokenGenerator.GenerateToken(connectedNUser);
            //        return Ok(new { Token = token, Role = connectedNUser.Role_Id });
            //    }
            //    else
            //    {
            //        return BadRequest("Invalid cerdentials");
            //    }
            //}
            //catch (Exception ex)
            //{

            //    return BadRequest(ex.Message);
            //}

            try
            {
                NUser? connectedNUser = _userRepository.LoginNUser(nUser.Email, nUser.PasswordHash);
                string? MdpNUser = nUser.PasswordHash;
                string? hashpwd = connectedNUser.PasswordHash;
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
        public IActionResult Register(NewNUser nu)
        {
            _userRepository.RegisterNUser( nu.Pseudo, nu.Email, nu.PasswordHash);
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
        [HttpPost]
        public async Task<IActionResult> Create(NUserForm nUser)
        {
            if (!ModelState.IsValid) 
                return BadRequest();
            if (_userRepository.Create(nUser.NUserToDal()))
            {
                await _nUserHub.RefreshNUser();
                return Ok();
            }
            return BadRequest("Registration Error");
        }
        [HttpDelete("{nUser_Id}")]
        public IActionResult Delete(Guid nUser_Id)
        {
            _userRepository.Delete(nUser_Id);
            return Ok();
        }
        [HttpPut("nUser_Id")]
        public IActionResult Update(Guid nUser_Id, string pseudo, string passwordHash, string email, int nPerson_Id, string role_Id)
        {
            _userRepository.Update(nUser_Id, pseudo, passwordHash, email, nPerson_Id, role_Id);
            return Ok();
        }
        [HttpPost("update")]
        public IActionResult ReceiveNUserUpdate(Dictionary<string, string> newUpdate)
        {
            foreach (var item in newUpdate)
            {
                _currentNUser[item.Key] = item.Value;
            }
            return Ok(_currentNUser);
        }

        //[Authorize("AdminPolicy")]
        [HttpPatch("setRole")]
        public IActionResult ChangeRole(ChangeRole r)
        {
            _userRepository.SetRole(r.NUser_Id, r.Role_Id);
            return Ok();
        }

        [HttpPatch("update")]
        public IActionResult Update(UpdateNUserForm nu)
        {
            _userRepository.Update(nu.NUser_Id, nu.Pseudo, nu.PasswordHash, nu.Email, nu.NPerson_Id, nu.Role_Id);
            return Ok();
        }

        //[HttpPut("{NUser_Id}")]
        //public IActionResult Update(UpdateNUserForm nu)
        //{
        //    _nUserService.Update(nu.Pseudo, nu.Email, nu.Role_Id);
        //    return Ok();
        //}

        //[HttpOptions("{nUser_Id}")]
        //IActionResult PrefligthRoute(Guid nUser_Id)
        //{
        //    return NoContent();
        //}
        //// OPTIONS: api/NUser
        //[HttpOptions]
        //IActionResult PrefligthRoute()
        //{
        //    return NoContent();
        //}
        //[HttpPut("nUser_Id")]
        //IActionResult PutTodoItem(Guid nUser_Id)
        //{
        //    if (nUser_Id == Guid.Empty)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(nUser_Id);
        //}
    }
}
