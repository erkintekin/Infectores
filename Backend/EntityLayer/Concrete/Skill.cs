using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class Skill
    {
        [Key]
        public int SkillID { get; set; }
        public string Name { get; set; }
        public string AbilityName { get; set; }  // Modifier like WIS, CHA, INT
        public Ability Ability { get; set; }
        public ICollection<CharacterSkill> CharacterSkills { get; set; }
    }
}