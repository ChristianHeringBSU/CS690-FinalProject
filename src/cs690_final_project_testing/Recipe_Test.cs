namespace cs690_final_project_testing;

using System.Text;

using cs690_final_project_source;

public class Recipe_Test
{
    [Fact]
    public void RecipeSearch_Test()
    {
        // Write data to recipes.json
        byte[] b = Encoding.ASCII.GetBytes("[{\"title\":\"fried eggs\",\"ingredients\":[{\"item\":{\"name\":\"eggs\"},\"amount\":45},{\"item\":{\"name\":\"olive oil\"},\"amount\":25}],\"body\":\"First, crack your eggs into a bowl. Then heat olive oil in small sauce pan to 300F. Poar wisked eggs into hot oil and leave to cook for 4 minutes. Flip and leave for 5 minutes. Plate and serve.\"},{\"title\":\"boiled eggs\",\"ingredients\":[{\"item\":{\"name\":\"eggs\"},\"amount\":90},{\"item\":{\"name\":\"water\"},\"amount\":1000}],\"body\":\"First, place eggs in pot. Then, add water. Heat on high until at a roaring boil. Keep at a boil for 25 to 30 minutes. Plate and serve shell on.\"},{\"title\":\"sliced watermelon\",\"ingredients\":[{\"item\":{\"name\":\"watermelon\"},\"amount\":100}],\"body\":\"Get a chef knife and cut your (optionally chilled) watermelon into slices. Plate and serve fresh.\"}]");
        File.WriteAllBytes("recipes.json", b);

        // Load data from recipes.json
        Storage.ReadRecipes();

        // Search for fried eggs
        var result = Recipes.RecipeSearch("eggs");

        // Make sure fried eggs is found
        Assert.Equal("fried eggs", result[0].title);
    }

    [Fact]
    public void RecipeAdd_Test()
    {
        // Write data to recipes.json
        byte[] b = Encoding.ASCII.GetBytes("[]");
        File.WriteAllBytes("recipes.json", b);

        // Load data from recipes.json
        Storage.ReadRecipes();

        // Write a new recipe
        var _ = Recipes.RecipeAdd("burnt eggs", new List<Inventory.IngredientAmount>{}, "test body");
        
        // Make sure there's now a recipe
        Assert.True(Storage.recipes.Count == 1);
    }

    [Fact]
    public void RecipeDelete_Test()
    {
        // Write data to recipes.json
        byte[] b = Encoding.ASCII.GetBytes("[{\"title\":\"fried eggs\",\"ingredients\":[{\"item\":{\"name\":\"eggs\"},\"amount\":45},{\"item\":{\"name\":\"olive oil\"},\"amount\":25}],\"body\":\"First, crack your eggs into a bowl. Then heat olive oil in small sauce pan to 300F. Poar wisked eggs into hot oil and leave to cook for 4 minutes. Flip and leave for 5 minutes. Plate and serve.\"}]");
        File.WriteAllBytes("recipes.json", b);

        // Load data from recipes.json
        Storage.ReadRecipes();

        // Delete the single recipe
        var _ = Recipes.RecipeDelete("fried eggs");
        
        // Compare
        Assert.True(Storage.recipes.Count == 0);
    }
}
