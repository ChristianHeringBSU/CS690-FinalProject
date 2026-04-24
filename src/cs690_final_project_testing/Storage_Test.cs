namespace cs690_final_project_testing;

using System.Text;
using System.Text.Json;

using cs690_final_project_source;

public class Storage_Test
{
    [Collection("Sequential")]
    public void ReadRecipes_Test()
    {
        // Write data to recipes.json
        byte[] b = Encoding.ASCII.GetBytes("[{\"title\":\"fried eggs\",\"ingredients\":[{\"item\":{\"name\":\"eggs\"},\"amount\":45},{\"item\":{\"name\":\"olive oil\"},\"amount\":25}],\"body\":\"First, crack your eggs into a bowl. Then heat olive oil in small sauce pan to 300F. Poar wisked eggs into hot oil and leave to cook for 4 minutes. Flip and leave for 5 minutes. Plate and serve.\"},{\"title\":\"boiled eggs\",\"ingredients\":[{\"item\":{\"name\":\"eggs\"},\"amount\":90},{\"item\":{\"name\":\"water\"},\"amount\":1000}],\"body\":\"First, place eggs in pot. Then, add water. Heat on high until at a roaring boil. Keep at a boil for 25 to 30 minutes. Plate and serve shell on.\"},{\"title\":\"sliced watermelon\",\"ingredients\":[{\"item\":{\"name\":\"watermelon\"},\"amount\":100}],\"body\":\"Get a chef knife and cut your (optionally chilled) watermelon into slices. Plate and serve fresh.\"}]");
        File.WriteAllBytes("recipes.json", b);

        // Load data from recipes.json
        Storage.ReadRecipes();

        // Serialize the data object
        string data = JsonSerializer.Serialize(Storage.recipes);

        // Make sure the data written and read match
        Assert.Equal(Encoding.UTF8.GetString(b), data.ToString());
    }

    [Collection("Sequential")]
    public void WriteRecipes_Test()
    {
        // Write an empty recipe list to Storage.recipes
        Storage.recipes = new List<Recipes.Recipe>{};

        // Write that data to disk
        Storage.WriteRecipes();

        // Read out the data from recipes.json
        var s = File.ReadAllText("recipes.json");
        
        Assert.Equal("[]", s.Trim());
    }

    [Collection("Sequential")]
    public void ReadGroceryList_Test()
    {
        // Write data to grocery_list.json
        byte[] b = Encoding.ASCII.GetBytes("[{\"item\":{\"name\":\"oranges\"},\"marked\":false},{\"item\":{\"name\":\"sugar\"},\"marked\":false},{\"item\":{\"name\":\"eggs\"},\"marked\":true},{\"item\":{\"name\":\"watermelon\"},\"marked\":true}]");
        File.WriteAllBytes("grocery_list.json", b);

        // Load data into Storage.groceryList
        Storage.ReadGroceryList();

        // Serialize the data object
        string data = JsonSerializer.Serialize(Storage.groceryList);

        // Make sure the serialized input data matches the current data object
        Assert.Equal(Encoding.UTF8.GetString(b), data.ToString());
    }

    [Collection("Sequential")]
    public void WriteGroceryList_Test()
    {
        // Make an empty grocery list object
        Storage.groceryList = new List<Grocery.GroceryListItem>{};

        // Write that data to disk
        Storage.WriteGroceryList();

        // Read the empty json object from disk
        var s = File.ReadAllText("grocery_list.json");
        
        Assert.Equal("[]", s.Trim());
    }

    [Collection("Sequential")]
    public void ReadSubstitutions_Test()
    {
        // Write data to disk
        byte[] b = Encoding.ASCII.GetBytes("[{\"toSub\":{\"name\":\"eggs\"},\"sub\":{\"name\":\"applesauce\"}}]");
        File.WriteAllBytes("ingredients.json", b);

        // Load data into ingredients.json
        Storage.ReadSubstitutions();

        // Serialize the data written to disk
        string data = JsonSerializer.Serialize(Storage.substitutions);

        // Make sure the serialized input data matches the current data object
        Assert.Equal(Encoding.UTF8.GetString(b), data.ToString());
    }

    [Collection("Sequential")]
    public void WriteSubstitutions_Test()
    {
        // Make an empty substitutions object
        Storage.substitutions = new List<Ingredient.Substitution>{};

        // Write that data to disk
        Storage.WriteSubstitutions();

        // Read the empty json object from disk
        var s = File.ReadAllText("ingredients.json");
        
        Assert.Equal("[]", s.Trim());
    }

    [Collection("Sequential")]
    public void ReadInventory_Test()
    {
        // Write data to disk
        byte[] b = Encoding.ASCII.GetBytes("[{\"item\":{\"name\":\"olive oil\"},\"amount\":768},{\"item\":{\"name\":\"flour\"},\"amount\":7001},{\"item\":{\"name\":\"watermelon\"},\"amount\":1400},{\"item\":{\"name\":\"eggs\"},\"amount\":147},{\"item\":{\"name\":\"butter\"},\"amount\":90}]");
        File.WriteAllBytes("inventory.json", b);

        // Load data into inventory.json
        Storage.ReadInventory();

        // Serialize the data written to disk
        string data = JsonSerializer.Serialize(Storage.inventory);

        // Make sure the serialized input data matches the current data object
        Assert.Equal(Encoding.UTF8.GetString(b), data.ToString());
    }

    [Collection("Sequential")]
    public void WriteInventory_Test()
    {
        // Make an empty inventory object
        Storage.inventory = new List<Inventory.IngredientAmount>{};

        // Write that data to disk
        Storage.WriteInventory();

        // Read the empty json object from disk
        var s = File.ReadAllText("inventory.json");
        
        Assert.Equal("[]", s.Trim());
    }
}
