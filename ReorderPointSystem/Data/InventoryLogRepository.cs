using ReorderPointSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ReorderPointSystem.Data
{
    public class InventoryLogRepository
    {
        private readonly string _connectionString;

        public InventoryLogRepository(string connectionString)
        {
            SQLiteConnection.ClearAllPools();

            _connectionString = connectionString;

            CreateTableIfNotExists();
            EnsureTestSeedData();
        }

        private void CreateTableIfNotExists()
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            string sql = @"
                CREATE TABLE IF NOT EXISTS inventory_logs (
	                id	            INTEGER PRIMARY KEY AUTOINCREMENT,
	                item_id	        INTEGER NOT NULL,
	                quantity_change	INTEGER NOT NULL,
	                type	        TEXT NOT NULL,
	                created_at	    TEXT NOT NULL,
	                FOREIGN KEY(item_id) REFERENCES items(id)
                );";

            using var cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        private void EnsureTestSeedData()
        {
            if (!_connectionString.Contains("New=True"))
                return;

            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            // Insert required category
            using (var cmd = new SQLiteCommand(
                "INSERT INTO categories (name) VALUES ('TestCategory');", conn))
            {
                cmd.ExecuteNonQuery();
            }

            // Insert required item (id=1)
            using (var cmd = new SQLiteCommand(@"
                INSERT INTO items 
                    (category_id, name, description, current_amount, reorder_point, max_amount, created_at, updated_at)
                VALUES 
                    (1, 'Test Item', 'FK test item', 10, 5, 50, datetime('now'), datetime('now'));
            ", conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public int Add(InventoryLog log)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            string sql = @"
                INSERT INTO inventory_logs (item_id, quantity_change, type, created_at)
                VALUES (@item_id, @quantity_change, @type, @created_at);";

            using var cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.AddWithValue("@item_id", log.ItemId);
            cmd.Parameters.AddWithValue("@quantity_change", log.QuantityChange);
            cmd.Parameters.AddWithValue("@type", log.Type);
            cmd.Parameters.AddWithValue("@created_at", log.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"));

            cmd.ExecuteNonQuery();

            return (int)conn.LastInsertRowId;
        }

        public List<InventoryLog> GetAll()
        {
            var logs = new List<InventoryLog>();

            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            using var cmd = new SQLiteCommand("SELECT * FROM inventory_logs ORDER BY created_at DESC", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
                logs.Add(MapReader(reader));

            return logs;
        }

        public InventoryLog? GetById(int id)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            using var cmd = new SQLiteCommand("SELECT * FROM inventory_logs WHERE id=@id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
                return MapReader(reader);

            return null;
        }

        private static InventoryLog MapReader(SQLiteDataReader r)
        {
            return new InventoryLog
            {
                Id = Convert.ToInt32(r["id"]),
                ItemId = Convert.ToInt32(r["item_id"]),
                QuantityChange = Convert.ToInt32(r["quantity_change"]),
                Type = r["type"].ToString() ?? "",
                CreatedAt = DateTime.Parse(r["created_at"].ToString() ?? DateTime.Now.ToString())
            };
        }
    }
}
