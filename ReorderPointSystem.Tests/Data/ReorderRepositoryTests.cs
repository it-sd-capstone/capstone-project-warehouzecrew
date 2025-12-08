using ReorderPointSystem.Data;
using ReorderPointSystem.Models;
using ReorderPointSystem.Services;

namespace ReorderPointSystem.Tests.Data
{
    public class ReorderRepositoryTests : TestBase
    {
        // Helper method to add sample items for testing
        private void AddSampleItems()
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO items (
                    category_id, name, description, current_amount,
                    reorder_point, max_amount, reorder_enabled, created_at, updated_at
                ) VALUES 
                    (1, 'TestItem1', 'Description1', 5, 10, 15, 1, '2024-01-01', '2024-01-01'),
                    (1, 'TestItem2', 'Description2', 3, 8, 12, 0, '2024-01-01', '2024-01-01'),
                    (1, 'TestItem3', 'Description3', 2, 6, 10, 1, '2024-01-01', '2024-01-01');
            ";
            command.ExecuteNonQuery();
        }

        [Fact]
        public void Add_ShouldInsertReorderAndReturnWithGeneratedId()
        {
            // Arrange
            AddSampleItems();
            var repo = new ReorderRepository();
            var reorder = new Reorder(
                items: new List<ReorderItem>
                {
                    new ReorderItem { ItemId = 1, Quantity = 10 },
                    new ReorderItem { ItemId = 2, Quantity = 5 }
                },
                status: "Pending approval"
            );

            // Act
            var result = repo.Add(reorder);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Id > 0, "Generated ID should be greater than 0");
            Assert.Equal("Pending approval", result.Status);
            Assert.NotEqual(DateTime.MinValue, result.CreatedAt);
        }

        [Fact]
        public void Add_ShouldPersistReorderToDatabase()
        {
            // Arrange
            AddSampleItems();
            var repo = new ReorderRepository();
            var reorder = new Reorder(
                items: new List<ReorderItem>
                {
                    new ReorderItem { ItemId = 1, Quantity = 20 }
                },
                status: "In process"
            );

            // Act
            var result = repo.Add(reorder);

            // Assert - Verify reorder exists in database
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT id, status, created_at FROM reorders WHERE id = @Id";
            command.Parameters.AddWithValue("@Id", result.Id);

            using var reader = command.ExecuteReader();
            Assert.True(reader.Read(), "Reorder should exist in database");
            Assert.Equal(result.Id, reader.GetInt32(0));
            Assert.Equal("In process", reader.GetString(1));
        }

        [Fact]
        public void Add_ShouldInsertAllReorderItems()
        {
            // Arrange
            AddSampleItems();
            var repo = new ReorderRepository();
            var reorder = new Reorder(
                items: new List<ReorderItem>
                {
                    new ReorderItem { ItemId = 1, Quantity = 15 },
                    new ReorderItem { ItemId = 2, Quantity = 25 },
                    new ReorderItem { ItemId = 3, Quantity = 30 }
                }
            );

            // Act
            var result = repo.Add(reorder);

            // Assert - Verify all items exist in database
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT item_id, quantity 
                FROM reorder_items 
                WHERE reorder_id = @ReorderId
                ORDER BY item_id
            ";
            command.Parameters.AddWithValue("@ReorderId", result.Id);

            using var reader = command.ExecuteReader();

            // First item
            Assert.True(reader.Read());
            Assert.Equal(1, reader.GetInt32(0));
            Assert.Equal(15, reader.GetInt32(1));

            // Second item
            Assert.True(reader.Read());
            Assert.Equal(2, reader.GetInt32(0));
            Assert.Equal(25, reader.GetInt32(1));

            // Third item
            Assert.True(reader.Read());
            Assert.Equal(3, reader.GetInt32(0));
            Assert.Equal(30, reader.GetInt32(1));

            // No more items
            Assert.False(reader.Read());
        }

        [Fact]
        public void Add_WithEmptyItemsList_ShouldInsertReorderOnly()
        {
            // Arrange
            var repo = new ReorderRepository();
            var reorder = new Reorder(
                items: new List<ReorderItem>(),
                status: "Pending approval"
            );

            // Act
            var result = repo.Add(reorder);

            // Assert
            Assert.True(result.Id > 0);

            // Verify no items in database
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM reorder_items WHERE reorder_id = @ReorderId";
            command.Parameters.AddWithValue("@ReorderId", result.Id);

            var count = Convert.ToInt32(command.ExecuteScalar());
            Assert.Equal(0, count);
        }

        [Fact]
        public void Add_ShouldUseDefaultStatusWhenNotSpecified()
        {
            // Arrange
            AddSampleItems();
            var repo = new ReorderRepository();
            var reorder = new Reorder
            {
                Items = new List<ReorderItem>
                {
                    new ReorderItem { ItemId = 1, Quantity = 5 }
                }
            };

            // Act
            var result = repo.Add(reorder);

            // Assert
            Assert.Equal("Pending approval", result.Status);

            // Verify in database
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT status FROM reorders WHERE id = @Id";
            command.Parameters.AddWithValue("@Id", result.Id);

            var status = command.ExecuteScalar() as string;
            Assert.Equal("Pending approval", status);
        }

        [Fact]
        public void Add_ShouldSetCreatedAtToCurrentTime()
        {
            // Arrange
            AddSampleItems();
            var beforeAdd = GlobalDate.GetUpdatedDate().ToLocalTime();
            var repo = new ReorderRepository();
            var reorder = new Reorder(new List<ReorderItem>
            {
                new ReorderItem { ItemId = 1, Quantity = 5 }
            });

            // Act
            var result = repo.Add(reorder);
            var afterAdd = GlobalDate.GetUpdatedDate().ToLocalTime();

            // Assert
            Assert.InRange(result.CreatedAt, beforeAdd.AddSeconds(-1), afterAdd.AddSeconds(1));
        }

        [Fact]
        public void GetAll_ShouldReturnReorderList_WhenReordersExist()
        {
            // Arrange
            AddSampleItems();
            var repo = new ReorderRepository();
            var reorder1 = repo.Add(new Reorder(
                new List<ReorderItem> { new ReorderItem { ItemId = 1, Quantity = 5 } }
            ));
            var reorder2 = repo.Add(new Reorder(
                new List<ReorderItem> { new ReorderItem { ItemId = 2, Quantity = 10 } }
            ));

            // Act
            var results = repo.GetAll();

            // Assert
            Assert.NotNull(results);
            Assert.Equal(2, results.Count);
            Assert.Contains(results, r => r.Id == reorder1.Id);
            Assert.Contains(results, r => r.Id == reorder2.Id);
        }

        [Fact]
        public void GetAll_ShouldReturnEmptyList_WhenNoReordersExist()
        {
            // Arrange
            var repo = new ReorderRepository();

            // Act
            var results = repo.GetAll();

            // Assert
            Assert.NotNull(results);
            Assert.Empty(results);
        }

        [Fact]
        public void GetAll_ShouldNotIncludeItemsForEachReorder()
        {
            // Arrange
            // Note: GetAll() does NOT return items per reorder for performance reasons
            // Use GetById() to retrieve items for a specific reorder
            AddSampleItems();
            var repo = new ReorderRepository();
            var reorder1 = repo.Add(new Reorder(
                new List<ReorderItem>
                {
                    new ReorderItem { ItemId = 1, Quantity = 5 },
                    new ReorderItem { ItemId = 2, Quantity = 10 }
                }
            ));
            var reorder2 = repo.Add(new Reorder(
                new List<ReorderItem>
                {
                    new ReorderItem { ItemId = 3, Quantity = 15 }
                }
            ));

            // Act
            var results = repo.GetAll();

            // Assert
            var firstReorder = results.First(r => r.Id == reorder1.Id);
            var secondReorder = results.First(r => r.Id == reorder2.Id);

            // GetAll() returns reorders without items for performance
            Assert.Empty(firstReorder.Items);
            Assert.Empty(secondReorder.Items);
        }

        [Fact]
        public void GetAll_ShouldReturnCorrectReorderProperties()
        {
            // Arrange
            AddSampleItems();
            var repo = new ReorderRepository();
            var originalReorder = repo.Add(new Reorder(
                new List<ReorderItem> { new ReorderItem { ItemId = 1, Quantity = 5 } },
                "Complete"
            ));

            // Act
            var results = repo.GetAll();

            // Assert
            var retrievedReorder = results.First();
            Assert.Equal(originalReorder.Id, retrievedReorder.Id);
            Assert.Equal("Complete", retrievedReorder.Status);
            Assert.Equal(originalReorder.CreatedAt.ToString(), retrievedReorder.CreatedAt.ToString());
        }

        [Fact]
        public void GetById_ShouldReturnReorder_WhenReorderExists()
        {
            // Arrange
            AddSampleItems();
            var repo = new ReorderRepository();
            var addedReorder = repo.Add(new Reorder(
                new List<ReorderItem> { new ReorderItem { ItemId = 1, Quantity = 5 } }
            ));

            // Act
            var result = repo.GetById(addedReorder.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(addedReorder.Id, result.Id);
            Assert.Equal(addedReorder.Status, result.Status);
        }

        [Fact]
        public void GetById_ShouldReturnNull_WhenReorderDoesNotExist()
        {
            // Arrange
            var repo = new ReorderRepository();

            // Act
            var result = repo.GetById(999);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetById_ShouldIncludeAllReorderItems()
        {
            // Arrange
            AddSampleItems();
            var repo = new ReorderRepository();
            var addedReorder = repo.Add(new Reorder(
                new List<ReorderItem>
                {
                    new ReorderItem { ItemId = 1, Quantity = 5 },
                    new ReorderItem { ItemId = 2, Quantity = 10 },
                    new ReorderItem { ItemId = 3, Quantity = 15 }
                }
            ));

            // Act
            var result = repo.GetById(addedReorder.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Items.Count);
            Assert.Contains(result.Items, i => i.ItemId == 1 && i.Quantity == 5);
            Assert.Contains(result.Items, i => i.ItemId == 2 && i.Quantity == 10);
            Assert.Contains(result.Items, i => i.ItemId == 3 && i.Quantity == 15);
        }

        [Fact]
        public void GetById_ShouldReturnReorderWithEmptyItems_WhenNoItemsExist()
        {
            // Arrange
            AddSampleItems();
            var repo = new ReorderRepository();
            var addedReorder = repo.Add(new Reorder(new List<ReorderItem>()));

            // Act
            var result = repo.GetById(addedReorder.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result.Items);
        }

        [Fact]
        public void Update_ShouldReturnTrue_WhenReorderExists()
        {
            // Arrange
            AddSampleItems();
            var repo = new ReorderRepository();
            var reorder = repo.Add(new Reorder(
                new List<ReorderItem> { new ReorderItem { ItemId = 1, Quantity = 5 } }
            ));

            // Act
            reorder.MarkComplete();
            var result = repo.Update(reorder);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Update_ShouldReturnFalse_WhenReorderDoesNotExist()
        {
            // Arrange
            var repo = new ReorderRepository();
            var reorder = new Reorder(
                id: 999,
                items: new List<ReorderItem>(),
                status: "Complete",
                createdAt: GlobalDate.GetUpdatedDate()
            );

            // Act
            var result = repo.Update(reorder);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Update_ShouldModifyStatusInDatabase()
        {
            // Arrange
            AddSampleItems();
            var repo = new ReorderRepository();
            var reorder = repo.Add(new Reorder(
                new List<ReorderItem> { new ReorderItem { ItemId = 1, Quantity = 5 } },
                "Pending approval"
            ));

            // Act
            reorder.MarkInProcess();
            repo.Update(reorder);

            // Assert - Verify status changed in database
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT status FROM reorders WHERE id = @Id";
            command.Parameters.AddWithValue("@Id", reorder.Id);

            var status = command.ExecuteScalar() as string;
            Assert.Equal("In process", status);
        }

        [Fact]
        public void Update_ShouldNotModifyOtherFields()
        {
            // Arrange
            AddSampleItems();
            var repo = new ReorderRepository();
            var reorder = repo.Add(new Reorder(
                new List<ReorderItem> { new ReorderItem { ItemId = 1, Quantity = 5 } },
                "Pending approval"
            ));
            var originalCreatedAt = reorder.CreatedAt;

            // Act
            reorder.MarkComplete();
            repo.Update(reorder);

            // Assert - Verify CreatedAt hasn't changed
            var updated = repo.GetById(reorder.Id);
            Assert.NotNull(updated);
            Assert.Equal(originalCreatedAt.ToString(), updated.CreatedAt.ToString());
        }

        [Fact]
        public void Update_WithMarkComplete_ShouldSetStatusToComplete()
        {
            // Arrange
            AddSampleItems();
            var repo = new ReorderRepository();
            var reorder = repo.Add(new Reorder(
                new List<ReorderItem> { new ReorderItem { ItemId = 1, Quantity = 5 } }
            ));

            // Act
            reorder.MarkComplete();
            repo.Update(reorder);

            // Assert
            var updated = repo.GetById(reorder.Id);
            Assert.Equal("Complete", updated.Status);
        }

        [Fact]
        public void Update_WithMarkCancelled_ShouldSetStatusToCancelled()
        {
            // Arrange
            AddSampleItems();
            var repo = new ReorderRepository();
            var reorder = repo.Add(new Reorder(
                new List<ReorderItem> { new ReorderItem { ItemId = 1, Quantity = 5 } }
            ));

            // Act
            reorder.MarkCancelled();
            repo.Update(reorder);

            // Assert
            var updated = repo.GetById(reorder.Id);
            Assert.Equal("Cancelled", updated.Status);
        }

        [Fact]
        public void Delete_ShouldReturnTrue_WhenReorderExists()
        {
            // Arrange
            AddSampleItems();
            var repo = new ReorderRepository();
            var reorder = repo.Add(new Reorder(
                new List<ReorderItem> { new ReorderItem { ItemId = 1, Quantity = 5 } }
            ));

            // Act
            var result = repo.Delete(reorder.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Delete_ShouldReturnFalse_WhenReorderDoesNotExist()
        {
            // Arrange
            var repo = new ReorderRepository();

            // Act
            var result = repo.Delete(999);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Delete_ShouldRemoveReorderFromDatabase()
        {
            // Arrange
            AddSampleItems();
            var repo = new ReorderRepository();
            var reorder = repo.Add(new Reorder(
                new List<ReorderItem> { new ReorderItem { ItemId = 1, Quantity = 5 } }
            ));

            // Act
            repo.Delete(reorder.Id);

            // Assert - Verify reorder no longer exists
            var result = repo.GetById(reorder.Id);
            Assert.Null(result);
        }

        [Fact]
        public void Delete_ShouldRemoveAllAssociatedReorderItems()
        {
            // Arrange
            AddSampleItems();
            var repo = new ReorderRepository();
            var reorder = repo.Add(new Reorder(
                new List<ReorderItem>
                {
                    new ReorderItem { ItemId = 1, Quantity = 5 },
                    new ReorderItem { ItemId = 2, Quantity = 10 },
                    new ReorderItem { ItemId = 3, Quantity = 15 }
                }
            ));

            // Act
            repo.Delete(reorder.Id);

            // Assert - Verify no items remain in reorder_items table
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM reorder_items WHERE reorder_id = @ReorderId";
            command.Parameters.AddWithValue("@ReorderId", reorder.Id);

            var count = Convert.ToInt32(command.ExecuteScalar());
            Assert.Equal(0, count);
        }

        [Fact]
        public void Delete_ShouldNotAffectOtherReorders()
        {
            // Arrange
            AddSampleItems();
            var repo = new ReorderRepository();
            var reorder1 = repo.Add(new Reorder(
                new List<ReorderItem> { new ReorderItem { ItemId = 1, Quantity = 5 } }
            ));
            var reorder2 = repo.Add(new Reorder(
                new List<ReorderItem> { new ReorderItem { ItemId = 2, Quantity = 10 } }
            ));

            // Act
            repo.Delete(reorder1.Id);

            // Assert - Verify reorder2 still exists
            var remaining = repo.GetById(reorder2.Id);
            Assert.NotNull(remaining);
            Assert.Equal(reorder2.Id, remaining.Id);
        }

        [Fact]
        public void Delete_ShouldUseTransaction_ToEnsureAtomicity()
        {
            // Arrange
            AddSampleItems();
            var repo = new ReorderRepository();
            var reorder = repo.Add(new Reorder(
                new List<ReorderItem> { new ReorderItem { ItemId = 1, Quantity = 5 } }
            ));

            // Act
            repo.Delete(reorder.Id);

            // Assert - Both reorder and items should be deleted
            using var connection = Database.GetConnection();

            // Check reorder
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM reorders WHERE id = @Id";
                command.Parameters.AddWithValue("@Id", reorder.Id);
                Assert.Equal(0, Convert.ToInt32(command.ExecuteScalar()));
            }

            // Check reorder items
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT COUNT(*) FROM reorder_items WHERE reorder_id = @Id";
                command.Parameters.AddWithValue("@Id", reorder.Id);
                Assert.Equal(0, Convert.ToInt32(command.ExecuteScalar()));
            }
        }
    }
}