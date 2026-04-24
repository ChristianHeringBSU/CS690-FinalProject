namespace cs690_final_project_testing;

using System.Text;

using cs690_final_project_source;

[Collection("Sequential")]
public class Inventory_Test
{
    [Fact]
    public void InventorySearch_Test()
    {
        // Write data to disk
        byte[] b = Encoding.ASCII.GetBytes("[{\"item\":{\"name\":\"olive oil\"},\"amount\":768},{\"item\":{\"name\":\"flour\"},\"amount\":7001},{\"item\":{\"name\":\"watermelon\"},\"amount\":1400},{\"item\":{\"name\":\"eggs\"},\"amount\":147},{\"item\":{\"name\":\"butter\"},\"amount\":90}]");
        File.WriteAllBytes("inventory.json", b);

        // Load that data into Storage.inventory
        Storage.ReadInventory();

        // Look for our olive oil listing
        var result = Inventory.InventorySearch("olive oil");

        // Make sure the amount matches the hardcoded data
        Assert.Equal(768, result.amount);
    }

    [Fact]
    public void InventoryAdd_Test()
    {
        // Write data to inventory.json
        byte[] b = Encoding.ASCII.GetBytes("[{\"item\":{\"name\":\"olive oil\"},\"amount\":768},{\"item\":{\"name\":\"flour\"},\"amount\":7001},{\"item\":{\"name\":\"watermelon\"},\"amount\":1400},{\"item\":{\"name\":\"eggs\"},\"amount\":147},{\"item\":{\"name\":\"butter\"},\"amount\":90}]");
        File.WriteAllBytes("inventory.json", b);

        // Load that data into Storage.inventory
        Storage.ReadInventory();

        // Add stock to an inventory item
        var _ = Inventory.InventoryAdd(new Inventory.IngredientAmount{
            item = new Inventory.Ingredient{
                name = "olive oil"
            }, amount = 768
        },
        "32");

        // Search for that inventory item
        var result = Inventory.InventorySearch("olive oil");

        Assert.Equal(800, result.amount);
    }

    [Fact]
    public void InventoryRemove_Test()
    {
        // Write data to inventory.json
        byte[] b = Encoding.ASCII.GetBytes("[{\"item\":{\"name\":\"olive oil\"},\"amount\":768},{\"item\":{\"name\":\"flour\"},\"amount\":7001},{\"item\":{\"name\":\"watermelon\"},\"amount\":1400},{\"item\":{\"name\":\"eggs\"},\"amount\":147},{\"item\":{\"name\":\"butter\"},\"amount\":90}]");
        File.WriteAllBytes("inventory.json", b);

        // Load data into Storage.inventory
        Storage.ReadInventory();

        // Remove from olive oil's stock
        var _ = Inventory.InventoryRemove(new Inventory.IngredientAmount{
            item = new Inventory.Ingredient{
                name = "olive oil"
            },
            amount = 768
        },
        "68");

        // Search for the new stock of olive oil
        var result = Inventory.InventorySearch("olive oil");

        // Make sure the stock matches
        Assert.Equal(700, result.amount);
    }

    [Fact]
    public void InventoryAddNew_Test()
    {
        // Write data to inventory.json
        byte[] b = Encoding.ASCII.GetBytes("[]");
        File.WriteAllBytes("inventory.json", b);

        // Load data into Storage.inventory
        Storage.ReadInventory();

        // Add a new item to inventory
        var _ = Inventory.InventoryAddNew("new item");

        // Make sure that's the only item
        Assert.True(Storage.inventory.Count == 1);
    }
}
