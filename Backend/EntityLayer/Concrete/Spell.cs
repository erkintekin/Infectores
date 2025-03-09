using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backend.EntityLayer.Concrete
{
    public class Spell
    {
        [Key]
        public int SpellID { get; set; }
        public required string Name { get; set; }
        public required string Damage { get; set; }
        public int DamageTypeID { get; set; } // For different damage types. A spell can have only 1 dmg type
        public required DamageType DamageType { get; set; }
        public required string HitDice { get; set; }
        public required string Description { get; set; }
        public int Level { get; set; }
        public int Range { get; set; }
        public int Duration { get; set; }
        public ICollection<SpellComponent> Components { get; set; }
        public required string CastingTime { get; set; }
        public string? School { get; set; }
        public bool isCantrip { get; set; } = false;
        public required string Source { get; set; }
        public ICollection<CharacterSpell> CharacterSpells { get; set; }

        public Spell()
        {
            Components = new List<SpellComponent>();
            CharacterSpells = new List<CharacterSpell>();
        }
    }
}