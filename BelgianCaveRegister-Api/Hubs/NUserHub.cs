using BelgianCaveRegister_Api.Dto;
using BelgianCaveRegister_Api.Tools;
using BelgianCavesRegister.Bll;
using Microsoft.AspNetCore.SignalR;

namespace BelgianCaveRegister_Api.Hubs
{
    public class NUserHub : Hub
    {
        private readonly INUserService _nUserService;
        private readonly TokenGenerator _tokenGenerator;

        public NUserHub(INUserService nUserService, TokenGenerator tokenGenerator)
        {
            _nUserService = nUserService;
            _tokenGenerator = tokenGenerator;
        }
        //public async Task RegisterNUser(string email, string pseudo, string password)
        //{
        //    var user = await _nUserService.RegisterNUserAsync(email, pseudo, password);
        //    var token = _tokenGenerator.GenerateToken(user);

        //    await Clients.Caller.SendAsync("ReceiveNUser", user, token);
        //}

        //public async Task NotifyNewNUser()
        //{
        //    if (Clients is not null)
        //        await Clients.All.SendAsync("receivenuserupdate");
        //}
        public async Task RefreshNUser()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("notifynewnuser");
        }
        //public async Task submit()
        //{
        //    if (Clients is not null)
        //        await Clients.All.SendAsync("nuser");
        //}
        //public async Task GetNUser()
        //{
        //    if (Clients is not null)
        //        await Clients.All.SendAsync("nuser");
        //}
    }
}

