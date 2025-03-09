namespace Backend.DTOs
{
    public class AbilityDTO
    {
        public int AbilityID { get; set; }
        public required string AbilityName { get; set; }
        public required string Description { get; set; }
    }

    public class AbilityCreateDTO
    {
        public required string AbilityName { get; set; }
        public required string Description { get; set; }
    }

    public class AbilityUpdateDTO
    {
        public required string AbilityName { get; set; }
        public required string Description { get; set; }
    }
}