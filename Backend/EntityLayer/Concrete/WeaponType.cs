using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class WeaponType
    {
        [Key]
        public int WeaponTypeID { get; set; }
        public required string Type { get; set; }
        public ICollection<Weapon> Weapons { get; set; }

        public WeaponType()
        {
            Weapons = new List<Weapon>();
        }
    }
}