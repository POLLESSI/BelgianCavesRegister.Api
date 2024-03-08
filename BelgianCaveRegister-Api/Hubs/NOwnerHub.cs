using BelgianCaveRegister_Api.Dto;
using Microsoft.AspNetCore.SignalR;

namespace BelgianCaveRegister_Api.Hubs
{
    public class NOwnerHub : Hub
    {
        public async Task NotifyNewNOwner()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("receivenownerupdate");
        }
        public async Task RefreshNOwner()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("notifynewnowner");
        }
        public async Task submit()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("nowner");
        }
        public async Task GetNOwner()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("nowner");
        }
    }
}

