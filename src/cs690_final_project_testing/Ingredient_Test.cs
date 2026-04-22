namespace cs690_final_project_testing;

using System.Text;
using System.Text.Json;

using cs690_final_project_source;

public class Ingredient_Test
{
    [Fact]
    public void SubstitutionAdd_Test()
    {
        byte[] b = Encoding.ASCII.GetBytes("[]");

        File.WriteAllBytes("ingredients.json", b);

        Storage.ReadSubstitutions();

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

        Assert.Equal("applesauce", Storage.substitutions[0].sub.name);
    }

    [Fact]
    public void SubstitutionDelete_Test()
    {
        byte[] b = Encoding.ASCII.GetBytes("[{\"toSub\":{\"name\":\"eggs\"},\"sub\":{\"name\":\"applesauce\"}}]");

        File.WriteAllBytes("ingredients.json", b);

        Storage.ReadSubstitutions();

        var _ = Ingredient.SubstitutionDelete("0");

        var s = File.ReadAllText("ingredients.json");

        Assert.Equal("[]\n", s);
    }
}
