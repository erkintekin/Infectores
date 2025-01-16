using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class Armor
    {
        [Key, ForeignKey("Item")]
        public int ItemID { get; set; }
        public Item Item { get; set; }
        public int Defense { get; set; }
        public int ArmorTypeID { get; set; }
        public ArmorType ArmorType { get; set; }
    }
}