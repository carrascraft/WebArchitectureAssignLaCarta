using Microsoft.AspNetCore.Http.Features;
using static MudBlazor.CategoryTypes;

namespace BlazorSignalRApp.Modules;



public class MenuItem
{
    public string Name { get; set; }
    public int Price { get; set; }
}

public class Menu
{
    private List<MenuItem> _repo = new List<MenuItem>(){};
    // a dictionary may be better?
    public void addMenuItem(MenuItem elem){

        _repo.Add(elem);
    }
    public List<MenuItem> getMenuItems(){
        return _repo;
    }
    public void loadState(List<MenuItem> menuItems)
    {
        _repo.Clear();
        _repo.AddRange(menuItems);
    }
    public void deleteMenuItem(MenuItem elem)
    {
        var item = _repo.FirstOrDefault(i => i.Name == elem.Name);
        if (item != null)
        {
            _repo.Remove(item);
        }

    }
    public int priceOfItem(string name){
        foreach(MenuItem item in _repo ){
            if( item.Name == name){
                return item.Price;
            }
        }
        return -1;
        
    }
    public List<Tuple<string, int>> getNamesAndPrices(){
        List<Tuple<string, int>> namesAndPrices = new List<Tuple<string, int>>();
        foreach( MenuItem m in _repo){
            namesAndPrices.Add(new Tuple<string, int>(m.Name, m.Price));
        }


        return namesAndPrices;
    }

    



}