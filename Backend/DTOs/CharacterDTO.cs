namespace Backend.DTOs
{
    public class CharacterDTO // Görüntüleme için
    {
        public int CharacterID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ClassName { get; set; }
        public int Level { get; set; }
        public int XP { get; set; }
        public int ArmorClass { get; set; }
        public bool IsMOB { get; set; }
        public bool IsNPC { get; set; }
        public List<CharacterAbilityDTO> Abilities { get; set; }
        public List<CharacterSkillDTO> Skills { get; set; }
        public List<CharacterSpellDTO> Spells { get; set; }
        public InventoryDTO Inventory { get; set; }
    }

    public class CharacterCreateDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int UserID { get; set; }
        public int ClassID { get; set; }
        public bool IsMOB { get; set; }
        public bool IsNPC { get; set; }
    }

    public class CharacterUpdateDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Level { get; set; }
        public int XP { get; set; }
        public int ArmorClass { get; set; }
    }
}