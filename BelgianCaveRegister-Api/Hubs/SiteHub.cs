//using BelgianCaveRegister_Api.Dto;
//using Microsoft.AspNetCore.SignalR;

//namespace BelgianCaveRegister_Api.Hubs
//{
//    public class SiteHub : Hub
//    {
//        public async Task NotifyNewSite()
//        {
//            await Clients.All.SendAsync("ReceiveSiteUpdate");
//        }
//        public async Task RefreshSite()
//        {
//            if (Clients.All is not null)
//                await Clients.All.SendAsync("notiftNewSite");
//        }
//    }
//}

