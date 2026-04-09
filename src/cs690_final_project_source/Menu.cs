namespace cs690_final_project_source;

using Spectre.Console;

class Menu
{
    static string NotImplemented()
    {
        AnsiConsole.WriteLine("Not Implemented!");

        return "";
    }
    static public void MainMenu()
    {
        var functionMap = new Dictionary<string, Delegate>
        {
            ["Recipe"] = new Func<string>(RecipeMenu),
            ["Grocery List"] = new Func<string>(GroceryListMenu),
            ["Ingredient Substitutions"] = new Func<string>(IngredientSubstitutionMenu),
            ["Inventory Management"] = new Func<string>(InventoryManagementMenu),
        };

        string[] selectionOptions = ["Recipe", "Grocery List", "Ingredient Substitutions", "Inventory Management", "Exit"];

        while(true)
        {
            string selection = DisplaySelectMenu("Main Menu", "", selectionOptions);

            if(selection == "Exit")
            {
                break;
            }

            functionMap[selection].DynamicInvoke();
        }
    }

    static string RecipeMenu()
    {
        var functionMap = new Dictionary<string, Delegate>
        {
            ["Search For A Recipe"] = new Func<string>(RecipeMenuSearch),
            ["Add A New Recipe"] = new Func<string>(RecipeMenuAdd),
            ["Edit A Recipe"] = new Func<string>(RecipeMenuEdit),
            ["Delete A Recipe"] = new Func<string>(RecipeMenuDelete),
        };

        string[] selectionOptions = ["Search For A Recipe", "Add A New Recipe", "Edit A Recipe", "Delete A Recipe",  "Return To Main Menu"];

        while(true)
        {
            string selection = DisplaySelectMenu("Recipe Menu", "", selectionOptions);

            if(selection == "Return To Main Menu")
            {
                break;
            }

            functionMap[selection].DynamicInvoke();
        }

        return "";
    }

    static string RecipeMenuSearch()
    {
        List<Recipes.Recipe> matchedRecipes;

        while(true)
        {
            string search = AnsiConsole.Ask<string>("What recipe are you searching for? (Type \"Exit\" to go back to Recipe Menu)");
            if(search == "Exit")
            {
                return "";
            }

            matchedRecipes = Recipes.RecipeSearch(search);
            if(matchedRecipes.Count > 0)
            {
                break;
            }
        }

        string[] recipeTitles = new string[matchedRecipes.Count];

        for(var i = 0; i < matchedRecipes.Count; i++)
        {
            recipeTitles[i] = matchedRecipes[i].title;
        }

        string selection = Menu.DisplaySelectMenu("Recipe Menu", "Search For A Recipe", recipeTitles);

        return "";
    }

    static string RecipeMenuAdd()
    {
        string title;
        List<Inventory.IngredientAmount> ingredients = new List<Inventory.IngredientAmount>();
        string body;
        
        while(true)
        {
            title = AnsiConsole.Ask<string>("Enter the title for the new recipe. (Type \"Exit\" to go back to Recipe Menu)");
            if(title.ToLower() == "exit")
            {
                return "";
            }

            if(title != "")
            {
                break;
            }
        }

        while(true)
        {
            var ingredient = AnsiConsole.Ask<string>("Enter an ingredient in the new recipe. Type \"Done\" after entering all ingredients. (Type \"Exit\" to go back to Recipe Menu)");
            if(ingredient.ToLower() == "exit")
            {
                return "";
            }

            if(ingredient.ToLower() == "done")
            {
                break;
            }

            var amount = AnsiConsole.Ask<string>("Enter the amount of that ingredient (in grams) in the recipe. (Type \"Exit\" to go back to Recipe Menu)");
            if(ingredient.ToLower() == "exit")
            {
                return "";
            }
            
            ingredients.Add(new Inventory.IngredientAmount{item = new Inventory.Ingredient{name = ingredient}, amount = Convert.ToDouble(amount)});
        }

        while(true)
        {
            body = AnsiConsole.Ask<string>("Enter the body of the new recipe. (Type \"Exit\" to go back to Recipe Menu)");
            if(body.ToLower() == "Exit")
            {
                return "";
            }

            if(body != "")
            {
                break;
            }
        }

        return Recipes.RecipeAdd(title, ingredients, body);
    }

    static string RecipeMenuEdit()
    {
        List<Recipes.Recipe> matchedRecipes;

        while(true)
        {
            string search = AnsiConsole.Ask<string>("What recipe are you searching for? (Type \"Exit\" to go back to Recipe Menu)");
            if(search == "Exit")
            {
                return "";
            }

            matchedRecipes = Recipes.RecipeSearch(search);
            if(matchedRecipes.Count > 0)
            {
                break;
            }
        }

        string[] recipeTitles = new string[matchedRecipes.Count];

        for(var i = 0; i < matchedRecipes.Count; i++)
        {
            recipeTitles[i] = matchedRecipes[i].title;
        }

        string selection = Menu.DisplaySelectMenu("Recipe Menu", "Search For A Recipe", recipeTitles);

        return Recipes.RecipeEdit(selection);
    }

    static string RecipeMenuDelete()
    {
        List<Recipes.Recipe> matchedRecipes;

        while(true)
        {
            string search = AnsiConsole.Ask<string>("What recipe are you searching for? (Type \"Exit\" to go back to Recipe Menu)");
            if(search == "Exit")
            {
                return "";
            }

            matchedRecipes = Recipes.RecipeSearch(search);
            if(matchedRecipes.Count > 0)
            {
                break;
            }
        }

        string[] recipeTitles = new string[matchedRecipes.Count];

        for(var i = 0; i < matchedRecipes.Count; i++)
        {
            recipeTitles[i] = matchedRecipes[i].title;
        }

        string selection = Menu.DisplaySelectMenu("Recipe Menu", "Search For A Recipe", recipeTitles);

        return Recipes.RecipeDelete(selection);
    }

    static string GroceryListMenu()
    {
        var functionMap = new Dictionary<string, Delegate>
        {
            ["Add Item To Grocery List"] = new Func<string>(NotImplemented),
            ["Mark Item On Grocery List"] = new Func<string>(NotImplemented),
            ["Display Grocery List"] = new Func<string>(NotImplemented),
            ["Delete Item On Grocery List"] = new Func<string>(NotImplemented),
            ["Clear Grocery List"] = new Func<string>(NotImplemented),
        };

        string[] selectionOptions = ["Add Item To Grocery List", "Mark Item On Grocery List", "Display Grocery List", "Delete Item On Grocery List", "Clear Grocery List", "Return To Main Menu"];

        while(true)
        {
            string selection = DisplaySelectMenu("Grocery List Menu", "", selectionOptions);

            if(selection == "Return To Main Menu")
            {
                break;
            }

            functionMap[selection].DynamicInvoke();
        }

        return "";
    }

    static string IngredientSubstitutionMenu()
    {
        var functionMap = new Dictionary<string, Delegate>
        {
            ["Add Substitution"] = new Func<string>(NotImplemented),
            ["Delete Substitution"] = new Func<string>(NotImplemented),
            ["Search Substitutions"] = new Func<string>(NotImplemented),
        };

        string[] selectionOptions = ["Add Substitution", "Delete Substitution", "Search Substitutions", "Return To Main Menu"];

        while(true)
        {
            string selection = DisplaySelectMenu("Recipe Menu", "", selectionOptions);

            if(selection == "Return To Main Menu")
            {
                break;
            }

            functionMap[selection].DynamicInvoke();
        }

        return "";
    }

    static string InventoryManagementMenu()
    {
        var functionMap = new Dictionary<string, Delegate>
        {
            ["Add To Ingredient's Stock"] = new Func<string>(InventoryMenuAdd),
            ["Remove From Ingredient's Stock"] = new Func<string>(InventoryMenuRemove),
            ["List Ingredients"] = new Func<string>(InventoryMenuList),
            ["Add new Ingredient"] = new Func<string>(InventoryMenuAddNew),
        };

        string[] selectionOptions = ["Add To Ingredient's Stock", "Remove From Ingredient's Stock", "List Ingredients", "Add new Ingredient", "Return To Main Menu"];

        while(true)
        {
            string selection = DisplaySelectMenu("Recipe Menu", "", selectionOptions);

            if(selection == "Return To Main Menu")
            {
                break;
            }

            functionMap[selection].DynamicInvoke();
        }

        return "";
    }

    static string InventoryMenuAdd()
    {
        var ingredientName = AnsiConsole.Ask<string>("Enter name of the ingredient. (Type \"Exit\" to go back to Inventory Management Menu)");
        if(ingredientName.ToLower() == "exit")
        {
            return "";
        }

        var matchedIngredient = Inventory.InventorySearch(ingredientName);

        var amount = AnsiConsole.Ask<string>("Enter the amount to add in grams. (Type \"Exit\" to go back to Inventory Management Menu)");

        Inventory.InventoryAdd(matchedIngredient, amount);

        return "";
    }

    static public string InventoryMenuRemove()
    {
        var ingredientName = AnsiConsole.Ask<string>("Enter name of the ingredient. (Type \"Exit\" to go back to Inventory Management Menu)");
        if(ingredientName.ToLower() == "exit")
        {
            return "";
        }

        var matchedIngredient = Inventory.InventorySearch(ingredientName);

        var amount = AnsiConsole.Ask<string>("Enter the amount to remove. (Type \"Exit\" to go back to Inventory Management Menu)");

        Inventory.InventoryRemove(matchedIngredient, amount);

        return "";
    }

    static public string InventoryMenuList()
    {
        var inventory = new Table();
        
        inventory.AddColumn("Ingredient Name");
        inventory.AddColumn("Amount In Inventory");
        
        foreach(var item in Storage.inventory)
        {
            inventory.AddRow(item.item.name, item.amount.ToString());
        }
        
        AnsiConsole.Write(inventory);

        _ = AnsiConsole.Ask<string>("Press enter to continue...");

        return "";
    }

    static string InventoryMenuAddNew()
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

        return Inventory.InventoryAddNew(ingredientName);
    }

    public static string DisplaySelectMenu(string currentMenuName, string menuMessage, string[] selectionOptions)
    {
        AnsiConsole.MarkupLine("CS-690 Final Project: Christian Hering");

        if(menuMessage != "")
        {
            AnsiConsole.MarkupLine($"{currentMenuName}: {menuMessage}");
        } else {
            AnsiConsole.MarkupLine($"{currentMenuName}");
        }

        AnsiConsole.WriteLine(); // Space

        return AnsiConsole.Prompt(new SelectionPrompt<string>().AddChoices(selectionOptions));
    }
}
