using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class CharacterThrow
    {
        [Key]
        [Column(Order = 1)]
        public int CharacterID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ThrowID { get; set; }

        public bool IsProficient { get; set; }

        public int BonusValue { get; set; }

        public int SaveDC { get; set; }

        [ForeignKey("CharacterID")]
        public Character Character { get; set; }

        [ForeignKey("ThrowID")]
        public Throw Throw { get; set; }
    }
}