using Microsoft.AspNetCore.SignalR;

namespace BelgianCavesRegister.Api.Hubs
{
    public class LambdaDataHub : Hub
    {
        public async Task RefreshLambdaData()
        {
            if (Clients.All is not null)
                await Clients.All.SendAsync("notifyNewLambdaData");
        }
    }
}

