﻿using BelgianCaveRegister_Api.Dto;
using Microsoft.AspNetCore.SignalR;

namespace BelgianCaveRegister_Api.Hubs
{
    public class NUserHub : Hub
    {
        public async Task RefreshNUser()
        {
            if (Clients.All is not null)
                await Clients.All.SendAsync("notifyNewNUser");
        }
    }
}

