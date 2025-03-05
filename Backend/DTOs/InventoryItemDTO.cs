namespace Backend.DTOs
{
    public class InventoryItemDTO
    {
        public int ItemID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public int GP { get; set; }
        public string Description { get; set; }
        public string ItemType { get; set; }
    }
}