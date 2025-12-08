using System.Data;
using System.Data.SQLite;
using ReorderPointSystem.Models;
using ReorderPointSystem.Services;

namespace ReorderPointSystem.Data
{
    internal class ItemRepository
    {
        public List<Item> GetAll()
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM items WHERE NOT is_deleted";

            List<Item> items = new List<Item>();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                items.Add(MapReaderToItem(reader));
            }

            return items;
        }

        public List<Item> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<Item>();

            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM items WHERE Name LIKE @searchTerm AND NOT is_deleted";
            command.Parameters.AddWithValue("@searchTerm", $"%{searchTerm}%");

            List<Item> items = new List<Item>();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                items.Add(MapReaderToItem(reader));
            }
            return items;
        }

        public Item? GetById(int id)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM items WHERE id = @Id";
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (!reader.Read()) return null;
            return MapReaderToItem(reader);
        }

        public Item Add(Item item, bool ignoreLog = false)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO items (category_id, name, description, current_amount, reorder_point, max_amount, reorder_enabled, is_deleted, created_at, updated_at)
                VALUES (@CategoryId, @Name, @Description, @CurrentAmount, @ReorderPoint, @MaxAmount, @ReorderEnabled, 0, @CreatedAt, @LastUpdatedAt);

                SELECT last_insert_rowid();
            ";

            var currentDateTime = GlobalDate.date;
            command.Parameters.AddWithValue("@CategoryId", item.CategoryId);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Description", item.Description);
            command.Parameters.AddWithValue("@CurrentAmount", item.CurrentAmount);
            command.Parameters.AddWithValue("@ReorderPoint", item.ReorderPoint);
            command.Parameters.AddWithValue("@MaxAmount", item.MaxAmount);
            command.Parameters.AddWithValue("@ReorderEnabled", item.ReorderEnabled);
            command.Parameters.AddWithValue("@CreatedAt", currentDateTime);
            command.Parameters.AddWithValue("@LastUpdatedAt", currentDateTime);

            int newId = Convert.ToInt32(command.ExecuteScalar());
            
            if (!ignoreLog)
            {
                InventoryLogRepository logRepository = new InventoryLogRepository();
                InventoryLog newLog = new InventoryLog(newId, item.CurrentAmount, "Item created");
                logRepository.Add(newLog);
            }

            return new Item
            {
                Id = newId,
                CategoryId = item.CategoryId,
                Name = item.Name,
                Description = item.Description,
                CurrentAmount = item.CurrentAmount,
                ReorderPoint = item.ReorderPoint,
                MaxAmount = item.MaxAmount,
                ReorderEnabled = item.ReorderEnabled,
                CreatedAt = currentDateTime,
                LastUpdatedAt = currentDateTime
            };
        }

        public bool Update(Item item, bool ignoreLog = false)
        {
            if (item.IsDeleted) return false;

            int previousQuantity = 0;
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            // Get previous quantity for inventory log
            if (!ignoreLog)
            {
                command.CommandText = @"
                    SELECT current_amount
                    FROM items
                    WHERE id = @Id
                ";
                command.Parameters.AddWithValue("@Id", item.Id);

                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    previousQuantity = reader.GetInt32(0);
                }
            }

            command.CommandText = @"
                UPDATE items
                SET category_id = @CategoryId,
                    name = @Name,
                    description = @Description,
                    current_amount = @CurrentAmount,
                    reorder_point = @ReorderPoint,
                    max_amount = @MaxAmount,
                    reorder_enabled = @ReorderEnabled,
                    updated_at = @LastUpdatedAt
                WHERE id = @Id;
            ";
            var currentDateTime = GlobalDate.date;
            command.Parameters.AddWithValue("@CategoryId", item.CategoryId);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Description", item.Description);
            command.Parameters.AddWithValue("@CurrentAmount", item.CurrentAmount);
            command.Parameters.AddWithValue("@ReorderPoint", item.ReorderPoint);
            command.Parameters.AddWithValue("@MaxAmount", item.MaxAmount);
            command.Parameters.AddWithValue("@ReorderEnabled", item.ReorderEnabled);
            command.Parameters.AddWithValue("@LastUpdatedAt", currentDateTime);
            command.Parameters.AddWithValue("@Id", item.Id);

            bool result = command.ExecuteNonQuery() > 0;

            // Add inventory log
            if (!ignoreLog)
            {
                InventoryLogRepository logRepository = new InventoryLogRepository();
                InventoryLog newLog = new InventoryLog(item.Id, item.CurrentAmount - previousQuantity, "Item updated");
                logRepository.Add(newLog);
            }

            // Returns true if successful
            return result;
        }

        public bool Delete(int id)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = "UPDATE items SET is_deleted = 1 WHERE id = @Id";
            command.Parameters.AddWithValue("@Id", id);

            // Returns true if successful
            return command.ExecuteNonQuery() > 0;
        }

        public Item MapReaderToItem(SQLiteDataReader reader)
        {
            Item item = new Item();
            item.Id = reader.GetInt32(0);
            item.CategoryId = reader.GetInt32(1);
            item.Name = reader.GetString(2);
            item.Description = reader.GetString(3);
            item.CurrentAmount = reader.GetInt32(4);
            item.ReorderPoint = reader.GetInt32(5);
            item.MaxAmount = reader.GetInt32(6);
            item.ReorderEnabled = reader.GetBoolean(7);
            item.IsDeleted = reader.GetBoolean(8);
            item.CreatedAt = reader.GetDateTime(9);
            item.LastUpdatedAt = reader.GetDateTime(10);
            return item;
        }
    }
}
