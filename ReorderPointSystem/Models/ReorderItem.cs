namespace ReorderPointSystem.Models
{
    internal class ReorderItem
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = "Missing Name";
        public int Quantity { get; set; }

        public ReorderItem() {
            ItemId = -1;
            Quantity = -1;
        }

        public ReorderItem(int itemId, int quantity)
        {
            ItemId = itemId;
            Quantity = quantity;
        }

        public ReorderItem(int itemId, int quantity, string name)
        {
            ItemId = itemId;
            Quantity = quantity;
            Name = name;
        }
    }
}
