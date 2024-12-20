using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class ItemType
    {
        [Key]
        public int ItemTypeID { get; set; }
        public string Type { get; set; } // Misc, Weapon, Armor
    }
}