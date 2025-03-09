namespace Backend.DTOs
{
    public class CharacterSkillDTO
    {
        public int CharacterID { get; set; }
        public int SkillID { get; set; }
        public required string SkillName { get; set; }
        public required string AbilityName { get; set; }
        public bool IsProficient { get; set; }
        public int Modifier { get; set; }
    }

    public class CharacterSkillCreateDTO
    {
        public int CharacterID { get; set; }
        public int SkillID { get; set; }
        public bool IsProficient { get; set; }
    }

    public class CharacterSkillUpdateDTO
    {
        public bool IsProficient { get; set; }
        public int Modifier { get; set; }
    }
}