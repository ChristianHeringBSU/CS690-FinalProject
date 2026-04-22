namespace cs690_final_project_testing;

using System.Text;

using cs690_final_project_source;

public class Inventory_Test
{
    [Fact]
    public void InventorySearch_Test()
    {
        byte[] b = Encoding.ASCII.GetBytes("[{\"item\":{\"name\":\"olive oil\"},\"amount\":768},{\"item\":{\"name\":\"flour\"},\"amount\":7001},{\"item\":{\"name\":\"watermelon\"},\"amount\":1400},{\"item\":{\"name\":\"eggs\"},\"amount\":147},{\"item\":{\"name\":\"butter\"},\"amount\":90}]");

        File.WriteAllBytes("inventory.json", b);
        Storage.ReadInventory();

        var result = Inventory.InventorySearch("olive oil");

        Assert.Equal(768, result.amount);
    }

    [Fact]
    public void InventoryAdd_Test()
    {
        byte[] b = Encoding.ASCII.GetBytes("[{\"item\":{\"name\":\"olive oil\"},\"amount\":768},{\"item\":{\"name\":\"flour\"},\"amount\":7001},{\"item\":{\"name\":\"watermelon\"},\"amount\":1400},{\"item\":{\"name\":\"eggs\"},\"amount\":147},{\"item\":{\"name\":\"butter\"},\"amount\":90}]");

        File.WriteAllBytes("inventory.json", b);
        Storage.ReadInventory();

        var _ = Inventory.InventoryAdd(new Inventory.IngredientAmount{item = new Inventory.Ingredient{name = "olive oil"}, amount = 768}, "32");

        var result = Inventory.InventorySearch("olive oil");

        Assert.Equal(800, result.amount);
    }

    [Fact]
    public void InventoryRemove_Test()
    {
        byte[] b = Encoding.ASCII.GetBytes("[{\"item\":{\"name\":\"olive oil\"},\"amount\":768},{\"item\":{\"name\":\"flour\"},\"amount\":7001},{\"item\":{\"name\":\"watermelon\"},\"amount\":1400},{\"item\":{\"name\":\"eggs\"},\"amount\":147},{\"item\":{\"name\":\"butter\"},\"amount\":90}]");

        File.WriteAllBytes("inventory.json", b);
        Storage.ReadInventory();

        var _ = Inventory.InventoryRemove(new Inventory.IngredientAmount{item = new Inventory.Ingredient{name = "olive oil"}, amount = 768}, "68");

        var result = Inventory.InventorySearch("olive oil");

        Assert.Equal(700, result.amount);
    }

    [Fact]
    public void InventoryAddNew_Test()
    {
        byte[] b = Encoding.ASCII.GetBytes("[{\"item\":{\"name\":\"olive oil\"},\"amount\":768},{\"item\":{\"name\":\"flour\"},\"amount\":7001},{\"item\":{\"name\":\"watermelon\"},\"amount\":1400},{\"item\":{\"name\":\"eggs\"},\"amount\":147},{\"item\":{\"name\":\"butter\"},\"amount\":90}]");

        File.WriteAllBytes("inventory.json", b);
        Storage.ReadInventory();
        var original_data = Storage.inventory;

        var _ = Inventory.InventoryAddNew("new item");

        Assert.Equal((original_data.Count + 1).ToString(), Storage.inventory.Count.ToString());
    }
}
