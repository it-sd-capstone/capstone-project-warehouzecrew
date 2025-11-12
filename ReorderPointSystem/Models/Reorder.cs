using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReorderPointSystem.Models
{
    internal class Reorder
    {
        private const string _defaultStatus = "Pending approval";

        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; } = _defaultStatus;
        public DateTime CreatedAt { get; set; }

        public Reorder()
        {
            Id = -1;
            ItemId = -1;
            Quantity = -1;
        }

        public Reorder(int itemId, int quantity = 0, string status = _defaultStatus)
        {
            Id = -1;
            ItemId = itemId;
            Quantity = quantity;
            Status = status;
            CreatedAt = DateTime.MinValue;
        }

        public Reorder(int id, int itemId, int quantity, string status, DateTime createdAt)
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

        public void MarkComplete()
        {
            Status = "Complete";
        }

        public void MarkCancelled()
        {
            Status = "Cancelled";
        }
    }
}
