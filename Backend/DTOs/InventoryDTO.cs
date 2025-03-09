namespace Backend.DTOs
{
    public class InventoryDTO
    {
        public int InventoryID { get; set; }
        public int CharacterID { get; set; }
        public float TotalWeight { get; set; }
        public float TotalValue { get; set; }
        public required List<InventoryItemDTO> Items { get; init; } = new();
    }

    public class InventoryCreateDTO
    {
        public int CharacterID { get; set; }
    }

    public class InventoryUpdateDTO
    {
        public float TotalWeight { get; set; }
        public float TotalValue { get; set; }
    }
}