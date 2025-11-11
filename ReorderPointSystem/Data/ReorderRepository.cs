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
        public static List<Reorder> GetAll()
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM reorders";

            List<Reorder> reorders = new List<Reorder>();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                Reorder reorderEntry = new Reorder()
                {
                    Id = reader.GetInt32(0),
                    ItemId = reader.GetInt32(1),
                    Quantity = reader.GetInt32(2),
                    Status = reader.GetString(3),
                    CreatedAt = reader.GetDateTime(4),
                };
                reorders.Add(reorderEntry);
            }

            return reorders;
        }

        public static Reorder? GetById(int id)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM reorders WHERE id = @Id";
            command.Parameters.AddWithValue("@Id", id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Reorder()
                {
                    Id = reader.GetInt32(0),
                    ItemId = reader.GetInt32(1),
                    Quantity = reader.GetInt32(2),
                    Status = reader.GetString(3),
                    CreatedAt = reader.GetDateTime(4)
                };
            }
            return null; // Not found
        }

        public static int Add(Reorder reorderEntry)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO reorders (
                    item_id,
                    quantity,
                    status,
                    created_at
                ) VALUES (
                    @ItemId,
                    @Quantity,
                    @Status,
                    @CreatedAt
                );

                SELECT last_insert_rowid();
                ";
            command.Parameters.AddWithValue("@ItemId", reorderEntry.ItemId);
            command.Parameters.AddWithValue("@Quantity", reorderEntry.Quantity);
            command.Parameters.AddWithValue("@Status", reorderEntry.Status);
            command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

            // Returns id of the newly created reorder
            int newReorderId = (int) command.ExecuteScalar();
            return newReorderId;
        }

        public static bool Update(Reorder reorderEntry)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = @"
                UPDATE
                    item_id = @ItemId
                    quantity = @Quantity
                    status = @Status
                WHERE
                    id = @Id";
            command.Parameters.AddWithValue("@ItemId", reorderEntry.ItemId);
            command.Parameters.AddWithValue("@Quantity", reorderEntry.Quantity);
            command.Parameters.AddWithValue("@Status", reorderEntry.Status);
            command.Parameters.AddWithValue("@Id", reorderEntry.Id);

            // Returns true if successful
            int affectedRows = command.ExecuteNonQuery();
            return affectedRows > 0;
        }

        public static bool Delete(int reorderId)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = @"DELETE FROM reorders WHERE id = @Id";
            command.Parameters.AddWithValue("@Id", reorderId);
            
            // Returns true if successful
            int affectedRows = command.ExecuteNonQuery();
            return affectedRows > 0;
        }
    }
}
