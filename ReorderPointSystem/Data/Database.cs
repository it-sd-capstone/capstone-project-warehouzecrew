using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReorderPointSystem.Data
{
    internal static class Database
    {
        private static string dbFilePath = "rps.db";
        private static string connectionString = $"Data Source={dbFilePath};Version=3;";

        public static void SetTestDatabase(string testDbFilePath)
        {
            dbFilePath = testDbFilePath;
            connectionString = $"Data Source={dbFilePath};Version=3;New=True;";
        }

        public static SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(connectionString);
            connection.Open();
            return connection;
        }

        public static void Initialize()
        {
            if (!System.IO.File.Exists(dbFilePath))
            {
                Debug.WriteLine("Database file not found. Creating new database");
                SQLiteConnection.CreateFile(dbFilePath);
                CreateTables();
                Debug.WriteLine("Database and tables created successfully.");
            }
        }

        private static void CreateTables()
        {
            using var connection = GetConnection();
            string createTablesQuery = @"
                CREATE TABLE IF NOT EXISTS categories (
	                id	    INTEGER NOT NULL UNIQUE,
	                name	TEXT NOT NULL,
	                PRIMARY KEY(id AUTOINCREMENT)
                );
                CREATE TABLE IF NOT EXISTS inventory_logs (
	                id	            INTEGER NOT NULL UNIQUE,
	                item_id	        INTEGER NOT NULL,
	                quantity_change	INTEGER NOT NULL,
	                type	        TEXT NOT NULL,
	                created_at	    TEXT NOT NULL,
	                PRIMARY KEY(id AUTOINCREMENT),
	                FOREIGN KEY(item_id) REFERENCES items(id)
                );
                CREATE TABLE IF NOT EXISTS items (
	                id	            INTEGER NOT NULL UNIQUE,
	                category_id	    INTEGER NOT NULL,
	                name	        TEXT NOT NULL,
	                description	    TEXT,
	                current_amount	INTEGER NOT NULL,
	                reorder_point	INTEGER NOT NULL,
	                max_amount	    INTEGER NOT NULL,
	                created_at	    TEXT,
	                updated_at	    TEXT,
	                PRIMARY KEY(id AUTOINCREMENT),
	                FOREIGN KEY(category_id) REFERENCES categories(id)
                );
                CREATE TABLE IF NOT EXISTS reorders (
	                id	INTEGER NOT NULL UNIQUE,
	                status	TEXT NOT NULL,
	                created_at	TEXT NOT NULL,
	                PRIMARY KEY(id AUTOINCREMENT)
                );
                CREATE TABLE IF NOT EXISTS reorder_items (
	                reorder_id	INTEGER NOT NULL,
	                item_id	INTEGER NOT NULL,
	                quantity	INTEGER NOT NULL,
	                PRIMARY KEY(reorder_id,item_id),
                    FOREIGN KEY(reorder_id) REFERENCES reorders(id),
                    FOREIGN KEY(item_id) REFERENCES items(id)
                );
                INSERT INTO categories (name)
                SELECT 'General'
                WHERE NOT EXISTS (SELECT 1 FROM Categories);
            ";

            using var command = new SQLiteCommand(createTablesQuery, connection);
            command.ExecuteNonQuery();
        }
    }
}
