using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class CharacterBonusAction
    {
        [Key, Column(Order = 1)]
        public int CharacterID { get; set; }
        public Character Character { get; set; }

        [Key, Column(Order = 2)]
        public int BonusActionID { get; set; }
        public BonusAction BonusAction { get; set; }
    }
}