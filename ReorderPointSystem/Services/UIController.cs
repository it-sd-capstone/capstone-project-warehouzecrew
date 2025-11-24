using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using ReorderPointSystem.Data;
using ReorderPointSystem.Models;

namespace ReorderPointSystem.Services
{
    internal class UIController
    {
        private InventoryManager _inventoryManager;

        public UIController(InventoryManager inventoryManager)
        {
            _inventoryManager = inventoryManager;
        }

        public List<Item> LoadItems()
        {
            
            List<Item> items = new List<Item>();

            using var conn = Database.GetConnection();
            string sqlQuery = "SELECT * FROM items";
            SQLiteCommand cmd = new SQLiteCommand(sqlQuery, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            try
            {
                while (reader.Read())
                {
                    int id = reader.GetInt16(reader.GetOrdinal("id"));
                    int categoryID = reader.GetInt16(reader.GetOrdinal("category_id"));
                    string name = reader.GetString(reader.GetOrdinal("name"));
                    string description = reader.GetString(reader.GetOrdinal("description"));
                    int currAmt = reader.GetInt16(reader.GetOrdinal("current_amount"));
                    int reorderPt = reader.GetInt16(reader.GetOrdinal("reorder_point"));
                    int maxAmt = reader.GetInt16(reader.GetOrdinal("max_amount"));
                    String created = reader.GetString(reader.GetOrdinal("created_at")).ToString();
                    String updated = reader.GetString(reader.GetOrdinal("updated_at")).ToString();
                    Item item = new Item(id, categoryID, name, description, currAmt, reorderPt, maxAmt);
                    DateTime result;
                    DateTime.TryParse(created, out result);
                    item.CreatedAt = result;
                    DateTime.TryParse(updated, out result);
                    item.LastUpdatedAt = result;
                    items.Add(item);
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show("Data Loading Error", ex.Message);
            }
            cmd.Dispose();
            conn.Close();

            return items;
        }

        public List<String> LoadOrders()
        {
            List<string> orders = new List<string>();


            return orders;
        }


        public void AddNewItem(Item item)
        {

        }

        public void UpdateExistingItem(Item item)
        {

        }

        public void DeleteItem(int itemID) 
        { 
        
        }

        public List<Item> SearchItems(string name)
        {
            SQLiteConnection conn = Database.GetConnection();
            String sqlSearchStr = "SELECT * FROM items WHERE name LIKE '%" + name + "%'";
            SQLiteCommand cmd = new SQLiteCommand(sqlSearchStr, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<Item> items = new List<Item>();

            while (reader.Read())
            {
                int id = reader.GetInt16(reader.GetOrdinal("id"));
                int categoryID = reader.GetInt16(reader.GetOrdinal("category_id"));
                string itemName = reader.GetString(reader.GetOrdinal("name"));
                string description = reader.GetString(reader.GetOrdinal("description"));
                int currAmt = reader.GetInt16(reader.GetOrdinal("current_amount"));
                int reorderPt = reader.GetInt16(reader.GetOrdinal("reorder_point"));
                int maxAmt = reader.GetInt16(reader.GetOrdinal("max_amount"));
                String created = reader.GetString(reader.GetOrdinal("created_at")).ToString();
                String updated = reader.GetString(reader.GetOrdinal("updated_at")).ToString();
                Item item = new Item(id, categoryID, itemName, description, currAmt, reorderPt, maxAmt);
                DateTime result;
                DateTime.TryParse(created, out result);
                item.CreatedAt = result;
                DateTime.TryParse(updated, out result);
                item.LastUpdatedAt = result;
                items.Add(item);
            }
            reader.Close();
            conn.Close();
            cmd.Dispose();
            return items;
        }

        public List<Item> ProcessLowStockReorders(List<Item> itemsIn)
        {
            List<Item> itemsOut = new List<Item>();
            foreach (Item item in itemsIn) 
            { 
                if (item.ReorderPoint > item.CurrentAmount)
                {
                    itemsOut.Add(item);
                }
            }
            return itemsOut;
        }

    }
}
