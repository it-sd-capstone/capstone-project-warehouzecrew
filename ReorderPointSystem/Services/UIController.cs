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
            List<Item> items = _inventoryManager.GetItemRepository().GetAll();
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

        public List<Item>? SearchItems(string name)
        {
            if (Validator.IsValidString(name))
            {
                return _inventoryManager.GetItemRepository().Search(name);
            } else
            {
                return null;
            }
        }

        public List<Item> ProcessLowStockReorders(List<Item> itemsIn, List<Reorder> reorders)
        {
            List<Item> itemsOut = new List<Item>();
            List<ReorderItem> reorderItems = itemsOnOrder();

            foreach (Item item in itemsIn)
            {
                if (item.NeedsReorder())
                {
                    if (reorderItems.Find(x => x.ItemId == item.Id) == null)
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

        private List<ReorderItem> itemsOnOrder()
        {
            List<Reorder> reorders = _inventoryManager.GetReorderRepository().GetAll();
            List<ReorderItem> reorderItems = new List<ReorderItem>();
            foreach (Reorder reorder in  reorders)
            {
                List<ReorderItem> items = _inventoryManager.GetReorderRepository().GetById(reorder.Id).Items;
                foreach (ReorderItem item in items)
                {
                    if (!reorderItems.Contains(item) && !reorder.Status.Equals("Complete")) {
                        reorderItems.Add(item);
                    }
                }
            }
            return reorderItems;
        }
    }
}
