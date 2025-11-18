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
                    ItemId = reader.GetInt32(1),
                    Quantity = reader.GetInt32(2),
                    Status = reader.GetString(3),
                    CreatedAt = reader.GetDateTime(4)
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
                ItemId = reader.GetInt32(1),
                Quantity = reader.GetInt32(2),
                Status = reader.GetString(3),
                CreatedAt = reader.GetDateTime(4)
            };
        }

        public Reorder Add(Reorder reorderEntry)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO reorders (item_id, quantity, status, created_at)
                VALUES (@ItemId, @Quantity, @Status, @CreatedAt);

                SELECT last_insert_rowid();
            ";

            var createdAt = DateTime.Now;

            command.Parameters.AddWithValue("@ItemId", reorderEntry.ItemId);
            command.Parameters.AddWithValue("@Quantity", reorderEntry.Quantity);
            command.Parameters.AddWithValue("@Status", reorderEntry.Status);
            command.Parameters.AddWithValue("@CreatedAt", createdAt);

            int newId = Convert.ToInt32(command.ExecuteScalar());

            return new Reorder(
                newId,
                reorderEntry.ItemId,
                reorderEntry.Quantity,
                reorderEntry.Status,
                createdAt
            );
        }

        public bool Update(Reorder reorderEntry)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = @"
                UPDATE reorders
                SET item_id = @ItemId,
                    quantity = @Quantity,
                    status = @Status
                WHERE id = @Id;
            ";
            command.Parameters.AddWithValue("@ItemId", reorderEntry.ItemId);
            command.Parameters.AddWithValue("@Quantity", reorderEntry.Quantity);
            command.Parameters.AddWithValue("@Status", reorderEntry.Status);
            command.Parameters.AddWithValue("@Id", reorderEntry.Id);

            // Returns true if successful
            return command.ExecuteNonQuery() > 0;
        }

        public bool Delete(int reorderId)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM reorders WHERE id = @Id";
            command.Parameters.AddWithValue("@Id", reorderId);

            // Returns true if successful
            return command.ExecuteNonQuery() > 0;
        }
    }
}
