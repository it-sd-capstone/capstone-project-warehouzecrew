using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReorderPointSystem.Data;

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
            _inventoryLogRepo = new InventoryLogRepository($"Data Source=rps.db;Version=3;");
        }

    }
}
