using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class Misc
    {
        [Key, ForeignKey(nameof(Item))]
        public int ItemID { get; set; }
        public Item Item { get; set; }
    }
}