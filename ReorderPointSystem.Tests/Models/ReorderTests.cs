using ReorderPointSystem.Models;

namespace ReorderPointSystem.Tests.Models
{
    public class ReorderTests
    {
        [Fact]
        public void MarkInProcess()
        {
            // Arrange
            Reorder newOrder = new Reorder(1, 1, 10);

            // Act
            newOrder.MarkInProcess();

            // Assert
            Assert.Equal("In process", newOrder.Status);
        }

        [Fact]
        public void MarkCompleted()
        {
            // Arrange
            Reorder newOrder = new Reorder(1, 1, 10);

            // Act
            newOrder.MarkCompleted();

            // Assert
            Assert.Equal("Complete", newOrder.Status);
        }
    }
}
