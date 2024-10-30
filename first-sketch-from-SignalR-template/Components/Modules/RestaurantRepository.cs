using Microsoft.AspNetCore.Http.Features;
using System.Collections.Generic;

namespace BlazorSignalRApp.Modules;


public static class RestaurantRepository
{
    public static List<Restaurant> restaurants = new List<Restaurant>() {
        new Restaurant(1,1),
        new Restaurant(2, 2),
        new Restaurant(3, 3)
     };


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
}