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
        public List<ReorderItem> Items { get; set; } = new List<ReorderItem>();
        public string Status { get; set; } = _defaultStatus;
        public DateTime CreatedAt { get; set; } = DateTime.MinValue;

        public Reorder()
        {
            Id = -1;
        }

        public Reorder(List<ReorderItem> items, string status = _defaultStatus)
        {
            Id = -1;
            Items = items;
            Status = status;
            CreatedAt = DateTime.MinValue;
        }

        public Reorder(int id, List<ReorderItem> items, string status, DateTime createdAt)
        {
            Id = id;
            Items = items;
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
