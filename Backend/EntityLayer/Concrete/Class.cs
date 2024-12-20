using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class Class
    {
        [Key]
        public int ClassID { get; set; }
        public string Name { get; set; }
        public int Speed { get; set; }
        public string HitDice { get; set; } // 1d8 after level 1, 1d8 + const.
        public string ProficiencyID { get; set; }
        public Proficiency? Proficiency { get; set; }
    }
}