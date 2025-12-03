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
                    bool reorderEnabled = reader.GetBoolean(reader.GetOrdinal("reorder_enabled"));
                    Item item = new Item(id, categoryID, name, description, currAmt, reorderPt, maxAmt, reorderEnabled);
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

            /*
            ItemRepository repository = new ItemRepository();
            items = repository.GetAll();
            */
            return items;
        }

        public List<Reorder> LoadOrders()
        {
            List<Reorder> orders = new List<Reorder>();
            orders = _inventoryManager.GetReorderRepository().GetAll();
            return orders;
        }

        // Inventory list sorting function
        public List<Item> SortItems(List<Item> items, string sortCriteria)
        {
            switch (sortCriteria)
            {
                case "Alphabetical (A to Z)":
                    return items.OrderBy(i => i.Name).ToList();

                case "Alphabetical (Z to A)":
                    return items.OrderByDescending(i => i.Name).ToList();

                case "Quantity (Low to High)":
                    return items.OrderBy(i => i.CurrentAmount).ToList();

                case "Quantity (High to Low)":
                    return items.OrderByDescending(i => i.CurrentAmount).ToList();

                case "Date Added (Newest)":
                    return items.OrderByDescending(i => i.CreatedAt).ToList();

                case "Date Added (Oldest)":
                    return items.OrderBy(i => i.CreatedAt).ToList();

                default:
                    return items;
            }
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
                bool reorderEnabled = reader.GetBoolean(reader.GetOrdinal("reorder_enabled"));
                Item item = new Item(id, categoryID, itemName, description, currAmt, reorderPt, maxAmt, reorderEnabled);
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

        public List<Item> ProcessLowStockReorders(List<Item> itemsIn, List<Reorder> reorders)
        {
            List<Item> itemsOut = new List<Item>();
            foreach (Item item in itemsIn) 
            { 
                if (item.NeedsReorder())
                {
                    List<Reorder> matchedOrders = reorders.FindAll(x => findMatchedId(x, item));
                    bool onOrder = false;
                    foreach (Reorder reorder in matchedOrders)
                    {
                        if (reorder.Status.Equals("In process") || reorder.Status.Equals("Pending approval"))
                        {
                            onOrder = true;
                        }
                    }
                    if (!onOrder)
                    {
                        itemsOut.Add(item);
                    }
                }
            }
            return itemsOut;
        }

        public InventoryManager GetInventoryManager()
        {
            return _inventoryManager;
        }

        private bool findMatchedId(Reorder o, Item item)
        {
            // Alan 12/2/2025
            // Please refactor. Reorder.ItemId no longer exists and instead lives inside
            // Reorder.Items which is a list of ReorderItem which includes ItemId.

            //if (o.ItemId == item.Id)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return false;
        }
    }
}
