using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }
        public required string Name { get; set; }
        public int GP { get; set; }
        public string? Description { get; set; }
        public int ItemTypeID { get; set; }
        public required ItemType ItemType { get; set; }
        public Misc? Misc { get; set; }
        public ICollection<InventoryItem> InventoryItems { get; set; }

        public Item()
        {
            InventoryItems = new List<InventoryItem>();
        }
    }
}