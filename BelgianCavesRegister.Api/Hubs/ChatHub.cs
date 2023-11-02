//using BelgianCavesRegister.Api.Dto.Forms;
//using Microsoft.AspNetCore.SignalR;
//using System.Text.RegularExpressions;

//namespace BelgianCavesRegister.Api.Hubs
//{
//    public class ChatHub : Hub
//    {
//        public async Task SendMessage(Message message)
//        {
//            await Clients.All.SendAsync("receiveMessage", message);
//        }
//        public async Task JoinGroup(string qroupName, string pseudo)
//        {
//            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
//            await SendToGroup(new Message
//            {
//                Author = "System",
//                Content = "A new user has logged in" + pseudo
//            }, groupName);
//        }
//        public async Task SendToGroup(Message message, string groupName)
//        {
//            await Clients.Group(groupName).SendAsync("messageFromGroup", message);
//        }
//    }
//}

