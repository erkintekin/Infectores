namespace Backend.DTOs
{
    public class CharacterSpellDTO
    {
        public int CharacterID { get; set; }
        public int SpellID { get; set; }
        public required string SpellName { get; set; }
        public required string Description { get; set; }
        public int SpellLevel { get; set; }
        public bool IsPrepared { get; set; }
        public int SlotsUsed { get; set; }
    }

    public class CharacterSpellCreateDTO
    {
        public int CharacterID { get; set; }
        public int SpellID { get; set; }
        public int SpellLevel { get; set; }
    }

    public class CharacterSpellUpdateDTO
    {
        public bool IsPrepared { get; set; }
        public int SlotsUsed { get; set; }
    }
}