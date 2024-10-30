namespace BlazorSignalRApp.Modules;

public static class ordersRepository
{
    private static Dictionary<int, List<string>> _orders= new Dictionary<int,List<string>>();
    public static void addOrderForTable(int tableId, string order){
        if (!_orders.ContainsKey(tableId)){
            _orders[tableId] = new List<string>();
        }
        _orders[tableId].Add(order);
    }
    public static List<string> getTableOrders(int tableId){
        if (!_orders.ContainsKey(tableId)){
            return new List<string>(); 
        }
        return _orders[tableId];
    }
    public static void deliverOrderOfTable(int tableId, string order){
        if (_orders.ContainsKey(tableId) && _orders[tableId].Count > 0){        
        _orders[tableId].Remove(order);
        return;
        }
        else{
            throw new InvalidOperationException($"hiciste cualquiera con la mesa {tableId}");
        }
    }
    public static List<int> getOpenedTables(){
        List<int> openedTables = new List<int>();
        foreach (int key in _orders.Keys ){
            if( _orders[key].Count() > 0  ){
                openedTables.Add(key);
            }
        }
        return openedTables;
    }

}