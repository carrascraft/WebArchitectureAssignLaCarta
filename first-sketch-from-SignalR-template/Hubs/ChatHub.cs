using Microsoft.AspNetCore.SignalR;
using BlazorSignalRApp.Modules;
using BlazorSignalRApp.Components.Pages;
using Microsoft.AspNetCore.SignalR.Client;
using System.Xml.Linq;
using MudBlazor;
namespace BlazorSignalRApp.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        ordersRepository.addOrderForTable(int.Parse(user), message);
        messagesRepository.addMessage(message);
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
    public async Task CreateResto(int countTables)
    {
        RestaurantRepository.addRestaurant(countTables);
        await Clients.All.SendAsync("ReceiveMessage", "-1", "-1");
    }

    public async Task AddMenuItem(int restaurantId, int priceItem, string nameItem)
    {
        Console.WriteLine($"Añadir desde chatHub ítem: {nameItem}, Precio: {priceItem}");
        RestaurantRepository.addItemToMenuFromARestaurant(restaurantId, priceItem, nameItem);
        await Clients.All.SendAsync("ReceiveMessage", "-1", "-1");
    }


    public async Task DeleteMenuItem(int restaurantId, int priceItem, string nameItem)
    {
        Console.WriteLine($"Eliminando desde chatHub ítem: {nameItem}, Precio: {priceItem}");
        RestaurantRepository.deleteItemToMenuFromARestaurant(restaurantId, priceItem, nameItem);
        await Clients.All.SendAsync("ReceiveMessage", "-1", "-1");
    }
     
    public async Task AddTable(int restaurantId)
    {
        RestaurantRepository.addTableToRestaurant(restaurantId);
        await Clients.All.SendAsync("ReceiveMessage", "-1", "-1");
    }

    public async Task SubstractTable(int restaurantId)
    {
        RestaurantRepository.substractTableToRestaurant(restaurantId);
        await Clients.All.SendAsync("ReceiveMessage", "-1", "-1");
    }

    public async Task DeliverOrder(int tableId, string order)
    {
        ordersRepository.deliverOrderOfTable(tableId, order);
        await Clients.All.SendAsync("ReceiveMessage", "-1", "error");
    }


}