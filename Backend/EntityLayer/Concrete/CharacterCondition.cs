using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class CharacterCondition
    {
        [Key]
        public int CharacterConditionID { get; set; }
        public int CharacterID { get; set; }
        public Character Character { get; set; }
        public int ConditionID { get; set; }
        public Condition Condition { get; set; }
    }
}