namespace cs690_final_project_source;

using Spectre.Console;
using System.Text.Json;

class Inventory
{
    public struct Ingredient
    {
        public string name { get; set; }
    }

    public struct IngredientAmount
    {
        public Ingredient item { get; set; }
        public double amount { get; set; }
    }

    public static IngredientAmount InventorySearch(string searchString)
    {
        Storage.ReadInventory();

        return Storage.inventory.First(n => n.item.name == searchString);
    }

    public static string InventoryAdd(IngredientAmount matchedIngredient, string amount)
    {
        Storage.ReadInventory();

        var ingredientObject = matchedIngredient;

        Storage.inventory.Remove(matchedIngredient);

        ingredientObject.amount += Convert.ToDouble(amount);

        Storage.inventory.Add(ingredientObject);

        return Storage.WriteInventory();
    }

    public static string InventoryRemove(IngredientAmount matchedIngredient, string amount)
    {
        Storage.ReadInventory();

        var ingredientObject = matchedIngredient;

        Storage.inventory.Remove(matchedIngredient);

        ingredientObject.amount -= Convert.ToDouble(amount);

        Storage.inventory.Add(ingredientObject);

        return Storage.WriteInventory();
    }

    public static string InventoryAddNew(string item)
    {
        Storage.ReadInventory();

        // TODO: if exists, return

        // else
        Storage.inventory.Add(new IngredientAmount{item = new Ingredient{name = item}, amount = 0.0});

        return Storage.WriteInventory();
    }
}
