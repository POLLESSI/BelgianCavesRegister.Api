using BelgianCaveRegister_Api.Dto;
using Microsoft.AspNetCore.SignalR;

namespace BelgianCaveRegister_Api.Hubs
{
    public class LambdaDataHub : Hub
    {
        public async Task NotifyNewLambdaData()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("receiveLambdaDataUpdate");
        }
        public async Task RefreshLambdaData()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("notifyNewLambdaData");
        }
        public async Task submit()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("lambdaData");
        }
        public async Task GetLambdaData()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("lambdaData");
        }
    }
}

