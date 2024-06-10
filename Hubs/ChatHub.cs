using Microsoft.AspNetCore.SignalR;

namespace ChatMicroserviceAPI.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(int senderId, int receiverId, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", senderId, receiverId, message);
    }
}
