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
        public required string ActionName { get; set; }
        public int SpellID { get; set; }
        public required Spell Spell { get; set; }
        public required string Description { get; set; }
        public ICollection<CharacterBonusAction> CharacterBonusActions { get; set; }

        public BonusAction()
        {
            CharacterBonusActions = new List<CharacterBonusAction>();
        }
    }
}