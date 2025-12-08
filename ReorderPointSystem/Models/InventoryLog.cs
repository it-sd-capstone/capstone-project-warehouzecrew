using ReorderPointSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReorderPointSystem.Models
{
    public class InventoryLog
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int QuantityChange { get; set; } // Positive for restocks, negative for depletion
        public string Type { get; set; }        // e.g., "Received", "Used", "Manual Adjustment"
        public DateTime CreatedAt { get; set; }

        public InventoryLog()
        {
            CreatedAt = GlobalDate.GetUpdatedDate();
        }

        public InventoryLog(int itemId, int quantityChange, string type)
        {
            ItemId = itemId;
            QuantityChange = quantityChange;
            Type = type;
            CreatedAt = GlobalDate.GetUpdatedDate();
        }

        public override string ToString()
        {
            return $"{CreatedAt:g} | ItemID: {ItemId} | {Type} | Change: {QuantityChange}";
        }
    }
}
