namespace Backend.DTOs
{
    public class CharacterSpellDTO
    {
        public int SpellID { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Damage { get; set; }
        public string DamageType { get; set; }
        public string Description { get; set; }
    }
}