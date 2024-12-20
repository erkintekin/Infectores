using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class CharacterSkill
    {
        [Key]
        public int CharacterSkillID { get; set; }
        public int CharacterID { get; set; }
        public Character Character { get; set; }
        public int SkillID { get; set; }
        public Skill Skill { get; set; }
    }
}