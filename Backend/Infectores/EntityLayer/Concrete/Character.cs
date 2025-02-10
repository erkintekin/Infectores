using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class Character
    {
        [Key]
        public int CharacterID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int UserID { get; set; }
        public User? User { get; set; }
        public int ClassID { get; set; }
        public Class? Class { get; set; }
        public int Level { get; set; } = 1;
        public int XP { get; set; } = 0;
        public int InventoryID { get; set; }
        public Inventory? Inventory { get; set; }
        public bool? IsMOB { get; set; } = false;
        public bool? IsNPC { get; set; } = false;
        public int ArmorClass { get; set; } = 10;
        //public string DefaultActions { get; set; }
        public ICollection<CharacterCondition>? Conditions { get; set; }
        public ICollection<CharacterSkill>? Skills { get; set; }
        public ICollection<CharacterSpell>? Spells { get; set; }
        public ICollection<CharacterProficiency>? Proficiencies { get; set; }
        public ICollection<CharacterFeature>? Features { get; set; }
        public ICollection<CharacterSense>? Senses { get; set; }
        public ICollection<CharacterAbility>? Abilities { get; set; }
        public ICollection<CharacterThrow>? Throws { get; set; }
        public ICollection<BonusAction>? BonusActions { get; set; }
    }
}