using System.Collections.Generic;

namespace Backend.DTOs
{
    public class SpellDTO
    {
        public int SpellID { get; set; }
        public string Name { get; set; }
        public string Damage { get; set; }
        public string DamageType { get; set; }
        public string HitDice { get; set; }
        public string Description { get; set; }
        public int Range { get; set; }
        public int Duration { get; set; }
        public string CastingTime { get; set; }
        public string School { get; set; }
        public bool IsCantrip { get; set; }
        public List<string> Components { get; set; } = new List<string>();
    }
}