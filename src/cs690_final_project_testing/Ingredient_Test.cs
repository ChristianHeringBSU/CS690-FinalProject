namespace cs690_final_project_testing;

using System.Text;

using cs690_final_project_source;

[Collection("Sequential")]
public class Ingredient_Test
{
    [Fact]
    public void SubstitutionAdd_Test()
    {
        // Write data to ingredients.json
        byte[] b = Encoding.ASCII.GetBytes("[]");
        File.WriteAllBytes("ingredients.json", b);

        // Load data into Storage.substitutions
        Storage.ReadSubstitutions();

        // Construct and add a new substitution
        var _ = Ingredient.SubstitutionAdd(new Ingredient.Substitution
        {
            toSub = new Inventory.Ingredient
            {
                name = "eggs",
            },
            sub = new Inventory.Ingredient
            {
                name = "applesauce",
            }
        });

        // Make sure that substitution exists
        Assert.Equal("applesauce", Storage.substitutions[0].sub.name);
    }

    [Fact]
    public void SubstitutionDelete_Test()
    {
        // Write data to ingredients.json
        byte[] b = Encoding.ASCII.GetBytes("[{\"toSub\":{\"name\":\"eggs\"},\"sub\":{\"name\":\"applesauce\"}}]");
        File.WriteAllBytes("ingredients.json", b);

        // Load ingredients.json into Storage.substitutions var
        Storage.ReadSubstitutions();

        // Delete the only substitution
        var _ = Ingredient.SubstitutionDelete("eggs", "applesauce");

        // Read and compare the file data to what should be there
        var s = File.ReadAllText("ingredients.json");

        Assert.Equal("[]", s.Trim());
    }
}
