using Microsoft.AspNetCore.SignalR;

namespace BelgianCavesRegister.Api.Hubs
{
    public class BibliographyHub : Hub
    {
        public async Task RefreshBibliography()
        {
            if (Clients.All is not null)
                await Clients.All.SendAsync("notifyNewBibliography");
        }
    }
}

