using BelgianCaveRegister_Api.Dto;
using Microsoft.AspNetCore.SignalR;

namespace BelgianCaveRegister_Api.Hubs
{
    public class NPersonHub : Hub
    {
        //public async Task NotifyNewPerson()
        //{
        //    if (Clients is not null)
        //        await Clients.All.SendAsync("receivenpersonupdate");
        //}
        public async Task RefreshPerson()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("notifynewnperson");
        }
        //public async Task submit()
        //{
        //    if (Clients is not null)
        //        await Clients.All.SendAsync("nperson");
        //}
        //public async Task GetNPerson()
        //{
        //    if (Clients is not null)
        //        await Clients.All.SendAsync("nperson");
        //}
    }
}

