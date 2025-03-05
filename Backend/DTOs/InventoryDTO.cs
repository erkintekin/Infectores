using System.Collections.Generic;

namespace Backend.DTOs
{
    public class InventoryDTO
    {
        public int InventoryID { get; set; }
        public int CharacterID { get; set; }
        public List<InventoryItemDTO> Items { get; set; } = new List<InventoryItemDTO>();
    }
}