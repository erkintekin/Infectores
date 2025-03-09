using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class CharacterBonusAction
    {
        [Key]
        public int CharacterBonusActionID { get; set; }
        public int CharacterID { get; set; }
        public required Character Character { get; set; }
        public int BonusActionID { get; set; }
        public required BonusAction BonusAction { get; set; }
    }
}