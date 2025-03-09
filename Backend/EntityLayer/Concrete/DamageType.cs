using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class DamageType
    {
        [Key]
        public int DamageTypeID { get; set; }
        public required string Type { get; set; }  // Bludgeoning, Piercing etc.
        public string? Description { get; set; }
        public ICollection<Weapon> Weapons { get; set; }
        public ICollection<Spell> Spells { get; set; }

        public DamageType()
        {
            Weapons = new List<Weapon>();
            Spells = new List<Spell>();
        }
    }
}