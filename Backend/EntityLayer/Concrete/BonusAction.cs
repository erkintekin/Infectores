using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backend.EntityLayer.Concrete
{
    public class BonusAction
    {
        [Key]
        public int BonusActionID { get; set; }
        public string ActionName { get; set; }
        public int? SpellID { get; set; }
        public Spell Spell { get; set; }
        public string Description { get; set; }
    }
}