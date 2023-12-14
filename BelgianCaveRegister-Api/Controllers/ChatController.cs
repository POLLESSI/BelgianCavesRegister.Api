using BelgianCaveRegister_Api.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BelgianCaveRegister_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatHub hub;

        public ChatController(ChatHub Hub)
        {
            hub = Hub;
        }
        [HttpPost]
        public async Task<IActionResult> Login(string passwordHash, string email)
        {
            await hub.JoinGroup("groupname", "username");
            return Ok();
        }
        //[HttpDelete]
        //[ValidateAntiForgeryToken]
        //public IActionResult Delete()
        //{
        //    _ChatRepository.Delete();
        //    return Ok();
        //}
    }
}
