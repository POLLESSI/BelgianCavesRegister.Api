using BelgianCaveRegister_Api.Dto;
using Microsoft.AspNetCore.SignalR;

namespace BelgianCaveRegister_Api.Hubs
{
    public class NPersonHub : Hub
    {
        public async Task RefreshPerson()
        {
            if (Clients.All is not null)
                await Clients.All.SendAsync("notiftNewNPerson");
        }
    }
}

