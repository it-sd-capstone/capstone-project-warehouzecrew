using ReorderPointSystem.Models;

namespace ReorderPointSystem.Tests.Models
{
    public class ReorderTests
    {
        [Fact]
        public void MarkInProcess_ShouldSetStatusToInProcess_WhenCalled()
        {
            // Arrange
            Reorder newOrder = new Reorder();

            // Act
            newOrder.MarkInProcess();

            // Assert
            Assert.Equal("In process", newOrder.Status);
        }

        [Fact]
        public void MarkComplete_ShouldSetStatusToComplete_WhenCalled()
        {
            // Arrange
            Reorder newOrder = new Reorder();

            // Act
            newOrder.MarkComplete();

            // Assert
            Assert.Equal("Complete", newOrder.Status);
        }

        [Fact]
        public void MarkCancelled_ShouldSetStatusToCancelled_WhenCalled()
        {
            // Arrange
            Reorder newOrder = new Reorder();

            // Act
            newOrder.MarkCancelled();

            // Assert
            Assert.Equal("Cancelled", newOrder.Status);
        }
    }
}
