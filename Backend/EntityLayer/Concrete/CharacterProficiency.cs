using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class CharacterProficiency
    {
        [Key]
        public int CharacterProficiencyID { get; set; }
        public int CharacterID { get; set; }
        public Character Character { get; set; }
        public int ProficiencyID { get; set; }
        public Proficiency Proficiency { get; set; }
    }
}