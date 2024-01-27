//using BelgianCaveRegister_Api.Dto;
//using Microsoft.AspNetCore.SignalR;

//namespace BelgianCaveRegister_Api.Hubs
//{
//    public class NOwnerHub : Hub
//    {
//        public async Task NotifyNewNOwner()
//        {
//            await Clients.All.SendAsync("ReceiveNOwnerUpdate");
//        }
//        public async Task RefreshNOwner()
//        {
//            if (Clients.All is not null)
//                await Clients.All.SendAsync("notifyNewNOwner");
//        }
//    }
//}

