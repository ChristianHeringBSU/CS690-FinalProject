using System.Text.Json;

namespace cs690_final_project_source;

public static class Storage
{
    public static string recipeFile = "recipes.json";
    public static string groceryFile = "grocery_list.json";
    public static string ingredientFile = "ingredients.json";
    public static string inventoryFile = "inventory.json";

    public static List<Recipes.Recipe> recipes = new List<Recipes.Recipe>();
    public static List<Grocery.GroceryListItem> groceryList = new List<Grocery.GroceryListItem>();
    public static List<Ingredient.Substitution> substitutions = new List<Ingredient.Substitution>();
    public static List<Inventory.IngredientAmount> inventory = new List<Inventory.IngredientAmount>();

    public static string ReadRecipes()
    {
        using StreamReader reader = new(recipeFile);

        recipes = JsonSerializer.Deserialize<List<Recipes.Recipe>>(reader.ReadToEnd());

        reader.Close();

        return "";
    }

    public static string WriteRecipes()
    {
        string data = JsonSerializer.Serialize(recipes);

        using StreamWriter fd = new StreamWriter(recipeFile);
        fd.WriteLine(data);

        fd.Close();
        
        return "";
    }

    public static string ReadGroceryList()
    {
        using StreamReader reader = new(groceryFile);

        groceryList = JsonSerializer.Deserialize<List<Grocery.GroceryListItem>>(reader.ReadToEnd());

        reader.Close();
        
        return "";
    }

    public static string WriteGroceryList()
    {
        string data = JsonSerializer.Serialize(groceryList);

        using StreamWriter fd = new StreamWriter(groceryFile);
        fd.WriteLine(data);

        fd.Close();
        
        return "";
    }

    public static string ReadSubstitutions()
    {
        using StreamReader reader = new(ingredientFile);

        substitutions = JsonSerializer.Deserialize<List<Ingredient.Substitution>>(reader.ReadToEnd());

        reader.Close();
        
        return "";
    }

    public static string WriteSubstitutions()
    {
        string data = JsonSerializer.Serialize(substitutions);

        using StreamWriter fd = new StreamWriter(ingredientFile);
        fd.WriteLine(data);

        fd.Close();
        
        return "";
    }

    public static string ReadInventory()
    {
        using StreamReader reader = new(inventoryFile);

        inventory = JsonSerializer.Deserialize<List<Inventory.IngredientAmount>>(reader.ReadToEnd());

        reader.Close();
        
        return "";
    }

    public static string WriteInventory()
    {
        string data = JsonSerializer.Serialize(inventory);

        using StreamWriter fd = new StreamWriter(inventoryFile);
        fd.WriteLine(data);

        fd.Close();
        
        return "";
    }
}
