using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class Ability
    {
        [Key]
        public int AbilityID { get; set; }
        public string AbilityName { get; set; }
        public string Value { get; set; }
        public string? Description { get; set; }
    }
}