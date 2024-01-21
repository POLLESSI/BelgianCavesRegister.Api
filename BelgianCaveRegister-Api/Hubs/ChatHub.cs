using BelgianCaveRegister_Api.Models;
using Microsoft.AspNetCore.SignalR;

namespace BelgianCaveRegister_Api.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("receiveMessage", message);
        }
        public async Task JoinGroup(string groupName, string username)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await SendToGroup(new Message
            {
                Author = "System",
                newMessage = "A new user has logged in" + username
            }, groupName);
        }
        public async Task SendToGroup(Message message, string groupName)
        {
            await Clients.Group(groupName).SendAsync("messageFromGroup", message);
        }
        public async Task RefreshChat()
        {
            if (Clients.All is not null) await Clients.All.SendAsync("notifyNewChat");
        }
    }
}

