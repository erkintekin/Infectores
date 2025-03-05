namespace Backend.DTOs
{
    public class SkillDTO
    {
        public int SkillID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AbilityName { get; set; }
    }

    public class SkillCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AbilityID { get; set; }
    }

    public class SkillUpdateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AbilityID { get; set; }
    }
}