namespace cs690_final_project_testing;

using System.Text;
using System.Text.Json;

using cs690_final_project_source;

public class Grocery_Test
{
    [Fact]
    public void GroceryListAdd_Test()
    {
        byte[] b = Encoding.ASCII.GetBytes("[]");

        File.WriteAllBytes("grocery_list.json", b);

        Storage.ReadGroceryList();

        var _ = Grocery.GroceryListAdd("eggs");

        Assert.Equal("eggs", Storage.groceryList[0].item.name);
    }

    [Fact]
    public void GroceryListMark_Test()
    {
        byte[] b = Encoding.ASCII.GetBytes("[{\"item\":{\"name\":\"oranges\"},\"marked\":false},{\"item\":{\"name\":\"sugar\"},\"marked\":false},{\"item\":{\"name\":\"eggs\"},\"marked\":true},{\"item\":{\"name\":\"watermelon\"},\"marked\":true}]");

        File.WriteAllBytes("grocery_list.json", b);

        Storage.ReadGroceryList();

        var was_marked = Storage.groceryList.Find(n => n.item.name == "oranges").marked;

        var _ = Grocery.GroceryListMark("oranges");

        Assert.Equal(!was_marked, Storage.groceryList.Find(n => n.item.name == "oranges").marked);
    }

    [Fact]
    public void GroceryListDelete_Test()
    {
        byte[] b = Encoding.ASCII.GetBytes("[{\"item\":{\"name\":\"oranges\"},\"marked\":false},{\"item\":{\"name\":\"sugar\"},\"marked\":false},{\"item\":{\"name\":\"eggs\"},\"marked\":true},{\"item\":{\"name\":\"watermelon\"},\"marked\":true}]");

        File.WriteAllBytes("grocery_list.json", b);

        Storage.ReadGroceryList();

        var original_count = Storage.groceryList.Count;

        var _ = Grocery.GroceryListDelete("oranges");

        Assert.Equal(original_count - 1, Storage.groceryList.Count);
    }

    [Fact]
    public void GroceryListClear_Test()
    {
        byte[] b = Encoding.ASCII.GetBytes("[{\"item\":{\"name\":\"oranges\"},\"marked\":false},{\"item\":{\"name\":\"sugar\"},\"marked\":false},{\"item\":{\"name\":\"eggs\"},\"marked\":true},{\"item\":{\"name\":\"watermelon\"},\"marked\":true}]");

        File.WriteAllBytes("ingredients.json", b);

        Storage.ReadGroceryList();

        var _ = Grocery.GroceryListClear();

        foreach(var item in Storage.groceryList)
        {
            if(item.marked == true)
            {
                Assert.True(false);
            }
        }
        
        Assert.True(true);
    }
}
