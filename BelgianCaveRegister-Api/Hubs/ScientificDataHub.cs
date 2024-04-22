using BelgianCaveRegister_Api.Dto;
using Microsoft.AspNetCore.SignalR;

namespace BelgianCaveRegister_Api.Hubs
{
    public class ScientificDataHub : Hub
    {
        //public async Task NotifyNewScientificData()
        //{
        //    if (Clients is not null)
        //        await Clients.All.SendAsync("receivescientificdataupdate");
        //}
        public async Task RefreshScientificData()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("notifynewscientificdata");
        }
        //public async Task submit()
        //{
        //    if (Clients is not null)
        //        await Clients.All.SendAsync("scientificdata");
        //}
        //public async Task GetScientificData()
        //{
        //    if (Clients is not null)
        //        await Clients.All.SendAsync("scientificdata");
        //}
    }
}
