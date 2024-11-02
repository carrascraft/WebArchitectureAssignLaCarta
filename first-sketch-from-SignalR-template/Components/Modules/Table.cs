using Microsoft.AspNetCore.Http.Features;

namespace BlazorSignalRApp.Modules;

public class Table
{
    public Table()
    {
        _orders = new List<string>();
    }

    public Table(int id)
    {
        Id = id;
        _orders = new List<string>();
    }
    
    public int Id { get; set; }
    public List<string> Orders 
    { 
        get => _orders;
        set => _orders = value;
    }

    private List<string> _orders;
}