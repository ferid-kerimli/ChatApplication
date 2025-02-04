using Microsoft.AspNetCore.SignalR;

namespace ChatApplication.BLL.Utility;

public class ChatHub : Hub
{
    public async Task SendMessage(int conversationId, int senderId, string message)
    {
        await Clients.Group($"conversation_{conversationId}").SendAsync("ReceiveMessage", senderId, message, DateTime.UtcNow);
    }

    public async Task JoinConversation(int conversationId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"conversation_{conversationId}");
    }

    public async Task LeaveConversation(int conversationId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"conversation_{conversationId}");
    }
}