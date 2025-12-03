using System.Data.SQLite;
using ReorderPointSystem.Models;

namespace ReorderPointSystem.Data
{
    internal class ItemRepository
    {
        public List<Item> GetAll()
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM items";

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
            command.CommandText = "SELECT * FROM items WHERE Name LIKE @searchTerm";
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

        public Item Add(Item item)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO items (category_id, name, description, current_amount, reorder_point, max_amount, reorder_enabled, created_at, updated_at)
                VALUES (@CategoryId, @Name, @Description, @CurrentAmount, @ReorderPoint, @MaxAmount, @ReorderEnabled, @CreatedAt, @LastUpdatedAt);

                SELECT last_insert_rowid();
            ";

            var currentDateTime = DateTime.Now;
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

        public bool Update(Item item)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
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
            var currentDateTime = DateTime.Now;
            command.Parameters.AddWithValue("@CategoryId", item.CategoryId);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Description", item.Description);
            command.Parameters.AddWithValue("@CurrentAmount", item.CurrentAmount);
            command.Parameters.AddWithValue("@ReorderPoint", item.ReorderPoint);
            command.Parameters.AddWithValue("@MaxAmount", item.MaxAmount);
            command.Parameters.AddWithValue("@ReorderEnabled", item.ReorderEnabled);
            command.Parameters.AddWithValue("@LastUpdatedAt", currentDateTime);
            command.Parameters.AddWithValue("@Id", item.Id);

            // Returns true if successful
            return command.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM items WHERE id = @Id";
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
            item.CreatedAt = reader.GetDateTime(8);
            item.LastUpdatedAt = reader.GetDateTime(9);
            return item;
        }
    }
}
