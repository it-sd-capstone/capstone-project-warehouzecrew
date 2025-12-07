using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReorderPointSystem.Models
{
    public class Item
    {
        // Properties
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CurrentAmount { get; set; }
        public int ReorderPoint { get; set; }
        public int MaxAmount { get; set; }
        public bool ReorderEnabled { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
       
        // Constructors
        public Item()
        {
            Id = -1;
            CategoryId = -1;
            Name = "";
            Description = "";
            CurrentAmount = -1;
            ReorderPoint = -1;
            MaxAmount = -1;
            ReorderEnabled = false;
            CreatedAt = DateTime.MinValue;
            LastUpdatedAt = DateTime.MinValue;
        }

        public Item(int id, int categoryId, string name, string description, int currentAmount, int reorderPoint, int maxAmount, bool enableReorder = false)
        {
            Id = id;
            CategoryId = categoryId;
            Name = name;
            Description = description;
            CurrentAmount = currentAmount;
            ReorderPoint = reorderPoint;
            MaxAmount = maxAmount;
            ReorderEnabled = enableReorder;
            CreatedAt = DateTime.Now;
            LastUpdatedAt = DateTime.Now;
        }

        public Item(int id, int categoryId, string name, string description, int currentAmount, int reorderPoint, int maxAmount, bool enableReorder, DateTime createdAt, DateTime updatedAt)
        {
            Id = id;
            CategoryId = categoryId;
            Name = name;
            Description = description;
            CurrentAmount = currentAmount;
            ReorderPoint = reorderPoint;
            MaxAmount = maxAmount;
            ReorderEnabled = enableReorder;
            CreatedAt = createdAt;
            LastUpdatedAt = updatedAt;
        }

        // Methods
        public bool NeedsReorder()
        {
            if (ReorderEnabled)
            {
                return CurrentAmount < ReorderPoint;
            }
            else
            {
                return false;
            }
        }

        public int AddStock(int amount)
        {
            CurrentAmount += amount;
            return CurrentAmount;
        }

        public int RemoveStock(int amount)
        {
            CurrentAmount -= amount;
            return CurrentAmount;
        }

        public int UpdateStock(int amount)
        {
            CurrentAmount = amount;
            return CurrentAmount;
        }
    }
}
