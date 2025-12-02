using ReorderPointSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ReorderPointSystem.Data
{
    public class InventoryLogRepository
    {
        public InventoryLog Add(InventoryLog log)
        {
            using var conn = Database.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO inventory_logs (item_id, quantity_change, type, created_at)
                VALUES (@item_id, @quantity_change, @type, @created_at);
                
                SELECT last_insert_rowid();
            ";

            var currentDateTime = DateTime.Now;
            cmd.Parameters.AddWithValue("@item_id", log.ItemId);
            cmd.Parameters.AddWithValue("@quantity_change", log.QuantityChange);
            cmd.Parameters.AddWithValue("@type", log.Type);
            cmd.Parameters.AddWithValue("@created_at", currentDateTime);

            int newId = Convert.ToInt32(cmd.ExecuteScalar());
            return new InventoryLog
            {
                Id = newId,
                ItemId = log.ItemId,
                QuantityChange = log.QuantityChange,
                Type = log.Type,
                CreatedAt = currentDateTime
            };
        }

        public List<InventoryLog> GetAll()
        {
            var logs = new List<InventoryLog>();

            using var conn = Database.GetConnection();
            using var cmd = new SQLiteCommand("SELECT * FROM inventory_logs ORDER BY created_at DESC", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
                logs.Add(MapReader(reader));

            return logs;
        }

        public InventoryLog? GetById(int id)
        {
            using var conn = Database.GetConnection();
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
