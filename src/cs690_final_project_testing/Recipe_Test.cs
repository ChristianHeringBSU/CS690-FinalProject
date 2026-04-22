namespace cs690_final_project_testing;

using System.Text;

using cs690_final_project_source;

public class Recipe_Test
{
    [Fact]
    public void RecipeSearch_Test()
    {
        byte[] b = Encoding.ASCII.GetBytes("[{\"title\":\"fried eggs\",\"ingredients\":[{\"item\":{\"name\":\"eggs\"},\"amount\":45},{\"item\":{\"name\":\"olive oil\"},\"amount\":25}],\"body\":\"First, crack your eggs into a bowl. Then heat olive oil in small sauce pan to 300F. Poar wisked eggs into hot oil and leave to cook for 4 minutes. Flip and leave for 5 minutes. Plate and serve.\"},{\"title\":\"boiled eggs\",\"ingredients\":[{\"item\":{\"name\":\"eggs\"},\"amount\":90},{\"item\":{\"name\":\"water\"},\"amount\":1000}],\"body\":\"First, place eggs in pot. Then, add water. Heat on high until at a roaring boil. Keep at a boil for 25 to 30 minutes. Plate and serve shell on.\"},{\"title\":\"sliced watermelon\",\"ingredients\":[{\"item\":{\"name\":\"watermelon\"},\"amount\":100}],\"body\":\"Get a chef knife and cut your (optionally chilled) watermelon into slices. Plate and serve fresh.\"}]");

        File.WriteAllBytes("recipes.json", b);

        var result = Recipes.RecipeSearch("eggs");

        Assert.Equal("fried eggs", result[0].title);
    }

    [Fact]
    public void RecipeAdd_Test()
    {
        byte[] b = Encoding.ASCII.GetBytes("[{\"title\":\"fried eggs\",\"ingredients\":[{\"item\":{\"name\":\"eggs\"},\"amount\":45},{\"item\":{\"name\":\"olive oil\"},\"amount\":25}],\"body\":\"First, crack your eggs into a bowl. Then heat olive oil in small sauce pan to 300F. Poar wisked eggs into hot oil and leave to cook for 4 minutes. Flip and leave for 5 minutes. Plate and serve.\"},{\"title\":\"boiled eggs\",\"ingredients\":[{\"item\":{\"name\":\"eggs\"},\"amount\":90},{\"item\":{\"name\":\"water\"},\"amount\":1000}],\"body\":\"First, place eggs in pot. Then, add water. Heat on high until at a roaring boil. Keep at a boil for 25 to 30 minutes. Plate and serve shell on.\"},{\"title\":\"sliced watermelon\",\"ingredients\":[{\"item\":{\"name\":\"watermelon\"},\"amount\":100}],\"body\":\"Get a chef knife and cut your (optionally chilled) watermelon into slices. Plate and serve fresh.\"}]");

        File.WriteAllBytes("recipes.json", b);

        Storage.ReadRecipes();
        var original_data = Storage.recipes;

        var _ = Recipes.RecipeAdd("burnt eggs", new List<Inventory.IngredientAmount>{}, "test body");
        
        Assert.Equal((original_data.Count + 1).ToString(), Storage.recipes.Count.ToString());
    }

    [Fact]
    public void RecipeDelete_Test()
    {
        byte[] b = Encoding.ASCII.GetBytes("[{\"title\":\"fried eggs\",\"ingredients\":[{\"item\":{\"name\":\"eggs\"},\"amount\":45},{\"item\":{\"name\":\"olive oil\"},\"amount\":25}],\"body\":\"First, crack your eggs into a bowl. Then heat olive oil in small sauce pan to 300F. Poar wisked eggs into hot oil and leave to cook for 4 minutes. Flip and leave for 5 minutes. Plate and serve.\"},{\"title\":\"boiled eggs\",\"ingredients\":[{\"item\":{\"name\":\"eggs\"},\"amount\":90},{\"item\":{\"name\":\"water\"},\"amount\":1000}],\"body\":\"First, place eggs in pot. Then, add water. Heat on high until at a roaring boil. Keep at a boil for 25 to 30 minutes. Plate and serve shell on.\"},{\"title\":\"sliced watermelon\",\"ingredients\":[{\"item\":{\"name\":\"watermelon\"},\"amount\":100}],\"body\":\"Get a chef knife and cut your (optionally chilled) watermelon into slices. Plate and serve fresh.\"}]");

        File.WriteAllBytes("recipes.json", b);

        Storage.ReadRecipes();
        var original_data = Storage.recipes.Count - 1;

        var _ = Recipes.RecipeDelete("fried eggs");
        
        Assert.Equal(original_data.ToString(), Storage.recipes.Count.ToString());
    }
}
