using System.Data.SQLite;
using ReorderPointSystem.Data;

namespace ReorderPointSystem.Tests.Data
{
    public class DatabaseTests : TestBase
    {
        [Fact]
        public void GetConnection_ReturnsOpenConnection()
        {
            // Arrange
            Database.Initialize();

            // Act
            using var connection = Database.GetConnection();

            // Assert
            Assert.NotNull(connection);
            Assert.Equal(System.Data.ConnectionState.Open, connection.State);
        }

        [Fact]
        public void Initialize_CreatesDatabaseFileAndTables()
        {
            // Act
            Database.Initialize();

            // Assert
            Assert.True(System.IO.File.Exists(TestDbFilePath), "Database file was not created.");
            using var connection = Database.GetConnection();
            using var command = new SQLiteCommand("SELECT name FROM sqlite_master WHERE type='table';", connection);
            using var reader = command.ExecuteReader();
            var tables = new HashSet<string>();
            while (reader.Read())
            {
                tables.Add(reader.GetString(0));
            }
            Assert.Contains("categories", tables);
            Assert.Contains("inventory_logs", tables);
            Assert.Contains("items", tables);
            Assert.Contains("reorders", tables);
        }
    }
}
