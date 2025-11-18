using ReorderPointSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReorderPointSystem.Data
{
    internal class ItemRepository
    {
        public List<Item> GetAll()
        {
            string getAllQuery = @"select * from items";
            SQLiteConnection con = Database.GetConnection();
            using var query = new SQLiteCommand(getAllQuery, con);
            var reader = query.ExecuteReader();
            var items = new List<Item>();
            while (reader.Read())
            {
                items.Add(MapReaderToItem(reader));
            }
            con.Close();
            return items;
        }
        /// <summary><list type="table">
        /// <item>by default the searchString indicates that an items name should contain the given string</item>
        /// <item>if it starts with [@], it will trigger special cases, which can be stacked in any way one after the other, where all must be true for a given item to pass</item>
        /// <item>use "[@]name " for the rest of the search string until the next [@] to apply to the item name</item>
        /// <item>use "[@]desc " for the rest of the search string until the next [@] to apply to the item description</item>
        /// <item>use "[@]cat " for the rest of the search string until the next [@] to apply to the item category</item>
        /// <item>use "[@]above " for the rest of the search string until the next [@] to indicate the item should have more than that many items</item>
        /// <item>use "[@]below " for the rest of the search string until the next [@] to indicate the item should have less than that many items</item>
        /// <item>advanced example: "[@]cat 5[@]above 1700" returns all items in category 5 whos current stock is >= 1700</item>
        /// </list></summary>
        public List<Item> Search(string searchString)
        {
            List<Item> items = GetAll();
            List<Item> fromSearch = new List<Item>();
            List<string> searches = new List<string>();
            if (searchString.StartsWith("[@]"))
            {
                foreach (string s in searchString.Split("[@]"))
                {
                    switch (s.Split()[0])
                    {
                        case "name": searches.Add("N" + s.Substring(5)); break;
                        case "desc": searches.Add("D" + s.Substring(5)); break;
                        case "cat": searches.Add("C" + s.Substring(4)); break;
                        case "above": searches.Add("A" + s.Substring(6)); break;
                        case "below": searches.Add("B" + s.Substring(6)); break;
                    }
                }
            }
            else
            {
                searches.Add("N" + searchString);
            }
            foreach (var item in items)
            {
                bool valid = true;
                foreach (var search in searches)
                {
                    switch (search.Substring(0,1))
                    {
                        case "N": if (!item.Name.Contains(search.Substring(1))) { valid = false; } break;
                        case "D": if (!item.Description.Contains(search.Substring(1))) { valid = false; } break;
                        case "C": if (item.CategoryId != int.Parse(search.Substring(1))) { valid = false; } break;
                        case "A": if (item.CurrentAmount < int.Parse(search.Substring(1))) { valid = false; } break;
                        case "B": if (item.CurrentAmount > int.Parse(search.Substring(1))) { valid = false; } break;
                    }
                    if (!valid)
                    {
                        break;
                    }
                }
                if (valid)
                {
                    fromSearch.Add(item);
                }
            }
            return fromSearch;
        }
        public Item? GetById(int id)
        {
            var items = GetAll();
            foreach (var item in items)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
        public int Add(Item item)
        {
            string addCommand = @"insert into items (category_id, name, description, current_amount, reorder_point, max_amount, created_at, updated_at) 
values (@cat, @name, @desc, @current, @reorder, @max, @created, @updated)";
            SQLiteConnection con = Database.GetConnection();
            using var command = new SQLiteCommand(addCommand, con);
            command.Prepare();
            command.Parameters.AddWithValue("cat", item.CategoryId);
            command.Parameters.AddWithValue("name", item.Name);
            command.Parameters.AddWithValue("desc", item.Description);
            command.Parameters.AddWithValue("current", item.CurrentAmount);
            command.Parameters.AddWithValue("reorder", item.ReorderPoint);
            command.Parameters.AddWithValue("max", item.MaxAmount);
            command.Parameters.AddWithValue("created", item.CreatedAt);
            command.Parameters.AddWithValue("updated", item.LastUpdatedAt);
            int rows = command.ExecuteNonQuery();
            con.Close();
            return rows;
        }
        public void Update(Item item)
        {
            item.LastUpdatedAt = DateTime.Now;
            string updateCommand = @"update items category_id = '@cat', name = '@name', description = '@desc', current_amout = '@current'
, reorder_point = '@reorder', max_amount = '@max', created_at = '@created', updated_at = '@updated' where id = @id";
            SQLiteConnection con = Database.GetConnection();
            using var command = new SQLiteCommand(updateCommand, con);
            command.Prepare();
            command.Parameters.Add(item.CategoryId);
            command.Parameters.Add(item.Name);
            command.Parameters.Add(item.Description);
            command.Parameters.Add(item.CurrentAmount);
            command.Parameters.Add(item.ReorderPoint);
            command.Parameters.Add(item.MaxAmount);
            command.Parameters.Add(item.CreatedAt);
            command.Parameters.Add(item.LastUpdatedAt);
            int rows = command.ExecuteNonQuery();
            con.Close();
        }
        public void Delete(int id)
        {
            string deleteCommand = @"delete from items where id = " + id;
            SQLiteConnection con = Database.GetConnection();
            using var command = new SQLiteCommand(deleteCommand, con);
            command.ExecuteNonQuery();
            con.Close();
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
            item.CreatedAt = reader.GetDateTime(7);
            item.LastUpdatedAt = reader.GetDateTime(8);
            return item;
        }
    }
}
