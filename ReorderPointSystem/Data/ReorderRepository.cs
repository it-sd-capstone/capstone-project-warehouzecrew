using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReorderPointSystem.Models;

namespace ReorderPointSystem.Data
{
    internal class ReorderRepository
    {
        // Does NOT return a list of ReorderItem per Reorder!
        // This is for memory/performance reasons, if you want more details from a specific Reorder,
        // use GetById to get a list of reorder items.
        // Note: If we want this reverted, just uncomment line 32
        public List<Reorder> GetAll()
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM reorders";

            List<Reorder> reorders = new List<Reorder>();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                reorders.Add(new Reorder
                {
                    Id = reader.GetInt32(0),
                    Status = reader.GetString(1),
                    CreatedAt = reader.GetDateTime(2),
                    //Items = GetReorderItems(reader.GetInt32(0))
                });
            }

            return reorders;
        }

        public Reorder? GetById(int id)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM reorders WHERE id = @Id";
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (!reader.Read()) return null;

            return new Reorder
            {
                Id = reader.GetInt32(0),
                Status = reader.GetString(1),
                CreatedAt = reader.GetDateTime(2),
                Items = GetReorderItems(reader.GetInt32(0))
            };
        }

        private List<ReorderItem> GetReorderItems(int reorderId)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT 
                    ri.item_id,
                    ri.quantity,
                    i.name AS item_name
                FROM 
                    reorder_items ri
                JOIN 
                    items i ON ri.item_id = i.id
                WHERE 
                    ri.reorder_id = @ReorderId;
            ";
            command.Parameters.AddWithValue("@ReorderId", reorderId);

            List<ReorderItem> items = new List<ReorderItem>();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                items.Add(new ReorderItem
                {
                    ItemId = reader.GetInt32(0),
                    Quantity = reader.GetInt32(1),
                    Name = reader.GetString(2)
                });
            }
            return items;
        }

        public Reorder Add(Reorder reorderEntry)
        {
            using var connection = Database.GetConnection();

            // Create reorder entry
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"
                    INSERT INTO reorders (status, created_at)
                    VALUES (@Status, @CreatedAt);

                    SELECT last_insert_rowid();
                ";
                reorderEntry.CreatedAt = DateTime.UtcNow;
                command.Parameters.AddWithValue("@Status", reorderEntry.Status);
                command.Parameters.AddWithValue("@CreatedAt", reorderEntry.CreatedAt);

                reorderEntry.Id = Convert.ToInt32(command.ExecuteScalar());
            }
                
            // Create reorder item entries
            foreach (ReorderItem item in reorderEntry.Items)
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                        INSERT INTO reorder_items (reorder_id, item_id, quantity)
                        VALUES (@ReorderId, @ItemId, @Quantity);
                    ";
                    command.Parameters.AddWithValue("@ReorderId", reorderEntry.Id);
                    command.Parameters.AddWithValue("@ItemId", item.ItemId);
                    command.Parameters.AddWithValue("@Quantity", item.Quantity);

                    command.ExecuteNonQuery();
                }
            }

            return reorderEntry;
        }

        public bool Update(Reorder reorderEntry)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = @"
                UPDATE reorders
                SET status = @Status
                WHERE id = @Id;
            ";
            command.Parameters.AddWithValue("@Status", reorderEntry.Status);
            command.Parameters.AddWithValue("@Id", reorderEntry.Id);

            // Returns true if successful
            return command.ExecuteNonQuery() > 0;
        }

        public bool Delete(int reorderId)
        {
            using var connection = Database.GetConnection();
            using var transaction = connection.BeginTransaction();
            using var command = connection.CreateCommand();

            command.Transaction = transaction;
            command.CommandText = @"
                DELETE FROM reorder_items WHERE reorder_id = @Id;
                DELETE FROM reorders WHERE id = @Id;
            ";
            command.Parameters.AddWithValue("@Id", reorderId);

            int affected = command.ExecuteNonQuery();
            transaction.Commit();

            // Returns true if successful
            return affected > 0;
        }
    }
}
