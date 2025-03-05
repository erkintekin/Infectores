namespace Backend.DTOs
{
    public class InventoryDTO
    {
        public int InventoryID { get; set; }
        public int CharacterID { get; set; }
        public float TotalWeight { get; set; }
        public float TotalValue { get; set; }
        public List<InventoryItemDTO> Items { get; set; }
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