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
        [Key]
        public int MiscID { get; set; }
        [ForeignKey("Item")]
        public int ItemID { get; set; }
        public required Item Item { get; set; }
    }
}