namespace BlazorSignalRApp.Modules;

public class RestaurantState
{
    public int Id { get; set; }
    public List<Table> Tables { get; set; }
    public List<MenuItem> Menu { get; set; }
}