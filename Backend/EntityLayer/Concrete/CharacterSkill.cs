using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class CharacterSkill
    {
        [Key]
        public int CharacterID { get; set; }
        public Character Character { get; set; }

        [Key]
        public int SkillID { get; set; }
        public Skill Skill { get; set; }
        public int Bonus { get; set; }
    }
}