using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class Skill
    {
        [Key]
        public int SkillID { get; set; }
        public string Name { get; set; }
        public string AbilityName { get; set; }  // Modifier like WIS, CHA, INT
        public Ability Ability { get; set; }
        public int Bonus { get; set; }
        public ICollection<CharacterSkill> CharacterSkills { get; set; }
    }
}