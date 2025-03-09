namespace Backend.DTOs
{
    public class InventoryItemDTO
    {
        public int InventoryID { get; set; }
        public int ItemID { get; set; }
        public required string ItemName { get; set; }
        public required string Description { get; set; }
        public required string ItemType { get; set; }
        public int Quantity { get; set; }
        public float Weight { get; set; }
        public float Value { get; set; }
        public bool IsEquipped { get; set; }
    }

    public class InventoryItemCreateDTO
    {
        public int InventoryID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
    }

    public class InventoryItemUpdateDTO
    {
        public int Quantity { get; set; }
        public bool IsEquipped { get; set; }
    }
}