using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class SpellComponent
    {
        [Key]
        public int SpellID { get; set; }
        public Spell Spell { get; set; }
        [Key]
        public int ComponentID { get; set; }
        public Component Component { get; set; }
    }
}