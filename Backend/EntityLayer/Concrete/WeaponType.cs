using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class WeaponType
    {
        [Key]
        public int WeaponTypeID { get; set; }
        public string WeaponType { get; set; }
    }
}