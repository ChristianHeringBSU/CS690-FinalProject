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
            ["Search For A Recipe"] = new Func<string>(NotImplemented),
            ["Add A New Recipe"] = new Func<string>(NotImplemented),
            ["Edit A Recipe"] = new Func<string>(NotImplemented),
            ["Delete A Recipe"] = new Func<string>(NotImplemented),
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
            ["Add To Ingredient's Stock"] = new Func<string>(NotImplemented),
            ["Remove From Ingredient's Stock"] = new Func<string>(NotImplemented),
            ["List Ingredients"] = new Func<string>(NotImplemented),
            ["Add new Ingredient"] = new Func<string>(NotImplemented),
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

    static string DisplaySelectMenu(string currentMenuName, string menuMessage, string[] selectionOptions)
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
