using Microsoft.AspNetCore.SignalR;
using BlazorSignalRApp.Modules;
using BlazorSignalRApp.Components.Pages;
namespace BlazorSignalRApp.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        ordersRepository.addOrderForTable(int.Parse(user), message);
        messagesRepository.addMessage(message);
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
    public async Task DeliverOrder(int tableId, string order)
    {
        ordersRepository.deliverOrderOfTable(tableId, order);
        await Clients.All.SendAsync("ReceiveMessage", "-1", "error");
    }


}