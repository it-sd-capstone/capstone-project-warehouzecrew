using ReorderPointSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReorderPointSystem.Models
{
    internal class Item
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CurrentAmount { get; set; }
        public int ReorderPoint { get; set; }
        public int MaxAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
        public Item(int id, int categoryId, string name, string description, int currentAmount, int reorderPoint, int maxAmount)
        {
            Id = id;
            CategoryId = categoryId;
            Name = name;
            Description = description;
            CurrentAmount = currentAmount;
            ReorderPoint = reorderPoint;
            MaxAmount = maxAmount;
            CreatedAt = DateTime.Now;
            LastUpdatedAt = DateTime.Now;
        }
        public Item()
        {
            Id = -1;
            CategoryId = -1;
            Name = "";
            Description = "";
            CurrentAmount = -1;
            ReorderPoint = -1;
            MaxAmount = -1;
            CreatedAt = DateTime.Now;
            LastUpdatedAt = DateTime.Now;
        }
        public bool NeedsReorder()
        {
            return CurrentAmount <= ReorderPoint;
        }
        public int AddStock(int amount)
        {
            CurrentAmount += amount;
            new ItemRepository().Update(this);
            return CurrentAmount;
        }
        public int RemoveStock(int amount)
        {
            CurrentAmount -= amount;
            new ItemRepository().Update(this);
            return CurrentAmount;
        }
        public int UpdateStock(int amount)
        {
            CurrentAmount = amount;
            new ItemRepository().Update(this);
            return CurrentAmount;
        }
        public static Item RandomItem(int id)
        {
            Random r = new Random();
            Item item = new Item();
            item.Id = id;
            item.CategoryId = r.Next(5);
            item.Name = new string[] { "Big", "Small", "Orange", "Quality", "Cheap", "Fancy" }[r.Next(6)] + " " + new string[] { "Pipe", "Apple", "Table", "Silverware set", "Vehicle", "Pencil" }[r.Next(6)];
            item.Description = item.Name + "s " + new string[] { "made with care", "mass produced in china", "with bluetooth functionality", "free of gmos and organic" }[r.Next(4)];
            item.CurrentAmount = r.Next(10000);
            item.ReorderPoint = r.Next(10000);
            item.MaxAmount = r.Next(10000) + item.CurrentAmount + item.ReorderPoint;
            return item;
        }
        override
        public string ToString()
        {
            return $"{Name}\n{Description}\nCategory: {CategoryId}, Id: {Id}\nCurrent: {CurrentAmount}, Reorder: {ReorderPoint}, Max: {MaxAmount}\nCreated: {CreatedAt}, Updated: {LastUpdatedAt}";
        }
    }
}
