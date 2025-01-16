using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class Inventory
    {
        [Key]
        public int InventoryID { get; set; }
        public int CharacterID { get; set; }
        public Character Character { get; set; }
        public ICollection<InventoryItem> InventoryItems { get; set; }
    }
}