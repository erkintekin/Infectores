using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class CharacterCondition
    {
        [Key]
        [Column(Order = 1)]
        public int CharacterID { get; set; }
        public Character Character { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ConditionID { get; set; }
        public Condition Condition { get; set; }
    }
}