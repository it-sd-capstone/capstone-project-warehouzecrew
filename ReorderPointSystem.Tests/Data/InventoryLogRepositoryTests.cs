using ReorderPointSystem.Data;
using ReorderPointSystem.Models;
using ReorderPointSystem.Services;
using System.Data.SQLite;

namespace ReorderPointSystem.Tests.Data
{
    public class InventoryLogRepositoryTests : TestBase
    {
        private void SeedFakeItem()
        {
            using var conn = Database.GetConnection();
            using var cmd = new SQLiteCommand(
                @"INSERT INTO categories (name) VALUES ('TestCategory'); 
          INSERT INTO items (category_id, name, description, current_amount, reorder_point, reorder_enabled, max_amount, created_at, updated_at)
          VALUES (1, 'TestItem', 'Fake', 10, 5, 20, 1, datetime('now'), datetime('now'));",
                conn);
            cmd.ExecuteNonQuery();
        }

        // ------------------------------------------------------
        // Add() inserts correctly
        // ------------------------------------------------------
        [Fact]
        public void Add_ShouldInsertNewLog()
        {
            SeedFakeItem();
            var repo = new InventoryLogRepository();
            var log = new InventoryLog(1, 5, "IN");

            InventoryLog newLog = repo.Add(log);

            Assert.NotNull(newLog);
            Assert.Equal(1, newLog!.ItemId);
            Assert.Equal(5, newLog.QuantityChange);
            Assert.Equal("IN", newLog.Type);
        }

        // ------------------------------------------------------
        // GetById returns null when missing
        // ------------------------------------------------------
        [Fact]
        public void GetById_ShouldReturnNull_WhenNotFound()
        {
            SeedFakeItem();
            var repo = new InventoryLogRepository();

            var result = repo.GetById(9999);

            Assert.Null(result);
        }

        // ------------------------------------------------------
        // GetAll returns logs in descending time order
        // ------------------------------------------------------
        [Fact]
        public void GetAll_ShouldReturnAllLogs_InDescendingDateOrder()
        {
            SeedFakeItem();
            var repo = new InventoryLogRepository();

            repo.Add(new InventoryLog(1, -3, "OUT"));
            System.Threading.Thread.Sleep(20);
            repo.Add(new InventoryLog(1, 10, "IN"));

            var all = repo.GetAll();

            Assert.Equal(2, all.Count);
            Assert.True(all[0].CreatedAt >= all[1].CreatedAt);
        }

        // ------------------------------------------------------
        // Timestamp persisted
        // ------------------------------------------------------
        [Fact]
        public void Add_ShouldPersistCorrectTimestamp()
        {
            SeedFakeItem();
            var repo = new InventoryLogRepository();

            var before = GlobalDate.date;
            InventoryLog newLog = repo.Add(new InventoryLog(1, 7, "IN"));

            Assert.NotNull(newLog);

            // Allow 1 second timestamp drift due to SQLite string-based timestamps
            Assert.InRange(newLog!.CreatedAt,
                before.AddSeconds(-1),
                GlobalDate.date.AddSeconds(1));
        }

        // ------------------------------------------------------
        // Constructor should create table
        // ------------------------------------------------------
        [Fact]
        public void Constructor_ShouldCreateTableIfNotExists()
        {
            var repo = new InventoryLogRepository();
            var all = repo.GetAll();

            Assert.NotNull(all);
        }
    }
}
