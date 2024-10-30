using Microsoft.AspNetCore.Http.Features;

namespace BlazorSignalRApp.Modules;


public class Table
{

    public Table(int id)
    {
        _id = id;
    }

    private int _id = 0;

    private List<string> _orders = new List<string>();

}