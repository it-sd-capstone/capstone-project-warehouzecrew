using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReorderPointSystem.Data;
using ReorderPointSystem.Models;

namespace ReorderPointSystem.Services
{    

    internal class InventoryManager
    {

        private ItemRepository _itemRepo;
        private ReorderRepository _reorderRepo;
        private InventoryLogRepository _inventoryLogRepo;

        public InventoryManager()
        {
            _itemRepo = new ItemRepository();
            _reorderRepo = new ReorderRepository();
            _inventoryLogRepo = new InventoryLogRepository();
        }

        public ItemRepository GetItemRepository()
        {
            return _itemRepo;
        }

        public ReorderRepository GetReorderRepository()
        {
            return _reorderRepo;
        }

        public InventoryLogRepository GetInventoryLogRepository()
        {
            return _inventoryLogRepo;
        }

        public List<Item> GetAllItems()
        {
            return _itemRepo.GetAll();
        }

        public Item addItem(Item item)
        {
            return _itemRepo.Add(item);
        }

        public bool updateItem(Item item)
        {
            return _itemRepo.Update(item);
        }

        public bool deleteItem(int id)
        {
            return _itemRepo.Delete(id);
        }

        public Reorder generateReorder(Item item)
        {
            // TODO 
            // return _reorderRepo.Add(new Reorder(item.Id));
            return null;
        }

        public void addInventoryLog(int itemId, int qtyChange, string type)
        {
            _inventoryLogRepo.Add(new InventoryLog(itemId, qtyChange, type));
        }
    }
}
