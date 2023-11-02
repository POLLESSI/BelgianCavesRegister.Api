using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BelgianCavesRegister.Api.Hubs
{
    public class SiteHub : Hub
    {
        public async Task RefreshSite()
        {
            if (Clients.All is not null)
                await Clients.All.SendAsync("notiftNewSite");
        }
    }
}

