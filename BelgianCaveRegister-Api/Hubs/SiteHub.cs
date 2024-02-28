using BelgianCaveRegister_Api.Dto;
using Microsoft.AspNetCore.SignalR;

namespace BelgianCaveRegister_Api.Hubs
{
    public class SiteHub : Hub
    {
        public async Task NotifyNewSite()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("receiveSiteUpdate");
        }
        public async Task RefreshSite()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("notiftNewSite");
        }
        public async Task submit()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("site");
        }
        public async Task GetSite()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("site");
        }
    }
}

