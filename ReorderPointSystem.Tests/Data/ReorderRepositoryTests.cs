using ReorderPointSystem.Data;
using ReorderPointSystem.Models;

namespace ReorderPointSystem.Tests.Data
{
    public class ReorderRepositoryTests : TestBase
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
                    5,
                    10,
                    15,
                    'Created date',
                    'Updated date'
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
                    'TestItem2',
                    'TestDescription2',
                    1,
                    2,
                    3,
                    'Created date2',
                    'Updated date2'
                )";
                command.ExecuteNonQuery();
            }
        }

        [Fact]
        public void Add_ShouldReturnNewEntry()
        {
            // Arrange
            AddSampleData();
            var repo = new ReorderRepository();
            Reorder reorder = new Reorder(1, 5);

            // Act
            Reorder result = repo.Add(reorder);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Id > 0);
        }

        [Fact]
        public void Update_ShouldReturnTrue_WhenEntryDoesExist()
        {
            // Arrange
            AddSampleData();
            var repo = new ReorderRepository();
            Reorder reorder = repo.Add(new Reorder(1, 5));

            // Act
            bool result = repo.Update(reorder);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Update_ShouldReturnFalse_WhenEntryDoesNotExist()
        {
            // Arrange
            var repo = new ReorderRepository();
            Reorder reorder = new Reorder(1, 5);

            // Act
            bool result = repo.Update(reorder);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Delete_ShouldReturnTrue_WhenEntryDoesExist()
        {
            // Arrange
            AddSampleData();
            var repo = new ReorderRepository();
            Reorder reorder = repo.Add(new Reorder(1, 5));

            // Act
            bool result = repo.Delete(reorder.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Delete_ShouldReturnFalse_WhenEntryDoesNotExist()
        {
            // Arrange
            var repo = new ReorderRepository();

            // Act
            bool result = repo.Delete(5);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetById_ShouldReturnReorder_WhenEntryDoesExist()
        {
            // Arrange
            AddSampleData();
            var repo = new ReorderRepository();
            Reorder reorder = repo.Add(new Reorder(1, 5));

            // Act
            Reorder? result = repo.GetById(reorder.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(reorder.Id, result.Id);
        }

        [Fact]
        public void GetById_ShouldReturnNull_WhenEntryDoesNotExist()
        {
            // Arrange
            var repo = new ReorderRepository();

            // Act
            Reorder? result = repo.GetById(8);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetAll_ShouldReturnReorderList_WhenAnyEntryDoesExist()
        {
            // Arrange
            AddSampleData();
            var repo = new ReorderRepository();
            Reorder reorder1 = repo.Add(new Reorder(1, 5));
            Reorder reorder2 = repo.Add(new Reorder(1, 2));

            // Act
            List<Reorder> results = repo.GetAll();

            // Assert
            Assert.NotNull(results);
            Assert.Equal(2, results.Count);
        }

        [Fact]
        public void GetAll_ShouldReturnEmptyList_WhenAnyEntryDoesNotExist()
        {
            // Arrange
            var repo = new ReorderRepository();

            // Act
            List<Reorder> results = repo.GetAll();

            // Assert
            Assert.NotNull(results);
            Assert.Empty(results);
        }
    }
}
