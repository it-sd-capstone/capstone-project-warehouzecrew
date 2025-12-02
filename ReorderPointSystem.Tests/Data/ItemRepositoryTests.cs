using ReorderPointSystem.Data;
using ReorderPointSystem.Models;

namespace ReorderPointSystem.Tests.Data
{
    public class ItemRepositoryTests : TestBase
    {
        // Helper method
        private void AddSampleData()
        {
            using var connection = Database.GetConnection();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                INSERT INTO categories
                    (name) VALUES ('TestCategory');

                INSERT INTO items (
                    category_id,
                    name,
                    description,
                    current_amount,
                    reorder_point,
                    max_amount,
                    created_at,
                    updated_at
                ) VALUES (
                    1,
                    'TestItem',
                    'TestDescription',
                    10,
                    5,
                    50,
                    datetime('now'),
                    datetime('now')
                );

                INSERT INTO items (
                    category_id,
                    name,
                    description,
                    current_amount,
                    reorder_point,
                    max_amount,
                    created_at,
                    updated_at
                ) VALUES (
                    1,
                    'AnotherItem',
                    'AnotherDescription',
                    20,
                    10,
                    100,
                    datetime('now'),
                    datetime('now')
                );";
                command.ExecuteNonQuery();
            }
        }

        private Item CreateTestItem(string name = "TestItem")
        {
            return new Item
            {
                CategoryId = 1,
                Name = name,
                Description = "Test Description",
                CurrentAmount = 10,
                ReorderPoint = 5,
                MaxAmount = 50
            };
        }

        [Fact]
        public void GetAll_ShouldReturnItemList_WhenAnyItemDoesExist()
        {
            // Arrange
            AddSampleData();
            var repo = new ItemRepository();

            // Act
            List<Item> results = repo.GetAll();

            // Assert
            Assert.NotNull(results);
            Assert.Equal(2, results.Count);
        }

        [Fact]
        public void GetAll_ShouldReturnEmptyList_WhenNoItemsExist()
        {
            // Arrange
            var repo = new ItemRepository();

            // Act
            List<Item> results = repo.GetAll();

            // Assert
            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public void GetAll_ShouldReturnItemsWithAllProperties()
        {
            // Arrange
            AddSampleData();
            var repo = new ItemRepository();

            // Act
            List<Item> results = repo.GetAll();

            // Assert
            Item item = results.First();
            Assert.True(item.Id > 0);
            Assert.Equal(1, item.CategoryId);
            Assert.Equal("TestItem", item.Name);
            Assert.Equal("TestDescription", item.Description);
            Assert.Equal(10, item.CurrentAmount);
            Assert.Equal(5, item.ReorderPoint);
            Assert.Equal(50, item.MaxAmount);
        }

        [Fact]
        public void Search_ShouldReturnEmptyList_WhenSearchTermIsNull()
        {
            // Arrange
            var repo = new ItemRepository();

            // Act
            List<Item> results = repo.Search(null);

            // Assert
            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public void Search_ShouldReturnEmptyList_WhenSearchTermIsEmpty()
        {
            // Arrange
            var repo = new ItemRepository();

            // Act
            List<Item> results = repo.Search("");

            // Assert
            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public void Search_ShouldReturnEmptyList_WhenSearchTermIsWhitespace()
        {
            // Arrange
            var repo = new ItemRepository();

            // Act
            List<Item> results = repo.Search("   ");

            // Assert
            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public void Search_ShouldReturnMatchingItem_WhenExactMatchExists()
        {
            // Arrange
            AddSampleData();
            var repo = new ItemRepository();

            // Act
            List<Item> results = repo.Search("TestItem");

            // Assert
            Assert.NotNull(results);
            Assert.Single(results);
            Assert.Equal("TestItem", results[0].Name);
        }

        [Fact]
        public void Search_ShouldReturnMatchingItems_WhenPartialMatchExists()
        {
            // Arrange
            AddSampleData();
            var repo = new ItemRepository();

            // Act
            List<Item> results = repo.Search("Item");

            // Assert
            Assert.NotNull(results);
            Assert.Equal(2, results.Count);
        }

        [Fact]
        public void Search_ShouldBeCaseInsensitive()
        {
            // Arrange
            AddSampleData();
            var repo = new ItemRepository();

            // Act
            List<Item> resultsLower = repo.Search("testitem");
            List<Item> resultsUpper = repo.Search("TESTITEM");

            // Assert
            Assert.Single(resultsLower);
            Assert.Single(resultsUpper);
        }

        [Fact]
        public void Search_ShouldReturnEmptyList_WhenNoMatchesExist()
        {
            // Arrange
            AddSampleData();
            var repo = new ItemRepository();

            // Act
            List<Item> results = repo.Search("NonExistent");

            // Assert
            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public void GetById_ShouldReturnItem_WhenItemDoesExist()
        {
            // Arrange
            AddSampleData();
            var repo = new ItemRepository();
            Item addedItem = repo.Add(CreateTestItem("UniqueItem"));

            // Act
            Item? result = repo.GetById(addedItem.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(addedItem.Id, result.Id);
            Assert.Equal("UniqueItem", result.Name);
        }

        [Fact]
        public void GetById_ShouldReturnNull_WhenItemDoesNotExist()
        {
            // Arrange
            var repo = new ItemRepository();

            // Act
            Item? result = repo.GetById(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void Add_ShouldReturnNewItem()
        {
            // Arrange
            AddSampleData();
            var repo = new ItemRepository();
            Item item = CreateTestItem();

            // Act
            Item result = repo.Add(item);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Id > 0);
        }

        [Fact]
        public void Add_ShouldSetCreatedAtAndLastUpdatedAt()
        {
            // Arrange
            AddSampleData();
            var repo = new ItemRepository();
            Item item = CreateTestItem();
            DateTime beforeAdd = DateTime.Now.AddSeconds(-1);

            // Act
            Item result = repo.Add(item);
            DateTime afterAdd = DateTime.Now.AddSeconds(1);

            // Assert
            Assert.InRange(result.CreatedAt, beforeAdd, afterAdd);
            Assert.InRange(result.LastUpdatedAt, beforeAdd, afterAdd);
        }

        [Fact]
        public void Add_ShouldPreserveAllProperties()
        {
            // Arrange
            AddSampleData();
            var repo = new ItemRepository();
            Item item = CreateTestItem();

            // Act
            Item result = repo.Add(item);

            // Assert
            Assert.Equal(item.CategoryId, result.CategoryId);
            Assert.Equal(item.Name, result.Name);
            Assert.Equal(item.Description, result.Description);
            Assert.Equal(item.CurrentAmount, result.CurrentAmount);
            Assert.Equal(item.ReorderPoint, result.ReorderPoint);
            Assert.Equal(item.MaxAmount, result.MaxAmount);
        }

        [Fact]
        public void Add_ShouldGenerateUniqueIds_ForMultipleItems()
        {
            // Arrange
            AddSampleData();
            var repo = new ItemRepository();
            Item item1 = CreateTestItem("Item1");
            Item item2 = CreateTestItem("Item2");

            // Act
            Item result1 = repo.Add(item1);
            Item result2 = repo.Add(item2);

            // Assert
            Assert.NotEqual(result1.Id, result2.Id);
        }

        [Fact]
        public void Add_ShouldAllowItemToBeRetrieved()
        {
            // Arrange
            AddSampleData();
            var repo = new ItemRepository();
            Item item = CreateTestItem();

            // Act
            Item addedItem = repo.Add(item);
            Item? retrievedItem = repo.GetById(addedItem.Id);

            // Assert
            Assert.NotNull(retrievedItem);
            Assert.Equal(addedItem.Id, retrievedItem.Id);
            Assert.Equal(addedItem.Name, retrievedItem.Name);
        }

        [Fact]
        public void Update_ShouldReturnTrue_WhenItemDoesExist()
        {
            // Arrange
            AddSampleData();
            var repo = new ItemRepository();
            Item item = repo.Add(CreateTestItem());
            item.Name = "Updated Name";

            // Act
            bool result = repo.Update(item);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Update_ShouldReturnFalse_WhenItemDoesNotExist()
        {
            // Arrange
            var repo = new ItemRepository();
            Item item = CreateTestItem();
            item.Id = 999;

            // Act
            bool result = repo.Update(item);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Update_ShouldUpdateAllProperties()
        {
            // Arrange
            AddSampleData();
            var repo = new ItemRepository();
            Item item = repo.Add(CreateTestItem());
            int originalId = item.Id;

            item.CategoryId = 1;
            item.Name = "Updated Name";
            item.Description = "Updated Description";
            item.CurrentAmount = 20;
            item.ReorderPoint = 10;
            item.MaxAmount = 100;

            // Act
            repo.Update(item);
            Item? updatedItem = repo.GetById(originalId);

            // Assert
            Assert.NotNull(updatedItem);
            Assert.Equal(1, updatedItem.CategoryId);
            Assert.Equal("Updated Name", updatedItem.Name);
            Assert.Equal("Updated Description", updatedItem.Description);
            Assert.Equal(20, updatedItem.CurrentAmount);
            Assert.Equal(10, updatedItem.ReorderPoint);
            Assert.Equal(100, updatedItem.MaxAmount);
        }

        [Fact]
        public void Delete_ShouldReturnTrue_WhenItemDoesExist()
        {
            // Arrange
            AddSampleData();
            var repo = new ItemRepository();
            Item item = repo.Add(CreateTestItem());

            // Act
            bool result = repo.Delete(item.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Delete_ShouldReturnFalse_WhenItemDoesNotExist()
        {
            // Arrange
            var repo = new ItemRepository();

            // Act
            bool result = repo.Delete(999);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Delete_ShouldRemoveItemFromDatabase()
        {
            // Arrange
            AddSampleData();
            var repo = new ItemRepository();
            Item item = repo.Add(CreateTestItem());

            // Act
            repo.Delete(item.Id);
            Item? deletedItem = repo.GetById(item.Id);

            // Assert
            Assert.Null(deletedItem);
        }

        [Fact]
        public void Delete_ShouldNotAffectOtherItems()
        {
            // Arrange
            AddSampleData();
            var repo = new ItemRepository();
            Item item1 = repo.Add(CreateTestItem("Item1"));
            Item item2 = repo.Add(CreateTestItem("Item2"));

            // Act
            repo.Delete(item1.Id);
            Item? remainingItem = repo.GetById(item2.Id);

            // Assert
            Assert.NotNull(remainingItem);
            Assert.Equal("Item2", remainingItem.Name);
        }
    }
}