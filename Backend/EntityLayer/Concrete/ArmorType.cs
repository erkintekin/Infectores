using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class ArmorType
    {
        [Key]
        public int ArmorTypeID { get; set; }
        public string ArmorType { get; set; }
    }
}