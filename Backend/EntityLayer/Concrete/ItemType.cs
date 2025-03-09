using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class ItemType
    {
        [Key]
        public int ItemTypeID { get; set; }
        public required string Type { get; set; } // Misc, Weapon, Armor
        public ICollection<Item> Items { get; set; }

        public ItemType()
        {
            Items = new List<Item>();
        }
    }
}