using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class CharacterSpell
    {
        [Key]
        public int CharacterSpellID { get; set; }
        public int CharacterID { get; set; }
        public Character Character { get; set; }
        public int SpellID { get; set; }
        public Spell Spell { get; set; }
    }
}