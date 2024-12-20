using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }
        public string Name { get; set; }
        public int GP { get; set; }
        public string? Description { get; set; }
        public int ItemTypeID { get; set; }
        public ItemType ItemType { get; set; }
    }
}