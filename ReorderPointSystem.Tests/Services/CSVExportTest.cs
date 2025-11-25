using System;
using System.Collections.Generic;
using ReorderPointSystem.Models;
using ReorderPointSystem.Services;
using Xunit;

namespace ReorderPointSystem.Tests.Services
{
    public class CSVExportTests
    {
        // ---------------------------------------------------------
        // ITEMS EXPORT
        // ---------------------------------------------------------
        [Fact]
        public void ExportItems_ShouldIncludeCorrectHeaders()
        {
            var csv = CSVExport.ExportItems(new List<Item>());

            Assert.StartsWith("Id,CategoryId,Name,Description,CurrentAmount,ReorderPoint,MaxAmount,CreatedAt,LastUpdatedAt", csv);
        }

        [Fact]
        public void ExportItems_ShouldExportItemRowsCorrectly()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Id = 1,
                    CategoryId = 2,
                    Name = "Hammer",
                    Description = "Heavy duty",
                    CurrentAmount = 10,
                    ReorderPoint = 5,
                    MaxAmount = 50,
                    CreatedAt = new DateTime(2024,1,1,10,0,0),
                    LastUpdatedAt = new DateTime(2024,1,1,12,0,0)
                }
            };

            var csv = CSVExport.ExportItems(items);

            Assert.Contains("1,2,Hammer,Heavy duty,10,5,50,2024-01-01 10:00:00,2024-01-01 12:00:00", csv);
        }

        // ---------------------------------------------------------
        // CATEGORY EXPORT
        // ---------------------------------------------------------
        [Fact]
        public void ExportCategories_ShouldIncludeCorrectHeaders()
        {
            var csv = CSVExport.ExportCategories(new List<Category>());

            Assert.StartsWith("Id,Name", csv);
        }

        [Fact]
        public void ExportCategories_ShouldExportCategoryRowsCorrectly()
        {
            var csv = CSVExport.ExportCategories(
                new List<Category> { new Category { Id = 1, Name = "Tools" } }
            );

            Assert.Contains("1,Tools", csv);
        }

        // ---------------------------------------------------------
        // REORDER EXPORT
        // ---------------------------------------------------------
        [Fact]
        public void ExportReorders_ShouldIncludeCorrectHeaders()
        {
            var csv = CSVExport.ExportReorders(new List<Reorder>());

            Assert.StartsWith("Id,ItemId,Quantity,Status,CreatedAt", csv);
        }

        [Fact]
        public void ExportReorders_ShouldExportRowsCorrectly()
        {
            var reorder = new Reorder
            {
                Id = 7,
                ItemId = 1,
                Quantity = 50,
                Status = "Pending",
                CreatedAt = new DateTime(2024, 1, 2, 9, 0, 0)
            };

            var csv = CSVExport.ExportReorders(new List<Reorder> { reorder });

            Assert.Contains("7,1,50,Pending,2024-01-02 09:00:00", csv);
        }

        // ---------------------------------------------------------
        // INVENTORY LOG EXPORT
        // ---------------------------------------------------------
        [Fact]
        public void ExportInventoryLogs_ShouldIncludeCorrectHeaders()
        {
            var csv = CSVExport.ExportInventoryLogs(new List<InventoryLog>());

            Assert.StartsWith("Id,ItemId,QuantityChange,Type,CreatedAt", csv);
        }

        [Fact]
        public void ExportInventoryLogs_ShouldExportRowsCorrectly()
        {
            var log = new InventoryLog
            {
                Id = 4,
                ItemId = 1,
                QuantityChange = -3,
                Type = "OUT",
                CreatedAt = new DateTime(2024, 1, 2, 15, 30, 0)
            };

            var csv = CSVExport.ExportInventoryLogs(new List<InventoryLog> { log });

            Assert.Contains("4,1,-3,OUT,2024-01-02 15:30:00", csv);
        }
    }
}
