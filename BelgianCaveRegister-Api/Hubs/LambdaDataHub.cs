//using BelgianCaveRegister_Api.Dto;
//using Microsoft.AspNetCore.SignalR;

//namespace BelgianCaveRegister_Api.Hubs
//{
//    public class LambdaDataHub : Hub
//    {
//        public async Task NotifyNewLambdaData()
//        {
//            await Clients.All.SendAsync("ReceiveLambdaDataUpdate");
//        }
//        public async Task RefreshLambdaData()
//        {
//            if (Clients.All is not null)
//                await Clients.All.SendAsync("notifyNewLambdaData");
//        }
//    }
//}

