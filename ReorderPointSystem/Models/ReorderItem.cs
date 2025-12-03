namespace ReorderPointSystem.Models
{
    internal class ReorderItem
    {
        public int ItemId { get; set; }
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
    }
}
