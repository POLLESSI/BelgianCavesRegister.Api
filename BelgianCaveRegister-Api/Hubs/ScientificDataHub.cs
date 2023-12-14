using BelgianCaveRegister_Api.Dto;
using Microsoft.AspNetCore.SignalR;

namespace BelgianCaveRegister_Api.Hubs
{
    public class ScientificDataHub : Hub
    {
        public async Task RefreshScientificData()
        {
            if (Clients.All is not null)
                await Clients.All.SendAsync("notifyNewScientificData");
        }
    }
}
