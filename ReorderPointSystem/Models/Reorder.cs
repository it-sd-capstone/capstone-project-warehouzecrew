using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReorderPointSystem.Models
{
    internal class Reorder
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public Reorder()
        {
            Id = -1;
            ItemId = -1;
            Quantity = -1;
        }

        public Reorder(int id, int itemId, int quantity = -1, string status = "", DateTime createdAt = default)
        {
            Id = id;
            ItemId = itemId;
            Quantity = quantity;
            Status = status;
            CreatedAt = createdAt;
        }

        public void MarkInProcess()
        {
            Status = "In process";
        }

        public void MarkCompleted()
        {
            Status = "Complete";
        }
    }
}
