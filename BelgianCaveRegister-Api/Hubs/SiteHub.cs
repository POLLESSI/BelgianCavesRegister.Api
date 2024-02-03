using BelgianCaveRegister_Api.Dto;
using Microsoft.AspNetCore.SignalR;

namespace BelgianCaveRegister_Api.Hubs
{
    public class SiteHub : Hub
    {
        public async Task NotifyNewSite()
        {
            if (Clients.All is not null) 
                await Clients.All.SendAsync("receiveSiteUpdate");
        }
        public async Task RefreshSite()
        {
            if (Clients.All is not null)
                await Clients.All.SendAsync("notifyNewSite");
        }
        public async Task submit()
        {
            if (Clients.All is not null)
                await Clients.All.SendAsync("site");
        }
        public async Task GetSite()
        {
            if (Clients.All is not null)
                await Clients.All.SendAsync("site");
        }
    }
}

