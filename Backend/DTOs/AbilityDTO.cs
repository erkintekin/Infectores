namespace Backend.DTOs
{
    public class AbilityDTO
    {
        public int AbilityID { get; set; }
        public string AbilityName { get; set; }
        public string Description { get; set; }
    }

    public class AbilityCreateDTO
    {
        public string AbilityName { get; set; }
        public string Description { get; set; }
    }

    public class AbilityUpdateDTO
    {
        public string AbilityName { get; set; }
        public string Description { get; set; }
    }
}