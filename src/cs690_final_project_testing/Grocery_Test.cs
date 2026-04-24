namespace cs690_final_project_testing;

using System.Text;

using cs690_final_project_source;

public class Grocery_Test
{
    [Collection("Sequential")]
    public void GroceryListAdd_Test()
    {
        // Write empty json list object to grocery_list.json
        byte[] b = Encoding.ASCII.GetBytes("[]");
        File.WriteAllBytes("grocery_list.json", b);

        // Load file data into Storage.groceryList
        Storage.ReadGroceryList();

        // Add item to grocery list
        var _ = Grocery.GroceryListAdd("eggs");

        // Make sure that item exists
        Assert.Equal("eggs", Storage.groceryList[0].item.name);
    }

    [Collection("Sequential")]
    public void GroceryListMark_Test()
    {
        // Write file data
        byte[] b = Encoding.ASCII.GetBytes("[{\"item\":{\"name\":\"oranges\"},\"marked\":false},{\"item\":{\"name\":\"sugar\"},\"marked\":false},{\"item\":{\"name\":\"eggs\"},\"marked\":true},{\"item\":{\"name\":\"watermelon\"},\"marked\":true}]");
        File.WriteAllBytes("grocery_list.json", b);

        // Load file data into Storage.groceryList
        Storage.ReadGroceryList();

        // Store whether or not oranges are marked
        var was_marked = Storage.groceryList.Find(n => n.item.name == "oranges").marked;

        // Mark oranges on our list
        var _ = Grocery.GroceryListMark("oranges");

        // Compare
        Assert.Equal(!was_marked, Storage.groceryList.Find(n => n.item.name == "oranges").marked);
    }

    [Collection("Sequential")]
    public void GroceryListDelete_Test()
    {
        // Write file data
        byte[] b = Encoding.ASCII.GetBytes("[{\"item\":{\"name\":\"oranges\"},\"marked\":false},{\"item\":{\"name\":\"sugar\"},\"marked\":false},{\"item\":{\"name\":\"eggs\"},\"marked\":true},{\"item\":{\"name\":\"watermelon\"},\"marked\":true}]");
        File.WriteAllBytes("grocery_list.json", b);

        // Load file data into Storage.groceryList
        Storage.ReadGroceryList();

        // Save the original number of items in Storage.groceryList
        var original_count = Storage.groceryList.Count;

        // Delete an item, then compare to see if the count has changed
        var _ = Grocery.GroceryListDelete("oranges");

        Assert.Equal(original_count - 1, Storage.groceryList.Count);
    }

    [Collection("Sequential")]
    public void GroceryListClear_Test()
    {
        // Write file data
        byte[] b = Encoding.ASCII.GetBytes("[{\"item\":{\"name\":\"oranges\"},\"marked\":false},{\"item\":{\"name\":\"sugar\"},\"marked\":false},{\"item\":{\"name\":\"eggs\"},\"marked\":true},{\"item\":{\"name\":\"watermelon\"},\"marked\":true}]");
        File.WriteAllBytes("grocery_list.json", b);

        // Load file data into Storage.groceryList
        Storage.ReadGroceryList();

        // Clear all marked items
        var _ = Grocery.GroceryListClear();

        // Make sure there are no marked items left
        foreach(var item in Storage.groceryList)
        {
            if(item.marked == true)
            {
                Assert.True(false); // Fail if a marked item is found
            }
        }
        
        Assert.True(true);
    }
}
