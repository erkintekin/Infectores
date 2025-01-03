using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class CharacterAbility
    {
        [Key]
        public int CharacterAbilityID { get; set; }
        public int CharacterID { get; set; }
        public Character Character { get; set; }
        public int AbilityID { get; set; }
        public Ability Ability { get; set; }
    }
}