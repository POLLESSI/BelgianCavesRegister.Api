using BelgianCaveRegister_Api.Dto;
using Microsoft.AspNetCore.SignalR;

namespace BelgianCaveRegister_Api.Hubs
{
    public class BibliographyHub : Hub
    {
        public async Task NotifyNewBibliography()
        {
            if (Clients.All is not null)
                await Clients.All.SendAsync("receiveBibliographyUpdate");
        }
        public async Task RefreshBibliography()
        {
            if (Clients.All is not null)
                await Clients.All.SendAsync("notifyNewBibliography");
        }
        public async Task submit()
        {
            if (Clients.All is not null)
                await Clients.All.SendAsync("bibliography");
        }
        public async Task GetBibliography()
        {
            if (Clients.All is not null)
                await Clients.All.SendAsync("bibliography");
        }
    }
}

