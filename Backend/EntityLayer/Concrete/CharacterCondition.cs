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
        public int CharacterConditionID { get; set; }
        public int CharacterID { get; set; }
        public required Character Character { get; set; }
        public int ConditionID { get; set; }
        public required Condition Condition { get; set; }
    }
}