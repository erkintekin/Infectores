namespace Backend.DTOs
{
    public class CharacterAbilityDTO
    {
        public int CharacterID { get; set; }
        public int AbilityID { get; set; }
        public required string AbilityName { get; set; }
        public int Value { get; set; }
    }
}