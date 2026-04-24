namespace cs690_final_project_source;

using System.Diagnostics;
using System.IO;
using System.Text.Json;
using Spectre.Console;

public class Recipes
{
    public struct Recipe
    {
        public string title { get; set; }
        public List<Inventory.IngredientAmount> ingredients { get; set; }
        public string body { get; set; }
    }

    public static List<Recipe> RecipeSearch(string searchString)
    {
        Storage.ReadRecipes();

        return Storage.recipes.FindAll(n => n.title.Contains(searchString) == true);
    }

    public static string RecipeAdd(string title, List<Inventory.IngredientAmount> ingredients, string body)
    {
        Storage.ReadRecipes();

        var newRecipe = new Recipe{title = title, ingredients = ingredients, body = body};

        Storage.recipes.Add(newRecipe);

        return Storage.WriteRecipes();
    }

    public static string RecipeEdit(string recipeTitle)
    {
        var recipe = Storage.recipes.First(n => n.title == recipeTitle);

        var tmpfile = Path.GetTempFileName();

        string data = JsonSerializer.Serialize(recipe);

        using StreamWriter fd = new StreamWriter(tmpfile);
        fd.WriteLine(data);
        fd.Close();

        _ = AnsiConsole.Ask($"Please open {tmpfile} and hit enter when finished", "");

        using StreamReader reader = new(tmpfile);
        var newrecipe = JsonSerializer.Deserialize<Recipe>(reader.ReadToEnd());

        Storage.recipes.Add(newrecipe);
        Storage.recipes.Remove(recipe);

        reader.Close();

        return Storage.WriteRecipes();
    }

    public static string RecipeDelete(string recipeTitle)
    {
        var recipe = Storage.recipes.First(n => n.title == recipeTitle);

        var success = Storage.recipes.Remove(recipe);
        if(success == false)
        {
            return "Error removing recipe from recipe list";
        }

        return Storage.WriteRecipes();
    }
}
