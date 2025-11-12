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
            Reorder reorder = new Reorder(1, 5);

            // Act
            Reorder result = ReorderRepository.Add(reorder);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Id > 0);
        }

        [Fact]
        public void Update_ShouldReturnTrue_WhenEntryDoesExist()
        {
            // Arrange
            AddSampleData();
            Reorder reorder = ReorderRepository.Add(new Reorder(1, 5));

            // Act
            bool result = ReorderRepository.Update(reorder);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Update_ShouldReturnFalse_WhenEntryDoesNotExist()
        {
            // Arrange
            Reorder reorder = new Reorder(1, 5);

            // Act
            bool result = ReorderRepository.Update(reorder);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void Delete_ShouldReturnTrue_WhenEntryDoesExist()
        {
            // Arrange
            AddSampleData();
            Reorder reorder = ReorderRepository.Add(new Reorder(1, 5));

            // Act
            bool result = ReorderRepository.Delete(reorder.Id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Delete_ShouldReturnFalse_WhenEntryDoesNotExist()
        {
            // Act
            bool result = ReorderRepository.Delete(5);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetById_ShouldReturnReorder_WhenEntryDoesExist()
        {
            // Arrange
            AddSampleData();
            Reorder reorder = ReorderRepository.Add(new Reorder(1, 5));

            // Act
            Reorder? result = ReorderRepository.GetById(reorder.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(reorder.Id, result.Id);
        }

        [Fact]
        public void GetById_ShouldReturnNull_WhenEntryDoesNotExist()
        {
            // Act
            Reorder? result = ReorderRepository.GetById(8);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetAll_ShouldReturnReorderList_WhenAnyEntryDoesExist()
        {
            // Arrange
            AddSampleData();
            Reorder reorder1 = ReorderRepository.Add(new Reorder(1, 5));
            Reorder reorder2 = ReorderRepository.Add(new Reorder(1, 2));

            // Act
            List<Reorder> results = ReorderRepository.GetAll();

            // Assert
            Assert.NotNull(results);
            Assert.Equal(2, results.Count);
        }

        [Fact]
        public void GetAll_ShouldReturnEmptyList_WhenAnyEntryDoesNotExist()
        {
            // Act
            List<Reorder> results = ReorderRepository.GetAll();

            // Assert
            Assert.NotNull(results);
            Assert.Empty(results);
        }
    }
}
