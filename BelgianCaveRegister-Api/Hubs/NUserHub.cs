using BelgianCaveRegister_Api.Dto;
using Microsoft.AspNetCore.SignalR;

namespace BelgianCaveRegister_Api.Hubs
{
    public class NUserHub : Hub
    {
        public async Task NotifyNewNUser()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("receiveNUserUpdate");
        }
        public async Task RefreshNUser()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("notifyNewNUser");
        }
        public async Task submit()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("nuser");
        }
        public async Task GetNUser()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("nuser");
        }
    }
}

