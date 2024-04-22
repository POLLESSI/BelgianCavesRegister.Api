using BelgianCaveRegister_Api.Models;
using BelgianCaveRegister_Api.Hubs;
using BelgianCaveRegister_Api.Tools;
using BelgianCavesRegister.Dal.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Reflection.Metadata.Ecma335;

namespace BelgianCaveRegister_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepository _chatRepository;
        private readonly ChatHub _hub;

        public ChatController(IChatRepository chatRepository , ChatHub hub)
        {
            _chatRepository = chatRepository;
            _hub = hub;
        }
        //[HttpPost]
        //public async Task<IActionResult> Login(string passworHash, string email)
        //{
        //    //Based on connection ID, Iwill retrieve the list of user groups and re-register them in their groups at the hub level
        //    await _hub.JoinGroup("groupname", "username");
        //    return Ok();
        //}
        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_chatRepository.GetAll());
        }
        [HttpGet("{chat_Id}")]
        public IActionResult GetById(int chat_Id) 
        {
            return Ok (_chatRepository.GetById(chat_Id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(Message newMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (_chatRepository.Create(newMessage.ChatToDal()))
            {
                await _hub.RefreshChat();
                return Ok(newMessage);
            }
            return BadRequest("Registration error");
        }
        [HttpDelete("{chat_Id}")]
        public IActionResult Delete(int chat_Id)
        {
            _chatRepository.Delete(chat_Id);
            return Ok();
        }
        //[HttpOptions("{chat_Id}")]
        //IActionResult PrefligthRoute(int chat_Id)
        //{
        //    return NoContent();
        //}
        //// OPTIONS: api/Chat
        //[HttpOptions]
        //IActionResult PrefligthRoute()
        //{
        //    return NoContent();
        //}
        //[HttpPut("chat_Id")]
        //IActionResult PutTodoItem(int chat_Id)
        //{
        //    if (chat_Id < 1)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(chat_Id);
        //}
    }
}
