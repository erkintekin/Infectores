using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class CharacterSpell
    {
        [Key]
        [Column(Order = 1)]
        public int CharacterID { get; set; }
        public required Character Character { get; set; }

        [Key]
        [Column(Order = 2)]
        public int SpellID { get; set; }
        public required Spell Spell { get; set; }
        public int Level { get; set; }

    }
}