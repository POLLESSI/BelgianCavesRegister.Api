using BelgianCaveRegister_Api.Dto;
using Microsoft.AspNetCore.SignalR;

namespace BelgianCaveRegister_Api.Hubs
{
    public class BibliographyHub : Hub
    {
        //public async Task NotifyNewBibliography()
        //{
        //    if (Clients is not null)
        //    {
        //        await Clients.All.SendAsync("receivebibliographyupdate");
        //    }
        //}
        public async Task RefreshBibliography()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("notifynewbibliography");
        }
        //public async Task submit()
        //{
        //    if (Clients is not null)
        //        await Clients.All.SendAsync("bibliography");
        //}
        //public async Task GetBibliography()
        //{
        //    if (Clients is not null)
        //        await Clients.All.SendAsync("bibliography");
        //}
    }
}

