using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Text.Json;

namespace cs690_final_project_source;

class Storage
{
    public struct Ingredient
    {
        public static string name;
    }

    public struct IngredientAmount
    {
        public static Ingredient item;
        public static double amount;
    }

    public struct IngredientStock
    {
        public static Vector<IngredientAmount> inventory;
    }

    public struct Recipe
    {
        public static string title;
        public static Vector<IngredientAmount> ingredients;
        public static string body;
    }

    public struct Recipes
    {
        public static Vector<Recipe> recipes;
    }

    public struct GroceryListItem
    {
        public static Ingredient item;
        public static bool marked;
    }

    public struct GroceryList
    {
        public static Vector<GroceryListItem> item;
    }

    public struct Substitution
    {
        public static Ingredient toSub;
        public static Ingredient sub;
    }

    public struct Substitutions
    {
        public static Vector<Substitution> item;
    }

    static string recipeFile = "recipes.json";
    static string groceryFile = "grocery_list.json";
    static string ingredientFile = "ingredient.json";
    static string inventoryFile = "inventory.json";

    public static Recipes recipes;
    public static GroceryList groceryList;
    public static Substitutions substitutions;
    public static IngredientStock inventory;

    static Storage() {
        recipes = new Recipes();
        groceryList = new GroceryList();
        substitutions = new Substitutions();
        inventory = new IngredientStock();
    }

    public static int ReadRecipes()
    {
        using StreamReader reader = new(recipeFile);

        recipes = JsonSerializer.Deserialize<Recipes>(reader.ReadToEnd());

        return 0;
    }

    public static int WriteRecipes()
    {
        string data = JsonSerializer.Serialize(recipes);

        using StreamWriter fd = new StreamWriter(recipeFile);
        fd.WriteLine(data);

        return 0;
    }

    public static int ReadGroceryList()
    {
        using StreamReader reader = new(groceryFile);

        groceryList = JsonSerializer.Deserialize<GroceryList>(reader.ReadToEnd());

        return 0;
    }

    public static int WriteGroceryList()
    {
        string data = JsonSerializer.Serialize(groceryList);

        using StreamWriter fd = new StreamWriter(groceryFile);
        fd.WriteLine(data);

        return 0;
    }

    public static int ReadSubstitutions()
    {
        using StreamReader reader = new(ingredientFile);

        substitutions = JsonSerializer.Deserialize<Substitutions>(reader.ReadToEnd());

        return 0;
    }

    public static int WriteSubstitutions()
    {
        string data = JsonSerializer.Serialize(substitutions);

        using StreamWriter fd = new StreamWriter(ingredientFile);
        fd.WriteLine(data);

        return 0;
    }

    public static int ReadInventory()
    {
        using StreamReader reader = new(inventoryFile);

        inventory = JsonSerializer.Deserialize<IngredientStock>(reader.ReadToEnd());

        return 0;
    }

    public static int WriteInventory()
    {
        string data = JsonSerializer.Serialize(inventory);

        using StreamWriter fd = new StreamWriter(inventoryFile);
        fd.WriteLine(data);

        return 0;
    }
}
