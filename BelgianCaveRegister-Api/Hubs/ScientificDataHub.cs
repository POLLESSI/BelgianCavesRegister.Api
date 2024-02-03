using BelgianCaveRegister_Api.Dto;
using Microsoft.AspNetCore.SignalR;

namespace BelgianCaveRegister_Api.Hubs
{
    public class ScientificDataHub : Hub
    {
        public async Task NotifyNewScientificData()
        {
            if (Clients.All is not null) 
                await Clients.All.SendAsync("receiveScientificDataUpdate");
        }
        public async Task RefreshScientificData()
        {
            if (Clients.All is not null)
                await Clients.All.SendAsync("notifyNewScientificData");
        }
        public async Task submit()
        {
            if (Clients.All is not null)
                await Clients.All.SendAsync("scientificData");
        }
        public async Task GetScientificData()
        {
            if (Clients.All is not null)
                await Clients.All.SendAsync("scientificData");
        }
    }
}
