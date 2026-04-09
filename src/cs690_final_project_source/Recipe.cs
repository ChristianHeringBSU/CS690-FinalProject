namespace cs690_final_project_source;

using System.Diagnostics;
using System.IO;
using System.Text.Json;

class Recipes
{
    public struct Recipe
    {
        public string title;
        public List<Inventory.IngredientAmount> ingredients;
        public string body;
    }

    public static List<Recipe> RecipeSearch(string searchString)
    {
        Storage.ReadRecipes();

        var matchedRecipes = new List<Recipe>();

        foreach(var recipe in Storage.recipes)
        {
            bool titleMatches = recipe.title.Contains(searchString);
            bool bodyMatches = recipe.body.Contains(searchString);

            if(titleMatches || bodyMatches)
            {
                matchedRecipes.Append(recipe);
            }
        }

        return null; //new Storage.Recipe>();
    }

    public static string RecipeAdd(string title, List<Inventory.IngredientAmount> ingredients, string body)
    {
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
        
        // https://stackoverflow.com/a/60018808
        var p = new Process {
            StartInfo = new ProcessStartInfo(tmpfile)
            {
                UseShellExecute = true
            }
        };

        p.Start();

        p.WaitForExit();

        using StreamReader reader = new(tmpfile);

        recipe = JsonSerializer.Deserialize<Recipe>(reader.ReadToEnd()); // TODO: Does this modify the underlying data?

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
