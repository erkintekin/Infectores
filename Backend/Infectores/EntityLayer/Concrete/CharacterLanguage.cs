using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class CharacterLanguage
    {
        [Key, Column(Order = 1)]
        public int CharacterID { get; set; }
        public Character Character { get; set; }

        [Key, Column(Order = 2)]
        public int LanguageID { get; set; }
        public Language Language { get; set; }
    }
}