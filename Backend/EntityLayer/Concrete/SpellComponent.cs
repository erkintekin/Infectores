using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.EntityLayer.Concrete
{
    public class SpellComponent
    {
        [Key]
        [Column(Order = 1)]
        public int SpellID { get; set; }
        public required Spell Spell { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ComponentID { get; set; }
        public required Component Component { get; set; }
    }
}