using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class Misc
    {
        [Key]
        public int ItemID { get; set; }
        public Item Item { get; set; }
    }
}