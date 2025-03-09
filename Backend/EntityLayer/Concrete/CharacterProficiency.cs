using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class CharacterProficiency
    {
        [Key]
        [Column(Order = 1)]
        public int CharacterID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProficiencyID { get; set; }

        public bool IsProficient { get; set; }

        public int BonusValue { get; set; }

        [ForeignKey("CharacterID")]
        public required Character Character { get; set; }

        [ForeignKey("ProficiencyID")]
        public required Proficiency Proficiency { get; set; }
    }
}