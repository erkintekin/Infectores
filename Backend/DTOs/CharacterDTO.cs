using System.Collections.Generic;

namespace Backend.DTOs
{
    public class CharacterDTO
    {
        public int CharacterID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int UserID { get; set; }
        public int ClassID { get; set; }
        public string ClassName { get; set; }
        public int Level { get; set; } = 1;
        public int XP { get; set; } = 0;
        public int ArmorClass { get; set; } = 10;
        public bool IsMOB { get; set; } = false;
        public bool IsNPC { get; set; } = false;
        public List<CharacterAbilityDTO> Abilities { get; set; } = new List<CharacterAbilityDTO>();
        public List<CharacterSkillDTO> Skills { get; set; } = new List<CharacterSkillDTO>();
        public List<CharacterSpellDTO> Spells { get; set; } = new List<CharacterSpellDTO>();
        public InventoryDTO Inventory { get; set; }
    }
}