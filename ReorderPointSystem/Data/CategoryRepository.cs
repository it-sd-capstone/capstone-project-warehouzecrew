using System;
using System.Collections.Generic;
using System.Data.SQLite;
using ReorderPointSystem.Models;

namespace ReorderPointSystem.Data
{
    internal class CategoryRepository
    {
        public List<Category> GetAll()
        {
            var categories = new List<Category>();

            using var connection = Database.GetConnection();
            using var command = new SQLiteCommand("SELECT id, name FROM categories WHERE NOT is_deleted ORDER BY name;", connection);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                categories.Add(new Category
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }

            return categories;
        }

        public Category? GetById(int id)
        {
            using var connection = Database.GetConnection();
            using var command = new SQLiteCommand("SELECT * FROM categories WHERE id = @id;", connection);
            command.Parameters.AddWithValue("@id", id);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Category
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    IsDeleted = reader.GetBoolean(2)
                };
            }

            return null;
        }

        public Category Add(Category category)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            // Check if a category with the same name already exists
            command.CommandText = "SELECT COUNT(*) FROM categories WHERE name = @name;";
            command.Parameters.AddWithValue("@name", category.Name);

            long count = (long)command.ExecuteScalar();
            if (count > 0)
            {
                return null;
            }

            // Insert the new category
            command.CommandText = "INSERT INTO categories (name) VALUES (@name); SELECT last_insert_rowid();";
            command.Parameters.AddWithValue("@name", category.Name);

            long insertedId = (long)command.ExecuteScalar();
            return new Category
            {
                Id = (int)insertedId,
                Name = category.Name
            };
        }

        public bool Update(Category category)
        {
            using var connection = Database.GetConnection();
            using var command = new SQLiteCommand(
                "UPDATE categories SET name = @name WHERE id = @id;",
                connection);

            command.Parameters.AddWithValue("@name", category.Name);
            command.Parameters.AddWithValue("@id", category.Id);

            return command.ExecuteNonQuery() > 0;
        }

        public bool Delete(int categoryId)
        {
            using var connection = Database.GetConnection();
            using var command = connection.CreateCommand();

            // Check if any items are associated with this category
            command.CommandText = "SELECT COUNT(*) FROM items WHERE category_id = @id AND NOT is_deleted";
            command.Parameters.AddWithValue("@id", categoryId);
            long itemCount = (long)command.ExecuteScalar();
            if (itemCount > 0)
            {
                // Cannot delete category with associated items
                throw new InvalidOperationException();
            }

            // Mark the category as deleted
            command.CommandText = "UPDATE categories SET is_deleted = 1 WHERE id = @id;";
            command.Parameters.AddWithValue("@id", categoryId);

            return command.ExecuteNonQuery() > 0;
        }
    }
}
