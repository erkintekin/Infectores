using System.ComponentModel.DataAnnotations;

namespace Backend.DTOs
{
    public class CharacterDTO // Görüntüleme için
    {
        public int CharacterID { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required]
        [StringLength(50)]
        public required string Surname { get; set; }

        [Required]
        public required string ClassName { get; set; }
        public int Level { get; set; }
        public int XP { get; set; }
        public int ArmorClass { get; set; }
        public bool IsMOB { get; set; }
        public bool IsNPC { get; set; }
        public required List<CharacterAbilityDTO> Abilities { get; init; }
        public required List<CharacterSkillDTO> Skills { get; init; }
        public required List<CharacterSpellDTO> Spells { get; init; }
        public required InventoryDTO Inventory { get; set; }

        public CharacterDTO()
        {
            Abilities = new List<CharacterAbilityDTO>();
            Skills = new List<CharacterSkillDTO>();
            Spells = new List<CharacterSpellDTO>();
        }
    }

    public class CharacterCreateDTO
    {
        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required]
        [StringLength(50)]
        public required string Surname { get; set; }
        public int UserID { get; set; }
        public int ClassID { get; set; }
        public bool IsMOB { get; set; }
        public bool IsNPC { get; set; }
    }

    public class CharacterUpdateDTO
    {
        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required]
        [StringLength(50)]
        public required string Surname { get; set; }
        public int Level { get; set; }
        public int XP { get; set; }
        public int ArmorClass { get; set; }
    }
}