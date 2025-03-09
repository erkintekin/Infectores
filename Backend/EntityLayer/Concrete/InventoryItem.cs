using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class InventoryItem
    {
        [Key]
        public int InventoryItemID { get; set; }
        public int InventoryID { get; set; }
        public required Inventory Inventory { get; set; }
        public int ItemID { get; set; }
        public required Item Item { get; set; }
        public int Quantity { get; set; }
        public string? Notes { get; set; }
    }
}