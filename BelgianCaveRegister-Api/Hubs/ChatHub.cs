using BelgianCaveRegister_Api.Models;
using Microsoft.AspNetCore.SignalR;

namespace BelgianCaveRegister_Api.Hubs
{
    public class ChatHub : Hub
    {
        //public async Task SendMessage(Message message)
        //{
        //    await Clients.All.SendAsync("receivemessage", message);
        //}
        //public async Task JoinGroup(string groupName, string pseudo)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        //    await SendToGroup(new Message
        //    {
        //        Author = "System",
        //        NewMessage = "A new user has logged in" + pseudo
        //    }, groupName);
        //}
        //public async Task SendToGroup(Message message, string groupName)
        //{
        //    await Clients.Group(groupName).SendAsync("messagefromgroup", message);
        //}
        public async Task RefreshChat()
        {
            if (Clients is not null)
                await Clients.All.SendAsync("notifynewchat");
        }
    }
}

