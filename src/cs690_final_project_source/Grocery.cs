namespace cs690_final_project_source;

public class Grocery
{
    public struct GroceryListItem
    {
        public Inventory.Ingredient item { get; set; }
        public bool marked { get; set; }
    }
    
    public static string GroceryListAdd(string item)
    {
        Storage.ReadGroceryList();

        Storage.groceryList.Add(new GroceryListItem{item = new Inventory.Ingredient{name = item}, marked = false});

        return Storage.WriteGroceryList();
    }
    
    public static string GroceryListMark(string item)
    {
        Storage.ReadGroceryList();

        GroceryListItem object_to_mark = Storage.groceryList.First(n => n.item.name == item);
        
        Storage.groceryList.Remove(object_to_mark);

        object_to_mark.marked = !object_to_mark.marked;

        Storage.groceryList.Add(object_to_mark);

        return Storage.WriteGroceryList();
    }
    
    public static string GroceryListDelete(string item)
    {
        Storage.ReadGroceryList();

        GroceryListItem object_to_remove = Storage.groceryList.First(n => n.item.name == item);

        Storage.groceryList.Remove(object_to_remove);
        
        return Storage.WriteGroceryList();
    }
    
    public static string GroceryListClear()
    {
        Storage.ReadGroceryList();

        Storage.groceryList = Storage.groceryList.FindAll(n => n.marked == false);
        
        return Storage.WriteGroceryList();
    }
}
