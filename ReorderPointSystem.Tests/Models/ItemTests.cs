using ReorderPointSystem.Data;
using ReorderPointSystem.Models;

namespace ReorderPointSystem.Tests.Models
{
    public class ItemTests
    {
        [Fact]
        public void CreateAndUpdateItem()
        {
            Database.Initialize();
            Item item = new Item(0, 0, "test item", "this is a test item used for testing purposes", 300, 400, 800);
            ItemRepository repo = new ItemRepository();
            repo.Add(item);
            Assert.True(item.NeedsReorder());
            item.AddStock(50);
            Assert.True(repo.GetById(item.Id).CurrentAmount == 350);
            item.RemoveStock(30);
            Assert.True(repo.GetById(item.Id).CurrentAmount == 320);
            item.UpdateStock(330);
            Assert.True(repo.GetById(item.Id).CurrentAmount == 330);
        }
    }
}
