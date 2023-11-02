using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelgianCavesRegister.Api.Hubs
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
