using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class Weapon
    {
        [Key, ForeignKey("Item")]
        public int ItemID { get; set; }
        public Item Item { get; set; }
        public int Damage { get; set; }
        public int DamageTypeID { get; set; }
        public DamageType DamageType { get; set; }
        public int WeaponTypeID { get; set; }
        public WeaponType WeaponType { get; set; }
        public int Range { get; set; }
        public int Weight { get; set; }
    }
}