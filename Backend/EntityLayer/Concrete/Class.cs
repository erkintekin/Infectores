using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class Class
    {
        [Key]
        public int ClassID { get; set; }
        [Required]
        public string Name { get; set; }
        public int Speed { get; set; }
        public string HitDice { get; set; } // 1d8 after level 1, 1d8 + const.
        public int ProficiencyID { get; set; }
        public Proficiency? Proficiency { get; set; }
    }
}