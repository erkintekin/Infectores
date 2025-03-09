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
        [Key]
        public int WeaponID { get; set; }
        public required Item Item { get; set; }
        public int Damage { get; set; }
        public int DamageTypeID { get; set; }
        public required DamageType DamageType { get; set; }
        public int WeaponTypeID { get; set; }
        public required WeaponType WeaponType { get; set; }
        public string? Range { get; set; }
        public int Weight { get; set; }
    }
}