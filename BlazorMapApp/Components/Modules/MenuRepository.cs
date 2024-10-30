using Microsoft.AspNetCore.Http.Features;

namespace BlazorSignalRApp.Modules;



//this may not be included on client ????
public class menuItem{
    public string? Name{get;set;}
    public int Price{get;set;}


}

public static class menuRepository
{
    private static List<menuItem> _repo = new List<menuItem>(){
    new menuItem {Name = "milanesa", Price =100000},
    new menuItem {Name = "chori", Price =155001},
    new menuItem {Name = "ñoqui", Price = 11323},
    new menuItem {Name = "tarta", Price = 15000},

    };
    // a dictionary may be better?
    public static void addMenuItem(menuItem elem){

        _repo.Add(elem);
    }
    public static int priceOfItem(string name){
        foreach(menuItem item in _repo ){
            if( item.Name == name){
                return item.Price;
            }
        }
        return -1;
        
    }
    public static List<Tuple<string, int>> getNamesAndPrices(){
        List<Tuple<string, int>> namesAndPrices = new List<Tuple<string, int>>();
        foreach( menuItem m in _repo){
            namesAndPrices.Add(new Tuple<string, int>(m.Name, m.Price));
        }


        return namesAndPrices;
    }

    



}