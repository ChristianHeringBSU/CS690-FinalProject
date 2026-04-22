namespace cs690_final_project_testing;

using System.Text;
using System.Text.Json;

using cs690_final_project_source;

public class Storage_Test
{
    [Fact]
    public void ReadRecipes_Test()
    {
        byte[] b = Encoding.ASCII.GetBytes("[{\"title\":\"fried eggs\",\"ingredients\":[{\"item\":{\"name\":\"eggs\"},\"amount\":45},{\"item\":{\"name\":\"olive oil\"},\"amount\":25}],\"body\":\"First, crack your eggs into a bowl. Then heat olive oil in small sauce pan to 300F. Poar wisked eggs into hot oil and leave to cook for 4 minutes. Flip and leave for 5 minutes. Plate and serve.\"},{\"title\":\"boiled eggs\",\"ingredients\":[{\"item\":{\"name\":\"eggs\"},\"amount\":90},{\"item\":{\"name\":\"water\"},\"amount\":1000}],\"body\":\"First, place eggs in pot. Then, add water. Heat on high until at a roaring boil. Keep at a boil for 25 to 30 minutes. Plate and serve shell on.\"},{\"title\":\"sliced watermelon\",\"ingredients\":[{\"item\":{\"name\":\"watermelon\"},\"amount\":100}],\"body\":\"Get a chef knife and cut your (optionally chilled) watermelon into slices. Plate and serve fresh.\"}]");

        File.WriteAllBytes("recipes.json", b);

        Storage.ReadRecipes();

        string data = JsonSerializer.Serialize(Storage.recipes);

        Assert.Equal(Encoding.UTF8.GetString(b), data.ToString());
    }

    [Fact]
    public void WriteRecipes_Test()
    {
        Storage.recipes = new List<Recipes.Recipe>{};

        Storage.WriteRecipes();

        var s = File.ReadAllText("recipes.json");
        
        Assert.Equal("[]\n", s);
    }

    [Fact]
    public void ReadGroceryList_Test()
    {
        byte[] b = Encoding.ASCII.GetBytes("[{\"item\":{\"name\":\"oranges\"},\"marked\":false},{\"item\":{\"name\":\"sugar\"},\"marked\":false},{\"item\":{\"name\":\"eggs\"},\"marked\":true},{\"item\":{\"name\":\"watermelon\"},\"marked\":true}]");

        File.WriteAllBytes("grocery_list.json", b);

        Storage.ReadGroceryList();

        string data = JsonSerializer.Serialize(Storage.groceryList);

        Assert.Equal(Encoding.UTF8.GetString(b), data.ToString());
    }

    [Fact]
    public void WriteGroceryList_Test()
    {
        Storage.groceryList = new List<Grocery.GroceryListItem>{};

        Storage.WriteGroceryList();

        var s = File.ReadAllText("grocery_list.json");
        
        Assert.Equal("[]\n", s);
    }

    [Fact]
    public void ReadSubstitutions_Test()
    {
        byte[] b = Encoding.ASCII.GetBytes("[{\"toSub\":{\"name\":\"eggs\"},\"sub\":{\"name\":\"applesauce\"}}]");

        File.WriteAllBytes("ingredients.json", b);

        Storage.ReadSubstitutions();

        string data = JsonSerializer.Serialize(Storage.substitutions);

        Assert.Equal(Encoding.UTF8.GetString(b), data.ToString());
    }

    [Fact]
    public void WriteSubstitutions_Test()
    {
        Storage.substitutions = new List<Ingredient.Substitution>{};

        Storage.WriteSubstitutions();

        var s = File.ReadAllText("ingredients.json");
        
        Assert.Equal("[]\n", s);
    }

    [Fact]
    public void ReadInventory_Test()
    {
        byte[] b = Encoding.ASCII.GetBytes("[{\"item\":{\"name\":\"olive oil\"},\"amount\":768},{\"item\":{\"name\":\"flour\"},\"amount\":7001},{\"item\":{\"name\":\"watermelon\"},\"amount\":1400},{\"item\":{\"name\":\"eggs\"},\"amount\":147},{\"item\":{\"name\":\"butter\"},\"amount\":90}]");

        File.WriteAllBytes("inventory.json", b);

        Storage.ReadInventory();

        string data = JsonSerializer.Serialize(Storage.inventory);

        Assert.Equal(Encoding.UTF8.GetString(b), data.ToString());
    }

    [Fact]
    public void WriteInventory_Test()
    {
        Storage.inventory = new List<Inventory.IngredientAmount>{};

        Storage.WriteInventory();

        var s = File.ReadAllText("inventory.json");
        
        Assert.Equal("[]\n", s);
    }
}
