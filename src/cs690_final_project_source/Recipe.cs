namespace cs690_final_project_source;

using Spectre.Console;

class Recipe
{
    static Storage.Recipes RecipeSearch(string searchString)
    {
        Storage.ReadRecipes();

        var matchedRecipes = new Storage.Recipes();

        foreach(var recipe in Storage.recipes)
        {
            bool titleMatches = recipe.title.Contains(searchString);
            bool bodyMatches = recipe.body.Contains(searchString);

            if(titleMatches || bodyMatches)
            {
                matchedRecipes.Append(recipe);
            }
        }

        return new Storage.Recipes();
    }

    static public string RecipeMenuSearch()
    {
        Storage.Recipes matchedRecipes;

        while(true)
        {
            string search = AnsiConsole.Ask<string>("What recipe are you searching for? (Type \"Exit\" to go back to Recipe Menu)");

            if(search == "Exit")
            {
                return "";
            }

            matchedRecipes = RecipeSearch(search);
            if(matchedRecipes.Length > 0)
            {
                break;
            }
        }

        string selection = Menu.DisplaySelectMenu("Main Menu", "", matchedRecipes);

        return "";
    }

    static string RecipeAdd(string title, string ingredients, string body)
    {
        Storage.recipes.Append(Storage.Recipe{title: title, ingredients: ingredients, body: body})

        Storage.WriteRecipes();

        return "";
    }

    static public string RecipeMenuAdd()
    {
        var title = "";
        var ingredients = "";
        var body = "";
        
        while(true)
        {
            title = AnsiConsole.Ask<string>("Enter the title for the new recipe. (Type \"Exit\" to go back to Recipe Menu)");
            ingredients = AnsiConsole.Ask<string>("Enter the ingredients of the new recipe as a comma separated list. (Type \"Exit\" to go back to Recipe Menu)");
            body = AnsiConsole.Ask<string>("Enter the body of the new recipe. (Type \"Exit\" to go back to Recipe Menu)");

            if(title != "" && ingredients != "" && body != "")
            {
                break;
            }
        }

        var error = RecipeAdd(title, ingredients, body);

        return "";
    }

    static string RecipeEdit()
    {

        return "";
    }

    static public string RecipeMenuEdit()
    {
        // search recipes

        // select recipe from table

        // open recipe editor

        return "";
    }

    static string RecipeDelete()
    {

        return "";
    }

    static public string RecipeMenuDelete()
    {
        // search recipes

        // select recipe from table

        // delete recipe

        return "";
    }
}
