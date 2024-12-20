using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class InventoryItem
    {
        [Key]
        public int InventoryItemID { get; set; }
        public int InventoryID { get; set; }
        public Inventory Inventory { get; set; }
        public int ItemID { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public string? Notes { get; set; }
    }
}