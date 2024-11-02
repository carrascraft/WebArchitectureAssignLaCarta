using Microsoft.AspNetCore.Http.Features;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorSignalRApp.Modules;


public static class RestaurantRepository
{
    public static List<Restaurant> restaurants = new List<Restaurant>() {
        new Restaurant(1,1),
        new Restaurant(2, 2),
        new Restaurant(3, 3)
     };

    private static readonly string filePath = "restaurants.json";

    public static int addRestaurant(int countMesas)
    {
        int newId = restaurants.Count;
        restaurants.Add(new Restaurant(newId, countMesas));
        return newId;
    }

    public static void addTableToRestaurant(int id)
    {
        //Capaz deberia validar que existe el restaurant con ese id
        restaurants[id].addTable();
    }

    public static void substractTableToRestaurant(int id)
    {
        //Capaz deberia validar que existe el restaurant con ese id
        restaurants[id].substractTable();
    }

    public static int getCountTableFromRestaurant(int id)
    {
        //Capaz deberia validar que existe el restaurant con ese id
        return restaurants[id].getCountOfTables();
    }

    public static List<Tuple<string,int>> getMenuOfARestaurant(int id)
    {
        List<Tuple<string, int>> listOfItems = new List<Tuple<string, int>>();
        listOfItems = restaurants[id].getElementsOfMenu();
        return listOfItems;
    }

    public static int getPriceOfItemFromARestaurant(int id, string item)
    {
        return restaurants[id].getPriceOfItem(item);
    }

    public static void addItemToMenuFromARestaurant(int id, int price, string name)
    {
        MenuItem menuItem = new MenuItem() { Name = name, Price = price };
        restaurants[id].addToMenu(menuItem);
    }

    public static void deleteItemToMenuFromARestaurant(int id, int price, string name)
    {
        MenuItem menuItem = new MenuItem() { Name = name, Price = price };
        restaurants[id].deleteToMenu(menuItem);
    }
    
    public static async Task GuardarEstados()
    {
        var estados = new List<object>();

        // Recorre cada restaurante y obtiene su estado
        foreach (var restaurant in restaurants)
        {
            estados.Add(restaurant.getState());
        }

        // Guarda todos los estados en un único archivo JSON
        var options = new JsonSerializerOptions { WriteIndented = true };
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await JsonSerializer.SerializeAsync(stream, estados, options);
        }
    }
    public static async Task LoadStates()
    {
        if (!File.Exists(filePath))
            return;

        using (var stream = new FileStream(filePath, FileMode.Open))
        {
            var estados = await JsonSerializer.DeserializeAsync<List<RestaurantState>>(stream);
            if (estados != null)
            {
                restaurants.Clear();
                foreach (var estado in estados)
                {
                    Console.WriteLine(estado.Id);
                    var restaurant = new Restaurant(estado.Id, estado.Tables.Count);
                    restaurant.loadState(estado);
                    restaurants.Add(restaurant);
                }
            }
        }
    }
}