namespace cs690_final_project_source;

using System.Runtime.CompilerServices;
using Spectre.Console;

class Menu
{
    static string NotImplemented()
    {
        _ = AnsiConsole.Ask("Not Implemented!", "");

        return "";
    }

    static string Init()
    {
        Storage.ReadRecipes();
        Storage.ReadGroceryList();
        Storage.ReadSubstitutions();
        Storage.ReadInventory();

        return "";
    }
    static public void MainMenu()
    {
        Init(); // Initialize storage var values

        var functionMap = new Dictionary<string, Delegate>
        {
            ["Recipe"] = new Func<string>(RecipeMenu),
            ["Grocery List"] = new Func<string>(GroceryListMenu),
            ["Ingredient Substitutions"] = new Func<string>(IngredientSubstitutionMenu),
            ["Inventory Management"] = new Func<string>(InventoryManagementMenu),
        };

        var selectionOptions = new List<string>{"Recipe", "Grocery List", "Ingredient Substitutions", "Inventory Management", "Exit"};

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

        var selectionOptions = new List<string>{"Search For A Recipe", "Add A New Recipe", "Edit A Recipe", "Delete A Recipe",  "Return To Main Menu"};

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
            string search = AnsiConsole.Ask("What recipe are you searching for? (Type \"Exit\" to go back to Recipe Menu)", "");
            if(search.ToLower() == "exit")
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

        string selection = DisplaySelectMenu("Recipe Menu", "Search For A Recipe", recipeTitles.ToList());

        var recipe = matchedRecipes.First(n => n.title == selection);

        AnsiConsole.MarkupLine($"Recipe Menu: {selection}");
        AnsiConsole.WriteLine("");

        for(var i = 0; i < recipe.ingredients.Count; i++)
        {
            var ingredient = recipe.ingredients[i];
            
            AnsiConsole.MarkupLine($" - {ingredient.amount.ToString()}g {ingredient.item.name.ToString()}");
        }

        AnsiConsole.WriteLine("");
        AnsiConsole.WriteLine(recipe.body);
        AnsiConsole.WriteLine("");

        _ = AnsiConsole.Ask("Press enter to return to Recipe Menu.", "");

        return "";
    }

    static string RecipeMenuAdd()
    {
        string title;
        List<Inventory.IngredientAmount> ingredients = new List<Inventory.IngredientAmount>();
        string body;
        
        while(true)
        {
            title = AnsiConsole.Ask("Enter the title for the new recipe. (Type \"Exit\" to go back to Recipe Menu)", "");
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
            var ingredient = AnsiConsole.Ask("Enter an ingredient in the new recipe. Type \"Done\" after entering all ingredients. (Type \"Exit\" to go back to Recipe Menu)", "");
            if(ingredient.ToLower() == "exit")
            {
                return "";
            }

            if(ingredient.ToLower() == "done")
            {
                break;
            }

            var amount = AnsiConsole.Ask("Enter the amount of that ingredient (in grams) in the recipe. (Type \"Exit\" to go back to Recipe Menu)", "");
            if(ingredient.ToLower() == "exit")
            {
                return "";
            }

            try
            {
                _ = Convert.ToDouble(amount);
            }
            catch(Exception)
            {
                AnsiConsole.Ask("Invalid amount entered!", "");

                return "";
            }
            
            ingredients.Add(new Inventory.IngredientAmount{item = new Inventory.Ingredient{name = ingredient}, amount = Convert.ToDouble(amount)});
        }

        while(true)
        {
            body = AnsiConsole.Ask("Enter the body of the new recipe. (Type \"Exit\" to go back to Recipe Menu)", "");
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
            string search = AnsiConsole.Ask("What recipe are you searching for? (Type \"Exit\" to go back to Recipe Menu)", "");
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

        string selection = Menu.DisplaySelectMenu("Recipe Menu", "Search For A Recipe", recipeTitles.ToList());

        return Recipes.RecipeEdit(selection);
    }

    static string RecipeMenuDelete()
    {
        List<Recipes.Recipe> matchedRecipes;

        while(true)
        {
            string search = AnsiConsole.Ask("What recipe are you searching for? (Type \"Exit\" to go back to Recipe Menu)", "");
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

        string selection = Menu.DisplaySelectMenu("Recipe Menu", "Search For A Recipe", recipeTitles.ToList());

        return Recipes.RecipeDelete(selection);
    }

    static string GroceryListMenu()
    {
        var functionMap = new Dictionary<string, Delegate>
        {
            ["Add Item To Grocery List"] = new Func<string>(GroceryListMenuAdd),
            ["Mark Item On Grocery List"] = new Func<string>(GroceryListMenuMark),
            ["Display Grocery List"] = new Func<string>(GroceryListMenuDisplay),
            ["Delete Item On Grocery List"] = new Func<string>(GroceryListMenuDelete),
            ["Clear Grocery List"] = new Func<string>(GroceryListMenuClear),
        };

        var selectionOptions = new List<string>{"Add Item To Grocery List", "Mark Item On Grocery List", "Display Grocery List", "Delete Item On Grocery List", "Clear Grocery List", "Return To Main Menu"};

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

    static string GroceryListMenuAdd()
    {
        Storage.ReadGroceryList();

        AnsiConsole.WriteLine();

        string item = AnsiConsole.Ask<string>("Enter name of the item. (Type \"Exit\" to go back to Grocery List Menu)");
        if(item.ToLower() == "exit")
        {
            return "";
        }

        return Grocery.GroceryListAdd(item);
    }

    static string GroceryListMenuMark()
    {
        var items = new List<string>();

        foreach(var item in Storage.groceryList)
        {
            items.Add(item.item.name);
        }

        var selection = DisplaySelectMenu("Grocery List", "Mark Item", items);
        
        return Grocery.GroceryListMark(selection);
    }

    static string GroceryListMenuDisplay()
    {
        Storage.ReadGroceryList();
        
        var grocery_list = new Table();
        
        grocery_list.AddColumn("Grocery List Item");
        grocery_list.AddColumn("Is Marked");
        
        foreach(var item in Storage.groceryList)
        {
            grocery_list.AddRow(item.item.name.ToString(), item.marked.ToString());
        }
        
        AnsiConsole.Write(grocery_list);

        _ = AnsiConsole.Ask("Press enter to continue...", "");
        
        return "";
    }

    static string GroceryListMenuDelete()
    {
        var items = new List<string>();

        foreach(var item in Storage.groceryList)
        {
            items.Add(item.item.name);
        }

        var selection = DisplaySelectMenu("Grocery List", "Delete Item", items);
        
        return Grocery.GroceryListDelete(selection);
    }

    static string GroceryListMenuClear()
    {
        AnsiConsole.WriteLine("Clearing marked items from grocery list...");

        return Grocery.GroceryListClear();
    }

    static string IngredientSubstitutionMenu()
    {
        var functionMap = new Dictionary<string, Delegate>
        {
            ["Add Substitution"] = new Func<string>(SubstitutionAdd),
            ["Delete Substitution"] = new Func<string>(SubstitutionDelete),
            ["Search Substitutions"] = new Func<string>(SubstitutionSearch),
        };

        var selectionOptions = new List<string>{"Add Substitution", "Delete Substitution", "Search Substitutions", "Return To Main Menu"};

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

    static string SubstitutionSearch()
    {
        Storage.ReadSubstitutions();
        
        var search = AnsiConsole.Ask("Please search for a substitution or type \"Exit\" to return to the Ingredient Substitution menu.", "");
        if(search.ToLower() == "exit")
        {
            return "";
        }

        var substitutions = new Table();
        
        substitutions.AddColumn("Index");
        substitutions.AddColumn("Item To Replace");
        substitutions.AddColumn("Substitution");
        
        foreach(var item in Storage.substitutions)
        {
            if(item.sub.name.Contains(search) != true && item.toSub.name.Contains(search) != true)
            {
                continue;
            }

            substitutions.AddRow(Storage.substitutions.IndexOf(item).ToString(), item.toSub.name.ToString(), item.sub.name.ToString());
        }
        
        AnsiConsole.Write(substitutions);

        _ = AnsiConsole.Ask("Press enter to continue...", "");
        
        return "";
    }

    static string SubstitutionAdd()
    {
        var item = AnsiConsole.Ask("Please input the item to be replaced. Type \"Exit\" to return to Ingredient Substitution Menu.", "");
        if(item.ToLower() == "exit")
        {
            return "";
        }

        var substitution = AnsiConsole.Ask("Please input the substitution. Type \"Exit\" to return to Ingredient Substitution Menu.", "");
        if(substitution.ToLower() == "exit")
        {
            return "";
        }

        return Ingredient.SubstitutionAdd(new Ingredient.Substitution{toSub = new Inventory.Ingredient{name = item}, sub = new Inventory.Ingredient{name = substitution}});
    }

    static string SubstitutionDelete()
    {
        var substitutions = new Table();
        
        substitutions.AddColumn("Index");
        substitutions.AddColumn("Item To Replace");
        substitutions.AddColumn("Substitution");
        
        foreach(var item in Storage.substitutions)
        {
            substitutions.AddRow(Storage.substitutions.IndexOf(item).ToString(), item.toSub.name.ToString(), item.sub.name.ToString());
        }
        
        AnsiConsole.Write(substitutions);

        var selection = AnsiConsole.Ask("Please enter the index number of the substitution to remove or type \"Exit\" to return to the Ingredient Substitution Menu.", "");
        if(selection.ToLower() == "exit")
        {
            return "";
        }

        if(Convert.ToDouble(selection) >= Storage.substitutions.Count)
        {
            AnsiConsole.Ask("Invalid input. Press enter to continue...", "");

            return "";
        }

        return Ingredient.SubstitutionDelete(selection);
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

        var selectionOptions = new List<string>{"Add To Ingredient's Stock", "Remove From Ingredient's Stock", "List Ingredients", "Add new Ingredient", "Return To Main Menu"};

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
        var ingredientName = AnsiConsole.Ask("Enter name of the ingredient. (Type \"Exit\" to go back to Inventory Management Menu)", "");
        if(ingredientName.ToLower() == "exit")
        {
            return "";
        }

        var matchedIngredient = Inventory.InventorySearch(ingredientName);
        if(matchedIngredient.item.name == null)
        {
            AnsiConsole.Ask("Invalid ingredient name entered.", "");

            return "";
        }

        var amount = AnsiConsole.Ask("Enter the amount to add in grams. (Type \"Exit\" to go back to Inventory Management Menu)", "");
        if(amount.Contains("-"))
        {
            AnsiConsole.Ask("Invalid amount entered.", "");

            return "";
        }

        try
        {
            _ = Convert.ToDouble(amount);
        }
        catch(Exception)
        {
            AnsiConsole.Ask("Invalid amount entered!", "");

            return "";
        }

        Inventory.InventoryAdd(matchedIngredient, amount);

        return "";
    }

    static public string InventoryMenuRemove()
    {
        var ingredientName = AnsiConsole.Ask("Enter name of the ingredient. (Type \"Exit\" to go back to Inventory Management Menu)", "");
        if(ingredientName.ToLower() == "exit")
        {
            return "";
        }

        var matchedIngredient = Inventory.InventorySearch(ingredientName);
        if(matchedIngredient.item.name == null)
        {
            AnsiConsole.Ask("Invalid ingredient name entered.", "");

            return "";
        }

        var amount = AnsiConsole.Ask("Enter the amount to remove. (Type \"Exit\" to go back to Inventory Management Menu)", "");
        if(amount.Contains("-"))
        {
            AnsiConsole.Ask("Invalid amount entered.", "");

            return "";
        }

        try
        {
            _ = Convert.ToDouble(amount);
        }
        catch(Exception)
        {
            AnsiConsole.Ask("Invalid amount entered!", "");

            return "";
        }

        Inventory.InventoryRemove(matchedIngredient, amount);

        return "";
    }

    static public string InventoryMenuList()
    {
        Storage.ReadInventory();
        
        var inventory = new Table();
        
        inventory.AddColumn("Ingredient Name");
        inventory.AddColumn("Amount In Inventory");
        
        foreach(var item in Storage.inventory)
        {
            inventory.AddRow(item.item.name.ToString(), item.amount.ToString());
        }
        
        AnsiConsole.Write(inventory);

        _ = AnsiConsole.Ask("Press enter to continue...", "");

        return "";
    }

    static string InventoryMenuAddNew()
    {
        var ingredientName = "";
        
        while(true)
        {
            ingredientName = AnsiConsole.Ask("Enter name of new ingredient. (Type \"Exit\" to go back to Inventory Management Menu)", "");
            if(ingredientName.ToLower() == "exit")
            {
                return "";
            }

            if(ingredientName != "")
            {
                break;
            }
        }

        return Inventory.InventoryAddNew(ingredientName);
    }

    public static string DisplaySelectMenu(string currentMenuName, string menuMessage, List<string> selectionOptions)
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
