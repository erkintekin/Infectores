namespace Backend.DTOs
{
    public class SkillDTO
    {
        public int SkillID { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string AbilityName { get; set; }
    }

    public class SkillCreateDTO
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int AbilityID { get; set; }
    }

    public class SkillUpdateDTO
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int AbilityID { get; set; }
    }
}