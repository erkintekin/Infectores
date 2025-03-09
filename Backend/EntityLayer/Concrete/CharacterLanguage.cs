using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.EntityLayer.Concrete
{
    public class CharacterLanguage
    {
        [Key]
        public int CharacterLanguageID { get; set; }
        public int CharacterID { get; set; }
        public required Character Character { get; set; }
        public int LanguageID { get; set; }
        public required Language Language { get; set; }
    }
}