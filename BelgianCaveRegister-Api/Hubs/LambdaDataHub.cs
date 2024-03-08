using BelgianCaveRegister_Api.Dto;
using Microsoft.AspNetCore.SignalR;

namespace BelgianCaveRegister_Api.Hubs
{
    public class LambdaDataHub : Hub
    {
        public async Task NotifyNewLambdaData()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("receivelambdadataupdate");
        }
        public async Task RefreshLambdaData()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("notifynewlambdaData");
        }
        public async Task submit()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("lambdadata");
        }
        public async Task GetLambdaData()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("lambdadata");
        }
    }
}

