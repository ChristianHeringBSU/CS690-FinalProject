namespace cs690_final_project_source;

using Spectre.Console;

class Inventory
{
    static string InventorySearch(string searchString)
    {
        Storage.ReadInventory();

        foreach(var item in Storage.inventory)
        {
            if(item.item.name == searchString)
            {
                return searchString;
            }
        }
        
        return "";
    }

    static string InventoryAdd()
    {

        return "";
    }

    static public string InventoryMenuAdd()
    {
        // search inventory (exact match ingredient)

        // prompt for ingredient amount in grams

        // add amount from ingredient

        var ingredientName = AnsiConsole.Ask<string>("Enter name of the ingredient. (Type \"Exit\" to go back to Inventory Management Menu)");

        var matchedIngredient = InventorySearch(ingredientName);

        var amount = AnsiConsole.Ask<string>("Enter the amount to add. (Type \"Exit\" to go back to Inventory Management Menu)");

        Storage.inventory[matchedIngredient] += amount

        return "";
    }

    static string InventoryRemove()
    {

        return "";
    }

    static public string InventoryMenuRemove()
    {
        // search inventory (exact match ingredient)

        // prompt for ingredient amount in grams

        // remove amount from ingredient

        var ingredientName = AnsiConsole.Ask<string>("Enter name of the ingredient. (Type \"Exit\" to go back to Inventory Management Menu)");

        var matchedIngredient = InventorySearch(ingredientName);

        var amount = AnsiConsole.Ask<string>("Enter the amount to remove. (Type \"Exit\" to go back to Inventory Management Menu)");

        Storage.inventory[matchedIngredient] -= amount;

        return "";
    }

    static public string InventoryMenuList()
    {
        // display ingredients in a menu

        var inventory = new Table();
        
        inventory.AddColumn("Ingredient Name");
        inventory.AddColumn("Amount In Inventory");
        
        foreach(var ingredient in Storage.ingredients)
        {
            inventory.AddRow(ingredient.item, ingredient.amount);
        }
        
        AnsiConsole.Write(inventory);

        return "";
    }

    static string InventoryAddNew(string ingredientName)
    {
        // if match, return error
        // else add return ""

        foreach(var ingredient in Storage.ingredients)
        {
            if(ingredient == ingredientName)
            {
                return "error, ingredient already exists";
            }
        }

        Storage.AddIngredient(ingredientName);

        return "";
    }

    static public string InventoryMenuAddNew()
    {
        var ingredientName = "";
        
        while(true)
        {
            ingredientName = AnsiConsole.Ask<string>("Enter name of new ingredient. (Type \"Exit\" to go back to Inventory Management Menu)");

            if(ingredientName != "")
            {
                break;
            }
        }

        return InventoryAddNew(ingredientName);
    }
}
