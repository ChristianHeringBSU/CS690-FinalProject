namespace cs690_final_project_source;

using Spectre.Console;

class Inventory
{
    public struct Ingredient
    {
        public string name;
    }

    public struct IngredientAmount
    {
        public Ingredient item;
        public double amount;
    }

    public static IngredientAmount InventorySearch(string searchString)
    {
        Storage.ReadInventory();

        return Storage.inventory.First(n => n.item.name == searchString);
    }

    public static string InventoryAdd(IngredientAmount matchedIngredient, string amount)
    {
        matchedIngredient.amount += Convert.ToDouble(amount);

        return Storage.ReadInventory();
    }

    public static string InventoryRemove(IngredientAmount matchedIngredient, string amount)
    {
        matchedIngredient.amount -= Convert.ToDouble(amount);

        return "";
    }

    public static string InventoryAddNew(string item)
    {
        // TODO: if exists, return

        // else
        Storage.inventory.Add(new IngredientAmount{item = new Ingredient{name = item}, amount = 0});

        return "";
    }
}
