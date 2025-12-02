using ReorderPointSystem.Models;
namespace ReorderPointSystem.Tests.Models
{
    public class ItemTests
    {
        public static Item GenerateTestItem()
        {
            return new Item()
            {
                Id = 1,
                CategoryId = 1,
                Name = "TestName",
                Description = "TestDesc",
                CurrentAmount = 5,
                ReorderPoint = 10,
                MaxAmount = 15,
                CreatedAt = DateTime.Now,
                LastUpdatedAt = DateTime.Now,
            };
        }

        [Fact]
        public void NeedsReorder_WhenCurrentAmountBelowReorderPoint_ReturnsTrue()
        {
            // Arrange
            var item = GenerateTestItem();
            item.CurrentAmount = 5;
            item.ReorderPoint = 10;

            // Act
            var result = item.NeedsReorder();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void NeedsReorder_WhenCurrentAmountEqualsReorderPoint_ReturnsFalse()
        {
            // Arrange
            var item = GenerateTestItem();
            item.CurrentAmount = 10;
            item.ReorderPoint = 10;

            // Act
            var result = item.NeedsReorder();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void NeedsReorder_WhenCurrentAmountAboveReorderPoint_ReturnsFalse()
        {
            // Arrange
            var item = GenerateTestItem();
            item.CurrentAmount = 15;
            item.ReorderPoint = 10;

            // Act
            var result = item.NeedsReorder();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void NeedsReorder_WhenCurrentAmountIsZero_ReturnsTrue()
        {
            // Arrange
            var item = GenerateTestItem();
            item.CurrentAmount = 0;
            item.ReorderPoint = 10;

            // Act
            var result = item.NeedsReorder();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void AddStock_WithPositiveAmount_IncreasesCurrentAmount()
        {
            // Arrange
            var item = GenerateTestItem();
            item.CurrentAmount = 5;

            // Act
            var result = item.AddStock(10);

            // Assert
            Assert.Equal(15, result);
            Assert.Equal(15, item.CurrentAmount);
        }

        [Fact]
        public void AddStock_WithZero_MaintainsCurrentAmount()
        {
            // Arrange
            var item = GenerateTestItem();
            item.CurrentAmount = 5;

            // Act
            var result = item.AddStock(0);

            // Assert
            Assert.Equal(5, result);
            Assert.Equal(5, item.CurrentAmount);
        }

        [Fact]
        public void AddStock_WithNegativeAmount_DecreasesCurrentAmount()
        {
            // Arrange
            var item = GenerateTestItem();
            item.CurrentAmount = 10;

            // Act
            var result = item.AddStock(-3);

            // Assert
            Assert.Equal(7, result);
            Assert.Equal(7, item.CurrentAmount);
        }

        [Fact]
        public void AddStock_ReturnsUpdatedCurrentAmount()
        {
            // Arrange
            var item = GenerateTestItem();
            item.CurrentAmount = 5;

            // Act
            var result = item.AddStock(7);

            // Assert
            Assert.Equal(item.CurrentAmount, result);
        }

        [Fact]
        public void RemoveStock_WithPositiveAmount_DecreasesCurrentAmount()
        {
            // Arrange
            var item = GenerateTestItem();
            item.CurrentAmount = 10;

            // Act
            var result = item.RemoveStock(3);

            // Assert
            Assert.Equal(7, result);
            Assert.Equal(7, item.CurrentAmount);
        }

        [Fact]
        public void RemoveStock_WithZero_MaintainsCurrentAmount()
        {
            // Arrange
            var item = GenerateTestItem();
            item.CurrentAmount = 10;

            // Act
            var result = item.RemoveStock(0);

            // Assert
            Assert.Equal(10, result);
            Assert.Equal(10, item.CurrentAmount);
        }

        [Fact]
        public void RemoveStock_WithAmountEqualToCurrentAmount_ResultsInZero()
        {
            // Arrange
            var item = GenerateTestItem();
            item.CurrentAmount = 10;

            // Act
            var result = item.RemoveStock(10);

            // Assert
            Assert.Equal(0, result);
            Assert.Equal(0, item.CurrentAmount);
        }

        [Fact]
        public void RemoveStock_WithAmountGreaterThanCurrentAmount_ResultsInNegative()
        {
            // Arrange
            var item = GenerateTestItem();
            item.CurrentAmount = 5;

            // Act
            var result = item.RemoveStock(10);

            // Assert
            Assert.Equal(-5, result);
            Assert.Equal(-5, item.CurrentAmount);
        }

        [Fact]
        public void RemoveStock_WithNegativeAmount_IncreasesCurrentAmount()
        {
            // Arrange
            var item = GenerateTestItem();
            item.CurrentAmount = 10;

            // Act
            var result = item.RemoveStock(-5);

            // Assert
            Assert.Equal(15, result);
            Assert.Equal(15, item.CurrentAmount);
        }

        [Fact]
        public void RemoveStock_ReturnsUpdatedCurrentAmount()
        {
            // Arrange
            var item = GenerateTestItem();
            item.CurrentAmount = 10;

            // Act
            var result = item.RemoveStock(3);

            // Assert
            Assert.Equal(item.CurrentAmount, result);
        }

        [Fact]
        public void UpdateStock_WithPositiveAmount_SetsCurrentAmount()
        {
            // Arrange
            var item = GenerateTestItem();
            item.CurrentAmount = 5;

            // Act
            var result = item.UpdateStock(20);

            // Assert
            Assert.Equal(20, result);
            Assert.Equal(20, item.CurrentAmount);
        }

        [Fact]
        public void UpdateStock_WithZero_SetsCurrentAmountToZero()
        {
            // Arrange
            var item = GenerateTestItem();
            item.CurrentAmount = 10;

            // Act
            var result = item.UpdateStock(0);

            // Assert
            Assert.Equal(0, result);
            Assert.Equal(0, item.CurrentAmount);
        }

        [Fact]
        public void UpdateStock_WithNegativeAmount_SetsCurrentAmountToNegative()
        {
            // Arrange
            var item = GenerateTestItem();
            item.CurrentAmount = 10;

            // Act
            var result = item.UpdateStock(-5);

            // Assert
            Assert.Equal(-5, result);
            Assert.Equal(-5, item.CurrentAmount);
        }

        [Fact]
        public void UpdateStock_ReplacesCurrentAmount_NotAddsToIt()
        {
            // Arrange
            var item = GenerateTestItem();
            item.CurrentAmount = 10;

            // Act
            var result = item.UpdateStock(5);

            // Assert
            Assert.Equal(5, result); // Should be 5, not 15
            Assert.Equal(5, item.CurrentAmount);
        }

        [Fact]
        public void UpdateStock_ReturnsUpdatedCurrentAmount()
        {
            // Arrange
            var item = GenerateTestItem();

            // Act
            var result = item.UpdateStock(100);

            // Assert
            Assert.Equal(item.CurrentAmount, result);
        }
    }
}