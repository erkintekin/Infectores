using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class Spell
    {
        [Key]
        public int SpellID { get; set; }
        public string Name { get; set; }
        public string Damage { get; set; }
        public string HitDice { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public int Range { get; set; }
        public int Duration { get; set; }
        public ICollection<SpellComponent> Components { get; set; }
        public string CastingTime { get; set; }
        public string? School { get; set; }
        public bool isCantrip { get; set; } // Default no
        public string Source { get; set; }

    }
}