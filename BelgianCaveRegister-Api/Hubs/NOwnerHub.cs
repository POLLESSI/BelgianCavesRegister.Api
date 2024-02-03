using BelgianCaveRegister_Api.Dto;
using Microsoft.AspNetCore.SignalR;

namespace BelgianCaveRegister_Api.Hubs
{
    public class NOwnerHub : Hub
    {
        public async Task NotifyNewNOwner()
        {
            if (Clients.All is not null) 
                await Clients.All.SendAsync("receiveNOwnerUpdate");
        }
        public async Task RefreshNOwner()
        {
            if (Clients.All is not null)
                await Clients.All.SendAsync("notifyNewNOwner");
        }
        public async Task submit()
        {
            if (Clients.All is not null)
                await Clients.All.SendAsync("nOwner");
        }
        public async Task GetNOwner()
        {
            if (Clients.All is not null)
                await Clients.All.SendAsync("nOwner");
        }
    }
}

