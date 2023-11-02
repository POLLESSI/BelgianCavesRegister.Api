using Microsoft.AspNetCore.SignalR;

namespace BelgianCavesRegister.Api.Hubs
{
    public class NOwnerHub : Hub
    {
        public async Task RefreshNOwner()
        {
            if (Clients.All is not null)
                await Clients.All.SendAsync("notifyNewNOwner");
        }
    }
}

